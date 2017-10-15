// (5.4.5) Crea una función "UltimaLetra", que devuelva la última letra de una cadena de texto.
// Prueba esta función para calcular la última letra de la frase "Hola".

using System;
public class Ejercicio_5_4_5
{
	public static char UltimaLetra(string cadena)
	{
		return cadena[cadena.Length-1];
	}
	public static void Main()
	{
		string cadenaUsuario;
		
		Console.WriteLine("Introduce un nombre");
		cadenaUsuario=Console.ReadLine();
		
		Console.WriteLine("La última letra de {0} es {1}", cadenaUsuario, UltimaLetra(cadenaUsuario));
	}
}
