--IgnacioPastor_A_Bloque4_PLSQL


/*
1.Crear una función pl/sql que duplica la cantidad recibida como parámetro .
*/

create or replace function duplicar (n in number) return number
as
begin
    return 2*n;
end duplicar;
declare
    param_n number := 3000;
    n_duplicada number;
begin
    n_duplicada := duplicar(param_n);
    dbms_output.put_line('n_duplicada: ' || n_duplicada);
end;


/*
2.Crear una función pl/sql llamada factorial que devuelva
el factorial de un número,
por ejemplo 5! = 1 * 2 * 3 * 4 * 5 = 120.
*/

create or replace function factorial (n in number) return number
as
    factori number := 1;
begin
    for i in 1..n loop
        factori := factori * i;
    end loop;
    return factori;
end factorial;
declare
    n_param number := 5;
    facto number;
begin
    facto := factorial(n_param);
    dbms_output.put_line('El factorial de '||n_param||' es '||facto);
end;


/*
3.Crear un procedimiento pl/sql que muestra los números desde
el 1 hasta el valor pasado como parámetro.
*/

create or replace procedure del1HastaNumero (n in number)
is
begin
    for i in 1..n loop
        if i = n then
            dbms_output.put_line(i);
        else
            dbms_output.put(i||', ');
        end if;
    end loop;
end del1HastaNumero;
declare
    n_param number := 27;
begin
    del1HastaNumero(n_param);
end;


/*
4.Modificar el procedimiento del Ejercicio 1 para que muestre 
números desde un valor inferior hasta uno superior
con cierto salto, que por defecto será 1.
*/

create or replace procedure salto (n in number)
is
    n2 number;
    n3 number;
begin
    n2 := n - 1;
    n3 := (n * 2) + 1;
    for i in n2..n3 loop
        if mod(n2, 2) = 0 then
            if mod(i, 2) = 0 then
                dbms_output.put_line(i || ', ');
            end if;
        else
            if mod(i, 2) != 0 then
                dbms_output.put_line(i || ', ');
            end if;
        end if;
    end loop;
end salto;
declare
    n_param number := 21;
begin
    salto(n_param);
end;


/*
5.Modificar el procedimiento del Ejercicio 1 para
que inserte los números en una tabla
*/

create or replace procedure salto (n in number)
is
    n2 number;
    n3 number;
begin
    n2 := n - 1;
    n3 := (n * 2) + 1;
    for i in n2..n3 loop
        if mod(n2, 2) = 0 then
            if mod(i, 2) = 0 then
                insert into table_ejer5 (numero) values (i);
            end if;
        else
            if mod(i, 2) != 0 then
                insert into table_ejer5 (numero) values (i);
            end if;
        end if;
    end loop;
end salto;
declare
    n_param number := 21;
begin
    salto(n_param);
end;

/*
6- Crea una función llamada, PVP que toma como argumento un código de producto,
una descripción y un coste del producto, y realice una inserción en una
tabla PRODUCTOS si el código de producto (PK) no existe y en caso de existir
actualice los datos de decripción y coste y devuelva el precio de venta al público,
que resulta de aplicarle a ese precio de coste un margen comercial del 20%.
*/

    create or replace function pvp (cod varchar2, descrip varchar2, preci number) return number
as
    prod_existe number;
    precio_return number;
begin
    select count(*) into prod_existe from productos prod where prod.codigo = cod;
    if prod_existe = 0 then
        insert into productos (codigo, descripcion, coste) values (cod, descrip, preci);
        precio_return := preci;
    else
        update productos set descripcion = descrip, coste = preci where codigo = cod;
    end if;
    return precio_return*1.2;
end pvp;
        DECLARE
    vCodigo varchar2(10) := 'TM';
    vDescripcion varchar2(100) := 'Tomates Molones';
    vPrecio number := 1;
    vPrecioReturn number;
BEGIN
    vPrecioReturn := pvp(vCodigo, vDescripcion, vPrecio);
    dbms_output.put_line(vPrecioReturn);
    END;

/*
7- Dado este PL/SQL:
CREATE OR REPLACE PROCEDURE modificar_precio_producto (codigoprod NUMBER, nuevo NUMBER)
AS
	Precioant NUMBER(5);
BEGIN
	SELECT precio_uni INTO precioant
	FROM productos
	WHERE cod_producto = codprod;
	IF (precioant * 0.20) > ABS( precioant – nuevoprecio) then
		UPDATE productos
			SET precio_uni = nuevoprecio
		WHERE cod_producto = codigoprod;
	ELSE
		DBMS_OUTPUT.PUT_LINE(‘Error, modificación superior a 20%’);
	END IF;
EXCEPTION
WHEN NO_DATA_FOUND THEN
	DBMS_OUTPUT.PUT_LINE (‘No encontrado el producto ‘ || codigoprod);
END modificar_precio_producto;
*/

/*
Responde a las siguientes preguntas:
a)¿Se trata de una función o de un procedimiento, por qué?,
	¿Qué habría que cambiar para que fuera lo otro?
-Se trata de un procedimiento porque utiliza la palabra clave PROCEDURE, y además no retorna ningún valor
-Para que fuera una función habría que usar la palabla clave FUNCTION y que retornara algún valor RETURN NUMBER por ejemplo

b)¿Cuál es la cabecera del procedimiento?
CREATE OR REPLACE PROCEDURE modificar_precio_producto (codigoprod NUMBER, nuevo NUMBER)

c)¿Qué es el precioant?
Una variable que se crea para almacenar el precio original del producto (a través de una select) y poder así compararlo con el nuevo.
d)¿Qué es el nuevoprecio?
El nuevoprecio es el nuevo precio que tendrá el producto, mmm diría que se le pasa a la función
	y hay una errata en la cabecera, cuando dice "nuevo" debería ser "nuevoprecio"

e)¿Qué es el precio_uni?
Precio de la unidad (unidad de producto, por ejemplo en secadores, un secador). Es también propiamente el campo de la tabla productos
	donde se almacena el valor del producto, el precio o como se quiera llamar.

f)¿Cuáles son los parámetros del procedimiento?
Codigoprod y nuevo

g)¿Qué es NO_DATA_FOUND?
Una excepción que salta cuando una select into no devuelve ningún valor

h)¿Cuál es el nombre del procedimiento?
modificar_precio_producto

i)¿Dónde comienza el bloque?
BEGIN

j)¿Qué hace la cláusula into?
Meter el resultado de la select en la variable indicada

k)¿qué hace la condición del IF?
Controla que el aumento que se pretende asignar al producto no sea mayor al 20% de lo que ya valía.
Es decir, si el 20% del precio anterior es mayor que la diferencia entre nuevo y viejo precio, actualiza. Si no, no actualiza.

l)¿Porque no tiene la cláusula declare?¿Qué tiene en su lugar?
Porque la cabecera hace ese papel de especificación. 

*/


/*
8- Corregir los errores de sintaxis en esta función
Esta función PL/SQL devuelve el número PI (3,141592653589793238462...).
Calculado mediante el algoritmo que ideó John Wallis en 1665

CREATE OR REPLACE FUNCTION piWallis(pIteraciones number) RETURN number
IS
	vCont number := 0;
	vRet number := 1;
	loop
		vCont := vCont + 1;
		EXIT WHEN vCont > pIteraciones;
		if (vCont % 2) = 0 THEN
			vRet := vRet * vCont / (vCont + 1);
		else
			vRet := vRet * (vCont + 1) / vCont;
		end if;
	end loop
	return (2 * vRet);
END piWallis;
*/


/*
9. Introduces todas las funciones y procedimentos de
los ejercicios anteriores en un PACKAGE llamado FUNCIONES_PROCE
*/

create package funciones_proce
as
FUNCTION piWallis(pIteraciones number) return number;
PROCEDURE modificar_precio_producto (codigoprod NUMBER, nuevo NUMBER);
end fonciones_proce;

create or replace package body funciones_proce
as
    FUNCTION piWallis(pIteraciones number) RETURN number
    IS
        vCont number := 0;
        vRet number := 1;
        loop
            vCont := (vCont + 1);
            EXIT WHEN vCont > pIteraciones;
            if (vCont % 2) = 0 THEN
                vRet := vRet * vCont / (vCont + 1);
            else
                vRet := vRet * (vCont + 1) / vCont;
            end if;
        end loop
        return (2 * vRet);
    END piWallis;
    PROCEDURE modificar_precio_producto (codigoprod NUMBER, nuevo NUMBER)
    AS
        Precioant NUMBER(5);
    BEGIN
        SELECT precio_uni INTO precioant
        FROM productos
        WHERE cod_producto = codprod;
        IF (precioant * 0.20) > ABS( precioant – nuevoprecio) then
            UPDATE productos
                SET precio_uni = nuevoprecio
            WHERE cod_producto = codigoprod;
        ELSE
            DBMS_OUTPUT.PUT_LINE('Error, modificación superior a 20%');
        END IF;
    EXCEPTION
    WHEN NO_DATA_FOUND THEN
        DBMS_OUTPUT.PUT_LINE ('No encontrado el producto ' || codigoprod);
    END modificar_precio_producto;
end funciones_proce;

/*
10 Ejecuta los procedimientos y funciones del
nuevo Paquete desde un bloque anónimo.
*/

declare
	n_pi number;
	c_product number := 32;
	c_nuevo number := 200;
begin
	n_pi := funciones_proce.piWallis(8);
	dbms_output.put_line(n_pi);
	funciones_proce.modificar_precio_producto(c_product, c_nuevo);
end;
	



















