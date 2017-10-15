/*
0.3: Pide al usuario un número del 1 al 12 y muestra el nombre del correspondiente mes, usando un “switch”.
*/
package ejerciciorepaso_t0_e03;

import static java.lang.System.out;
import java.util.Scanner;

/**
 *
 * @author Ignacio
 */
public class EjercicioRepaso_T0_E03 {
    
    public static void main(String[] args) {
        int n;
        Scanner teclado = new Scanner(System.in);
        out.println("Introduce un número del 1 al 12");
        try {
        n = teclado.nextInt();            
        }
        catch(Exception e){
            n = 0;
        }
        
        switch(n){
            case 1: out.println("Enero"); break;
            case 2: out.println("Febrero"); break;
            case 3: out.println("Marzo"); break;
            case 4: out.println("Abril"); break;
            case 5: out.println("Mayo"); break;
            case 6: out.println("Junio"); break;
            case 7: out.println("Julio"); break;
            case 8: out.println("Agosto"); break;
            case 9: out.println("Septiembre"); break;
            case 10: out.println("Octubre"); break;
            case 11: out.println("Noviembre"); break;
            case 12: out.println("Diciembre"); break;
            default: out.println("No has introducido un número del 1 al 12!"); break;
        }
    }
    
}
