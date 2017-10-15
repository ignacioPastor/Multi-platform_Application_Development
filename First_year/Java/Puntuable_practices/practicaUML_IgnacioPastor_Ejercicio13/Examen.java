
package gestionmatriculasestudiantes;

/**
 *Esta clase almacena las propiedades del Examen
 * Tanto la nota, el alumno, como la asignatura a la que pertenece
 * @author Ignacio
 */
public class Examen {
    
    
    protected float nota;
    protected Asignatura asig;
    public Estudiante estu;
    
    /**
     * Modifica la nota del examen
     * @param not donde se almacena la nota del examen
     */
    public void setNota(float not);
    
    /**
     * Devuelve la nota del examen
     * @return nota del examen
     */
    public float getNota();
    
    /**
     * Devuelve la asignatura de la cual es el examen
     * @return Asignatura a la que pertence
     */
    public Asignatura getAsignatura();
    
    /**
     * Devuelve el estudiante que ha realizado el examen
     * @return Estudiante que realiza el examen
     */
    public Estudiante getEstudiante();
    
}
