
package orderedcoments;

import java.time.temporal.ChronoUnit;
import java.util.Comparator;

/**
 *
 * @author Ignacio
 */
public class MyCommentComparator implements Comparator<Comment>{

    @Override
    public int compare(Comment o1, Comment o2) {
         if(o1.date.until(o2.date, ChronoUnit.SECONDS) > 0)
            return -1;
        else if(o1.date.until(o2.date, ChronoUnit.SECONDS) < 0)
            return 1;
        else
            return 0;
    }

}
