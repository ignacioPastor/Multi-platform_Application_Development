/*
1.6.1.1: Crea una fichero XML con datos de personas: 
nombre, e-mail, y edad. Haz un programa que lea todo el contenido de ese fichero
usando SAX y lo muestre en pantalla.
*/

package ejerciciospropuestos_1.pkg6.pkg1.pkg1;

import jdk.internal.org.xml.sax.helpers.DefaultHandler;

/**
 *
 * @author Ignacio
 */
public class MainEjerciciosPropuestos_1611 extends DefaultHandler{

    public static void main(String[] args) {
        
        ReadXml ficheroXml = new ReadXml();
        ficheroXml.procesarXml();
    }
    
}
