/*
1.5.3: Ampliando el esqueleto de los dos ejercicios anteriores, crea una “agenda”, 
que permita al usuario introducir datos de personas y buscar entre los datos existentes. 
Cada vez que se añade un nuevo dato, todos ellos se guardarán en fichero. 
Cuando se vuelva a lanzar el programa, los datos existentes se cargarán desde el fichero.
*/
package ejerciciospropuestos_1.pkg5.pkg3;

import java.io.EOFException;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.Scanner;

/**
 *
 * @author Ignacio
 */
// No carga bien
// Después de intentar mostrar o anyadir un dato se sale
public class MainEjerciciosPropuestos_153 {

    public static void main(String[] args) throws IOException, ClassNotFoundException {
        String nombreFichero = "agenda.dat";
        List<Persona> listaPersonas = new ArrayList<>();
        System.out.println("Cargando...");
        if(new File(nombreFichero).exists()){
            ObjectInputStream ficheroEntrada = new ObjectInputStream(new FileInputStream(new File(nombreFichero)));
            try{
                Persona p;
                while((p = (Persona) ficheroEntrada.readObject()) != null){
                    listaPersonas.add(p);
                }
                System.out.println("Se ha cargado correctamente la lista de contactos");
            }catch(EOFException eo){}
            ficheroEntrada.close();
        }else
            System.out.println("No se han encontrado datos guardados previamente");
        
        Scanner scanner = new Scanner(System.in);
        String opcion;
        boolean salir = false;
        do{
            System.out.println("Menu.");
            System.out.println("1. Añadir un nuevo dato");
            System.out.println("2. Mostrar datos almacenados");
            System.out.println("3. Borrar dato");
            System.out.println("4. Buscar dato");
            System.out.println("0. Salir");
            opcion = scanner.nextLine();
            switch(opcion){
                case "1": anyadirDato(listaPersonas); break;
                case "2": mostrarDatos(listaPersonas); break;
                case "3": borrarDato(listaPersonas); break;
                case "4": buscarDato(listaPersonas); break;
                case"0": salir = true; guardarDatos(listaPersonas, nombreFichero); break;
                default:
                    System.out.println("No es una opción válida");
                    break;
            }
        }
        while(salir == false);
        
    }
    public static void buscarDato(List<Persona> l){
        Scanner scanner = new Scanner(System.in);
        String patron = null;
        System.out.println("Por qué criterio quieres hacer la búsqueda:");
        System.out.println("1. Nombre");
        System.out.println("2. Mail");
        System.out.println("3. Año nacimiento");
        String opcion = scanner.nextLine();
        if(opcion.equals("1") || opcion.equals("2") || opcion.equals("3")){
            System.out.println("¿Qué quieres buscar?");
            patron = scanner.nextLine();
        }
        
        switch(opcion){
            case "1": buscarPorNombre(l, patron); break;
            case "2": buscarPorMail(l, patron); break;
            case "3": buscarPorAnyo(l, patron); break;
            default: System.out.println("No es una opción válida"); break;
        }
        
    }
    public static void buscarPorAnyo(List<Persona> l, String patron){
        if(!comprobarEntero(patron))
            System.out.println("Debes introducir un número entero");
        else{
            int n = Integer.parseInt(patron);
            Persona p = null;
            Iterator i = l.iterator();
            int contador = 0;
            while(i.hasNext()){
                p = (Persona) i.next();
                if(p.getAnyo() == n){
                    mostrarDatoPersona(p);
                    contador++;
                }
            }
            if(contador == 0)
                System.out.println("No se han encontrado registros con ese patrón");
        }
    }
    public static void buscarPorMail(List<Persona> l, String patron){
        Iterator i = l.iterator();
        Persona p = null;
        int contador = 0;
        while(i.hasNext()){
            p = (Persona) i.next();
            if(p.getMail().toUpperCase().contains(patron.toUpperCase())){
                mostrarDatoPersona(p);
                contador++;
            }
        }
        if(contador == 0)
            System.out.println("No se han encontrado registros con ese patrón");
    }
    public static void buscarPorNombre(List<Persona> l, String patron){
        Iterator i = l.iterator();
        Persona p = null;
        int contador = 0;
        while(i.hasNext()){
            p = (Persona) i.next();
        if(p.getNombre().toUpperCase().contains(patron.toUpperCase())){
            mostrarDatoPersona(p);
            contador++;
        }
        }
        if(contador == 0)
            System.out.println("No se han encontrado registros con ese patrón");
    }
    public static void borrarDato(List<Persona> l){
        Scanner scanner = new Scanner(System.in);
        System.out.println("Indica que registro quieres borrar");
        mostrarDatos(l);
        String respuesta = scanner.nextLine();
        if(!comprobarEntero(respuesta) || Integer.parseInt(respuesta) < 1 
                || Integer.parseInt(respuesta) > l.size())
            System.out.println("No es una opcion válida");
        else{
            l.remove(Integer.parseInt(respuesta) - 1);
        }
        
    }
    public static void mostrarDatoPersona(Persona p){
        System.out.println("Nombre: " + p.getNombre() 
                        + ". Mail: " + p.getMail() + ". Año nacimiento: " + p.getAnyo());
    }
    public static void mostrarDatos(List<Persona> l){
        if(l.size() == 0)
            System.out.println("No hay registros que mostrar");
        else{
            Iterator i = l.iterator();
            Persona p;
            int contador = 0;
            while(i.hasNext()){
                p = (Persona) i.next();
                System.out.println(++contador + ". Nombre: " + p.getNombre() 
                        + ". Mail: " + p.getMail() + ". Año nacimiento: " + p.getAnyo());
            }
        }
    }
    public static void anyadirDato(List<Persona> listaPersonas){
        Scanner scanner = new Scanner(System.in);
        Persona p = new Persona();
        System.out.println("Indica el nombre");
        p.setNombre(scanner.nextLine());
        System.out.println("Indica el e-mail");
        p.setMail(scanner.nextLine());
        System.out.println("Indica su anyo de nacimiento");
        String n = scanner.nextLine();
        if(comprobarEntero(n))
            p.setAnyo(Integer.parseInt(n));
        else{
            System.out.println("No es un año válido");
            p.setAnyo(0);
        }
        listaPersonas.add(p);
    }
    public static boolean comprobarEntero(String n){
        return n.matches("-?[0-9]+");
    }
    public static void guardarDatos(List<Persona> lista, String nombreFichero) throws IOException{
        try{
        ObjectOutputStream ficheroGuardar = new ObjectOutputStream(
                new FileOutputStream(new File(nombreFichero)));
        Iterator it = lista.iterator();
        while(it.hasNext()){
            ficheroGuardar.writeObject((Persona)it.next());
        }
        System.out.println("El guardado se ha efectuado correctamente");
        ficheroGuardar.close();
        }catch(Exception e){
            System.err.println("Ha habido un error: " + e.getMessage());
        }
    }
}
