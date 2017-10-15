/*
1.1.4. Crea una versión mejorada del ejercicio 1.1.3,
en la que antes de cada frase se anotará la fecha
y la hora en la que se ha realizado dicha anotación.
 */
package ejerciciospropuestos_1.pkg1.pkg4;

import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.text.DecimalFormat;
import java.time.ZonedDateTime;
import java.util.Scanner;

/**
 * @author Ignacio Pastor Padilla - Acceso a Datos - 2º DAM Semipresencial
 */
public class EjerciciosPropuestos_114 {
    
    public static void main(String[] args) {
        Scanner lector = new Scanner(System.in);
        PrintWriter fichero = null;
        String frase;
        DecimalFormat f = new DecimalFormat("00");
        try{
            fichero = new PrintWriter(new BufferedWriter(
                            new FileWriter("anotaciones.txt", true)));
            do{
                System.out.println("Introduce una frase");
                frase = lector.nextLine();
                ZonedDateTime now = ZonedDateTime.now();
                
                if(!frase.equals("")){
                    fichero.println(f.format(now.getDayOfMonth()) + "/" + f.format(now.getMonthValue()) + "/" + f.format(now.getYear())
                        + " - " + f.format(now.getHour()) + ":" + f.format(now.getMinute()) + ":" + f.format(now.getSecond()));
                    fichero.println(frase);
                    
                    fichero.println();
                    System.out.println();
                }
            }
            while(!frase.equals(""));
        }
        catch(IOException e){
            e.printStackTrace();
        }
        finally{
            if(fichero != null)
                fichero.close();
        }
    }
    
}
