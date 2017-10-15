
package threadracejoin;

import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Ignacio
 */
public class MyThread extends Thread{
    Thread threadWait;
    int n;
    public MyThread(){
        threadWait = null;
        n = 0;
    }
    public MyThread(Thread threadWait){
        this.threadWait = threadWait;
        n = 0;
    }
    public int getN(){return n;}
    @Override
    public void run(){
        if(threadWait != null){
            try {
                threadWait.join();
            } catch (InterruptedException ex) {}
        }
        while(n < 1000){
            System.gc();
            n++;
        }
    }
}
