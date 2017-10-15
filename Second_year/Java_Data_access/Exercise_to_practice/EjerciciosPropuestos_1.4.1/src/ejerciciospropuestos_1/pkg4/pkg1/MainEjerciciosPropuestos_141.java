/*
1.4.1: Crea un programa que lea los primeros 54 bytes de un fichero BMP (su cabecera) y
compruebe si los dos primeros bytes de esos 54 corresponden a las letras B y M. Si no es así,
mostrará el mensaje “No es un BMP válido”; si lo son, escribirá el mensaje “Parece un BMP
válido”.
*/
package ejerciciospropuestos_1.pkg4.pkg1;

import java.io.File;
import java.io.FileInputStream;
import java.io.InputStream;
import java.util.Scanner;

/**
 * Ejercicios Propuestos 1.4.1 Tema 1
 * @author Ignacio Pastor Padilla
 */
public class MainEjerciciosPropuestos_141 {

    public static void main(String[] args) {
        
        final int BUFFER_SIZE = 54; //bytes de la cabecera
        Scanner scanner = new Scanner(System.in);
        System.out.println("Indica el nombre del fichero");
        String nombreFicheroEntrada = scanner.nextLine();
        scanner.close(); //Cerramos el scanner
        //Comprobamos si el fichero indicado existe
        if(!(new File(nombreFicheroEntrada).exists())){
            System.err.println("No se ha encontrado el archivo indicado");
            return;
        }
        try{
            InputStream ficheroEntrada = new FileInputStream(new File(nombreFicheroEntrada));
            byte[] buffer = new byte[BUFFER_SIZE];
            ficheroEntrada.read(buffer, 0, BUFFER_SIZE);//Leemos 54 bytes, desde la posicion 0, guardandolos en el array buffer
            // Si el primer byte es "B" y el segundo "M", parece valido
            if("B".equals(Character.toString((char)buffer[0])) && "M".equals(Character.toString((char) buffer[1])))
                System.out.println("Parece un BMP valido");
            else
                System.out.println("No parece un BMP valido");
            ficheroEntrada.close();
        }
        catch(Exception e){
            System.err.println("Ha habido un error: " + e.getMessage());
        }
    }
}
