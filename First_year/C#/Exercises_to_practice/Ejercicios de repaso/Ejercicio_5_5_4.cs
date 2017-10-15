// (5.5.4) Crea una función "ContarLetra", que reciba una cadena y una letra,
// y devuelva la cantidad de veces que dicha letra aparece en la cadena.
// Por ejemplo, si la cadena es "Barcelona" y la letra es 'a',
// debería devolver 2 (porque la "a" aparece 2 veces).

using System;
public class Ejercicio_5_5_4
{
	public static byte ContarLetra(string texto, char letra)
	{
		byte contador=0;
		for (byte i = 0; i < texto.Length; i++)
		{
			if(Convert.ToString(texto[i]).ToUpper()==Convert.ToString(letra).ToUpper())
				contador++;
		}
		return contador;
		
	}
	public static void Main()
	{
		string textoUsuario;
		char letraUsuario;
		
		Console.WriteLine("Introducre una palabra o frase");
		textoUsuario=Console.ReadLine();
		Console.WriteLine("Introduce la letra que quieres contar cuantas veces aparece en el texto introducido");
		letraUsuario=Convert.ToChar(Console.ReadLine());
		
		Console.WriteLine("La letra {0} aparece {1} en \"{2}\"", letraUsuario, ContarLetra(textoUsuario, letraUsuario), textoUsuario);
	}
}
