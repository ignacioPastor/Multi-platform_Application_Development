<?php	
		define("DB_HOST","localhost");
		define("DB_USER","root");
		define("DB_PASS","");
		define("DB_DATABASE","practica5");
		
		$con=mysql_connect (DB_HOST, DB_USER, DB_PASS);
		if(!$con){
			echo "<p>Error conectando con el servidor</p>";
			exit();
		}
		if(!mysql_select_db (DB_DATABASE, $con)){
			echo "<p>Error seleccionando la base de datos.</p>";
			exit();
		}
?>