
package threadrace;

/**
 *
 * @author Ignacio
 */
public class MyThread extends Thread{
    int n;
    public MyThread(){
        n = 0;
    }
    public int getN(){
        return n;
    }
    @Override
    public void run() {
        for (int i = 1; i <= 1000; i++) {
            System.gc();
            n = i;
        }
    }

}
