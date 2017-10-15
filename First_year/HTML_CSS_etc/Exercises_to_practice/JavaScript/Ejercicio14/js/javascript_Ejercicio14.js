

window.onload = function(){
	var enlace1 = document.getElementById("enlace_1").onclick = onClickEnlace;
	var enlace2 = document.getElementById("enlace_2").onclick = onClickEnlace;
	var enlace3 = document.getElementById("enlace_3").onclick = onClickEnlace;
}
function onClickEnlace(){
	if(this == document.getElementById("enlace_1"))
		contenidoEnlace = document.getElementById("contenidos_1");
	else if(this == document.getElementById("enlace_2"))
		contenidoEnlace = document.getElementById("contenidos_2");
	else
		contenidoEnlace = document.getElementById("contenidos_3");
	
	var textoEnlace = this.childNodes[0];
	
	if(contenidoEnlace.style.display == "none"){
		contenidoEnlace.style.display = "block";
		textoEnlace.nodeValue = "Ocultar contenidos";
	}
	else{
		contenidoEnlace.style.display = "none";
		textoEnlace.nodeValue = "Mostrar contenidos";
	}
}