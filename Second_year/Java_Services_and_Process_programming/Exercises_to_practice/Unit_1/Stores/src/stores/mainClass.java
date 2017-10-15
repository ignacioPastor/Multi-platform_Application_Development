// PSP - Week 01
package stores;

import java.text.DecimalFormat;

/**
 *
 * @author Ignacio Pastor Padilla -  2º DAM Semi
 */
public class mainClass {
    public static void main(String[] args) {
        
        LiquorStore lS = new LiquorStore(20, 8.95);
        DecimalFormat dF = new DecimalFormat("#####.00");
        
        lS.payDrinks(10);
        System.out.println("LiquorStore paying for 10 drinks");
        System.out.println("Cash: " + dF.format(lS.getCash()) + "€");
        
        
        Store s = new Store(8.95){
            @Override
            public void welcome(){
                System.out.println("Welcome to anonymous store!"
                        + " Our drink price is "
                        + dF.format((getDrinkPrice()))+ "€");
            }
        };
        
        s.payDrinks(10);
        System.out.println();
        System.out.println("Store paying for 10 drinks");
        System.out.println("Cash: " + dF.format(s.getCash()) + "€");
    }
}
