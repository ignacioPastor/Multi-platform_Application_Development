
package bankaccountsynchronized;

/**
 *
 * @author Ignacio
 */
public class BankAccount {
    int balance;
    
    public BankAccount(int balance){
        this.balance = balance;
    }
    public synchronized void addMoney(int money){
        balance += money;
        System.out.println("AddMoney, current balance = " + balance);
    }
    
    public synchronized void takeOutMoney(int money){
        balance -= money;
        System.out.println("TakeOutMoney, current balance = " + balance);
    }
    public int getBalance(){
        return balance;
    }
}
