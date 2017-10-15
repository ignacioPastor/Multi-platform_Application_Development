/*
 1.1.7. Crea un programa que pregunte al usuario la cantidad de días de un mes, el número del
primer día (1 para lunes, 7 para domingo) y el nombre del mes (por ejemplo, “Marzo”) y cree
un fichero de texto llamado “calendarioMarzo.txt” (o el nombre del mes que corresponde),
con el calendario de ese mes.
 */
package ejerciciospropuestos_1.pkg1.pkg7;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.Scanner;

/**
 *
 * @author Ignacio Pastor Padilla
 */
public class EjerciciosPropuestos_117 {

    public static int pedirEntero(String texto){
        Scanner lectorE = new Scanner(System.in);
        int n = 0;
        boolean ok;
        do{
            ok = true;
            try{
                System.out.println(texto);
                n = lectorE.nextInt();
            }
            catch(NumberFormatException fn){
                System.out.println("Error: " + fn.getMessage());
                ok = false;
                lectorE.next();
            }
        }
        while(ok == false);
        return n;
    }
    
    public enum DiasSemana{
        Lunes(1), Martes(2), Miercoles(3), Jueves(4), Viernes(5), Sabado(6), Domingo(7);
        private final int nDia;
        private DiasSemana(int nDia){
            this.nDia = nDia;
        }
        public int getNDia(){
            return nDia;
        }
    }
    
    public static void main(String[] args) {
        
        Scanner lector = new Scanner(System.in);
        int cantidadDias = pedirEntero("Indica la cantidad de dias que tiene el mes");
        int nPrimerDia = pedirEntero("Indica el numero del primer dia (1 para Lunes, 7 para Domingo)");
        System.out.println("Indica el nombre del mes");
        String nombreMes = lector.nextLine();
        
        PrintWriter fichero = null;
        try{
            fichero = new PrintWriter("calendario" + nombreMes + ".txt");
            
            fichero.println(nombreMes);
            fichero.println();
            for(DiasSemana dia : DiasSemana.values()){
                fichero.print(dia.toString().toLowerCase().substring(0, 3) + " ");
            }
            fichero.println();
            
            int contadorDias = 1;
            while(contadorDias <= cantidadDias){
                for(DiasSemana dia : DiasSemana.values()){
                    fichero.print(" ");
                    if(contadorDias == 1 && dia.getNDia() != nPrimerDia){
                        fichero.print("  ");
                    }
                    else if(contadorDias <= cantidadDias){
                        if(contadorDias / 10 == 0) // Si tiene una cifra dara 0, si tiene dos cifras dara 1
                            fichero.print(" " + contadorDias++);
                        else
                            fichero.print(contadorDias++);
                    }
                    fichero.print(" ");
                }
                fichero.println();
            }
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
