

<html>
<body>
	<?php
		$radio = $_GET["radio"];
		$longCircunf = 2*PI*$radio;
		$superficie = PI*$radio*$radio;
		echo "La longitud de la circunferencia es " . $longCircunf;
		echo "La suferficie del círculo es " . $superficie;
	?>
</body>
</html>