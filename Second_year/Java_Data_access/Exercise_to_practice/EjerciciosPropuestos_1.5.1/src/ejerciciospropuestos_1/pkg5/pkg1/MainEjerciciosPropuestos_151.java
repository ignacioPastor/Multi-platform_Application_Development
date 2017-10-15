/*
1.5.1: Crea una clase Persona, con datos nombre, e-mail, año de nacimiento. 
Haz un programa que cree tres objetos de tipo persona
y los guarde en un fichero llamado “personas.dat”.
*/
package ejerciciospropuestos_1.pkg5.pkg1;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectOutputStream;

/**
 *
 * @author Ignacio
 */
public class MainEjerciciosPropuestos_151 {

    public static void main(String[] args) throws FileNotFoundException, IOException {
        Persona p1 = new Persona("Pedro Paramo", "p.paramo@gmail.com", 1934);
        Persona p2 = new Persona("Rene Descartes", "r.descartes@gmail.com", 1596);
        Persona p3 = new Persona("Ignacio Pastor", "i.pastor@gmail.com", 1991);
        //ObjectOutputStream ficheroObjetos = new ObjectOutputStream(new FileOutputStream(new File("personas.dat")));
        
        File fichero = new File("personas.dat");
        FileOutputStream ficheroSalida = new FileOutputStream(fichero);
        ObjectOutputStream ficheroObjetos = new ObjectOutputStream(ficheroSalida);
                
        ficheroObjetos.writeObject(p1);
        ficheroObjetos.writeObject(p2);
        ficheroObjetos.writeObject(p3);
        ficheroSalida.close();
        ficheroObjetos.close();
    }
}
