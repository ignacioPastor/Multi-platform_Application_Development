
package ejerciciospropuestos_1.pkg6.pkg1.pkg2;

import javax.xml.parsers.SAXParser;
import javax.xml.parsers.SAXParserFactory;
import org.xml.sax.Attributes;
import org.xml.sax.helpers.DefaultHandler;

/**
 *
 * @author Ignacio
 */
public class LectorXml {
    
    public void procesarXml(){
        try{
            SAXParserFactory saxParserFactory = SAXParserFactory.newInstance();
            SAXParser saxParser = saxParserFactory.newSAXParser();
            DefaultHandler manejadorEventos = new DefaultHandler(){
                String etiquetaActual = "";
                String contenido = "";
                
                public void startElement(String uri, String localName, String qName, Attributes attributes){
                    etiquetaActual = qName;
                    if(etiquetaActual.equals("persona"))
                        System.out.println("Persona: " + attributes.getValue("id"));
                }
                public void characters(char ch[], int start, int length){
                    contenido = new String(ch, start, length);
                }
                public void endElement(String uri, String localName, String qName){
                    if(!etiquetaActual.equals("")){
                        if(!etiquetaActual.equals("edad"))
                            System.out.println(" " + etiquetaActual + ": " + contenido);
                        etiquetaActual = "";
                    }
                }
            };
            saxParser.parse("personas.xml", manejadorEventos);
        }catch(Exception e){
            e.printStackTrace();
        }
    }
    
}
