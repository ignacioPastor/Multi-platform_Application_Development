
package bankaccountsynchronized;

/**
 *
 * @author Ignacio
 */
public class BankThreadSpend implements Runnable{

    BankAccount bankAccount;
    public BankThreadSpend(BankAccount bankAccount){
        this.bankAccount = bankAccount;
    }
    @Override
    public void run() {
        for (int i = 0; i < 5; i++) {
            bankAccount.takeOutMoney(100);
            try{
                Thread.sleep(100);
            }catch(InterruptedException ex){}
        }
    }

}
