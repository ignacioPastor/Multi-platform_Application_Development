-- Ejercicios Semanales PL/SQL Bloque 3, Ignacio Pastor Padilla
-- 1� DAM Semipresencial - Grupo A

/*
1.- �Funcionaria el siguiente c�digo?. Explicar por qu� y como
solucionarlo (si se os ocurren varias formas de arreglarlo, explicarlas todas).
DECLARE
base NUMBER:=100;
BEGIN
FOR dept IN 1..10 LOOP
UPDATE dept SET nom_dept=base+dept
WHERE cod_dept=base+dept;
END LOOP;
END;
*/

/*
El c�digo funcionar�a pero con algunas cuestiones dejadas en el aire:
-Si en la tabla hay un campo llamado base, se coger�a el campo de la tabla,
pues en caso de  ambig�edad Oracle siempre opta por el campo, no por la variable.
Si no existiera un campo "base", entonces sumar�a la variable.
- Respecto a dept, es por un lado el nombre de la tabla, por otro lado el contador
Pasar�a que si hay un campo en la tabla llamado dept, oracle trabajar�a con el
campo, y en caso de no haberlo, 
*/

/*
2- �Qu� ocurrir�a al ejecutar el siguiente c�digo?, �Por qu�?,
�C�mo arreglarlo? (Si existen varias posibilidades, comentarlas e
indicar cual ser�a m�s eficiente).

DECLARE
ap1_emp VARCHAR2(40):='Fernandez';
BEGIN
DELETE FROM emp WHERE ap1_emp=ap1_emp;
COMMIT;
END;
*/

/*
La condici�n tautol�gica, siempre ser� verdad. Por lo tanto se borrar�n
todos los datos de la tabla emp. Y adem�s, despu�s se hace COMMIT. Con lo que
los datos se pierden definitivamente.
Para arreglar el c�digo, primero quitamos el commit.
Despu�s en la condici�n where debemos cambiar la igualaci�n a s� mismo.
Pues si hay un campo de la tabla que se llama ap1_emp, oracle coger� siempre el 
campo, y si no lo hay, pues ser� la variable lo que coja. En ambos casos es una
igualaci�n a uno mismo, por lo que siempre ser� verdadera y nos borrar� todos 
los datos. Habr�a que llamar a la variable de forma distinta al campo, o
hacer la igualaci�n entre dos variables o expresiones diferentes entre s�.
*/

/*
3.- �Es correcto el siguiente c�digo en PL/SQL?, �Por qu�?
Nota:Ignorar el funcionamiento del c�digo (no hace nada), ce�irse
exclusivamente a la sintaxis v�lida en PL/SQL.
FOR ctr IN 1..10 LOOP
IF NOT fin THEN
INSERT INTO temp
VALUES (ctr, 'Hola');
COMMIT;
factor:=ctr*2;
ELSE
ctr:=10;
END IF;
END LOOP;
*/

/*
Es incorrecto. No se puede alterar el valor del contador tal y como se hace 
en el ELSE. Por otro lado, poner un COMMIT ah� en medio del c�digo
es una pr�ctica poco recomendable.
Todo esto, suponiendo que la tabla temp tiene dos campos, y que son del
tipo number y char, y en ese orden.
*/


/*
4.- �Qu� resultado provoca la ejecuci�n del siguiente c�digo PL/SQL?
DECLARE
variable NUMBER:=1;
almacenamos NUMBER:=1;
BEGIN
FOR i IN 5..variable LOOP
almacenamos:=almacenamos+i;
END LOOP;
INSERT INTO traza VALUES(TO_CHAR(almacenamos));
COMMIT;
END;
*/

/*
Suponiendo que en la tabla traza solo hay un campo, y es del tipo char:
Se almacenar�a '1'. Pues en un bucle FOR, el primero de los n�meros debe
ser siempre el menor, pues Oracle dice, "cuando 5 llegue a variable", 5 ya
es mayor que 1, por lo que ni siquiera se llega a meter en el bucle.
*/

/*
5- �Qu� da este bloque?
DECLARE
V_num NUMBER;
BEGIN
SELECT COUNT(*) INTO V_num
FROM productos;
DBMS_OUTPUT.PUT_LINE(V_num);
END;
*/
-- El n�mero de productos de los que disponemos. Es decir, las filas de la 
-- tabla productos.


/*
6- Crea una tabla MENSAJES con un solo campo VALOR, de tipo VARCHAR2(5).
Crea un bloque que inserte 8 elementos en la tabla con valores del 1 al 10,
excepto el 4 y 5.
*/

create table mensajes(
	valor varchar2(5)
);

BEGIN
FOR i IN 1..10 LOOP
if i <> 4 and i <> 5 then
insert into mensajes
values (to_char(i));
END IF;
END LOOP;
END;

/*
7- Vuelve a usar la tabla anterior con los datos ya rellenos,
y si el n�mero que insertas es menor que 4 entonces debes sacar
un mensaje de error si ya existe, si el n�mero es mayor o igual que 4,
debes insertarlo si no existe y actualizarlo sum�ndole 1 si ya existe.
*/

DECLARE
variable number;
BEGIN
FOR i IN 1..10 LOOP
IF i < 4 THEN
select count(*) into variable from mensajes where valor = i;
    IF variable > 0 THEN
	dbms_output.put_line('Error. El n�mero ' || 'i' || 'ya existe en la tabla');
	ELSE  insert into mensajes values (to_char(i));
	END IF;
ElSIF i >= 4 THEN
	IF variable > 0 THEN insert into mensajes values (to_char(i+1));
	else insert into mensajes values (i);
	END IF;
END IF;
END LOOP;
END;


/*
8- Crea una tabla PRODUCTO(CODPROD, NOMPROD, PRECIO),
usando SQL (no uses un bloque PL/SQL).
A�ade un producto a la tabla usando una sentencia insert
dentro de un bloque PL/SQL.
*/

create table producto(
	codprod varchar2(20) not null,
	nomprod varchar2(40),
	precio number,
constraint pk_producto primary key (codprod)
);

BEGIN
insert into producto (codprod, nomprod, precio)
values ('TF', 'Tomate Frito', 1.5);
END;


/*
9. A�ade otro producto, ahora utilizando una lista
de variables en la sentencia insert.
*/

DECLARE
codigo producto.codprod%type := 'LNT';
nombre producto.nomprod%type := 'Lentejas de Bote';
price producto.precio%type := 0.8;
BEGIN
insert into producto (codprod, nomprod, precio)
values (codigo, nombre, price);
END;


/*
10. A�ade, ahora usando un registro PL/SQL, dos produtos m�s.
*/

DECLARE
producto1 producto%rowtype;
producto2 producto%rowtype;
BEGIN
producto1.codprod := 'PTT';
producto1.nomprod := 'Patatas';
producto1.precio := 0.5;
producto2.codprod := 'LM';
producto2.nomprod := 'Limones';
producto2.precio := 0.8;
insert into producto values producto1;
insert into producto values producto2;
END;

/*
11. Borra el primer producto insertado,
e incrementa el precio de los dem�s en un 5%.
*/

BEGIN
delete from producto
where codprod = 'TM';
update producto
set precio = precio * 1.05;
END;

/*
12. Obt�n y muestra por pantalla el n�mero de productos que hay almacenados,
usando select ... Into y el mensaje �Hay n productos�.
*/

DECLARE
n_productos number;
BEGIN
select count(*)
into n_productos
from producto;
dbms_output.put_line('Hay ' || n_productos || ' productos');
END;


/*
13. Obt�n y muestra todos los datos de un producto
(busca a partir de la clave primaria, escogiendo un c�digo de producto existente.
Usa select ... into y un registro PL/SQL.
*/

DECLARE
v_producto producto%rowtype;
BEGIN
select *
into v_producto
from producto
where codprod = 'LM';
dbms_output.put_line(v_producto.codprod || ' ' || v_producto.nomprod || ' ' || v_producto.precio);
END;


/*
14- Haz un bloque PL/SQL, de forma que se indique que no hay productos,
que hay pocos (si hay entre 1 y 3) o el n�mero exacto de produtos existentes
(si hay m�s de 3).
*/

DECLARE
n_productos number;
BEGIN
select count(*)
into n_productos
from producto;
IF n_productos = 0 THEN
	dbms_output.put_line('No hay productos');
ELSIF n_productos > 0 and n_productos < 4 THEN
	dbms_output.put_line('Hay pocos productos');
ELSE dbms_output.put_line('Hay ' || n_productos || ' productos');
END IF;
END;







