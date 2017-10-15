/*
1.6.1.3: Crea un programa que analice el fichero XML anterior, 
pero conserve sólo los nombres, que se guardarán en un ArrayList 
para finalmente mostrarse ordenados en pantalla.
*/
package ejerciciospropuestos_1.pkg6.pkg1.pkg3;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Iterator;
import java.util.List;
import javax.xml.parsers.SAXParser;
import javax.xml.parsers.SAXParserFactory;
import org.xml.sax.Attributes;
import org.xml.sax.helpers.DefaultHandler;

/**
 *
 * @author Ignacio
 */
public class ReaderXml2 extends DefaultHandler{
    List<String> nombres = new ArrayList<>();
    
    public void procesarXml(){
        try{
            SAXParserFactory saxParserFactory = SAXParserFactory.newInstance();
            SAXParser saxParser = saxParserFactory.newSAXParser();
            DefaultHandler manejadorEventos = new DefaultHandler(){
                String etiquetaActual = "";
                String contenido = "";
                
                public void startElement(String uri, String localName, String qName, Attributes attributes){
                    etiquetaActual = qName;
                }
                public void characters(char ch[], int start, int length){
                    contenido = new String(ch, start, length);
                }
                public void endElement(String uri, String localName, String qName){
                    if(!etiquetaActual.equals("")){
                        if(etiquetaActual.equals("nombre")){
                            nombres.add(contenido);
                        }
                        etiquetaActual = "";
                    }
                }
            };
            saxParser.parse("personas.xml", manejadorEventos);
        }catch(Exception e){
            e.printStackTrace();
        }
    }
    public void mostrarNombres(){
        Collections.sort(nombres);
        Iterator it = nombres.iterator();
        while(it.hasNext()){
            System.out.println(it.next());
        }
    }
}