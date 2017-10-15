// (4.1.5.1) Crea un programa que contenga un array con los nombres de
// los meses del año. El usuario podrá elegir entre verlos en orden natural
// (de Enero a Diciembre) o en orden inverso (de Diciembre a Enero).
// Usa constantes para el valor máximo del array en ambos recorridos.

using System;
public class Ejercicio_4_1_5_1
{
	public static void Main()
	{
		try
		{
			const byte MAXIMO=12;
			string[] meses = new string[MAXIMO] {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"};
			byte opcion;
			
			Console.WriteLine("Indica si quieres ver los meses del año en orden natural con un \"0\", o en orden inverso\"1\"");
			opcion=Convert.ToByte(Console.ReadLine());
			if(opcion==0)
			{
				for (byte i = 0; i < MAXIMO; i++)
				{
					if(i==MAXIMO-1)
						Console.Write("{0}", meses[i]);
					else
						Console.Write("{0}, ", meses[i]);
				}
				Console.WriteLine();
			}
			else if(opcion==1)
			{
				for (int i = MAXIMO-1; i >= 0; i--)
				{
					if(i==0)
						Console.Write("{0}", meses[i]);
					else
					 Console.Write("{0}, ", meses[i]);
				}
				Console.WriteLine();
			}
			else
				Console.WriteLine("Debes indicar \"0\" o \"1\"");
		}
		catch(Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}
}
