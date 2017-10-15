--Ignacio Pastor Padilla - Examen AD
CREATE OR REPLACE FUNCTION ClientesProducto (producto VARCHAR)
RETURNS SETOF clientes AS
$$
DECLARE datos clientes;
BEGIN
FOR datos IN select distinct clientes.* 
		from clientes, pedidos, productos, detalles_pedido
		where clientes.id_cliente = pedidos.id_cliente
		and pedidos.id_pedido = detalles_pedido.id_pedido
		and detalles_pedido.id_producto = productos.id_producto
		and UPPER(productos.nombre) like UPPER('manza%')
LOOP
RETURN NEXT datos;
END LOOP;
END;
$$
LANGUAGE plpgsql;







