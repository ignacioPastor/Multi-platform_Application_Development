// (4.1.3.4) Un programa que almacene en una tabla el número de días que
// tiene cada mes (de un año no bisiesto), pida al usuario que le indique
// un mes (ej. 2 para febrero) y un día (ej. el día 15) y diga qué número
// de día es dentro del año (por ejemplo, el 15 de febrero sería el día
// número 46, el 31 de diciembre sería el día 365).

using System;
public class Ejercicio_4_1_3_4
{
	public static void Main()
	{
		try
		{
			short sumaDias=0;
			byte mesUsuario, diaUsuario;
			byte[] meses = new byte[12] {31,30,31,30,31,30,31,31,30,31,30,31};
			
			Console.WriteLine("Indica un mes por su número");
			mesUsuario=Convert.ToByte(Console.ReadLine());
			Console.WriteLine("Indica un día dentro de ese mes");
			diaUsuario=Convert.ToByte(Console.ReadLine());
			
			for (byte i = 0; i < mesUsuario-1; i++)
			{
				sumaDias+=meses[i];
			}
			sumaDias+=diaUsuario;
			Console.WriteLine("El día {0} del mes {1}, es el día número {2} dentro del año", diaUsuario, mesUsuario, sumaDias);
		}
		catch(Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}
}
