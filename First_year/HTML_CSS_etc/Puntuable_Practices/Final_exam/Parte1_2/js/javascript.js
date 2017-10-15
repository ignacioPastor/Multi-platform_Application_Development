//Ignacio Pastor Padilla - Examen Convocatoria Anticipada Lenguaje de Marcas 08/02/2017
var regexVacio = /^\s+$/;
window.onload = function(){
	document.getElementById("login").onblur = ValidarDNI;
	document.getElementById("password").onblur = ValidarPassword;
	document.getElementById("nombre").onblur = ValidarNombre;
	document.getElementById("apellido").onblur = ValidarApellido;
	
	document.getElementById("myForm").onsubmit = ValidarFormulario;
}
function ValidarDNI(){
	var regexDNI = /^\d{8}-{1}[A-Z]{1}$/;
	var dni = document.getElementById("login");
	
	if(dni.value == null || dni.value == "" || regexVacio.test(dni.value)){
		crearMensajeError(dni, "El campo no puede quedar vacío");
		return false;
	}else if(!regexDNI.test(dni.value)){
		crearMensajeError(dni, "No es un dni válido (Ej: 12345678-A)");
		return false;
	}else{
		eliminarMensajeError(dni);
		return true;
	}
}
function ValidarPassword(){
	var pass = document.getElementById("password");
	
	var regexPassLengthAlfaNum = /^[A-Za-z0-9]{6,}$/;
	var regexPassMayus = /[A-Z]/;
	var regexPassMinus = /[a-z]/;
	var regexPassNum = /[0-9]/;
	
	if(pass.value == null || pass.value == "" || regexVacio.test(pass.value)){
		crearMensajeError(pass, "El password no puede quedar vacío");
		return false;
	}else if(!regexPassLengthAlfaNum.test(pass.value)){
		crearMensajeError(pass, "El campo debe tener un mínimo de 6 caracteres alfanuméricos");
		return false;
	}else if(!regexPassMayus.test(pass.value)){
		crearMensajeError(pass, "El password debe contener al menos una mayúscula");
		return false;
	}else if(!regexPassMinus.test(pass.value)){
		crearMensajeError(pass, "El password debe contener al menos una minúscula");
		return false;
	}else if(!regexPassNum.test(pass.value)){
		crearMensajeError(pass, "El password debe contener al menos un número");
		return false;
	}else{
		eliminarMensajeError(pass);
		return true;
	}	
}
function ValidarNombre(){
	var nombre = document.getElementById("nombre");
	return ValidarTexto(nombre);
}
function ValidarApellido(){
	var apellido = document.getElementById("apellido");
	return ValidarTexto(apellido);
}
function ValidarTexto(elemento){
	var regexTexto = /^[a-zA-Z]{3,25}$/;
	
	if(elemento.value == null || elemento.value == "" || regexVacio.test(elemento.value)){
		crearMensajeError(elemento, "El " + elemento.id + " no puede quedar vacío");
		return false;
	}else if(!regexTexto.test(elemento.value)){
		crearMensajeError(elemento, "El " + elemento.id + " debe tener mínimo 3 y máximo 25 caracteres alfabéticos");
		return false;
	}else{
		eliminarMensajeError(elemento);
		return true;
	}
}
function ValidarFormulario(){
	var formulario = document.getElementById("myForm");
	ValidarApellido();ValidarDNI();ValidarNombre();ValidarPassword();
	if(!(ValidarDNI() && ValidarApellido() && ValidarNombre() && ValidarPassword())){
		crearMensajeError(formulario, "Hay campos obligatorios sin validar");
		return false;
	}else{
		eliminarMensajeError(formulario);
		return true;
	}
}
function crearMensajeError(elemento, mensaje){
	eliminarMensajeError(elemento);
	var parrafoError = document.createElement("p");
	var mensajeError = document.createTextNode(mensaje);
	parrafoError.appendChild(mensajeError);
	
	parrafoError.setAttribute("class", "error");
	parrafoError.setAttribute("id", elemento.id + "Error");
	document.body.appendChild(parrafoError);
}
function eliminarMensajeError(elemento){
	var parrafoErrorEliminar = document.getElementById(elemento.id + "Error");
	if(parrafoErrorEliminar){
		var padreError = parrafoErrorEliminar.parentNode;
		padreError.removeChild(parrafoErrorEliminar);
	}
}












