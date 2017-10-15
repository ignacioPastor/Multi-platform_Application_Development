/*

0.2: Pide al usuario un número entero y muéstralo como producto de sus factores primos, algo como: 24 = 2 * 2 * 2 * 3
*/
package ejerciciorepaso_t0_e02;
import static java.lang.System.out;
import java.util.Scanner;
/**
 *
 * @author Ignacio
 */

public class EjercicioRepaso_T0_E02 {

    public static void asterisco(int n){
        if(n > 1)
            out.print(" * ");
        else
            out.println();
    }
    public static void descomponer(int n){
        if(n > 1){
            if(n % 2 == 0){
                n /= 2;
                out.print(2);
                asterisco(n);
            }
            else if (n % 3 == 0){
                n /= 3;
                out.print(3);
                asterisco(n);
            }
            else if (n % 5 == 0){
                n /= 5;
                out.print(5);
                asterisco(n);
            }
            descomponer(n);
        }
        
        
    }
    public static void main(String[] args) {
        Scanner entrada = new Scanner(System.in);
        out.print("Introduce un número entero: ");
        int n = entrada.nextInt();
        out.print(n + " = ");
        descomponer(n);
        
    }
    
}
