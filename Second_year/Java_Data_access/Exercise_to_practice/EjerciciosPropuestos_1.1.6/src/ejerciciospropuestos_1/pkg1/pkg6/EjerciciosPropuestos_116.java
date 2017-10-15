/*
1.1.6. Crea un programa que pregunte al usuario la cantidad de días de un mes, el número del
primer día (1 para lunes, 7 para domingo) y el nombre del mes (por ejemplo, “Marzo”) y cree
un fichero de texto llamado “agendaMarzo.txt” (o el nombre del mes que corresponde), que
contendrá un esqueleto de agenda para ese mes.
*/
package ejerciciospropuestos_1.pkg1.pkg6;

import java.io.IOException;
import java.io.PrintWriter;
import static java.lang.System.out;
import java.util.Scanner;

/**
 *
 * @author Ignacio Pastor Padilla
 */
public class EjerciciosPropuestos_116 {
    
    public static String primeraMayus(String texto){        
        char inicial = texto.charAt(0);
        return inicial + texto.toLowerCase().substring(1, texto.length());
    }
    
    public static int pedirEntero(String texto){
        Scanner lector2 = new Scanner(System.in);
        boolean ok;
        int n = 0;
        do{
            try{
                ok = true;
                out.println(texto);
                n = lector2.nextInt();
            }
            catch(NumberFormatException e){
                out.println(e.getMessage());
                lector2.next();
                ok = false;
            }
        }
        while(ok == false);
        return n;
    }
    
    public enum DiaSemana {
        LUNES(1), MARTES(2), MIERCOLES(3),
        JUEVES(4), VIERNES(5), SABADO(6), DOMINGO(7);            
        private final int numSemana;            
        private DiaSemana(int numSemana){
            this.numSemana = numSemana;
        }
        public int getDiaSemana(){
            return numSemana;
        }
    }    
    public static void main(String[] args) { 
        Scanner lector = new Scanner(System.in);
        
        int cantidadDias = pedirEntero("Introduce la cantidad de dias del mes");
        int nPrimerDia = pedirEntero("Indica el numero del primer dia (1 para Lunes, 7 para Domingo)");
        out.println("Indica el nombre del mes");
        String nombreMes = lector.nextLine();
        
        PrintWriter fichero = null;
        try{
            fichero = new PrintWriter("agenda" + nombreMes + ".txt");
            
            fichero.println(nombreMes);
            fichero.println();
            fichero.println("-----------------------------------------------------------");
            
            for (int i = 1; i <= cantidadDias; i++, nPrimerDia++) {
                for (DiaSemana dia : DiaSemana.values()) {
                    if(nPrimerDia == 8)
                        nPrimerDia = 1;
                    if(dia.getDiaSemana() == nPrimerDia){
                        fichero.println(primeraMayus(dia.toString()) + " " + i + ":");                        
                    }
                }
                fichero.println("-----------------------------------------------------------");
                
            }
        }
        catch(IOException o){
            o.printStackTrace();
        }
        finally{
            if(fichero != null)
                fichero.close();
        }
    }
}
