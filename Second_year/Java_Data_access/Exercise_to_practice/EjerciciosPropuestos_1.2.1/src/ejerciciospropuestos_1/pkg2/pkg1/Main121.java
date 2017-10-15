/*
 1.2.1: Crea un programa que muestre la primera línea del contenido del fichero
“DosFrases.txt”.
 */
package ejerciciospropuestos_1.pkg2.pkg1;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;

/**
 * Ejercicio Propuesto 1.2.1
 * @author Ignacio
 */
public class Main121 {

    public static void main(String[] args) {
        
        if(!(new File("dosFrases.txt").exists())){
            System.out.println("El fichero no existe");
            return;
        }
        System.out.println("Leyendo fichero...");
        
        try{
            BufferedReader ficheroLectura = new BufferedReader(
                    new FileReader(new File("dosFrases.txt")));
            String linea = null;
            while((linea = ficheroLectura.readLine()) != null){
                System.out.println(linea);
            }
            ficheroLectura.close();
        }
        catch(IOException e){
            System.out.println("Ha habido un error: " + e.getMessage());
        }
        System.out.println("Saliendo del programa...");
        
    }
    
}
