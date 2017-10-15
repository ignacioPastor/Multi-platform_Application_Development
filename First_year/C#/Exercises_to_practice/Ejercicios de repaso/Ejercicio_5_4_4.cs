// (5.4.4) Crea una función "Inicial", que devuelva la primera letra de una cadena de texto.
// Prueba esta función para calcular la primera letra de la frase "Hola".

using System;
public class Ejercicio_5_4_4
{
	public static char Inicial(string cadena)
	{
		return cadena[0];
	}
	public static void Main()
	{
		string cadenaUsuario;
		
		Console.WriteLine("Introduce un nombre");
		cadenaUsuario=Console.ReadLine();
		
		Console.WriteLine("La inicial de {0} es {1}", cadenaUsuario, Inicial(cadenaUsuario));
	}
}
