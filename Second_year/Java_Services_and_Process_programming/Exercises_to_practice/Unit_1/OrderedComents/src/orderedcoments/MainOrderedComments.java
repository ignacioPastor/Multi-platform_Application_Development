package orderedcoments;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.time.Month;
import java.time.ZoneId;
import java.time.ZonedDateTime;
import java.time.format.DateTimeFormatter;
import java.time.temporal.TemporalAccessor;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;

/**
 *
 * @author Ignacio
 */
public class MainOrderedComments {

    public static void main(String[] args) {
        
        String nombreFichero = "comments.txt";
        if(!(new File(nombreFichero).exists())){
            System.out.println("No se ha encontrado el fichero de comentarios");
            return;
        }
        List<Comment> comments = null;
        try{
            BufferedReader ficheroLectura = new BufferedReader(
                new FileReader(new File(nombreFichero)));
            
            Comment c;
            String linea;
            String[] lineaSplit;
            int[] fecha;
            int[] hora;
            comments = new ArrayList<>();
            while((linea = ficheroLectura.readLine()) != null){
                lineaSplit = linea.split(";");
                fecha = datear(lineaSplit[2], "fecha");
                hora = datear(lineaSplit[3], "hora");
                
                c = new Comment(lineaSplit[0],lineaSplit[1], 
                    ZonedDateTime.of(fecha[2], fecha[1], fecha[0], 
                    hora[0], hora[1], hora[2], 0, ZoneId.of(lineaSplit[4])));
                c.date.withZoneSameInstant(ZoneId.of("Europe/Madrid"));
                comments.add(c);
            }
            MyCommentComparator mcc = new MyCommentComparator();
            Collections.sort(comments, mcc);
            ficheroLectura.close();
        }
        catch(IOException e){
            System.err.println(e.getMessage());
        }
        try{
//            BufferedWriter ficheroEscritura = new BufferedWriter(
//                new FileWriter(new File("ordered_comments.txt")));
            PrintWriter ficheroEscritura = new PrintWriter("ordered_comments.txt");
            for (int i = 0; i < comments.size(); i++) {
                
            
                ficheroEscritura.println(comments.get(i).username + ";" + comments.get(i).comment + ";"
                    + comments.get(i).date.format(DateTimeFormatter.ofPattern("dd/MM/yyy;HH:mm:ss;VV")));
            }
            ficheroEscritura.close();
        }
        catch(IOException e1){
            System.err.println(e1.getMessage());
        }
    }
    public static int[] datear(String str, String tipo){
        String separador;
        if("fecha".equals(tipo))
            separador = "/";
        else
            separador = ":";
        String[] strSpliteado = str.split(separador);
        int[] result = new int[3];
        for (int i = 0; i < 3; i++) {
            result[i] = Integer.parseInt(strSpliteado[i]);
        }
        return result;
    }
}
