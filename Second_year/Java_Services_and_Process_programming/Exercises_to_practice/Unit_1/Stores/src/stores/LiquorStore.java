// PSP - Week 01
package stores;

/**
 *
 * @author Ignacio Pastor Padilla -  2º DAM Semi
 */
public class LiquorStore extends Store {
    public LiquorStore(){
        
    }
    public LiquorStore(int tax, double drinkPrice){
        super(drinkPrice);
        this.tax = tax;
    }
    
    private int tax;
    
    @Override
    public void welcome(){
        System.out.println("Welcome to our LiquorStore."
                + "If you are younger than 18 years, go back home");
    }
    
    @Override
    public void payDrinks(int numberOfDrinks){
        super.payDrinks(numberOfDrinks);
        setCash(getCash() + ((getCash() * tax) / 100));
    }
}
