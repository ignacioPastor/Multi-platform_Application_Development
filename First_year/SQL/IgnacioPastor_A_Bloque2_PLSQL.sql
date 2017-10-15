--IgnacioPastor_A_Bloque2_PLSQL

/*
1.- �Es correcta la siguiente sintaxis General de la sentencia
IF-THEN ELSE?, �Por qu�?, �C�mo la escribir�as?.

BEGIN
    IF condicion1 THEN
    BEGIN
        secuencia_de_instrucciones1;
    ELSE
        secuencia_de_instrucciones2;
    ENDIF;
END;

*/

-- No es correcta. El segundo BEGIN sobra.
--El ENDIF; deber�a ir separado: END IF;
--Dejando de lado claro, que las variables deben ser declaradas
BEGIN
    IF condicion1 THEN
        secuencia_de_instrucciones1;
    ELSE
        secuencia_de_instrucciones2;
    END IF;
END;


/*
2.- �Qu� resultado nos dar�a la siguiente comparaci�n?

DECLARE
    identificador1 VARCHAR2(10):='Hola Pepe';
    identificador2 VARCHAR2(10):='Hola pepe';
BEGIN
    IF identificador1<>identificador2 THEN
        RETURN TRUE;
    ELSE
        RETURN FALSE;
    END IF;
END;
*/

--Devuelve TRUE

DECLARE
    identificador1 VARCHAR2(10):='Hola Pepe';
    identificador2 VARCHAR2(10):='Hola pepe';
BEGIN
    IF identificador1<>identificador2 THEN
        RETURN TRUE;
    ELSE
        RETURN FALSE;
END IF;
END;


/*
3.- Indicar que errores existen en el siguiente c�digo fuente:
DECLARE
    a NUMBER:=1;
    b NUMBER:=6;
    salida_bucle BOOLEAN;
BEGIN
    salida_bucle:='FALSE';
    WHILE NOT salida_bucle
    LOOP
    BEGIN
        IF a>=b THEN
            salida_bucle:='TRUE';
        ELSE
            a:=(a+1);
        END IF;
    END LOOP;
END;
*/

--Sobra el segundo BEGIN
--La inicializaci�n de los booleanos no es char, sobran las comillas

DECLARE
    a NUMBER:=1;
    b NUMBER:=6;
    salida_bucle BOOLEAN;
BEGIN
    salida_bucle:=FALSE;
    WHILE NOT salida_bucle
    LOOP
        IF a>=b THEN
            salida_bucle:=TRUE;
        ELSE
            a:=(a+1);
        END IF;
    END LOOP;
END;


/*
4- �Qu� valor contendr� la variable 'sumador' al salir del bucle?, �Por qu�?
DECLARE
    sumador NUMBER;
BEGIN
    FOR i IN 1..100 LOOP
        sumador:=sumador+i;
    END LOOP;
END;
*/

--Null. Porque sumar un entero a null da null.


/*
5.- �Qu� resultado dar� la ejecuci�n del siguiente c�digo?
DECLARE
    temp NUMBER(1,0);
    SUBTYPE numero IS temp%TYPE;
    valor numero;
BEGIN
    WHILE valor<20 LOOP
        valor:=valor+1;
    END LOOP;
END;
*/

--Dar� error, porque "numero" no es un tipo de n�mero en oracle, no es
--la palabra reservada para declarar un n�mero. Por lo tanto, el 
--identificador "valor" no ha sido declarado.


/*
6- � Funcionar�a el siguiente trozo de c�digo?, �Por qu�?, �C�mo
arreglarlo?
DECLARE
    mi_valor NUMBER;
    cierto BOOLEAN:=FALSE;
BEGIN
    WHILE NOT cierto
    LOOP
        IF mi_valor=NULL THEN
            mi_valor:=1;
        ELSE
            mi_valor:=mi_valor+1;
        END IF;
        IF mi_valor>100 THEN cierto:=TRUE; END IF;
    EXIT WHEN cierto;
    END LOOP;
END;
*/

--No funcionar�a porque null es incomparable. Deber�a ser "is null".
--De hecho, creo que con el "=" entra en un bucle infinito

DECLARE
    mi_valor NUMBER;
    cierto BOOLEAN:=FALSE;
BEGIN
    WHILE NOT cierto
    LOOP
        IF mi_valor is NULL THEN
            mi_valor:=1;
        ELSE
            mi_valor:=mi_valor+1;
            dbms_output.put_line(mi_valor);
        END IF;
        IF mi_valor>100 THEN cierto:=TRUE; END IF;
    EXIT WHEN cierto;
    END LOOP;
END;

/*
7.- Escribir la sintaxis General de un c�digo que eval�e si se cumple
una condici�n, en caso de cumplirse que ejecute una serie de sentencias,
en caso contrario que eval�e otra, que de cumplirse ejecute otras
instrucciones, si �sta no se cumple que eval�e una tercera condici�n.. y
as� N veces. En caso de existir varias soluciones, comentarlas y escribir la
m�s �ptima o clara.
*/

DECLARE
    valor number(5);
BEGIN
    IF valor = 1 THEN
        sentencia1;
        sentencia2;
    ELSIF valor = 2 THEN
        sentencia3;
        sentencia4;
    ELSIF valor = 3 THEN
        sentencia5;
        sentencia6;
    --(...)
    ELSE
        sentenciaN;
    END IF;
END;

DECLARE
    valor number(5);
BEGIN
    CASE valor
    WHEN 1 THEN
        sentencia1;
        sentencia2;
    WHEN 2 THEN
        sentencia3;
        sentencia4;
    WHEN 3 THEN
        sentencia5;
        sentencia6;
    --(...)
    ELSE
        sentenciaN;
    END CASE;
END;

--Las dos opciones servir�an. La primera utilizando if-else-if y la
--segunda con case. Dir�a que ambas funcionan igual, se va evaluando
--la expresi�n, proceden por orden y cuando una de las condiciones se
--cumple se deja de comprobar las siguientes. La diferencia consistir�a
--en que el case solo permite manejar valores de una expresi�n, mientras
--que con el if podemos ir variando radicalmente la condici�n a cumplir.
--Por ejemplo, if valor=1 then(...) elsif manyana_va_a_llover = true then..
--En este caso, siendo las posibilidades siempre limitadas y en torno 
--al valor num�rico de "valor", el case servir�a tan bien como el if,
--y quiz�s estar�a m�s indicado.


/*
8.- Implementar en PL/SQL un bucle infinito que vaya sumando
valores en una variable de tipo NUMBER.
*/

DECLARE
    valor number := 1;
BEGIN
    WHILE valor > 0 LOOP
        valor := valor + 1;
    END LOOP;
END;
    

/*
9.- En base al bucle anterior, a�adirle la condici�n de que salga 
cuando la variable sea mayor que 10.000.
*/

DECLARE
    valor number := 1;
BEGIN
    WHILE valor <= 10000 LOOP
        valor := valor + 1;
    END LOOP;
END;


/*
10.- Implementar un bucle en PL/SQL mediante la sentencia WHILE,
en el cual vayamos sumando valores a una variable mientras �sta sea
menor que 10, y asegur�ndonos de que el bucle se ejecuta por lo menos
una vez.
*/

DECLARE
    valor number := 1;
BEGIN
    WHILE valor < 10 LOOP
        valor := valor + 1;
    END LOOP;
END;

--Esto no garantizar�a que se ejecutase al menos una vez. Eso ser�a
--usando LOOP, pero pide con while...

/*
11.- Implementar en PL/SQL, el c�digo necesario de un programa que
al final de su ejecuci�n haya almacenado en una variable llamada 
'cadena', el siguiente valor:
cadena:='10*9*8*7*6*5*4*3*2*1'
*/

DECLARE
    cadena varchar2(200) := ' ';
BEGIN
    FOR i IN REVERSE 1..10 LOOP
        if i = 1 then
        cadena := cadena || i;
        else
        cadena := cadena || i || '*';
        end if;
    END LOOP;
    dbms_output.put_line(cadena);
END;