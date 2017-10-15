<html>
	<head>
		<title>Actualizar alumno</title>
		<link rel="stylesheet" type="text/css" href="css/style.css" />
	</head>
	<body>
		<?php
			include("conexion.php");
			$nombre=$_REQUEST['nombreAl'];
			$direccion=$_REQUEST['dir'];
			$email=$_REQUEST['email'];
			$telefono=$_REQUEST['telf'];
			$sql = "UPDATE alumnos SET nombre='".$nombre."', direccion='".$direccion."', mail='".$email."', telefono='".$telefono."' WHERE UPPER(Trim(nombre))=UPPER(Trim('".$nombre."'));"; 
			$resultado=mysql_query($sql);
			if(!$resultado)
				echo "<p>Error con la update</p>";
			else
				echo "<p>Se ha actualizado con éxito</p>";
			echo "<a href='index.html'>Volver</a>";
		?>
	</body>
</html>