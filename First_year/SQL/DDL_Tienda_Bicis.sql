-- IgnacioPastorPadilla_BasesDatos_DAM_Semi_GrupoA
-- Practica_Final_2oTrimestre
-- DDL


create table empleados (
    dni varchar2(20) not null,
    nombre varchar2(80),
    antiguedad number(2),
    experiencia varchar2(50),
    dni_supervisor varchar2(20),
constraint pk_empleados primary key (dni),
constraint fk_empleados_empleados foreign key (dni_supervisor)
    references empleados (dni));


create table mecanico( (
    dni varchar2(20) not null,
    grado_hab varchar2(30),
constraint pk_mecanico primary key(dni),
constraint fk_mecanico_dni foreign key(dni)
    references empleados (dni));


create table vendedor(
    dni varchar2(20) not null,
    rating varchar2(20)
    grado_fid number(2),
constraint pk_vendedor primary key(dni),
constraint fk_vendedor_empleados foreign key (dni)
    references empleados (dni));


create table producto(
    codigo varchar2(5) not null,
    tipo varchar2(20),
    descripcion varchar2(60),
    dni varchar2(20) not null,
constraint pk_producto primary key(codigo),
constraint fk_producto_empleados foreign key(dni)
    references empleados (dni));


create table club(
    codigo varchar2(5) not null,
    nombre varchar2(60),
    localidad varchar2(50),
constraint pk_club primary key (codigo));


create table cliente(
    dni varchar2(20) not null,
    nombre varchar2(60),
    direccion varchar2(60),
    productos number(4),
    codigo varchar2(5),
constraint pk_cliente primary key (dni),
constraint fk_cliente_club foreign key (codigo)
    references club (codigo));


create table comprar(
    dni varchar2(20) not null,
    codigo varchar2(5) not null,
constraint pk_comprar primary key (dni, codigo),
constraint fk_comprar_cliente foreign key (dni)
    references cliente (dni),
constraint fk_comprar_producto foreign key (codigo)
    references producto (codigo));


create table proveedor(
    nif varchar2(20) not null,
    nombre varchar2(60),
    producto_principal varchar2(50),
constraint pk_proveedor primary key (nif));


create table proveer(
    nif varchar2(20) not null,
    codigo varchar2(5) not null,
constraint pk_proveer primary key (nif, codigo),
constraint fk_proveer_proveedor foreign key (nif)
    references proveedor (nif),
constraint fk_proveer_producto foreign key (codigo)
    references producto (codigo));


create table marca(
    nif varchar2(20) not null,
    anyo_trabajo number(2),
    porcentaje number(3),
constraint pk_marca primary key (nif));


create table grupo(
    codigo varchar2(5) not null,
    fabricante varchar2(50),
    modelo varchar2(20),
    gama varchar2(20),
    peso number(5),
    material varchar2(30),
    anyo_fabricacion number(4),
constraint pk_grupo primary key (codigo));


create table sistema_electronico(
    codigo varchar2(5) not null,
    autonomia number(4),
    colocacion varchar(20),
constraint pk_sistema_electronico primary key (codigo),
constraint fk_sistema_electronico_grupo foreign key (codigo)
    references grupo (codigo));


create table bicicleta(
    num_serie varchar2(30) not null,
    diametro number(2),
    codigo varchar2(5) not null,
constraint pk_bicicleta primary key (num_serie),
constraint fk_bicicleta_grupo foreign key (codigo)
	references grupo (codigo));


create table distribuir(
    num_serie varchar2(30) not null,
    nif varchar2(20) not null,
constraint pk_distribuir primary key (num_serie, nif),
constraint fk_distribuir_bicicleta foreign key (num_serie)
    references bicicleta (num_serie),
constraint fk_distribuir_marca foreign key (nif)
    references marca (nif));


create table infantil(
    num_serie varchar2(30) not null,
    ruedines varchar2(2),
    edad number(2),
constraint pk_infantil primary key (num_serie),
constraint fk_infantil_bicicleta foreign key (num_serie)
    references bicicleta (num_serie));


create table montanya(
    num_serie varchar2(30) not null,
    talla number(2),
    tipo_suspension varchar2(50),
    material_cuadro varchar2(20),
constraint pk_montanya primary key (num_serie),
constraint fk_montanya_bicicleta foreign key (num_serie)
    references bicicleta (num_serie));


create table carretera(
    num_serie varchar2(30) not null,
    talla number(2),
    peso number,
    disenyo_cuadro varchar2(30),
    material_cuadro varchar2(20),
constraint pk_carretera primary key (num_serie),
constraint fk_carretera_bicicleta foreign key (num_serie)
    references bicicleta (num_serie));


create table comprar_bici(
    dni_empleados varchar2(20) not null,
    num_serie varchar2(30) not null,
    dni_cliente varchar2(20) not null,
    fecha date,
    importe number,
constraint pk_comprar_bici primary key
    (dni_empleados, num_serie, dni_cliente, fecha),
constraint fk_comprar_bici_empleados foreign key (dni_empleados)
    references empleados (dni),
constraint fk_comprar_bici_bicicleta foreign key (num_serie)
    references bicicleta (num_serie),
constraint fk_comprar_bici_cliente foreign key (dni_cliente)
    references cliente (dni));


create table descuento(
    numero number(4) not null,
    descripcion varchar2(60),
constraint pk_descuento primary key (numero));


create table disponer(
    numero number(4) not null,
    dni_empleados varchar2(20) not null,
    num_serie varchar2(30) not null,
    dni_cliente varchar2(20) not null,
    fecha date not null,
constraint pk_disponer primary key
(numero, dni_empleados, num_serie, dni_cliente, fecha),
constraint fk_disponer_descuento foreign key (numero)
    references descuento (numero),
constraint fk_disponer_comprar_bici foreign key 
    (dni_empleados, num_serie, dni_cliente, fecha) references
    comprar_bici (dni_empleados, num_serie, dni_cliente, fecha));


create table equipacion_oficial(
    numero number(10) not null,
    calidad varchar2(20),
    temporada varchar2(20),
    codigo varchar2(5) not null,
constraint pk_equipacion_oficial primary key (numero),
constraint fk_equipacion_oficial_cliente foreign key (codigo)
    references club (codigo));