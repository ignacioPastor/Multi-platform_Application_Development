
package regexreader;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.Reader;
import java.util.regex.Pattern;

/**
 *
 * @author Ignacio
 */
public class RegexReader extends BufferedReader {
    //Pattern regex;
    String stringRegex;
    public RegexReader(Reader reader, String stringRegex){
        super(reader);
        //this.regex = Pattern.compile(stringRegex);
        this.stringRegex = stringRegex;
    }
    
    @Override
    public String readLine() throws IOException{
        String line = super.readLine();
        if(line == null)
            return null;
        else if(line.matches(stringRegex))
            return line;
        else
            return "nop";
    }
    
}
