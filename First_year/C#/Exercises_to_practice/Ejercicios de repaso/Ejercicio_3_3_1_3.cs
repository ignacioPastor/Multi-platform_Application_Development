// (3.3.1.3) Crea un programa que pida al usuario el ancho y el alto
// y una letra, y escriba un rectángulo formado por esa cantidad de letras

using System;
public class Ejercicio_3_3_1_3
{
	public static void Main()
	{
		try
		{
			ushort ancho, alto;
			char letra;
			
			Console.WriteLine("Introduce el ancho del rectángulo");
			ancho=Convert.ToUInt16(Console.ReadLine());
			Console.WriteLine("Introduce el alto del rectángulo");
			alto=Convert.ToUInt16(Console.ReadLine());
			Console.WriteLine("Introduce la letra con la que formar el rectángulo");
			letra=Convert.ToChar(Console.ReadLine());
			
			for(ushort i=0; i<alto; i++)
			{
				for(ushort j=0; j<ancho; j++)
				{
					Console.Write(letra);
				}
				Console.WriteLine();
			}
		}
		catch(FormatException e)
		{
			Console.WriteLine(e.Message);
		}
		catch(Exception i)
		{
			Console.WriteLine(i.Message);
		}
	}
}
