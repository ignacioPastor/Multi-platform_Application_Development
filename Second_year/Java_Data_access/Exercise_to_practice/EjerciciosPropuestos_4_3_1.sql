
drop database if exists HibernateEj1;
create database HibernateEj1;

drop table if exists series;
create table series (
	codigo integer,
	nombre varchar(60),
	cadena varchar(35),
	duracion integer,
	constraint pk_series primary key (codigo)
);

insert into series (codigo, nombre, cadena, duracion)
values (1, 'The Big Bang Theory', 'Neox', 22);

insert into series (codigo, nombre, cadena, duracion)
values (2, 'C.S.I.: Miami', 'Energy', 43);

insert into series (codigo, nombre, cadena, duracion)
values (3, 'House', 'Cuatro', 40);





