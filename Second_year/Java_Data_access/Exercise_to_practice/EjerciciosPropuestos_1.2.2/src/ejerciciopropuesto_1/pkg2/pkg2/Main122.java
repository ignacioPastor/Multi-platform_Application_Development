/*
    1.2.2: Crea un programa que muestre todo el contenido del fichero “anotaciones.txt”.
 */
package ejerciciopropuesto_1.pkg2.pkg2;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;

/**
 * Ejercicio Propuesto 1.2.2
 * @author Ignacio
 */
public class Main122 {

    
    public static void main(String[] args) {
        
        if(!(new File("anotaciones.txt").exists())){
            System.out.println("El fichero no existe");
            return;
        }
        System.out.println("Leyendo fichero...");
        System.out.println();
        try{
            BufferedReader ficheroLectura = new BufferedReader(
                new FileReader(new File("anotaciones.txt")));
            String linea = null;
            while((linea = ficheroLectura.readLine()) != null){
                System.out.println(linea);
            }
            ficheroLectura.close();
        }
        catch(IOException e){
            System.out.println("Ha habido un error: " + e.getMessage());
        }
        System.out.println();
        System.out.println("Saliendo del programa...");
    }
    
}
