
package bankaccountsynchronizedobject;

import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Ignacio
 */
public class BankThreadSpend implements Runnable{
    BankAccount ba;
    public BankThreadSpend(BankAccount ba){
        this.ba = ba;
    }

    @Override
    public void run() {
        for (int i = 0; i < 5; i++) {
            ba.takeOutMoney(100);
            try {
                Thread.sleep(100);
            } catch (InterruptedException ex) {}
        }
    }
    
}
