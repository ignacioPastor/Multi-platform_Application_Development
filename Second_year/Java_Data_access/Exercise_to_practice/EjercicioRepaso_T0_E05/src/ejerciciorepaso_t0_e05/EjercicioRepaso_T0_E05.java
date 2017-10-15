/*
0.5: Pide al usuario un número entero y di si es (o no) un palíndromo primo,
con la ayuda de dos funciones booleanas “esPrimo” y “esPalindromo”.
*/

package ejerciciorepaso_t0_e05;

import static java.lang.System.out;
import java.util.Scanner;

public class EjercicioRepaso_T0_E05 {

    public static boolean esPrimo(int n){
        for (int i = n - 1; i > 1; i--) {
            if(n % i == 0)
                return false;
        }
        return true;
    }
    
    public static boolean esPalindromo(int n){
        String nString = Integer.toString(n);
        if(nString.length() > 1){
            int mitad = nString.length() / 2;
            
            return (nString.substring(0, mitad).equals(invertirCadena(nString.substring(mitad + ajusteNumCifrasParImpar(nString), nString.length()))));
//            if(nString.substring(0, mitad).equals(invertirCadena(nString.substring(mitad + ajusteNumCifrasParImpar(nString), nString.length())))){
//                return true;
//            }
        }
        return false;
    }
    public static String invertirCadena(String cadena){
        String cadenaInvertida = "";
        for (int i = cadena.length() - 1; i >= 0; i--) {
            cadenaInvertida += cadena.charAt(i);
        }
        return cadenaInvertida;
    }
    public static int ajusteNumCifrasParImpar(String cadena){
        if(cadena.length() % 2 == 0)
            return 0;
        return 1;
    }
    
    public static void main(String[] args) {
        Scanner teclado = new Scanner(System.in);
        int n;
        try{
            out.println("Introduce un número entero");
            n = teclado.nextInt();
            if(esPrimo(n))
                out.println("Es Primo");
            else
                out.println("No es primo");
            if(esPalindromo(n))
                out.println("Es palindromo");
            else
                out.println("No es palindromo");
        }
        catch(Exception e){
            out.println("Error: " + e.getLocalizedMessage());
        }
    }
    
}