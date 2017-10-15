

using System;
public class PracT4_E3
{
	public static void Main()
	{
		try
		{
			byte nArticulos;

			Console.WriteLine("Indica el número de artículos a pedir");
			nArticulos=Convert.ToByte(Console.ReadLine());
			string[,] pedidos = new string[nArticulos,5];	
			
			for (byte i = 0; i < nArticulos; i++)
			{
				Console.WriteLine("Nombre del artículo: ");
				pedidos[i,0]=Console.ReadLine();
				Console.WriteLine("Cantidad el mes anterior: ");
				pedidos[i,1]=Console.ReadLine();
				if(Convert.ToInt16(pedidos[i,1])<0)
					pedidos[i,1]="0";
				Console.WriteLine("Cantidad actual");
				pedidos[i,2]=Console.ReadLine();
				if(Convert.ToInt16(pedidos[i,2])<0)
					pedidos[i,2]="0";
				Console.WriteLine("Cantidad Óptima");
				pedidos[i,3]=Console.ReadLine();
				if(Convert.ToInt16(pedidos[i,3])<0)
					pedidos[i,3]="0";

			}
			
			for (byte i = 0; i < nArticulos; i++)
			{
				pedidos[i,4]=Convert.ToString(Convert.ToInt16(pedidos[i,1])-Convert.ToInt16(pedidos[i,2])+Convert.ToInt16(pedidos[i,3]));
				Console.WriteLine("Pedido a realizar de {0}: {1} unidades", pedidos[i,0], pedidos[i,4]);
			}
			
			
		}
		catch(Exception e)
		{
			Console.WriteLine(e.Message);
		}
		
	
		
	}
}
