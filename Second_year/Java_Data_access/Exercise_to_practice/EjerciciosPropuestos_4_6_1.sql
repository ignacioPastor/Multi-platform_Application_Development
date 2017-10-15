
drop if exists table series;
drop if exists table cadenas;
drop if exists database hibernateej2;

create database hibernateej2;
create table cadenas (
	codigo varchar(6),
	nombre varchar(35),
	constraint pk_cadenas primary key (codigo)
);
create table series (
	codigo integer,
	nombre varchar(60),
	codCadena varchar(6),
	duracion integer,
	constraint pk_series primary key (codigo),
	constraint fk_series_cadenas foreign key (codCadena)
		references cadenas (codigo)
);

insert into cadenas (codigo, nombre)
values ('cad1', 'cadena1');
insert into cadenas (codigo, nombre)
values ('cad2', 'cadena2');
insert into cadenas (codigo, nombre)
values ('cad3', 'cadena3');
insert into cadenas (codigo, nombre)
values ('cad4', 'cadena4');
insert into cadenas (codigo, nombre)
values ('cad5', 'cadena5');

insert into series (codigo, nombre, codCadena, duracion)
values (1, 'nombre1', 'cad1', 11);
insert into series (codigo, nombre, codCadena, duracion)
values (2, 'nombre2', 'cad2', 22);
insert into series (codigo, nombre, codCadena, duracion)
values (3, 'nombre3', 'cad3', 33);
insert into series (codigo, nombre, codCadena, duracion)
values (4, 'nombre4', 'cad4', 44);
insert into series (codigo, nombre, codCadena, duracion)
values (5, 'nombre5', 'cad5', 55);
insert into series (codigo, nombre, codCadena, duracion)
values (6, 'nombre6', 'cad4', 66);
insert into series (codigo, nombre, codCadena, duracion)
values (7, 'nombre7', 'cad5', 77);







