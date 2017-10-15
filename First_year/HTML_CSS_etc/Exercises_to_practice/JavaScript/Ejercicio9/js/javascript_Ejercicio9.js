var cadena = prompt("Introduce una cadena de texto");
if(cadena == "" || !isNaN(cadena))
	alert("Debes introducir una cadena de texto!");
else{
	var resultado = mayusMinus(cadena);
	alert(resultado);
	
}
function mayusMinus(texto){
	// alert(texto + "  " + texto.toUpperCase().toString());
	if(texto == texto.toUpperCase()){
		return "La cadena \"" + texto + "\" está formada solo por mayúsculas";
	}
	else if(texto == texto.toLowerCase()){
		return "La cadena \"" + texto + "\" está formada solo por minúsculas";
	}
	else{
		return "La cadena \"" + texto + "\" está formada por mayúsculas y minúsculas";
	}
}