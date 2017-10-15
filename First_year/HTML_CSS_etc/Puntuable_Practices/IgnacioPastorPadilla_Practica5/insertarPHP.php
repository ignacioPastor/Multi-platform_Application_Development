<html>
	<head>
		<title>Insertar Alumno</title>
		<link rel="stylesheet" type="text/css" href="css/style.css" />
	</head>
	<body>
		<?php
			include("conexion.php");
	
			$nombre=$_POST['nombreAl'];
			$direccion=$_POST['dir'];
			$email=$_POST['email'];
			$telefono=$_POST['telf'];
			$sql="INSERT INTO alumnos (nombre,direccion,mail,telefono) VALUES ('$nombre','$direccion', '$email','$telefono');";
			if(mysql_query($sql))
				echo "<p>Se ha insertado con éxito</p>";
			else
				echo "<p>Ha habido un error</p>";
			echo "<a href='index.html'>Volver</a>";
		?>
	</body>
</html>