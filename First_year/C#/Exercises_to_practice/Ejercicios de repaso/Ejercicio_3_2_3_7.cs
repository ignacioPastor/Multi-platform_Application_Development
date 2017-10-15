// (3.2.3.7) Escribe un programa que calcule una aproximación de PI mediante
// la expresión: pi/4 = 1/1 - 1/3 + 1/5 - 1/7 + 1/9 - 1/11 + 1/13 ...
// El usuario deberá indicar la cantidad de términos a utilizar, y el
// programa mostrará todos los resultados hasta esa cantidad de términos.
// Debes hacer todas las operaciones con "double".

using System;
public class Ejercicio_3_2_3_7
{
	public static void Main()
	{
		ushort nTerminos, contador=1;
		double acumulado=0, i=1;
		bool alternativoBool=true;
		
		Console.WriteLine("Introduce cuántos términos quieres contemplar en la aproximación de pi");
		nTerminos=Convert.ToUInt16(Console.ReadLine());
		
		if (nTerminos <=0)
		{
			Console.WriteLine("No has introducido una cantidad de términos válida");
		}
		else
		{
			for(double j=0; j<nTerminos; j++)
			{
				Console.WriteLine(contador);
				contador++;
				if(i%2==0)
					continue;
				else
					{
						if(alternativoBool==true)
						{
							acumulado=acumulado+1/i;
							alternativoBool=false;
						}
						else
						{
							acumulado=acumulado-1/i;
							alternativoBool=true;
						}
					}
				i+=2;
			}
			Console.WriteLine("pi = {0}", acumulado*4);
		}
	}
}
