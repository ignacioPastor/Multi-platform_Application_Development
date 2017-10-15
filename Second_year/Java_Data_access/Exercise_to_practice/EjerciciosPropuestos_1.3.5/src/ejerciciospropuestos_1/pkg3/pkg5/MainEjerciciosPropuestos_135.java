/*
1.3.5: Crea un programa que diga si un fichero (binario) contiene 
una cierta palabra que introduzca el usuario, buscando byte a byte.
*/
package ejerciciospropuestos_1.pkg3.pkg5;

import java.io.File;
import java.io.FileInputStream;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/**
 *
 * @author Ignacio
 */
public class MainEjerciciosPropuestos_135 {

    public static void main(String[] args) {
        
        Scanner scanner = new Scanner(System.in);
        System.out.println("Indica el nombre del fichero");
        String nombreFichero = scanner.nextLine();
        System.out.println("Indica la palabra que quieres buscar");
        String palabraBuscar = scanner.nextLine();
        
        //String nombreFichero = "fotoGIF.gif";
//        String palabraBuscar = "GIF";
        
        
        if(!(new File(nombreFichero).exists())){
            System.err.println("No se ha encontrado el fichero.");
            return;
        }
        FileInputStream fichero = null;
        try{
            fichero = new FileInputStream(new File(nombreFichero));
            int dato = 0;
            List<Integer> listaFichero = new ArrayList<>();
            while((dato = fichero.read()) != -1){
                listaFichero.add(dato);
            }
            
            fichero.close();
            
            if(buscarPalabra(listaFichero, palabraBuscar))
                System.out.println("La palabra está en el fichero");
            else
                System.out.println("No se ha encontrado la palabra");
        }
        catch(Exception e){
            System.err.println("Ha habido un error: " + e.getMessage());
        }
        
        
        
    }
    public static boolean buscarPalabra(List<Integer> lista, String palabra){
        int longitudPalabra = palabra.length();
        byte[] paByte = palabra.getBytes();
        List<Integer> palabraInt = new ArrayList<>();
        for (int i = 0; i < paByte.length; i++) {
            palabraInt.add(Byte.toUnsignedInt(paByte[i]));
        }
        
        
        boolean salir = false;
        for(int i = 0; i < lista.size() && salir == false; i++){
            if(lista.get(i) == palabraInt.get(0))
                salir = comprobarPalabra(lista, palabraInt, i);
        }
        
        return salir;
    }
    public static boolean comprobarPalabra(List<Integer> lista, List<Integer> palabraInt, int i){
        for(int j = i, k = 0; k < palabraInt.size(); j++, k++) {
            if(lista.get(j) != palabraInt.get(k))
                return false;
        }
        return true;
    }
}
