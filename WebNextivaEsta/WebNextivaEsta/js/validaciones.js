// Script para la validación de formularios
// Se incluye en la pagina con el formulario a validar
// dentro del html se establecen los campos requeridos para la validacion
//
//	field[0]={	id:"identificador", 
//				tipo:"tipo de dato", 
//				largo:"largo caracteres", 
//				colorFondoPredeterminado:"color de fondo del elemento",
//				colorValidacion:"color fondo elemento para validar",
//				clasePredeterminada:"clase CSS del elemento",
//				claseValidacion:"clase CSS para validacion",
//				funcion:"funcion a ejecutar"}
//				parametro:"parametro a pasar a la funcion",
//
//	Una vez establecidos se llama a validarFormulario(field).
//


var field = new Array();

function validaRut(text) {
	array_rut=text.split("-");
	//var rut=crut;
	var rut=array_rut[0];
	var largo=rut.length;
	var i=0;
	//var dv=dv;
	var dv=array_rut[1];
	
	if(dv == 'k')
	{
		dv = 'K';	
	}
	
	var mult=2;
	var suma=0;
	largo--;
	while(largo>=0)
    {
	    suma=suma+(rut.charAt(largo)*mult);
		if(mult>6)
			mult=2;
		else
			mult++;
		largo--;
    }
	var resto = suma%11;
	var digito = 11-resto
	if(digito==10)
		digito="K";
	else
		if(digito==11)
			digito=0;

	if(digito!=dv)
		return false;
	else
		return true;



}

function validarCampo(elemento,tipo) {	
// var campo maneja el campo a validar
// var miTipo gestiona el tipo de dato
	var campo = new Array();
	var isOk = true;
//asignamos valores al array
	campo['value'] = obtenerElemento(elemento).value;
	campo['tipo'] = tipo;
	//campo['tipoFecha']=miTipoFecha;
	//seleccionamos el tipo de datos y ejecutamos la funcion correspondiente
	//
 	//	t = texto
	//	n = numero
	//	f = fecha
	//	e = email
	//  w = referencia a sitio web
	//
	switch (campo['tipo']) {
		case 't':
			if((campo['value'].length == 0)||(campo['value']== "")) {
				alert('Debe ingresar el campo requerido.');
				isOk = false;
				break
			}
			break;
		case 'n':
			if((campo['value'].length == 0)||(campo['value']== "")) {
				alert('Debe ingresar el campo requerido.');
				isOk = false;
				break;
			}
			if(isNaN(campo['value'])){
				alert('El campo no contiene un valor númerico.');
				isOk = false;
				break;
			}
			break;
		case 'f':
			if((campo['value'].length == 0)||(campo['value']== "")) {
				alert('Debe ingresar el campo requerido.');
				isOk = false;
				break;
			}
			if (!/^\d{2}\/\d{2}\/\d{4}$/.test(campo['value'])){
				alert("El campo debe tener una fecha con formato  DD/MM/AAAA.");
				isOk = false;
				break;
			}
			if(fechaValida(campo['value'],campo['tipoFecha']) === false) {
				alert("El campo no tiene una fecha correcta.");
				isOk = false;
				break;
			}
			break;
		case 'e':
			if((campo['value'].length == 0)||(campo['value']== "")) {
				alert('Debe ingresar el campo requerido');
				isOk = false;
				break;
			}
			if(!/^[A-Za-z][A-Za-z0-9_.]*@[A-Za-z0-9_]+\.[A-Za-z0-9_.]+[A-za-z]$/.test(campo['value'])){
				alert('El campo no tiene una direccion de correo electronico valida.');
				isOk = false;
				break;
			}
			break;
		case 'r':
			if((campo['value'].length == 0)||(campo['value']== "")) {
				alert('Debe ingresar el campo requerido');
				isOk = false;
				break;
			}
			if(!/[0-9]{7,8}\-[k|K|0-9]/.test(campo['value'])){
				alert('El campo no tiene un formato de rut valido (12345678-9) .');
				isOk = false;
				break;
			}
			if(validaRut(campo['value'])==false){
				alert("El rut ingresado no es válido.");
				isOk = false;
				break;
			}
			break;
		}
	return isOk;
}
function fechaValida(fecha,TipoFecha){
	var dia = fecha.substr(0,2);
	var mes = fecha.substr(3,2);
	var ano = fecha.substr(6,4);


	var estado = true;
	
	if (parseInt(mes)>=13){
		estado = false;
		return estado;
	}
	switch(parseInt(mes)){
	case 1,3,5,7,8,10,12:
		if(parseInt(dia)>31){
			estado = false;
			break;
		}
	break;

	case 4,6,9,11:
		if(parseInt(dia)>30){
			estado = false;
			break;		
		}
	break;

	case 2:
		if(parseInt(dia)>29){
			estado = false;
			break;
		}
	break;
	}
	return estado;
}
function validarFormulario(field){
	var Ok = true;
	var i = 0;
//Realizo loop por los elementos establecidos
	for(i=0;i<field.length;i++) {
//Establezco las propiedades del campo para validación
		var vElemento = field[i].id;
		var vTipo = field[i].tipo;
		var vLargo = field[i].largo;
		var vColorFondoPredeterminado = field[i].colorFondoPredeterminado;
		var vColorValidacion = field[i].colorValidacion;
		var vClasePredeterminada = field[i].clasePredeterminada;
		var vClaseValidacion = field[i].claseValidacion;
		var vFuncion = field[i].funcion;
		var vParametro = field[i].parametro;
//		var vTipoFecha = field[i].tipoFecha

//Si hay variable className pero no esta definida, la defino desde el HTML
/*		if(vClasePredeterminada == undefined){
			if((obtenerElemento(vElemento).className != undefined)||(obtenerElemento(vElemento).className != "")) {
				vClasePredeterminada = obtenerElemento(vElemento).className;
			}
		}*/
//Si la variable Largo está definida, realizo la comparación.
		if(vLargo != undefined){
			if(obtenerElemento(vElemento).value.length > vLargo){
				Ok = false;
				alert("Este campo solo requiere de " + vLargo + " caracteres");
				if((vColorValidacion == undefined)||(vClaseValidacion != undefined)){
					obtenerElemento(vElemento).className=vClaseValidacion; 	
				}
				else {
					obtenerElemento(vElemento).backgroundColor=vColorValidacion;
				}
				obtenerElemento(vElemento).select();
				obtenerElemento(vElemento).focus();				
				break;
			}
		}
//Valido el campo
		if(validarCampo(vElemento,vTipo)==false){
			if(vClaseValidacion != undefined) {
				obtenerElemento(vElemento).className=vClaseValidacion; 
			}
			else {
				obtenerElemento(vElemento).style.backgroundColor=vColorValidacion; 
			}
			Ok = false;
			obtenerElemento(vElemento).select();
			obtenerElemento(vElemento).focus();
			break;
		}

		//Ejecuto función si es que la validación me exige una
		if((vFuncion != undefined)&&(vFuncion != "")){
			switch (vFuncion) {
				case "compararFechas":
					if(compararFechas(obtenerElemento(vParametro).value, obtenerElemento(vElemento).value)==false){
						alert ("La fecha " + obtenerElemento(vElemento).value + " es menor que " + obtenerElemento(vParametro).value);
						Ok = false;
						if(vClaseValidacion != undefined) {
							obtenerElemento(vElemento).className=vClaseValidacion; 
						}	
						else {
							obtenerElemento(vElemento).style.backgroundColor=vColorValidacion; 
						}
						obtenerElemento(vElemento).select();
						obtenerElemento(vElemento).focus();
					return false;
					break;
					}
					break;

				case "compararPassword":
					if(compararPassword(obtenerElemento(vParametro).value,obtenerElemento(vElemento).value)==false) {
					alert ("La contraseña ingresada no coincide en los campos solicitados");
					Ok = false;
					if(vClaseValidacion != undefined) {
							obtenerElemento(vElemento).className=vClaseValidacion; 
						}	
						else {
							obtenerElemento(vElemento).style.backgroundColor=vColorValidacion; 
						}
						obtenerElemento(vElemento).select();
						obtenerElemento(vElemento).focus();
					return false;
					break;
					}
					break;
			}
			
		}
//Si esta Ok devuelvo el formato original
		if(vClasePredeterminada != undefined) {
			if(vClasePredeterminada != ""){
				obtenerElemento(vElemento).className=vClasePredeterminada; 
			}
		}
		else {
			obtenerElemento(vElemento).style.backgroundColor=vColorFondoPredeterminado; 
		}						
	}
	return Ok;
	
}
function compararFechas(fecha1,fecha2){

	var d1 = new Date();
	var d2 = new Date();

	d1.setDate(fecha1.substr(3,2));
	d1.setMonth(fecha1.substr(0,2));
	d1.setYear(fecha1.substr(6,4));
	d2.setDate(fecha2.substr(3,2));
	d2.setMonth(fecha2.substr(0,2));
	d2.setYear(fecha2.substr(6,4));

	if(d1>d2){
		return false;
	}
	else {
		return true;
	}

}
function compararPassword(pass1,pass2){
	var p1 = pass1;
	var p2 = pass2;

	if (p1!=p2) {
		return false;
	}
	return true;
}

function obtenerElemento(id)
{
    var elemento;
    if(document.all)
    {
        elemento = document.all[id];
        return elemento;
    }
    if(document.getElementById)
    {
        elemento = document.getElementById(id);
        return elemento;
    }
}