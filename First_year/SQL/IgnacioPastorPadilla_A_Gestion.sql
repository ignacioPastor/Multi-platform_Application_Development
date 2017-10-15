-- IgnacioPastorPadilla_A_Gestion

-- Proyecto Final Bases de Datos
-- Profesor: Pablo Garramone
-- 1º DAM - Semipresencial Grupo A



create or replace package gestion is
procedure gestionar_procedimientos (opcion in number, vCodigo in grupo.codigo%type, vModelo in grupo.modelo%type,
                        vGama in grupo.gama%type, vFabricante in grupo.fabricante%type,
                        vPeso in grupo.peso%type, vMaterial in grupo.material%type,
                        vAnyo in grupo.anyo_fabricacion%type);

end gestion;
-------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------
create or replace package body gestion is
    procedure insertar_nuevo (vCodigo in grupo.codigo%type, vModelo in grupo.modelo%type,
                        vGama in grupo.gama%type, vFabricante in grupo.fabricante%type,
                        vPeso in grupo.peso%type, vMaterial in grupo.material%type,
                        vAnyo in grupo.anyo_fabricacion%type);
    procedure modificar_registro (vCodigo in grupo.codigo%type, vModelo in grupo.modelo%type,
                        vGama in grupo.gama%type, vFabricante in grupo.fabricante%type,
                        vPeso in grupo.peso%type, vMaterial in grupo.material%type,
                        vAnyo in grupo.anyo_fabricacion%type);
    procedure borrar_registro (vCodigo in grupo.codigo%type);
    procedure mostrar_registro (vCodigo in grupo.codigo%type);
---------------------------------------------------------------------------------------------------------------
    
    procedure gestionar_procedimientos (opcion in number, vCodigo in grupo.codigo%type, vModelo in grupo.modelo%type,
                        vGama in grupo.gama%type, vFabricante in grupo.fabricante%type,
                        vPeso in grupo.peso%type, vMaterial in grupo.material%type,
                        vAnyo in grupo.anyo_fabricacion%type) is
    BEGIN
        CASE opcion
            when 1 then insertar_nuevo(vCodigo, vModelo, vGama, vFabricante, vPeso, vMaterial, vAnyo);
            when 2 then modificar_registro(vCodigo, vModelo, vGama, vFabricante, vPeso, vMaterial, vAnyo);
            when 3 then borrar_registro(vCodigo);
            when 4 then mostrar_registro(vCodigo);
            else null;
        END CASE;
    END;

--------------------------------------------------------------------------------------------

procedure insertar_nuevo (vCodigo in grupo.codigo%type, vModelo in grupo.modelo%type,
                        vGama in grupo.gama%type, vFabricante in grupo.fabricante%type,
                        vPeso in grupo.peso%type, vMaterial in grupo.material%type,
                        vAnyo in grupo.anyo_fabricacion%type) IS
    BEGIN
        IF vCodigo is null THEN
            raise_application_error(-20100, 'El código no puede quedar en blanco');
        ELSE
            insert into grupo (codigo, modelo, gama, fabricante, peso, material, anyo_fabricacion)
            values (vCodigo, vModelo, vGama, vFabricante, vPeso, vMaterial, vAnyo);
        END IF;
    EXCEPTION
    WHEN dup_val_on_index THEN
        raise_application_error(-20101, 'Ya existe ese producto');
    END;

------------------------------------------------------------------------------------------------

procedure modificar_registro (vCodigo in grupo.codigo%type, vModelo in grupo.modelo%type,
                        vGama in grupo.gama%type, vFabricante in grupo.fabricante%type,
                        vPeso in grupo.peso%type, vMaterial in grupo.material%type,
                        vAnyo in grupo.anyo_fabricacion%type) IS
    BEGIN
        update grupo
        set modelo = vModelo, gama = vGama, fabricante = vFabricante, peso = vPeso, material = vMaterial, anyo_fabricacion = vAnyo
        where codigo = vCodigo;
    EXCEPTION
    WHEN no_data_found THEN
        raise_application_error(-20102, 'El producto que intenta actualizar no se encuentra registrado');
    WHEN OTHERS THEN
    IF sqlcode = -2292 THEN
            raise_application_error(-20041, 'El producto que intenta cambiar tiene hijos (aparece en otras tablas)');
    END IF;
    END;

---------------------------------------------------------------------------------------------

procedure borrar_registro (vCodigo in grupo.codigo%type) IS
    BEGIN
        delete from grupo where codigo = vCodigo;
    EXCEPTION
    WHEN no_data_found THEN
        raise_application_error(-20103, 'El producto que intenta borrar no se encuentra registrado');
    WHEN OTHERS THEN
    IF sqlcode = -2292 THEN
            raise_application_error(-20043, 'El producto que intenta borrar tiene hijos (aparece en otras tablas)'); 
    END IF;
    END;

-----------------------------------------------------------------------------------------------------
-- La tabla temporal que he creado para mostrar los datos se encuentra al final de este archivo
procedure mostrar_registro (vCodigo in grupo.codigo%type) IS
        vModelo grupo.modelo%type;
        vGama grupo.gama%type;
        vFabricante grupo.fabricante%type;
        vPeso grupo.peso%type;
        vMaterial grupo.material%type;
        vAnyo grupo.anyo_fabricacion%type;
    BEGIN
        select modelo, gama, fabricante, peso, material, anyo_fabricacion
        into vModelo, vGama, vFabricante, vPeso, vMaterial, vAnyo
        from grupo
        where codigo = vCodigo;
        
        delete tmp_mostrar1; -- Antes de meter los nuevos datos borramos los previos que pudieren haber
        
        insert into tmp_mostrar1 (codigo, fabricante, modelo, gama, peso, material, anyo_fabricacion)
        values (vCodigo, vFabricante, vModelo, vGama, vPeso, vMaterial, vAnyo);
        
        dbms_output.put_line(vCodigo||vModelo||vGama||vFabricante||vPeso||vMaterial||vAnyo);
    
    EXCEPTION
        WHEN no_data_found THEN
            raise_application_error(-20104, 'El producto que intenta mostrar no se encuentra registrado');
    -- Como la búsqueda es por PK, no es posible que devuelva más de un valor
    END;
END gestion;

-- Para comprobar que todo está bien
begin
    gestion.gestionar_procedimientos(4, 'O01', null, null, null, null, null, null);
end;

--TRIGGER-----------------------------------------------------------------------------------------
create or replace trigger tr_grupo
before insert or update of anyo_fabricacion on grupo
for each row
BEGIN
    if ((:new.anyo_fabricacion is not null) and (:new.anyo_fabricacion > to_number(to_char(sysdate, 'yyyy')))) then
        :new.anyo_fabricacion := null;
    end if;
END;


-- Tabla temporal para mostrar los datos
/*
create global temporary table tmp_mostrar1 (
        codigo varchar2(5),
        fabricante varchar2(50),
        modelo varchar2(20),
        gama varchar2(20),
        peso number(5),
        material varchar2(30),
        anyo_fabricacion number(4))
        on commit preserve rows;
*/