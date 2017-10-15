// PSP - Week 01
package killenemies;

/**
 *
 * @author Ignacio Pastor Padilla -  2º DAM Semi
 */
public class Enemy implements Character {
    @Override
    public boolean isEnemy(){
        return true;
    }
    public void kill(){
        System.out.println("Ahhhggg, you killed me, bastard!");
    }
}
