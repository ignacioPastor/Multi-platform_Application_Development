-- IgnacioPastor_A_Bloque6_PLSQL



-- 1 – Realiza el ejercicio 6 de funciones, usando excepciones.
/* EJERCICIO 6 FUNCIONES
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
    select precio into prod_existe from productos prod where prod.codigo = cod;
    update productos set descripcion = descrip, coste = preci where codigo = cod;
    return preci*1.2;
    EXCEPTION
    WHEN NO_DATA_FOUND THEN
    insert into productos (codigo, descripcion, coste) values (cod, descrip, preci);
    return preci*1.2;
end pvp;

--OTRA FORMA DE HACERLO
create or replace function pvp (cod varchar2, descrip varchar2, preci number) return number
as
    prod_existe number;
    precio_return number;
BEGIN
	insert into productos (codigo, descripcion, coste) values (cod, descrip, preci);
	return preci*1.2;
EXCEPTION
	when dup_val_on_index then
		update productos set descripcion = descrip, coste = preci where codigo = cod;
		return preci*1.2;
END;
	

-- 2- Realiza el ejercicio anterior dando un mensaje de error
-- en caso de que ya exista. (Sin hacer el update)

create or replace function pvp (cod varchar2, descrip varchar2, preci number) return number
as
    prod_existe number;
begin
    insert into productos (codigo, descripcion, coste) values (cod, descrip, preci);
    return preci*1.2;
    EXCEPTION
    WHEN NO_DATA_FOUND THEN
    dbms_output.put_line('Entra en la excepcion not_data_found');
    WHEN DUP_VAL_ON_INDEX THEN
        RAISE_APPLICATION_ERROR(-20500, 'El producto ya existe');
        return preci*1.2;
    WHEN OTHERS THEN
    dbms_output.put_line('Salta la excepcion OTHERS');
    dbms_output.put_line('Codigo de error: '||sqlcode||' Definicion: '||sqlerrm);
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


-- 3- Realiza el ejercicio anterior dando un mensaje de error
-- en caso de que no existe. (Sin hacer el insert)
--------- ME SALTA: Warning: compiled but with compilation errors Y NO SÉ POR QUÉ
create or replace function pvp (cod varchar2, descrip varchar2, preci number) return number
as
    precio_existe number := 0;
begin
    select precio into precio_existe from productos prod where prod.codigo = cod;
    update productos set descripcion = descrip, coste = preci where codigo = cod;
    return preci*1.2;
    EXCEPTION
    WHEN NO_DATA_FOUND THEN
        RAISE_APPLICATION_ERROR(-20500, 'El producto no existe');
        return preci*1.2;
    WHEN OTHERS THEN
    dbms_output.put_line('Salta la excepcion OTHERS');
    dbms_output.put_line('Codigo de error: '||sqlcode||' Definicion: '||sqlerrm);
    return preci*1.2;
end pvp;


-- 4- Provoca un error para que salte una excepción
-- y captúrala antes de salir de la función.

create or replace function pvp(cod varchar2, descrip varchar2, preci number) return number
as
    prod_existe number;
begin
    select preci into prod_existe from productos prod where codigo = 'OO';
    return preci*1.2;
    EXCEPTION
    WHEN NO_DATA_FOUND THEN
        RAISE_APPLICATION_ERROR(-20501, 'El producto en cuestión no existe');
        return preci*1.2;
    WHEN DUP_VAL_ON_INDEX THEN
        RAISE_APPLICATION_ERROR(-20500, 'El producto en cuestión ya existe');
        return preci*1.2;
    WHEN OTHERS THEN
    dbms_output.put_line('Salta la excepcion OTHERS');
    dbms_output.put_line('Codigo de error: '||sqlcode||' Definicion: '||sqlerrm);
end pvp;


-- 5- Anida todas las excepciones posibles de
-- los ejercicios anteriores en la misma función.
--------- ME SALTA: Warning: compiled but with compilation errors Y NO SÉ POR QUÉ

create or replace function pvp16 (cod varchar2, descrip varchar2, preci number) return number
as
    prod_existe number;
BEGIN
    BEGIN
        select precio into precio_existe from productos prod where prod.codigo = cod;
        EXCEPTION
        WHEN NO_DATA_FOUND THEN
        RAISE_APPLICATION_ERROR(-20501, 'El producto en cuestión no existe');
        return preci*1.2;
    END;
    BEGIN
        insert into productos (codigo, descripcion, coste) values (cod, descrip, preci);
        return preci*1.2;
        EXCEPTION
        WHEN DUP_VAL_ON_INDEX THEN
            RAISE_APPLICATION_ERROR(-20500, 'El producto en cuestión ya existe');
            update productos prod set descripcion = descrip, coste = preci where prod.codigo = cod;
            return preci*1.2;
    END;
    EXCEPTION
    WHEN OTHERS THEN
    dbms_output.put_line('Salta la excepcion OTHERS');
    dbms_output.put_line('Codigo de error: '||sqlcode||' Definicion: '||sqlerrm);
END pvp16;


-- 6-Muestra el número de productos, de forma que indique
-- “No hay productos” en vez de “Hay 0 productos”.

DECLARE
    nProductos number;
BEGIN
    select count(*) into nProductos from productos;
    IF nProductos = 0 THEN
        dbms_output.put_line('No hya productos');
    ELSE
        dbms_output.put_line('Hay '||nProductos||' productos');
    END IF;
END;


/*
7- Crea un bloque PL/SQL en el que insertas un producto con código 3,
ya existente. Haz el control de excepciones de forma que un error de
clave primaria duplicada se ignore (no se inserta el producto pero
el bloque PL/SQL se ejecuta correctamente). Si intentamos insertar
un producto con precio negativo, debe aparecer un error
*/

insert into productos values ('3', 'Tres', 3);

DECLARE
    pCodigo varchar2(10) := '3';
    pDescripcion varchar2(100) := 'Tres';
    pCoste number := 3;
BEGIN
    begin
        IF pCoste < 0 THEN
            dbms_output.put_line('El precio no puede ser negativo');
        ELSE
            insert into productos values (pCodigo, pDescripcion, pCoste);
        END IF;
        
        EXCEPTION
        WHEN DUP_VAL_ON_INDEX THEN
            null;
    end;
    dbms_output.put_line('Comprobamos que el bloque se ejecuta correctamente');

END;


/*
8- Escribe un bloque PL/SQL donde usas un registro para almacenar
los datos de un producto. El bloque insertará ese producto, pero
si el precio no es positivo generará una excepción de tipo precio_prod_invalido,
que deberás declarar previamente, en vez de realizar la inserción.
*/

DECLARE
    pProducto productos%rowtype;
    precio_prod_invalido exception;
BEGIN
    pProducto.codigo := '5';
    pProducto.descripcion := 'Cinco';
    pProducto.coste := -5;
    IF pProducto.coste < 0 THEN
        raise precio_prod_invalido;
    ELSE
        insert into productos values (pProducto.codigo, pProducto.descripcion, pProducto.coste);
    END IF;
    EXCEPTION
    when precio_prod_invalido then
        dbms_output.put_line('El precio del producto no puede ser negativo');
END;


/*
9- Modifica el ejercicio anterior, de forma que ahora
captures la excepción elevada y produces otra,
con SQLCODE y mensaje de error espífico,
usando RAISE_APPLICATION_ERROR
*/

DECLARE
    pProducto productos%rowtype;
    precio_prod_invalido exception;
BEGIN
    pProducto.codigo := '5';
    pProducto.descripcion := 'Cinco';
    pProducto.coste := 5;
    IF pProducto.coste < 0 THEN
        raise precio_prod_invalido;
    ELSE
        insert into productos values (pProducto.codigo, pProducto.descripcion, pProducto.coste);
    END IF;
    EXCEPTION
    when precio_prod_invalido then
        raise_application_error(-20500, 'El precio del producto no puede ser negativo');
END;