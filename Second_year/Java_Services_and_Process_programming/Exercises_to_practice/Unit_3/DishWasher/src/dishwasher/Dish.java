
package dishwasher;

/**
 *
 * @author Ignacio
 */
public class Dish {
    int dishNumber;
    public Dish(int dishNumber){
        this.dishNumber = dishNumber;
    }
    public int getDishNumber(){
        return dishNumber;
    }
    public void setDishNumber(int dishNumber){
        this.dishNumber = dishNumber;
    }
}
