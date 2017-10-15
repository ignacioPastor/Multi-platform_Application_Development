package regexreader;

import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;

/**
 *
 * @author Ignacio
 */
public class MainRegexReader {

    public static void main(String[] args) throws IOException {
        String nombreFichero = "ficheroConFechas.txt";
        String regExpresionBuscar = ".*\\d?\\d/\\d?\\d/\\d\\d\\d\\d.*";
        String line = null;
        try(RegexReader regReader = new RegexReader(new FileReader(nombreFichero), regExpresionBuscar)){
            do{
                line = regReader.readLine();
                if(line == null){
                    System.out.println();
                    System.out.println("Fin de lectura");
                }
                else if("nop".equals(line)){

                }
                else
                    System.out.println(line);
            }
            while(line != null);
                
        }
        catch(FileNotFoundException e1){
            System.err.println(e1.getMessage());
        }
        catch(IOException e2){
            System.err.println(e2.getMessage());
        }
        
    }
    
}
