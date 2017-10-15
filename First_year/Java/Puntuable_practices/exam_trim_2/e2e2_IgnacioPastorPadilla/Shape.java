package e2e2;

/**
 * Interfaz para manejar figuras geométricas de 2 dimensiones. Cada figura geométrica, 
 * entre otras cosas, tiene un color asociado.
 * @author Profe
 */
public interface Shape {
	
	/**
	 * Esta función pone el color a la figura.
	 * @param aColor Color que debe tener la figura
	 */
	void setColor(int aColor);
	
	/**
	 * Función para obtener el color de la figura.
	 * @return Color de la figura.
	 */
	int getColor();
	
	/**
	 * Esta función dice si un punto (x,y) está dentro de la figura o no. Se estima que
	 * un punto está dentro de una figura si está dentro o está en el perímetro
	 * de la figura. Por ejemplo el punto (1, 0) estaría dentro del circulo de 
	 * radio 1 situado en las coordenadas (0, 0). Otra anotación al respecto es que 
	 * si una figura geométrica se convierte en un punto, por ejemplo un círculo 
	 * de radio 0, un punto sólo pertenecerá a esa figura si coinciden los puntos
	 * dados (el que se pasa a la función y al que se convierte la figura). Si una 
	 * figura se conviere en un segmento (una linea), entonces el punto pertenecerá
	 * a esa figura si pertenece al segmento en el que se ha convertido.
	 * @param x Coordenada x del punto que queremos checkear.
	 * @param y Coordenada x del punto que queremos checkear.
	 * @return true si el punto está dentro, false en otro caso.
	 */
	boolean containsPoint(float x, float y);
}
