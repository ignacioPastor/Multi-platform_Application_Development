/**
 * @author Javier Carrasco
 * Clase PedidosClientes
 * Clase predefina para el examen de los temas 1 y 2 del módulo Acceso a datos
 * de 2º DAM.
 */

package examen;

import java.util.ArrayList;
//---------------------------------------------------------------------------------------------------------------------------------------CLIENTE
/**
 * Almacena la informaci&oacute;n relevante sobre un cliente.
 * @author Javier Carrasco
 * @version 1.00
 * @see PedidosClientes
 */
class Cliente {
	private int id_cliente;
	private String nombre;
	private String calle;
	private String ciudad;
	
	/**
	 * Constructor con par&aacute;metros para Cliente.
	 * @param i Identificador del cliente.
	 * @param n Nombre del cliente.
	 * @param c Calle del cliente.
	 * @param ci Ciudad del cliente.
	 */
	Cliente(int i, String n, String c, String ci){
		id_cliente = i;
		nombre = n;
		calle = c;
		ciudad = ci;
	}
	
	/**
	 * Devuelve el identificador del cliente.
	 * @return Identificador del cliente.
	 */
	public int getId_cliente() {
		return id_cliente;
	}

	/**
	 * Asigna un identificador al cliente.
	 * @param id_cliente Identificador para el cliente.
	 */
	public void setId_cliente(int id_cliente) {
		this.id_cliente = id_cliente;
	}

	/**
	 * Devuelve el nombre del cliente.
	 * @return Nombre del cliente.
	 */
	public String getNombre() {
		return nombre;
	}

	/**
	 * Asigna un nombre al cliente.
	 * @param nombre Nombre para el cliente.
	 */
	public void setNombre(String nombre) {
		this.nombre = nombre;
	}

	/**
	 * Devuelve la calle del cliente.
	 * @return Calle del cliente.
	 */
	public String getCalle() {
		return calle;
	}

	/**
	 * Asigna la calle al cliente.
	 * @param calle Calle del cliente.
	 */
	public void setCalle(String calle) {
		this.calle = calle;
	}

	/**
	 * Devuelve la ciudad del cliente.
	 * @return Ciudad del cliente.
	 */
	public String getCiudad() {
		return ciudad;
	}

	/**
	 * Asigna una ciudad al cliente.
	 * @param ciudad Ciudad para el cliente.
	 */
	public void setCiudad(String ciudad) {
		this.ciudad = ciudad;
	}
}

//--------------------------------------------------------------------------------------------------------------------------------EMPLEADO
/**
 * Almacena la informaci&oacute;n necesaria sobre un empleado.
 * @author Javier Carrasco
 * @version 1.00
 * @see Pedido
 */
class Empleado {
	private int id_empleado;
	private String nombre;
	
	/**
	 * Constructor con par&aacute;metros para Empleado.
	 * @param id Identificador del empleado, ser&aacute; de tipo entero.
	 * @param nom Nombre del empleado.
	 */
	Empleado(int id, String nom){
		id_empleado = id;
		nombre = nom;
	}
	
	/**
	 * Devuelve el identificador del empleado.
	 * @return Identificador del empleado.
	 */
	public int getId_empleado() {
		return id_empleado;
	}

	/**
	 * Asigna un identificador al empleado.
	 * @param id_empleado Identificador para el empleado.
	 */
	public void setId_empleado(int id_empleado) {
		this.id_empleado = id_empleado;
	}

	/**
	 * Devuelve el nombre del empleado.
	 * @return Nombre del empleado.
	 */
	public String getNombre() {
		return nombre;
	}

	/**
	 * Asigna un nombre al empleado.
	 * @param nombre Nombre para el empleado.
	 */
	public void setNombre(String nombre) {
		this.nombre = nombre;
	}
}

//--------------------------------------------------------------------------------------------------------------------------------DETALLE_PEDIDO
/**
 * Almacena la informaci&oacute;n sobre el detalle de los pedidos. Nos permitir&aacute;
 * almacenar la informaci&oacute;n de una l&iacute;nea del pedido.
 * @author Javier Carrasco
 * @version 1.00
 * @see Pedido
 */
class DetallePedido {
	private int id_producto;
	private String producto;
	private int cantidad;
	
	/**
	 * Constructor con par&aacute;metros para DetallePedido.
	 * @param id Identificador del producto.
	 * @param prod Nombre o descripci&oacute;n del producto.
	 * @param cant Cantidad pedida del producto.
	 */
	DetallePedido(int id, String prod, int cant){
		id_producto = id;
		producto = prod;
		cantidad = cant;
	}

	/**
	 * Devuelve el identificador del producto.
	 * @return Identificador del producto.
	 */
	public int getId_producto() {
		return id_producto;
	}

	/**
	 * Asigna un identificador de producto a la l&iacute;nea.
	 * @param id_producto Identificador del producto.
	 */
	public void setId_producto(int id_producto) {
		this.id_producto = id_producto;
	}

	/**
	 * Devuelve el nombre o descripci&oacute;n del producto.
	 * @return Nombre o descripci&oacute;n del producto.
	 */
	public String getProducto() {
		return producto;
	}

	/**
	 * Asigna el nombre o descripci&oacute;n del producto.
	 * @param producto Nombre o descripci&oacute;n del producto.
	 */
	public void setProducto(String producto) {
		this.producto = producto;
	}

	/**
	 * Devuelve la cantidad de producto.
	 * @return Cantidad de producto.
	 */
	public int getCantidad() {
		return cantidad;
	}

	/**
	 * Asigna la cantidad de producto.
	 * @param cantidad Cantidad de producto.
	 */
	public void setCantidad(int cantidad) {
		this.cantidad = cantidad;
	}
}
//-----------------------------------------------------------------------------------------------------------------------------------------PEDIDO-
/**
 * Almacena la informaci&oacute;n b&aacute;sica sobre los pedidos, tambi&eacute;n se
 * incluyen las l&iacute;neas de pedido (DetallePedido). En esta clase, se utilizar&aacute;
 * la variable privada <b>empleado</b> de clase Empleado para almacenar la informaci&oacute;n.
 * Para el <b>detalle</b> del pedido se utilizar&aacute; un ArrayList&lt;DetallePedido&gt; como
 * variable privada.
 * @author Javier Carrasco
 * @version 1.00
 * @see DetallePedido
 * @see PedidosClientes
 * @see ArrayList
 */
class Pedido {
	private String fecha;
	private Empleado empleado;
	/**
	 * Contiene las l&iacute;neas de detalle de los pedidos.
	 */
	private ArrayList<DetallePedido> detalle = new ArrayList<DetallePedido>();
	
	/**
	 * Constructor con par&aacute;metros de Pedido.
	 * @param fecha Fecha del pedido (no se utilizar&aacute; la clase Date).
	 * @param id_pro Identificador del producto.
	 * @param prod Nombre o descripci&oacute;n del producto.
	 * @param cant Cantidad del producto.
	 * @param id_emp Identificador del empleado.
	 * @param nombre Nombre del empleado.
	 * @see Empleado
	 * @see DetallePedido
	 */
	Pedido(String fecha, int id_pro, String prod, int cant, int id_emp, String nombre){
		this.fecha = fecha;
		empleado = new Empleado(id_emp,nombre);
		detalle.add(new DetallePedido(id_pro, prod, cant));
	}
	
	/**
	 * Devuelve los datos del empleado.
	 * @return Datos de empleado
	 * @see Empleado
	 */
	public Empleado getEmpleado() {
		return empleado;
	}

	/**
	 * Se asigna los datos del empleado.
	 * @param id Identificador del empleado.
	 * @param nom Nombre del empleado.
	 * @see Empleado
	 */
	public void setEmpleado(int id, String nom) {
		empleado = new Empleado(id, nom);
	}

	/**
	 * Devuelve la fecha en formato String (AAAA-MM-DD) seg&uacute;n la base de datos
	 * PostgreSQL. No se utiliza la clase Date.
	 * @return Fecha del pedido.
	 */
	public String getFecha() {
		return fecha;
	}
	
	/**
	 * Se asigna la fecha del pedido en formato String (AAAA-MM-DD) seg&uacute;n
	 * la base de datos PostgreSQL. No se utiliza la clase Date.
	 * @param fecha Fecha del pedido.
	 */
	public void setFecha(String fecha) {
		this.fecha = fecha;
	}
	
	/**
	 * Devuelve el ArrayList con el detalle del pedido.
	 * @return Detalle del pedido.
	 * @see DetallePedido
	 */
	public ArrayList<DetallePedido> getDetalle() {
		return detalle;
	}
	
	/**
	 * Se a&ntilde;ade un nuevo elemento de detalle de pedido al ArrayList de DetallePedido,
	 * se utilizar&aacute; el m&eacute;todo add de ArrayList.
	 * @param id Identificador del producto.
	 * @param prod Nombre o descripci&oacute;n del producto.
	 * @param cant Cantidad de producto.
	 */
	public void setDetalle(int id, String prod, int cant) {
		detalle.add(new DetallePedido(id, prod, cant));
	}
}
//---------------------------------------------------------------------------------------------------------------------------------PEDIDOS_CLIENTES
/**
 * Clase principal para el examen. Se utilizar&aacute; para almacener la 
 * informaci&oacute;n de los pedidos agrupados por cliente. Esta clase contiene una variable
 * privada de tipo Cliente encargada de almacenar la informaci&oacute;n del cliente.
 * @author Javier Carrasco
 * @see Pedido
 * @version 1.00
 */
public class PedidosClientes {
	private Cliente cli;
	/**
	 * ArrayList&lt;Pedido&gt; que contiene la informaci&oacute;n sobre
	 * los pedidos del cliente.
	 */
	protected ArrayList<Pedido> pedidos = new ArrayList<Pedido>();
	
	/**
	 * Constructor con par&aacute;metros.
	 * @param id Identificador del cliente.
	 * @param nombre Nombre del cliente.
	 * @param calle Calle del cliente
	 * @param ciudad Ciudad del cliente.
	 * @see Cliente
	 */
	PedidosClientes(int id, String nombre, String calle, String ciudad){
		cli = new Cliente(id, nombre, calle, ciudad);
	}
	
	/**
	 * Obtiene el cliente.
	 * @return Devuelve el objeto Cliente con los datos de &eacute;ste.
	 * @see Cliente
	 */
	public Cliente getCli() {
		return cli;
	}
	
	/**
	 * Asigna los datos del cliente.
	 * @param id Identificador del cliente.
	 * @param nombre Nombre del cliente.
	 * @param calle Calle del cliente.
	 * @param ciudad Ciudad del cliente.
	 * @see Cliente
	 */
	public void setCli(int id, String nombre, String calle, String ciudad) {
		cli = new Cliente(id, nombre, calle, ciudad);
	}
	
	/**
	 * Devuelve el ArrayList&lt;Pedido&gt; con los datos de los pedidos.
	 * @return Datos de pedidos.
	 * @see Pedido
	 */
	public ArrayList<Pedido> getPedidos() {
		return pedidos;
	}
	
	/** 
	 * Se a&ntilde;ade un nuevo pedido al ArrayList&lt;Pedido&gt;,
	 * se utilizar&aacute; el m&eacute;todo add de ArrayList, adem&aacute;s
	 * se a&ntilde;ade la l&iacute;nea de detalle.
	 * @param fecha Fecha del pedido.
	 * @param id_p Identificador del producto.
	 * @param prod Nombre o descripci&oacute;n del producto.
	 * @param cant Cantidad de producto.
	 * @param id_emp Identificador de empleado.
	 * @param nombre Nombre de empleado.
	 * @see Pedido
	 */
	public void setPedido(String fecha, int id_p, String prod, int cant, int id_emp, String nombre) {
		pedidos.add(new Pedido(fecha, id_p, prod, cant, id_emp, nombre));
	}
}
