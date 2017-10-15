/*
0.4: Pide al usuario un número del 1 al 12 y muestra el nombre del correspondiente mes, 
usando un array de cadenas de texto en el que estarán almacenados dichos nombres.
*/
package ejerciciorepaso_t0_e04;

import java.util.Scanner;


public class EjercicioRepaso_T0_E04 {

    
    public static void main(String[] args) {
        String[] meses = {"Enero","Febrero", "Marzo", "Abril", "Mayo", "Junio",
            "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"};
        Scanner teclado = new Scanner(System.in);
        try{
            System.out.println("Introduce un número del 1 al 12");
            int n = teclado.nextInt();
            System.out.println("El nombre del mes que corresponde al número que has introducido es: " + meses[n]);
        }
        catch(Exception e){
            System.out.println("Debes introducir un número del 1 al 12");
        }
    }
    
}
