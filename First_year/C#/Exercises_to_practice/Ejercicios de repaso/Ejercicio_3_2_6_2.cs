
// (3.2.6.2) Crea un programa que pida al usuario la cantidad de rojo
// (por ejemplo, 255), verde (por ejemplo, 160) y azul (por ejemplo, 0)
// que tiene un color, y que muestre ese color RGB en notación hexadecimal
// (por ejemplo, FFA000).

using System;
public class Ejercicio_3_2_6_2
{
	public static void Main()
	{
		byte red, green, blue;
		string red16, green16, blue16;
		
		Console.WriteLine("Introduce la cantidad de rojo que tiene el color");
		red=Convert.ToByte(Console.ReadLine());
		Console.WriteLine("Introduce la cantidad de verde que tiene el color");
		green=Convert.ToByte(Console.ReadLine());
		Console.WriteLine("Introduce la cantidad de azul que tiene el color");
		blue=Convert.ToByte(Console.ReadLine());
		
		red16=Convert.ToString(red,16);
		green16=Convert.ToString(green,16);
		blue16=Convert.ToString(blue, 16);
		
		Console.WriteLine("El color RGB introducido, en notación hexadecimal se expresaría así {0}{1}{2}", red16.ToUpper(), green16.ToUpper(), blue16.ToUpper());
	}
}
