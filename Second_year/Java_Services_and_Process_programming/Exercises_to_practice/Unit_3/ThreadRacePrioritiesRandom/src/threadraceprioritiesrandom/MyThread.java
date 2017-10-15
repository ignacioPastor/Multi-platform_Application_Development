
package threadraceprioritiesrandom;

import java.util.Random;

/**
 *
 * @author Ignacio
 */
public class MyThread extends Thread{
    
    int n, priority;
    Random r = new Random();
    public MyThread(int priority){
        n = 0;
        this.priority = priority;
    }
    public int getNumber(){return n;}
    @Override
    public void run() {
        for (int i = 0; i < 1000; i++) {
            if(r.nextInt(11) >= priority)
                MyThread.yield();
            System.gc();
            n++;
        }
    }
    

}
