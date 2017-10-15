
package gestionmatriculasestudiantes;

/**
 * Esta clase caracteriza a las Personas, las gestiona y compone
 * @author Ignacio
 */
public class Persona {
    
    protected String dni;
    protected String nombre;
    protected String direccion;
    protected String estadoCivil;
    
    /**
     * Devuelve el dni de la persona
     * @return devuelve dni
     */
    public String getDni();
    
    /**
     * Devuelve el nombre de la persona
     * @return nombre persona
     */
    public String getNombre();
    
    /**
     * Modifica la dirección de la persona
     * @param p1 string con la nueva dirección
     */
    public void setDirección(String p1);
    
    /**
     * Devuelve la dirección de la persona
     * @return dirección persona
     */
    public String getDirección();
    
    /**
     * Modifica el estado civil de la persona
     * @param estad parámetro con el nuevo estado civil
     */
    public void setEstadoCivil(String estad);
    
    /**
     * Devuelve el estado civil de la persona
     * @return string con el estado civil
     */
    public String getEstadoCivil();
}
