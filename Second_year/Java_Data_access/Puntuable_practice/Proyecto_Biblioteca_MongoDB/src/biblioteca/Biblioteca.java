package biblioteca;

import java.net.UnknownHostException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;
import java.util.regex.Pattern;

import org.bson.Document;
import org.bson.conversions.Bson;
import org.bson.types.ObjectId;

import com.mongodb.BasicDBObject;
import com.mongodb.DBObject;
import com.mongodb.MongoClient;
import com.mongodb.MongoCommandException;
import com.mongodb.MongoCredential;
import com.mongodb.QueryBuilder;
import com.mongodb.ServerAddress;
import com.mongodb.client.MongoCollection;
import com.mongodb.client.MongoCursor;
import com.mongodb.client.MongoDatabase;
import com.mongodb.client.MongoIterable;
import com.mongodb.client.model.Filters;
import com.mongodb.client.model.Sorts;
import com.mongodb.util.JSON;

/**
 * Clase que gestiona consultas sobre una base de datos Mongodb almacenada en un servidor remoto
 * @author Ignacio Pastor Padilla
 * Práctica Acceso a Datos - Tema 5
 */
public class Biblioteca {
	private final static String SERVER = "javi.iessanvi.es";
	private final static String USER = "becario";
	private final static String PASS = "mybecario";
	private final static String BD = "biblioteca";
	private final static MongoCredential CREDENCIALES
		= MongoCredential.createCredential(
					USER,
					BD,
					PASS.toCharArray());
	private static MongoClient mongoClient = null;
	private static Scanner scanner = new Scanner(System.in);
	
	public static void main(String[] args) {
		Logger mongoLogger = Logger.getLogger("org.mongodb.driver");
		mongoLogger.setLevel(Level.SEVERE);
		
		try{
			MongoDatabase db = conexion();
			String opcion;
			do{
				mostrarMenu();
				opcion = scanner.nextLine();
				switch(opcion){
					case "1": muestraPorAutores(db); break;
					case "2": buscarLibroPorTitulo(db); break;
					case "0": System.out.println("Saliendo del programa..."); break;
					default: System.out.println("Opción no válida!"); break;
				}
			}while(!opcion.equals("0"));
			
		}catch(UnknownHostException e){
			System.err.println("Error: " + e.getMessage());
		}finally{
			if(mongoClient != null)
				mongoClient.close();
			if(scanner != null)
				scanner.close();
		}
	}
	/**
	 * Muestra todos los autores de la base de datos y los libros que han escrito
	 * @param db base de datos con la que tiene que trabajar
	 * @throws MongoCommandException
	 */
	private static void muestraPorAutores(MongoDatabase db) throws MongoCommandException{
		System.out.println();
		System.out.println("|--------------------|");
		System.out.println(" Listado por autores |");
		System.out.println("|--------------------|");
		System.out.println();
		
		MongoCollection<Document> autores = db.getCollection("autores"); //Conjunto de autores
		MongoCursor<Document> cursorAutores = autores.find().iterator();
		MongoCollection<Document> libros = db.getCollection("libros"); //Conjunto de libros
		
		try{
			while(cursorAutores.hasNext()){		//Para cada autor que tenemos almacenado
				DBObject dbObjAutor = (DBObject)JSON.parse(cursorAutores.next().toJson()); 		//Guardamos el autor que estamos considerando en esta iteración
				System.out.println(dbObjAutor.get("autor"));	//Imprimimos el autor
				Bson librosOrdenados = Sorts.ascending("paginas");
				MongoCursor<Document> cursorLibros = libros.find().sort(librosOrdenados).iterator();	//Ahora vamos a recorrer los libros que tenemos almacenados
				while(cursorLibros.hasNext()){
					DBObject dbObjLibro = (DBObject)JSON.parse(cursorLibros.next().toJson());	//Consideramos cada libro
					List<ObjectId> listaAutores = (List<ObjectId>)dbObjLibro.get("autores");	//Obtenemos la lista de autores de cada libro
					for(ObjectId autorEnLibro : listaAutores){		//Para cada autor de la lista de autores que cada libro contiene...
						if(dbObjAutor.get("_id").toString().equals(autorEnLibro.toString())){	//Comprobamos si aparece el autor que estamos considerando en esta iteración
							System.out.print("        ");
							System.out.println("ISBN: " + dbObjLibro.get("ISBN") + " | "
								+ "Título: " + dbObjLibro.get("titulo") + " | "
								+ "Nº Páginas: " + dbObjLibro.get("paginas"));	 //Si aparece, lo imprimimos
						}//end if
					}//end for
				}//end while libros del autor
				System.out.println();
			}//end while autores
		}catch(Exception e){
			System.err.println("Error: " + e.getMessage());
		}finally{
			cursorAutores.close();
		}
	}
	
	/**
	 * Busca un libro por el título parcial introducido por el usuario
	 * @param db base de datos con la que tiene que trabajar
	 * @throws MongoCommandException
	 */
	private static void buscarLibroPorTitulo(MongoDatabase db) throws MongoCommandException{
		System.out.println();
		System.out.println("|------------------------------|");
		System.out.println(" Búsqueda por título (parcial) |");
		System.out.println("|------------------------------|");
		System.out.println();
		System.out.print("Introduce el contenido del título: ");
		String textoBuscar = scanner.nextLine();
		MongoCollection<Document> libros = db.getCollection("libros"); //Conjunto de libros
		MongoCollection<Document> autores = db.getCollection("autores"); //Conjunto de autores
		BasicDBObject filtros = (BasicDBObject) JSON.parse(
				"{titulo:{$regex: '"+ textoBuscar + "', $options: 'i'}}"); //Filtro que mira si el título coincide, ignoramos mayúsculas y minúsculas
		Bson librosOrdenados = Sorts.ascending("paginas");
		MongoCursor<Document> cursorLibros = libros.find(filtros).sort(librosOrdenados).iterator(); //Obtenemos la lista de libros que coinciden
		
		try{
			while(cursorLibros.hasNext()){ //Recorremos la lista de libros que coinciden
				DBObject dbObj = (DBObject)JSON.parse(cursorLibros.next().toJson()); //Libro que estamos considerando en esta iteración
				System.out.println("	ISBN.......: " + dbObj.get("ISBN"));
				System.out.println("	Título.....: " + dbObj.get("titulo"));
				System.out.println("	Nº Páginas.: " + dbObj.get("paginas"));
				System.out.print("	Autor/es...: ");
				
				List<ObjectId> listaAutoresId = (List<ObjectId>)dbObj.get("autores"); //Obtenemos la lista de autores que aparece en este libro
				
				int contador = listaAutoresId.size();//Lo utilizaremos para saber cuándo poner una ", " al final del autor
				for(ObjectId id : listaAutoresId){
					BasicDBObject filtrosCoincidenciaAutor = (BasicDBObject) JSON.parse(
							"{_id: {$oid: '" + id + "'}}"); //Con este filtro encontramos en nuestro conjunto de autores al autor que ha escrito este libro
					Document autor = (Document)autores.find(filtrosCoincidenciaAutor).first(); //Cogemos solo el primero porque estamos buscando por pk, solo habrá uno
					System.out.print(autor.get("autor")); //Imprimimos el autor
					//Caso de que todavía queden autores por imprimir en este libro, ponemos una coma y un espacio
					if(contador-- > 1)
						System.out.print(", ");
				}
				System.out.println();
				System.out.println();
			}
		}catch(Exception e){
			System.err.println("Error: " + e.getMessage());
		}
		finally{
			cursorLibros.close();
		}
	}
	/**
	 * Muestra el Menú de opciones para el usuario
	 */
	public static void mostrarMenu(){
		System.out.println();
		System.out.println("BIBLIOTECA MONGODB");
		System.out.println("------------------");
		System.out.println();
		System.out.println("1- Listado completo de libros por autor");
		System.out.println("2- Buscar libro por título (búsqueda parcial");
		System.out.println("0. Salir");
		System.out.println();
		System.out.print("Elige una opción:");
	}
	/**
	 * Conecta con la base de datos y la devuelve.
	 * @return Base de Datos
	 * @throws UnknownHostException
	 */
	private static MongoDatabase conexion() throws UnknownHostException{
		System.out.println("Conectando a MongoDB.");
		mongoClient = new MongoClient(new ServerAddress(SERVER), 
				Arrays.asList(CREDENCIALES));
		
		return mongoClient.getDatabase(BD);
	}
}
