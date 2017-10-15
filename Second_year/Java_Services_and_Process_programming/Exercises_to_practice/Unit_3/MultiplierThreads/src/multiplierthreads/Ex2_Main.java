/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package multiplierthreads;

/**
 *
 * @author Ignacio
 */
public class Ex2_Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        
        Thread t1 = new MyThread(11);
        Thread t2 = new MyThread(12);
        Thread t3 = new MyThread(13);
        Thread t4 = new MyThread(14);
        Thread t5 = new MyThread(15);
        Thread t6 = new MyThread(16);
        Thread t7 = new MyThread(17);
        Thread t8 = new MyThread(18);
        Thread t9 = new MyThread(19);
        Thread t10 = new MyThread(20);
        
        t1.start();
        t2.start();
        t3.start();
        t4.start();
        t5.start();
        t6.start();
        t7.start();
        t8.start();
        t9.start();
        t10.start();
        
    }
    
}
