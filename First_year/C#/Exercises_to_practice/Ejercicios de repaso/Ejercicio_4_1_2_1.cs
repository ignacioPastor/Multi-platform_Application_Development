// (4.1.2.1) Un programa que almacene en una tabla el número de días que
// tiene cada mes (supondremos que es un año no bisiesto), pida al usuario
// que le indique un mes (1=enero, 12=diciembre) y muestre en pantalla
// el número de días que tiene ese mes.

using System;
public class Ejercicio_4_1_2_1
{
	public static void Main()
	{
		byte[] meses = new byte [12] {31,30,31,30,31,30,31,31,30,31,30,31};
		
		byte mesUsuario;
		
		Console.WriteLine("Introduce el número del mes del cual quieres saber los días que tiene");
		mesUsuario=Convert.ToByte(Console.ReadLine());
		Console.WriteLine("El mes {0} tiene {1} días", mesUsuario, meses[mesUsuario-1]);
	}
}
