//(5.3.3) Crea una función "DibujarRectanguloHueco" que dibuje en pantalla
// un rectángulo hueco del ancho y alto que se indiquen como parámetros,
// formado por una letra que también se indique como parámetro.
// Completa el programa con un Main que pida esos datos al usuario y dibuje el rectángulo.

using System;
public class Ejercicio_5_3_3
{
	public static void DibujarRectanguloHueco(char letra, byte alto, byte ancho)
	{
		for (byte i = 0; i < alto; i++)
		{
			for(byte j=0; j<ancho; j++)
			{
				if(i==0||i==alto-1||j==0||j==ancho-1)
					Console.Write(letra);
				else
					Console.Write(" ");
			}
			Console.WriteLine();
		}
	}
	public static void Main()
	{
		char letraUsuario;
		byte altoUsuario, anchoUsuario;
		
		Console.WriteLine("Introduce el alto de rectángulo");
		altoUsuario=Convert.ToByte(Console.ReadLine());
		Console.WriteLine("Introduce el ancho del rectángulo");
		anchoUsuario=Convert.ToByte(Console.ReadLine());
		Console.WriteLine("Introduce el caracter con el que quiere que se dibuje el rectángulo hueco");
		letraUsuario=Convert.ToChar(Console.ReadLine());
		
		DibujarRectanguloHueco(letraUsuario, altoUsuario, anchoUsuario);
	}
}
