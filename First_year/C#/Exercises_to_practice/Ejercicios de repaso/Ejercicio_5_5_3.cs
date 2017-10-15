// (5.5.3) Crea una función "EsPrimo", que reciba un número y devuelva
// el valor booleano "true" si es un número primo o "false" en caso contrario.

using System;
public class Ejercicio_5_5_3
{
	public static bool EsPrimo(short numero)
	{
		bool serPrimo=true;
		for (short i = 2; i <= numero/2; i++)
		{
			if(numero%i==0)
				serPrimo=false;
		}
		return serPrimo;
		
	}
	public static void Main()
	{
		short nUsuario=-1;
		
		do
		{
			try
			{
				Console.WriteLine("Introduce un número entero para ver si es primo");
				nUsuario=Convert.ToInt16(Console.ReadLine());
				if(nUsuario<1)
					Console.WriteLine("Un número primo no puede ser negativo");
			}
			catch(FormatException e)
			{
				Console.WriteLine(e.Message);
			}
		}
		while (nUsuario<1);
		
		if(EsPrimo(nUsuario))
			Console.WriteLine("Es primo");
		else
			Console.WriteLine("No es primo");
	}
}
