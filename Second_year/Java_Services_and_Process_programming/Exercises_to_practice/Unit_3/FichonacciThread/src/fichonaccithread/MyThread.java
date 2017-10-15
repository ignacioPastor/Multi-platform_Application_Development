
package fichonaccithread;

/**
 *
 * @author Ignacio
 */
public class MyThread extends Thread{
    
    private int n, n1 = 1, n2 = 1, tmp;
    
    public MyThread(){
        n = 0;
    }
    public MyThread(int n){
        this.n = n;
    }
    
    public void setN(int n){
        this.n = n;
    }
    public int getN(){
        return n;
    }
    
    @Override
    public void run(){
        System.out.print(n1 + " " + n2);
        tmp = n1 + n2;
        while(tmp < n){
            n1 = n2;
            n2 = tmp;
            System.out.print(" " + tmp);
            tmp = n1 + n2;
        }
        System.out.println();
    }
}
