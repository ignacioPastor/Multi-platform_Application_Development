
package gestionmatriculasestudiantes;

import java.util.ArrayList;

/**
 *Esta clase es la que se encarga de gestionar el programa en sus
 * características más generales.
 * @author Ignacio
 */
public class Aplicacion {
    
    public ArrayList<Persona> personas;
    public ArrayList<Asignatura> asignaturas;
    
    /**
     * Se encarga de dar de alta a una nueva persona, añadiéndolo a la lista personas
     */
    public void darAltaPersona();
    
    /**
     * Se encarga de dar de alta a una nueva asignatura, añadiéndolo a la lista asignaturas
     */
    public void darAltaAsignatura();
    
    /**
     * Se encarga de realizar las actas, listando las notas por asignaturas
     */
    public void listarNotasPorAsignaturas;
    
}
