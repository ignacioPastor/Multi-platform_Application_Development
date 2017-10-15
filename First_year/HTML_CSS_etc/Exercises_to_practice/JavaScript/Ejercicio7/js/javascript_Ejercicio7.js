
var nUsuario = prompt("Indica un número");
if(isNaN(nUsuario))
	alert("No es un número");
else{
	var resultadoCadena = "";
	var resultadoNumerico = 1;
	for(var i = nUsuario; i > 0; i--){
		resultadoCadena += i.toString() + " x ";
		resultadoNumerico *= i;
	}
	resultadoCadena = resultadoCadena.substring(0, resultadoCadena.length - 3);
	alert(nUsuario + "! = " + resultadoCadena + " = " + resultadoNumerico);
}