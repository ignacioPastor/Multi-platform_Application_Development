package ejerciciospropuestos_1.pkg3.pkg1;

import java.io.File;
import java.io.FileInputStream;

/**
 *
 * @author Ignacio
 */
public class MainEjerciciosPropuestos_131 {

    public static void main(String[] args) {
        try{
            String nombreFichero = "vs2015.3.exe";
            boolean d1 = false;
            boolean d2 = false;
            int dato = 0;
            FileInputStream fichero = new FileInputStream(new File(nombreFichero));
            
            dato = fichero.read();
            d1 = Integer.toHexString(dato).equals("4d");
            
            dato = fichero.read();
            d2 = Integer.toHexString(dato).equals("5a");
            
            if(d1 == true && d2 == true)
                System.out.println("Parece un fichero \".exe\" valido");
            else
                System.out.println("No parece un fichero \".exe\" valido");
            
            fichero.close();
        }
        catch(Exception e){
            System.out.println("Ha habido un error: " + e.getMessage());
        }
    }
}
