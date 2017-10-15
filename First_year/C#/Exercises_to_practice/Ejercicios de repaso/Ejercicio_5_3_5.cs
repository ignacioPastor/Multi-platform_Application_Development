// (5.3.5) Crea una nueva versión de la función "DibujarRectangulo",
// que se apoye en la "EscribirRepetido" que acabas de crear.

using System;
public class Ejercicio_5_3_5
{
	public static void DibujarRectangulo(char caracterDB, short altoDB, short anchoDB)
	{
		for (short i = 0; i < altoDB; i++)
		{
			EscribirRepetido(caracterDB, anchoDB);
			Console.WriteLine();
		}
	}
	public static void EscribirRepetido(char caracter, short ancho)
	{
		for (short i = 0; i < ancho; i++)
		{
			Console.Write(caracter);
		}
	}
	public static void Main()
	{
		short altoUsuario, anchoUsuario;
		char caracterUsuario;
		
		Console.WriteLine("Introduce el alto del rectángulo");
		altoUsuario=Convert.ToInt16(Console.ReadLine());
		Console.WriteLine("Introduce el ancho del rectángulo");
		anchoUsuario=Convert.ToInt16(Console.ReadLine());
		Console.WriteLine("Indice el caracter con el que quieres dibujar el rectángulo");
		caracterUsuario=Convert.ToChar(Console.ReadLine());
		
		DibujarRectangulo(caracterUsuario, altoUsuario,anchoUsuario); 
	}
}
