

window.onload = function(){
	document.onmousemove = mostrarInfo;
	document.onkeypress = mostrarInfo;
	document.onclick = mostrarInfo;
}
var contadorClick = false;
function mostrarInfo(elEvento){
	//Se ha detectado que el evento click del ratón genera inmediatamente
	// después un evente de mousemove, por lo que con este código suprimimos
	// el manejo del evento posterior al click
	if(contadorClick){
		contadorClick = false;
		return;
	}
	console.log("Entra en un evento");
	var evento = elEvento || window.event;
	// if(evento.type != "mousemove")alert("tipo de evento: " + evento.type);
	var ie = navigator.userAgent.toLowerCase().indexOf("msie") != -1;
	var infoRaton = document.getElementById("infoRaton");
	var infoTeclado = document.getElementById("infoTeclado");
	
	var coordenadaNavegadorX = evento.clientX;
	var coordenadaNavegadorY = evento.clientY;
	
	//Ratón
	if(evento.type == "mousemove"){
		//Info navegador
		var ratNavX = document.getElementById("ratNavX");
		var ratNavY = document.getElementById("ratNavY");
		ratNavX.innerHTML = coordenadaNavegadorX;
		ratNavY.innerHTML = coordenadaNavegadorY;
		
		//Info página
		var coordenadaPaginaX;
		var coordenadaPaginaY;
		if(ie){
			coordenadaPaginaX = evento.clientX + document.body.scrollLeft;
			coordenadaPaginaY = evento.clientY + document.body.scrollTop;
		}
		else{
			coordenadaPaginaX = evento.pageX;
			coordenadaPaginaY = evento.pageY;
		}
		var ratPagX = document.getElementById("ratPagX");
		var ratPagY = document.getElementById("ratPagY");
		ratPagX.innerHTML = coordenadaPaginaX;
		ratPagY.innerHTML = coordenadaPaginaY;
		
		//Ponemos el fondo de color blanco
		
		infoRaton.style.backgroundColor = 'white';
		infoTeclado.style.backgroundColor = 'white';
		// document.body.backgroundColor = "red";
		// document.div.backgroundColor = "red";
	}
	else if(evento.type == "keypress"){ //Teclado
		console.log("evento keypress");
		var teCa = document.getElementById("teCa");
		var teCod = document.getElementById("teCod");
		var contenidoCaracter, contenidoCodigo;
		if(ie) //Internet explorer
			contenidoCodigo = evento.keyCode;
		else //Otros navegadores
			contenidoCodigo = evento.charCode;
		contenidoCaracter = String.fromCharCode(contenidoCodigo);
		
		teCa.innerHTML = contenidoCaracter;
		teCod.innerHTML = contenidoCodigo;
		
		infoTeclado.style.backgroundColor = '#CCE6FF';
	}
	else if(evento.type == "click"){
		console.log("evento click");
		infoRaton.style.backgroundColor = '#FFFFCC';
		contadorClick = true;
		mostrarDondeClick(coordenadaNavegadorX, coordenadaNavegadorY);
	}
}
function mostrarDondeClick(clickX, clickY){
	var dimensiones = tamanoVentanaNavegador();
	console.log(dimensiones);
	var medioX = dimensiones[0] / 2;
	var medioY = dimensiones[1] / 2;
	var posicionMedioX, posicionMedioY;
	if(clickX < medioX)
		posicionMedioX = "Izquierda";
	else
		posicionMedioX = "Derecha";
	if(clickY < medioY)
		posicionMedioY = "Arriba";
	else
		posicionMedioY = "Abajo";
	console.log(posicionMedioX + " " + posicionMedioY);
	var dondeClick = document.getElementById("dondeClick");
	dondeClick.innerHTML = posicionMedioX + " " + posicionMedioY;
}
function tamanoVentanaNavegador(){
	var dimensiones = [];
	
	if(typeof(window.innerWidth) == 'number') {
		// No es IE
		dimensiones = [window.innerWidth, window.innerHeight];
	} else if(document.documentElement && (document.documentElement.clientWidth || document.documentElement.clientHeight)) {
		//IE 6 en modo estandar (no quirks)
		dimensiones = [document.documentElement.clientWidth, document.documentElement.clientHeight];
	} else if(document.body && (document.body.clientWidth || document.body.clientHeight)) {
		//IE en modo quirks
		dimensiones = [document.body.clientWidth, document.body.clientHeight];
	}
	
	return dimensiones;
}