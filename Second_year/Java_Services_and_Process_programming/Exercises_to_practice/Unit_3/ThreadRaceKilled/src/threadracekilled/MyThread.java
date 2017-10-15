
package threadracekilled;

/**
 *
 * @author Ignacio
 */
public class MyThread extends Thread{
    int n;
    boolean finish;
    public MyThread(){
        n = 0;
        finish = false;
    }
    public int getN(){
        return n;
    }
    @Override
    public void run(){
        while(n < 1000 && !finish){
            System.gc();
            n++;
            if(this.getName().equals("A") && n == 700)
                finish = true;
        }
    }
}
