
package bankaccountsynchronizedobject;

import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Ignacio
 */
public class BankThreadSave implements Runnable{
    BankAccount ba;
    public BankThreadSave(BankAccount ba){
        this.ba = ba;
    }
    @Override
    public void run() {
        for (int i = 0; i < 5; i++) {
            ba.addMoney(100);
            try {
                Thread.sleep(100);
            } catch (InterruptedException ex) {}
        }
    }

}
