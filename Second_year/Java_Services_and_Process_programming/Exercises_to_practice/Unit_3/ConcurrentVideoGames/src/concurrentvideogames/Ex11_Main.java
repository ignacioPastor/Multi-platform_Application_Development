/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package concurrentvideogames;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.concurrent.Executors;
import java.util.concurrent.LinkedBlockingDeque;
import java.util.concurrent.ThreadPoolExecutor;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Ignacio
 */
public class Ex11_Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        
        ArrayList<VideoGame> arrayList = new ArrayList<>();
        ThreadPoolExecutor executor =  (ThreadPoolExecutor)Executors.newCachedThreadPool();
        for (int i = 0; i < 100; i++) {
            arrayList.add(new VideoGame("Videogame " + i, 50));
        }
        Thread tSum = new Thread( () -> {
            for (int i = 0; i < 100; i++) {
                arrayList.get(i).setPrice(arrayList.get(i).getPrice() + 1);
                System.out.println("Sumando, " + arrayList.get(i).getName()
                        + " Precio: " + arrayList.get(i).getPrice());
            }
        });
        Thread tSub = new Thread( () -> {
            for (int i = 0; i < 100; i++) {
                arrayList.get(i).setPrice(arrayList.get(i).getPrice() - 1);
                System.out.println("Restando, " + arrayList.get(i).getName()
                        + " Precio: " + arrayList.get(i).getPrice());
            }
        });
        
        Thread t = new Thread( () -> {
            for (int i = 0; i < 10; i++) {
                System.out.println("Prueba " + i);
            }
        });
        
//        executor.execute(tSum);
//        executor.execute(tSub);
//        executor.shutdown();
        tSub.start();
        tSum.start();
        try {Thread.sleep(5000);} catch (InterruptedException ex) {}
        for (int i = 0; i < arrayList.size(); i++) {
            System.out.println(arrayList.get(i).getName() + ", price: " + arrayList.get(i).getPrice());
        }
//------------------------------------------------------------------------------------------------------------------------------------
        System.out.println();
        System.out.println();
        System.out.println();
        
        try {Thread.sleep(2000);} catch (InterruptedException ex) {}
                
        LinkedBlockingDeque<VideoGame> linquedB = new LinkedBlockingDeque<>();
        
        for (int i = 0; i < 100; i++) {
            try {
                linquedB.put(new VideoGame("L_VideoGame " + i, 100));
            } catch (InterruptedException ex) {}
        }
        Thread tLSum = new Thread(()->{
            Iterator<VideoGame> it = linquedB.iterator();
            VideoGame v;
            while(it.hasNext()){
                v = it.next();
                v.setPrice(v.getPrice() + 1);
                System.out.println("Sumando, " + v.getName() + ", price: " + v.getPrice());
            }
        });
        Thread tLSub = new Thread(()->{
            Iterator<VideoGame> it = linquedB.iterator();
            VideoGame v;
            while(it.hasNext()){
                v = it.next();
                v.setPrice(v.getPrice() - 1);
                System.out.println("Restando, " + v.getName() + ", price: " + v.getPrice());
            }
        });
        
        tLSum.start();
        tLSub.start();
        try {Thread.sleep(5000);} catch (InterruptedException ex) {}
        Iterator<VideoGame> it = linquedB.iterator();
            VideoGame v;
            while(it.hasNext()){
                v = it.next();
                System.out.println(v.getName() + ", price: " + v.getPrice());
            }
    }
}
