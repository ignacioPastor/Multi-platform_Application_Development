/*
1.2.7: Crea un programa que lea el contenido del fichero “rectangulo.txt” que creaste en el
ejercicio 1.1.5 y que muestre en pantalla cual es la anchura y la altura del triángulo de
asteriscos.
 */
package ejerciciospropuestos_1.pkg2.pkg7;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;

/**
 * Ejercicio Propuesto 1.2.7
 * @author Ignacio
 */
public class Main127 {
    
    public static void main(String[] args) {
        
        String nombreFichero = "rectangulo.txt";
        if(!(new File(nombreFichero).exists())){
            System.out.println("El fichero no existe");
            return;
        }
        String linea = null;
        int anchura = 0;
        int altura = 0;
        try{
            BufferedReader ficheroLectura = new BufferedReader(
                new FileReader(new File(nombreFichero)));
            linea = ficheroLectura.readLine();
            anchura = linea.length();
            altura++;
            while((linea = ficheroLectura.readLine()) != null){
                altura++;
            }
        }
        catch(IOException e){
            System.out.println("Ha habido un error: " + e.getMessage());
        }
        
        System.out.println("Anchura: " + anchura);
        System.out.println("Altura: " + altura);
    }
}
