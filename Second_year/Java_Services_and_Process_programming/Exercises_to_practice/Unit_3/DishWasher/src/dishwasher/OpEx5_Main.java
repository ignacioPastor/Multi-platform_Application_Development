/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dishwasher;

/**
 *
 * @author Ignacio
 */
public class OpEx5_Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        DishPile pile = new DishPile();
        
        Washer w = new Washer(20, pile);
        Dryer d = new Dryer(20, pile);
        
        w.start();
        d.start();
        
    }
    
}
