// (3.2.4.2) Crea una nueva versión del programa que calcula una
// aproximación de PI mediante la expresión:
// pi/4 = 1/1 - 1/3 + 1/5 - 1/7 + 1/9 - 1/11 + 1/13 (...)
// con tantos términos como indique el usuario. Debes hacer todas las
// operaciones con "double", pero mostrar el resultado como "float".

using System;
public class Ejercicio_3_2_4_2
{
	public static void Main()
	{
		ushort nTerminos;
		bool alternativo=true;
		double acumulado=0, resultado, i=1;
		float resultadoSimple;
		
		Console.WriteLine("Introduce el número de términos que quieres contemplar en la aproximación de pi");
		nTerminos=Convert.ToUInt16(Console.ReadLine());
		
		if(nTerminos<=0)
			Console.WriteLine("No has introducido un número de términos válido");
		else
		{
			for(byte j=0; j<nTerminos; j++)
			{
				if(alternativo==true)
				{
					acumulado=acumulado+1/i;
					alternativo=false;
				}
				else
				{
					acumulado=acumulado-1/i;
					alternativo=true;
				}
				i+=2;
			}
		}
		Console.WriteLine("Usando double {0}",acumulado*4);
			resultado=acumulado*4;
			resultadoSimple=(float)resultado;
			Console.WriteLine("El número pi expresado con una aproximación de {0} términos es {1}", nTerminos, resultadoSimple);
	}
}
