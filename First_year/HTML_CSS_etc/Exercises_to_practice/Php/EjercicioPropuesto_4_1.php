

<html>
<body>

	<?php
		if(!isset($_POST["n1"]))
		{
	?>
		<form action="<?php echo $_SERVER["PHP_SELF"]; ?>" method="post">
			<p> Indica el primer número <input type="text" name="n1"></p>
			<p> Indica el segundo número <input type="text" name="n2"></p>
			<input type="submit" value="Enviar">
		</form>
	<?php
		}
		else
		{
			if($_POST["n2"] == 0)
			{
				echo "No se puede dividir entre cero. <br/> <br/>";
			}
			else
			{
				echo $_POST["n1"] . " / " . $_POST["n2"] . " = " . $_POST["n1"]/$_POST["n2"];
			}
	?>
		<form action="<?php echo $_SERVER["PHP_SELF"]; ?>" method="post">
			<p> Indica el primer número <input type="text" name="n1"></p>
			<p> Indica el segundo número <input type="text" name="n2"></p>
			<input type="submit" value="Enviar">
		</form>
	<?php
		}
	?>
</body>
</html>