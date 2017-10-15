-- IgnacioPastorPadilla_BasesDatos_DAM_Semi_GrupoA
-- Practica_Final_2oTrimestre
-- Consultas

--------------------------------------------------------------------------------
-- a) 5 consultas simples de una sola tabla

-- a.1. Muestra los empleados con una antigüedad de más de 3 años

select *
from empleados
where antiguedad > 3;

-- a.2. Muestra aquellos clisentes que forman parte del club de
-- la tienda y que han comprado ropa de calidad Alta

select *
from equipacion_oficial
where upper(calidad) = 'ALTA';

-- a.3. Muestra el nombre y el producto principal con el que
-- trabaja cada proveedor

select nombre, producto_principal
from proveedor;

-- a.4. Muestra las bicicletas infantiles para niños de más
-- de 10 años.

select *
from infantil
where edad > 10;

-- a.5. Muestra los grupos electrónico que vayan integrados
-- dentro del cuadro.

select *
from sistema_electronico
where upper(colocacion) = 'INTEGRADO';


---------------------------------------------------------------------------------
-- b) 2 actualizaciones y 2 Borrados en cualquier tabla

-- b.1. Con la entrada del nuevo año, suma un año de antigüedad a todos los 
-- empleados de la tienda.

update empleados
set antiguedad = antiguedad + 1;

-- b.2. Rebaja en un punto el procentaje que se lleva la marca
-- en aquellas marcas con las que llevemos más de 3 años trabajando

update marca
set porcentaje = porcentaje - 1
where anyo_trabajo > 3;

-- b.3. Borra de la tabla de equipaciones aquellos que tengan
-- ropa de calidad media de temporada de invierno

delete equipacion_oficial
where upper(temporada) = 'INVIERNO'
and upper(calidad) = 'MEDIA';

-- b.4. Borra las bicicletas de montaña que tengan cuadro de alumnio

delete montanya
where upper(material_cuadro) = 'ALUMINIO';


---------------------------------------------------------------------------------
-- c) 3 consultas con más de 1 tabla (al menos 1 con Outer Join)

-- c.1. Muestra las bicicletas con un diámetro superior
-- a 26 pulgadas. Si la bicicleta es de montaña que aparezca el 
-- tipo de suspensión que tiene

select bi.num_serie, bi.diametro, mon.tipo_suspension
from bicicleta bi, montanya mon
where bi.num_serie = mon.num_serie (+)
and bi.diametro > 26;

-- c.2. Muestra el nombre de clientes que hayan comprado alguna
-- bicicleta en la tienda y que tengan una "a" en su nombre

select cli.*
from cliente cli, comprar_bici cb
where cli.dni = cb.dni_cliente
and upper(cli.nombre) like '%A%';

-- c3. Muestra la experiencia,  la antigüedad de aquellos y habilidad
-- empleados que sean mecánicos

select em.nombre, em.antiguedad, em.experiencia, me.grado_hab
from empleados em, mecanico me
where em.dni = me.dni;


---------------------------------------------------------------------------------
-- d) 3 consultas usando funciones

-- d.1. Muestra la media del precio por el que se han vendido
-- las bicicletas

select avg(importe)
from comprar_bici;

-- d.2. Calcula el dinero que se ha ingresado
-- fruto de las ventas de bicicletas infantiles

select sum(cb.importe)
from comprar_bici cb
where cb.num_serie in (select inf.num_serie
                            from infantil inf);

-- d.3. Muestra la bicicleta más barata que no sea infantil

select bi.*, cb.importe
from bicicleta bi, comprar_bici cb
where bi.num_serie not in (select inf.num_serie
                                from infantil inf)
and bi.num_serie = cb.num_serie
and cb.importe = (select min(cb2.importe)
                    from comprar_bici cb2
                    where cb2.num_serie not in (select inf.num_serie
                                                    from infantil inf));


---------------------------------------------------------------------------------
-- e) 2 consultas usando group by

-- e.1. Muestra cuántas bicicletas de carretera de cada tipo de diseño hay

select disenyo_cuadro, count(*)
from carretera
group by disenyo_cuadro;

-- e.2. Muestra cuántos grupos del año pasado quedan por vender

select anyo_fabricacion, count(*)
from grupo
where anyo_fabricacion = 2015
group by anyo_fabricacion;


---------------------------------------------------------------------------------
-- f) 2 consultas utilizando subconsultas

-- f.1. Muestra los empleados que sean mecánicos con una habilidad media

select em.*, me.grado_hab
from empleados em, mecanico me
where em.dni = me.dni
and me.grado_hab = (select me2.grado_hab
                        from mecanico me2
                        where upper(me2.grado_hab) = 'MEDIO');

-- f.2. Muestra los diametros disponibles para bicicletas de carretera

select bi.diametro
from bicicleta bi
where bi.num_serie in (select ca.num_serie
                        from carretera ca);



---------------------------------------------------------------------------------
-- g) 2 consultas usando subconsultas y group by con having

-- g.1. Muestra de qué diámetros de rueda tenemos más de dos unidades

select diametro, count(*)
from bicicleta
group by diametro
having count(*) > 2;

-- g.2. Muestra el proveedor del que dispongamos de más productos

select prove.nif, count(*)
from proveedor pro, proveer prove
where pro.nif = prove.nif
group by prove.nif
having count(*) = (select max(count(*))
                    from proveedor pro2, proveer prove2
                    where pro2.nif = prove2.nif
                    group by prove2.nif);


---------------------------------------------------------------------------------
-- h) 3 actualizaciones usando subconsultas en where y set

-- h.1. Acutaliza el rating de venta a Alto, en aquellos vendedores que lo tengan
-- como Medio, y hayan vendido alguna bicicleta por más de 2500 euros. 

update vendedor ven
set ven.rating = 'Alto'
where ven.rating = 'Medio'
and ven.dni in (select cb.dni_empleados
                    from comprar_bici cb
                    where cb.importe > 2500);

-- h.2. Actualiza la experiencia del empleado con menos antigüedad
-- de forma que sea la misma que el empleado de más antigüedad

update empleados em
set em.experiencia = (select em2.experiencia
                        from empleados em2
                        where em2.antiguedad = (select max(em3.antiguedad)
                                                    from empleados em3))
where em.antiguedad = (select min(em4.antiguedad)
                            from empleados em4);

-- h.3. Nos dicen que ha habido un error al registrar el peso del 
-- grupo de alta gama de un fabricante. El fabricante contiene "sh"
-- en su nombre. Incrementa el peso del producto en 100g

update grupo gru
set gru.peso = gru.peso + 100
where upper(gru.gama) = 'ALTA'
and upper(gru.fabricante) like '%SH%';


------------------------------------------------------------------------------------
-- i) 2 consultas usando operadores de Conjuntos

-- i.1. Muestra el dni de los empleados que tengan una antigüedad
-- de más de 5 años, que en su experiencia no aparezca la letra i,
-- que su dni tenga al menos un 0. O que su 2a letra del nombre sea a, 
-- y que su rating sea Alto, o su grado de habilidad sea Alto

(
    select dni
    from empleados
    where antiguedad > 5
    INTERSECT
    select dni
    from empleados
    where upper(nombre) not like '%I%'
    INTERSECT
    select dni
    from empleados
    where dni like '%0%'
)
UNION
(
    select dni
    from empleados
    where upper(nombre) like '_A%'
    INTERSECT
    (
        select dni
        from vendedor
        where rating = 'Alto'
        UNION
        select dni
        from mecanico
        where grado_hab = 'Alto'
    )
);

-- i.2. Muestra el numero de serie de las bicicletas cuyo peso
-- baje de los 8Kg siendo de carretera, o que tengan un grupo de gama alta, 
-- o que tengan un diametro de rueda superior a 
-- 26 pulgadas y un grupo de gama media, pero que el grupo no sea 
-- Shimano

select bi.num_serie
from bicicleta bi, carretera ca
where bi.num_serie = ca.num_serie
and ca.peso < 8
UNION
select bi.num_serie
from bicicleta bi, grupo gru
where bi.codigo = gru.codigo
and gru.gama = 'Alta'
UNION
(
    (
        select num_serie
        from bicicleta
        where diametro > 26
        INTERSECT
        select bi.num_serie
        from bicicleta bi, grupo gru
        where bi.codigo = gru.codigo
        and gru.gama = 'Media'
    )
    MINUS
        select bi.num_serie
        from bicicleta bi, grupo gru
        where bi.codigo = gru.codigo
        and gru.fabricante <> 'Shimano'
);


----------------------------------------------------------------------------

-- j) 2 vistas normales y 1 materializada

-- j.1. Crea una vista sobre clientes que se hayan
-- gastado más de 2000 euros en una compra

create or replace view j1
as
select cli.nombre
from cliente cli, comprar_bici cb
where cli.dni = cb.dni_cliente
and cb.importe > 2000;

-- j.2. Crea una vista no actualizable sobre las 
-- bicicletas con un sistema electrónico en su grupo

create or replace view j2
as
select bi.num_serie, bi.diametro, gru.*, se.autonomia, se.colocacion
from bicicleta bi, grupo gru, sistema_electronico se
where bi.codigo = gru.codigo
and gru.codigo = se.codigo
with read only;

-- j.3. Crea una vista materializada que se se refesque cada dos días
-- que muestre el nombre de los proveedores junto con el tipo y descripción
-- del producto que proveen.

create materialized view j3
build immediate
refresh start with sysdate next sysdate + 2
as
select pro.nombre, prod.tipo, prod.descripcion
from proveedor pro, proveer prove, producto prod
where pro.nif = prove.nif
and prove.codigo = prod.codigo;