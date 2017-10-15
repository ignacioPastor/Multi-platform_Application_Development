
package companies;

import java.util.Collection;
import java.util.Iterator;
import java.util.Map;
import java.util.Set;
import java.util.TreeMap;
import java.util.TreeSet;

/**
 * Exercise 5 - Unit 1
 * @author Ignacio
 */
public class MainCompanies {

    public static void main(String[] args) {
    
        Person p1 = new Person("Saul", 29);
        Person p2 = new Person("Antonio", 24);
        Person p3 = new Person("Marcos", 37);
        Person p4 = new Person("Rodolfo", 21);
        Person p5 = new Person("Eugenia", 18);
        Person p6 = new Person("Marta", 54);
        Person p7 = new Person("Ignacio", 25);
        Person p8 = new Person("Aradia", 21);
        Person p9 = new Person("Segismundo", 57);
        
        
        Company c1 = new Company("Monsanto", 380.12);
        Company c2 = new Company("Herbalife", 207.382);
        Company c3 = new Company("Ferrovial", 485.32);
        
        TreeSet people1 = new TreeSet();
        TreeSet people2 = new TreeSet();
        TreeSet people3 = new TreeSet();
        
        people1.add(p1);
        people1.add(p2);
        people1.add(p3);
        people2.add(p4);
        people2.add(p5);
        people2.add(p6);
        people3.add(p7);
        people3.add(p8);
        people3.add(p9);
        
//        verTreeSet(people1);
//        verTreeSet(people2);
//        verTreeSet(people3);
        
        TreeMap<Company, TreeSet> companies = new TreeMap<>();
        companies.put(c1, people1);
        companies.put(c2, people2);
        companies.put(c3, people3);
        
        //verTreeMap(companies);
        verTreeMap2(companies);
        //verTreeMap3(companies);
        
        
    }
    public static void verTreeSet(Set t){
        Iterator i = t.iterator();
        Person p;
        while(i.hasNext()){
            p = (Person)i.next();
            System.out.println("Name: " + p.getName() + ". Age: " + p.getAge());
        }
        System.out.println();
    }
    public static void verTreeMap(Map t){
        Iterator i = t.keySet().iterator();
        Company c;
        while(i.hasNext()){
            c = (Company)i.next();
            System.out.println("Company name: " + c.name + ". Company money: " + c.getMoney() + ".");
            verTreeSet((Set)t.get(c));
        }
    }
    public static void verTreeMap2(Map t){
        Set mapSet = t.entrySet();
        Iterator i = mapSet.iterator();
        Map.Entry e;
        Company c;
        TreeSet s;
        //System.out.println(i.getClass());
        while(i.hasNext()){
            e = (Map.Entry<Company, TreeSet>)i.next();
            c = (Company)e.getKey();
            s = (TreeSet)e.getValue();
            System.out.println("Company name: " + c.name + ". Company money: " + c.getMoney() + ".");
            verTreeSet(s);
        }
    }
    public static void verTreeMap3(TreeMap<Company, Set<Person>> t){
        for( Map.Entry<Company, Set<Person>> entry : t.entrySet()){
            Company key = entry.getKey();
            Set<Person> value = entry.getValue();
        }
    }
}
