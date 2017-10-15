// (3.2.1.2) ¿Cuál sería el resultado de las siguientes operaciones,
// usando números reales? a=5; a/=2; a+=1; a*=3; --a;

using System;
public class Ejercicio_3_2_1_2
{
	public static void Main()
	{
		float a=5;
		
		a/=2;
			Console.WriteLine("a/=2; Yo: a=2,5; Resultado={0}",a); 
		a+=1;
			Console.WriteLine("a+=1; Yo: a=3,5; Resultado={0}", a);
		a*=3;
			Console.WriteLine("a*=3; Yo: a=10,5; Resultado={0}", a);
		--a;
			Console.WriteLine("--a; Yo: a=9,5; Resultado={0}", a);
	}
}
