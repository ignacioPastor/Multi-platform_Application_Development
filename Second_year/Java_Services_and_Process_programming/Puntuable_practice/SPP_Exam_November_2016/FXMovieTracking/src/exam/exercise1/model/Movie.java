
package exam.exercise1.model;

/**
 * PSP Exam
 * @author Ignacio Pastor Padilla
 * This class characterize the Movie object
 */
public class Movie {
    private String title;
    private int year;
    private String category;
    private int rating;
    /**
     * Void constructor who initializes all variables
     */
    public Movie(){
        title = "";
        year = -1;
        category = "";
        rating = -1;
    }
    /**
     * Constructor who receives parameters
     * @param title title of the movie
     * @param year year of the movie
     * @param category category of the movie
     * @param rating rating of the movie
     */
    public Movie(String title, int year, String category, int rating){
        this.title = title;
        this.year = year;
        this.category = category;
        this.rating = rating;
    }
    public void setTitle(String title){
        this.title = title;
    }
    public String getTitle(){
        return title;
    }
    public void setYear(int year){
        this.year = year;
    }
    public int getYear(){
        return year;
    }
    public void setCategory(String category){
        this.category = category;
    }
    public String getCategory(){
        return category;
    }
    public void setRating(int rating){
        this.rating = rating;
    }
    public int getRating(){
        return rating;
    }
    /**
     * This method returns the data of de class in particual order
     * @return all parameters in custom string
     */
    @Override
    public String toString()
    {
        return title + "-" + year + "-" + category + "-" + rating;
    }
    
}
