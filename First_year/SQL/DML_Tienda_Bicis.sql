-- IgnacioPastorPadilla_BasesDatos_DAM_Semi_GrupoA
-- Practica_Final_2oTrimestre
-- DML



insert into empleados (dni, nombre, antiguedad, experiencia)
values ('001', 'Daniel Martinez', 12, 'comercial, montaje');

insert into empleados (dni, nombre, antiguedad, experiencia, dni_supervisor)
values ('002', 'Marcos Padilla', 2, 'montaje','001');

insert into empleados (dni, nombre, antiguedad, experiencia, dni_supervisor)
values ('003', 'Francisco Libertador', 5, 'mantenimiento, venta','001');

insert into empleados (dni, nombre, antiguedad, experiencia, dni_supervisor)
values ('004', 'Rodolfo Garcia', 3, 'montaje, venta','001');

insert into empleados (dni, nombre, antiguedad, experiencia, dni_supervisor)
values ('005', 'Hermenigildo Hernandez', 9, 'mantenimiento, venta','001');

insert into empleados (dni, nombre, antiguedad, experiencia, dni_supervisor)
values ('006', 'Marcos Marquez', 1, 'montaje, alineacion ruedas', '001');


-- Tabla mecanico

insert into mecanico (dni, grado_hab)
values ('002', 'Alto');

insert into mecanico (dni, grado_hab)
values ('004', 'Medio');

insert into mecanico (dni, grado_hab)
values ('006', 'Alto');


-- Tabla vendedor

insert into vendedor (dni, rating, grado_fid)
values ('001', 'Alto', 9);

insert into vendedor (dni, rating, grado_fid)
values ('003', 'Medio', 8);

insert into vendedor (dni, rating, grado_fid)
values ('005', 'Medio', 6);


-- Tabla producto

insert into producto (codigo, tipo, descripcion, dni)
values ('A032', 'Casco', 'Casco Giro gama alta', '001');

insert into producto (codigo, tipo, descripcion, dni)
values ('A033', 'Bidón', 'Bidón Camelback con Membrana', '003');

insert into producto (codigo, tipo, descripcion, dni)
values ('A123', 'Maillot', 'Maillot Scott gama media', '006');

insert into producto (codigo, tipo, descripcion, dni)
values ('A043', 'Zapatillas MTB', 'Zapatillas Suela Carbono', '005');

insert into producto (codigo, tipo, descripcion, dni)
values ('A783', 'Guantes', 'Guantes Fizi invierno', '001');


-- Tabla club

insert into club (codigo, nombre, localidad)
values ('C123', 'Marcos', 'San Vicente del Raspeig');

insert into club (codigo, nombre, localidad)
values ('C234', 'Ruben', 'Elda');

insert into club (codigo, nombre, localidad)
values ('C345', 'Marta', 'Aspe');

insert into club (codigo, nombre, localidad)
values ('C456', 'Jose', 'San Vicente del Raspeig');

insert into club (codigo, nombre, localidad)
values ('C567', 'Hernan', 'Alicante')


-- Tabla cliente

insert into cliente (dni, nombre, direccion, productos, codigo)
values ('101', 'Marta', 'C/Aviador, Alicante', 5, 'C345');

insert into cliente (dni, nombre, direccion, productos)
values ('102', 'Mario', 'C/Castelar',4);

insert into cliente (dni, nombre, productos)
values ('103', 'Marcos', 3);

insert into cliente (dni, nombre, direccion, productos, codigo)
values ('104', 'Hernan', 'Av.Estacion', 19, 'C567');

insert into cliente (dni, nombre, productos)
values ('105', 'Rubén', 1);


-- Tabla comprar

insert into comprar (dni, codigo)
values ('101', 'A032');

insert into comprar (dni, codigo)
values ('102', 'A033');

insert into comprar (dni, codigo)
values ('103', 'A123');

insert into comprar (dni, codigo)
values ('104', 'A043');

insert into comprar (dni, codigo)
values ('105', 'A783');


-- Tabla proveedor

insert into proveedor (nif, nombre, producto_principal)
values ('E01', 'Componentes SL', 'Grupos');

insert into proveedor (nif, nombre, producto_principal)
values ('E02', 'Ciclismo SA', 'Ropa');

insert into proveedor (nif, nombre, producto_principal)
values ('E03', 'A Rueda', 'Ruedas');

insert into proveedor (nif, nombre, producto_principal)
values ('E04', 'Suministros Martinez', 'Piezas repuesto');

insert into proveedor (nif, nombre, producto_principal)
values ('E05', 'Comercios Villar', 'Bicicletas');


-- Tabla proveer

insert into proveer (nif, codigo)
values ('E01', 'A032');

insert into proveer (nif, codigo)
values ('E02', 'A033');

insert into proveer (nif, codigo)
values ('E03', 'A123');

insert into proveer (nif, codigo)
values ('E04', 'A043');

insert into proveer (nif, codigo)
values ('E05', 'A783');


-- Tabla marca

insert into marca (nif, anyo_trabajo, porcentaje)
values ('I01', 3, 10);

insert into marca (nif, anyo_trabajo, porcentaje)
values ('I02', 2, 12);

insert into marca (nif, anyo_trabajo, porcentaje)
values ('I03', 1, 8);

insert into marca (nif, anyo_trabajo, porcentaje)
values ('I04', 6, 15);

insert into marca (nif, anyo_trabajo, porcentaje)
values ('I05', 5, 12);


-- Tabla grupo

insert into grupo (codigo, fabricante, modelo, gama, peso, material, anyo_fabricacion)
values ('O01', 'Shimano', '105', 'Media', 1500, 'Aluminio', 2015);

insert into grupo (codigo, fabricante, modelo, gama, peso, material, anyo_fabricacion)
values ('O02', 'Campagnolo', 'Centaur', 'Media', 1200, 'Aluminio', 2016);

insert into grupo (codigo, fabricante, modelo, gama, peso, material, anyo_fabricacion)
values ('O03', 'Sram', '105', 'Force', 1300, 'Aluminio', 2016);

insert into grupo (codigo, fabricante, modelo, gama, peso, material, anyo_fabricacion)
values ('O04', 'Shimano', 'Dura-Ace', 'Alta', 1000, 'Carbono', 2015);

insert into grupo (codigo, fabricante, modelo, gama, peso, material, anyo_fabricacion)
values ('O05', 'Campagnolo', 'Veloce', 'Media', 1400, 'Aluminio', 2016);

insert into grupo (codigo, fabricante, modelo, gama, peso, material, anyo_fabricacion)
values ('O06', 'Sram', 'Red', 'Alta', 1100, 'Carbono', 2016);


-- Tabla sistema_electronico

insert into sistema_electronico (codigo, autonomia, colocacion)
values ('O04', 100, 'Integrado');

insert into sistema_electronico (codigo, autonomia, colocacion)
values ('O06', 90, 'Integrado');

insert into sistema_electronico (codigo, autonomia, colocacion)
values ('O02', 60, 'Externo-Acoplado'); 


-- Tabla bicicleta

insert into bicicleta (num_serie, diametro, codigo)
values ('U01', 26, 'O04');

insert into bicicleta (num_serie, diametro, codigo)
values ('U02', 26, 'O06');

insert into bicicleta (num_serie, diametro, codigo)
values ('U03', 27, 'O03');

insert into bicicleta (num_serie, diametro, codigo)
values ('U04', 29, 'O01');

insert into bicicleta (num_serie, diametro, codigo)
values ('U05', 26, 'O02');

insert into bicicleta (num_serie, diametro, codigo)
values ('U06', 18, 'O01');

insert into bicicleta (num_serie, diametro, codigo)
values ('U07', 16, 'O01');

insert into bicicleta (num_serie, diametro, codigo)
values ('U08', 19, 'O02');

insert into bicicleta (num_serie, diametro, codigo)
values ('U09', 27, 'O06');


-- Tabla distribuir

insert into distribuir (num_serie, nif)
values ('U01', 'I01');

insert into distribuir (num_serie, nif)
values ('U02', 'I02');

insert into distribuir (num_serie, nif)
values ('U03', 'I03');

insert into distribuir (num_serie, nif)
values ('U04', 'I04');

insert into distribuir (num_serie, nif)
values ('U05', 'I05');


-- Tabla infantil

insert into infantil (num_serie, ruedines, edad)
values ('U08', 'No', 12);

insert into infantil (num_serie, ruedines, edad)
values ('U07', 'Si', 6);

insert into infantil (num_serie, ruedines, edad)
values ('U06', 'No', 8);


-- Tabla montanya

insert into montanya (num_serie, talla, tipo_suspension, material_cuadro)
values ('U09', 56, 'Doble', 'Aluminio');

insert into montanya (num_serie, talla, tipo_suspension, material_cuadro)
values ('U04', 54, 'Semi-Rigida', 'Carbono');

insert into montanya (num_serie, talla, tipo_suspension, material_cuadro)
values ('U05', 52, 'Doble', 'Carbono');


-- Tabla carretera

insert into carretera (num_serie, talla, peso, disenyo_cuadro, material_cuadro)
values ('U01', 56, 7.3, 'Gran Fondo', 'Carbono');

insert into carretera (num_serie, talla, peso, disenyo_cuadro, material_cuadro)
values ('U02', 54, 7.1, 'Escaladora', 'Carbono');

insert into carretera (num_serie, talla, peso, disenyo_cuadro, material_cuadro)
values ('U03', 52, 8, 'Aero', 'Carbono');


-- Tabla comprar_bici

insert into comprar_bici (dni_empleados, num_serie, dni_cliente, fecha, importe)
values ('001', 'U01', '101', '12/05/2015', 1200);

insert into comprar_bici (dni_empleados, num_serie, dni_cliente, fecha, importe)
values ('001', 'U05', '102', '12/12/2015', 2000);

insert into comprar_bici (dni_empleados, num_serie, dni_cliente, fecha, importe)
values ('003', 'U08', '103', '05/05/2016', 200);

insert into comprar_bici (dni_empleados, num_serie, dni_cliente, fecha, importe)
values ('003', 'U02', '104', '18/04/2016', 2300);

insert into comprar_bici (dni_empleados, num_serie, dni_cliente, fecha, importe)
values ('005', 'U04', '105', '13/03/2016', 3000);


-- Tabla descuento

insert into descuento (numero, descripcion)
values ( 111, '10% en ropa');

insert into descuento (numero, descripcion)
values ( 112, '10% en calzado');

insert into descuento (numero, descripcion)
values ( 113, '15% en bicicleta');

insert into descuento (numero, descripcion)
values ( 114, '10% material deportivo');

insert into descuento (numero, descripcion)
values ( 115, '20% en el siguiente casco');


-- Tabla disponer

insert into disponer (numero, dni_empleados, num_serie, dni_cliente, fecha)
values ( 111, '001', 'U01', '101', '12/05/2015');

insert into disponer (numero, dni_empleados, num_serie, dni_cliente, fecha)
values ( 112, '001','U05', '102', '12/12/2015');

insert into disponer (numero, dni_empleados, num_serie, dni_cliente, fecha)
values ( 113, '003', 'U08', '103', '05/05/2016');

insert into disponer (numero, dni_empleados, num_serie, dni_cliente, fecha)
values ( 114, '003', 'U02', '104', '18/04/2016');

insert into disponer (numero, dni_empleados, num_serie, dni_cliente, fecha)
values ( 115, '005', 'U04', '105', '13/03/2016');


-- Tabla equipacion_oficial

insert into equipacion_oficial (numero, calidad, temporada, codigo)
values ( 221, 'Alta', 'Verano', 'C123');

insert into equipacion_oficial (numero, calidad, temporada, codigo)
values ( 222, 'Alta', 'Verano', 'C234');

insert into equipacion_oficial (numero, calidad, temporada, codigo)
values ( 223, 'Media', 'Invierno', 'C345');

insert into equipacion_oficial (numero, calidad, temporada, codigo)
values ( 224, 'Media', 'Invierno', 'C456');

insert into equipacion_oficial (numero, calidad, temporada, codigo)
values ( 225, 'Alta', 'Primavera', 'C567');













