

window.onload = function(){
	document.onmousemove = mostrarInfo;
	document.onkeypress = mostrarInfo;
	document.onclick = mostrarInfo;
}
var contadorClick = false;
function mostrarInfo(elEvento){
	//Se ha detectado que el evento click del ratón genera inmediatamente
	// después un evento de mousemove, por lo que con este código suprimimos
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
	//Ratón
	if(evento.type == "mousemove"){
		//Info navegador
		var coordenadaNavegadorX = evento.clientX;
		var coordenadaNavegadorY = evento.clientY;
		
		var ratNavX = document.getElementById("ratNavX");
		var ratNavY = document.getElementById("ratNavY");
		ratNavX.innerHTML = coordenadaNavegadorX;
		ratNavY.innerHTML = coordenadaNavegadorY;
		
		//Info página
		var ie = navigator.userAgent.toLowerCase().indexOf("msie") != -1;
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
	}
}

