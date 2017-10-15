package e2e1;

/**
 * Esta será la implementación de la interfaz de la matriz. Impleméntala.
 * @author Profe
 */
public class MatrixImplementation implements Matrix{
        int columnCount;
        int rowCount;
        int[][] matriz;
	/**
	 * Constructor.
	 * @param columnCount Número de de columnas de la matriz
	 * @param rowCount Número de filas de la matriz
	 */
	MatrixImplementation(int columnCount, int rowCount) {
            
            
            if(columnCount <= 0 || rowCount <= 0){
                this.columnCount = 0;
                this.rowCount = 0;
            }
            else{
                this.columnCount = columnCount;
                this.rowCount = rowCount;
            }

            matriz = new int[this.columnCount][this.rowCount];
                
            for (int i = 0; i < this.columnCount; i++) {
                for (int j = 0; j < this.rowCount; j++) {
                    matriz[i][j] = 0;
                }
            }
            
	}	
    /**
	 * Esta función pone en la celda que está en la columna column y la fila row 
	 * el valor de value.
	 * @param column Columna de la celda que queremos modificar.
	 * @param row Fila de la celda que queremos modificar.
	 * @param value Valor que queremos poner.
	 */
    @Override
    public void setValue(int column, int row, int value) {
        if(column >= 0 && column < columnCount &&  row >= 0 && row < rowCount)
            matriz[column][row] = value;
        
    }
/**
	 * Función que devuelve el valor de una celda de la matriz.
	 * @param column Columna de la celda de la que queremos saber el valor.
	 * @param row Fila de la celda de la que queremos saber el valor.
	 * @return El calor que hay en la celda de la posición indicada. Si se trata
	 * de una posición no válida, se devolverá 0
	 */
    @Override
    public int getValue(int column, int row) {
        
        if(column < 0 || column >= columnCount ||  row < 0 || row >= rowCount)
            return 0;
        else
            return matriz[column][row];

        
    }
/**
	 * Función que devuelve el número de columnas de la matrix.
	 * @return Número de columnas de la matriz.
	 */
    @Override
    public int getColumnCount() {
        return columnCount;
    }
	/**
	 * Función que devuelve el número de filas de la matrix.
	 * @return Número de filas de la matriz.
	 */
    @Override
    public int getRowCount() {
        return rowCount;
    }
}
