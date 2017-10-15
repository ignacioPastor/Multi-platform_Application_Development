package customexception;

import java.util.Scanner;

/**
 *
 * @author Ignacio
 */
public class MainCustomException {
    
    public static int positiveSubtract(int n1, int n2) throws NegativeSubtractException{
        int result = n1 - n2;
        if(result >= 0)
            return result;
        else
            throw new NegativeSubtractException(n1, n2);
    }
    public static boolean isInteger(String str){
        return str.matches("-?[0-9]+");
    }
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String aux;
        System.out.println("Introduce el primer numero");
        while(!isInteger(aux = scanner.nextLine()))
            System.err.println("Error: debes introducir un numero entero");
        int n1 = Integer.parseInt(aux);
        System.out.println("Introduce el segundo numero");
        while(!isInteger(aux = scanner.nextLine())){
            System.err.println("Error: debes introducir un numero entero");
        }
        int n2 = Integer.parseInt(aux);
        
        try{
            System.out.println("El resultado de restar " + n1 + " - " + n2 
                    + " es: " + positiveSubtract(n1, n2));
        }
        catch(NegativeSubtractException e){
            System.err.println(e.getMessage());
        }
    }
    
}
