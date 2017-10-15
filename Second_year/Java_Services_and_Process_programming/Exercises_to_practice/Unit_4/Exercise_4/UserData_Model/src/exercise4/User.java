
package exercise4;

import java.io.Serializable;
import java.time.LocalDate;
import java.util.Date;

/**
 *
 * @author Ignacio
 */

public class User implements Serializable{
    private String name;
    private String password;
    private LocalDate dateRegister;
    
    public User(){
        name = "";
        password = "";
        dateRegister = LocalDate.now();
    }
    
    public void setName(String name){
        this.name = name;
    }
    public String getName(){
        return name;
    }
    public void setPassword(String password){
        this.password = password;
    }
    public String getPassword(){
        return password;
    }
    public LocalDate getDateRegister(){
        return dateRegister;
    }
}

