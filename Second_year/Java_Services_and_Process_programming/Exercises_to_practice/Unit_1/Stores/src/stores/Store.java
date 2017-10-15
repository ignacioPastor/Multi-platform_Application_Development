// PSP - Week 01
package stores;

/**
 *
 * @author Ignacio Pastor Padilla -  2º DAM Semi
 */
public abstract class Store {
    public Store(){
        
    }
    public Store(double drinkPrice){
        this.drinkPrice = drinkPrice;
        cash = 0.0;
    }
    private double cash;
    private double drinkPrice;
    public abstract void welcome();
    
    public void payDrinks(int numOfDrinks){
        cash += (numOfDrinks * drinkPrice);
    }
    
    public double getDrinkPrice(){
        return drinkPrice;
    }
    
    public void setCash(double cash){
        this.cash = cash;
    }
    
    public double getCash(){
        return cash;
    }
    
}
