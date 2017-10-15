// (5.5.1) Crea una función "PedirEntero", que reciba como parámetros el texto que se debe mostrar en pantalla,
// el valor mínimo aceptable y el valor máximo aceptable. Esta función deberá pedir al usuario que introduzca el valor,
// tantas veces como sea necesario, deberá volvérselo a pedir en caso de error, y deberá devolver un valor correcto.
// Pruébalo con un programa que pida al usuario un año entre 1800 y 2100.

using System;
public class Ejercicio_5_5_1
{
	public static int PedirEntero(string texto, int nMinimo, int nMaximo)
	{
		int nUsuario=1000;
		do
		{
			Console.WriteLine("{0} {1} y {2}", texto, nMinimo, nMaximo);
			try
			{
				nUsuario=Convert.ToInt32(Console.ReadLine());
				if(nUsuario>nMaximo||nUsuario<nMinimo)
					Console.WriteLine("El número debe estar entre {0} y {1}", nMinimo, nMaximo);	
			}
			catch (FormatException e)
			{
				Console.WriteLine(e.Message);
			}
		}
		while (nUsuario>nMaximo||nUsuario<nMinimo);
		
		return nUsuario;
	}
	public static void Main()
	{
		int numero;
		
		numero=PedirEntero("Introduce un número entre ", 1800, 2100);
		Console.WriteLine("Correcto, el número {0} cumple con los requisitos", numero);
	}
}
