/* 1.1.2. Crea un programa que pida frases al usuario (una cantidad indeterminada, 
hasta que introduzca una línea vacía) y las almacene en un fichero llamado “frases.txt”. 
Cada vez que se lance el programa, se destruirá el fichero “frases.txt” 
y se creará uno nuevo que lo reemplace.
*/
package ejerciciospropuestos_1.pkg1.pkg2;

import java.io.IOException;
import java.io.PrintWriter;
import static java.lang.System.out;
import java.util.Scanner;

/**
 *
 * @author Ignacio Pastor Padilla - Acceso a Datos - 2º DAM Semipresencial
 */
public class EjerciciosPropuestos_112 {

    
    public static void main(String[] args) {
        Scanner lT = new Scanner(System.in);
        
        String frase;
        PrintWriter fich = null;
        try{
            fich = new PrintWriter("frases.txt");
            do{
                out.println("Introduce una frase");
                frase = lT.nextLine();
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
