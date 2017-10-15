-- IgnacioPastorPadilla_A_Estadisticas

-- Proyecto Final Bases de Datos
-- Profesor: Pablo Garramone
-- 1º DAM - Semipresencial Grupo A



create or replace package estadisticas is 
    procedure gestionar_estadisticas(opcion in number, n in number);
end estadisticas;

----------------------------------------------------------------------------------------------------------------------

create or replace package body estadisticas is

    procedure ventas_vendedores;
    procedure max_autonomia;
    procedure listar_bicis (n in number);
    procedure venta_localidades_club;
    procedure nivel;
    procedure datos_empleados_venden;
    

    procedure gestionar_estadisticas (opcion in number, n in number) is
    begin
        CASE opcion
            when 1 then ventas_vendedores;
            when 2 then max_autonomia;
            when 3 then listar_bicis(n);
            when 4 then venta_localidades_club;
            when 5 then nivel;
            when 6 then datos_empleados_venden;
            else null;
        end case;
    end;    

--------------------------------------------------------------------------------
    procedure ventas_vendedores is
        cursor cVendedores is
            select em.dni, em.nombre, count(*) n_ventas
                from empleados em, vendedor ven
                where em.dni = ven.dni
                group by em.dni, em.nombre;
        vVendedores cVendedores%rowtype;
    BEGIN
        OPEN cVendedores;
        FETCH cVendedores INTO vVendedores;
        WHILE cVendedores%FOUND LOOP
        
        dbms_output.put_line(vVendedores.dni||vVendedores.nombre||vVendedores.n_ventas);
        FETCH cVendedores INTO vVendedores;
        END LOOP;
        
        CLOSE cVendedores;
    
    END;
------------------------------------------------------------------------------------------------------------    
    procedure max_autonomia is
        cursor cAutonomia is
            select gr.codigo, gr.modelo, gr.fabricante, se.autonomia
                from grupo gr, sistema_electronico se
                where gr.codigo = se.codigo
                and se.autonomia = (select max(se2.autonomia)
                                            from grupo gr2, sistema_electronico se2
                                            where gr2.codigo = se2.codigo
                                            and gr2.fabricante = gr.fabricante
                                            group by gr2.fabricante);
        vAutonomia cAutonomia%rowtype;
    BEGIN
        OPEN cAutonomia;
        
        
        LOOP
        FETCH cAutonomia INTO vAutonomia;
        
        EXIT WHEN cAutonomia%NOTFOUND;
        dbms_output.put_line(vAutonomia.codigo||vAutonomia.modelo||vAutonomia.fabricante||vAutonomia.autonomia);
        
        END LOOP;
        
        CLOSE cAutonomia;
    
    END;
 -----------------------------------------------------------------------------------------------------------------------   
    procedure listar_bicis (n in number) is
    cursor cBicis is
        select bi.num_serie, bi.diametro, gr.modelo,
            ca.peso, ca.talla, ca.material_cuadro
        from bicicleta bi, grupo gr, carretera ca
        where bi.codigo = gr.codigo
        and bi.num_serie = ca.num_serie
        order by ca.peso;
    vBicis cBicis%rowtype;
    contador number := 0;
    /*
    vNum_serie bicicleta.num_serie%type;
    vDiametro bicicleta.diametro%type;
    vModelo grupo.modelo%type;
    vPeso carretera.peso%type;
    vTalla carretera.talla%type;
    vMaterial_cuadro carretera.material_cuadro%type;
    */
    begin
        OPEN cBicis;
        LOOP
        
        FETCH cBicis INTO vBicis;
        
        IF cBicis%NOTFOUND THEN
            EXIT;
        ELSIF contador = n THEN
            EXIT;
        ELSE
            dbms_output.put_line(vBicis.num_serie||vBicis.diametro||
                vBicis.modelo||vBicis.peso||vBicis.talla||vBicis.material_cuadro);
            contador := contador + 1;
        END IF;
        END LOOP;
        CLOSE cBicis;
    end;

---------------------------------------------------------------------------------------------------------------------

    procedure venta_localidades_club is
    cadena varchar2(1000);
BEGIN
    cadena := 'DECLARE cursor cLocalidadesClub is
        select cl.localidad, sum(cli.productos) cantidad_productos
        from club cl, cliente cli
        where cl.codigo = cli.codigo
        group by cl.localidad; BEGIN FOR i in cLocalidadesClub LOOP dbms_output.put_line(i.localidad||
        i.cantidad_productos); END LOOP; END;';
    execute immediate cadena;
END;
--------------------------------------------------------------------------------------------

    procedure nivel is
        cursor cNivel is
            select distinct em.dni, decode(em.dni, (select ve2.dni
                                            from vendedor ve2
                                            where ve2.dni = em.dni), ve.rating,
                                                                                (select me2.dni
                                                                                 from mecanico me2
                                                                                 where me2.dni = em.dni), me.grado_hab, 0) nivel, em.antiguedad
            from empleados em, vendedor ve, mecanico me
            where (em.dni = ve.dni or em.dni = me.dni)
            order by em.antiguedad;
            
            vNivel cNivel%rowtype;
    BEGIN
        OPEN cNivel;
        FETCH cNivel INTO vNivel;
        WHILE cNivel%FOUND LOOP
            dbms_output.put_line(vNivel.dni||vNivel.nivel||vNivel.antiguedad);
            FETCH cNivel INTO vNivel;
        END LOOP;
        CLOSE cNivel;
    END;

---------------------------------------------------------------------------------------------------

    procedure datos_empleados_venden is
        cursor c1Mecanico is
            select dni
            from mecanico;
        cursor c2Empleado(vC1 mecanico.dni%type) is
            select nombre, experiencia, antiguedad
            from empleados
            where dni = vC1;
    BEGIN
        FOR i IN c1Mecanico LOOP
            FOR j IN c2Empleado (i.dni) LOOP
                dbms_output.put_line(j.nombre||j.antiguedad||j.experiencia);
            END LOOP;
        END LOOP;
    END;

--------------------------------------------------------------------------------------------------------

END estadisticas;

-- Para checkear
begin
    estadisticas.gestionar_estadisticas(3, 3);
end;