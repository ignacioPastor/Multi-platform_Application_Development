
create table actores (
	id varchar(10),
	nombre varchar(30),
	apellidos varchar(60),
	constraint pk_actores primary key (id)
);

create table actuar (
	id varchar(10),
	codigo integer,
	constraint pk_actuar primary key (id, codigo),
	constraint fk_actuar_actores foreign key (id)
		references actores (id),
	constraint fk_actuar_series foreign key (codigo)
		references series (codigo)

);


insert into actores (id, nombre, apellidos)
values ('ac1', 'actor1', 'apellidos1');
insert into actores (id, nombre, apellidos)
values ('ac2', 'nombre2', 'apellidos2');
insert into actores (id, nombre, apellidos)
values ('ac3', 'nombre3', 'apellidos3');
insert into actores (id, nombre, apellidos)
values ('ac4', 'nombre4', 'apellidos4');
insert into actores (id, nombre, apellidos)
values ('ac5', 'nombre5', 'apellidos5');