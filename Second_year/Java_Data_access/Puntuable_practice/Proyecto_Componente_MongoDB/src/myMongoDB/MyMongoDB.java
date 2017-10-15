package myMongoDB;

import java.io.Serializable;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;

import org.bson.Document;
import org.bson.conversions.Bson;
import org.bson.types.ObjectId;

import com.mongodb.BasicDBObject;
import com.mongodb.DBObject;
import com.mongodb.MongoClient;
import com.mongodb.MongoCredential;
import com.mongodb.ServerAddress;
import com.mongodb.client.MongoCollection;
import com.mongodb.client.MongoCursor;
import com.mongodb.client.MongoDatabase;
import com.mongodb.client.model.Sorts;
import com.mongodb.util.JSON;

public class MyMongoDB implements Serializable {

	private static final String SERVER = "javi.iessanvi.es";
	private static Scanner scannerMyMongoDB = new Scanner(System.in);
	
	private String usuario;
	private String password;
	private String baseDatos;
	
	private MongoClient mongoClient = null;
	
	private MongoDatabase mongoDatabase = null;
	
	private MongoCredential credenciales = null;
	/**
	 * 
	 */
	public MyMongoDB() {
		super();
	}
	/**
	 * @param usuario
	 * @param password
	 * @param baseDatos
	 * @throws UnknownHostException
	 */
	public MyMongoDB(String usuario, String password, String baseDatos){
		super();
		this.usuario = usuario;
		this.password = password;
		this.baseDatos = baseDatos;
		credenciales = MongoCredential.createCredential(usuario, baseDatos, password.toCharArray());
		mongoClient = new MongoClient(new ServerAddress(SERVER), Arrays.asList(credenciales));
		mongoDatabase = mongoClient.getDatabase(baseDatos);
	}
	/**
	 * @param usuario
	 * @param password
	 * @param baseDatos
	 * @param mongoClient
	 * @param mongoDatabase
	 * @param credenciales
	 */
	public MyMongoDB(String usuario, String password, String baseDatos, MongoClient mongoClient,
			MongoDatabase mongoDatabase, MongoCredential credenciales) {
		super();
		this.usuario = usuario;
		this.password = password;
		this.baseDatos = baseDatos;
		this.mongoClient = mongoClient;
		this.mongoDatabase = mongoDatabase;
		this.credenciales = credenciales;
	}
	/**
	 * Muestra un listado de libros agrupado por autores
	 */
	public void muestraPorAutores(){
		System.out.println();
		System.out.println("|--------------------|");
		System.out.println(" Listado por autores |");
		System.out.println("|--------------------|");
		System.out.println();
		
		MongoCollection<Document> autores = mongoDatabase.getCollection("autores"); //Conjunto de autores
		MongoCursor<Document> cursorAutores = autores.find().iterator();
		MongoCollection<Document> libros = mongoDatabase.getCollection("libros"); //Conjunto de libros
		
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
	 * Permite la búsqueda parcial por título de los libros
	 * @throws IOException 
	 */
	public void buscarLibroPorTitulo() {
		//Scanner scannerTitulo = new Scanner(System.in);
		//BufferedReader scannerTitulo = new BufferedReader(new InputStreamReader(System.in));
		System.out.println();
		System.out.println("|------------------------------|");
		System.out.println(" Búsqueda por título (parcial) |");
		System.out.println("|------------------------------|");
		System.out.println();
		System.out.print("Introduce el contenido del título: ");
		String textoBuscar = scannerMyMongoDB.nextLine();
		//String textoBuscar = scannerTitulo.readLine();
		MongoCollection<Document> libros = mongoDatabase.getCollection("libros"); //Conjunto de libros
		MongoCollection<Document> autores = mongoDatabase.getCollection("autores"); //Conjunto de autores
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
			//scannerTitulo.close();
		}
	}
	/**
	 * Permite la búsqueda parcial por ISBN de los libros
	 */
	public void buscarLibroPorISBN(){
		//Scanner scannerISBN = new Scanner(System.in);
		System.out.println();
		System.out.println("|------------------------------|");
		System.out.println(" Búsqueda por ISBN (parcial) |");
		System.out.println("|------------------------------|");
		System.out.println();
		System.out.print("Introduce el contenido del ISBN: ");
		String textoBuscar = scannerMyMongoDB.nextLine();
		MongoCollection<Document> libros = mongoDatabase.getCollection("libros"); //Conjunto de libros
		MongoCollection<Document> autores = mongoDatabase.getCollection("autores"); //Conjunto de autores
		BasicDBObject filtros = (BasicDBObject) JSON.parse(
				"{ISBN:{$regex: '"+ textoBuscar + "', $options: 'i'}}"); //Filtro que mira si el ISBN coincide, ignoramos mayúsculas y minúsculas
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
			//scannerISBN.close();
		}
	}
	/**
	 * Cierra la conexión
	 */
	public void closeConexion(){
		if(mongoClient != null)
			mongoClient.close();
		if(scannerMyMongoDB != null)
			scannerMyMongoDB.close();
	}
	/**
	 * @return the usuario
	 */
	public String getUsuario() {
		return usuario;
	}
	/**
	 * @param usuario the usuario to set
	 */
	public void setUsuario(String usuario) {
		this.usuario = usuario;
	}
	/**
	 * @return the password
	 */
	public String getPassword() {
		return password;
	}
	/**
	 * @param password the password to set
	 */
	public void setPassword(String password) {
		this.password = password;
	}
	/**
	 * @return the baseDatos
	 */
	public String getBaseDatos() {
		return baseDatos;
	}
	/**
	 * @param baseDatos the baseDatos to set
	 */
	public void setBaseDatos(String baseDatos) {
		this.baseDatos = baseDatos;
	}
	/**
	 * @return the mongoClient
	 */
	public MongoClient getMongoClient() {
		return mongoClient;
	}
	/**
	 * @param mongoClient the mongoClient to set
	 */
	public void setMongoClient(MongoClient mongoClient) {
		this.mongoClient = mongoClient;
	}
	/**
	 * @return the mongoDatabase
	 */
	public MongoDatabase getMongoDatabase() {
		return mongoDatabase;
	}
	/**
	 * @param mongoDatabase the mongoDatabase to set
	 */
	public void setMongoDatabase(MongoDatabase mongoDatabase) {
		this.mongoDatabase = mongoDatabase;
	}
	/**
	 * @return the credenciales
	 */
	public MongoCredential getCredenciales() {
		return credenciales;
	}
	/**
	 * @param credenciales the credenciales to set
	 */
	public void setCredenciales(MongoCredential credenciales) {
		this.credenciales = credenciales;
	}
	/**
	 * @return the server
	 */
	public static String getServer() {
		return SERVER;
	}
	/* (non-Javadoc)
	 * @see java.lang.Object#hashCode()
	 */
	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + ((baseDatos == null) ? 0 : baseDatos.hashCode());
		result = prime * result + ((credenciales == null) ? 0 : credenciales.hashCode());
		result = prime * result + ((mongoClient == null) ? 0 : mongoClient.hashCode());
		result = prime * result + ((mongoDatabase == null) ? 0 : mongoDatabase.hashCode());
		result = prime * result + ((password == null) ? 0 : password.hashCode());
		result = prime * result + ((usuario == null) ? 0 : usuario.hashCode());
		return result;
	}
	/* (non-Javadoc)
	 * @see java.lang.Object#equals(java.lang.Object)
	 */
	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (getClass() != obj.getClass())
			return false;
		MyMongoDB other = (MyMongoDB) obj;
		if (baseDatos == null) {
			if (other.baseDatos != null)
				return false;
		} else if (!baseDatos.equals(other.baseDatos))
			return false;
		if (credenciales == null) {
			if (other.credenciales != null)
				return false;
		} else if (!credenciales.equals(other.credenciales))
			return false;
		if (mongoClient == null) {
			if (other.mongoClient != null)
				return false;
		} else if (!mongoClient.equals(other.mongoClient))
			return false;
		if (mongoDatabase == null) {
			if (other.mongoDatabase != null)
				return false;
		} else if (!mongoDatabase.equals(other.mongoDatabase))
			return false;
		if (password == null) {
			if (other.password != null)
				return false;
		} else if (!password.equals(other.password))
			return false;
		if (usuario == null) {
			if (other.usuario != null)
				return false;
		} else if (!usuario.equals(other.usuario))
			return false;
		return true;
	}//end equals
	
}//end class
