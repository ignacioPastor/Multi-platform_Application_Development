/*
Crea un programa en JAVA muestre la cabecera de un fichero MP3 con ID3V1, 
cuyo nombre deberá introducir el usuario desde consola. El programa deberá mostrar el 
campo (Título, Artista, etc.) y el valor que contenga en el fichero.
*/

package lector_id3v1;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.io.InputStream;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.Scanner;

/**
 * @author Ignacio Pastor Padilla
 * Ejercicio Obligatorio Unidad 1 - Acceso a Datos - 2ºDAM Semi
 */
public class Lector_ID3v1 {
    /**
     * Comprueba si el caracter que le llega puede imprimirse
     * (es numero, A-Z, o un espacio)
     * @param b byte leido de fichero binario
     * @return true si el caracter se puede imprimir
     */
    public static boolean esImprimible(byte b){
        
        return (Character.toString((char)b).matches("[A-Za-z0-9]") || Character.toString((char)b).matches("(\\s)"));
    }
    /**
     * Cuenta los bytes que tiene un archivo binario
     * @param nombreFichero Nombre del fichero cuyos bytes queremos contar
     * @return numero de bytes que contiene el archivo binario
     */
    public static int contarBytesArchivo(String nombreFichero){
        try{
            InputStream fichero = new FileInputStream(new File(nombreFichero));
            int contador = 0;
                while(fichero.read() != -1)
                    contador++;
            fichero.close();
                return contador;
        }
        catch(Exception o){
            System.err.println("Ha habido un error: " + o.getMessage());
        }
        return 0;
    }
    /**
     * Mira si al inicio del último bloque de 128 bytes se encuentra la cabecera TAG,
     *     lo cual indicaría que es un archivo de formato ID3v1
     * @param buffer Array de bytes con los ultimos 128 bytes
     * @return true si encuentra la etiqueta
     */
    public static boolean comprobarFormatoID3v1(byte[] buffer){
        return (Character.toString((char)buffer[0]).equals("T")
                && Character.toString((char)buffer[1]).equals("A")
                && Character.toString((char)buffer[2]).equals("G"));
    }
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.println("Introduzca el nombre del archivo de entrada: ");
        String nombreFicheroEntrada = scanner.nextLine();
        if(!(new File(nombreFicheroEntrada).exists())){    // Comprobamos que el fichero existe
            System.err.println("No se ha encontrado el archivo especificado.");
            return;
        }
        
        InputStream ficheroEntrada = null;
        final int BUFFER_SIZE = 128; // Sabemos que el bloque que nos interesa está en los últimos 128 bytes
        byte[] buffer = null;
        try{
            ficheroEntrada = new FileInputStream(new File(nombreFicheroEntrada));
            buffer = new byte[BUFFER_SIZE]; // Nuestro array tendrá 128 posiciones
            int contadorBytes = contarBytesArchivo(nombreFicheroEntrada); // Contamos los bytes del archivo
            ficheroEntrada.skip(contadorBytes - 128); // Ponemos el puntero del fichero en la posición -128
            ficheroEntrada.read(buffer, 0, BUFFER_SIZE); // Cogemos los 128 últimos bytes
            
            if(!comprobarFormatoID3v1(buffer)){ // Comprobamos que esos 128 bytes contienen el bloque que caracteriza el ID3v1
                System.out.println("El archivo no tiene formato ID3v1.");
                ficheroEntrada.close();
                return; // Si no lo tiene salimos del programa
            }
        }
        catch(Exception e){
            System.err.println("Ha habido un error: " + e.getMessage());
        }
        finally{
            try{
                if(ficheroEntrada != null)
                    ficheroEntrada.close();
            }
            catch(IOException io){
                System.err.println("No ha podido cerrarse el fichero correctamente.");
            }
        }
        // Extraemos los datos del bloque de bytes
        int indice = 0; // utilizamos un puntero que iremos moviendo en función del tamanyo de cada conjunto a leer
        String cabecera = formarCadena(buffer, 3, indice); indice += 3;
        String titulo = formarCadena(buffer, 30, indice); indice += 30;
        String artista = formarCadena(buffer, 30, indice); indice += 30;
        String album = formarCadena(buffer, 30, indice); indice += 30;
        String anyo = formarCadena(buffer, 4, indice); indice += 4;
        String comentario = formarCadena(buffer, 29, indice); indice += 30; // Si cojo los 30 bytes, el último  me da un cuadrado (no se imprime)
        int genero = (int)buffer[indice];
        
        // Mostramos los resultados
        System.out.println("Titulo de la canción: " + titulo);
        System.out.println("Artista: " + artista);
        System.out.println("Álbum: " + album);
        System.out.println("Año: " + anyo);
        System.out.println("Comentario: " + comentario);
        //Con el genero intentaremos leer un fichero de generos para mostrar una descripcion del codigo de genero.
        String generoString = leerGenero(genero);
        if(generoString.equals("error")) // Si no ha podido leerse el fichero imprimiremos el codigo
            System.out.println("Género: " + genero);
        else
            System.out.println("Género: " + generoString); // Si todo funciona correctamente, imprimiremos la descripcion del genero
    }
    /**
     * Conforma una cadena de string con los bytes de un array
     * @param b array con los bytes, parte de los cuales queremos convertir en una cadena de string
     * @param tamanyo indice posterior del bloque que queremos coger
     * @param indice indice del inicio del bloque que queremos coger
     * @return el bloque de bytes que nos interesa convertido a string
     */
    public static String formarCadena(byte[] b, int tamanyo, int indice){
        String s = "";
        for (int i = indice; i < tamanyo + indice; i++) {
            s += Character.toString((char)b[i]);
        }
        return s;
    }
    /**
     * Lee el fichero de generos y devuelve la descripcion que le corresponde al codigo que se le pasa
     * @param nGenero codigo del genero cuya descripcion buscamos
     * @return Descripcion del genero, o "error" en caso de no haber podido leer el fichero
     */
    public static String leerGenero(int nGenero){
        final String FICHERO_GENEROS = "generos.txt";
        if(!(new File(FICHERO_GENEROS).exists())) // Comprobamos si existe el fichero
            return "error";
        
        BufferedReader fichGeneros = null;
        try{
            fichGeneros = new BufferedReader(new FileReader(new File(FICHERO_GENEROS)));
            
            List<String> generos = new ArrayList<>(); // Leemos el fichero y guardaremos la informacion en una lista
            String linea;
            while((linea = fichGeneros.readLine()) != null){
                generos.add(linea);
            }
            Iterator it = generos.iterator(); // Recorremos la lista y miramos si contiene contiene el codigo que buscamos guardado entre corchetes
            while(it.hasNext()){
                linea = (String) it.next();
                if(linea.contains("["+ Integer.toString(nGenero) + "]")){
                    return linea.substring(linea.indexOf(">") + 2);//Si lo encontramos, devolvemos la parte de la cadena correspondiente a la descripcion
                }
            }
            return "error"; // Si no encontramos el codigo, devolvemos "error"
        }
        catch(Exception g){
            System.err.println("Ha habido un error intentando leer el índice de géneros: " + g.getMessage());
        }
        finally{
            try{
                if(fichGeneros != null)
                    fichGeneros.close();
            }
            catch(IOException iog){
                System.err.println("No se ha podido cerrar correctamente el fichero de géneros.");
            }
        }
        return "error";
    }
}
