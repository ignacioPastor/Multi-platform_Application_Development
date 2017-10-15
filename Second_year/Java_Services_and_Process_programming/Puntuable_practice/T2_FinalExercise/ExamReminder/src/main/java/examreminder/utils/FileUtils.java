
package examreminder.utils;
/**
 * Final Exercise - Unit 2 - Service and Process Programming
 * Ignacio Pastor Padilla - 2º DAM Semi-presincial
 */
import examreminder.model.Exam;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;
import org.apache.commons.codec.digest.DigestUtils;

/**
 * Class with usefull statics methods
 * @author Ignacio Pastor Padilla
 */
public class FileUtils {

    final static String NAME_LOGIN_FILE = "loginData.txt";
    final static String NAME_EXAMS_FILE = "examData.txt";
    /**
     * Load exams from a given text file
     * @return list of exams load from de text file
     */
    public static List<Exam> loadExams(){
        if(!(new File(NAME_EXAMS_FILE).exists())){
            System.err.println("Error: exam data file doesn't exists.");
            return null;
        }
        List<Exam> listExams = new ArrayList<>();
        BufferedReader reader = null;
        String line = "";
        String[] splitLine = null;
        try{
            reader = new BufferedReader(new FileReader(new File(NAME_EXAMS_FILE)));
            while((line = reader.readLine()) != null){
                splitLine = line.split(":");
                int[] date = getDate(splitLine[1]);
                if(splitLine.length == 2)
                    listExams.add(new Exam(splitLine[0], LocalDate.of(date[2], date[1], date[0])));
                else
                    listExams.add(new Exam(splitLine[0], LocalDate.of(date[2], date[1], date[0]),
                            Float.parseFloat(splitLine[2])));
            }
        }catch(Exception e){
            System.err.println("Error: " + e.getMessage());
            try{
                reader.close();
            }catch(Exception o){
                System.err.println("Error, examData file can't be closed: " + o.getMessage());
            }
        }
        return listExams;
    }
    /**
     * return array with integers of year, month, day
     * @param date 
     * @return array of integer with the numbers of date
     */
    private static int[] getDate(String date){
        String[] splitDate = date.split("/");
        return new int[]{Integer.parseInt(splitDate[0]), 
            Integer.parseInt(splitDate[1]), Integer.parseInt(splitDate[2])};
    }
    /**
     * Save the list of exams in the file
     * @param exams list of exams
     */
    public static void saveExams(List<Exam> exams){
        if(!(new File(NAME_EXAMS_FILE).exists())){
            System.err.println("Error: exam data file doesn't exists.");
            return;
        }
        BufferedWriter writer = null;
        try{
            writer = new BufferedWriter(new FileWriter(new File(NAME_EXAMS_FILE)));
            for (int i = 0; i < exams.size(); i++){
                writer.write(exams.get(i).getData());
                writer.newLine();
            }
            writer.close();
        }catch(Exception e){
            System.err.println("Error saving exams data: " + e.getMessage());
            try{
                writer.close();
            }catch(Exception o){
                System.err.println("Error closing the exam data file: " + e.getMessage());
            }
        }
    }
    /**
     * Read the file with login data an check if user's data are registered
     * @param user user nick
     * @param password user password
     * @return true if is registered in the file
     */
    public static boolean checkLogin(String user, String password){
        if(!(new File(NAME_EXAMS_FILE).exists())){
            System.err.println("Error: login data file doesn't exists.");
            return false;
        }
        String data = user + ":" + DigestUtils.sha256Hex(password); //Password has to be protected
        BufferedReader reader = null;
        try{
            reader = new BufferedReader(new FileReader(new File(NAME_LOGIN_FILE)));
            String line = "";
            while((line = reader.readLine()) != null){
                if(line.equals(data)){
                    reader.close();
                    return true;
                }
            }
            reader.close();
            return false;
        }catch(Exception e){
            System.err.println("Error: " + e.getMessage());
            try{
                reader.close();
            }catch(Exception o){
                System.err.println("Error, dataLogin file can't be closed: " + o.getMessage());
            }
            return false;
        }
    }
}
