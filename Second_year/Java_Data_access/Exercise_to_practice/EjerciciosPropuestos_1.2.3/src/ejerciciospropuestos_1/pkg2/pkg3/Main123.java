/*
    1.2.3: Crea un programa que muestre paginado el contenido del fichero “anotaciones.txt”: tras
    cada 23 líneas se realizará una pausa hasta que el usuario pulse Intro.
 */
package ejerciciospropuestos_1.pkg2.pkg3;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.Scanner;

/**
 * Ejercicio Propuesto 1.2.3
 * @author Ignacio
 */
public class Main123 {

    
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
            Scanner lector = new Scanner(System.in);
            String linea = null;
            int contador = 0;
            while((linea = ficheroLectura.readLine()) != null){
                if(contador == 23){
                    contador = 0;
                    lector.nextLine();
                }
                else
                    contador++;
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
