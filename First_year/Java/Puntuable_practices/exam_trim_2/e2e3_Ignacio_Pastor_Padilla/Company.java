package e2e3;

/**
 * Clase para manejar los empleados de una compañia. Esta clase simulará el 
 * almacenamiento de los empleados como si de un array sin valores nulos por medio
 * se tratase.
 * Has de implementar esta clase para que se comporte tal y como pone en los comentarios.
 * El número máximo de empleados que se puede tener una compañía es 10.
 * @author Profe
 */
public class Company {
	Employee employees[]; 
        Employee arrayEnviar[];
        int contador;
        
        public Company(){
            employees = new Employee[10];
            contador = 0;
        }
	/**
	 * Añade un empleado a la lista de empleados.
	 * @param employee Empleado a insertar. Si es null, no se añadirá el empleado.
	 * @return true si el empleado ha podido añadirse, false en otro caso.
	 */
	boolean addEmployee(Employee employee) {
            if(contador >= 10){
                //System.out.println("entra en contador > 10, contador vale " + contador);
                return false;
            }
            else if(employee != null){
                employees[contador] = employee;
                contador++;
                //System.out.println("entra en añadir, contador vale " + contador);
                return true;
            }
            else
                return false;
	}
	
	/**
	 * Función que quita de la compañía a un empleado.
	 * @param employee Nombre del empleado que queremos borrar. La comparación
	 * de esta variable con el nombre del empleado que se va a quitar ha de ser 
	 * case-INsensitive. Para que esta función supere el test, se puede estimar 
	 * como válido el borrar un solo empleado, o todos los empleados con el nombre dado.
	 */
	void removeEmployee(String employee) {
            for (int i = 0; i < contador; i++) {
                if(employee.toUpperCase().equals(employees[i].getName(true))){
                    for (int j = i; j < contador - 1; j++) {
                        employees[j] = employees[j + 1];
                        
                    }
                    contador--;
                }
            }
	}
	
	/**
	 * Función que devuelve el array de empleados.
	 * @return Un array con los empleados en la compañía. Este array, deberá
	 * contener a los empleados que hay en un momento dado en la compañía, en el
	 * mismo orden en que fueron añadidos. Es decir, si hay 3 empleados añadidos
	 * a la compañía, el array devuelto será de tamaño 3.
	 * NO PUEDE CONTENER VALORES NULOS!!! Con lo que cuidado de cómo manejéis el
	 * array internamente.
	 */
	Employee[] getEmployees() {
            arrayEnviar = new Employee[contador];
            arrayEnviar = employees;
            return arrayEnviar;
	}
	
	/**
	 * Función para saber el número de empleados que hay en la compañía.
	 * @return El numero de empleados que hay en un momento dado en la compañía.
	 */
	int getEmployeeCount() {
            return contador;
	}
	
	/**
	 * Función que devuelve el empleado que hay una posición dada. Si por ejemplo 
	 * en algún momento dado de la compañía hay 3 empleados, getEmployeeAt(0) 
	 * devolverá el primer empleado de los que hay almacenados, getEmployeeAt(1)
	 * el segundo y getEmployeeAt(2) el tercero. Además, se devolverán en el orden
	 * en que fueron insertados.
	 * @param index Posición del empleado.
	 * @return Empleado en la posición dada. Si no se puede acceder al empleado, 
	 * devolverá null.
	 */
	Employee getEmployeeAt(int index) {
            if(index < contador)
                return employees[index];
            else
                return null;
	}
}
