/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package callablewordcounting;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.util.Arrays;
import java.util.List;
import java.util.concurrent.Callable;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.Future;
import java.util.concurrent.TimeUnit;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Ignacio
 */
public class Ex13_Main {

    
    public static Callable<Integer> getNumberWord(String word, String text){
        return () -> { //Callable
            try{
                BufferedReader reader = new BufferedReader(new FileReader(new File(text)));
                int number = 0;
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
                reader.close();
                return number;
            }catch(Exception e){
                System.err.println("Error: " + e.getMessage());
                throw new IllegalStateException("task interrupted", e);
            }
        };
    }
    public static void main(String[] args) {
        String text1 = "text1.txt";
        String text2 = "text2.txt";
        String text3 = "text3.txt";
        String word = "java";
        
        List<Callable<Integer>> callables = Arrays.asList(getNumberWord(word, text1),
                getNumberWord(word, text2), getNumberWord(word, text3));
        
        ExecutorService executor = Executors.newFixedThreadPool(3);
        
        List<Future<Integer>> futures;
        int nWords = 0;
        try{
            futures = executor.invokeAll(callables);
            executor.shutdown();
            for(Future f : futures){
                try{
                    nWords += (int)f.get();
                }catch(InterruptedException | ExecutionException e2){}
            }
        }catch(InterruptedException e){
            throw new IllegalStateException(e);
        }
        System.out.println("The word " + word + " appears " + nWords + " times.");
    }
}