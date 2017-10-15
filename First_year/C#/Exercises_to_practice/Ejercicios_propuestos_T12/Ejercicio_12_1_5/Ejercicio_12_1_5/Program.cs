using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Ignacio Pastor Padilla - DAM Semi - A

// (12.1.5) Crea un programa que muestre el calendario correspondiente al mes y el año
// que se indiquen como parámetros en línea de comandos.


namespace Ejercicio_12_1_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int anyo = 0;
            int mes = 0, numDias, dia = 1;
            int nDiaSemana;
            bool finMes = false;
            bool datosCorrectos = true;
            bool inicioEscritura = false;

            do
            {
                try
                {
                    datosCorrectos = true;
                    Console.WriteLine("Idica el año");
                    anyo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Indica el mes");
                    mes = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ha habido un error {0}", e.Message);
                    datosCorrectos = false;
                }
            }
            while (datosCorrectos == false);

            DateTime calendario = new DateTime(anyo, mes, 1);

            numDias = DateTime.DaysInMonth(anyo, mes);
            nDiaSemana = (int)calendario.DayOfWeek;
            Console.WriteLine("Lu Ma Mi Ju Vi Sa Do");
            for  (int i = 0; i < 6 && finMes == false; i++)
            {
                for (int j = 0; j < 7 && finMes == false; j++)
                {
                    if (nDiaSemana == 0)
                        Console.WriteLine("                   {0}", calendario.Day);
                    else 
                    {
                        
                        if (nDiaSemana - 1 > j && !inicioEscritura)
                            Console.Write("   ");
                        else
                        {
                            inicioEscritura = true;
                            if(calendario.Day < 10)
                                Console.Write(" ");
                            Console.Write("{0} ", calendario.Day);
                            if (numDias == calendario.Day)
                                finMes = true;
                            else
                                calendario = calendario.AddDays(1);
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
