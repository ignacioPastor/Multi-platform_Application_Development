// (5.7.3) Crea una función "MaxMinArray", que reciba un array de reales de doble precisión
// y devuelva el mayor valor almacenado en ese array y el menor,
// utilizando parámetros por referencia. Pruébala con un "Main" adecuado.

using System;
public class Ejercicio_5_7_3
{
	public static void MaxMinArray(double[] array, ref double max, ref double min)
	{
		max=array[0];
		min=array[0];
		for (byte i = 1; i < array.Length; i++) 
		{
			if(max<array[i])
				max=array[i];
			if(min>array[i])
				min=array[i];
		}
	}
	public static void Main()
	{
		byte nNumeros;
		double maximo=0, minimo=0;
		Console.WriteLine("Introduce el número de números que vas a querer almacenar en el array");
		nNumeros=Convert.ToByte(Console.ReadLine());
		
		double[] arrayUsuario = new double[nNumeros];
		
		for (byte i = 0; i < nNumeros; i++)
		{
			Console.WriteLine("Introduce el número de la posición {0}", i+1);
			arrayUsuario[i]=Convert.ToDouble(Console.ReadLine());
		}
		Console.WriteLine("Los datos almacenados son");
		for (byte i = 0; i < arrayUsuario.Length; i++)
		{
			Console.WriteLine("{0}. {1}", i+1, arrayUsuario[i]);
		}
		
		
		
		MaxMinArray(arrayUsuario, ref maximo, ref minimo);
		
		Console.WriteLine("El mayor número introducido es {0} y el menor {1}", maximo, minimo);
	}
}
