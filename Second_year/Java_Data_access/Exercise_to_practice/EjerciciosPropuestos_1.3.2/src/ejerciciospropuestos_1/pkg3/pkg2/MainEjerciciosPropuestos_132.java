package ejerciciospropuestos_1.pkg3.pkg2;

import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.util.Scanner;

/**
 *
 * @author Ignacio
 */
public class MainEjerciciosPropuestos_132 {

    
    public static boolean comprobarDatoImprimible(int dato){
        String d = Character.toString((char) dato);
        
        if(d.matches("[a-zA-Z0-9]+") == true)
            return true;
        else if(d.matches("\\s") == true)
            return true;
        
        return false;
    }
    
    public static void main(String[] args) throws IOException {
        FileInputStream fichero = null;
        int dato = 0;
        try{
            Scanner scanner = new Scanner(System.in);
            //String nombreFichero = "vs2015.3.exe";
            System.out.println("Indica el nombre del fichero");
            String nombreFichero = scanner.nextLine();
            if(!(new File(nombreFichero).exists())){
                System.out.println("El fichero no existe");
                return;
            }
            fichero = new FileInputStream(new File(nombreFichero));
            
            while((dato = fichero.read()) != -1){
                if(comprobarDatoImprimible(dato) == true){
                    System.out.print((char) dato);
                }
            }
            
        }
        catch(Exception e){
            System.out.println("Ha habido un error: " + e.getMessage());
        }
        finally{
            if(fichero != null)
                fichero.close();
        }
    }
    
}
