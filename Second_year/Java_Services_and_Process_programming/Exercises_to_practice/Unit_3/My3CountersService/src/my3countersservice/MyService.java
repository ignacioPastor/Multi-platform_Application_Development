
package my3countersservice;

import javafx.concurrent.Service;
import javafx.concurrent.Task;
import javafx.scene.control.Button;

/**
 *
 * @author Ignacio
 */
public class MyService extends Service<Void>{

    int nFrom;
    int nTo;
    Button button;
    
    public MyService(int nFrom, int nTo, Button button){
        this.nFrom = nFrom;
        this.nTo = nTo;
        this.button = button;
    }
    
    public void setFrom(int nFrom){this.nFrom = nFrom;}
    public int getFrom(){return nFrom;}
    public void setTo(int nTo){this.nTo = nTo;}
    public int getTo(){return nTo;}
    
    @Override
    protected Task<Void> createTask() {
        
        return new Task(){
            @Override
            protected Void call() throws Exception {
                if(nFrom < nTo){
                    for (int i = nFrom; i <= nTo; i++) {
                        updateMessage("Counting... " + i);
                        Thread.sleep(1000);
                    }
                    button.setDisable(false);
                }else{
                    for (int i = nFrom; i >= nTo; i--) {
                        updateMessage("Counting... " + i);
                        Thread.sleep(1000);
                    }
                    button.setDisable(false);
                }
                return null;
            }
        
        };
    }

}
