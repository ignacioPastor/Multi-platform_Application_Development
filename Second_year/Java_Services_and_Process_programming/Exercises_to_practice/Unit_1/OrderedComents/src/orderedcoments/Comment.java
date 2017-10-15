
package orderedcoments;

import java.time.ZonedDateTime;
import java.time.temporal.ChronoUnit;

/**
 *
 * @author Ignacio
 */
public class Comment{
    public Comment(){
        
    }
    public Comment(String username, String comment, ZonedDateTime date){
        this.username = username;
        this.comment = comment;
        this.date = date;
    }
    String username;
    String comment;
    ZonedDateTime date;

//    @Override
//    public int compareTo(Comment o) {
//        if(this.date.until(o.date, ChronoUnit.SECONDS) > 0)
//            return 1;
//        else if(this.date.until(o.date, ChronoUnit.SECONDS) > 0)
//            return -1;
//        else
//            return 0;
//    }

    
}
