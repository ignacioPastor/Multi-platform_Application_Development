/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package threadracepriorities;

import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Ignacio
 */
public class ThreadRacePriorities {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        MyThread tA = new MyThread();
        MyThread tB = new MyThread();
        MyThread tC = new MyThread();
        
        tA.setName("A");
        tB.setName("B");
        tC.setName("C");
         
        tA.setPriority(Thread.MAX_PRIORITY);
        tB.setPriority(Thread.NORM_PRIORITY);
        tC.setPriority(Thread.MIN_PRIORITY);
        
        tA.start();
        tB.start();
        tC.start();
        
        do{
            System.out.println("Thread " + tA.getName() + ": " + tA.getNumber()
                    + "; Thread " + tB.getName() + ": " + tB.getNumber()
                    + "; Thread " + tC.getName() + ": " + tC.getNumber());
            try {
                Thread.sleep(100);
            } catch (InterruptedException ex) { }
        }while(tA.isAlive() || tB.isAlive() || tC.isAlive());
    }
    
}
