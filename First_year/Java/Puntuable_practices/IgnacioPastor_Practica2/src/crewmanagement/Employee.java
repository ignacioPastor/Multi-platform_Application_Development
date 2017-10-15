
package crewmanagement;

import static java.lang.System.out;



/**
 * Class to store information of employees
 * @author Ignacio
 * @version 1.0
 */
public class Employee {

    boolean nameOK, surnameOK;
    private Turn[]turns = new Turn[7];
    private int turnCount=0;
    private String name, surname, dni;
    
    /**
    * Constructor of the class
    */
    public Employee(){
        turnCount = 0;
    }
    /**
    * Constructor oversized of the class
    * @param name
    * @param surname
    */
    public Employee(String name, String surname){
        if(ValidateString(name) == true)
            this.name = name;
        else
            setNameOK(false);
        if(ValidateString(surname) == true)
            this.surname = surname;
    }
    /**
    * Constructor oversized of the class
    * @param name
    * @param surname
    * @param dni
    */
    public Employee(String name, String surname, String dni){
        if(ValidateDNI(dni)==true)
            this.dni=dni;
        if(ValidateString(name) == true)
            this.name = name;
        if(ValidateString(surname) == true)
            this.surname = surname;
    }
    /**
     * set the name of employee
     * @param name name of employee
     */
    public void setName(String name){
        if(ValidateString(name) == true){
            this.name = name;
            nameOK = true;
        }
        else
            nameOK = false;
    }
    /**
     * get the name of employee
     * @return name of employee
     */
    public String getName(){
        return name;
    }
    /**
     * set the surname of employee
     * @param surname surname of employee
     */
    public void setSurname(String surname){
        if(ValidateString(surname) == true){
            this.surname = surname;
            surnameOK = true;
        }
        else
            surnameOK = false;
    }
    /**
     * get the surname of employee
     * @return surname of employee
     */
    public String getSurname(){
        return surname;
    }
    /**
     * get the full name of employee, in Capital letters or not, it's depends on the value of two boolean parameters
     * @return name and surname of employee
     * @param nameInUpperCase
     * @param surnameInUpperCase
     */
    public String getFullName(boolean nameInUpperCase, boolean surnameInUpperCase){
        if(nameInUpperCase == true && surnameInUpperCase == false){
            if(nameOK == true && surnameOK == true)
                return name.toUpperCase() + ", " + surname.toLowerCase();
            else if(nameOK == false && surnameOK == true)
                return surname.toLowerCase();
            else if(nameOK == true && surnameOK == false)
                return name.toUpperCase();
            else 
                return "";
        }
        else if(nameInUpperCase == false && surnameInUpperCase == true){
            if(nameOK == true && surnameOK == true)
                return name.toLowerCase() + ", " + surname.toUpperCase();
            else if(nameOK == false && surnameOK == true)
                return surname.toUpperCase();
            else if(nameOK == true && surnameOK == false)
                return name.toLowerCase();
            else 
                return "";
        }

        else if(nameInUpperCase == true && surnameInUpperCase == true){
            if(nameOK == true && surnameOK == true)
                return name.toUpperCase() + ", " + surname.toUpperCase();
            else if(nameOK == false && surnameOK == true)
                return surname.toUpperCase();
            else if(nameOK == true && surnameOK == false)
                return name.toUpperCase();
            else
                return "";
        }

        else {
            if(nameOK == true && surnameOK == true)
                return name.toLowerCase() + ", " + surname.toLowerCase();
            else if(nameOK == false && surnameOK == true)
                return surname.toLowerCase();
            else if(nameOK == true && surnameOK == false)
                return name.toLowerCase();
            else 
                return "";
        }
        

    }
    
    /**
     * set the dni of employee
     * @param dni, dni of employee
     */
    public void setDNI(String dni){
        if(ValidateDNI(dni)==true && getDNI() == null)
            this.dni=dni;
    }
    /**
     * get the dni of employee
     * @return dni of employee
     */
    public String getDNI(){
        return dni;
    }
    /**
     * Indicates if the dni is valid or not
     * @return boolean
     * @param dni
     */
    public boolean ValidateDNI(String dni){
        //Check that the String has 9 characters
        if( dni == null || dni.length() != 9){
           // out.println("DNI not valid");
            return false;
        }
        else
        {
            //Check that the eight first characters are a numbers
            boolean digit=true;
            for(int i = 0; i < dni.length()-1 && digit == true; i++){
                if(Character.isDigit((char) dni.charAt(i)))
                    digit=true;
                else return false; //if the eigth first characters aren't numbers, is not a valid DNI
            }
            //Check that the last character is a letter
            if(Character.isLetter((char) dni.charAt(dni.length()-1)))
                return true;
            else return false;
        }
    }
    /**
     * Add turn for an employee
     * @param aTurn
     */
    public void addTurn(Turn aTurn){
        if(turnCount < 7 && aTurn != null){
           turns[turnCount]=aTurn; 
           turnCount++;
        }
    }
    /**
     * get the Turns of employee
     * @return Turns of employee
     */
    public Turn[]getTurns(){
        Turn[]temp =new Turn[turnCount];
        for(int i=0; i < turnCount; i++)
            temp[i]=turns[i];
        return temp;
    }
    /**
     * tool for removeTurn method, for find the turn which user wants remove
     * @param aDay
     * @return position of turn
     */
    public int findTurnPosition(String aDay){
        for(int i=0;  i<turnCount; i++){
            if(turns[i].day.equals(aDay.toUpperCase()))
                return i;
        }
        return -1;
    }
    /**
     * Remove a turn indicated by user
     * @param day
     */
    public void removeTurn(String day){
        int index = findTurnPosition(day);
        if(index >=0){
            for(int i=index; i<turnCount-1; i++)
                turns[i]=turns[i+1];
            turnCount--;
        }
    }
    /**
     * get the number of turns where the employee is assigned
     * @return turnCount of employee
     */
    public int getTurnCount(){
        return turnCount;
    }
    /**
     * get the turn of employee indicated by the user 
     * @return turns of employee
     * @param anIndex
     */
    public Turn getTurnAt(int anIndex){
        if(anIndex > turnCount)
            return null;
        else return turns[anIndex];
    }   
    /**
     * Check if user is trying update a string value to null
     * @param text
     * @return boolean
     */
    public boolean ValidateString(String text){
        if(text != null)
            return true;
        else
            return false;
    }
    public void setNameOK(boolean nameOK){
        this.nameOK = nameOK;
    }
    public boolean GetNameOK(){
        return nameOK;
    }
}