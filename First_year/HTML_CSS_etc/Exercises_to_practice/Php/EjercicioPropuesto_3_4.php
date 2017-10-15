

<html>
<body>

	<?php
		if(!isset($_POST["n1"]))
		{
	?>
	<form action="<?php echo $_SERVER["PHP_SELF"];?>" method="post">
		<p>Indica el primer número <input type="text" name="n1"></p>
		<p>Indica el segundo número <input type="text" name="n2"></p>
		<input type="submit" value="toSend!">
	</form>
	<?php
		}
		else
		{
	?>
	<p>El resultado de sumar <?php echo $_POST["n1"];?> y <?php echo $_POST["n2"];?> es <?php echo $_POST["n1"]+$_POST["n2"]?></p>
	<?php 
		}
	?>
</body>
</html>