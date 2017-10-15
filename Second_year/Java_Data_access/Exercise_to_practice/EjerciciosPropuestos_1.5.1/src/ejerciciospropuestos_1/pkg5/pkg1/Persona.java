
package ejerciciospropuestos_1.pkg5.pkg1;

import java.io.Serializable;

/**
 *
 * @author Ignacio
 */
public class Persona implements Serializable{
    public Persona(){
        }
    public Persona(String nombre, String mail, int anyoNacimiento){
        this.nombre = nombre;
        this.mail = mail;
        this.anyoNacimiento = anyoNacimiento;
    }
    private String nombre;
    private String mail;
    private int anyoNacimiento;
    
    public void setNombre(String nombre){
        this.nombre = nombre;
    }
    public String getNombre(){
        return nombre;
    }
    public void setMain(String main){
        this.mail = mail;
    }
    public String getMail(){
        return mail;
    }
    public void setAnyoNacimiento(int anyoNacimiento){
        this.anyoNacimiento = anyoNacimiento;
    }
    public int getAnyoNacimiento(){
        return anyoNacimiento;
    }
}
