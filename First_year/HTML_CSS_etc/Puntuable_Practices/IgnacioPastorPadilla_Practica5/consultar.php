<html>
	<head>
		<link rel="stylesheet" type="text/css" href="css/style.css" />
		<title>Consultar Alumno</title>
	</head>
	<body>
		<?php
			include("conexion.php");
			$nombre=$_GET['nombre'];
			$existe="SELECT * FROM alumnos WHERE UPPER(TRIM(nombre))=UPPER(TRIM('".$nombre."'));";
			$resultado=mysql_query($existe);
			if($campos=mysql_fetch_array($resultado))
			{
				$direccion=$campos['direccion'];
				$mail=$campos['mail'];
				$telf=$campos['telefono'];
				echo "
					<p>Nombre: ".$nombre."</p>
					<p>Direccion: ".$direccion."</p>
					<p>E-mail: ".$mail."</p>
					<p>Telefono: ".$telf."</p>";
			}
			else
				echo "<p>No existe el alumno</p>";
			echo "<a href='index.html'>Volver</a>";
		?>
	</body>
</html>