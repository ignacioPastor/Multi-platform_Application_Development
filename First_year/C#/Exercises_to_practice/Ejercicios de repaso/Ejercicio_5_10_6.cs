// (5.10.6) Crea un programa que emplee recursividad para dar la vuelta a una cadena de caracteres
// (por ejemplo, a partir de "Hola" devolvería "aloH"). La función recursiva se llamará "Invertir(cadena)".
// Como siempre, analiza cuál será el caso base (qué longitud debería tener una cadena para que sea trivial darle la vuelta)
// y cómo pasar del caso "n-1" al caso "n" (por ejemplo, si ya has invertido las 5 primeras letras,
// que ocurriría con la letra de la sexta posición).


// NO ENTIENDO ESTE EJERCICIO, VER EL EJERCICIO RESUELTO
using System;
using Text.System;
public class Ejercicio_5_10_6
{
	public static string Invertir(string cadena)
	{
		StringBuilder cadenaInvertida = new StringBuilder(cadena);
		
		cadenaInvertida[cadenaInvertida.Length-1]=cadenaInvertida[0]
	}
	public static void Main()
	{
		string palabra, palabraInvertida;
		
		Console.WriteLine("Introduce una palabra");
		palbra=Console.ReadLine();
		
		palabraInvertida=Invertir(palabra);
		Console.WriteLine("La palabla \"{0}\" invertida es \"{1}\"", palabra, palabraInvertida);
	}	
}
