-- IgnacioPastor_A_Bloque7_PLSQL


-- 1. Crea un procedimiento que dado un nombre y una contraseña,
-- te cree un usuario y te de permisos.

DECLARE
    v_usuario varchar2(30) := 'ignacioPruebas';
    v_contrasenya varchar2(10) := '1234';
    cadena varchar(200);
BEGIN
    cadena := 'create user '||v_usuario||' identified by '||v_contrasenya;
    execute immediate cadena;
    cadena := 'grant all privileges to '||v_usuario;
    execute immediate cadena;
END;


-- 2. Cambia el ejercicio anterior capturando todos
--  los fallos posibles que se puedan dar.

DECLARE
    v_usuario varchar2(30) := 'ignacioPruebass';
    v_contrasenya varchar2(10) := 4;
    cadena varchar(200);
BEGIN
    cadena := 'create user '||v_usuario||' identified by '||v_contrasenya;
    execute immediate cadena;
    cadena := 'grant all privileges to '||v_usuario;
    execute immediate cadena;
EXCEPTION
    WHEN OTHERS THEN
    if sqlcode = -01920 then
        RAISE_APPLICATION_ERROR(-20100, 'El nombre de usuario ya existe');
    else RAISE_APPLICATION_ERROR(-20101, 'Ha habido un error: '||SQLERRM);
    end if;
END;


-- 3. Crea dinámicamente una tabla de 5 campos, y creale una clave primaria

DECLARE
    cadena varchar2(300);
BEGIN
    cadena := 'create table tabla_prueba_dinamico ( 
        campo1 varchar2(20) not null, campo2 varchar2(20),
        campo3 number, campo4 date, campo5 varchar2(20),
        constraint pk_tabla_prueba_dinamico primary key (campo1))';
    execute immediate cadena;
END;


-- 4. Realiza un procedimiento llamado Busqueda, que entren por parámetros
-- los 5 campos dados y busque dinámicamente todos los datos de la tabla
-- anterior por todos los criterios que no se le pase a NULL a la función,
-- dando un error si todos se pasan a NULL.

-- si la variable no es nula, añadimos que se busque ese campo.
-- gestionamos el "and" añadiendo siempre el conector, pero asignándolo siempre como "and" después de utilizarlo
-- así, caso de que el primer valor sea nulo, siempre lo usará, pero la primera vez estará vacío, y después ya se añade el "and"
-- porque no sabemos qué campo no va a ser nulo, pudiera ser que solo el campo 5 sea no nulo.

create or replace procedure Busqueda (v1 in varchar2, v2 in varchar2,
    v3 in number, v4 in date, v5 in varchar2)
IS
    cadena varchar2(1000);
    conector varchar2(30) := '';
BEGIN
cadena := 'select * from tabla_prueba_dinamico where ';
    IF v1 is null and v2 is null and v3 is null and v4 is null and v5 is null THEN
        raise_application_error(-20100, 'Todos los parámetros son nulos');
    END IF;    
    IF v1 is not null THEN
        cadena := cadena || 'campo1 = '||v1||' ';
        conector := ' and ';
    END IF;
    IF v2 is not null THEN
        cadena := cadena||conector||'campo2 = '||v2||' ';
        conector := ' and ';
    END IF;
    IF v3 is not null THEN
        cadena := cadena||conector||'campo3 = '||v3||' ';
        conector := ' and ';
    END IF;
    IF v4 is not null THEN
        cadena := cadena||conector||'campo4 = '||v4||' ';
        conector := ' and ';
    END IF;
    IF v5 is not null THEN
        cadena := cadena||conector||'campo5 = '||v5||' ';
        conector := ' and ';
    END IF;
END;

--Comprobamos que detecta si los parámetros son todos null
BEGIN
    busqueda(null, null, null, null, null);
END;


-- 5. Crea la tabla usando SQL dinámico y EXECUTE IMMEDIATE dentro de
-- un bloque PL/SQL. Comprueba que efectivamente la tabla fue creada,
-- con una consulta simple sobre el catalogo de Oracle.
-- Finalmente, elimina la tabla.

DECLARE
    cadena varchar2(1000);
    n number;
BEGIN
    cadena := 'create table tabla_prueba_ejer5 (campo1 number not null,
        campo2 number, constraint pk_tabla_prueba_ejer5 primary key (campo1))';
    execute immediate cadena;
    cadena := 'select count(*) from tabla_prueba_ejer5';
    execute immediate cadena into n;
    dbms_output.put_line('En la tabla hay '||n||' tuplas');
    cadena := 'drop table tabla_prueba_ejer5';
    execute immediate cadena;
END;


-- 6. De nuevo en un bloque PL/SQL, crea una tabla T2 con un campo
-- S alfanumérico, e inserta una fila en esa tabla.


DECLARE
	cadena varchar2(1000);
BEGIN
	cadena := 'create table T2 ( campo1 varchar2(20) not null, campo2 varchar2(20),
		campo3 number, constraint pk_T2 primary key (campo1))';
	execute immediate cadena;
	cadena := 'insert into T2 values (:1, :2, :3)';
	execute immediate cadena using 'mesa', 'roble', 68;
END;


-- 7. Recupera e imprime de nuevo los datos de todos los productos,
-- ahora usando SQL dinámico.

DECLARE
    cadena varchar2(1000);
BEGIN
    cadena := 'DECLARE cursor c1 is select * from productos; 
        BEGIN FOR i in c1 LOOP dbms_output.put_line(i.codigo||
        i.descripcion||i.coste); END LOOP; END;';
    execute immediate cadena;
END;


-- 8. Altera la tabla de productos, añadiendo una restricción c_precio_positivo
-- que compruebe que el precio de un producto es mayor que cero.

DECLARE
	cadena varchar2(100);
BEGIN
	cadena := 'alter table productos add constraint c_precio_positivo
			check (coste >= 0)';
	execute immediate cadena;
END;








