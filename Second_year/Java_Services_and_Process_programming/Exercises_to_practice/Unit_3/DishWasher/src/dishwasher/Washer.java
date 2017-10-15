
package dishwasher;


/**
 *
 * @author Ignacio
 */
public class Washer extends Thread{
    DishPile pile;
    int n;
    int id = 0;
    public Washer(int n, DishPile pile){
        this.n = n;
        this.pile = pile;
    }
    @Override
    public void run(){
        for (int i = 0; i < n; i++) {
            
            pile.wash(new Dish(id++));
            try {
                Thread.sleep(50);
            } catch (InterruptedException ex) {}
        }
    }
    
}
