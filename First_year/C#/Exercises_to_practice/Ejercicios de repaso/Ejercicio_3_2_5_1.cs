
// (3.2.5.1) El usuario de nuestro programa podrá teclear dos números de
// hasta 12 cifras significativas. El programa deberá mostrar el resultado
// de dividir el primer número entre el segundo, utilizando tres cifras
// decimales.

using System;
public class Ejercicio_3_2_5_1
{
	public static void Main()
	{
		double n1, n2;
		double resultado;
		
		Console.WriteLine("Introduce un numerador de hasta doce cifras significativas");
		n1=Convert.ToInt64(Console.ReadLine());
		Console.WriteLine("Introduce un denominador de hasta doce cifras significativas");
		n2=Convert.ToInt64(Console.ReadLine());
		
		resultado=n1/n2;
		Console.WriteLine(resultado);
		Console.WriteLine(resultado.ToString("#.###"));
	}
}
