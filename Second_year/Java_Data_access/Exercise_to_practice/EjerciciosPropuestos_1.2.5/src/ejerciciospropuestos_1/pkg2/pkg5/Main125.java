/*
1.2.5: Crea un programa que lea el contenido de un fichero de texto y lo vuelque a otro fichero
de texto, pero convirtiendo cada línea a mayúsculas.
 */
package ejerciciospropuestos_1.pkg2.pkg5;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;

/**
 * Ejercicio Propuesto 1.2.5
 * @author Ignacio
 */
public class Main125 {
    
    public static void main(String[] args) {
        
        String nombreFicheroLectura = "anotaciones.txt";
        String nombreFicheroEscritura = "anotacionesMayusculas.txt";
        
        if(!(new File(nombreFicheroLectura).exists())){
            System.out.println("El fichero no existe");
            return;
        }
        System.out.println("Leyendo fichero...");
        try{
            BufferedReader ficheroLectura = new BufferedReader(
                new FileReader(new File(nombreFicheroLectura)));
            BufferedWriter ficheroEscritura = new BufferedWriter(
                new FileWriter(new File(nombreFicheroEscritura)));
            
            String linea = null;
            while((linea = ficheroLectura.readLine()) != null){
                ficheroEscritura.write((linea.toUpperCase()));
                ficheroEscritura.newLine();
            }
            
            ficheroLectura.close();
            ficheroEscritura.close();
            System.out.println("Tarea completada con exito.");
        }
        catch(IOException e){
            System.out.println("Ha habido un error: " + e.getMessage());
        }
        System.out.println("Saliendo del programa...");
    }
    
}
