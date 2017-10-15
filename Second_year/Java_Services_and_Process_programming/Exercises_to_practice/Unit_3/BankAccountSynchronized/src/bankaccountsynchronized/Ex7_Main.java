/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package bankaccountsynchronized;

/**
 *
 * @author Ignacio
 */
public class Ex7_Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        
        BankAccount bA = new BankAccount(1000);
        Thread[] t = new Thread[40];
        for (int i = 0; i < t.length; i++) {
            if(i % 2 == 0)
                t[i] = new Thread(new BankThreadSave(bA));
            else
                t[i] = new Thread(new BankThreadSpend(bA));
        }
        for (int i = 0; i < t.length; i++) {
            t[i].start();
        }
    }
}
