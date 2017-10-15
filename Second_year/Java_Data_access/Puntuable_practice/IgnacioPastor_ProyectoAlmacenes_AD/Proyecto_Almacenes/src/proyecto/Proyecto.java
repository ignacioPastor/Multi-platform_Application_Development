package proyecto;
/*
 * Ignacio Pastor Padilla
 * Acceso a Datos - 2� DAM Semipresencial
 * 
 */
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.Scanner;

/**
 * CustomException. Esta clase caracteriza una excepci�n que utilizaremos en nuestro programa
 * @author Ignacio Pastor Padilla
 */
class ExcepcionPropia extends Exception {
	private static final long serialVersionUID = 1L;

	public ExcepcionPropia(String msg) {
        super(msg);
    }
}
/**
 * Esta clase contiene una serie de funciones y el main de nuestro programa.
 * Gestionaremos una base de datos en postgre, realizando una serie de consultas sobre la misma
 * @author Ignacio Pastor Padilla
 */
public class Proyecto {
	
	private static final String URL = "jdbc:postgresql://localhost:5432/almacenes";
	private static final String USUARIO = "postgres";
	private static final String PASSWORD = "1234";
	private static Statement statement = null;
	public static int numeroAlmacenes; // Utilizaremos esta variable para contar el n�mero de almacenes que hay.
									// As� sabremos cu�ndo el usuario est� pidiendo un almac�n que no existe, y cu�ndo la funci�n devuelve 0
	
	/**
	 * Se encargar� de establecer la conexi�n y devolver
	 *	verdadero si es correcto y falso en caso de fallo.
	 * @return 
	 * @throws ClassNotFoundException 
	 * @throws SQLException 
	 */
	private static boolean conexionBD() throws ClassNotFoundException, SQLException{
		try{
			Class.forName("org.postgresql.Driver");
			Connection conec = DriverManager.getConnection(URL, USUARIO, PASSWORD);
			statement = conec.createStatement();
		}catch(Exception e){
			return false;
		}
		return true;
	}
	
	/**
	 * Cierra la conexi�n.
	 * @throws SQLException 
	 */
	private static void desconexionBD() throws SQLException{
		statement.close();
	}
	
	/**
	 * Presenta el men� realizando una consulta para obtener los almacenes ordenandos por el c�digo
	 * leer� la opci�n del usuario para calcular la media del almac�n seleccionado 
	 * @return Devuelve la opci�n seleccionada o -1 en caso de error (valor no num�rico introducido)
	 * @throws SQLException 
	 * @throws ExcepcionPropia 
	 */
	private static int menuAlmacenes() throws SQLException, ExcepcionPropia{
		numeroAlmacenes = 0; // inicializamos el contador a 0, as� evitamos que en caso de que hay bucle, la cuenta de almacenes se duplique
		System.out.println("Listado de almacenes");
		System.out.println("--------------------");
		Scanner scanner = new Scanner(System.in);
		int opcion;
		String sentenciaSql = "select codigo, lugar "
								+ "from almacenes "
								+ "order by codigo;";
		ResultSet rs = statement.executeQuery(sentenciaSql);
		while(rs.next()){
			System.out.println(rs.getInt(1) + ". " + rs.getString(2));
			numeroAlmacenes++;
		}
		System.out.println();
		System.out.print("Indica el numero de almac�n para conocer la media de cajas: ");
		try{
			opcion = Integer.parseInt(scanner.next()); // Leemos el valor introducido, y si no es num�rico, lanzamos una excepci�n personalizada
		}catch(Exception e){
			scanner.nextLine();
			//scanner.close(); // Una vez m�s, cerrar la clase Scanner me da infinidad de errores
			throw new ExcepcionPropia("opci�n incorrecta.");
		}
		scanner.nextLine();
		//scanner.close(); // Una vez m�s, cerrar la clase Scanner me da infinidad de errores
		return opcion;// Si la opci�n es v�lida, devolvemos la opci�n elegida
	}
	/**
	 * Utiliza la funci�n ValorMedio() creada en PostgreSQL
	 * para obtener la media de todas las cajas. 
	 * @return Devuelve la media de todas las cajas
	 * @throws SQLException 
	 */
	private static double valorMedio() throws SQLException{
		String sentenciaSql = "select ValorMedio()";
		ResultSet rs = statement.executeQuery(sentenciaSql);
		rs.next();
		return rs.getFloat(1);
	}
	/**
	 * Obtiene la media de las cajas del almac�n pasado como par�metro.
	 * @param almacen almacen cuya media de cajas queremos saber
	 * @return Devuelve la media de cajas de el almac�n pasado como par�metro
	 * @throws SQLException 
	 * @throws ExcepcionPropia 
	 */
	private static double valorMedioAlmacen(int almacen) throws SQLException, ExcepcionPropia{
		String sentenciaSql = "select * from ValorMedioAlmacen(" + almacen + ")"; // Con select * from evitamos un string sobre el que hacer split
		ResultSet rs = statement.executeQuery(sentenciaSql);
		// Para controlar cuando devuelve 0 lo que hacemos es que si devuelve nulo la funci�n, devolvemos 0 al main
		// Sabemos ya que no se le ha pasado ning�n valor fuera del rango de los almacenes que tenemos, porque eso lo controlamos
		//	con la variable global actuando como contador en la funci�n valorMedio()
		if(!rs.next()){
			return 0;
		}
		//Comprobamos que el almac�n que hemos le�do es propiamente el almac�n que quer�amos leer
		// Puesto que en la pr�ctica se especifica que esta funci�n devuelve un double, entiendo que solo devolvemos la media
		if(!(almacen == rs.getInt(1))){
			throw new ExcepcionPropia("El almac�n le�do no es el que se ha indicado");
		}
		return rs.getDouble(2);
	}
	public static void main(String[] args) {
		try{
			int opcion;
			if(!conexionBD())
				throw new ExcepcionPropia("No se ha podido conectar con la Base de Datos.");
			System.out.printf("Conectado a BD Almacenes.%n%n");
			System.out.printf("Valor medio de todas las cajas: %.2f%n", valorMedio());
			do{
				System.out.println();
				opcion = menuAlmacenes();
			} while(opcion > numeroAlmacenes || opcion <= 0); // Mientra se introduzcan valores num�ricos fuera de rango, nos mantendremos en el bucle
			
			System.out.printf("Valor medio de las cajas del almac�n %d: %.2f%n", opcion, valorMedioAlmacen(opcion));
			
			desconexionBD();
			// Me he dado cuenta de que mezclar System.out.println con System.err.println hace que a menudo en la consola la l�nea de err
			// aparezca donde no le corresponde. He intentado usar printf que parec�a que fallaba menos... pero tambi�n pasa a menudo
			System.out.printf("%nDesconexi�n.%n%nFin del programa.%n");
		}catch(ExcepcionPropia ep){ // Capturamos nuestra excepci�n personalizada de forma independiente
			System.out.printf("%nDesconexi�n.%n%nFin del programa.%n");
			System.err.println("ERROR: " + ep.getMessage());
		}
		catch(Exception e){
			try{
				System.out.printf("%nDesconexi�n.%n%nFin del programa.%n");
				desconexionBD();// En caso de error en la ejecuci�n del programa, nos aseguramos de que la conexi�n se cierra
			}catch(Exception o){
					System.err.println("ERROR al desconectar de la BD: " + o.getMessage());
			}
			System.err.println("ERROR inesperado: " + e.getMessage());
		}
	}
}
