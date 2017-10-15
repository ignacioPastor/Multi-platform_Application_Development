
package gestionmatriculasestudiantes;

import java.util.ArrayList;

/**
 *Esta clase caracteriza y gestiona las características de las Asignaturas
 * @author Ignacio
 */
public class Asignatura {
    
    protected String codigo;
    public String nombre;
    protected String profesorResponsable;
    protected int cursoAsignado;
    public ArrayList<Estudiante> matriculados;
    public ArrayList<Examen> examenes;
    
    /**
     * Matricula un nuevo estudiante, es decir, lo añade a la lista
     * @param estudiant estudiante que se quiere matricular
     */
    public void matricularEstudiante(Estudiante estudiant);
    
    /**
     * Lista los alumnos matriculados, es decir, la lista matriculados
     */
    public void listarAlumnosMatriculados();
    
    /**
     * Almacena una nueva nota en la lista de exámenes.
     * @param nNota la nota que queremos registrar
     * @param estu el estudiante al que se la queremos asignar
     */
    public void registrarNotaExamen(float nNota, Estudiante estu);
    
    /**
     * Devuelve el código de la asignatura
     * @return codigo asignatura
     */
    public String getCodigo();
    
    /**
     * Devuelve el nombre de la Asignatura
     * @return el nombre de la asignatura
     */
    public String getNombre();
    
    /**
     * Devuelve el curso asignado de la Asignatura
     * @return curso asignado
     */
    public int getCursoAsignado();
}
