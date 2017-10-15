// (5.4.3) Crea una función llamada "Signo", que reciba un número real,
// y devuelva un número entero con el valor: -1 si el número es negativo, 1 si es positivo o 0 si es cero.

using System;
public class Ejercicio_5_4_3
{
	public static int Signo(float numero)
	{
		if (numero<0)
			return -1;
		else if(numero>0)
			return 1;
		else
			return 0;
	}
	public static void Main()
	{
		float nUsuario;
		
		Console.WriteLine("Introduce un número real");
		nUsuario=Convert.ToSingle(Console.ReadLine());
		if(Signo(nUsuario)==1)
			Console.WriteLine("El número introducido es positivo");
		else if(Signo(nUsuario)==-1)
			Console.WriteLine("El número introducido es negativo");
		else if(Signo(nUsuario)==0)
			Console.WriteLine("El número introducido es cero");
	}
}
