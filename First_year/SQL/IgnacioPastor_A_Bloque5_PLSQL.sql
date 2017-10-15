--IgnacioPastor_A_Bloque5_PLSQL

/*
1- Realiza un cursor sobre la tabla Bancos y sucursales,
donde indiques el nombre del banco y el de cada sucursal.
Hazlo con Fecth y con FOR.
*/

DECLARE
    CURSOR nom_banc_sucur is
    select nombre_banc, nombre_suc
    from bancos ban, sucursales su
    where ban.cod_banco = su.cod_banco;
    v_cursor nom_banc_sucur%ROWTYPE;
BEGIN
    OPEN nom_banc_sucur;
    FETCH nom_banc_sucur into v_cursor;
    WHILE nom_banc_sucur%FOUND LOOP
        dbms_output.put_line(v_cursor.nombre_banc || ', ' || v_cursor.nombre_suc);
        FETCH nom_banc_sucur into v_cursor;
    END LOOP;
    CLOSE nom_banc_sucur;
END;

DECLARE
    CURSOR nom_banc_sucur is
    select nombre_banc, nombre_suc
    from bancos ban, sucursales su
    where ban.cod_banco = su.cod_banco;
    v_cursor nom_banc_sucur%ROWTYPE;
BEGIN
    FOR v_cursor IN nom_banc_sucur LOOP
        dbms_output.put_line(v_cursor.nombre_banc || ', ' || v_cursor.nombre_suc);
    END LOOP;
END;


/*
2- Crea un campo en la tabla Cuenta, llamándolo “Rentable”,
recorre la tabla Cuenta y si el haber es mayor que el debe
actualizar a S de los contrario a N, sumando las rentables
y las no rentables y sacándolas por pantalla al final.
Usa ROWID para hacerlo (identificador único para cada registros de una BD).
*/
alter table cuentas add rentable varchar2(10);


DECLARE
    CURSOR rentabilidad IS
    SELECT rowid from cuentas where saldo_haber > saldo_debe;
    vContadorRentables number;
    vNoRentables number;
BEGIN
    FOR v_rentabilidad IN rentabilidad LOOP
            UPDATE cuentas
                set rentable = 'S'
                where rowid = v_rentabilidad.rowid;
                vContadorRentables := rentabilidad%rowcount;
    END LOOP;
    UPDATE cuentas
        set rentable = 'N'
        where rentable is null;
    select count(*) into vNoRentables from cuentas;
    vNoRentables := vNoRentables - vContadorRentables;
    dbms_output.put_line('Nº cuentas rentables: '||vContadorRentables||'. Nº cuentas no rentables: '||vNoRentables);
END;

--OTRA FORMA DE HACERLO
DECLARE
    CURSOR rentabilidad IS
    SELECT cod_banco, cod_sucur, num_cta from cuentas where saldo_haber > saldo_debe;
    vContadorRentables number;
    vNoRentables number;
BEGIN
    FOR v_rentabilidad IN rentabilidad LOOP
            UPDATE cuentas
                set rentable = 'S'
                where v_rentabilidad.cod_banco = cod_banco
                and v_rentabilidad.cod_sucur = cod_sucur
                and v_rentabilidad.num_cta = num_cta;
            vContadorRentables := rentabilidad%rowcount;
    END LOOP;
    UPDATE cuentas
        set rentable = 'N'
        where rentable is null;
    select count(*) into vNoRentables from cuentas;
    vNoRentables := vNoRentables - vContadorRentables;
    dbms_output.put_line('Nº cuentas rentables: '||vContadorRentables||'. Nº cuentas no rentables: '||vNoRentables);
END;



-- 3- Mira de realizar lo anterior con una UPDATE Masiva.

BEGIN
    update cuentas
        set rentable = 'S'
        where saldo_haber > saldo_debe;
    update cuentas
        set rentable = 'N'
        where saldo_debe >= saldo_haber;
END;


-- 4- Utiliza un cursor y un bucle LOOP simple para recuperar
-- y mostrar los datos de todos Los productos.
--Indica al final cuantos productos hay.

DECLARE
    CURSOR cursorProductos IS
        select * from productos;
    vCursor cursorProductos%rowtype;
    vContador number;
BEGIN
    OPEN cursorProductos;
    LOOP
        FETCH cursorProductos into vCursor;
        EXIT WHEN cursorProductos%NOTFOUND;
        dbms_output.put_line('Código: '||vCursor.codigo||'. Descripción: '||vCursor.descripcion||'. Coste: '||vCursor.coste||'.');
        vContador := cursorProductos%ROWCOUNT;
    END LOOP;
    CLOSE cursorProductos;
    dbms_output.put_line('En total hay '||vContador||' prodcutos.');
END;


-- 5- Usa el cursor del loop directamente en el bucle

DECLARE
    vContador number := 0;
BEGIN
    FOR vProductos in (select * from productos) LOOP
        dbms_output.put_line('Código: '||vProductos.codigo||'. Descripción: '||vProductos.descripcion||'. Coste: '||vProductos.coste||'.');
        vContador := vContador + 1;
    END LOOP;
    dbms_output.put_line('En total hay '||vContador||' prodcutos.');
END;


-- 6- Usa ahora un while

DECLARE
    CURSOR cursorProductos is
        select * from productos;
    vContador number;
    vCursor cursorProductos%ROWTYPE;
BEGIN
    OPEN cursorProductos;
    FETCH cursorProductos into vCursor;
    WHILE cursorProductos%FOUND LOOP
        dbms_output.put_line('Código: '||vCursor.codigo||'. Descripción: '||vCursor.descripcion||'. Coste: '||vCursor.coste||'.');
        vContador := cursorProductos%ROWCOUNT;
        FETCH cursorProductos into vCursor;
    END LOOP;
    CLOSE cursorProductos;
    dbms_output.put_line('En total hay '||vContador||' prodcutos.');
END;


-- 7. Dadas las siguientes tablas:

create table alumnos7(
    numMatricula number not null,
    nombre varchar2(15),
    apellidos varchar2(30),
    titulacion varchar2(15),
    precioMatricula number,
constraint pk_alumnos7 primary key (numMatricula)
);

create table alumnosinf(
    idmatricula number not null,
    nombre_apellidos varchar2(50),
    precio number,
constraint pk_alumnosinf primary key (idmatricula)
);

insert into alumnos7 (numMatricula, nombre, apellidos, titulacion, preciomatricula)
values (1, 'Juan', 'Álvarez', 'Administrativo', 1000);

insert into alumnos7 (numMatricula, nombre, apellidos, titulacion, preciomatricula)
values (2, 'José', 'Jiménez', 'Informática', 1200);

insert into alumnos7 (numMatricula, nombre, apellidos, titulacion, preciomatricula)
values (3, 'María', 'Pérez', 'Administrativo', 1000);

insert into alumnos7 (numMatricula, nombre, apellidos, titulacion, preciomatricula)
values (4, 'Elena', 'Martínez', 'Informática', 1200);


/*
Construya un cursor que inserte sólo los alumnos de informática en la tabla
ALUMNOSINF, teniendo en cuenta la estructura de esta tabla, así por ejemplo,
debe tener en cuenta que el atributo nombre_apellidos resulta de la concatenación
de los atributos nombre y apellidos. Antes de la inserción de cada tupla en la
tabla ALUMNOSINF debe mostrar por pantalla el nombre y el apellido
que va a insertar.
*/

DECLARE
    CURSOR cursorAlu IS
        select * from alumnos7 where titulacion = 'Informática';
    vCursor cursorAlu%ROWTYPE;
BEGIN
    OPEN cursorAlu;
    FETCH cursorAlu into vCursor;
    WHILE cursorAlu%FOUND LOOP
        dbms_output.put_line('Se procede a insertar: idmatricula: '||vCursor.numMatricula||', nombre_apellidos: '||vCursor.nombre||' '||vCursor.apellidos||', precio: '||vCursor.preciomatricula);
        insert into alumnosinf (idmatricula, nombre_apellidos, precio)
        values (vCursor.numMatricula, vCursor.nombre||' '||vCursor.apellidos, vCursor.preciomatricula);
        FETCH cursorAlu into vCursor;
    END LOOP;
    CLOSE cursorAlu;
END;


-- 8. Dadas las siguientes tablas:

create table tabla_departamento(
    num_depart number(2) not null,
    nombre_depart varchar2(15),
    ubicación varchar2(15),
    presupuesto number(10,2),
    media_salarios number(10,2),
    total_salarios number(10,2),
constraint pk_tabla_departamentos primary key (num_depart)
);

create table tabla_empleado(
    num_empleado number(4) not null,
    nombre_empleado varchar2(25),
    categoria varchar2(10),
    jefe number(4),
    fecha_contratacion date,
    salario number(7,2),
    comision number(7,2),
    num_depart number(2),
constraint pk_tabla_empleado primary key (num_empleado),
constraint fk_empleado_empleado foreign key (jefe)
    references tabla_empleado (num_empleado),
constraint fk_empleado_departamento foreign key (num_depart)
    references tabla_departamento (num_depart)
);

/*
a) Construya un bloque que calcule el presupuesto del departamento para el año
próximo. Se almaceraná el mismo en la tabla Tabla_Departamento en la columna
Presupuesto. Hay que tener en cuenta las siguientes subidas de sueldo:
Gerente +20%
Comercial +15%
Los demás empleados que no estén en ninguna de las categorías anteriores se
les subirá el sueldo un 10%.
*/

BEGIN
        update tabla_empleado
            set salario = salario*1.2
            where categoria = 'Gerente';
        update tabla_empleado
            set salario = salario*1.15
            where categoria = 'Comercial';
        update tabla_empleado
            set salario = salario*1.1
            where categoria != 'Comercial'
                and categoria != 'Gerente';
END;

/*
b) Construya un bloque que actualice el campo Total_Salarios y el campo
Media_Salarios de la Tabla_Departamento, siendo el total la suma del salario
de todos los empleados, igualmente con la media. Para ello:
-Cree un cursor C1, que devuelva todos los departamentos
-Cree un cursor C2, que devuelva el salario y el código de todos los
empleados de su departamento
*/

DECLARE
    CURSOR c1 is
        select num_depart from tabla_departamento;
    CURSOR c2 (vC1 tabla_departamento.num_depart%TYPE) is
        select emp.salario, emp.num_empleado
        from tabla_empleado emp
        where emp.num_depart = vC1;
    vTotalSalarios number;
    vContadorEmpleados number;
BEGIN
    FOR i IN c1 LOOP
    update tabla_departamento dep --Ponemos el total salarios que había a 0
    set total_salarios = 0
    where dep.num_depart = i.num_depart;
        FOR j IN c2(i.num_depart) LOOP
            update tabla_departamento dep--vamos sumando el salario de cada empleado de ese departamento
                set dep.total_salarios = dep.total_salarios + j.salario
                where dep.num_depart = i.num_depart;
            select total_salarios into vTotalSalarios--vamos metiendo el salario del empleado en una variable
                from tabla_departamento dep
                where dep.num_depart = i.num_depart;
                vContadorEmpleados := c2%ROWCOUNT;
            update tabla_departamento dep --dividimos el total de salarios entre el número de empleados y actualizamos salario medio
                set media_salarios = (vTotalSalarios / vContadorEmpleados)
                where dep.num_depart = i.num_depart;
        END LOOP;
    END LOOP;
END;

--PRIMER INTENTO CHUNGO DE HACER EL EJERCICIO
DECLARE
    CURSOR cursorSalarios is
    select distinct num_depart from tabla_departamento;
    vSumSalarioNuevo number;
    vMediaSalarioNuevo number;
    vSalarioAnterior number;
    incrementoSalarios number;
    numPersonasDepartamento number;
BEGIN
    update tabla_empleado
            set salario = salario*1.2
            where categoria = 'Gerente';
        update tabla_empleado
            set salario = salario*1.15
            where categoria = 'Comercial';
        update tabla_empleado
            set salario = salario*1.1
            where categoria != 'Comercial'
                and categoria != 'Gerente';
    FOR i IN cursorSalarios LOOP
        select total_salarios into vSalarioAnterior
            from tabla_departamento dep
            where dep.num_depart = i.num_depart; 
        select sum(salario) into vSumSalarioNuevo
            from tabla_empleado emp
            where emp.num_depart = i.num_depart;
        update tabla_departamento dep
            set total_salarios = vSumSalarioNuevo
            where dep.num_depart = i.num_depart;
        select count(*) into numPersonasDepartamento
            from tabla_departamento dep
            where dep.num_depart = i.num_depart;
        vMediaSalarioNuevo := vSumSalarioNuevo / numPersonasDepartamento;
        update tabla_departamento dep
            set media_salarios = vMediaSalarioNuevo
            where dep.num_depart = i.num_depart;
            incrementoSalarios := vSumSalarioNuevo - vSalarioAnterior;
        update tabla_departamento dep
            set presupuesto = presupuesto + incrementoSalarios
            where dep.num_depart = i.num_depart;
    END LOOP;
END;

/*
9. Cree una tabla NOTAS con los atributos que estime necesarios y construya un
bloque que inserte en la tabla NOTAS cuatro filas para cada alumno matriculado,
estas filas corresponderán a las tres convocatorias ordinarias y la última para
la convocatoria de junio. Antes de insertar se comprobará que no están ya
creadas. Las filas deberán inicializarse a nulo.
*/

create table notas(
    not_numMatricula number not null,
    convocatoria varchar2(50) not null,
    nota number default null,
constraint pk_notas primary key (not_numMatricula, convocatoria)
);

DECLARE
    CURSOR cursorAlumnos IS
        select numMatricula from alumnos7;
    vCursorAlumnos cursorAlumnos%ROWTYPE;
BEGIN
    OPEN cursorAlumnos;
    FETCH cursorAlumnos into vCursorAlumnos;
    WHILE cursorAlumnos%FOUND LOOP
        BEGIN
            insert into notas (not_numMatricula, convocatoria)
            values (vCursorAlumnos.numMatricula, '1ª Convocatoria');
            insert into notas (not_numMatricula, convocatoria)
            values (vCursorAlumnos.numMatricula, '2ª Convocatoria');
            insert into notas (not_numMatricula, convocatoria)
            values (vCursorAlumnos.numMatricula, '3ª Convocatoria');
            insert into notas (not_numMatricula, convocatoria)
            values (vCursorAlumnos.numMatricula, 'Convocatoria de Junio');
        EXCEPTION
        WHEN DUP_VAL_ON_INDEX THEN
            null;
        END;
	FETCH cursorAlumnos into vCursorAlumnos;
    END LOOP;
    CLOSE cursorAlumnos;
END;


/*
10. Cree un bloque que almacene en la tabla AUX_ARTICULOS (debe crearse
previamente) un número dado de los artículos con mayor precio de los
existentes en la tabla Tabla_articulos. El número de artículos a almacenarse
debe ser dado por teclado.
*/

create table aux_articulos(
    numeroArticulos number,
    codigo varchar2(40) not null,
constraint pk_aux_articulos primary key (codigo),
constraint fk_aux_articulos_productos foreign key (codigo)
    references productos (codigo)
);


DECLARE
    CURSOR cursorCaro IS
        select p1.codigo
            from productos p1
            where p1.coste = (select max(p2.coste)
                                from productos p2);
    nArticulosUsuario number;
    vCursorCaro cursorCaro%ROWTYPE;
    n number;
BEGIN
    dbms_output.put_line('Introduce el número del artículo más caro que quieres');
    nArticulosUsuario:=&n;
    OPEN cursorCaro;
    FETCH cursorCaro into vCursorCaro;
    WHILE cursorCaro%FOUND LOOP
        insert into aux_articulos(numeroArticulos, codigo)
        values (nArticulosUsuario, vCursorCaro.codigo);
        FETCH cursorCaro into vCursorCaro;
    END LOOP;
    CLOSE cursorCaro;
END;


--HECHO SIN CURSORES
DECLARE
    vCodigo productos.codigo%type;
    nArticulosUsuario number;
    n number;
BEGIN
    dbms_output.put_line('Introduce el número del artículo más caro que quieres');
    nArticulosUsuario:=&n;
    select p1.codigo into vCodigo
            from productos p1
            where p1.coste = (select max(p2.coste)
                                from productos p2);
    insert into aux_articulos(numeroArticulos, codigo)
        values (nArticulosUsuario, vCodigo);
END;


/*
11. Escriba un bloque que recupere todos los prevedores por países. El resultado
debe almacenarse en una nueva tabla Tabla_aux que permita almacenar datos
del tipo: Proveedor: ONCE - País: España
Utilice un cursor para recuperar cada país de la tabla Tabla_Proveedores y pasar
dicho país a un cursor que obtenga el nombre de los proveedores en él. Una vez
que se tiene el nombre del proveedor y su país, debe añadirse a la nueva tabla
en el formato especificado.
NOTA: En primer lugar, debe crear las tablas Tabla_Proveedores y Tabla_Aux e
insertar en las mismas datos de prueba.
*/

create table tabla_proveedores(
    nombre varchar2(20) not null,
    pais varchar2(20),
    productosProveen varchar2(200),
    anyosAntiguedad number,
constraint pk_tabla_proveedores primary key (nombre)
);

create table tabla_aux(
    nombre varchar2(20) not null,
    pais varchar2(20),
constraint pk_aux primary key (nombre),
constraint fk_aux_proveedores foreign key (nombre)
    references tabla_proveedores (nombre)
);

insert into tabla_proveedores (nombre, pais, productosProveen, anyosAntiguedad)
values ('ONCE', 'España', 'Lotería', '25');
insert into tabla_proveedores (nombre, pais, productosProveen, anyosAntiguedad)
values ('CARTON_S.L.', 'España', 'Cartón', '3');
insert into tabla_proveedores (nombre, pais, productosProveen, anyosAntiguedad)
values ('DISOL', 'Francia', 'Disolvente', '6');
insert into tabla_proveedores (nombre, pais, productosProveen, anyosAntiguedad)
values ('QUES', 'Francia', 'Queso', '2');
insert into tabla_proveedores (nombre, pais, productosProveen, anyosAntiguedad)
values ('TRI', 'Rusia', 'Trigo', '13');
insert into tabla_proveedores (nombre, pais, productosProveen, anyosAntiguedad)
values ('PIZ', 'Italia', 'Pizza', '39');

DECLARE
    CURSOR c1 IS
        select distinct pais from tabla_proveedores;
    CURSOR c2 (vC1 c1%ROWTYPE) IS
        select nombre from tabla_proveedores p2
            where p2.pais = vC1.pais;
BEGIN
    FOR i IN c1 LOOP
        FOR j IN c2(i) LOOP
            insert into tabla_aux values (j.nombre, i.pais);
        END LOOP;
    END LOOP;
END;


/*
12. Crea un cursor que obtenga por pantalla los siguientes datos de vuelos del
modelo AEROPUERTO: Nombre aeropuerto de origen, nombre aeropuerto de destino,
director de cada uno si lo tuviera (si no, que aparezca en blanco), año que se
ha realizado y numero de veces que se efectúa ese mismo vuelo por cada año.
*/

DECLARE
    CURSOR cursorVuelos IS
        select vo.num_vuelo, vo.cod_avion, to_char(vo.fecha_vuelo, 'yyyy') anyo_vuelo,
            aero_origen.nombre aero_origen, aero_destino.nombre aero_destino,
            dir_origen.nombre director_aero_origen,
            dir_destino.nombre director_aero_destino,
            count(*) num_veces_repite_cada_anyo
        from volar vo, programa_vuelo pv, aeropuertos aero_origen,
            aeropuertos aero_destino, director dir_origen, director dir_destino
        where vo.num_vuelo = pv.num_vuelo
        and pv.cod_aero_despegar = aero_origen.codigo
        and pv.cod_aero_aterrizar = aero_destino.codigo
        and dir_origen.cod_aeropuerto = aero_origen.codigo
        and dir_destino.cod_aeropuerto = aero_destino.codigo
        group by vo.num_vuelo, vo.cod_avion, to_char(vo.fecha_vuelo, 'yyyy'),
            aero_origen.nombre, aero_destino.nombre,
            dir_origen.nombre, dir_destino.nombre;
    vCursorVuelos cursorVuelos%ROWTYPE;
BEGIN
    OPEN cursorVuelos;
    FETCH cursorVuelos into vCursorVuelos;
    WHILE cursorVuelos%FOUND LOOP
        dbms_output.put_line('Número de vuelo: '||vCursorVuelos.num_vuelo
            ||' Codigo de Avión: '||vCursorVuelos.cod_avion
            ||' Año del vuelo: '||vCursorVuelos.anyo_vuelo
            ||' Aeropuerto de origen: '||vCursorVuelos.aero_origen
            ||' Aeropuerto de destino: '||vCursorVuelos.aero_destino
            ||' Director aeropuerto origen: '||vCursorVuelos.director_aero_origen
            ||' Director aeropuerto destino: '||vCursorVuelos.director_aero_destino
            ||' Número de veces que el vuelo se repite cada año: '||vCursorVuelos.num_veces_repite_cada_anyo);
    	FETCH cursorVuelos into vCursorVuelos;
    END LOOP;
    CLOSE cursorVuelos;
END;










