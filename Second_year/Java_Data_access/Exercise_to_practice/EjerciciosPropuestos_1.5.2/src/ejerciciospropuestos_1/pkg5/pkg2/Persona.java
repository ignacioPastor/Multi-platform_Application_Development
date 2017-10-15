
package ejerciciospropuestos_1.pkg5.pkg2;

import java.io.Serializable;

/**
 *
 * @author Ignacio
 */
public class Persona implements Serializable{
    public Persona(){}
    public Persona(String nombre, String mail, int anyoNacimiento){
        this.nombre = nombre;
        this.mail = mail;
        this.anyoNacimiento = anyoNacimiento;
    }
    String nombre;
    String mail;
    int anyoNacimiento;
    
    public String getNombre(){
        return nombre;
    }
    public String getMail(){
        return mail;
    }
    public int getAnyoNac(){
        return anyoNacimiento;
    }
}
