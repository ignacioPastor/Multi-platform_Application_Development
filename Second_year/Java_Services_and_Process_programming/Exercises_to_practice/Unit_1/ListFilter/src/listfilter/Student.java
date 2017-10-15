
package listfilter;

import java.util.List;

/**
 *
 * @author Ignacio
 */
public class Student {
    public Student(){
        
    }
    public Student(String name, int age, List<String> subjects){
        this.name = name;
        this.age = age;
        this.subjects = subjects;
    }
    
    private String name;
    private int age;
    private List<String> subjects;
    
    public String getName(){
        return name;
    }
    public int getAge(){
        return age;
    }
    public List<String> getSubjects(){
        return subjects;
    }
}
