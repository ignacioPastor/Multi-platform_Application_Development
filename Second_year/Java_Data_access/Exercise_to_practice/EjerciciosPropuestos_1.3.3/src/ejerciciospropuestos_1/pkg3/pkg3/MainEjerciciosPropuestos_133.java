/*
1.3.3: Crea un programa que extraiga el contenido de un fichero binario, 
volcando a un fichero de texto todo lo que sean caracteres imprimibles 
(basta con que sean desde la A hasta la Z, junto con el espacio en blanco)
e ignorando todos los demás caracteres. El nombre del fichero de entrada 
lo elegirá el usuario y el fichero de salida tendrá ese mismo nombre, 
pero terminado en “.txt” (por ejemplo, si el fichero original era “1.zip”, 
el de salida será “1.zip.txt”).
*/

package ejerciciospropuestos_1.pkg3.pkg3;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileWriter;
import java.util.Scanner;

/**
 *
 * @author Ignacio
 */
public class MainEjerciciosPropuestos_133 {

    public static boolean datoImprimible(int dato){
        return (Character.toString((char) dato).matches("[A-Za-z]") || Character.toString((char) dato).matches("\\s"));
    }
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        FileInputStream ficheroEntrada = null;
        String nombreFicheroEntrada = null;
        BufferedWriter ficheroSalida = null; 

        
        System.out.println("Indica el nombre del fichero");
        nombreFicheroEntrada = scanner.nextLine();
        if(!(new File(nombreFicheroEntrada).exists())){
            System.err.println("No se ha encontrado el fichero");
            return;
        }
        String nombreFicheroSalida = nombreFicheroEntrada + ".txt";
        

        try{
            ficheroSalida = new BufferedWriter(new FileWriter(new File(nombreFicheroSalida)));
            ficheroEntrada = new FileInputStream(new File(nombreFicheroEntrada));
            int dato;
            while((dato = ficheroEntrada.read()) != -1){
                if(datoImprimible(dato)){
                    ficheroSalida.write((char)dato);
                }
            }
                ficheroSalida.close();
                ficheroEntrada.close();
        }
        catch(Exception e){
            System.err.println("Ha habido un error: " + e.getMessage());
        }
    }
    
}
