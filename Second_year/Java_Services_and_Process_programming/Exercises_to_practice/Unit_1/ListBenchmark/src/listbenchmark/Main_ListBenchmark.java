/*
We are going to test in which cases is better to use
an ArrayList, or a LinkedList
 */
package listbenchmark;

import java.time.Duration;
import java.time.Instant;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.LinkedList;
import java.util.List;
import java.util.Random;

/**
 * Exercise 4
 * @author Ignacio
 */
public class Main_ListBenchmark {
    
    public static void imprimirTamanyo(List l){
        System.out.println(l.size());
    }
    /**
     * Run the test and show the results
     */
    public static void runTests(){
        
        List<Double> a = new ArrayList<>();
        List<Double> l = new LinkedList<>();
        
        System.out.println("Test 1: Add 100.000 (double) random items always at position 0");
        System.out.println("ArryaList: " + Test1(a) + " ms");
        System.out.println("LinkedList: " + Test1(l) + " ms");
        System.out.println();
        
        System.out.println("Test 2: Delete the first 50.000 items (always delete the first one)");
        System.out.println("ArrayList: " + Test2(a) + " ms");
        System.out.println("LinkedList: " + Test2(l) + " ms");
        System.out.println();
        
        System.out.println("Test 3: Add 50.000 random items in random positions");
        System.out.println("ArrayList: " + Test3(a) + " ms");
        System.out.println("LinkedList: " + Test3(l) + " ms");
        System.out.println();
        
        System.out.println("Test 4: Delete 50.000 items from random positions");
        System.out.println("ArrayList: " + Test4(a) + " ms");
        System.out.println("LinkedList: " + Test4(l) + " ms");
        System.out.println();
        
        System.out.println("Test 5: Delete items that are in even positions (divisible by 2) using an Iterator");
        System.out.println("ArrayList: " + Test5(a) + " ms");
        System.out.println("LinkedList: " + Test5(l) + " ms");
        System.out.println();
    }
    /**
     * Su función es mostrar una versión de los test con información adicional
     * para porder comprobar que las operaciones deseadas se están llevando
     * a cabo de forma correcta
     */
    public static void runTestsComprobacion(){
        
        List<Double> a = new ArrayList<>();
        List<Double> l = new LinkedList<>();
        
        // Test 1
        imprimirTamanyo(a);
        System.out.println("Test1, ArryaList: " + Test1(a));
        imprimirTamanyo(a);
        imprimirTamanyo(l);
        System.out.println("Test1, LinkedList: " + Test1(l));
        imprimirTamanyo(l);
        
        // Test 2
        imprimirTamanyo(a);
        System.out.println("Test 2, ArrayList: " + Test2(a));
        imprimirTamanyo(a);
        imprimirTamanyo(l);
        System.out.println("Test 2, LinkedList: " + Test2(l));
        imprimirTamanyo(l);
        
        // Test 3
        imprimirTamanyo(a);
        System.out.println("Test3, ArrayList: " + Test3(a));
        imprimirTamanyo(a);
        imprimirTamanyo(l);
        System.out.println("Test3, LinkedList: " + Test3(l));
        imprimirTamanyo(l);
        
        //Test 4
        imprimirTamanyo(a);
        System.out.println("Test4, ArrayList: " + Test4(a));
        imprimirTamanyo(a);
        imprimirTamanyo(l);
        System.out.println("Test4, LinkedList: " + Test4(l));
        imprimirTamanyo(l);
        
        // Test 5
        imprimirTamanyo(a);
        ver20PrimerosElementos(a);
        System.out.println("Test5, ArrayList: " + Test5(a));
        ver20PrimerosElementos(a);
        imprimirTamanyo(a);
        imprimirTamanyo(l);
        //ver20PrimerosElementos(l); // No tiene sentido en una LinkedList
        System.out.println("Test5, LinkedList: " + Test5(l));
        //ver20PrimerosElementos(a); // No tiene sentido en una LinkedList
        imprimirTamanyo(l);
        System.out.println();
    }
    /**
     * Test 1: Add 100.000 (double) random items always at position 0.
     * @param l List implemented as ArrayList or LinkedList
     * @return long with de duration of de procedure in milliseconds
     */
    public static long Test1(List l){
        Random r = new Random();
        Instant start;
        Instant end;
        Duration dur;
        
        start = Instant.now();
        for (int i = 0; i < 100000; i++) {
            l.add(0, r.nextDouble());
        }
        end = Instant.now();
        dur = Duration.between(start, end);
        return dur.toMillis();
    }
    /**
     * Test 2: Delete the first 50.000 items (always delete the first one).
     * @param l List implemented as ArrayList or LinkedList
     * @return long with de duration of de procedure in milliseconds
     */
    public static long Test2(List l){
        Instant start;
        Instant end;
        Duration dur;
        
        start = Instant.now();
        for (int i = 0; i < 50000; i++) {
            l.remove(0);
        }
        end = Instant.now();
        dur = Duration.between(start, end);        
        return dur.toMillis();
    }
    /**
     * Test 3: Add 50.000 random items in random positions.
     * @param l List implemented as ArrayList or LinkedList
     * @return long with de duration of de procedure in milliseconds
     */
    public static long Test3(List l){
        Random r = new Random();
        Instant start;
        Instant end;
        Duration dur;
        
        start = Instant.now();
        for (int i = 0; i < 50000; i++) {
            l.add(r.nextInt(50000), r.nextDouble());
        }
        end = Instant.now();
        dur = Duration.between(start, end);
        return dur.toMillis();
    }
    /**
     * Test 4: Delete 50.000 items from random positions.
     * @param l List implemented as ArrayList or LinkedList
     * @return long with de duration of de procedure in milliseconds
     */
    public static long Test4(List l){
        Random r = new Random();
        Instant start;
        Instant end;
        Duration dur;
        
        start = Instant.now();
        for (int i = 0; i < 50000; i++) {
            l.remove(r.nextInt(50000));
        }
        end = Instant.now();
        dur = Duration.between(start, end);
        return dur.toMillis();
        
    }
    /**
     * Test 5: Delete items that are in even positions (divisible by 2) using an Iterator.
     * @param l List implemented as ArrayList or LinkedList
     * @return long with de duration of de procedure in milliseconds
     */
    public static long Test5(List l){
        Iterator i = l.iterator();
        Instant start;
        Instant end;
        Duration dur;
        int contador = 0;
        
        start = Instant.now();
        while(i.hasNext()){
            i.next();
            if(++contador % 2 == 0){
                i.remove();
            }
        }
        end = Instant.now();
        dur = Duration.between(start, end);
        return dur.toMillis();
    }
    public static void ver20PrimerosElementos(List l){
        if(l.size() >= 20){
            for (int i = 0; i < 20; i++) {
                System.out.println("Posicion " + i + ": " + l.get(i));
            }
        }
    }
    
    public static void main(String[] args) {
        
        runTests();
        //runTestsComprobacion();
    
    }
    
}
