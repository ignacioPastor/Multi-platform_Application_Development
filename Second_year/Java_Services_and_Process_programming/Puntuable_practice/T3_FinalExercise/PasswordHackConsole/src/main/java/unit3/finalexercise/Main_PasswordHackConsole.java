
package unit3.finalexercise;
/**
 * FinalExercise PSP Unit 3
 */

import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.Map;
import java.util.concurrent.CompletableFuture;
import java.util.concurrent.ConcurrentMap;
import java.util.concurrent.ConcurrentSkipListMap;
import java.util.concurrent.Executors;
import java.util.concurrent.ScheduledExecutorService;
import java.util.concurrent.TimeUnit;
import java.util.stream.Collectors;
import org.apache.commons.codec.digest.DigestUtils;

/**
 * This class manage the program for break passwords encrypted by sha256Hex
 * @author Ignacio Pastor Padilla, DAM Semipresencial
 */
public class Main_PasswordHackConsole {
    //Main collection, here we save the encrypted password as key and decrypted as value
    public static ConcurrentMap<String, String> resultMap = new ConcurrentSkipListMap<>();
    
    public static CompletableFuture<Void> decryptPass(String encrypted) {
        return CompletableFuture.supplyAsync(() -> { // Async thread
                for (int i = 0; i <= 999999; i++) {
                    if(DigestUtils.sha256Hex(new DecimalFormat("000000").format(i)).equals(encrypted)){
                        return String.valueOf(new DecimalFormat("000000").format(i));
                    }
                }
                return "NOT FOUND";
        }).thenAccept(result -> { // Same thread as before
            resultMap.put(encrypted, result);
        });
    }
    public static void main(String[] args){
        //We read the file with encrypted passwords
        ArrayList<String> listPassword = new ArrayList<>();
        BufferedReader reader;
        try{
            reader = new BufferedReader(new FileReader(new File("password.txt")));
            String line = "";
            while((line = reader.readLine()) != null){
                listPassword.add(line);
            }
            reader.close();
        }catch(FileNotFoundException fnf){
            System.err.println("File of password not found");
            System.exit(1);
        }catch(IOException io){
            System.err.println("Error reading password file: " + io.getMessage());
        }
        ScheduledExecutorService executor = Executors.newScheduledThreadPool(listPassword.size());
        CompletableFuture<Void>[] listFutures = new CompletableFuture[listPassword.size()];
        
        //If we want use allOf, we need transfer our data from list to array
        listPassword.stream()
            .map(p -> decryptPass(p))
            .collect(Collectors.toList())
            .toArray(listFutures);
        
        CompletableFuture<Void> allTask = CompletableFuture.allOf(
                listFutures
        );
        //When allTask have finished, print result
        allTask.thenRun(() -> {
            try{
                TimeUnit.MILLISECONDS.sleep(1001);
                executor.shutdown();
            }catch(InterruptedException ex){
                executor.shutdownNow();
            }
            for (Map.Entry<String, String> entry : resultMap.entrySet())
                System.out.println(entry.getKey() + " = " + entry.getValue());
        });
        /**
         * Check and inform periodically about pregresion of objectives
         */
        Runnable task = () -> {
            int nFinished;
            int percent;
            nFinished = resultMap.size();
            percent = (nFinished * 100) / listPassword.size();
            System.out.println(nFinished + " decoded : " + percent + "%");
        };
        executor.scheduleAtFixedRate(task, 1, 1000, TimeUnit.MILLISECONDS);
        while(!allTask.isDone()){
            try{
                TimeUnit.MILLISECONDS.sleep(100);
            }catch(InterruptedException ex){}
        }
    }
}