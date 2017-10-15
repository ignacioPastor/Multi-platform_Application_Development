// (3.1.2.1) Pregunta al usuario su edad, que se guardará en un "byte".
// A continuación, le deberás decir que no aparenta tantos años.

using System;
public class Ejercicio_3_1_2_1
{
	public static void Main()
	{
		byte edad;
		
		Console.WriteLine("Dime tu edad");
		edad=Convert.ToByte(Console.ReadLine());
		Console.WriteLine("No aparentas {0} años", edad);
	}
}
