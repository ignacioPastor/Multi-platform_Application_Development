
package multiplierthreadsjoin;

/**
 *
 * @author Ignacio
 */
public class MyThread extends Thread{
    int n;
    Thread threadWait;
    public MyThread(int n){
        this.n = n;
        threadWait = null;
    }
    public MyThread(Thread threadWait, int n){
        this.threadWait = threadWait;
        this.n = n;
    }
    public int getNumber(){return n;}
    @Override
    public void run(){
        if(threadWait != null){
            try{
                threadWait.join();
            }catch(InterruptedException e){}
        }
        for (int i = 0; i <= 10; i++)
            System.out.println(n + " x " + i + " = " + n*i);
        System.out.println();
    }
}
