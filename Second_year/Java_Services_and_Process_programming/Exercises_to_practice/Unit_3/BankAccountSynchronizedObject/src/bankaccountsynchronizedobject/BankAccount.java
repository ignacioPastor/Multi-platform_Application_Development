
package bankaccountsynchronizedobject;

/**
 *
 * @author Ignacio
 */
public class BankAccount {
    int balance;
    public BankAccount(int balance){
        this.balance = balance;
    }
    public int getBalance(){
        return balance;
    }
    public void addMoney(int money){
        synchronized(this){
            balance += money;
            System.out.println("Add money. Current balance: " + balance);
        }
    }
    public void takeOutMoney(int money){
        synchronized(this){
            balance -= money;
            System.out.println("Spend money. Current balance: " + balance);
        }
    }

}
