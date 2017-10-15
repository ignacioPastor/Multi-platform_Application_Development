// (3.3.1.2) Crea un programa que muestre letras alternas (una sí y una no)
// entre la que teclee el usuario y la "z". Por ejemplo, si el usuario
// introduce una "a", se escribirá "aceg...".

using System;
public class Ejercicio_3_3_1_2
{
	public static void Main()
	{
		try
		{
			char letra;
			bool alternador=false;
			
			Console.WriteLine("Introduce una letra");
			letra=Convert.ToChar(Console.ReadLine());
			
			for(char i=letra; i<='z'; i++)
			{
				if(alternador==false)
				{
					Console.Write(i);
					alternador=true;
				}
				else alternador=false;
			}
			Console.WriteLine();
		}
		catch(FormatException)
		{
			Console.WriteLine("Debes introducir una letra");
		}
	}
}
