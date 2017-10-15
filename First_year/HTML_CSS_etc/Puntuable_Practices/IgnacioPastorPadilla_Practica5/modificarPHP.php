<html>
	<head>
		<title>Modificar Alumno</title>
		<link rel="stylesheet" type="text/css" href="css/style.css" />
	</head>
	<body>
		<?php
			$nombreAl=$_GET['nombre'];
			include("conexion.php");
			$sql="SELECT * FROM alumnos WHERE nombre='".$nombreAl."';";
			$resultado=mysql_query($sql);
			if(!$campos=mysql_fetch_array($resultado))
			{
				echo "<p>Error con la select</p>
					<a class='botonModificar' href='index.html'>Volver</a>";
				exit();
			}
			else
			{
				$direc=$campos['direccion'];
				$mail=$campos['mail'];
				$telf=$campos['telefono'];
				echo "<h1>Modificar Alumno</h1>
					<form class='formulario' action='update.php' method='post'
						<label for='nombre'>Nombre alumno</label>
						<input name='nombreAl' value='$nombreAl' type='text' /></br>
			
						<label for='direccion'>Dirección</label>
						<input name='dir' type='text' value='$direc' /></br>
			
						<label for='mail'>Mail</label>
						<input name='email' type='text' value='$mail' /></br>
			
						<label for='telefono'>Telefono</label>
						<input name='telf' type='text' value='$telf' /></br>
			
						<button class='boton' type='submit'>Enviar</button>
						<a class='botonModificar' href='index.html'>Volver</a>
					</form>";
			}
		?>
	</body>