package listfilter;

import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.Random;
import java.util.Set;
import java.util.TreeSet;
import java.util.function.Predicate;
import java.util.stream.Collector;
import java.util.stream.Collectors;
import java.util.stream.Stream;
import listfilter.MainListFilter.Subjects;

/**
 *
 * @author Ignacio
 */
public class MainListFilter {
    
    enum Subjects{PROGRAMMING, MATHS, BIOLOGY, PHILOSOPHY, MUSIC, LANGUAGE};
    public static List<String> rellenarLista(List<String> l){
        Random r = new Random();
        Subjects[] sub = Subjects.values();
        int n;
        while(l.size() < 3) {
            n = r.nextInt(6);
            if(l.indexOf(sub[n].toString().toLowerCase()) < 0)
                l.add(sub[n].toString().toLowerCase());
        }
        return l;
    }
    public static void verListaString(List<String> l){
        Iterator i = l.iterator();
        while(i.hasNext()){
            System.out.print(i.next() + "; ");
        }
    }
    public static void verListaString(Set<String> l){
        Iterator i = l.iterator();
        while(i.hasNext()){
            System.out.print(i.next() + "; ");
        }
    }
    public static void verListaStudent(List<Student> l){
        Iterator i = l.iterator();
        Student s;
        while(i.hasNext()){
            s = (Student) i.next();
            System.out.print("Nombre: " + s.getName() + ". Edad: " + s.getAge() 
                + ". Asignaturas matriculado: ");
            verListaString(s.getSubjects());
            System.out.println();
        }
    }
    public static List<Student> rellenarListaStudent(){
        List<Student> listStudents = new ArrayList();
        
        Student s1 = new Student("Prometheus Marcus", 25, rellenarLista(new ArrayList<>()));
        Student s2 = new Student("Peter Eugeion", 21, rellenarLista(new ArrayList<>()));
        Student s3 = new Student("Pacus Peter", 19, rellenarLista(new ArrayList<>()));
        Student s4 = new Student("Peter Rufus", 27, rellenarLista(new ArrayList<>()));
        Student s5 = new Student("Marco Rodriguez", 21, rellenarLista(new ArrayList<>()));
        Student s6 = new Student("Peter Jorh", 17, rellenarLista(new ArrayList<>()));
        Student s7 = new Student("Maria Rembrant", 26, rellenarLista(new ArrayList<>()));
        Student s8 = new Student("Martha Peterana", 23, rellenarLista(new ArrayList<>()));
        
        listStudents.add(s1);
        listStudents.add(s2);
        listStudents.add(s3);
        listStudents.add(s4);
        listStudents.add(s5);
        listStudents.add(s6);
        listStudents.add(s7);
        listStudents.add(s8);
        
        return listStudents;
    }
    
    
    public static void main(String[] args) {
        List<Student> listStudents = rellenarListaStudent();
        
        List<Student> older20 = filterStudents(listStudents,(s) -> s.getAge() > 20);
        List<Student> programmers = filterStudents(listStudents, (s) -> s.getSubjects().contains("programming"));
        List<Student> peters = filterStudents(listStudents, (s) -> s.getName().toLowerCase().contains("peter"));
        
        //mostrarResultados(listStudents, older20, programmers, peters);
        
        // Exercise 10---------------------------------------------------------------------------
        List<String> oldestNames = getOldestNames(listStudents);
        //verListaString(oldestNames);
        verListaString(getAllSubjects(listStudents));
        
    }
    //Exercise 10.2
//    public static List<String> getAllSubjects(List<Student> list){
//        List asignaturas = new ArrayList<>();
//        asignaturas = list.stream()
//                .map(p -> p.getSubjects())
//                .collect(Collectors.toList());
//                //.collect(Collectors. .groupingBy(p -> p.stream().distinct().to;
//                //.collect(Collectors.groupingBy(p -> p.stream()
//                    //.collect(Collectors.groupingBy(s -> s.forEach(p -> p.toString()))).toList();
//        List asignaturas2 = asignaturas.stream()
//                .sorted()
//                .distinct()
//                .collect(Collectors.toList());
//        List<String> paraEnviar;
//        //paraEnviar = asigs.stream().collect(Collectors.groupingBy(classifier))
//        
//        return asignaturas;
//    }
    //SOLUCIÓN DEL PROFESOR
    public static Set<String> getAllSubjects(List<Student> list) {
		List<String> subjects = list.stream()
				.map(Student::getSubjects)
				.reduce(new ArrayList<String>() ,(list1, list2) -> {
					List<String> l = new ArrayList<>(list1); // No entiendo esta línea, ni la siguiente-----------------------------------------
					l.addAll(list2);
					return l;
				});
				
		return new TreeSet<>(subjects); // TreeSet orders by default alphabetically
	}
    //Exercise 10.1
    public static List<String> getOldestNames(List<Student> list){
        List<String> l = list.stream()
            .sorted((p1,p2) -> Integer.compare(p2.getAge(), p1.getAge()))
            .map(p -> p.getName())
            .limit(3).collect(Collectors.toList());
        
        return l;
    }
    
    public static List<Student> filterStudents(List<Student> srcList, Predicate<Student> predicate){
        List<Student> l = new ArrayList<>();
        for(Student s : srcList){
            if(predicate.test(s))
                l.add(s);
        }
        return l;
    }
    public static void mostrarResultados(List<Student> listStudents, List<Student> older20, List<Student> programmers, List<Student> peters){
        System.out.println("List of Students:");
        verListaStudent(listStudents);
        System.out.println();
        
        System.out.println("Estudiantes mayores de 20 años:");
        verListaStudent(older20);
        System.out.println();        
        System.out.println("Estudiantes matriculados en programacion:");
        verListaStudent(programmers);
        System.out.println();
        System.out.println("Estudiantes cuyo nombre contiene \"Peter\"");
        verListaStudent(peters);
        System.out.println();
    }
}