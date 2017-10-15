//package org.kodejava.sample.commons.io;
package clasesJava;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import org.apache.commons.io.FileUtils;

//import org.apache.commons.io.FileUtils;


/**
 *
 * @author Ignacio
 */
public class Main {

    public static void main(String[] args) throws IOException{
        
        
        File file = new File("Unit2_partIII_Gradle.pdf");
        List<String> lines = FileUtils.readLines(file, "UTF-8");
        
        for (int i = 0; i < lines.size(); i++){
            System.out.println(lines.get(i));
        }
        System.out.println("Todo ok");


        
    }
}
