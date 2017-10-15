// PSP - Week 01
package animalconversation;

/**
 *
 * @author Ignacio Pastor Padilla - 2º DAM-Semi
 */
public abstract class Animal {
    
    public Animal(){
        
    }
    public Animal(String name){
        this.name = name;
    }
    protected String name;
    
    public abstract String talk();
}
