// (3.2.2.1) Crea un programa que muestre el resultado de dividir
// 13 entre 6 usando números enteros, luego usando números de coma
// flotante de simple precisión y luego con números de doble precisión.

using System;
public class Ejercicio_3_2_2_1
{
	public static void Main()
	{
		int a=13, b=6, resultadoEnteros;
		float c=13f, d=6f, resultadoFlotante;
		double e=13, f=6, resultadoDoble;
		
		resultadoEnteros=a/b;
		resultadoFlotante=c/d;
		resultadoDoble=e/f;
		
		Console.WriteLine("13/6 con: Enteros={0}, Flotante={1}, Doble={2}", resultadoEnteros, resultadoFlotante, resultadoDoble);
	}
}
