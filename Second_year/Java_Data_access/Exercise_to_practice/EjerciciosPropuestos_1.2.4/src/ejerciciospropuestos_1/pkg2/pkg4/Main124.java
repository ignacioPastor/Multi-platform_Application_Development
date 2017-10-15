/*
1.2.4: Crea un programa que muestre el contenido de un fichero de texto, cuyo nombre
deberá introducir el usuario. Debe avisar si el fichero no existe.
 */
package ejerciciospropuestos_1.pkg2.pkg4;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.Scanner;

/**
 * Ejercicio Propuesto 1.2.4
 * @author Ignacio
 */
public class Main124 {

    public static void main(String[] args) {
         
        Scanner lector = new Scanner(System.in);    
        System.out.println("Introduce el nombre del fichero");
        String nombreFichero = lector.nextLine();
        if(!(new File(nombreFichero).exists())){
            System.out.println("El fichero no existe");
            return;
        }
        try{
            BufferedReader ficheroLectura = new BufferedReader(
                new FileReader(new File(nombreFichero)));
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
