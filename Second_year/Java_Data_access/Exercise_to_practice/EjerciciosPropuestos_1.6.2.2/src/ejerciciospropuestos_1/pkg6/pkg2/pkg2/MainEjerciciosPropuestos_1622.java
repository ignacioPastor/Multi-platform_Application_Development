package ejerciciospropuestos_1.pkg6.pkg2.pkg2;

import java.io.File;
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
public class MainEjerciciosPropuestos_1622 {

    public static void main(String[] args) {
        try{
            File inputFile = new File("personas.xml");
            DocumentBuilderFactory dbFactory = DocumentBuilderFactory.newInstance();
            DocumentBuilder dBuilder = dbFactory.newDocumentBuilder();
            Document doc = dBuilder.parse(inputFile);
            doc.getDocumentElement().normalize();
            
            System.out.println("Elemento base: " + doc.getDocumentElement().getNodeName());
            NodeList nList = doc.getElementsByTagName("persona");
            System.out.println();
            
            System.out.println("Recorriendo personas...");
            for (int i = 0; i < nList.getLength(); i++) {
                Node nNode = nList.item(i);
                if(nNode.getNodeType() == Node.ELEMENT_NODE){
                    Element e = (Element) nNode;
                    System.out.println("Codigo: " + e.getAttribute("id"));
                    System.out.println("Nombre: " + e.getElementsByTagName("nombre").item(0).getTextContent());
                    System.out.println("Mail: " + e.getElementsByTagName("mail").item(0).getTextContent());
                }
                System.out.println();
            }
            
        }catch(Exception e){
            e.printStackTrace();
        }
    }
    
}