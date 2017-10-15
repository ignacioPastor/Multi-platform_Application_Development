/*
1.2.6: Crea un programa que pida al usuario el nombre de un fichero y una palabra a buscar en
él. Debe mostrar en pantalla todas las líneas del fichero que contengan esa palabra.
 */
package ejerciciospropuestos_1.pkg2.pkg6;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.Scanner;

/**
 * Ejercicio Propuesto 1.2.6
 * @author Ignacio
 */
public class Main126 {

    public static void main(String[] args) {
        
        Scanner lector = new Scanner(System.in);
        
        System.out.println("Introduce el nombre del fichero");
        String nombreFichero = lector.nextLine();
        
        if(!(new File(nombreFichero).exists())){
            System.out.println("El fichero no existe");
            return;
        }
        
        System.out.println("¿Que palabra quieres buscar?");
        String palabraBuscar = lector.nextLine();
                
        System.out.println("Leyendo fichero...");
        System.out.println();
        
        String linea = null;
        try{
            BufferedReader ficheroLectura = new BufferedReader(
                new FileReader(new File(nombreFichero)));
            while((linea = ficheroLectura.readLine()) != null){
                if(linea.contains(palabraBuscar)){
                    System.out.println(linea);
                }
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
