using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Ignacio Pastor Padilla - Practica Tema 8 - Programación - DAM Semipresencial
//Subclase de Usuarios, de la que hereda. Aquí gestionamos lo relativo a los Operarios así como la fabricación de muebles y el menú de opciones
namespace GestionDeMuebles
{
    class Operarios : Usuarios
    {
        protected string turno;
        int cantidadFabricada;
        int pasadas;

        string fechaTemporal;
        bool fechaCorrecta;
        ushort patasTemporales;
        string fechaBuscar;
        string datoTemporal;

        public Operarios()
        {

        }
        public Operarios(string nombre, string apellidos, string nick, string password, string turno)
            : base(nombre, apellidos, nick, password)
        {
            this.turno = turno;
        }
        public void SetTurno(string turno)
        {
            this.turno = turno;
        }
        public string GetTurno()
        {
            return turno;
        }
        public override string Mostrar()
        {
            return base.Mostrar() + ";" + turno;
        }
        public void Fabrica()
        {
            int opcion;
            do
            {
                Console.WriteLine("Menú");
                Console.WriteLine("1. Fabricación de mesas de ordenador");
                Console.WriteLine("2. Fabricación de mesas de oficina");
                Console.WriteLine("3. Fabricación de mesas de comedor");
                Console.WriteLine("4. Fabricación de sillas de oficina");
                Console.WriteLine("5. Fabricación de sillas de comedor");
                Console.WriteLine("6. Listado de elementos fabricados en una fecha concreta");
                Console.WriteLine("0. Salir");
                try
                {
                    opcion = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Ha habido un error: " + e.Message);
                    opcion = 111;
                }
                catch (Exception o)
                {
                    Console.WriteLine("Ha habido un error: " + o.Message);
                    opcion = 111;
                }

                MetodoSwitch(opcion);
            }
            while (opcion != 0);
        }
        public void MetodoSwitch(int opcion)
        {
            switch (opcion)
            {
                case 1: // Fabricación de mesas de ordenador
                    SetCantidadFabricada();
                    do
                    {
                        FabricarMesaOrdenador();
                        FabricarMesa();
                        FabricarMesaOficina(false);
                        FabricarMueble();
                        pasadas++;
                    }
                    while (GetCantidadFabricada() != pasadas);
                    break;
                case 2: // Fabricación de mesas de oficina
                    SetCantidadFabricada();
                    do
                    {
                        FabricarMesaOficina(true);
                        FabricarMesa();
                        FabricarMueble();
                        pasadas++;
                    }
                    while (GetCantidadFabricada() != pasadas);
                    break;
                case 3: // Fabricación de mesas de comedor
                    SetCantidadFabricada();
                    do
                    {
                        FabricarMesaComedor();
                        FabricarMesa();
                        FabricarMueble();
                        pasadas++;
                    }
                    while (GetCantidadFabricada() != pasadas);
                    break;
                case 4: // Fabricación de sillas de oficina
                    SetCantidadFabricada();
                    do
                    {
                        FabricarSillaOficina();
                        FabricarSilla();
                        FabricarMueble();
                        pasadas++;
                    }
                    while (GetCantidadFabricada() != pasadas);
                    break;
                case 5: //Fabricación de sillas de comedor
                    SetCantidadFabricada();
                    do
                    {
                        FabricarSillaComedor();
                        FabricarSilla();
                        FabricarMueble();
                        pasadas++;
                    }
                    while (GetCantidadFabricada() != pasadas);
                    break;
                case 6: // Listado de elementos fabricados en una fecha concreta
                    ListadoFechaFabricacionConcreta();
                    break;
                case 0: // Salir
                    ActualizarFichero();
                    Console.WriteLine("El fichero ha sido actualizado.");
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("No es una opción válida");
                    break;
            }//Fin switch
        }// Fin MetodoSwitch

        public void SetCantidadFabricada()
        {
            try
            {
                Console.WriteLine("Introduce la cantidad de elementos de este mueble que se van a introducir en el archivo");
                cantidadFabricada = Convert.ToInt32(Console.ReadLine());
            }
            catch(FormatException e)
            {
                Console.WriteLine("Ha habido un error: " + e.Message);
                cantidadFabricada = 1;
            }
            catch(Exception o)
            {
                Console.WriteLine("Ha habido un error: " + o.Message);
            }
            pasadas = 0;
        }
        public int GetCantidadFabricada()
        {
            return cantidadFabricada;
        }

        public void FabricarMueble()
        {
                Console.WriteLine("Introduce el material");
                m[a.GetContadorMuebles()].SetMaterial(Console.ReadLine());
                Console.WriteLine("Introduce el color");
                m[a.GetContadorMuebles()].SetColor(Console.ReadLine());
            do
            {
                Console.WriteLine("Introduce la fecha de fabricación (formato \"dd/mm/aaaa\")");
                fechaTemporal = Console.ReadLine();
                if (fechaTemporal.Length == 10 && fechaTemporal[2] == '/' && fechaTemporal[5] == '/')
                    fechaCorrecta = true;
                else
                {
                    Console.WriteLine("El formato de fecha no es válido");
                    fechaCorrecta = false;
                }
            }
            while (fechaCorrecta == false);
            m[a.GetContadorMuebles()].SetFechaFabricacion(fechaTemporal);
            try
            {
                Console.WriteLine("Introduce el precio de venta");
                m[a.GetContadorMuebles()].SetPrecioVenta(Convert.ToSingle(Console.ReadLine()));
            }
            catch (FormatException e)
            {
                Console.WriteLine("Ha habido un error: " + e.Message);
            }
            catch (Exception o)
            {
                Console.WriteLine("Ha habido un error: " + o.Message);
            }
            a.SetContadorMuebles(a.GetContadorMuebles() + 1);
        }
        public void FabricarMesa()
        {
            try
            {
                Console.WriteLine("Introduce el alto de la mesa");
                ((Mesas)m[a.GetContadorMuebles()]).SetAlto(Convert.ToSingle(Console.ReadLine()));
            }
            catch (FormatException e)
            {
                Console.WriteLine("Ha habido un error: " + e.Message);
            }
            catch (Exception o)
            {
                Console.WriteLine("Ha habido un error: " + o.Message);
            }
            try
            {
                Console.WriteLine("Introduce el ancho de la mesa");
                ((Mesas)m[a.GetContadorMuebles()]).SetAncho(Convert.ToSingle(Console.ReadLine()));
            }
            catch (FormatException e)
            {
                Console.WriteLine("Ha habido un error: " + e.Message);
            }
            catch (Exception o)
            {
                Console.WriteLine("Ha habido un error: " + o.Message);
            }
            try
            {
                Console.WriteLine("Introduce el largo de la mesa");
                ((Mesas)m[a.GetContadorMuebles()]).SetLargo(Convert.ToSingle(Console.ReadLine()));
            }
            catch (FormatException e)
            {
                Console.WriteLine("Ha habido un error: " + e.Message);
            }
            catch (Exception o)
            {
                Console.WriteLine("Ha habido un error: " + o.Message);
            }
        }
        public void FabricarMesaComedor()
        {
            m[a.GetContadorMuebles()] = new MesasComedor();
            do
            {
                try
                {
                    Console.WriteLine("Introduce el número de patas de la mesa");
                    patasTemporales = Convert.ToUInt16(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Ha habido un error: " + e.Message);
                    patasTemporales = 3;
                }
                catch (Exception o)
                {
                    Console.WriteLine("Ha habido un error: " + o.Message);
                    patasTemporales = 3;
                }
                if (patasTemporales != 2 && patasTemporales != 4)
                    Console.WriteLine("El número de patas debe ser 2 ó 4");
            }
            while (patasTemporales != 2 && patasTemporales != 4);
            ((MesasComedor)m[a.GetContadorMuebles()]).SetNumeroPatas(patasTemporales);
            Console.WriteLine("Introduce la forma de las patas de la mesa");
            ((MesasComedor)m[a.GetContadorMuebles()]).SetFormaPatas(Console.ReadLine());

        }
        public void FabricarMesaOficina(bool serMesaOficina)
        {
            if (serMesaOficina == true)
                m[a.GetContadorMuebles()] = new MesasOficina();
            try
            {
                Console.WriteLine("Introduce el número de cajones de la mesa");
                ((MesasOficina)m[a.GetContadorMuebles()]).SetNumeroCajones(Convert.ToUInt16(Console.ReadLine()));
            }
            catch (FormatException e)
            {
                Console.WriteLine("Ha habido un error: " + e.Message);
            }
            catch (Exception o)
            {
                Console.WriteLine("Ha habido un error: " + o.Message);
            }
            do
            {
                Console.WriteLine("Indica si tiene ruedas (pulsa tecla \"s\" si sí que tiene, y \"n\" si no tiene)");
                datoTemporal = Console.ReadLine();
                if (datoTemporal != "s" && datoTemporal != "n" && datoTemporal != "S" && datoTemporal != "N")
                    Console.WriteLine("No es una opción válida");
            }
            while (datoTemporal != "s" && datoTemporal != "n" && datoTemporal != "S" && datoTemporal != "N");
            if (datoTemporal == "s" || datoTemporal == "S")
                ((MesasOficina)m[a.GetContadorMuebles()]).SetRuedas(Convert.ToBoolean("true"));
            else if (datoTemporal == "n" || datoTemporal == "N")
                ((MesasOficina)m[a.GetContadorMuebles()]).SetRuedas(Convert.ToBoolean("false"));
        }
        public void FabricarMesaOrdenador()
        {
            m[a.GetContadorMuebles()] = new MesasOrdenador();

            try
            {
                Console.WriteLine("Introduce el largo de la bandeja de teclado");
                ((MesasOrdenador)m[a.GetContadorMuebles()]).SetLargoBandejaTeclado(Convert.ToSingle(Console.ReadLine()));
            }
            catch (FormatException e)
            {
                Console.WriteLine("Ha habido un error: " + e.Message);
            }
            catch (Exception o)
            {
                Console.WriteLine("Ha habido un error: " + o.Message);
            }
            try
            {
                Console.WriteLine("Introduce el ancho de la bandeja de teclado");
                ((MesasOrdenador)m[a.GetContadorMuebles()]).SetAnchoBandejaTeclado(Convert.ToSingle(Console.ReadLine()));
            }
            catch (FormatException e)
            {
                Console.WriteLine("Ha habido un error: " + e.Message);
            }
            catch (Exception o)
            {
                Console.WriteLine("Ha habido un error: " + o.Message);
            }
        }
        public void FabricarSilla()
        {
            do
            {
                Console.WriteLine("Indica si tiene antebrazos (pulsa tecla \"s\" si sí que tiene, y \"n\" si no tiene");
                datoTemporal = Console.ReadLine();
                if (datoTemporal != "s" && datoTemporal != "n" && datoTemporal != "S" && datoTemporal != "N")
                    Console.WriteLine("Opción no válida");
            }
            while (datoTemporal != "s" && datoTemporal != "n" && datoTemporal != "S" && datoTemporal != "N");
            if (datoTemporal == "s" || datoTemporal == "S")
                ((Sillas)m[a.GetContadorMuebles()]).SetAntebrazos(Convert.ToBoolean("true"));
            else if (datoTemporal == "n" || datoTemporal == "N")
                ((Sillas)m[a.GetContadorMuebles()]).SetAntebrazos(Convert.ToBoolean("false"));
        }
        public void FabricarSillaOficina()
        {
            m[a.GetContadorMuebles()] = new SillasOficina();

            Console.WriteLine("Introduce el material de la pata");
            ((SillasOficina)m[a.GetContadorMuebles()]).SetMaterialPata(Console.ReadLine());
            try
            {
                Console.WriteLine("Introduce el número de ruedas de la silla");
                ((SillasOficina)m[a.GetContadorMuebles()]).SetNumeroRuedas(Convert.ToUInt16(Console.ReadLine()));
            }
            catch (FormatException e)
            {
                Console.WriteLine("Ha habido un error: " + e.Message);
            }
            catch (Exception o)
            {
                Console.WriteLine("Ha habido un error: " + o.Message);
            }
        }
        public void FabricarSillaComedor()
        {
            m[a.GetContadorMuebles()] = new SillasComedor();

            Console.WriteLine("Introduce el material del asiento");
            ((SillasComedor)m[a.GetContadorMuebles()]).SetMaterialAsiento(Console.ReadLine());
            Console.WriteLine("Introduce el material del respaldo");
            ((SillasComedor)m[a.GetContadorMuebles()]).SetMaterialRespaldo(Console.ReadLine());
            Console.WriteLine("Introduce la forma de las patas");
            ((SillasComedor)m[a.GetContadorMuebles()]).SetFormaPatas(Console.ReadLine());
        }
        public void ListadoFechaFabricacionConcreta()
        {
            do
            {
                Console.WriteLine("Introduce la fecha de fabricación (formato \"dd/mm/aaaa\")");
                fechaTemporal = Console.ReadLine();
                if (fechaTemporal.Length == 10 && fechaTemporal[2] == '/' && fechaTemporal[5] == '/')//bien
                    fechaCorrecta = true;
                else
                {
                    Console.WriteLine("El formato de fecha no es válido");
                    fechaCorrecta = false;
                }
            }
            while (fechaCorrecta == false);

            fechaBuscar = fechaTemporal;
            mueblesDisponibles = false;
            for (int i = 0; i < a.GetContadorMuebles(); i++)
            {
                if (m[i].GetFechaFabricacion() == fechaBuscar)//Buscamos coincidencias, si las hay buscamos el tipo de objeto que es e imprimimos
                {
                    if (Convert.ToString(m[i].GetType()) == "GestionDeMuebles.MesasComedor")
                    {
                        ImprimirMesasComedor(i);
                        Console.WriteLine();
                        mueblesDisponibles = true;
                    }
                    else if (Convert.ToString(m[i].GetType()) == "GestionDeMuebles.MesasOficina")
                    {
                        ImprimirMesasOficina(i);
                        Console.WriteLine();
                        mueblesDisponibles = true;
                    }
                    else if (Convert.ToString(m[i].GetType()) == "GestionDeMuebles.MesasOrdenador")
                    {
                        ImprimirMesasOrdenador(i);
                        Console.WriteLine();
                        mueblesDisponibles = true;
                    }
                    if (Convert.ToString(m[i].GetType()) == "GestionDeMuebles.SillasOficina")
                    {
                        ImprimirSillasOficina(i);
                        Console.WriteLine();
                        mueblesDisponibles = true;
                    }
                    else if (Convert.ToString(m[i].GetType()) == "GestionDeMuebles.SillasComedor")
                    {
                        ImprimirSillasComedor(i);
                        Console.WriteLine();
                        mueblesDisponibles = true;
                    }
                }// Fin del if encontrar la fecha de fabricación concreta
            }//Fin del bucle for
            if (mueblesDisponibles == false)//Caso de que no haya muebles que cumplan los requisitos
                Console.WriteLine("No hay muebles fabricados en esa fecha");
        }// Fin del método ListadoFechaFabricacionConcreta()
    }
}
