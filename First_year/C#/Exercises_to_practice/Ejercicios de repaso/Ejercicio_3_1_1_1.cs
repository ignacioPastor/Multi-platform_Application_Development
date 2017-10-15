// (3.1.1.1) Calcula el producto de 1.000.000 por 1.000.000, usando una
// variable llamada "producto", de tipo "long". Prueba también a
// calcularlo usando una variable de tipo "int".

using System;
public class Ejercicio_3_1_1_1
{
	public static void Main()
	{
		long numero=1000000, resultado;
		// Si cambiamos este long por int el resultado nos de negativo, es decir, colapsa
		resultado=numero*numero;
		Console.WriteLine(resultado);
	}
}
