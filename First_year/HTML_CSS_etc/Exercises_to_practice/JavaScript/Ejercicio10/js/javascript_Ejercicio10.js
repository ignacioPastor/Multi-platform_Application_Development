var cadena = prompt("Introduce una cadena de texto para ver si es palíndromo");
if(cadena == "")
	alert("Debes introducir una cadena de texto!");
else{
	if(esPalindromo(cadena))
		alert(cadena + " es palíndromo.");
	else
		alert(cadena + " no es palíndromo.");
}
function esPalindromo(texto){
	var medio;
	var medio2;
	if(texto.length % 2 == 0){
		medio = texto.length / 2;
		medio2 = medio;
	}
	else{
		medio = texto.length / 2;
		medio = medio.toFixed(0);
		medio2 = medio - 1;
	}
	var primeraMitad = texto.substring(0, medio);
	var segundaMitad = texto.substring(medio2, texto.length);
	var segundaMitadInvertida = segundaMitad.split("").reverse().join("");
	// alert(primeraMitad + " " + segundaMitad + " " + segundaMitadInvertida);
	return primeraMitad == segundaMitadInvertida;
}
