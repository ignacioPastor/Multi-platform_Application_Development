// (2.4.1) Crea un programa que cuente cuantas veces aparece
// la letra 'a' en una frase que teclee el usuario, utilizando "foreach".

using System;
public class Ejercicio_2_4_1
{
	public static void Main()
	{
		string fraseUsuario;
		int contador=0;
		
		
		Console.WriteLine("Introduce una frase");
		fraseUsuario=Console.ReadLine();
		
		foreach(char letra in fraseUsuario)
		{
			if(letra=='a')
				contador++;
		}
		Console.WriteLine("La letra \"a\" aparece {0} veces en la frase introducida", contador);
	}
}
