// (4.1.3.2) Crea un programa que pregunte al usuario cuántos números
// enteros va a introducir (por ejemplo, 10), le pida todos esos números,
// los guarde en un array y finalmente calcule y muestre la media de esos números.

using System;
public class Ejercicio_4_1_3_2
{
	public static void Main()
	{
		try
		{
			byte cantidadNumeros;
			float suma=0, media;
			
			Console.WriteLine("¿Cuántos números vas a querer introducir?");
			cantidadNumeros=Convert.ToByte(Console.ReadLine());
			
			float[] numeros = new float[cantidadNumeros];
			
			for (byte i = 0; i < cantidadNumeros; i++)
			{
				Console.WriteLine("Introduce el número de la posición {0}", i+1);
				numeros[i]=Convert.ToSingle(Console.ReadLine());
				suma+=numeros[i];
			}
			media=suma/cantidadNumeros;
			Console.WriteLine("La media de los números introducidos es {0}", media);
		}
		catch(Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}
}
