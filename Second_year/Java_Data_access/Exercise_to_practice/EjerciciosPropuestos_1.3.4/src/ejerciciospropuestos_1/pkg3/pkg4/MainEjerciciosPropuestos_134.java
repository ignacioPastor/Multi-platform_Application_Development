/*
1.3.4: Abre una imagen GIF y comprueba si sus tres primeros bytes
son las letras G, I, F.
*/
package ejerciciospropuestos_1.pkg3.pkg4;

import java.io.File;
import java.io.FileInputStream;
import java.util.Scanner;

/**
 *
 * @author Ignacio
 */
public class MainEjerciciosPropuestos_134 {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        FileInputStream ficheroEntrada = null;
        System.out.println("Indica el nombre del fichero");
        String nombreFicheroEntrada = scanner.nextLine();
        if(!(new File(nombreFicheroEntrada).exists())){
            System.err.println("No se ha encontrado el fichero");
            return;
        }
        try{
            boolean d1;
            boolean d2;
            boolean d3;
            ficheroEntrada = new FileInputStream(new File(nombreFicheroEntrada));
            
            d1 = Character.toString((char)ficheroEntrada.read()).equals("G");
            d2 = Character.toString((char)ficheroEntrada.read()).equals("I");
            d3 = Character.toString((char) ficheroEntrada.read()).equals("F");
            
            if(d1 == d2 == d3 == true)
                System.out.println("En efecto, los tres primeros bytes representan \"G\", \"I\", \"F\".");
            else
                System.out.println("Los tres primeros bytes no representan \"G\", \"I\", \"F\".");
            
            ficheroEntrada.close();
        }
        catch(Exception e){
            System.err.println("Ha habido un error: " + e.getMessage());
        }
    }
    
}
