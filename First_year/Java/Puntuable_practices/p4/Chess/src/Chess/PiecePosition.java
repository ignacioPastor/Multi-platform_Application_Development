//Ignacio Pastor Padilla - Entornos de Desarrollo Práctica 4 - DAM Semi A

package Chess;

public class PiecePosition {

	/**
         * Esta función comprueba si la columna y la fila indicadas están
         * dentro del tablero
         * @param column Columna del tablero
         * @param row Fila del tablero
         * @return true or false según se cumpla que tanto la columna como 
         * la fila tienen valores entre 0 y 8
         */
	public static boolean isAvailable(int column, int row) {
		return column >= 0 && column < 8 && row >= 0 && row < 8;
	}

	/**
         * Esta función comprueba si incrementando la fila y la columna de una
         * posición dada, el resultado sigue siendo legítimo. Es decir, está 
         * dentro del tablero
         * @param position posición origen de la pieza
         * @param columnIncrement incremento de la columna
         * @param rowIncrement incremento de la fila
         * @return Devuelve false si la posición dada es null o la posición de
         * destino no está dentro del tablero. Devuelve true si la posición es 
         * válida
         */
	static boolean isAvailable(PiecePosition position, int columnIncrement, int rowIncrement) {
		if (position == null)
			return false;
		
		int newColumn = position.getColumn() + columnIncrement;
		int newRow = position.getRow() + rowIncrement;
		return isAvailable(newColumn, newRow);
	}

	/**
         * Esta función comprueba que una posición sea válida. Por un lado que
         * no sea null, y por otro que esté dentro del tablero
         * @param position posición de una pieza
         * @return true si la posición no es nula y está dentro del tablero.
         * False si no es así
         */
	static boolean isAvailable(PiecePosition position) {
		if (position == null)
			return false;
		return isAvailable(position.getColumn(), position.getRow());
	}

	private int column, row;

	/**
         * Constructor de la clase. Crea una posición con los valores de 
         * columna y fila que se le pasan
         * @param column columna
         * @param row fila
         */
	public PiecePosition(int column, int row) {
		this.column = column;
		this.row = row;
	}
	
	/**
         * Esta función es un getter para mostrar el valor de columna
         * de una pieza
         * @return el valor de la columna
         */
	public int getColumn() {
		return column;
	}

	/**
         * Esta función es un getter para mostrar el valor de fila
         * de una pieza
         * @return el valor de la fila
         */
	public int getRow() {
		return row;
	}
	
        /**
         * Esta función asigna a las variables columna y fila los valores que
         * se le pasan en la función
         * @param column columna
         * @param row fila
         * @return devuelve siempre false
         */
	public boolean setValues(int column, int row) {
		if (isAvailable(column, row)) {
			this.column = column;
			this.row = row;			
			return true;
		}
		return false;
	}
        
	
	/**
         * Esta función asigna una nueva posición a una pieza que va a ser
         * desplazada, es decir, asigna la nueva posición de destino
         * @param columnCount
         * @param rowCount
         * @return devuelve la nueva posición. Devuelve null, si la posición
         * de destino no es viable
         */
	public PiecePosition getDisplacedPiece(int columnCount, int rowCount) {		
		if (!isAvailable(this, columnCount, rowCount))
			return null;
		int newColumn = getColumn() + columnCount;
		int newRow = getRow() + rowCount;
		return new PiecePosition(newColumn, newRow);
	}
	
	/**
         * Esta función duplica o clona una posición
         * @return devuelve una posición con las variables de columna y fila
         */
	public PiecePosition clone() {
		return new PiecePosition(column, row);
	}
	
	/**
         * Esta función comprueba si la posición de origen es igual a la
         * posición idicada como destino
         * @param aPosition
         * @return true si la posición original es la misma que la posición
         * de destino. False si no es así
         */
	public boolean equals(PiecePosition aPosition) {
		return aPosition.getColumn() == getColumn() && aPosition.getRow() == getRow();
	}
}
