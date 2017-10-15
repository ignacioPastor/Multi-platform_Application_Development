/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package atomiccounter;

import java.util.concurrent.atomic.AtomicInteger;

/**
 *
 * @author Ignacio
 */
public class Ex12_Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        
        AtomicInteger n = new AtomicInteger();
        n.set(0);
        
        Thread tSum = new Thread(()->{
            for (int i = 0; i < 100; i++) {
                n.getAndIncrement();
                System.out.println("Increment: " + n.get());
            }
        });
        Thread tSub = new Thread(()->{
            for (int i = 0; i < 100; i++) {
                n.getAndDecrement();
                System.out.println("Decrement: " + n.get());
            }
        });
        tSum.start();
        tSub.start();
        
        
             
    }
    
}
