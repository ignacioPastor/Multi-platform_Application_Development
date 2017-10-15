// (4.4.3.4) Un programa capaz de sumar dos números enteros muy grandes (por ejemplo, de 50 cifras),
// que se deberán pedir como cadena de texto y analizar letra a letra
// (pista: tendrás que pensar cómo sumas dos números a mano: qué ocurre si al suma cifra a cifra
// obtienes un número mayor que 10 y cómo tratar el caso de que los dos números no tengan la misma longitud).

using System;
public class Ejercicio_4_4_3_4
{
	public static void Main()
	{
		string n1, n2, mayor, menor, resultado;
		bool acabado;
		
		Console.WriteLine("Introduce un número largo");
		n1=Console.ReadLine();
		Console.WriteLine("Introduce un segundo número largo");
		n2=Console.ReadLine();
		
		if(n1.Length>n2.Length)
		{
			mayor=n1;
			menor=n2;
		//	diferenciaCifras=n1.Length-n2.Length;
		}
		else
		{
			mayor=n2;
			menor=n1;
		//	diferenciaCifras=n2.Length-n1.Length;
			
		}
			
		for(int i= mayor.Length; i>0; i--)
		{
			acabado=true;
			for(int j=menor.Length; j>0; j--)
			{
				acabado=false;
				
			}
			if(acabado)
			{
				resultado[i]= mayor[i];
			}
			else
			{
				resultado[i]=mayor[i]+menor[j];
			}
		}
		Console.WriteLine(resultado);
	}
}
