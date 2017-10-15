// (5.3.4) Crea una función "EscribirRepetido", que reciba un carácter y un número,
// y escriba ese carácter tantas veces como indique ese número (todas ellas en la misma línea).

using System;
public class Ejercicio_5_3_4
{
	public static void EscribirRepetido(char caracter, short numero)
	{
		for (short i = 0; i < numero; i++)
		{
			Console.Write(caracter);
		}
		Console.WriteLine();
	}
	public static void Main()
	{
		char caracterUsuario;
		short numeroUsuario;
		
		Console.WriteLine("Introduce un caracter");
		caracterUsuario=Convert.ToChar(Console.ReadLine());
		Console.WriteLine("Indica cuantas veces quieres escribir el caracter");
		numeroUsuario=Convert.ToInt16(Console.ReadLine());
		
		EscribirRepetido(caracterUsuario, numeroUsuario);
	}
}
