
package gestionmatriculasestudiantes;

import java.util.ArrayList;

/**
 *Esta clase caracteriza al Estudiante
 * @author Ignacio
 */
public class Estudiante {
    
    public ArrayList<Asignatura> asignaturasMatriculadas;
    
    /**
     * Lista las asignaturas matriculadas
     */
    public void listarAsignaturasMatriculadas();
    
    /**
     * Matricula al estudiante en una nueva asignatura
     * @param asig Asignatura en la que matricular al estudiante
     */
    public void anyadirAsignaturaMatriculada(Asignatura asig);
}
