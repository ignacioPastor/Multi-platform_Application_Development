/*
1.4.2: Crea una versión alternativa del ejercicio 1.3.3, leyendo los datos a un array en vez de
trabajar byte a byte: un programa que extraiga el contenido de un fichero binario, volcando a
un fichero de texto todo lo que sean caracteres imprimibles (basta con que sean desde la A
hasta la Z, junto con el espacio en blanco).
*/
package ejerciciospropuestos_1.pkg4.pkg2;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileWriter;
import java.io.InputStream;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.Scanner;

/**
 *
 * @author Ignacio
 */
public class MainEjerciciosPropuestos_142 {
    
    public static void main(String[] args) {
        
        Scanner scanner = new Scanner(System.in);
//        System.out.println("Indica el nombre del fichero");
//        String nombreFicheroEntrada = scanner.nextLine();
        String nombreFicheroEntrada = "fotoBMP.bmp";
        String nombreFicheroSalida = nombreFicheroEntrada + ".txt";
        if(!(new File(nombreFicheroEntrada).exists())){
            System.out.println("No se ha encontrado el fichero especificado");
            return;
        }
        
        try{
            InputStream ficheroEntrada = new FileInputStream(new File(nombreFicheroEntrada));
            PrintWriter ficheroSalida = new PrintWriter(new FileWriter(nombreFicheroSalida));
            
            System.out.println("Cargando archivo en la memoria interna del programa...");
            List<Byte> listBytes = new ArrayList<>();
            int dato;
            while((dato = ficheroEntrada.read()) > 0){
                listBytes.add((byte)dato);
            }
            verLista(listBytes);
//            Iterator it = listBytes.iterator();
//            while(it.hasNext()){
//                listBytes.add((Byte)it.next());
//            }
            System.out.println("Volcando los caracteres imprimibles en el fichero de texto...");
            Iterator it2 = listBytes.iterator();
            Byte byt;
            while(it2.hasNext()){
                byt = (Byte)it2.next();
                System.out.println(byt);
                if(comprobarImprimible(byt)){
                    System.out.println("Encuentra valor imprimible");
                    ficheroSalida.println(byt);
                    ficheroSalida.println("patata");
                }
            }
            
            ficheroEntrada.close();
            System.out.println("Va a cerrar el fichero de texto");
            ficheroSalida.close();
        }
        catch(Exception e){
            System.err.println("Ha habido un error: " + e.getMessage());
        }
    }
    public static boolean comprobarImprimible(Byte b){
        System.out.println("Entrando en comprobarImprimible");
        System.out.println(b);
        System.out.println("A ver como lo traduce del asci");
        System.out.println(Integer.toString(Byte.toUnsignedInt(b)));
        System.out.println();
        return (Byte.toString(b).matches("[A-Za-z0-9]") || Byte.toString(b).matches("(\\s)"));
    }
    public static void verLista(List<Byte> lista){
        Iterator iter = lista.iterator();
        while(iter.hasNext()){
            System.out.println(iter.next());
        }
    }
}
