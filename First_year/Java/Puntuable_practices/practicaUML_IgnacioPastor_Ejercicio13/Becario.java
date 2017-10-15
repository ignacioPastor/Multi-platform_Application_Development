
package gestionmatriculasestudiantes;

/**
 *Esta clase almacena y gestiona las propiedades del Estudiante que es Becario
 * @author Ignacio
 */
public class Becario extends Estudiante {
    
    private int importeBeca;
    private String codigo;
    
    /**
     * Devuelve el importe de la beca.
     * @return importe beca
     */
    public int getImporteBeca();
}
