
--drop database if exists bibliotecahibernate;
--drop table if exists libro;
--drop table if exists revista;

create database bibliotecahibernate;


create table libro (
	isbn integer,
	titulo varchar(200),
	autor varchar(100),
	editorial varchar(50),
	anyoPublicacion integer,
	edicionLujo boolean,
	constraint pk_libro primary key (isbn)
);

create table revista (
	issn integer,
	titulo varchar(200),
	editorial varchar(50),
	anyoPublicacion integer,
	mesPublicacion integer,
	constraint pk_revista primary key (issn)
);










