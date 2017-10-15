create database tareasUnit4;

create table tareas (
	codigo varchar(10),
	fecha date,
	descripcion varchar(250),
	completada boolean,
	constraint pk_tareas primary key (codigo)
);


insert into tareas (codigo, fecha, descripcion, completada)
values ('1', '07-12-17', 'descripcion1', true);
insert into tareas (codigo, fecha, descripcion, completada)
values ('2', '02-02-12', 'descripcion2', false);
insert into tareas (codigo, fecha, descripcion, completada)
values ('3', '03-03-13', 'descripcion3', true);
insert into tareas (codigo, fecha, descripcion, completada)
values ('4', '04-04-14', 'descripcion4', false);
insert into tareas (codigo, fecha, descripcion, completada)
values ('5', '05-05-15', 'descripcion5', true);



