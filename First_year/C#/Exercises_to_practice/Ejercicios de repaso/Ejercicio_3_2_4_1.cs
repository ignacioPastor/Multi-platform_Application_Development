//(3.2.4.1) Crea un programa que calcule la raíz cuadrada del número que
// introduzca el usuario. La raíz se deberá calcular como "double", pero
// el resultado se mostrará como "float". (Recuerda: como viste al hacer 
// el ejercicio 3.2.3.3, la raíz cuadrada de un número x se calcula con
// Math.Sqrt(x)).

using System;
public class Ejercicio_3_2_4_1
{
	public static void Main()
	{
		double numeroUsuario;
		double raizUsuario;
		float raizSimple;
		
		Console.WriteLine("Introduce el número cuya raíz cuadrada quieres calcular");
		numeroUsuario=Convert.ToDouble(Console.ReadLine());
		raizUsuario=Math.Sqrt(numeroUsuario);
		
		raizSimple= (float) raizUsuario;
		
		
		Console.WriteLine("La raíz cuadrada de {0} es {1}, double", numeroUsuario, raizUsuario);
		Console.WriteLine("La raíz cuadrada de {0} es {1}, simple", numeroUsuario, raizSimple);
	}
}
