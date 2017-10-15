// Ignacio Pastor Padilla - Acceso a Datos - 2º DAM Semipresencial

//1.1.1. Crea un programa que pida dos frases al usuario
//  y las guarde en un fichero llamado “dosFrases.txt”.
package ejerciciospropuestos_1.pkg1.pkg1;

import java.io.IOException;
import java.io.PrintWriter;
import static java.lang.System.out;
import java.util.Scanner;

/**
 *
 * @author Ignacio
 */
public class EjerciciosPropuestos_111 {

    public static void main(String[] args) {
        
        Scanner teclado = new Scanner(System.in);
        
        out.println("Introduce una frase");
        String frase1 = teclado.nextLine();
        out.println("Introduce otra frase");
        String frase2 = teclado.nextLine();
        
        PrintWriter pW = null;
        try{
            pW = new PrintWriter("dosFrases.txt");
            pW.println(frase1);
            pW.println(frase2);
        }
        catch(IOException e){
            e.printStackTrace();
        }
        finally{
            if(pW != null)
                pW.close();
        }
        
    }
    
}
