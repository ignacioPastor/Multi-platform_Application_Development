package e2e2;

/**
 * Figura que has de implementar de tal manera que herede de ShapeBase.
 * Esta clase manejará el concepto de figura geométrica de rectángulo. Un rectángulo 
 * viene definido por 4 valores, la X mínima y la X máxima; la Y mínima y la Y máxima.
 * Hay que tener en cuenta que un rectángulo, dependiendo de los valores que nos
 * pasen en el constructor, se puede convertir en un punto o en un segmento
 * con todas las consecuencias descritas en el método Shape.containsPoint
 * @author Profe
 */
public class Rectangle extends ShapeBase {
	float minx, miny, maxx, maxy;
	/**
	 * Constructor.
	 * @param minx x mínima
	 * @param miny y mínima
	 * @param maxx x máxima, en el caso de que la x máxima sea menor que la x mínima
	 * en el constructor se deberá corregir y se deberá poner al valor de la x mínima.
	 * @param maxy y máxima, lo mismo que para la coordenada x máxima pero para las
	 * coordenadas y
	 */
	public Rectangle(float minx, float miny, float maxx, float maxy) {
            this.minx = minx;
            this.miny = miny;
            
            if(maxx < minx)
                this.maxx = minx;
            else
                this.maxx = maxx;
            
            if(maxy < miny)
                this.maxy = miny;
            else
                this.maxy = maxy;
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
            if((x >= minx && x <=  maxx) && (y >=  miny && y <=  maxy))
                return true;
            else
                return false;
        }

    
}
