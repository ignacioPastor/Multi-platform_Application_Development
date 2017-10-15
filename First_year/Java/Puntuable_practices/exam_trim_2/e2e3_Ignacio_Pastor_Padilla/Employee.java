package e2e3;

/**
 * Clase para almacenar los datos de un empleado. Como observación hay que mencionar 
 * que los empleados ADMITEN null como nombre, con lo cual, en el setter del nombre, 
 * se ha de admitir un null.
 * Implementa esta clase para que se comporte como sugieren los métodos.
 * @author Profe
 */
public class Employee {
        
        String name;
	/**
	 * Constructor.
	 * @param name Nombre del empleado.
	 */
	public Employee(String name) {
            setName(name);
	}
	
	/**
	 * Función que pone el nombre del empleado.
	 * @param aName Nombre del empleado, puede ser null, y por lo tanto se ha de
	 * almacenar null.
	 */
	void setName(String aName) {
            this.name = aName;
	}
	
	/**
	 * Función que devuelve el nombre del empleado.
	 * @param uppercase Si este parámero es true, el nombre será devuelto TODO en
	 * mayúsculas.
	 * @return Nombre del empleado.
	 */
	String getName(boolean uppercase) {
            
            if(uppercase == true && name != null)
                return name.toUpperCase();
            else
                return name;
	}
}
