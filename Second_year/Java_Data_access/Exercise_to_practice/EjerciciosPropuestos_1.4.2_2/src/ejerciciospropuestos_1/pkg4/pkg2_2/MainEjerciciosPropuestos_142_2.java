/*
1.4.2: Crea una versión alternativa del ejercicio 1.3.3, leyendo los datos a 
un array en vez de trabajar byte a byte: un programa que extraiga el contenido 
de un fichero binario, volcando a un fichero de texto todo lo que sean caracteres 
imprimibles (basta con que sean desde la A hasta la Z, junto con el espacio en blanco).
*/

package ejerciciospropuestos_1.pkg4.pkg2_2;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStream;

/**
 *
 * @author Ignacio
 */
public class MainEjerciciosPropuestos_142_2 {

    public static boolean esImprimible(byte b){
        
        return (Character.toString((char)b).matches("[A-Za-z0-9]") || Character.toString((char)b).matches("(\\s)"));
    }
    public static void main(String[] args) throws IOException {
     String nombreFicheroEntrada = "fotoPNG.png";
     String nombreFicheroSalida = nombreFicheroEntrada + ".txt";
     if(!(new File(nombreFicheroEntrada).exists())){
         System.err.println("No se ha encontrado el fichero indicado");
         return;
     }
     BufferedWriter ficheroSalida = null;
        try{
            InputStream ficheroEntrada = new FileInputStream(new File(nombreFicheroEntrada));
            ficheroSalida = new BufferedWriter(new FileWriter(new File(nombreFicheroSalida)));
            byte[] buff = new byte[1024];
            int cantidad;
            while((cantidad = ficheroEntrada.read(buff, 0, 1024)) != -1){
                for (int i = 0; i < cantidad; i++) {
                    if(esImprimible(buff[i])){
                        ficheroSalida.write((char)buff[i]);
                    }
                }
            }
            ficheroEntrada.close();
        }
        catch(Exception e){
            System.err.println("Ha habido un error: " + e.getMessage());
        }
        finally{
            if(ficheroSalida != null)
                ficheroSalida.close();
        }
    }
}
