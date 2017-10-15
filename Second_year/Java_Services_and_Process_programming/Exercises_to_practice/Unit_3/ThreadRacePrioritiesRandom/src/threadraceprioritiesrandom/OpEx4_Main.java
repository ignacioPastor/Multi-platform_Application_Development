/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package threadraceprioritiesrandom;

import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Ignacio
 */
public class OpEx4_Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        MyThread t1 = new MyThread(1);
        MyThread t2 = new MyThread(5);
        MyThread t3 = new MyThread(10);
        
        t1.setName("A");
        t2.setName("B");
        t3.setName("C");
        
        t1.start();
        t2.start();
        t3.start();
        
        do{
            System.out.println("Thread " + t1.getName() + ": " + t1.getNumber()
                + "; Thread " + t2.getName() + ": " + t2.getNumber()
                + "; Thread " + t3.getName() + ": " + t3.getNumber());
            try {
                Thread.sleep(50);
            } catch (InterruptedException ex) { }
        }while(t1.isAlive() || t2.isAlive() || t3.isAlive());
        
    }
    
}
