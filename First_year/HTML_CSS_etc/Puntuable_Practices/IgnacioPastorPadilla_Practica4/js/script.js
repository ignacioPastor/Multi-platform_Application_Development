// Ignacio Pastor Padilla - Practica 4 Lenguaje de Marcas

var register;

window.onload = function(){
	if(document.getElementById("login") != null){
		document.getElementById("login").onsubmit = validaLogin;
		document.getElementById("nick").onblur = validaNick;
		document.getElementById("password").onblur = validaPassword;
		register = false;
	}
	else{
		register = true;
		document.getElementById("register").onsubmit = validaRegister;
		document.getElementById("usuario").onblur = validaNick;
		document.getElementById("contrasenya").onblur = validaPassword;
		document.getElementById("contrasenya2").onblur = validaPassword2;
		document.getElementById("email").onblur = validaMail;
	}
}
function validaRegister(){
	var bEnviar = document.getElementById("enviar");
	if(validaNick() && validaPassword() && validaPassword2() && validaFecha() && validaMail()){
		eliminarMensajeError(bEnviar);
		return true;
	}else{
		mensajeError(bEnviar, "Resuelve los errores del formulario antes de enviar");
		return false;
	}
}
function validaMail(){
	var email = document.getElementById("email");
	var regexVacio = /^\s+$/;
	var regexMail = /^(.+\@.+\..+)$/;
	
	if(email.value == null || email.value == "" || regexVacio.test(email.value) ){
		mensajeError(email,"El e-Mmail no puede estar vacío.");
		return false;
	}
	if(regexMail.test(email.value) == false){
		mensajeError(email,"No se ha introducido un e-Mail válido.");
		return false;
	}else{
		eliminarMensajeError(email);
		return true;
	}
}
function validaFecha(){
	var fechaNac = document.getElementById("fecha");
	var regexVacio = /^\s+$/;
	var regexFecha = /^\d{2}\/\d{2}\/((19[0-9]{2})|(20[01][0-2]))$/;
	
	if(fechaNac.value == null || fechaNac.value == "" || regexVacio.test(fechaNac.value)){
		mensajeError(fechaNac,"El campo fecha no puede estar vacía.");
		return false;
	}else if(regexFecha.test(fechaNac.value)){
		mensajeError(fechaNac,"La fecha no es válida, debe ser una fecha entre 1900 y 2012.");
		return false;
	}else{
		eliminarMensajeError(fechaNac);
		return true;
	}
}
function validaLogin(){
	var miBoton = document.getElementById("enviar");
	if(validaNick() == true && validaPassword() == true){
		eliminarMensajeError(miBoton);
		return true;
	}
	else{
		mensajeError(miBoton, "Resuelve los errores del formulario antes de enviar.");
		return false;
	}
}
function validaPassword2(){
	var miPass2 = document.getElementById("contrasenya2");
	var miPass = document.getElementById("contrasenya");
	
	eliminarMensajeError(miPass2);
	if(miPass2.value != miPass.value)
	{
		mensajeError(miPass2, "Los password no coinciden");
		return false;
	}else{
		eliminarMensajeError(miPass2);
		return true;
	}
	
}
function validaNick(){
	if(register)
		var miControl = document.getElementById("usuario");
	else
		var miControl = document.getElementById("nick");		

	var regexVacio = /^\s+$/;
	var regexUsuario = /^[a-zA-Z0-9]+$/;
	eliminarMensajeError(miControl);
	if(miControl.value == null || miControl.value.length == 0 || regexVacio.test(miControl.value))
	{
		mensajeError(miControl, "El nombre de usuario no puede quedar vacío");
		return false;
	}else if(miControl.value.length > 10)
	{
		mensajeError(miControl, "La longitud máxima son 10 caracteres");
		return false;
	}else if(!regexUsuario.test(miControl.value)){
		mensajeError(miControl, "Sólo son válidos los caracteres alfanuméricos");
		return false;
	}else{
		eliminarMensajeError(miControl);
		return true;
	}
}

function validaPassword(){
	if(register)
		var miPass = document.getElementById("contrasenya");
	else
		var miPass = document.getElementById("password");
	
	var regexVacio = /^\s+$/;
	var regexPassword = /[a-zA-Z]{1,}[0-9]{1,}/;
	if(miPass.value == null || miPass.value.length == 0 || regexVacio.test(miPass.value)){
		mensajeError(miPass, "El password no puede quedar vacío");
		return false;
	}else if(miPass.value.length <6){
		mensajeError(miPass, "El password debe tener al menos 6 caracteres");
		return false;
	}else if(!regexPassword.test(miPass.value)){
		mensajeError(miPass, "El password debe contener al menos una letra y un número");
		return false;
	}else if(document.getElementById("usuario") && (document.getElementById("usuario").value == miPass))
	{
		mensajeError(miPass, "El password y el usuario no pueden coincidir");
		return false;
	}else{
		eliminarMensajeError(miPass);
		return true;
	}
}

function mensajeError(elemento, mensaje){
	//Para que no se acumulen los mensajes de error. Mostraremos uno por campo cada vez.
	if(document.getElementById(elemento.id + "Error")){
		document.getElementById((elemento.id + "Error")).parentNode.removeChild(document.getElementById(elemento.id + "Error"));
	}
	
	var parrafoError = document.createElement("p");
	var nodoMensaje = document.createTextNode(mensaje);
	parrafoError.appendChild(nodoMensaje);
	
	document.body.appendChild(parrafoError);
	var posicionElemento = getAbsoluteElementPosition(elemento);
	
	parrafoError.style.position = "absolute";
	parrafoError.style.top = (posicionElemento.top - 30) + "px";
	parrafoError.style.left = (posicionElemento.left + 230) + "px";
	
	parrafoError.setAttribute("class", "error");
	parrafoError.setAttribute("id", elemento.id + "Error");
}

function getAbsoluteElementPosition(element) { 
    if (!element)
        return { top:0,left:0 };

    var y = 0;
    var x = 0;
    while (element.offsetParent) {
        x += element.offsetLeft;
        y += element.offsetTop;
        element = element.offsetParent;
    }
    return {top:y,left:x};
}

function eliminarMensajeError(elemento){
	if(document.getElementById(elemento.id + "Error")){
		document.getElementById((elemento.id + "Error")).parentNode.removeChild(document.getElementById(elemento.id + "Error"));
		// document.getElementById(elemento.id + "error").parentNode.removeChild(document.getElementById(elemento.id + "Error"));
	}
}