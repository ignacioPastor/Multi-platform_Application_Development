package examen;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;

public class Consultas {
	/**
	 * Ejecuta la consulta y crea el ArrayList que devolvemos.
	 * @param con conexion con la BD
	 * @return ArrayList con los datos recogidos de la BD
	 */
	public static ArrayList<PedidosClientes> PedidosClientes(Statement con){
		//System.out.println("1");
		PedidosClientes pedidosClientes = null;
		
		ArrayList<PedidosClientes> list = new ArrayList<>();
		try{
		
			String sql = "select clientes.* , pedidos.* , detalles_pedido.* , empleados.* , productos.* "
					+ "from clientes , pedidos , detalles_pedido , empleados , productos "
					+ "where clientes.id_cliente = pedidos.id_cliente "
					+ "and pedidos.id_empleado = empleados.id_empleado "
					+ "and pedidos.id_pedido = detalles_pedido.id_pedido "
					+ "and detalles_pedido.id_producto = productos.id_producto "
					+ "order by clientes.id_cliente , pedidos.fecha_pedido desc , productos.id_producto ";
			ResultSet rs = con.executeQuery(sql);
			//System.out.println("2");
			while(rs.next()){
				//System.out.println("3");
				if(pedidosClientes != null && pedidosClientes.getCli().getId_cliente() == rs.getInt(1)){
					//System.out.println("4");
					pedidosClientes.setPedido(rs.getString(8), rs.getInt(16), rs.getString(17), rs.getInt(11), rs.getInt(12), rs.getString(13));
				}else{
					//System.out.println("5");
					pedidosClientes = new PedidosClientes(rs.getInt(1), rs.getString(2), rs.getString(3), rs.getString(4));
					//System.out.println("5,2");
					//System.out.println("sice pedidos " + pedidosClientes.getPedidos().size());
					if(pedidosClientes.getPedidos() != null && pedidosClientes.getPedidos().size() > 0
							&& pedidosClientes.getPedidos().get(pedidosClientes.getPedidos().size() - 1).getFecha() == rs.getString(8)){
						System.out.println("6");
						pedidosClientes.getPedidos().get(pedidosClientes.getPedidos().size() - 1).getDetalle().add(new DetallePedido(rs.getInt(16), rs.getString(17), rs.getInt(11)));
					}else{
						//System.out.println("7");
						
						pedidosClientes.setPedido(rs.getString(8), rs.getInt(16), rs.getString(17), rs.getInt(11), rs.getInt(12), rs.getString(13));
					}
					list.add(pedidosClientes);
				}
				
			}
		}catch(SQLException e){
			System.err.println("SQLError: " + e.getMessage());
		}
		return list;
	}
	
}
