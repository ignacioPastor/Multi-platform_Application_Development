// PSP - Week 01
package killenemies;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

/**
 *
 * @author Ignacio Pastor Padilla -  2º DAM Semi
 */
public class MainClassKillEnemies {

    public static void main(String[] args) {
        
        List<Character> listChar;
        listChar = new ArrayList<>();
        
        for (int i = 0; i < 10; i++) {
            if(i % 2 == 0)
                listChar.add(new Friend());
            else
                listChar.add(new Enemy());
        }
        
        Collections.shuffle(listChar);
        
        for (int i = 0; i < 10; i++) {
            if(listChar.get(i) instanceof Enemy){
                System.out.println("Character " + i
                    + " is a enemy! kill it!");
                ((Enemy)listChar.get(i)).kill();
            }
            else{
                System.out.println("Character " + i
                    + " is a friend! :-)");
            }
            System.out.println();
        }
        
        
    }
    
}
