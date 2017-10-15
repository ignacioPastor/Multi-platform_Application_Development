/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package threadracekilled;

/**
 *
 * @author Ignacio
 */
public class Ex4_Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        MyThread t1 = new MyThread();
        MyThread t2 = new MyThread();
        MyThread t3 = new MyThread();
        
        t1.setName("A");
        t2.setName("B");
        t3.setName("C");
        
        t1.start();
        t2.start();
        t3.start();
        
        do{
            try{
                Thread.sleep(100);
            }catch(InterruptedException i){}
            System.out.println("Thread " + t1.getName() + ": " + t1.getN()
                    + "; Thread " + t2.getName() + ": " + t2.getN()
                    + "; Thread " + t3.getName() + ": " + t3.getN());
        }while(t1.isAlive() || t2.isAlive() || t3.isAlive());
    }
    
}
