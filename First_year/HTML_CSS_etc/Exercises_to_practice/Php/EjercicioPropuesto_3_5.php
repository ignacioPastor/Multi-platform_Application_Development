
<html>
<body>

	<?php
		if(!isset($_POST["n1"]))
		{
	?>
		<form action="<?php echo $_POST["PHP_SELF"]; ?>" method="post">
			<p>Introduce el primer número <input type="text" name="n1"></p>
			<p>Introduce el segundo número <input type="text" name="n2"></p>
			<input type="submit" value="Enviar">
		</form>
	<?php
		}
		else
		{
	?>
		<p> La suma de <?php echo $_POST["n1"];?> y <?php echo $_POST["n2"];?> es <?php echo $_POST["n1"]+$_POST["n2"];?></p>
		<form action="<?php echo $_POST["PHP_SELF"]; ?>" method="post">
			<p>Introduce el primer número <input type="text" name="n1"></p>
			<p>Introduce el segundo número <input type="text" name="n2"></p>
			<input type="submit" value="Enviar">
		</form>
	<?php } ?>

</body>
</html>