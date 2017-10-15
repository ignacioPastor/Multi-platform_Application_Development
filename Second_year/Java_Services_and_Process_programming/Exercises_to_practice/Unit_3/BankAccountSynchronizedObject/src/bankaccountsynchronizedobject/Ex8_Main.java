/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package bankaccountsynchronizedobject;

/**
 *
 * @author Ignacio
 */
public class Ex8_Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        BankAccount ba = new BankAccount(1000);
        
        int aLength = 20;
        Thread[] tSv = new Thread[aLength];
        Thread[] tSp = new Thread[aLength];
        
        for (int i = 0; i < aLength; i++) {
            tSv[i] = new Thread(new BankThreadSave(ba));
            tSp[i] = new Thread(new BankThreadSpend(ba));
        }
        for (int i = 0; i < aLength; i++) {
            tSv[i].start();
            tSp[i].start();
        }
        
        
    }
    
}
