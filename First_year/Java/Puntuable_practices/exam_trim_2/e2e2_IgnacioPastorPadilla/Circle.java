package e2e2;

/**
 * Figura que ha de heredar de ShapeBase.
 * Figura del círculo. Hay que tener en cuenta que un círculo de radio cero se
 * convierte en un punto con todas las consecuencias descritas en el método
 * Shape.containsPoint
 * Implementa esta clase tal y como se te ha requerido.
 * @author Profe
 */
public class Circle extends ShapeBase{
        
        float x;
        float y;
        float radius;
	/**
	 * Constructor.
	 * @param x Coordenada x del centro del círculo
	 * @param y Coordenada y del centro del círculo
	 * @param radius Radio del círculo. Si se pasa un radio negativo, hay que 
	 * transformarlo en un radio de tamaño 0.
	 */
	public Circle(float x, float y, float radius) {
            this.x = x;
            this.y = y;
            if(radius > 0)
                this.radius = radius;
            else
               this.radius = 0; 
	}
        
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
        @Override
	public boolean containsPoint(float x, float y){
            float dx = x - this.x;
            float dy = y - this.y;
            return dx * dx + dy * dy <= radius * radius;
        }
}
