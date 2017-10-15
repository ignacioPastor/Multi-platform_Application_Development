
package bankaccountlock;

import java.util.concurrent.locks.Lock;
import java.util.concurrent.locks.ReentrantLock;

/**
 *
 * @author Ignacio
 */
public class BankAccount {
    
    int balance;
    Lock myLock = new ReentrantLock();
    
    public BankAccount(int balance){
        this.balance = balance;
    }
    public int getBalance(){return balance;}
    
    public void addMoney(int money){
        myLock.lock();
        try {
            balance += money;
            System.out.println("Add Money, current balance: " + balance);
        } finally {
            myLock.unlock();
        }
    }
    public void takeOutMoney(int money){
        myLock.lock();
        try{
            balance -= money;
            System.out.println("Take Money, curren balance: " + balance);
        }finally{
            myLock.unlock();
        }
    }
}
