package examen;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;

public class Examen {
	
	private static final String URL = "jdbc:postgresql://localhost:5432/pedidos";
	private static final String USUARIO = "postgres";
	private static final String PASSWORD = "1234";
	private static Connection con = null;
	private static Statement statement = null;
	
	/**
	 * Establece la conexion con la BD 
	 * @return true si todo ha ido bien
	 */
	private static boolean conexionBD(){
		try{
			Class.forName("org.postgresql.Driver");
			Connection con = DriverManager.getConnection(URL, USUARIO, PASSWORD);
			statement = con.createStatement();
		}catch(SQLException sqlex){
			System.err.println("SQLException. Error al conectar con la Base de Datos: " + sqlex.getMessage());
			return false;
		}catch(ClassNotFoundException cnFound){
			System.err.println("ClassNotFoundException. No se ha podido encontra el driver para conectar con postgre: " + cnFound.getMessage());
			return false;
		}
		return true;
	}
	/**
	 * Se encarga de desconectar de la BD
	 */
	private static void desconexionBD(){
		try{
			statement.close();
		}catch(SQLException e){
			System.err.println("SQLException. Error al desconectar con la Base de Datos: " + e.getMessage());
		}
	}
	
	/**
	 * Se encarga de mostrar en pantalla el resultado de la consulta ya formateado
	 * @param pedidos
	 */
	private static void muestraPedidosClientes(ArrayList<PedidosClientes> pedidos){
		
		for(int i = 0; i < pedidos.size(); i++){
			
			System.out.println(i + 1 + " " + pedidos.get(i).getCli().getNombre() 
					+ " " + pedidos.get(i).getCli().getCalle() 
					+ " " + pedidos.get(i).getCli().getCiudad());
			
			for(int j = 0; j < pedidos.get(i).getPedidos().size(); j++){
				
				System.out.println("    " + pedidos.get(i).getPedidos().get(j).getFecha() 
						+ " " + pedidos.get(i).getPedidos().get(j).getEmpleado().getId_empleado() 
						+ " " + pedidos.get(i).getPedidos().get(j).getEmpleado().getNombre());
				
				for(int k = 0; k < pedidos.get(i).getPedidos().get(j).getDetalle().size(); k++){
					
					System.out.println("        " + pedidos.get(i).getPedidos().get(j).getDetalle().get(k).getId_producto()
							+ " " + pedidos.get(i).getPedidos().get(j).getDetalle().get(k).getProducto()
							+ " " + pedidos.get(i).getPedidos().get(j).getDetalle().get(k).getCantidad());
				}
				
			}
			
			
			
		}
	}
	
	public static void main(String[] args) {
		
		if(conexionBD()){
			ArrayList<PedidosClientes> datos = Consultas.PedidosClientes(statement);
			
			muestraPedidosClientes(datos);
			ExportarXML.crearXML(datos);
			
			desconexionBD();
		}else{
			System.err.println("ERROR: no se ha podido realizar la conexión.");
		}
		System.out.println("\nFin de programa.");
		
		
		
		
		/*
		System.out.println("Conectando con la BD...");
		conexionBD();
		System.out.println("Conetado!");
		
		ArrayList<PedidosClientes> datos = Consultas.PedidosClientes(statement);
		muestraPedidosClientes(datos);
		System.out.println("Desconectando...");
		desconexionBD();
		System.out.println("Desconectado!");
		*/
	}

}
