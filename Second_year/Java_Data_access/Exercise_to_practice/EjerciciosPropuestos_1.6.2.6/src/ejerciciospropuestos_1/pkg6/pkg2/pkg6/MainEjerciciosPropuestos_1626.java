/*
1.6.2.6: Crea una versión mejorada del programa anterior, que sea capaz de convertir
de un fichero CSV (cuyos campos aparecerán en la primera línea) a un fichero XML. 
Para simplificar un poco, supondremos que todos los datos, incluso los numéricos, 
estarán encerrados entre comillas.
*/

package ejerciciospropuestos_1.pkg6.pkg2.pkg6;

//import com.csvreader.CsvReader; // Se utiliza para el uso de la librería javacsv
import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.util.Scanner;
import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.transform.OutputKeys;
import javax.xml.transform.Transformer;
import javax.xml.transform.TransformerFactory;
import javax.xml.transform.dom.DOMSource;
import javax.xml.transform.stream.StreamResult;
import org.w3c.dom.Attr;
import org.w3c.dom.Document;
import org.w3c.dom.Element;

/**
 * Conversor de CSV a XML
 * Está preparado para leer "cualquier" CSV y generar un XML, no solo el fichero personas
 * @author Ignacio Pastor Padilla
 */

public class MainEjerciciosPropuestos_1626 {
    /**
     * Comprueba si el nombre viene en forma de Apellidos, Nombe; y si es así,
     * lo devuelve en forma Nombre Apellidos
     * @param nombre a validar formato
     * @return string con el nombre bien ordenado (Nombre Apellido
     */
    public static String validarNombre(String nombre){
        int pos;
        if((pos = nombre.indexOf(",")) != -1){
            String s1 = nombre.substring(0, pos);
            String s2;
            if(nombre.charAt(pos + 1) == ' '){
                s2 = nombre.substring(pos + 2, nombre.length());
            }else{
                s2 = nombre.substring(pos + 1, nombre.length());
            }
            return s2 + " " + s1;
        }
        return nombre;
    }
    public static void main(String[] args){
        try{
            Scanner scanner = new Scanner(System.in);
            System.out.println("Introduce el nombre (con extensión) del fichero CSV que quieres convertir en XML");
            String nombreFicheroEntrada = scanner.nextLine();
            //String nombreFicheroEntrada = "personas.csv";//Para agilizar la corrección, comentar las dos líneas superiores y descomentar esta
            scanner.close(); //Cerramos el scanner
            //Comprobamos que existe el fichero a leer
            if(!(new File(nombreFicheroEntrada).exists())){
                System.err.println("No se ha encontrado el fichero");
                return;
            }else if(!nombreFicheroEntrada.endsWith(".csv")){ //Comprobamos que efectivamente vamos a leer un csv
                System.err.println("No es un formato correcto (debes indicar un fichero .csv)");
                return;
            }
            //El elemento raiz lo extraeremos del nombre del fichero, primero quitamos la extensión
            String elementoRaiz = nombreFicheroEntrada.subSequence(0, nombreFicheroEntrada.indexOf(".csv")).toString();
            String nombreFicheroSalida = elementoRaiz + ".xml"; //Aprovechamos el nombre sin extensión para generar
            //Estimación superficial del singular               // el nombre del fichero de salida XML
            //El item principal del XML lo sacaremos haciendo una transformación estimada al singular del nombre del fichero
            String nombreItemPrincipal;
            if(elementoRaiz.endsWith("es"))
                nombreItemPrincipal = elementoRaiz.substring(0, elementoRaiz.length() - 2);
            else if(elementoRaiz.endsWith("s"))
                nombreItemPrincipal = elementoRaiz.substring(0, elementoRaiz.length() - 1);
            else
                nombreItemPrincipal = elementoRaiz;
            
            //XML
            DocumentBuilderFactory dbFactory = DocumentBuilderFactory.newInstance();
            DocumentBuilder dBuilder = dbFactory.newDocumentBuilder();
            Document doc = dBuilder.newDocument();
            Element eRaiz = doc.createElement(elementoRaiz);
            doc.appendChild(eRaiz);
            
// Utilizando la librería específica de CSV javacsv---------------------------------------------------------------------------------
//            CsvReader personasImport = new CsvReader(nombreFicheroEntrada);
//            personasImport.readHeaders();
//            String[] headers = personasImport.getHeaders();
//            int nHeaders = personasImport.getHeaderCount();
//            
//            int contador = 1;
//            while(personasImport.readRecord()){ // Leemos el fichero CSV
//                //ItemPrincipal
//                Element itemPrincipal = doc.createElement(nombreItemPrincipal);
//                eRaiz.appendChild(itemPrincipal);
//                Attr atribute = doc.createAttribute("id");
//                atribute.setValue("p" + (contador++));
//                itemPrincipal.setAttributeNode(atribute);
//                for (int i = 0; i < nHeaders; i++) { //Vamos leyendo los hijos del ItemPrincipal
//                    //Hijos del ItemPrincipal
//                    Element e = doc.createElement(headers[i]);
//                    if(e.getNodeName().equals("nombre")) // Si estamos leyendo el nombre, controlamos su formato (Nombre Apellidos)
//                        e.appendChild(doc.createTextNode(validarNombre(personasImport.get("nombre"))));
//                    else
//                        e.appendChild(doc.createTextNode(personasImport.get(headers[i])));
//                    itemPrincipal.appendChild(e);
//                }
//            }
//            personasImport.close(); // Cerramos el fichero de entrada
// Fin uso librería javacsv---------------------------------------------------------------------------------------------------------
            
//Leyendo como si se tratara de un fichero de texto---------------------------------------------------------------------------------
            BufferedReader lector = new BufferedReader(new FileReader(new File(nombreFicheroEntrada)));
            String[] lineaSplit;
            String[] cabecera;
            String linea;
            linea = lector.readLine(); //Leemos la cabecera del fichero CSV
            cabecera = limpiarComillas(linea.split("\",\"")); //Separamos por elementos y le quitamos las comillas residuales
            int contador = 1;
            while((linea = lector.readLine()) != null){ //Leemos el resto de las lineas
                lineaSplit = limpiarComillas(linea.split("\",\""));  //Separamos por elementos, y eliminamos las comillas residuales
                Element itemPrincipal = doc.createElement(nombreItemPrincipal); //Creamos el item principal (persona)
                eRaiz.appendChild(itemPrincipal);// Asignamos el item principal como hijo del raiz
                Attr atribute = doc.createAttribute("id"); // Creamos el atributo id para el item principal
                atribute.setValue("p" + (contador++)); //Asignamos al atributo el valor
                itemPrincipal.setAttributeNode(atribute); // Asignamos el atributo al item principal
                for (int i = 0; i < cabecera.length; i++) { //Vamos leyendo los distintos elementos de esta fila
                                                            //(tantos como elementos de cabecera hay)
                    //Hijos del ItemPrincipal
                    Element e = doc.createElement(cabecera[i]); //Creamos un elemento para el hijo, con el nombre de columna correspondiente
                    if(e.getNodeName().equals("nombre")) // Si estamos leyendo el nombre, controlamos su formato (Nombre Apellidos)
                        e.appendChild(doc.createTextNode(validarNombre(lineaSplit[0])));
                    else
                        e.appendChild(doc.createTextNode(lineaSplit[i]));
                    itemPrincipal.appendChild(e); // Asignamos el elemento nuevo como hijo del item principal
                }
            }
// Fin leyendo como si se tratara de un fichero de texto------------------------------------------------------------------------------
            
            //Reflejamos los datos en un XML
            TransformerFactory transformerFactory = TransformerFactory.newInstance();
            Transformer transformer = transformerFactory.newTransformer();
            transformer.setOutputProperty(OutputKeys.INDENT, "yes"); // Evita que el resultado aparezca en una sola línea en el fichero
                                                                    // No he conseguido que aparezca tabulado. 
                                                                    // Si se abre con el navegador sí que aparece tabulado correctamente
            transformer.setOutputProperty(OutputKeys.OMIT_XML_DECLARATION, "yes"); //Ocultamos la declaración, ahora no interesa
            DOMSource source = new DOMSource(doc);
            StreamResult result = new StreamResult(new File(nombreFicheroSalida));
            transformer.transform(source, result);
        }catch(Exception e){
            e.printStackTrace();
        }
    }
    /**
     * Elimina las comillas residuales que no se han eliminado en el Split
     * @param lS array de String leido, correspondiente a una linea del fichero
     * @return array con las comillas eliminadas
     */
    public static String[] limpiarComillas(String[] lS){
        for (int i = 0; i < lS.length; i++) {
            lS[i] = lS[i].replace("\"", "");
        }
        return lS;
    }
}
