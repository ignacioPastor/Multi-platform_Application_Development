/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package p5;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.PrintStream;
import java.util.ArrayList;
import java.util.Collections;
import java.util.LinkedList;
import java.util.List;
import java.util.Objects;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *Práctica P5 - Entornos de Desarrollo - 1ºDAM Semipresencial
 * @author Ignacio Pastor Padilla
 */
public class Lists {
    
    List<Integer> myArray = new ArrayList<Integer>();
    List<Integer> myLinked = new LinkedList<Integer>();
    List<Integer> myArrayCopy = new ArrayList<Integer>();
    List<Integer> myLinkedCopy = new LinkedList<Integer>();
        
    long before;
    float time;
    final int divMill = 1000000;
    final int value = 10;
    boolean exit;
    int tamanyo = 1000;
    
    PrintStream ficheroL;
    public Lists(){
        try {
            this.ficheroL = new PrintStream(new File("ficheroList.txt"));
        } catch (FileNotFoundException ex) {
            Logger.getLogger(Sort.class.getName()).log(Level.SEVERE, null, ex);
        }  
    }
    /**
     * Funcion que muestra el contenido de los arrays.
     * @param list lista a mostrar
     */
    public void VerArrays(List<Integer> list){
        for (int i = 0; i < tamanyo; i++) {
            System.out.print(list.get(i) + " ");
        }
        System.out.println();
    }
    /**
     * Asigna valores iniciales a las copias de las listas
     */
    private void IniciarArraysCopias(){
        myArrayCopy.clear();
        myLinkedCopy.clear();
        for (int i = 0; i < tamanyo; i++) {
            myArrayCopy.add(i);
            myLinkedCopy.add(i);
        }
    }
    /**
     * Asigna valores iniciales a las listas
     */
    private void IniciarArrays(){
            myArray.clear();
            myLinked.clear();
        for (int i = 0; i < tamanyo; i++) {
            myArray.add(i);
            myLinked.add(i);
        }
    }
    /**
     * Metodo principal que gestiona las llamadas a las diferentes secciones y tests
     */
    public void RunTimes(){
        IniciarArraysCopias();
        ficheroL.println("P5, Parte 1. Ignacio Pastor Padilla");
        ficheroL.println("");
        System.out.println("P5, Parte 1. Ignacio Pastor Padilla");
        System.out.println("");
        Insertar();
        Borrar();
        BorrarPorValor();
        Vaciado();
        Busqueda();
    }
    /**
     * Seccion relativa a las llamadas a los test de inserciones. Por cada test, se realiza el siguiente proceso
     * Se inicializan los arrays
     * Se imprime por pantalla el resultado de las mediciones de pasar cada test, a la vez que se ejecuta dicho test para cada tipo de lista
     * Se comprueba que el proceso se ha realizado correctamente, y se indica por pantalla si ha habido un error o si se ha procedido correctamente
     * Se repite el proceso, esta vez reflejando los resultados en un fichero
     */
    private void Insertar(){
        IniciarArrays();
        System.out.println("Test 01: Insertar elemento al final de la lista. ArrayList: "+Test01(myArray) + " LinkedList: " + Test01(myLinked));
        RunTests(ComprobarInsertar(myArray, myArrayCopy, myLinked, myLinkedCopy, 1, value));
        IniciarArrays();
        ficheroL.println("Test 01: Insertar elemento al final de la lista. ArrayList: "+Test01(myArray) + " LinkedList: " + Test01(myLinked));
        FichRunTests(ComprobarInsertar(myArray, myArrayCopy, myLinked, myLinkedCopy, 1, value));
        
        IniciarArrays();
        System.out.println("Test 02: Insertar elemento al principio de la lista. ArrayList: "+Test02(myArray) + " LinkedList: " + Test02(myLinked));
        RunTests(ComprobarInsertar(myArray, myArrayCopy, myLinked, myLinkedCopy, 2, value));
        IniciarArrays();
        ficheroL.println("Test 02: Insertar elemento al principio de la lista. ArrayList: "+Test02(myArray) + " LinkedList: " + Test02(myLinked));
        FichRunTests(ComprobarInsertar(myArray, myArrayCopy, myLinked, myLinkedCopy, 2, value));
        
        IniciarArrays();
        System.out.println("Test 03: Insertar elemento en mitad de la lista. ArrayList: "+Test03(myArray) + " LinkedList: " + Test03(myLinked));
        RunTests(ComprobarInsertar(myArray, myArrayCopy, myLinked, myLinkedCopy, 3, value));
        IniciarArrays();
        ficheroL.println("Test 03: Insertar elemento en mitad de la lista. ArrayList: "+Test03(myArray) + " LinkedList: " + Test03(myLinked));
        FichRunTests(ComprobarInsertar(myArray, myArrayCopy, myLinked, myLinkedCopy, 3, value));
        
        System.out.println("");
    }
    /**
     * Seccion que alberga las llamadas relativos a los borrados
     */
    private void Borrar(){
        ficheroL.println("");
        IniciarArrays();
        System.out.println("Test 04: Borrar elemento al final de la lista. ArrayList: "+Test04(myArray) + " LinkedList: " + Test04(myLinked));
        RunTests(ComprobarBorrar(myArray, myArrayCopy, myLinked, myLinkedCopy, 4));
        IniciarArrays();
        ficheroL.println("Test 04: Borrar elemento al final de la lista. ArrayList: "+Test04(myArray) + " LinkedList: " + Test04(myLinked));
        FichRunTests(ComprobarBorrar(myArray, myArrayCopy, myLinked, myLinkedCopy, 4));
        
        IniciarArrays();
        System.out.println("Test 05: Borrar elemento al principio de la lista. ArrayList: "+Test05(myArray) + " LinkedList: " + Test05(myLinked));
        RunTests(ComprobarBorrar(myArray, myArrayCopy, myLinked, myLinkedCopy, 5));
        IniciarArrays();
        ficheroL.println("Test 05: Borrar elemento al principio de la lista. ArrayList: "+Test05(myArray) + " LinkedList: " + Test05(myLinked));
        FichRunTests(ComprobarBorrar(myArray, myArrayCopy, myLinked, myLinkedCopy, 5));
        
        IniciarArrays();
        System.out.println("Test 06: Borrar elemento en mitad de la lista. ArrayList: "+Test06(myArray) + " LinkedList: " + Test06(myLinked));
        RunTests(ComprobarBorrar(myArray, myArrayCopy, myLinked, myLinkedCopy, 6));
        IniciarArrays();
        ficheroL.println("Test 06: Borrar elemento en mitad de la lista. ArrayList: "+Test06(myArray) + " LinkedList: " + Test06(myLinked));
        FichRunTests(ComprobarBorrar(myArray, myArrayCopy, myLinked, myLinkedCopy, 6));
        
        System.out.println("");
    }
    /**
     * Seccion que alberga las llamadas a los test relativos a los borrados por valor
     */
    private void BorrarPorValor(){
        ficheroL.println("");
        IniciarArrays();
        System.out.println("Test 07: Borrar por su valor elemento al final de la lista. ArrayList: "+Test07(myArray) + " LinkedList: " + Test07(myLinked));
        RunTests(ComprobarBorrarPorValor(myArray, myLinked, 999));
        IniciarArrays();
        ficheroL.println("Test 07: Borrar por su valor elemento al final de la lista. ArrayList: "+Test07(myArray) + " LinkedList: " + Test07(myLinked));
        FichRunTests(ComprobarBorrarPorValor(myArray, myLinked, 999));
        
        IniciarArrays();
        System.out.println("Test 08: Borrar por su valor elemento al principio de la lista. ArrayList: "+Test08(myArray) + " LinkedList: " + Test08(myLinked));
        RunTests(ComprobarBorrarPorValor(myArray, myLinked, 0));
        IniciarArrays();
        ficheroL.println("Test 08: Borrar por su valor elemento al principio de la lista. ArrayList: "+Test08(myArray) + " LinkedList: " + Test08(myLinked));
        FichRunTests(ComprobarBorrarPorValor(myArray, myLinked, 0));
        
        IniciarArrays();
        System.out.println("Test 09: Borrar por su valor elemento en mitad de la lista. ArrayList: "+Test09(myArray) + " LinkedList: " + Test09(myLinked));
        RunTests(ComprobarBorrarPorValor(myArray, myLinked, 499));
        IniciarArrays();
        ficheroL.println("Test 09: Borrar por su valor elemento en mitad de la lista. ArrayList: "+Test09(myArray) + " LinkedList: " + Test09(myLinked));
        FichRunTests(ComprobarBorrarPorValor(myArray, myLinked, 499));
        
        System.out.println("");
    }
    /**
     * Seccion relativa al test de vaciado de listas
     */
    private void Vaciado(){
        ficheroL.println("");
        IniciarArrays();
        System.out.println("Test 10: Vaciar completamente la lista. ArrayList: "+Test10(myArray) + " LinkedList: " + Test10(myLinked));
        RunTests(ComprobarVaciado(myArray, myLinked));
        IniciarArrays();
        ficheroL.println("Test 10: Vaciar completamente la lista. ArrayList: "+Test10(myArray) + " LinkedList: " + Test10(myLinked));
        FichRunTests(ComprobarVaciado(myArray, myLinked));
        
        System.out.println("");
    }
    /**
     * Seccion relativa a las llamadas a los test de búsqueda.
     * Inicializamos los Arrays
     * Realizamos la busqueda a la vez que mostramos por pantalla el tiempo que ha tardado en ejecutarse dicha busqueda
     * Repetimos el proceso reflejando esta vez las mediciones en un fichero
     */
    private void Busqueda(){
        ficheroL.println("");
        IniciarArrays();
        System.out.println("Test 11_1: Buscar si existe un elemento al final de la lista. ArrayList: "+Test11_1(myArray) + " LinkedList: " + Test11_1(myLinked));
        IniciarArrays();
        ficheroL.println("Test 11_1: Buscar si existe un elemento al final de la lista. ArrayList: "+Test11_1(myArray) + " LinkedList: " + Test11_1(myLinked));
        IniciarArrays();
        System.out.println("Test 11_2: Buscar si existe un elemento al principio de la lista. ArrayList: "+Test11_2(myArray) + " LinkedList: " + Test11_2(myLinked));
        IniciarArrays();
        ficheroL.println("Test 11_2: Buscar si existe un elemento al principio de la lista. ArrayList: "+Test11_2(myArray) + " LinkedList: " + Test11_2(myLinked));
        IniciarArrays();
        System.out.println("Test 11_3: Buscar si existe un elemento en el medio de la lista. ArrayList: "+Test11_3(myArray) + " LinkedList: " + Test11_3(myLinked));
        IniciarArrays();
        ficheroL.println("Test 11_3: Buscar si existe un elemento en el medio de la lista. ArrayList: "+Test11_3(myArray) + " LinkedList: " + Test11_3(myLinked));
        
        ficheroL.println("");
        IniciarArrays();
        System.out.println("Test 12_1: Buscar si existe un elemento en la lista implementando un algoritmo nosotros (FOR). ArrayList: "+Test12_1(myArray) + " LinkedList: " + Test12_1(myLinked));
        IniciarArrays();
        ficheroL.println("Test 12_1: Buscar si existe un elemento en la lista implementando un algoritmo nosotros (FOR). ArrayList: "+Test12_1(myArray) + " LinkedList: " + Test12_1(myLinked));
        IniciarArrays();
        System.out.println("Test 12_2: Buscar si existe un elemento en la lista implementando un algoritmo nosotros (DO/WHILE). ArrayList: "+Test12_2(myArray) + " LinkedList: " + Test12_2(myLinked));
        IniciarArrays();
        ficheroL.println("Test 12_2: Buscar si existe un elemento en la lista implementando un algoritmo nosotros (DO/WHILE). ArrayList: "+Test12_2(myArray) + " LinkedList: " + Test12_2(myLinked));
        IniciarArrays();
        System.out.println("Test 12_3: Buscar si existe un elemento en la lista implementando un algoritmo nosotros (WHILE). ArrayList: "+Test12_3(myArray) + " LinkedList: " + Test12_3(myLinked));
        IniciarArrays();
        ficheroL.println("Test 12_3: Buscar si existe un elemento en la lista implementando un algoritmo nosotros (WHILE). ArrayList: "+Test12_3(myArray) + " LinkedList: " + Test12_3(myLinked));
        
        ficheroL.println("");
        IniciarArrays();
        System.out.println("Test 13: Buscar si existe un elemento en la lista implementando un algoritmo (Búsqueda Binaria). ArrayList: "+Test13(myArray) + " LinkedList: " + Test13(myLinked));
        IniciarArrays();
        ficheroL.println("Test 13: Buscar si existe un elemento en la lista implementando un algoritmo (Búsqueda Binaria). ArrayList: "+Test13(myArray) + " LinkedList: " + Test13(myLinked));
    
        System.out.println("");
    }
    /**
     * Funcion que emite un mensaje de error o de correccion en funcion de que
     * el resultado del proceso ejecutado en los distintos test se haya realizado de forma correcta
     * @param resultado booleano que indica si ha habido o no un error
     */
    private void RunTests(boolean resultado){
        if(resultado == true){
            System.out.println("Ambas instrucciones se han ejecutado correctamente");
        }
        else{
            System.out.println("Ha habido un error");
        }
    }
    /**
     * Refleja el resultado del test mediante un mensaje en un fichero
     * @param resultado 
     */
    private void FichRunTests(boolean resultado){
        if(resultado == true){
            ficheroL.println("Ambas instrucciones se han ejecutado correctamente");
        }
        else{
            ficheroL.println("Ha habido un error");
        }
    }
    /**
     * Funcion que comprueba que las inserciones se han realizado de forma correcta.
     * Para cada lista, y cada test, comprueba que el tamaño de la lista haya aumentado uno respecto a la copia de referencia de dicha lista
     * @param list1 ArrayList modificada
     * @param listCopy1 ArrayList copia de referencia
     * @param list2 LinkedList modificada
     * @param listCopy2 LinkedList copia de referencia
     * @param test valor que indica el test que se ha realizado
     * @param elemento elemento presuntamente insertado
     * @return false si alguno de los procesos no se ha realizado de forma satisfactoria
     */
    private boolean ComprobarInsertar(List<Integer> list1, List<Integer> listCopy1, List<Integer> list2, List<Integer> listCopy2, int test, int elemento){
        if(list1.size() != listCopy1.size() + 1) // Comprobamos que la lista ha aumentado un valor
            return false;
        else if(list1.get(list1.size() - 1) != elemento && test == 1) //En caso de añadir al final, comprobamos que el valor final es igual al añadido
            return false;
        else if(list1.get(0) != elemento && test == 2)//En caso de añadir al principio, comprobamos que el valor final es igual al añadido
            return false;
        else if(list1.get((list1.size() / 2) - 1) != elemento && test == 3 && list1.size() % 2 == 0){//En caso de añadir en medio, comprobamos que el valor final es igual al añadido
            System.out.println("Primera Parte 0 ");
            return false;
        }
        else if(list1.get((list1.size() / 2)) != elemento && test == 3 && list1.size() % 2 == 1){//En caso de añadir en medio, comprobamos que el valor final es igual al añadido
            System.out.println("Primera Parte 1 ");
            return false;
        }
        else if(list2.size() != listCopy2.size() + 1)
            return false;
        else if(list2.get(list2.size() - 1) != elemento && test == 1)
            return false;
        else if(list2.get(0) != elemento && test == 2)
            return false;
        else if(list2.get((list2.size() / 2) - 1) != elemento && test == 3 && list2.size() % 2 == 0){//En caso de añadir en medio, comprobamos que el valor final es igual al añadido
            System.out.println("Segunda Parte 0 ");
            return false;
        }
        else if(list2.get((list2.size() / 2)) != elemento && test == 3 && list2.size() % 2 == 1){//En caso de añadir en medio, comprobamos que el valor final es igual al añadido
            System.out.println("Segunda Parte 1 ");
            return false;
        }
        else      
            return true;
    }
    /**
     * Funcion que comprueba que el borrado se ha ejecutado de forma satisfactoria
     * @param list1 ArrayList modificada
     * @param listCopy1 ArrayList copia de referencia
     * @param list2 LinkedList modificada
     * @param listCopy2 LinkedList copia de referencia
     * @param test valor que indica el test que se ha realizado
     * @return false si alguno de los procesos no se ha realizado de forma satisfactoria
     */
    private boolean ComprobarBorrar(List<Integer> list1, List<Integer> listCopy1, List<Integer> list2, List<Integer> listCopy2, int test){
        if(list1.size() != listCopy1.size() - 1)
            return false;
        else if(Objects.equals(list1.get(list1.size() - 1), listCopy1.get(listCopy1.size() - 1)) && test == 4)
            return false;
        else if(Objects.equals(list1.get(0), listCopy1.get(0)) && test == 5)
            return false;
        else if(Objects.equals(list1.get((list1.size() / 2) + 1), list1.get((list1.size() / 2))) && test == 6 && list1.size() % 2 == 1)
            return false;
        else if(Objects.equals(list1.get((list1.size() / 2)), list1.get((list1.size() / 2) - 1)) && test == 6 && list1.size() % 2 == 0)
            return false;
        else if(list2.size() != listCopy2.size() - 1)
            return false;
        else if(Objects.equals(list2.get(list2.size() - 1), listCopy2.get(listCopy2.size() - 1)) && test == 4)
            return false;
        else if(Objects.equals(list2.get(0), listCopy2.get(0)) && test == 5)
            return false;
        else if(Objects.equals(list2.get((list2.size() / 2) + 1), list2.get((list2.size() / 2))) && test == 6 && list2.size() % 2 == 1)
            return false;
        else if(Objects.equals(list2.get((list2.size() / 2)), list2.get((list2.size() / 2) - 1)) && test == 6 && list2.size() % 2 == 0)
            return false;
        else      
            return true;
    }
    /**
     * Funcion que comprueba que el borrado por valor se ha efectuado de forma satisfactoria
     * @param list1 ArrayList con el elemento borrado
     * @param list2 LinkedList con el elemento borrado
     * @param elemento elemento presuntamente borrado
     * @return false si el elemento que debería de haberse borrado sigue estando presente
     */
    private boolean ComprobarBorrarPorValor(List<Integer> list1, List<Integer> list2, int elemento)
    {
        if(list1.indexOf(elemento) != -1)
            return false;
        else if(list2.indexOf(elemento) != -1)
            return false;
        else
            return true;
    }
    /**
     * Funcion que comprueba que el vaciado se ha efectuado de forma satisfactoria
     * @param list1 ArrayList vacia
     * @param list2 LinkedList vacia
     * @return 
     */
    private boolean ComprobarVaciado(List<Integer> list1, List<Integer> list2){
        if(!list1.isEmpty())
            return false;
        else if(!list2.isEmpty())
            return false;
        else
            return true;
    }
    /**
     * Test 1, Insertar un elemento al final de la lista
     * @param list lista en la que insertar
     * @return tiempo de ejecucion en milisegundos
     */
    private float Test01(List<Integer> list){
        before = System.nanoTime();
        list.add(value);
        time = (float)(System.nanoTime() - before) / divMill;
        return time;
    }
    /**
     * Test 2, insertar un elemento al principio de la lista
     * @param list lista en la que realizar la insercion
     * @return tiempo de ejecucion en milisegundos
     */
    private float Test02(List<Integer> list){
        before = System.nanoTime(); 
        list.add(0,value);
        time = (float)(System.nanoTime() - before) / divMill;
        return time;
    }
    /**
     * Test 3, isertar un elemento a mitad de la lista
     * @param list lista en la que realizar la insercion
     * @return tiempo en milisegundos de la ejecucion
     */
    private float Test03(List<Integer> list){
        before = System.nanoTime(); 
        list.add(list.size()/2,value);
        time = (float)(System.nanoTime() - before) / divMill;
        return time;
    }
    /**
     * Test 4, borra el elemento que hay al final de la lsita
     * @param list lista en la que ralizar el borrado
     * @return tiempo de ejecucion en milisegundos
     */
    private float Test04(List<Integer> list){
        before = System.nanoTime(); 
        list.remove(list.size()-1);
        time = (float)(System.nanoTime() - before) / divMill;
        return time;
    }
    /**
     * Test 5, borra el elemento que hay al principio de la lista
     * @param list lista en la que realizar el borrado
     * @return tiempo de la ejecucion en milisegundos
     */
    private float Test05(List<Integer> list){
        before = System.nanoTime(); 
        list.remove(0);
        time = (float)(System.nanoTime() - before) / divMill;
        return time;
    }
    /**
     * Test 6, borra el elemento de en medio de la lista
     * @param list lista en la que realizar el borrado
     * @return tiempo de ejecucion en milisegundos
     */
    private float Test06(List<Integer> list){
        before = System.nanoTime(); 
        list.remove(list.size()/2);
        time = (float)(System.nanoTime() - before) / divMill;
        return time;
    }
    /**
     * Test 7, Borrado por valor de un elemento al final de la lista
     * @param list lista en la que realizar el borrado
     * @return tiempo de ejecucion en milisegundos
     */
    private float Test07(List<Integer> list){
        before = System.nanoTime();        
        list.remove(new Integer(999));
        time = (float)(System.nanoTime() - before) / divMill;
        return time;
    }
    /**
     * Test 8, Borrado por valor de un elemento que hay al principio de la lista
     * @param list lista en la que realizar el borrado
     * @return tiempo de ejecucion en milisegundos
     */
    private float Test08(List<Integer> list){
        before = System.nanoTime(); 
        list.remove(new Integer(0));
        time = (float)(System.nanoTime() - before) / divMill;
        return time;
    }
    /**
     * Test 9, borrado por valor de un elemento situado en medio de la lista
     * @param list
     * @return 
     */
    private float Test09(List<Integer> list){
        before = System.nanoTime(); 
        list.remove(new Integer(499));
        
        time = (float)(System.nanoTime() - before) / divMill;
        return time;
    }
    
    /**
     * Test 10, vaciado de la lista
     * @param list lista a vaciar
     * @return tiempo de ejecucion en milisegundos
     */
    private float Test10(List<Integer> list){
        before = System.nanoTime();
        list.clear();
        time = (float)(System.nanoTime() - before) / divMill;
        return time;
    }
    
    /**
     * Test 11_1, buscar si existe un elemento en la lista utilizando las funciones que tenga la propia lista
     * Buscamos un valor que está al final de la lista
     * @param list lista en la que realizar la búsqueda
     * @return tiempo de ejecucion en milisegundos
     */
    private float Test11_1(List<Integer> list){
        before = System.nanoTime(); 
        list.indexOf(999);
        time = (float)(System.nanoTime() - before) / divMill;
        return time;
    }
    /**
     * Test 11_2, buscar si existe un elemento en la lista utilizando las funciones que tenga la propia lista
     * Buscamos un valor que está al principio de la lista
     * @param list lista en la que realizar la búsqueda
     * @return tiempo de ejecucion en milisegundos
     */
    private float Test11_2(List<Integer> list){
        before = System.nanoTime(); 
        list.indexOf(0);
        time = (float)(System.nanoTime() - before) / divMill;
        return time;
    }
    /**
     * Test 11_3, buscar si existe un elemento en la lista utilizando las funciones que tenga la propia lista
     * Buscamos un valor que está en medio de la lista
     * @param list lista en la que realizar la búsqueda
     * @return tiempo de ejecucion en milisegundos
     */
    private float Test11_3(List<Integer> list){
        before = System.nanoTime(); 
        list.indexOf(499);
        time = (float)(System.nanoTime() - before) / divMill;
        return time;
    }
    
    /**
     * Test 12_1, buscar si existe un elemento en la lista con un algoritmo implementado por nosotros.
     * Algoritmo FOR
     * @param list lista en la que realizar la busqueda
     * @return tiempo de ejecucion en milisegundos
     */
    private float Test12_1(List<Integer> list){
        before = System.nanoTime(); 
        for (int i = 0; i < list.size(); i++) {
            if(list.get(i) == 999){
                time = (float)(System.nanoTime() - before) / divMill;
                return time;
            }
        }
        time = (float)(System.nanoTime() - before) / divMill;
        return time;
    }
    /**
     * Test 12_2, buscar si existe un elemento en la lista con un algoritmo implementado por nosotros.
     * Algoritmo DO/WHILE
     * @param list lista en la que realizar la busqueda
     * @return tiempo de ejecucion en milisegundos
     */
    private float Test12_2(List<Integer> list){
        int i = 0;
        before = System.nanoTime(); 
        do{
            i++;
        }
        while(list.get(i) != 999);
        time = (float)(System.nanoTime() - before) / divMill;
        return time;
    }
    /**
     * Test 12_3, buscar si existe un elemento en la lista con un algoritmo implementado por nosotros.
     * Algoritmo WHILE
     * @param list lista en la que realizar la busqueda
     * @return tiempo de ejecucion en milisegundos
     */
    private float Test12_3(List<Integer> list){
        int i = 0;
        before = System.nanoTime(); 
        while(list.get(i) != 999)
            i++;
        time = (float)(System.nanoTime() - before) / divMill;
        return time;
    }
    /**
     * Test 13, buscar un elemento de forma binaria con un algoritmo implementado por nosotros
     * @param list lista en la que realizar la busqueda
     * @return tiempo de ejecucion en milisegundos
     */
    private float Test13(List<Integer> list){
        Collections.sort(list);
        int centro, inf = 0, sup = list.size()-1;
        before = System.nanoTime(); 
        
        while(inf <= sup){
            centro = ((sup-inf)/2) + inf;
            if(list.get(centro) == 999)
            {
                time = (float)(System.nanoTime() - before) / divMill;
                return time;
            }
            else if(999 < list.get(centro))
                sup = centro - 1;
            else
                inf = centro + 1;
        }
        
        time = (float)(System.nanoTime() - before) / divMill;
        return time;
    }
}
