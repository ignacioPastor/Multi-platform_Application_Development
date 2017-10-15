/*
1.1.3. Crea una variante del ejercicio 1.1.2, en la que el fichero se llamará “anotaciones.txt”
y no se destruirá en cada nueva ejecución, sino que se añadirán las nuevas frases al final de las existentes.
 */
package ejerciciospropuestos_1.pkg1.pkg3;

import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import static java.lang.System.out;
import java.util.Scanner;

/**
 *
 * @author Ignacio Pastor Padilla - Acceso a Datos -  2º DAM Semipresencial
 */
public class EjerciciosPropuestos_113 {

    
    public static void main(String[] args) {
        
        Scanner lectorTeclado = new Scanner(System.in);
        PrintWriter fich = null;
        String frase;
        
        try{
            fich = new PrintWriter(new BufferedWriter(
               new FileWriter("anotaciones.txt", true)));
            do{
                out.println("Introduce una frase");
                frase = lectorTeclado.nextLine();
                if(!frase.equals(""))
                    fich.println(frase);
            }
            while(!frase.equals(""));
        }
        catch(IOException e){
            e.printStackTrace();
        }
        finally{
            if(fich != null)
                fich.close();
        }
    }
    
}
