function devolverNombreModificar()
{
	var elemento=document.getElementById("modificar");
	var nombreAl=elemento.value;
	var link=document.getElementById("linkModificar");
	link.setAttribute("href","modificarPHP.php?nombre="+nombreAl);
}

function devolverNombreBorrar()
{
	var elemento=document.getElementById("borrar");
	var nombreAl=elemento.value;
	var link=document.getElementById("linkBorrar");
	link.setAttribute("href","borrar.php?nombre="+nombreAl);
}

function devolverNombreConsulta()
{
	var elemento=document.getElementById("consultar");
	var nombreAl=elemento.value;
	var link=document.getElementById("linkConsultar");
	link.setAttribute("href","consultar.php?nombre="+nombreAl);
}