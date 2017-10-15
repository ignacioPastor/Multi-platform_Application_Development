
package dishwasher;


/**
 *
 * @author Ignacio
 */
public class Dryer extends Thread {
    
    int n;
    DishPile pile;
    
    public Dryer(int n, DishPile pile){
        this.n = n;
        this.pile = pile;
    }
    
    @Override
    public void run(){
        for (int i = 0; i < n; i++) {
            pile.dry();
            try {
                Thread.sleep(100);
            } catch (InterruptedException ex) {}
        }
    }
}
