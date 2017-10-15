
package exam.exercise2.model;

import java.util.List;

/**
 *PSP Exam
 * @author Ignacio Pastor Padilla
 * This class characterize the Room object
 */
public class Room {
    private String name;
    private int numberBeds;
    private List<Client> listClients;
    
    public Room(){
        name = "";
        numberBeds = 0;
        listClients = null;
    }
    public Room(String name, int numberBeds, List<Client> listClients){
        this.name = name;
        this.numberBeds = numberBeds;
        this.listClients = listClients;
    }
    public void setName(String name){
        this.name = name;
    }
    public String getName(){
        return name;
    }
    public void setNumberBeds(int numberBeds){
        this.numberBeds = numberBeds;
    }
    public int getNumberBeds(){
        return numberBeds;
    }
    public void setListClients(List<Client> listClients){
        this.listClients = listClients;
    }
    public List<Client> getListClients(){
        return listClients;
    }
}
