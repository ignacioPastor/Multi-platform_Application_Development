
package ejerciciospropuestos_1.pkg5.pkg3;

import java.io.Serializable;

/**
 *
 * @author Ignacio
 */
public class Persona implements Serializable{
    public Persona(){
        
    }
    public Persona(String nombre, String mail, int anyo){
        this.nombre = nombre;
        this.mail = mail;
        this.anyo = anyo;
    }
    private String nombre;
    private String mail;
    private int anyo;
    
    public void setNombre(String nombre){
        this.nombre = nombre;
    }
    public String getNombre(){
        return nombre;
    }
    public void setMail(String mail){
        this.mail = mail;
    }
    public String getMail(){
        return mail;
    }
    public void setAnyo(int anyo){
        this.anyo = anyo;
    }
    public int getAnyo(){
        return anyo;
    }
}
