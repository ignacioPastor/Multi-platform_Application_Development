// (4.1.1.1) Un programa que pida al usuario 4 números, los memorice
// (utilizando un array), calcule su media aritmética
// y después muestre en pantalla la media y los datos tecleados.

using System;
public class Ejercicio_4_1_1_1
{
	public static void Main()
	{
		try
		{
			float[] numeros = new float [4];
			float suma=0, media;
			
			for (byte i = 0; i < 4; i++)
			{
				Console.WriteLine("Introduce un número");
				numeros[i]=Convert.ToSingle(Console.ReadLine());
				suma+=numeros[i];
			}
			media=suma/numeros.Length;
			Console.WriteLine("Los números introducidos son: ");
			for (byte i = 0; i < numeros.Length; i++)
			{
				Console.Write("{0} ", numeros[i]);
			}
			Console.WriteLine();
			
			Console.WriteLine("Y la media es {0}", media);
		}
		catch(Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}
}
