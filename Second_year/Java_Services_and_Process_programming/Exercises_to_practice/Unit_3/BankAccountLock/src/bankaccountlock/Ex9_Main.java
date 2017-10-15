/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package bankaccountlock;

/**
 *
 * @author Ignacio
 */
public class Ex9_Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Thread[] t = new Thread[40];
        BankAccount ba = new BankAccount(1000);
        
        for (int i = 0; i < 40; i++) {
            if(i%2==0)
                t[i] = new BankThreadSave(ba);
            else
                t[i] = new BankThreadSpend(ba);
            t[i].start();
        }
        
    }
    
}
