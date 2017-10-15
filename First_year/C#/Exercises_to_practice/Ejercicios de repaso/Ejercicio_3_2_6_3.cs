
// (3.2.6.3) Crea un programa para mostrar los números del 0 a 255 en
// hexadecimal, en 16 filas de 16 columnas cada una (la primera fila
// contendrá los números del 0 al 15 –decimal-, la segunda del 16 al
// 31 –decimal- y así sucesivamente).

using System;
public class Ejercicio_3_2_6_3
{
	public static void Main()
	{
		byte nDecimal=0;
		string nHexadecimal;
		
		for(byte i=0; i<16; i++)
		{
			for(byte j=0; j<16; j++)
			{
				nHexadecimal=Convert.ToString(nDecimal,16);
				Console.Write("{0}={1} ", nDecimal++, nHexadecimal.ToUpper());
			}
			Console.WriteLine();
		}
	}
}
