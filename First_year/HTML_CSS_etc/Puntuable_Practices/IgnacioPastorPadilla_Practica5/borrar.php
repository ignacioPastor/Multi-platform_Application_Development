<html>
	<head>
		<title>Borrar alumno</title>
		<link rel="stylesheet" type="text/css" href="css/style.css" />
	</head>
	<body>
		<?php
			include("conexion.php");
			$nombreAl=$_GET['nombre'];
			$existe="SELECT * FROM alumnos WHERE nombre='".$nombreAl."';";
			$resultado=mysql_query($existe);
			if(mysql_fetch_array($resultado))
			{
				$sql="DELETE FROM alumnos WHERE Trim(nombre)='".$nombreAl."';";
				$resultado=mysql_query($sql);
				if(!$resultado)
				{
				echo "<p>Error al borrar</p>";
				exit();
				}
				else
				{
				echo "<p>Borrado con éxito</p>";
				}
			}
			else
			{
				echo "<p>No existe el alumno</p>";
			}
			echo "<a href='index.html'>Volver</a>";
		?>
	</body>
</html>