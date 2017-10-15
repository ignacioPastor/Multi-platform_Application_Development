// (5.9.1.4) Crea un programa que genere un array relleno con 100 números enteros
// al azar entre -10000 y 10000. Luego deberá calcular y mostrar su media.

using System;
public class Ejercicio_5_9_1_4
{
	public static void Main()
	{
		short media=0;
		short[] numerosAzar = new short[100];
		Random r = new Random();
		
		for (byte i = 0; i < numerosAzar.Length; i++)
		{
			numerosAzar[i]=Convert.ToInt16(r.Next(-10000, 10000));
			Console.WriteLine(numerosAzar[i]);
		}
		
		for (byte i = 0; i < numerosAzar.Length; i++)
		{
			media+=numerosAzar[i];
		}
		Console.WriteLine("La media de los datos del array es {0}", media/100);
	}
}
