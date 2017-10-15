package examen;

import java.io.File;
import java.util.ArrayList;
import java.util.Iterator;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
import javax.xml.transform.Transformer;
import javax.xml.transform.TransformerFactory;
import javax.xml.transform.dom.DOMSource;
import javax.xml.transform.stream.StreamResult;

import org.w3c.dom.Document;
import org.w3c.dom.Element;

/**
 * Esta clase se encargara de generar el fichero de salida pedidosCliente.xml
 * Queda a eleccion del programador si usar SAX o DOM
 * @author Ignacio
 *
 */
public class ExportarXML {
	
	public static void crearXML(ArrayList<PedidosClientes> pedidos){
		try{
			DocumentBuilderFactory dbFactory = DocumentBuilderFactory.newInstance();
			DocumentBuilder docBuilder = dbFactory.newDocumentBuilder();
			// elemento raiz
			Document doc = docBuilder.newDocument();
			Element elementoRaiz = doc.createElement("pedidosCliente");
			doc.appendChild(elementoRaiz);
			
			int identificador = 0;
			Iterator<PedidosClientes> iterador = pedidos.iterator();
			
			while(iterador.hasNext()){
				identificador++;
				
				PedidosClientes elemento = iterador.next();
				
				Element pedidoClienteXML = doc.createElement("pedidoCliente");
				pedidoClienteXML.setAttribute("id", Integer.toString(elemento.getCli().getId_cliente()));
				elementoRaiz.appendChild(pedidoClienteXML);
				
				Element nombreXML = doc.createElement("nombre");
				nombreXML.appendChild(doc.createTextNode(elemento.getCli().getNombre()));
				pedidoClienteXML.appendChild(nombreXML);
				
				Element calleXML = doc.createElement("calle");
				calleXML.appendChild(doc.createTextNode(elemento.getCli().getCalle()));
				pedidoClienteXML.appendChild(calleXML);
				
				Element ciudadXML = doc.createElement("ciudad");
				ciudadXML.appendChild(doc.createTextNode(elemento.getCli().getCiudad()));
				pedidoClienteXML.appendChild(ciudadXML);
				
				/*
				Element pedidosXML = doc.createElement("pedidos");
				pedidosXML.appendChild();
				pedidoClienteXML.appendChild(ciudadXML);
				*/
				
			}
			TransformerFactory trfFactory = TransformerFactory.newInstance();
			Transformer transformer = trfFactory.newTransformer();
			DOMSource source = new DOMSource(doc);
			StreamResult result = new StreamResult(new File("pedidosCliente.xml"));
			transformer.transform(source, result);
			System.out.println("Fichero XML generado.");
		}catch(Exception e){
			System.err.println("Error: " + e.getMessage());
		}
		
		
	}
	
	
}
