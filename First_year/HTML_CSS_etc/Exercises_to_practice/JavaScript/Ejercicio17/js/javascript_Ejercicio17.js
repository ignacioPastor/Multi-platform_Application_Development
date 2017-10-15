var limite = 10;
var contenido;

var indicador;


window.onload = function(){
	document.getElementById("textoPrueba").focus();
	// document.getElementById("textoPrueba").onchange = cambio;
	document.getElementById("textoPrueba").onkeypress = calcularRestantes;
	// document.getElementById("textoPrueba").onkeyup = especial;
	document.getElementById("textoPrueba").onkeyup = especial;
	contenido = document.getElementById("textoPrueba");
	indicador = document.getElementById("caracteresRestantes");
	indicador.innerHTML = " " + limite - contenido.value.length;
}
function cambio(){
	alert("cambia");
}
function especial(elEvento){
	var evento = elEvento || window.event;
	var codigoCaracter = evento.charCode || evento.keyCode;
	//teclas de derecha e izquierda
	if(codigoCaracter == 37 || codigoCaracter == 39) {
		return true;
	}
	//backspace y supr
	if(codigoCaracter == 8 || codigoCaracter == 46) {
		actualizarInfo(evento, 1);
		return true;
	}
//	indicador.innerHTML = " " + limite - (contenido.value.length + (contenido.value.length < 10 ? 1 : 0)); //&& contenido.value.length != 0 
	
}
function calcularRestantes(elEvento){
	// alert("entra");
	// indicador.innerHTML = " " + limite - ((contenido.value.length + 1) > 1 ? (contenido.value.length + 1) : 0);
	
	var evento = elEvento || window.event;
	var codigoCaracter = evento.charCode || evento.keyCode;

	// indicador.innerHTML = " " + limite - (contenido.value.length + (contenido.value.length < 10 ? 1 : 0)); //&& contenido.value.length != 0 
	// console.log(contenido.value.length);
	console.log("entra en calcularRestantes" + evento.type);
	
	if(contenido.value.length < limite){
		actualizarInfo(evento, 0);
		return true;
	}
	else
		return false;
	
	
}
function actualizarInfo(elEvento, corrector){
	var evento = elEvento || window.event;
	// if(evento.type == "keyup" && contenido.value.length == 0)
		// return;
	indicador.innerHTML = " " + (corrector + limite - (contenido.value.length + (contenido.value.length < 10 ? 1 : 0))); //&& contenido.value.length != 0 
	console.log(contenido.value.length);
}
function limita(limite){
	
	if(this.value.length < limite)
		return true;
	else
		return false;
}