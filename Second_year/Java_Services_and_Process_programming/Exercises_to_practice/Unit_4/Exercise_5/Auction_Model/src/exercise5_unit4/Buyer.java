
package exercise5_unit4;

import java.io.Serializable;

/**
 * SPP - Unit 4 - Exercise 5
 * @author Ignacio Pastor Padilla
 */
public class Buyer implements Serializable{
    String name;
    int offer;
    
    public Buyer(){
        this.name = "";
        this.offer = 0;
    }
    public Buyer(String name, int offer){
        this.name = name;
        this.offer = offer;
    }
    
    public void setName(String name){
        this.name = name;
    }
    public String getName(){
        return name;
    }
    public void setOffer(int offer){
        this.offer = offer;
    }
    public int getOffer(){
        return offer;
    }
    
}
