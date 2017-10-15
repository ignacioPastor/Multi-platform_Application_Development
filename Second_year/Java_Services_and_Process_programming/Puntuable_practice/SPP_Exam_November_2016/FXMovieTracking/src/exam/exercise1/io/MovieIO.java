
package exam.exercise1.io;

import exam.exercise1.model.Movie;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

/**
 * PSP Exam
 * @author Ignacio
 * This class manage the reading and writting instructions for save and load Movies
 */
public class MovieIO {
    private static final String NAME_FILE_MOVIES = "movies.txt";
    public MovieIO(){

    }
    
    public static List<Movie> loadMovies(){
        if(!(new File(NAME_FILE_MOVIES).exists())){
            System.err.println("Error: movie data file doesn't exists.");
            return null;
        }
        BufferedReader reader = null;
        List<Movie> listMovies = new ArrayList<>();
        String line = "";
        String[] splitLine = null;
        try{
            reader = new BufferedReader(new FileReader(new File(NAME_FILE_MOVIES)));
            while((line = reader.readLine()) != null){
                splitLine = line.split("-");
                listMovies.add(new Movie(splitLine[0], Integer.parseInt(splitLine[1]),
                        splitLine[2], Integer.parseInt(splitLine[3])));
            }
        }catch(IOException io){
            System.err.println("IO error: " + io.getMessage());
        }
        catch(NumberFormatException e){
            System.err.println("NumberFormatError : " + e.getMessage());
        }finally{
            try{reader.close();}catch(IOException io2){System.err.println("IOError closing file");}
        }
        return listMovies;
    }
    public static void saveMovies(List<Movie> listMovies){
        if(!(new File(NAME_FILE_MOVIES).exists())){
            System.err.println("Error: movie data file doesn't exists.");
        }
        BufferedWriter writer = null;
        try{
            writer = new BufferedWriter(new FileWriter(new File(NAME_FILE_MOVIES)));
            Iterator it = listMovies.iterator();
            while(it.hasNext()){
                writer.write(it.next().toString());
                writer.newLine();
            }
        }catch(IOException io){
            System.err.println("IOError: " + io.getMessage());
        }catch(Exception e){
            System.err.println("Error: " + e.getMessage());
        }finally{
            try{
                writer.close();
            }catch(IOException io2){
                System.err.println("IOError closing file");
            }
        }
    }
    
 

   
}
