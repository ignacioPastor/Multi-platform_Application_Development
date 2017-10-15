
package examreminder.model;
/**
 * Final Exercise - Unit 2 - Service and Process Programming
 * Ignacio Pastor Padilla - 2º DAM Semi-presincial
 */

import java.time.LocalDate;

/**
 * This class characterice the Exam object
 * @author Ignacio Pastor Padilla
 */
public class Exam {
    
    private String subject;
    private LocalDate date;
    private float mark;
    /**
     * Void constructor who initializes data.
     */
    public Exam(){
        subject = "";
        date = null;
        mark = 0.0f;
    }
    /**
     * Constructor with two parameters
     * @param subject name of subject
     * @param date date of exam
     */
    public Exam(String subject, LocalDate date){
        this.subject = subject;
        this.date = date;
        mark = 0.0f;
    }
    /**
     * Constructor with three parameters
     * @param subject name of subject
     * @param date date of exam
     * @param mark mark of exam
     */
    public Exam(String subject, LocalDate date, float mark){
        this.subject = subject;
        this.date = date;
        this.mark = mark;
    }
    /**
     * Setter of subject
     * @param subject 
     */
    public void setSubject(String subject){
        this.subject = subject;
    }
    /**
     * getter of subject
     * @return String subject
     */
    public String getSubject(){
        return subject;
    }
    /**
     * setter of Date
     * @param date 
     */
    public void setDate(LocalDate date){
        this.date = date;
    }
    /**
     * getter of date
     * @return LocalDate
     */
    public LocalDate getDate(){
        return date;
    }
    /**
     * setter of mark
     * @param mark 
     */
    public void setMark(float mark){
        this.mark = mark;
    }
    /**
     * getter of mark
     * @return float
     */
    public float getMark(){
        return mark;
    }
    /**
     * Put all data in one String and return that String
     * @return String with Exam data 
     */
    public String getData(){
        if(mark == 0.0f)
            return subject + ":" + getPerformedDate();
        else
            return subject + ":" + getPerformedDate() + ":" + mark;
    }
    /**
     * Prepares the kind of show date
     * @return string with local date separated by "/" instead "-"
     */
    public String getPerformedDate(){
        String[] line = date.toString().split("-");
        return line[2] + "/" + line[1] + "/" + line[0];
    }
}
