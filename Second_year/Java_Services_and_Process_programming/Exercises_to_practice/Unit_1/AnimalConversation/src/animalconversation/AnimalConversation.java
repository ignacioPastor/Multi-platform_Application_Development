// PSP - Week 01
package animalconversation;

/**
 *
 * @author Ignacio  Pastor Padilla - 2º DAM-Semi
 * @param <T>
 * @param <U>
 */

public class AnimalConversation<T extends Animal, U extends Animal> {
    
    public AnimalConversation(){
        
    }
    
    public T animal1;
    public U animal2;
    
    public AnimalConversation(T animal1, U animal2){
        this.animal1 = animal1;
        this.animal2 = animal2;
    }

    public void chat(){
        System.out.println(animal1.talk());
        System.out.println(animal2.talk());
    }

    
}
