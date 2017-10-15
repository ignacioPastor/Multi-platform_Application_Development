
var nUsuario = prompt("Introduce un número");

if(isNaN(nUsuario)){
	alert("No es un número!");
}else{
	alert("El número " + nUsuario + " es " + esParOImpar(nUsuario) + ".");
}

function esParOImpar(numero){
	if(numero % 2 == 0)
		return "par";
	else
		return "impar";
}
