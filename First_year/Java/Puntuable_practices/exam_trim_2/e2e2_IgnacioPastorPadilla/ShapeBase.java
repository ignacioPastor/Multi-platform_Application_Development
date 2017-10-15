package e2e2;

/**
 * Clase base de la que heredan todas las figuras. Esta clase implementa de manera
 * la parcial interfaz Shape, es decir, esta clase sólo ha de implementar los métodos setColor
 * y getColor, por lo que esta clase debe ser una clase abstracta.
 * Implementa esta clase tal y como se pide.
 * @author Profe
 */
public abstract class ShapeBase implements Shape {
    
    //enum enumerador = {
    int color;
    
    @Override
    public void setColor(int aColor){
        color = aColor;
    }
    
    /**
	 * Función para obtener el color de la figura.
	 * @return Color de la figura.
	 */
    @Override
    public int getColor(){
        return color;
    }

}
