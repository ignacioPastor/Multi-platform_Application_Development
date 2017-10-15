
package companies;

/**
 *
 * @author Ignacio
 */
public class Person implements Comparable<Person> {

    public Person(){
        
    }
    public Person(String name, int age){
        this.name = name;
        this.age = age;
    }
    
    String name;
    int age;

    
    public String getName(){
        return name;
    }
    public int getAge(){
        return age;
    }
    

    @Override
    public int compareTo(Person o) {
        if(this.age > o.age)
            return 1;
        else if(this.age < o.age)
            return -1;
        else
            return 0;
    }
}
