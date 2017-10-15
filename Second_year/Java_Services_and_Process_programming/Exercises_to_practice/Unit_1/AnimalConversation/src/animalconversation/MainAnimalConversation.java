// PSP - Week 01
package animalconversation;

/**
 *
 * @author Ignacio Pastor Padilla - 2º DAM-Semi
 */
public class MainAnimalConversation {

    public static void main(String[] args) {
        
        AnimalConversation<Dog, Cat> ac1 = new AnimalConversation<>(new Dog(), new Cat());
        AnimalConversation<Cat, Sheep> ac2 = new AnimalConversation<>(new Cat(), new Sheep());
        AnimalConversation<Sheep, Dog> ac3 = new AnimalConversation<>(new Sheep(), new Dog());
        
        ac1.chat();
        System.out.println();
        ac2.chat();
        System.out.println();
        ac3.chat();
    }
}
