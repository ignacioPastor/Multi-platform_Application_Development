// (5.9.1.3) Mejora el programa del ahorcado (4.4.9.3), para que la palabra a adivinar
// no sea tecleada por un segundo usuario, sino que se escoja al azar de un "array" de
// palabras prefijadas (por ejemplo, nombres de ciudades).

using System;
using System.Text;
public class Ejercicio_5_9_1_3
{
	public static void Main()
	{
		try
		{
			string palabraAdivinar;
			string[] ciudades = {"barcelona", "madrid", "valencia", "murcia", "vigo"};
			Random r = new Random();
			palabraAdivinar=ciudades[r.Next(0,6)];
			bool acierto;
			byte contador=8;
			char letraUsuario;
			
			StringBuilder palabraAdivinando = new StringBuilder(palabraAdivinar);
			
			for (byte i = 0; i < palabraAdivinar.Length; i++)
			{
				palabraAdivinando[i]='-';
			}
			Console.WriteLine();
			
			do
			{
				acierto=false;
				Console.WriteLine("Intenta adivinar la palabra, dispones de {0} intentos!", contador);
				Console.WriteLine("{0}", palabraAdivinando);
				letraUsuario=Convert.ToChar(Console.ReadLine());
				
				for (byte i = 0; i < palabraAdivinar.Length; i++)
				{
					if(letraUsuario.ToString().ToUpper()==palabraAdivinar[i].ToString().ToUpper())
					{
						palabraAdivinando[i]=letraUsuario;
						acierto=true;
					}
				}
				if(acierto)
					Console.WriteLine("Enhorabuena, esa letra está en la palabra");
				else
				{
					Console.WriteLine("Lo siento, esa letra no está en la palabra");
					contador--;
				}
				
			}
			while (contador>0&&palabraAdivinando.ToString()!=palabraAdivinar);
			
			if(palabraAdivinando.ToString().ToUpper()==palabraAdivinar.ToUpper())
					Console.WriteLine("Magnificástico, has acertado la palabra");
			else if(contador==0)
				Console.WriteLine("No te quedan intentos y no has conseguido adivinar la palabra. Lamentable, debería darte vergüenza.");
		}
		catch(Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}
}
