/*
1.1.5. Crea un programa que pida al usuario una anchura y una altura y cree un fichero
llamado “rectangulo.txt” que contenga un rectángulo de asteriscos de ese anchura y el altura.
 */
package ejerciciospropuestos_1.pkg1.pkg5;

import java.io.PrintWriter;
import java.util.Scanner;

/**
 *
 * @author Ignacio Pastor Padilla - Acceso a Datos - 2º DAM Semipresencial
 */
public class EjerciciosPropuestos_115 {

    
    public static void main(String[] args) {
        Scanner lector = new Scanner(System.in);
        PrintWriter fichero = null;
        int ancho = 0;
        int alto = 0;
        boolean ok;
        
        do{
            ok = true;
            try{
                System.out.println("Indica la anchura del rectangulo");
                ancho = lector.nextInt();
                System.out.println("Indica la altura del rectangulo");
                alto = lector.nextInt();
            }
            catch(Exception o){
                o.printStackTrace();
                //System.out.println("Error: " + o.getMessage());
                lector.next(); // Evita que entre en bucle en caso de que se introduzca un dato no valido
                ok = false;
            }
        }
        while(ok == false);
        try{
            fichero = new PrintWriter("rectangulo.txt");
            
            for (int i = 0; i < alto; i++) {
                for (int j = 0; j < ancho; j++) {
                    fichero.print("*");
                }
                fichero.println();
            }
        }
        catch(Exception e){
            e.printStackTrace();
        }
        finally{
            if(fichero != null){
                fichero.close();
                System.out.println("Se ha dibujado el rectángulo en el fichero correctamente");
            }
        }
    }
    
}
