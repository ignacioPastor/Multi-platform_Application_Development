/*
1.4.3: Abre una imagen en formato BMP y comprueba si está comprimida,
mirando el valor del byte en la posición 30 (empezando a contar desde 0). 
Si ese valor es un 0 (que es lo habitual), indicará que el fichero no está comprimido.
Deberás leer toda la cabecera (los primeros 54 bytes) con una sola orden.
*/
package ejerciciospropuestos_1.pkg4.pkg3;

import java.io.File;
import java.io.FileInputStream;
import java.io.InputStream;

/**
 *
 * @author Ignacio
 */
public class MainEjerciciosPropuestos_143 {

    public static void main(String[] args) {
        
        String nombreFichero = "fotoBMP.bmp";
        final int BUFFER_SIZE = 54;
        
        try{
            InputStream fichero = new FileInputStream(new File(nombreFichero));
            byte[] buffer = new byte[BUFFER_SIZE];
            fichero.read(buffer, 0, BUFFER_SIZE);
            if(Byte.toUnsignedInt(buffer[30]) == 0){
                System.out.println("El fichero no esta comprimido");
            }
            else{
                System.out.println("El fichero esta comprimido");
            }
            // Para ver la cabecera
//            for (int i = 0; i < BUFFER_SIZE; i++) {
//                System.out.print(buffer[i]);
//            }
//            System.out.println();
        }
        catch(Exception e){
            System.err.println("Ha habido un error: " + e.getMessage());
        }
        
    }
    
}
