-- IgnacioPastor_A_Triggers

/*
1- Supongamos que tenemos las siguientes tablas con los siguientes atributos:
CUENTA: PK nro_cuenta (10 caracteres) y balance
(numérico).
TRANSACCION: PK nro_cuenta(10 caracteres), PK hora_modificacion
(tipofecha), id_cliente(10 caracteres), ant_balance (numérico), act_balance
(numérico).
Crear un disparador que consiga mantener actualizada la tabla transacción cada vez que se
modifique la tabla cuenta (se cambie el atributo balance).
*/

-- Creamos las tablas 
create table cuenta (
    nro_cuenta varchar2(10) not null,
    balance number,
constraint pk_cuenta primary key (nro_cuenta));

create table transaccion (
    nro_cuenta varchar2(10) not null,
    hora_modificacion date not null,
    id_cliente varchar2(10),
    ant_balance number,
    act_balance number,
constraint pk_transaccion primary key (nro_cuenta, hora_modificacion),
constraint fk_nro_cuenta foreign key (nro_cuenta)
    references cuenta (nro_cuenta));

-- Trigger
create or replace trigger tr_actu_transaccion
after insert or delete or update of balance on cuenta
for each row
BEGIN
    if inserting then
        insert into transaccion (nro_cuenta, hora_modificacion, id_cliente, ant_balance, act_balance)
        values (:new.nro_cuenta, sysdate, to_char(user), :old.balance, :new.balance);
    elsif deleting then
        insert into transaccion (nro_cuenta, hora_modificacion, id_cliente, ant_balance, act_balance)
        values (:old.nro_cuenta, sysdate, to_char(user), :old.balance, :new.balance);
    else
        insert into transaccion (nro_cuenta, hora_modificacion, id_cliente, ant_balance, act_balance)
        values (:old.nro_cuenta, sysdate, to_char(user), :old.balance, :new.balance);
    end if;
END;

-- Comprobamos que todo va perfect

insert into cuenta (nro_cuenta, balance)
values ('ABCD', 100);

-- Toca deshabilitar la fk de transacción porque si no, al borrar una cuenta
-- no me permite almacenar esa transacción. O transacciones que se hayan
-- hecho previas a borrarla. Y pienso que es interesante que queden registradas.
alter table transaccion disable constraint fk_nro_cuenta;

delete cuenta where nro_cuenta = 'ABCD';

update cuenta
set balance = balance + 100;


----------------------------------------------------------------------------------------------------
/*
2- Supongamos que tenemos una tabla de distancias de diferentes rutas y que
queremos guardar estas distancias en kilómetros y en millas.
Distancias: PK ruta (10 caracteres), distancia_k (numérico), distancia_m (numérico).
Crear disparadores para conseguir que cuando se introduzca (o se modifique)
Una distancia en kilómetros, automáticamente se introduzca también en millas
y viceversa. (1 Km=0.621371 millas y 1 Milla=1.609344 Km)
*/

create table distancias (
    ruta varchar2(10) not null,
    distancia_k number,
    distancia_m number,
constraint pk_distancias primary key (ruta));

create or replace trigger trigger_distancias
before insert or update on distancias
for each row
BEGIN
    if inserting then
        if (:new.distancia_k is null and :new.distancia_m is null) then
            raise_application_error(-20101, 'Ambas distancias no pueden estar vacías');
        elsif (:new.distancia_k is null and :new.distancia_m is not null) then
            :new.distancia_k := :new.distancia_m * 1.609344;
        elsif (:new.distancia_k is not null and :new.distancia_m is null) then
            :new.distancia_m := :new.distancia_k * 0.621371;
        elsif (:new.distancia_k * 0.621371 <> :new.distancia_m) then
            raise_application_error(-20100, 'No concuerda la distancia en Km con la distancia en Millas, introduce un solo valor si no estás seguro de la conversión');
        end if;
    else
        if (:old.distancia_k <> :new.distancia_k and :old.distancia_m <> :new.distancia_m) then
            if (:new.distancia_k * 0.621371 <> :new.distancia_m) then
            raise_application_error(-20102, 'No concuerda la distancia en Km con la distancia en Millas, introduce un solo valor si no estás seguro de la conversión');
            end if;
        elsif (:old.distancia_k <> :new.distancia_k) then
            :new.distancia_m := :new.distancia_k * 0.621371;
        else
            :new.distancia_k := :new.distancia_m * 1.609344;
        end if;
    end if;
END;
--------------------------------------------------------------

-- 3. Transformar el siguiente esquema relacional haciendo desaparecer las
-- claves ajenas mediante el uso de disparadores

-- Primero creamos las tablas

CREATE TABLE EMPLOYEE(
NAMEP VARCHAR2(15) NOT NULL,
INIC VARCHAR2(1),
SURNAME VARCHAR2(15) NOT NULL,
NSS VARCHAR2(9) NOT NULL,
DATEN DATE,
ADDRESS VARCHAR2(30),
SEX VARCHAR2(1),
SALARY NUMBER(10,2),
ND NUMBER NOT NULL,
PRIMARY KEY (NSS));

CREATE TABLE DEPARTAMENT(
NAMED VARCHAR2(15) NOT NULL,
NUMBERD NUMBER NOT NULL,
DATEINICGTE DATE,
PRIMARY KEY (NUMBERD));

CREATE TABLE SITE_DEPTS(
NUMBERD NUMBER NOT NULL,
SITED VARCHAR2(15) NOT NULL,
PRIMARY KEY (NUMBERD, SITED));

CREATE TABLE PROJECT(
NAMEPR VARCHAR2(15) NOT NULL,
NUMBERPR NUMBER NOT NULL,
SITEPR VARCHAR2(15),
NUMD NUMBER NOT NULL,
PRIMARY KEY (NUMBERPR));

CREATE TABLE WORK_IN(
NSSE VARCHAR2 (9) NOT NULL,
NUMP NUMBER NOT NULL,
HOURS NUMBER(3,1) NOT NULL,
PRIMARY KEY (NSSE, NUMP));


--Trigger tabla Departament

create or replace trigger tr_departament
before delete or update of numberd on departament
for each row
DECLARE
    vEmployee number;
    vSite number;
    vProject number;
BEGIN
    if updating then
        raise_application_error(-20100, 'No puedes modificar este registro. Hijos encontrados');
    else
        select count(*) into vEmployee from employee where :old.numberd = nd;
        select count(*) into vSite from site_depts where :old.numberd = numberd;
        select count(*) into vProject from project where :old.numberd = numd;
        if ( vEmployee> 0) then
            delete employee where nd = :old.numberd;
        elsif ( vSite > 0) then
            delete site_depts where numberd = :old.numberd;
        elsif ( vProject > 0) then
            delete project where numd = :old.numberd;
        end if;
    end if;
END;

-- Trigger tabla employee

create or replace trigger tr_employee
before insert or delete or update of nss on employee
for each row
DECLARE
    vWork number;
    vDepartament number;
BEGIN
    if updating then
        raise_application_error(-20110, 'No puedes actualizar este campo. Hijos encontrados');
    elsif deleting then
        select count(*) into vWork from work_in where nsse = :old.nss;
        if (vWork > 0) then
            delete work_in where nsse = :old.nss;
        end if;
    else
        select count(*) into vDepartament from departament where numberd = :new.nd;
        if (vDepartament = 0) then
            raise_application_error(-20111, 'Error. Padre no encontrado en la tabla departament');
        end if;
    end if;
END;

-- Trigger de la tabla site_depts

create or replace trigger tr_site_depts
before insert  or update of numberd on site_depts
for each row
DECLARE
    vDepartament number;
BEGIN
    -- No es necesario un if updatin o inserting porque en ambos casos el objetivo es el mismo, ver si el new numberd tiene padre
    select count(*) into vDepartament from departament where numberd = :new.numberd;
        if (vDepartament = 0) then
            raise_application_error(-20120, 'Error: Padre no encontrado');
        end if;
END;

-- Trigger de la tabla Project

create or replace trigger tr_project
before insert or delete or update of numberpr on project
for each row
DECLARE
    vWork number;
    vDepartament number;
BEGIN
    if deleting then
        select count(*) into vWork from work_in where nump = :old.numberpr;
        if (vWork > 0) then
            raise_application_error(-20130, 'Error: Hijos encontrados');
        end if;
    else
        select count(*) into vDepartament from departament where numberd = :new.numd;
        if (vDepartament = 0) then
            raise_application_error(-20131, 'Error: Padre no encontrado');
        end if;
    end if;
END;

-- Trigger de la tabla Work_in

create or replace trigger tr_work_in
before insert or update of nsse or update of nump on work_in
for each row
DECLARE
    vEmp number;
    vPro number;
BEGIN
    if updating('NSSE') then
        select count(*) into vEmp from employee where nss = :new.nsse;
        if (vEmp = 0) then
            raise_application_error(-20040, 'Error: Padre no encontrado');
        end if;
    elsif updating('NUMP') then
        select count(*) into vPro from project where numberpr = :new.nump;
        if (vPro = 0) then
            raise_application_error(-20041, 'Error: Padre no encontrado');
        end if;
    else
        select count(*) into vEmp from employee where nss = :new.nsse;
        select count(*) into vPro from project where numberpr = :new.nump;
        if (vEmp = 0 and vPro = 0) then
            raise_application_error(-20043, 'Error: Padre no encontrado para nsse ni para nump');
        elsif (vEmp = 0) then
            raise_application_error(-20042, 'Error: Padre no encontrado para nsse');
        elsif (vPro = 0) then
            raise_application_error(-20042, 'Error: Padre no encontrado para nump');
        end if;
    end if;
END;


-- 4. Diseña un trigger que al insertar un nuevo empleado o al actualizar su
-- salario, el presupuesto del departamento se actualice

-- Primero creamos las tablas

create table empleado4 (
    nss number not null,
    nombre varchar2(10),
    salario number,
    num_dep varchar2(10),
constraint pk_empleado4 primary key (nss),
constraint fk_empleado4_departamento4 foreign key (num_dep)
    references departamento4 (num_dep));
    
create table departamento4 (
    num_dep  varchar2(10) not null,
    nombre varchar2(10),
    presupuesto number,
constraint pk_departamento4 primary key (num_dep));

-- Y hacemos el trigger

create or replace trigger tr_empleado4
after insert or update of salario on empleado4
for each row
BEGIN
    if inserting then
        update departamento4
            set presupuesto = presupuesto + :new.salario
            where :new.num_dep = departamento4.num_dep;
     else
        update departamento4
            set presupuesto = presupuesto + (:new.salario - :old.salario)
            where :old.num_dep = departamento4.num_dep;
     end if;
END;

/*
Si tenemos una serie de disparadores cuyo evento es el mismo y cuya acción
es la inserción de filas en una tabla, pero de forma que estén definidos de la
siguiente manera:
 1 a nivel de orden con temporalidad BEFORE
 1 a nivel de orden con temporalidad AFTER
 1 a nivel de fila con temporalidad BEFORE
 1 a nivel de fila con temporalidad AFTER
Determinar, mediante un ejemplo, el orden en que se irán activando dichos
disparadores mostrando como va variando el contenido de la tabla en la que se
inserta.
*/

/*

Orden de activación:
1. nivel de orden con temporalidad BEFORE
2. nivel de fila con temporalidad BEFORE
3. nivel de fila con temporalidad AFTER
4. nivel de orden con temporalidad AFTER

Ejemplo: En una tabla productos donde hay un precio, nombre y descripción.
Tenemos triggers para controlar que el precio no sea negativo, que las modificaciones
se guarden en un histórico. Y controlamos también quién y cuando intenta realizar
alguna acción (en una tabla de intentos), y llevaremos también el control del número
de modificaciones que sufre cada tabla mediante un contador de modificaciones que tenemos en otra tabla
Dados los siguientes triggers:
 T1 (orden, before) Almacena el usuario, hora y tipo de acción que ejecuta
 T2 (orden, after) Gestiona un contador de modificaciones que sufre cada tabla, contador que está en otra tabla
 T3 (fila, before) Comprueba que el precio introducido no sea negativo. Si lo es, lo modifica a 0.
 T4 (fila, after) Almacena en un histórico de precios, el precio y datos antiguos del producto modificado
 
 El orden en que estos triggers se ejecutaría sería: T1, T3, T4, T2.
 Es decir, primero se almacenan los datos del intento de acción.
 Después se comprueba que el precio que se introduce no es negativo.
 A continuación registra los datos anteriores del producto en una tabla histórico
 Y finalmente suma uno al contador de modificaciones de esa tabla

*/