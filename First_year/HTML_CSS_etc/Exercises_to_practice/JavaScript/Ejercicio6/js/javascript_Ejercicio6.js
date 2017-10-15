
var letras = ['T', 'R', 'W', 'A', 'G', 'M', 'Y', 'F', 'P', 'D', 'X',
	'B', 'N', 'J', 'Z', 'S', 'Q', 'V', 'H', 'L', 'C', 'K', 'E', 'T'];
	
var dni = prompt("Escribe tu dni (letra inclusive)\nEj: 12345678A","");

if(dni.length != 9){
	alert("El formato no es correcto, debe componerse de 8 números y una letra")
}else{
	var numeroDni = dni.substring(0,8);
	var letraDni = dni.substring(8);
	var resto = numeroDni % 23;
	if(letras[resto] == letraDni)
		alert("Dni validado!");
	else
		alert("No es un dni válido");
}