/*
1.6.1.2: Haz un programa que muestre sólo el nombre y el e-mail 
de las personas almacenadas en el fichero XML anterior (pero no la edad).
*/
package ejerciciospropuestos_1.pkg6.pkg1.pkg2;

/**
 *
 * @author Ignacio
 */
public class MainEjerciciosPropuestos_1612 {

    public static void main(String[] args) {
        LectorXml ficheroXml = new LectorXml();
        ficheroXml.procesarXml();
    }
    
}
