package ejerciciospropuestos_1.pkg6.pkg2.pkg3;

import java.io.File;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Iterator;
import java.util.List;
import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

/**
 *
 * @author Ignacio
 */
public class MainEjerciciosPropuestos_1623 {

    public static void main(String[] args) {
        List<String> nombres = new ArrayList<>();
        try{
            File inputFile = new File("personas.xml");
            DocumentBuilderFactory dbFactory = DocumentBuilderFactory.newInstance();
            DocumentBuilder dBuilder = dbFactory.newDocumentBuilder();
            Document doc = dBuilder.parse(inputFile);
            doc.getDocumentElement().normalize();
            
            System.out.println("Elemento base: " + doc.getDocumentElement().getNodeName());
            NodeList nList = doc.getElementsByTagName("persona");
            System.out.println();
            
            System.out.println("Recorriendo asignaturas...");
            for (int i = 0; i < nList.getLength(); i++) {
                Node nNode = nList.item(i);
                if(nNode.getNodeType() == Node.ELEMENT_NODE){
                    Element e = (Element) nNode;
                    nombres.add((e.getElementsByTagName("nombre").item(0).getTextContent()));
                }
            }
            Collections.sort(nombres);
            Iterator it = nombres.iterator();
            while(it.hasNext()){
                System.out.println(it.next());
            }
        }catch(Exception e){
            e.printStackTrace();
        }
    }
    
}
