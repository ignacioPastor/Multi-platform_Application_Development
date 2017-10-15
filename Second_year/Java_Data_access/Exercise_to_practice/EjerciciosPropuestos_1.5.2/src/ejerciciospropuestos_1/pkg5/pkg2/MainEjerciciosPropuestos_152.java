/*
1.5.2: Haz un programa que muestre los datos de las tres personas 
que se habían guardado en el fichero “personas.dat”.
*/
package ejerciciospropuestos_1.pkg5.pkg2;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;

/**
 *
 * @author Ignacio
 */
public class MainEjerciciosPropuestos_152 {

    public static void main(String[] args) throws IOException, ClassNotFoundException {
        try
        {
           
            Persona p1 = new Persona("Pedro Paramo", "p.paramo@gmail.com", 1934);
            Persona p2 = new Persona("Rene Descartes", "r.descartes@gmail.com", 1596);
            Persona p3 = new Persona("Ignacio Pastor", "i.pastor@gmail.com", 1991);
            
            ObjectOutputStream ficheroObjetos = new ObjectOutputStream(new FileOutputStream(new File("personas.dat")));
//            File fichero = new File("personas.dat");
//            FileOutputStream ficheroSalida = new FileOutputStream(fichero);
//            ObjectOutputStream ficheroObjetos = new ObjectOutputStream(ficheroSalida);
            
            ficheroObjetos.writeObject(p1);
            ficheroObjetos.writeObject(p2);
            ficheroObjetos.writeObject(p3);
            
            //ficheroSalida.close();
            ficheroObjetos.close();
            
            System.out.println("Se han guardado los objetos en el fichero");
            System.out.println("Se procede a leerlos ahora del fichero");
            
             ObjectInputStream ficheroObjetosEn = new ObjectInputStream(new FileInputStream(new File("personas.dat")));
//            File ficheroEn = new File("personas.dat");
//            FileInputStream ficheroEntrada = new FileInputStream(ficheroEn);
//            ObjectInputStream ficheroObjetosEn = new ObjectInputStream(ficheroEntrada);
            
            Persona p4 = (Persona) ficheroObjetosEn.readObject();
            Persona p5 = (Persona) ficheroObjetosEn.readObject();
            Persona p6 = (Persona) ficheroObjetosEn.readObject();
            
            
            ficheroObjetosEn.close();
            //ficheroEntrada.close();
            
            System.out.println("Primer Objeto. Nombre: " + p4.getNombre() + ". Mail: " + p4.getMail() + ". Año nacimiento: " + p4.getAnyoNac());
            System.out.println("Primer Objeto. Nombre: " + p5.getNombre() + ". Mail: " + p5.getMail() + ". Año nacimiento: " + p5.getAnyoNac());
            System.out.println("Primer Objeto. Nombre: " + p6.getNombre() + ". Mail: " + p6.getMail() + ". Año nacimiento: " + p6.getAnyoNac());

        }catch(Exception e){
            System.err.println("Error: " + e.getMessage());
        }
        
        
        
    }
    
}
