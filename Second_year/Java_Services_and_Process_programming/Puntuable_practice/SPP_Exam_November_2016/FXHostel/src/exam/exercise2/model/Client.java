
package exam.exercise2.model;

/**
 *PSP Exam
 * @author Ignacio Pastor Padilla
 * This class characterize the Client object
 */
public class Client {
    private String name;
    private boolean discount;
    
    public Client(){
        name = "";
        discount = false;
    }
    public Client(String name, boolean discount){
        this.name = name;
        this.discount = discount;
    }
    public void setName(String name){
        this.name = name;
    }
    public String getName(){
        return name;
    }
    public void setDiscount(boolean discount){
        this.discount = discount;
    }
    public boolean getDiscount(){
        return discount;
    }
}
