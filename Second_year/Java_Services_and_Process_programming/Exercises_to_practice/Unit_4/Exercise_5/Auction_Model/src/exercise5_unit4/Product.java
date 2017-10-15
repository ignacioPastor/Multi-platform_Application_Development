
package exercise5_unit4;

import java.io.Serializable;

/**
 * SPP - Unit 4 - Exercise 5
 * @author Ignacio Pastor Padilla
 */
public class Product implements Serializable{
    String name;
    int price;
    
    public Product(String name, int price){
        this.name = name;
        this.price = price;
    }
    public Product(){
        this.name = "";
        this.price = 0;
    }
    
    public void setName(String name){
        this.name = name;
    }
    public String getName(){
        return name;
    }
    public void setPrice(int price){
        this.price = price;
    }
    public int getPrice(){
        return price;
    }
}
