
package threadracepriorities;

import java.util.Random;

/**
 *
 * @author Ignacio
 */
public class MyThread extends Thread{
    int n;
    Random r = new Random();
    public MyThread(){
        n = 0;
    }
    @Override
    public void run(){
        for (int i = 0; i < 1000; i++) {
            
            n++;
            System.gc();
        }
    }
    public int getNumber(){
        return n;
    }
}
