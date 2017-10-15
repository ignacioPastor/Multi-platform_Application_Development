
package concurrentvideogames;

/**
 *
 * @author Ignacio
 */
public class VideoGame {
    
    private String name;
    private int price;
    
    public VideoGame(String name, int price){
        this.name = name;
        this.price = price;
    }
    
    public void setName(String name){
        this.name = name;
        System.out.println("Modification!");
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
