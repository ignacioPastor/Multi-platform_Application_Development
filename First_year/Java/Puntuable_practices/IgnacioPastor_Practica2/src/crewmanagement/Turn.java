
package crewmanagement;

import static java.lang.System.out;

/**
 * Class to store information of Turns
 * @author Ignacio
 * @version 1.0
 */
public class Turn {
    
    protected String day;
    private int initHour, finishHour;
    /**
     * Constructor of the class
     */
    public Turn(){
        day = null;
        initHour =0;
        finishHour = 0;
    }
    /**
     * Constructor oversized of the class
     * @param day
     */
    public Turn(String day){
        if(day != null)
            this.day  = day.toUpperCase();
        initHour = 0;
        finishHour = 0;
    }
    /**
     * Constructor oversized
     * @param day
     * @param initHour
     * @param finishHour
     */
    public Turn(String day, int initHour, int finishHour){
        if(day != null)
            this.day = day.toUpperCase();
        if(initHour >= 0 && initHour <= 23)
            this.initHour = initHour;
        if(finishHour >= 0 && finishHour <= 23)
            this.finishHour = finishHour;
    }
    /**
     * set the day of week
     * @param day, day of week
     */
    public void setDay(String day){
        if(day != null)
            this.day = day.toUpperCase();
    }
    /**
     * get the day of week
     * @return day of week
     */
    public String getDay(){
        return day;
    }
    /**
     * set the Initial Hour of work
     * @param initHour initial Hour of work
     */
    public void setInitHour(int initHour){
        if(initHour >= 0 && initHour <= 23){
            this.initHour = initHour;
        }
        //else out.println("It must be an integer between 0 and 23");
    }
    /**
     * get the Initial Hour of work
     * @return initHour of work
     */
    public int getInitHour(){
        return initHour;
    }
    /**
     * set the Finish Hour of work
     * @param finishHour, Finish Hour of work
     */
    public void setFinishHour(int finishHour){
        if (finishHour >= 0 && finishHour <= 23)
            this.finishHour = finishHour;
        //else out.println("It must be an integer between 0 and 23");
    }
    /**
     * get the Finish Hour of work
     * @return finishHour of work
     */
    public int getFinishHour(){
        return finishHour;
    }
    /**
     * For get the information of Turn in the screen
     * @return the information of Turn like String
     */
    @Override
    public String toString(){
        return "Day: " + day + "; Initial Hour: " + initHour + "; Finish Hour: " + finishHour;
    }
}
