
package readerswriterslock;

import java.util.Random;
import java.util.concurrent.TimeUnit;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Ignacio
 */
public class WritingThread extends Thread{
    MyData sharedData;
    Random r = new Random();
    public WritingThread(MyData sharedData){
        this.sharedData = sharedData;
    }
    @Override
    public void run(){
        try {
            TimeUnit.SECONDS.sleep(r.nextInt(10) + 1);
        } catch (Exception ex) {}
        sharedData.setValue(10);
    }
}
