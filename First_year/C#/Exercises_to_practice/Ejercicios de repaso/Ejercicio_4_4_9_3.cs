// (4.4.9.3) Crea un juego del ahorcado, en el que un primer usuario introduzca la palabra a adivinar,
// se muestre ésta oculta con guiones (-----) y el programa acepte las letras que introduzca el segundo usuario,
// cambiando los guiones por letras correctas cada vez que acierte (por ejemplo, a---a-t-).
// La partida terminará cuando se acierte la palabra por completo o el usuario agote sus 8 intentos.

using System;
using System.Text;
public class Ejercicio_4_4_9_3
{
	public static void Main()
	{
		try
		{
			string palabraAdivinar;
			bool acierto;
			byte contador=8;
			char letraUsuario;
			
			Console.WriteLine("Introduce la palabra que quieres adivinar");
			palabraAdivinar = Console.ReadLine();
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
					Console.WriteLine("Lo siento, esa letra no está en la palabra");
				
				contador--;
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
