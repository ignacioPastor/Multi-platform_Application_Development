
package dishwasher;

import java.util.Stack;

/**
 *
 * @author Ignacio
 */
public class DishPile {
    Stack<Dish> pile;
    public DishPile(){
        pile = new Stack<>();
    }
    public synchronized void wash(Dish d){
        if(pile.size() == 5){
                try {
                    wait();
            } catch (InterruptedException ex) {}
        }
        pile.push(d);
        notify();
        System.out.println("Washed dish #" + d.getDishNumber()
                + ", total in pile: " + pile.size());
    }
    public synchronized void dry(){
        if(pile.isEmpty()){
                try {
                    wait();
            } catch (InterruptedException ex) {}
        }
        Dish d = pile.pop();
        notify();
        System.out.println("Drying dish #" + d.getDishNumber() 
                + ", total in pile: " + pile.size());
    }
}
