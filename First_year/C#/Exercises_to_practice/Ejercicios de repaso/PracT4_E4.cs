

using System;
public class PracT4_E4
{
	struct articuloSimple
	{
		public string nombre;
		public short stock;
	}
	struct quits
	{
		public string nombreKit;
		public articuloSimple articuloSimple1;
		public short cantidadSimple1;
		public articuloSimple articuloSimple2;
		public short cantidadSimple2;
	}
	public static void Main()
	{
		try
		{
			byte nArticulos, i, kits1, kits2;
			
			Console.WriteLine("Cuántos artículos vas a inventariar");
			nArticulos=Convert.ToByte(Console.ReadLine());
			
			quits[] kits = new quits[nArticulos];
			
			for (i = 0; i < kits.Length; i++)
			{
				Console.WriteLine("Introduce el nombre del Kit {0}", i+1);
				kits[i].nombreKit=Console.ReadLine();
				Console.WriteLine("Introduce el nombre del artículo simple 1");
				kits[i].articuloSimple1.nombre=Console.ReadLine();
				Console.WriteLine("Introduce el stock del artículo simple 1");
				kits[i].articuloSimple1.stock=Convert.ToInt16(Console.ReadLine());
				Console.WriteLine("Introduce la cantidad utilizada del artículo simple 1");
				kits[i].cantidadSimple1=Convert.ToInt16(Console.ReadLine());
				Console.WriteLine("Introduce el nombre del artículo simple 2");
				kits[i].articuloSimple2.nombre=Console.ReadLine();
				Console.WriteLine("Introduce el stock del artículo simple 2");
				kits[i].articuloSimple2.stock=Convert.ToInt16(Console.ReadLine());
				Console.WriteLine("Introduce la cantidad utilizada del artículo simple 2");
				kits[i].cantidadSimple2=Convert.ToInt16(Console.ReadLine());
			}
			Console.WriteLine("Numeros de Kits que podemos vender:");
			for (i = 0; i < kits.Length; i++)
			{
				kits1=Convert.ToByte(kits[i].articuloSimple1.stock/kits[i].cantidadSimple1);
				kits2=Convert.ToByte(kits[i].articuloSimple2.stock/kits[i].cantidadSimple2);
				if(kits1>kits2)
					Console.WriteLine("{0}: {1}", kits[i].nombreKit, kits2);
				else
					Console.WriteLine("{0}: {1}", kits[i].nombreKit, kits1);
				
				
			}
		}
		catch(Exception e)
		{
			Console.WriteLine(e.Message);
		}
			
			
	}
}
