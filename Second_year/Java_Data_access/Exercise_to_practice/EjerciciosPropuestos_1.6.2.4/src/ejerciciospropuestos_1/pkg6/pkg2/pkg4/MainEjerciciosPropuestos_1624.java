/*
1.6.2.4: Crea un programa que analice el fichero XML anterior y vuelque sus datos
a un fichero CSV (un fichero de texto en el que en cada línea se guardará un registro, 
con sus campos separados por comas; los datos de texto estarán entre comillas,
pero los datos numéricos no). En ocasiones se incluyen los nombres de los campos 
en la primera fila, y eso deberá hacer tu programa,
*/

package ejerciciospropuestos_1.pkg6.pkg2.pkg4;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

public class MainEjerciciosPropuestos_1624 {

    public static void main(String[] args) {
        try{
            String nombreFicheroEntrada = "personas.xml";
            String nombreFicheroSalida = "personas.txt";
            BufferedWriter ficheroSalida = new BufferedWriter(new FileWriter(new File(nombreFicheroSalida)));
            
            File inputFile = new File(nombreFicheroEntrada);
            DocumentBuilderFactory dbFactory = DocumentBuilderFactory.newInstance();
            DocumentBuilder dBuilder = dbFactory.newDocumentBuilder();
            Document doc = dBuilder.parse(inputFile);
            doc.getDocumentElement().normalize();
            NodeList nList = doc.getElementsByTagName("persona");
            
            ficheroSalida.write("\"nombre\",\"e-mail\",\"edad\"");
            ficheroSalida.newLine();
            for (int i = 0; i < nList.getLength(); i++) {
                Node nNode = nList.item(i);
                if(nNode.getNodeType() == Node.ELEMENT_NODE){
                    Element e = (Element) nNode;
                    ficheroSalida.write("\"" + e.getElementsByTagName("nombre").item(0).getTextContent() + "\",\"" 
                        + e.getElementsByTagName("mail").item(0).getTextContent() + "\","
                        + e.getElementsByTagName("edad").item(0).getTextContent());
                    ficheroSalida.newLine();
                }
            }
            ficheroSalida.close();
            
        }catch(Exception e){
            e.printStackTrace();
        }
    }
    
}
