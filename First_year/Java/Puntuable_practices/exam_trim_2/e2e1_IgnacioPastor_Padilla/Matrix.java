package e2e1;

/**
 * Interfaz para manejar una matrix rectangular.
 * @author Profe
 */
public interface Matrix {
	/**
	 * Esta función pone en la celda que está en la columna column y la fila row 
	 * el valor de value.
	 * @param column Columna de la celda que queremos modificar.
	 * @param row Fila de la celda que queremos modificar.
	 * @param value Valor que queremos poner.
	 */
	void setValue(int column, int row, int value);
	
	/**
	 * Función que devuelve el valor de una celda de la matriz.
	 * @param column Columna de la celda de la que queremos saber el valor.
	 * @param row Fila de la celda de la que queremos saber el valor.
	 * @return El calor que hay en la celda de la posición indicada. Si se trata
	 * de una posición no válida, se devolverá 0
	 */
	int getValue(int column, int row);
	/**
	 * Función que devuelve el número de columnas de la matrix.
	 * @return Número de columnas de la matriz.
	 */
	int getColumnCount();
	/**
	 * Función que devuelve el número de filas de la matrix.
	 * @return Número de filas de la matriz.
	 */
	int getRowCount();
}
