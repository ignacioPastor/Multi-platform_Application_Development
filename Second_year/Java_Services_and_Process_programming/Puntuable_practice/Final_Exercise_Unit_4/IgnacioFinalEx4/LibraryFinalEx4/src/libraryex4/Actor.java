
package libraryex4;

import java.io.Serializable;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Date;
import java.util.Locale;

/**
 * Characterize Actor object
 * @author Ignacio Pastor Padilla
 */
public class Actor implements Serializable{
    
    private Integer id;
    private String name;
    //private LocalDate birthDate;
    private String birthDate;
    private String imgFile;
    private String description;
    
    /**
     * Void constructor.
     * Initializes to null all properties
     */
    public Actor() {
        this.id = null;
        this.name = null;
        this.birthDate = null;
        this.imgFile = null;
        this.description = null;
    }
    /**
     * Overloaded constructor
     * @param id
     * @param name
     * @param birthDate
     * @param imgFile
     * @param description 
     */
    public Actor(Integer id, String name, String birthDate, String imgFile, String description) {
        this.id = id;
        this.name = name;
        this.birthDate = birthDate;
        this.imgFile = imgFile;
        this.description = description;
    }

    public String getBirthDate() {
        return birthDate;
    }

    public void setBirthDate(String birthDate) {
        try{
            Locale myLocale = new Locale("en", "US");
            DateTimeFormatter formatter = DateTimeFormatter.ofPattern("yyyy-M-d", myLocale);
            LocalDate myDate = LocalDate.parse(birthDate, formatter);
            DateTimeFormatter formatter2 = DateTimeFormatter.ofPattern("MMMM d, yyyy", myLocale);
            this.birthDate = myDate.format(formatter2);
        }catch(Exception e){}
        //this.birthDate = birthDate;
    }
    /**
     * Getter of id
     * @return id
     */
    public Integer getId() {
        return id;
    }
    /**
     * Setter of id
     * @param id new value for id
     */
    public void setId(Integer id) {
        this.id = id;
    }
    /**
     * Getter of name
     * @return name
     */
    public String getName() {
        return name;
    }
    /**
     * Setter of name
     * @param name new value for name
     */
    public void setName(String name) {
        this.name = name;
    }
//    /**
//     * Getter of birthDate
//     * @return birthDate
//     */
//    public LocalDate getBirthDate() {
//        
//        return birthDate;
//    }
//    public String getBirthDateString(){
//        Locale myLocale = new Locale("en", "US");
//        DateTimeFormatter formatter = DateTimeFormatter.ofPattern("MMMM d, yyyy", myLocale);
//        
//        return birthDate.format(formatter);
//    }
//    
//    /**
//     * Setter of birthDate
//     * @param birthDate new value for birthDate
//     */
//    public void setBirthDate(LocalDate birthDate) {
//        this.birthDate = birthDate;
//    }
//    public void setBirthDate(String birthDate) {
//        Locale myLocale = new Locale("en", "US");
//        DateTimeFormatter formatter = DateTimeFormatter.ofPattern("yyyy-M-d", myLocale);
//        DateTimeFormatter formatter2 = DateTimeFormatter.ofPattern("MMMM d, yyyy", myLocale);
//        try{
//            this.birthDate = LocalDate.parse(birthDate, formatter);
//        }catch(Exception e){
//            System.out.println("Primer catch");
//            try{
//                this.birthDate = LocalDate.parse(birthDate, formatter2);
//            }catch(Exception e2){
//                System.out.println("Segundo catch");
//        }
//            
//        }
//    }
    /**
     * Getter of imgFile
     * @return imgFile
     */
    public String getImgFile() {
        return imgFile;
    }

    /**
     * Setter of imgFile
     * @param imgFile new value for imgFile
     */
    public void setImgFile(String imgFile) {
        this.imgFile = imgFile;
    }
    /**
     * Getter of description
     * @return description
     */
    public String getDescription() {
        return description;
    }
    /**
     * Setter for description
     * @param description new value of description
     */
    public void setDescription(String description) {
        this.description = description;
    }
    
//    @Override
//    public String toString() {
//        return "Actor:\n" + "Id: " + id + ".\nName: " + name + ".\nBirthDate: " + getBirthDateString()
//                + ".\nImgFile: " + imgFile + ".\nDescription: " + description + ".";
//    }

    @Override
    public String toString() {
        return "Actor [" + "id=" + id + ", name=" + name + ", birthDate=" + birthDate
                + ", imgFile=" + imgFile + ", description=" + description + "]";
    }
}
