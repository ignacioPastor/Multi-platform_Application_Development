
package p5;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.PrintStream;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 * Práctica P5 - Entornos de Desarrollo - 1ºDAM Semipresencial
 * @author Ignacio Pastor Padilla
 */
public class Sort {
    
    List<Integer> myArrayAleatory;
    List<Integer> myArrayOrdered;
    List<Integer> myArrayOrderedInvested;
    List<Integer> myArrayEqual;
    List<Integer> myArrayAleatoryCopy;
    List<Integer> myArrayOrderedCopy;
    List<Integer> myArrayOrderedInvestedCopy;
    List<Integer> myArrayEqualCopy;
    
    int contadorSwapExterno;
    int contadorComparacionesExterno;
    int contadorLlamadasExterno;
    
    /**
     * Muestra los arrays por pantalla. Utilizada durante el desarrollo de la 
     * práctica, pero no en el resultado final
     * @param list 
     */
    public void VerArrays(List<Integer> list){
        for (int i = 0; i < tamanyo; i++) {
            System.out.print(list.get(i) + " ");
        }
        System.out.println();
    }
    int tamanyo;
    
    // Para imprimir los resultados en un fichero
    PrintStream ficheroS;
    
    public Sort()
    {
        myArrayAleatory = new ArrayList<Integer>();
        myArrayOrdered = new ArrayList<Integer>();
        myArrayOrderedInvested = new ArrayList<Integer>();
        myArrayEqual = new ArrayList<Integer>();
        myArrayAleatoryCopy = new ArrayList<Integer>();
        myArrayOrderedCopy = new ArrayList<Integer>();
        myArrayOrderedInvestedCopy = new ArrayList<Integer>();
        myArrayEqualCopy = new ArrayList<Integer>();
        
        tamanyo = 1000;
       
        //Implementación del stream para imprimir en fichero
      try {
            this.ficheroS = new PrintStream(new File("ficheroSort.txt"));
        } catch (FileNotFoundException ex) {
            Logger.getLogger(Sort.class.getName()).log(Level.SEVERE, null, ex);
        }  
        
    }
    long before;
    float time;
    final int divMill = 1000000;
    
    /**
     * Asigna los valores iniciales a las listas. 
     * Llamando a esta función antes de cada test nos aseguraremos de que 
     * siempre estaremos trabajando con listas iguales, para que los resultados
     * sean comparables y las listas no se vayan alteranddo
     */
    private void InicializeArrays()
    {
        myArrayAleatory.clear();
        myArrayOrdered.clear();
        myArrayEqual.clear();
        myArrayOrderedInvested.clear();
        myArrayAleatoryCopy.clear();
        myArrayOrderedCopy.clear();
        myArrayEqualCopy.clear();
        myArrayOrderedInvestedCopy.clear();
        
        for (int i = 0; i < tamanyo; i++) {
            myArrayAleatory.add((int) (Math.random() * 10 + 0));
            myArrayOrdered.add(i);
            myArrayEqual.add(4);
            myArrayOrderedInvested.add(999-i);
            myArrayAleatoryCopy.add(myArrayAleatory.get(i));
            myArrayOrderedCopy.add(i);
            myArrayEqualCopy.add(4);
            myArrayOrderedInvestedCopy.add(999-i);
        }
    }
    /**
     * Método principal que irá gestionando esta clase llamando a cada apartado
     */
    public void RunTimes(){
        
        InicializeArrays();
        ficheroS.println("P5, Parte 2. Ignacio Pastor Padilla");
        ficheroS.println("");
        System.out.println("P5, Parte 2. Ignacio Pastor Padilla");
        System.out.println("");
        Bubble();
        Selection();
        Insertion();
        Quick();
        Merge();
        Binary();
        Secuencial();
    }
    /**
     * Gestiona los test y los procesos entorno a la ordenación con burbuja
     * Ponemos los arrays en valores iniciales.
     * Tomamos las medidas de velocidad a la vez que las mostramos por pantalla.
     * Hacemos e imprimimos por pantalla las comprobaciones necesarias para asegurarnos de que la ordenación se ha realizado correctamente
     * Repetimos el mismo proceso para reflejar los datos en el fichero
     * Finalmente contamos y reflejamos en fichero y pantalla el número de instrucciones que se han llevado a cabo
     */
    private void Bubble(){
        InicializeArrays();
        System.out.println("Test 01_1. BubbleSort con lista aleatoria: " + BubbleSort(myArrayAleatory));
        PrintRunTests(RunTests(myArrayAleatory, myArrayAleatoryCopy));
        ficheroS.println("Test 01_1. BubbleSort con lista aleatoria: " + BubbleSort(myArrayAleatory));
        FichPrintRunTests(RunTests(myArrayAleatory, myArrayAleatoryCopy));
        InicializeArrays();
        NumeroInstruccionesBubbleSort(myArrayAleatory);
        
        System.out.println("Test 01_2. BubbleSort con lista ordenada: " + BubbleSort(myArrayOrdered));
        PrintRunTests(RunTests(myArrayOrdered, myArrayOrderedCopy)); 
        ficheroS.println("Test 01_2. BubbleSort con lista ordenada: " + BubbleSort(myArrayOrdered));
        FichPrintRunTests(RunTests(myArrayOrdered, myArrayOrderedCopy));
        InicializeArrays();
        NumeroInstruccionesBubbleSort(myArrayOrdered);
        
        System.out.println("Test 01_3. BubbleSort con lista de todos inversamente ordenada: " + BubbleSort(myArrayOrderedInvested));
        PrintRunTests(RunTests(myArrayOrderedInvested, myArrayOrderedInvestedCopy));
        ficheroS.println("Test 01_3. BubbleSort con lista de todos inversamente ordenada: " + BubbleSort(myArrayOrderedInvested));
        FichPrintRunTests(RunTests(myArrayOrderedInvested, myArrayOrderedInvestedCopy));
        InicializeArrays();
        NumeroInstruccionesBubbleSort(myArrayOrderedInvested);
        
        System.out.println("Test 01_4. BubbleSort con lista de todos los elementos iguales: " + BubbleSort(myArrayEqual));
        PrintRunTests(RunTests(myArrayEqual, myArrayEqualCopy));
        ficheroS.println("Test 01_4. BubbleSort con lista de todos los elementos iguales: " + BubbleSort(myArrayEqual));
        FichPrintRunTests(RunTests(myArrayEqual, myArrayEqualCopy));
        InicializeArrays();
        NumeroInstruccionesBubbleSort(myArrayEqual);
        
        System.out.println("");
    }
    
    /**
     * Gestiona los test de ordenación por SelectionSort
     */
    private void Selection()
    {
        InicializeArrays();
        System.out.println("Test 02_1. SelectionSort con lista aleatoria: " + SelectionSort(myArrayAleatory));
        PrintRunTests(RunTests(myArrayAleatory, myArrayAleatoryCopy));
        ficheroS.println("");
        ficheroS.println("Test 02_1. SelectionSort con lista aleatoria: " + SelectionSort(myArrayAleatory));
        FichPrintRunTests(RunTests(myArrayAleatory, myArrayAleatoryCopy));
        InicializeArrays();
        NumeroInstruccionesSelectionSort(myArrayAleatory);
        
        System.out.println("Test 02_2. SelectionSort con lista ordenada: " + SelectionSort(myArrayOrdered)); 
        PrintRunTests(RunTests(myArrayOrdered, myArrayOrderedCopy));  
        ficheroS.println("Test 02_2. SelectionSort con lista ordenada: " + SelectionSort(myArrayOrdered));
        FichPrintRunTests(RunTests(myArrayOrdered, myArrayOrderedCopy)); 
        InicializeArrays();
        NumeroInstruccionesSelectionSort(myArrayOrdered);
        
        System.out.println("Test 02_3. SelectionSort con lista inversamente ordenada: " + SelectionSort(myArrayOrderedInvested));
        PrintRunTests(RunTests(myArrayOrderedInvested, myArrayOrderedInvestedCopy));
        ficheroS.println("Test 02_3. SelectionSort con lista inversamente ordenada: " + SelectionSort(myArrayOrderedInvested));
        FichPrintRunTests(RunTests(myArrayOrderedInvested, myArrayOrderedInvestedCopy));
        InicializeArrays();
        NumeroInstruccionesSelectionSort(myArrayOrderedInvested);
        
        System.out.println("Test 02_4. SelectionSort con lista de todos los elementos iguales: " + SelectionSort(myArrayEqual));
        PrintRunTests(RunTests(myArrayEqual, myArrayEqualCopy));
        ficheroS.println("Test 02_4. SelectionSort con lista de todos los elementos iguales: " + SelectionSort(myArrayEqual));
        FichPrintRunTests(RunTests(myArrayEqual, myArrayEqualCopy));
        InicializeArrays();
        NumeroInstruccionesSelectionSort(myArrayEqual);  
        
        System.out.println("");
    }
    /**
     * Gestiona los test de ordenación por InsertionSort
     */
    private void Insertion(){
        InicializeArrays(); 
        System.out.println("Test 03_1. InsertionSort con lista aleatoria: " + InsertionSort(myArrayAleatory));
        PrintRunTests(RunTests(myArrayAleatory, myArrayAleatoryCopy));
        ficheroS.println("");
        ficheroS.println("Test 03_1. InsertionSort con lista aleatoria: " + InsertionSort(myArrayAleatory));
        FichPrintRunTests(RunTests(myArrayAleatory, myArrayAleatoryCopy));
        InicializeArrays();
        NumeroInstruccionesInsertionSort(myArrayAleatory);  
        
        System.out.println("Test 03_2. InsertionSort con lista ordenada: " + InsertionSort(myArrayOrdered));
        PrintRunTests(RunTests(myArrayOrdered, myArrayOrderedCopy));
        ficheroS.println("Test 03_2. InsertionSort con lista ordenada: " + InsertionSort(myArrayOrdered));
        FichPrintRunTests(RunTests(myArrayOrdered, myArrayOrderedCopy));
        InicializeArrays();
        NumeroInstruccionesInsertionSort(myArrayOrdered);  
        
        System.out.println("Test 03_3. InsertionSort con lista inversamente ordenada: " + InsertionSort(myArrayOrderedInvested));
        PrintRunTests(RunTests(myArrayOrderedInvested, myArrayOrderedInvestedCopy));
        ficheroS.println("Test 03_3. InsertionSort con lista inversamente ordenada: " + InsertionSort(myArrayOrderedInvested));
        FichPrintRunTests(RunTests(myArrayOrderedInvested, myArrayOrderedInvestedCopy));
        InicializeArrays();
        NumeroInstruccionesInsertionSort(myArrayOrderedInvested);  
        
        System.out.println("Test 03_4. InsertionSort con lista de todos los elementos iguales: " + InsertionSort(myArrayEqual));
        PrintRunTests(RunTests(myArrayEqual, myArrayEqualCopy));
        ficheroS.println("Test 03_4. InsertionSort con lista de todos los elementos iguales: " + InsertionSort(myArrayEqual));
        FichPrintRunTests(RunTests(myArrayEqual, myArrayEqualCopy));
        InicializeArrays();
        NumeroInstruccionesInsertionSort(myArrayEqual);
        
        System.out.println("");
    }
    
    /**
     * Gestiona los test de ordenacion por QuickSort
     */
    private void Quick(){
        InicializeArrays(); 
        System.out.println("Test 04_1. QuickSort con lista aleatoria: " + quickSort(myArrayAleatory, 0, tamanyo - 1));
        PrintRunTests(RunTests(myArrayAleatory, myArrayAleatoryCopy));
        ficheroS.println("");
        ficheroS.println("Test 04_1. QuickSort con lista aleatoria: " + quickSort(myArrayAleatory, 0, tamanyo - 1));
        FichPrintRunTests(RunTests(myArrayAleatory, myArrayAleatoryCopy));
        InicializeArrays();
        NumeroInstruccionesQuickSort(myArrayAleatory, 0, tamanyo - 1);
        
        System.out.println("Test 04_2. QuickSort con lista ordenada: " + quickSort(myArrayOrdered, 0, tamanyo - 1));
        PrintRunTests(RunTests(myArrayOrdered, myArrayOrderedCopy));
        ficheroS.println("Test 04_2. QuickSort con lista ordenada: " + quickSort(myArrayOrdered, 0, tamanyo - 1));     
        FichPrintRunTests(RunTests(myArrayOrdered, myArrayOrderedCopy));
        InicializeArrays();
        NumeroInstruccionesQuickSort(myArrayOrdered, 0, tamanyo - 1);
        
        System.out.println("Test 04_3. QuickSort con lista inversamente ordenada: " + quickSort(myArrayOrderedInvested, 0, tamanyo - 1));
        PrintRunTests(RunTests(myArrayOrderedInvested, myArrayOrderedInvestedCopy));
        ficheroS.println("Test 04_3. QuickSort con lista inversamente ordenada: " + quickSort(myArrayOrderedInvested, 0, tamanyo - 1));
        FichPrintRunTests(RunTests(myArrayOrderedInvested, myArrayOrderedInvestedCopy));
        InicializeArrays();
        NumeroInstruccionesQuickSort(myArrayOrderedInvested, 0, tamanyo - 1);
        
        System.out.println("Test 04_4. QuickSort con lista de todos los elementos iguales: " + quickSort(myArrayEqual, 0, tamanyo - 1));
        PrintRunTests(RunTests(myArrayEqual, myArrayEqualCopy));
        ficheroS.println("Test 04_4. QuickSort con lista de todos los elementos iguales: " + quickSort(myArrayEqual, 0, tamanyo - 1));
        FichPrintRunTests(RunTests(myArrayEqual, myArrayEqualCopy));
        InicializeArrays();
        NumeroInstruccionesQuickSort(myArrayEqual, 0, tamanyo - 1);
        
        System.out.println("");
    }
    
    /**
     * Gestiona los test de ordenacion por MergeSort
     */
    private void Merge(){
        
        InicializeArrays(); 
        System.out.println("Test 05_1. MergeSort con lista aleatoria: " + mergeSort2(myArrayAleatory));
        PrintRunTests(RunTests(myArrayAleatory, myArrayAleatoryCopy));
        ficheroS.println("");
        ficheroS.println("Test 05_1. MergeSort con lista aleatoria: " + mergeSort2(myArrayAleatory));
        FichPrintRunTests(RunTests(myArrayAleatory, myArrayAleatoryCopy));
        InicializeArrays();
        NumeroInstruccionesMergeSort(myArrayAleatory);
        
        System.out.println("Test 05_2. MergeSort con lista ordenada: " + mergeSort2(myArrayOrdered));
        PrintRunTests(RunTests(myArrayOrdered, myArrayOrderedCopy));   
        ficheroS.println("Test 05_2. MergeSort con lista ordenada: " + mergeSort2(myArrayOrdered));
        FichPrintRunTests(RunTests(myArrayOrdered, myArrayOrderedCopy));
        InicializeArrays();
        NumeroInstruccionesMergeSort(myArrayAleatory);
        
        System.out.println("Test 05_3. MergeSort con lista inversamente ordenada: " + mergeSort2(myArrayOrderedInvested));
        PrintRunTests(RunTests(myArrayOrderedInvested, myArrayOrderedInvestedCopy));
        ficheroS.println("Test 05_3. MergeSort con lista inversamente ordenada: " + mergeSort2(myArrayOrderedInvested));
        FichPrintRunTests(RunTests(myArrayOrderedInvested, myArrayOrderedInvestedCopy));
        InicializeArrays();
        NumeroInstruccionesMergeSort(myArrayAleatory);
        
        System.out.println("Test 05_4. MergeSort con lista de todos los elementos iguales: " + mergeSort2(myArrayEqual));
        PrintRunTests(RunTests(myArrayEqual, myArrayEqualCopy));
        ficheroS.println("Test 05_4. MergeSort con lista de todos los elementos iguales: " + mergeSort2(myArrayEqual));
        FichPrintRunTests(RunTests(myArrayEqual, myArrayEqualCopy));
        InicializeArrays();
        NumeroInstruccionesMergeSort(myArrayAleatory);
        
        System.out.println("");
    }
    
    /**
     * Gestiona los test en la búsqueda  binaria
     */
    public void Binary(){
        InicializeArrays(); 
        System.out.println("Test 06_1. BinarySearch con lista aleatoria: " + BinarySearch(myArrayAleatory, tamanyo - 1));
        ficheroS.println("");
        ficheroS.println("Test 06_1. BinarySearch con lista aleatoria: " + BinarySearch(myArrayAleatory, tamanyo - 1));
        NumeroInstruccionesBinarySearch(myArrayAleatory, tamanyo - 1);
        
        System.out.println("Test 06_2. BinarySearch con lista ordenada: " + BinarySearch(myArrayOrdered, tamanyo - 1));        
        ficheroS.println("Test 06_2. BinarySearch con lista ordenada: " + BinarySearch(myArrayOrdered, tamanyo - 1));        
        NumeroInstruccionesBinarySearch(myArrayOrdered, tamanyo - 1);
        
        System.out.println("Test 06_3. BinarySearch con lista inversamente: " + BinarySearch(myArrayOrderedInvested, tamanyo - 1));
        ficheroS.println("Test 06_3. BinarySearch con lista inversamente: " + BinarySearch(myArrayOrderedInvested, tamanyo - 1));
        NumeroInstruccionesBinarySearch(myArrayOrderedInvested, tamanyo - 1);
        
        System.out.println("Test 06_4. BinarySearch con lista de todos los elementos iguales: " + BinarySearch(myArrayEqual, tamanyo - 1));
        ficheroS.println("Test 06_4. BinarySearch con lista de todos los elementos iguales: " + BinarySearch(myArrayEqual, tamanyo - 1));
        NumeroInstruccionesBinarySearch(myArrayEqual, tamanyo - 1);
    }
    
    /**
     * Gestiona los test en la busqueda Secuencial
     */
    private void Secuencial(){
        InicializeArrays(); 
        System.out.println("Test 07_1. SecuencialSearch con lista aleatoria: " + SecuencialSearch(myArrayAleatory, tamanyo - 1));
        ficheroS.println("");
        ficheroS.println("Test 07_1. SecuencialSearch con lista aleatoria: " + SecuencialSearch(myArrayAleatory, tamanyo - 1));
        NumeroInstruccionesSecuencialSearch(myArrayAleatory, tamanyo - 1);
        
        System.out.println("Test 07_2. SecuencialSearch con lista ordenada: " + SecuencialSearch(myArrayOrdered, tamanyo - 1));        
        ficheroS.println("Test 07_2. SecuencialSearch con lista ordenada: " + SecuencialSearch(myArrayOrdered, tamanyo - 1));
        NumeroInstruccionesSecuencialSearch(myArrayOrdered, tamanyo - 1);
        
        System.out.println("Test 07_3. SecuencialSearch con lista inversamente: " + SecuencialSearch(myArrayOrderedInvested, tamanyo - 1));
        ficheroS.println("Test 07_3. SecuencialSearch con lista inversamente: " + SecuencialSearch(myArrayOrderedInvested, tamanyo - 1));
        NumeroInstruccionesSecuencialSearch(myArrayOrderedInvested, tamanyo - 1);
        
        System.out.println("Test 07_4. SecuencialSearch con lista de todos los elementos iguales: " + SecuencialSearch(myArrayEqual, tamanyo - 1));
        ficheroS.println("Test 07_4. SecuencialSearch con lista de todos los elementos iguales: " + SecuencialSearch(myArrayEqual, tamanyo - 1));
        NumeroInstruccionesSecuencialSearch(myArrayEqual, tamanyo - 1);
        
        System.out.println("");
    }
    
    /**
     * Comprueba que ningún elemento tiene otro mayor a la derecha. Llama también a otra función para comprobar que todos los valores siguen existiendo
     * @param list lista ordenada a comprobar
     * @param listCopy lista original, se la pasaremos a la función que comprobará que todos los elementos siguen existiendo
     * @return false si algún elemento tiene otro mayor a su derecha. True si todos los valores están bien ordenados y siguen existiendo
     */
    private boolean RunTests(List<Integer> list, List<Integer> listCopy){
        
        for (int i = 0; i < list.size() - 1; i++) {
            if(list.get(i) > list.get(i + 1)){
                return false;
            }
        }
        
        return CheckElements(list, listCopy);
    }/**
     * Comprueba que todos los elementos de la lista ordenada siguen existiendo
     * @param list lista ordenada
     * @param listCopy lista orignial no modificada
     * @return  true si todos los elementos siguen existiendo
     */
    private boolean CheckElements(List<Integer> list, List<Integer> listCopy){
        for (int i = 0; i < list.size(); i++) {
            if(listCopy.indexOf(list.get(i)) == -1){
                System.out.println("devuelve falso el CheckElements");
                System.out.println("en i vale " + i);
                return false;
            }
        }
        return true;
    }
    /**
     * Imprime por pantalla si la ordenación se ha efectuado correctamente
     * @param sort booleano que indique si el mensaje debe ser de error o de todo correcto
     */
    private void PrintRunTests(boolean sort){
        if(sort == true)
            System.out.println("Se ha ordenado correctamente");
        else
            System.out.println("Ha habido un error en la ordenación");
    }
    /**
     * Imprime en el fichero si la ordenacion se ha efectuado correctamente
     * @param sort  booleano para saber si el mensaje debe ser de error o de todo correcto
     */
    private void FichPrintRunTests(boolean sort){
        if(sort == true)
            ficheroS.println("Se ha ordenado correctamente");
        else
            ficheroS.println("Ha habido un error en la ordenación");
    }
    
    /**
     * Ordena la lista por el método burbuja
     * @param list lista a ordenar
     * @return float con las mediciones en milisegundos del tiempo de ejecución
     */
    private float BubbleSort(List<Integer> list){
        before = System.nanoTime(); 
        
        for (int i = 0; i < (list.size() - 1); i++) {
            for (int j = i+1; j < list.size(); j++) {
                if (list.get(i) > list.get(j)){
                    int temp = list.get(i);
                    list.set(i, list.get(j));
                    list.set(j, temp);
                }
            }
        }
        time = (float)(System.nanoTime() - before) / divMill;
        return time;
    }
    /**
     * Función que repite el proceso de ordenación, esta vez midiendo el número de instrucciones que se llevan a cabo
     * La duplicación de código tiene por objetivo no influir en las medidas de tiempo
     * Se imprime por pantalla y en fichero el número de mediciones
     * @param list lista a ordenar
     */
    private void NumeroInstruccionesBubbleSort(List<Integer> list){
        int contadorSwap = 0;
        int contadorComparaciones = 0;
        for (int i = 0; i < (list.size() - 1); i++) {
            for (int j = i+1; j < list.size(); j++) {
                contadorComparaciones++;
                if (list.get(i) > list.get(j)){
                    int temp = list.get(i);
                    contadorSwap++;
                    list.set(i, list.get(j));
                    contadorSwap++;
                    list.set(j, temp);
                    contadorSwap++;
                }
            }
        }
        System.out.println("Se han contado " + contadorSwap + " Swaps y " + contadorComparaciones + " comparaciones");
        ficheroS.println("Se han contado " + contadorSwap + " Swaps y " + contadorComparaciones + " comparaciones");
    }
    /**
     * Funcion de ordenacion por el metodo SelectionSort
     * @param list lista a ordenar
     * @return  float con las mediciones de tiempo de ejecucion en milisegundo
     */
    private float SelectionSort(List<Integer> list){
        before = System.nanoTime(); 
        
        for (int i = 0; i < list.size() - 1; i++) {
            int menor = i;
            for (int j = i + 1; j < list.size(); j++) 
                if(list.get(j) < list.get(menor)){
                    menor = j;
                }
            if(i != menor){
                int tmp = list.get(i);
                list.set(i, list.get(menor));
                list.set(menor, tmp);
            }
            
        }
        time = (float)(System.nanoTime() - before) / divMill;
        return time;
    }
    /**
     * Funcion que cuenta el numero de instrucciones que se llevan a cabo en la ordenacion
     * La duplicidad de procesos tiene por objetivo no afectar a las mediciones
     * Imprime por pantalla y en fichero los resultados
     * @param list lista a ordenar
     */
    private void NumeroInstruccionesSelectionSort(List<Integer> list){
        int contadorSwap = 0;
        int contadorComparaciones = 0;
        for (int i = 0; i < list.size() - 1; i++) {
            int menor = i;
            for (int j = i + 1; j < list.size(); j++){ 
                contadorComparaciones++;
                if(list.get(j) < list.get(menor)){
                    menor = j;
                    contadorSwap++;
                }
            }
            if(i != menor){
                int tmp = list.get(i);
                contadorSwap++;
                list.set(i, list.get(menor));
                contadorSwap++;
                list.set(menor, tmp);
                contadorSwap++;
            }
        }
        System.out.println("Se han contado " + contadorSwap + " Swaps y " + contadorComparaciones + " comparaciones");
        ficheroS.println("Se han contado " + contadorSwap + " Swaps y " + contadorComparaciones + " comparaciones");
    }
    /**
     * Función que ordena una lista por el metodo de IsertionSort
     * @param list lista a ordenar
     * @return float con las mediciones del tiempo de ordenacion en milisegundos
     */
    private float InsertionSort(List<Integer> list){
        before = System.nanoTime(); 
        for (int i = 1; i < list.size(); i++) {
            int tmp = list.get(i);
            int j;
            for (j = i - 1; j >= 0 && tmp < list.get(j); j--) {
                list.set(j + 1, list.get(j));
            }
            list.set(j + 1, tmp);
        }
        time = (float)(System.nanoTime() - before) / divMill;
        return time;
    }
    /**
     * Funcion que cuenta el numero de instrucciones llevadas a cabo mediante el metodo de IsertionSort
     * La duplicidad tiene por objetivo no afectar a las mediciones de tiempo de ejecucion
     * Imprime por pantalla y en fichero los resultados
     * @param list lista a ordenar
     */
    private void NumeroInstruccionesInsertionSort(List<Integer> list){
        int contadorSwap = 0;
        int contadorComparaciones = 0;
        for (int i = 1; i < list.size(); i++) {
            int tmp = list.get(i);
            contadorSwap++;
            int j;
            for (j = i - 1; j >= 0 && tmp < list.get(j); j--) {
                contadorComparaciones++;
                list.set(j + 1, list.get(j));
                contadorSwap++;
            }
            list.set(j + 1, tmp);
            contadorSwap++;
        }
        System.out.println("Se han contado " + contadorSwap + " Swaps y " + contadorComparaciones + " comparaciones");
        ficheroS.println("Se han contado " + contadorSwap + " Swaps y " + contadorComparaciones + " comparaciones");
    }
    /**
     * Funcion de ordenación de una lista por el metodo de QuickSort
     * @param list lista a ordenar
     * @param low indice inferior de la lista
     * @param high indice superior de la lista
     * @return float con el tiempo de ejecucion en milisegundos
     */    
    private float quickSort(List<Integer> list, int low, int high){
        before = System.nanoTime();
        int i = low;
        //int j = high - 1;
        int j = high;
        int middle = low + (high - low) / 2;
        int pivot = list.get(middle);
        
        while (i <= j){
            while (list.get(i) < pivot)
                i++;
            while (list.get(j) > pivot)
                j--;
            
            if (i <= j){
                int temp = list.get(i);
                list.set(i, list.get(j));
                list.set(j, temp);
                i++;
                j--;
            }
        }
        
        if (low < j)
            quickSort(list, low, j);
        if (high > i)
            quickSort(list, i, high);
        time = (float)(System.nanoTime() - before)/divMill;
        return time;
    }
    /**
     * Funcion que cuenta el número de instrucciones, comparaciones y llamadas a funcion (recursivas) que se llevan a cabo durante la ordenacion
     * La duplicidad tiene por objeto no afectar a las mediciones de tiempo de ejecucion
     * Esta funcion alberga la llamada a la QuickSort, que por su recursividad, se ha decidido resolver de esta forma el contado de instrucciones
     * Se utilizan varables declaradas en la clase para que puedan ser utilizadas en la función sin que se inicialicen a 0 cada vez
     * @param list lista a ordenar
     * @param low indice inferior de la lista
     * @param high indice superior de la lista
     */
    private void NumeroInstruccionesQuickSort(List<Integer> list, int low, int high){
        contadorSwapExterno = 0;
        contadorComparacionesExterno = 0;
        contadorLlamadasExterno = 0;
        
        NumeroInstruccionesQuickSortAuxiliar( list, low, high);
        
        System.out.println("Se han contado " + contadorSwapExterno + " Swaps, " + contadorComparacionesExterno + " comparaciones y " + contadorLlamadasExterno + " llamadas a función");
        ficheroS.println("Se han contado " + contadorSwapExterno + " Swaps, " + contadorComparacionesExterno + " comparaciones y " + contadorLlamadasExterno + " llamadas a función");
    }
    /**
     * Función de ordenación por el método QuickSort. Utilizada para medir el numero de procesos
     * @param list lista a ordenar
     * @param low indice inferior de la funcion
     * @param high indice superior de la funcion
     */
    private void NumeroInstruccionesQuickSortAuxiliar(List<Integer> list, int low, int high){
        
        int middle = low + (high - low) / 2;
        int pivot = list.get(middle);
        
        int i = low;
        int j = high;
        while (i <= j){
            contadorComparacionesExterno++;
            while (list.get(i) < pivot){
                contadorComparacionesExterno++;
                i++;
            }
            while (list.get(j) > pivot){
                contadorComparacionesExterno++;
                j--;
            }
            contadorComparacionesExterno++;
            if (i <= j){
                int temp = list.get(i);
                contadorSwapExterno++;
                list.set(i, list.get(j));
                contadorSwapExterno++;
                list.set(j, temp);
                contadorSwapExterno++;
                i++;
                j--;
            }
        }
        contadorComparacionesExterno++;
        if (low < j){
            contadorLlamadasExterno++;
            NumeroInstruccionesQuickSortAuxiliar(list, low, j);
        }
        contadorComparacionesExterno++;
        if (high > i){
            contadorLlamadasExterno++;
            NumeroInstruccionesQuickSortAuxiliar(list, i, high);
        }
    }
    /**
     * Funcion que alberga la llamada a la funcion MergeSort. Se utiliza para porder medir el tiempo de ejecucion en una funcion recursiva
     * @param list lista a ordenar
     * @return float con el tiempo de ejecucion de la ordenacion en milisegundos
     */
    public float mergeSort2(List<Integer> list) {
        before = System.nanoTime();
        mergeSort(list);
        time = (float)(System.nanoTime() - before)/divMill;
        return time;
        
    }
    /**
     * Funcion de ordenacion por el metodo MergeSort. Parte principal
     * @param list lista a ordenar. Será dividida en dos partes mientras sea mayor de 1
     */
    public void mergeSort(List<Integer> list) {
        //System.out.println("entra en mergeSort");
        //System.out.println(list.size());
        if (list.size() > 1) {
            List<Integer> left = leftHalf(list);
            List<Integer> right = rightHalf(list);
            
            mergeSort(left);
            mergeSort(right);
            
            merge(list, left, right);
        }
    }
    /**
     * Funcion que recoge la mitad de la izquierda de la lista
     * @param list mitad izqiuerda de la lista
     * @return mitad de la lista recibida
     */
    public List<Integer> leftHalf(List<Integer> list) {
        int size1 = list.size() / 2;
        List<Integer> left = new ArrayList<Integer>();
        for (int i = 0; i < size1; i++) {
            left.add(i, list.get(i));
        }
        return left;
    }
    /**
     * Funcion que recibe la mitad derecha de la lista
     * @param list mitad izquierda de la lista
     * @return la mitad de la lista recibida
     */
    public List<Integer> rightHalf(List<Integer> list) {
        int size1 = list.size() / 2;
        int size2 = list.size() - size1;
         List<Integer> right = new ArrayList<Integer>();
        for (int i = 0; i < size2; i++) {
            right.add(i, list.get(i + size1));
        }
        return right;
    }
    /**
     * Función parte del proceso MergeSort. Gestiona el montaje de la lista ordenada a raíz de la descomposición previa
     * @param result lista ordenada
     * @param left elementos de la parte izquierda de la lista
     * @param right elementos de la parte derecha de la lista
     */
    public void merge(List<Integer> result, 
                             List<Integer> left, List<Integer> right) {
        int i1 = 0;
        int i2 = 0;
        
        for (int i = 0; i < result.size(); i++) {
            if (i2 >= right.size() || (i1 < left.size() && 
                    left.get(i1) <= right.get(i2))) {
                result.set(i, left.get(i1));
                i1++;
            } else {
                result.set(i, right.get(i2));
                i2++;
            }
        }
    }
    /**
     * Funcion que realiza la busqueda binaria
     * @param list lista en la que buscar
     * @param value valor a buscar
     * @return float con el tiempo de búsqueda en milisegundos
     */
    private float BinarySearch(List<Integer> list, int value){
        Collections.sort(list);
        int centro, inf = 0, sup = list.size()-1;
        before = System.nanoTime(); 
        
        while(inf <= sup){
            centro = ((sup-inf)/2) + inf;
            if(list.get(centro) == value)
            {
                time = (float)(System.nanoTime() - before) / divMill;
                return time;
            }
            else if(value < list.get(centro))
                sup = centro - 1;
            else
                inf = centro + 1;
        }
        time = (float)(System.nanoTime() - before) / divMill;
        return time;
    }
    /**
     * Funcion que cuenta el numero de instrucciones realizadas durante la busqueda binaria
     * La duplicidad tiene por objeto no interferir en la toma de mediciones de tiempo de búsqueda
     * @param list lista en la que buscar
     * @param value valor a buscar
     */
    private void NumeroInstruccionesBinarySearch(List<Integer> list, int value){
        int contadorSwap = 0;
        int contadorComparaciones = 0;
        Collections.sort(list);
        int centro, inf = 0, sup = list.size()-1;
        before = System.nanoTime(); 
        
        while(inf <= sup){
            contadorComparaciones++;
            contadorSwap++;
            centro = ((sup-inf)/2) + inf;
            if(list.get(centro) == value)
            {
                contadorComparaciones++;
                break;
                
            }
            else if(value < list.get(centro)){
                sup = centro - 1;
                contadorSwap++;
                contadorComparaciones++;
            }
            else{
                inf = centro + 1;
                contadorSwap++;
                contadorComparaciones++;
            }
        }
        System.out.println("Se han contado " + contadorSwap + " Swaps y " + contadorComparaciones + " comparaciones");
        ficheroS.println("Se han contado " + contadorSwap + " Swaps y " + contadorComparaciones + " comparaciones");
    }
    /**
     * Funcion que realiza la busqueda secuencial
     * @param list lista en la que buscar
     * @param value valor que buscar
     * @return tiempo en milisegundos que ha durado la busqueda
     */
    private float SecuencialSearch(List<Integer> list, int value){
        before = System.nanoTime(); 
        for (int i = 0; i < list.size(); i++) {
            if(list.get(i) == value){
                time = (float)(System.nanoTime() - before) / divMill;
                return time;
            }
        }
        time = (float)(System.nanoTime() - before) / divMill;
        return time;
    }
    /**
     * Funcion que cuenta el numero de instrucciones que se llevan a cabo durante la busqueda Secuencial
     * @param list lista en la que buscar
     * @param value valor a buscar
     */
    private void NumeroInstruccionesSecuencialSearch(List<Integer> list, int value){
        int contadorSwap = 0;
        int contadorComparaciones = 0;
        
        for (int i = 0; i < list.size(); i++) {
            contadorComparaciones++;
            if(list.get(i) == value){
                break;
            }
        }
        System.out.println("Se han contado " + contadorSwap + " Swaps y " + contadorComparaciones + " comparaciones");
        ficheroS.println("Se han contado " + contadorSwap + " Swaps y " + contadorComparaciones + " comparaciones");
    }
    /**
     * Fucion que alberga la llamada a la funcion de ordenacion por MergeSort.
     * Esta funcion medirá el número de Swaps, comparaciones, y llamadas a funcion que se producen.
     * La duplicidad tiene por objeto no interferir en la toma de medidas de tiempo de ejecucion
     * Utilizaremos contadores declarados en la clase para poder trabajar con la funcion recursiva
     * @param list lista a ordenar
     */
    public void NumeroInstruccionesMergeSort(List<Integer> list) {
        contadorSwapExterno = 0;
        contadorComparacionesExterno = 0;
        contadorLlamadasExterno = 0;
        
        mergeSortAuxiliar(list);
        
        System.out.println("Se han contado " + contadorSwapExterno + " Swaps, " + contadorComparacionesExterno + " comparaciones y " + contadorLlamadasExterno + " llamadas a función");
        ficheroS.println("Se han contado " + contadorSwapExterno + " Swaps, " + contadorComparacionesExterno + " comparaciones y " + contadorLlamadasExterno + " llamadas a función");
        
    }
    /**
     * Funcion de ordenacion por el metodo MergeSort. 
     * En esta funcion será en la que contaremos el numero de instrucciones que se llevan a cabo
     * @param list lista a ordenar
     */
    public void mergeSortAuxiliar(List<Integer> list) {
        //System.out.println("entra en mergeSort");
        //System.out.println(list.size());
        contadorComparacionesExterno++;
        if (list.size() > 1) {
            List<Integer> left = leftHalfAuxiliar(list);
            List<Integer> right = rightHalfAuxiliar(list);
            contadorLlamadasExterno++;
            mergeSortAuxiliar(left);
            contadorLlamadasExterno++;
            mergeSortAuxiliar(right);
            
            contadorLlamadasExterno++;
            mergeAuxiliar(list, left, right);
        }
        
    }
    /**
     * Funcion parte del MergeSort.
     * Forma parte del proceso de medida de instrucciones
     * @param list parte izquierda de la lista a ordenar
     * @return mitad de la lista recibida
     */
    public List<Integer> leftHalfAuxiliar(List<Integer> list) {
        int size1 = list.size() / 2;
        List<Integer> left = new ArrayList<Integer>();
        for (int i = 0; i < size1; i++) {
            left.add(i, list.get(i));
        }
        return left;
    }
    /**
     * Funcion parte del MergeSort
     * Forma parte del proceso de medida de instrucciones
     * @param list parte derecha de la lista a ordenar
     * @return mitad de la lista recibida
     */
    public List<Integer> rightHalfAuxiliar(List<Integer> list) {
        int size1 = list.size() / 2;
        int size2 = list.size() - size1;
         List<Integer> right = new ArrayList<Integer>();
        for (int i = 0; i < size2; i++) {
            right.add(i, list.get(i + size1));
        }
        return right;
    }
    /**
     * Funcion parte del proceso de ordenacion por MergeSort.
     * Forma parte del apartado de mediciones de instrucciones
     * @param result lista ordenada
     * @param left elementos de la parte izquierda de la lsita
     * @param right elementos de la parte derecha de la lista
     */
    public void mergeAuxiliar(List<Integer> result, 
                             List<Integer> left, List<Integer> right) {
        int i1 = 0;
        int i2 = 0;
        
        for (int i = 0; i < result.size(); i++) {
            contadorComparacionesExterno++;
            if (i2 >= right.size() || (i1 < left.size() && 
                    left.get(i1) <= right.get(i2))) {
                result.set(i, left.get(i1));
                i1++;
            } else {
                result.set(i, right.get(i2));
                i2++;
            }
        }
    }
}
    

