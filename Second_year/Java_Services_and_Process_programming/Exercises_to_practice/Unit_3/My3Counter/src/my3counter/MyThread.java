
package my3counter;

import java.util.logging.Level;
import java.util.logging.Logger;
import javafx.application.Platform;
import javafx.scene.control.Label;

/**
 *
 * @author Ignacio
 */
public class MyThread extends Thread{

    int nFrom;
    int nTo;
    Label label;
    
    public MyThread(int nFrom, int nTo, Label label){
        this.nFrom = nFrom;
        this.nTo = nTo;
        this.label = label;
    }
    
    @Override
    public void run(){
        if(nFrom < nTo){
            while(nFrom <= nTo){
                Platform.runLater(()->{
                   label.setText("Counting... " + nFrom++);
                });
                try {
                    Thread.sleep(1000);
                } catch (InterruptedException ex) {}
            }
        }else{
            while(nFrom >= nTo){
                Platform.runLater(()->{
                   label.setText("Counting... " + nFrom--);
                });
                try {
                    Thread.sleep(1000);
                } catch (InterruptedException ex) {}
            }
        }
    }
}
