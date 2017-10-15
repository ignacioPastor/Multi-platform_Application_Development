
package multiplierthreads;

/**
 *
 * @author Ignacio
 */
public class MyThread extends Thread {
    int n;
    public MyThread(){
        
    }
    public MyThread(int n){
        this.n = n;
    }
    @Override
    public void run(){
        for (int i = 0; i < 10; i++) {
            System.out.println(n + " x " + i + " = " + n * i);
        }
    }
}
