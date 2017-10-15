/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package multiplierthreadsjoin;

/**
 *
 * @author Ignacio
 */
public class Ex6_Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        
        MyThread t1 = new MyThread(11);
        MyThread t2 = new MyThread(t1, 12);
        MyThread t3 = new MyThread(t2, 13);
        MyThread t4 = new MyThread(t3, 14);
        MyThread t5 = new MyThread(t4, 15);
        MyThread t6 = new MyThread(t5, 16);
        MyThread t7 = new MyThread(t6, 17);
        MyThread t8 = new MyThread(t7, 18);
        MyThread t9 = new MyThread(t8, 19);
        MyThread t10 = new MyThread(t9, 20);
        
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
