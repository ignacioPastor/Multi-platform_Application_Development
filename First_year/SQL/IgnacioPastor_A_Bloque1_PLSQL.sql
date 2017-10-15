--Ignacio Pastor Padilla - Bloque 1 PLSQL - DAM Semi, grupo A.

/*
1.- Determinar cuales de los siguiente Identificadores son equivalentes
en PL/SQL

Identificador1 NUMBER;
Identificador_1 NUMBER;
identificador1 NUMBER;
IdEntificador_1 NUMBER;
IDENTIFICADOR1 NUMBER;

PL/SQL no es case sensitive, por lo que no distingue entre mayúsculas y
minúsculas. Por lo tanto, los identificadores son equivalentes en dos grupos:
1-3-5 son equivalentes entre sí. Y 2-4 son equivalentes entre sí.



2.- Determinar cual de los siguientes identificadores en PL/SQL es el válido:
Primera variable VARCHAR2(40);
end BOOLEAN;
Una_variable VARCHAR2(40);
Otra-variable VARCHAR2(40);

El primero, porque en los identificadores no está permitido el guión, pero 
sí que está permitido el guión bajo.


3.- ¿ Funcionaría la siguiente sentencia en PL/SQL?. En caso negativo proponer
como resolverlo.

DECLARE
    nombre VARCHAR2(80);
    direccion VARCHAR2(80);
    tipo empleado VARCHAR2(4);
BEGIN
    SELECT name, address, type
    INTO nombre, direccion, tipo empleado
    FROM emp;
END;

Tipo empleado no puede tener un espacio, debería ser algo así como tipo_empleado.
Y no sé si type (ya en el BEGIN) puede ser una palabra reservada...


4- En las siguientes sentencias de definición de Subtipos,
hay una que no es válida... Indicar cual es, y como solucionarlo.

DECLARE
SUBTYPE numero1 IS NUMBER;
SUBTYPE cadena IS VARCHAR2(10);
total numero1(6,2);

total numero1(6,2);
Porque numero1 es el nombre del identificador, no hay que confundirlo con
el tipo de variable number. La solución sería:
total number(6,2);


5.- Indicar del siguiente juego de declaraciones, cuales son correctas y
cuales no, indicando además por qué no son correctas.

DECLARE
    Correcta

cierto BOOLEAN:=FALSE;
    Correcta

id_externo NUMBER(4) NOT NULL;
    Incorrecta. Restringe para que no sea null, pero no le da ningún valor inicial

cosa NUMBER:=2;
    Correcta

producto NUMBER:=2*cosa;
    Correcta

suma NUMBER:=cosa + la_otra;
    Incorrecta. Si se hace referencia a una variable en una declaración, esa
        variable debe haberse declarado previamente.

la_otra NUMBER:=2;
    Correcta

tipo_uno NUMBER(7,2) NOT NULL:=3;
    Correcta

tipo_otro tipo_uno%TYPE;
    Correcta



6.- Suponiendo que tenemos una tabla llamada EMP, en la cual
existen tres campos: nombre VARCHAR2(40), direccion
VARCHAR2(255), telefono NUMBER(10)... ¿Qué valores podrán
tomar las variables que definimos en la siguiente declaración?

DECLARE
    valor1 emp%ROWTYPE;
    valor2 emp.nombre%TYPE;
    valor3 emp.telefono%TYPE;
CURSOR c1 IS
SELECT nombre,direccion FROM emp;
    valor4 c1%ROWTYPE;
    valor5 emp%ROWTYPE;

valor1 podrá tomar valores tanto de varchar2(40), varchar2(255) y number(10)
valor2 podrá tomar varchar2(40)
valor3 podrá tomar number(10)
valor4 podrá tomar varchar2(40) y varchar2(255)
valor5 podrá tomar valores tanto de varchar2(40), varchar2(255) y number(10)



7.- En base al enunciado anterior, ¿Sería correcta la siguiente asignación?
Razonar el por qué en ambos casos.

valor1:=valor5;
    Sí, porque el abanico de valores del que disponen para tomar es el mismo

¿y esta?
valor4:=valor1;
    No. Porque valor1 puede ser varchar2(40), varchar2(255) y number(10)
        mientras que valor4 solo varchar2(40) y varchar2(255).


8.-¿ Es esta declaración correcta en PL/SQL?

DECLARE
i, j NUMBER;
¿Y si la escribieramos así?
DECLARE
i, j NUMBER, NUMBER;

Por lo que sé, no sería correcta ninguna de las dos. Cada identificador debe
    ir seguido de su tipo de variable

*/

--9- Escribir un bloque PL/SQL que escriba el texto “Hola”.

DECLARE
    v_saludo varchar2(20) := 'Hola';
BEGIN
    dbms_output.put_line(v_saludo);
END;


--10 – Escribe un bloque PL/SQL que sume dos número y te diga que números
--ha sumado y cuál es el resultado.

DECLARE
    v_n1 number(5) := 5;
    v_n2 number(5) := 4;
BEGIN
    dbms_output.put_line(v_n1 ||' + '|| v_n2 ||' = '|| (v_n1 + v_n2));
END;


--11- Escribe un bloque PL/SQL donde declares una variable,
--inicializada a la fecha actual, que imprimes por pantalla.

DECLARE
    v_fecha_actual date := sysdate;
BEGIN
    dbms_output.put_line('La fecha actual es '|| sysdate);
END;


--12- Escribe un boque PL/SQL que almacene en una variable numérica el año actual.
--Muestra por pantalla el año. Puedes usar las funciones to_number y to_char.

DECLARE
    v_anyo_actual number(4) := to_number(to_char(sysdate, 'yyyy'));
BEGIN
    dbms_output.put_line(v_anyo_actual);
END;



