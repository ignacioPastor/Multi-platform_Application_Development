/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package fastestwordcounting;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.util.concurrent.Callable;
import java.util.concurrent.CompletableFuture;
import java.util.concurrent.ExecutionException;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Ignacio
 */
public class Ex14_Main {
    static int number2 = 0;
    public static CompletableFuture<Object> getNumberWord(String word, String text){
        return CompletableFuture.supplyAsync(() -> { //CompletableFuture
            try{
                int number;
                try (BufferedReader reader = new BufferedReader(new FileReader(new File(text)))) {
                    number = 0;
                    String line;
                    String[] splitLine;
                    while((line = reader.readLine()) != null){
                        if(line.toUpperCase().contains(word.toUpperCase())){
                            splitLine = line.split(" ");
                            for(String s : splitLine)
                                if(s.toUpperCase().contains(word.toUpperCase()))
                                    number++;
                        }
                    }   
                }
                System.out.println(text + " Task finished!");
                number2 = number;
                return number;
            }catch(Exception e){
                System.err.println("Error: " + e.getMessage());
                throw new IllegalStateException("task interrupted", e);
            }
        });
    }
    public static void main(String[] args) {
        String text1 = "text1.txt";
        String text2 = "text2.txt";
        String text3 = "text3.txt";
        String word = "java";
        
        CompletableFuture<Object> allTask = CompletableFuture.anyOf(getNumberWord(word, text1),
                getNumberWord(word, text2),getNumberWord(word, text3));
        allTask.thenRun(()->{
            try {
                System.out.println("The first thread has finished and found the text \"" + word + "\" " + number2 + " times." + (Integer) allTask.get());
            } catch (InterruptedException | ExecutionException ex) {    
                System.err.println("Error: " + ex.getMessage());
            }
        });
        while(!allTask.isDone()){
            try {
                Thread.sleep(100);
            } catch (InterruptedException ex) {}
        }
    }
}
