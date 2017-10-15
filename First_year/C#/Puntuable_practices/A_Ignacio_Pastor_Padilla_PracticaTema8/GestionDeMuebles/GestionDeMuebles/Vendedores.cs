using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Ignacio Pastor Padilla - Practica Tema 8 - Programación - DAM Semipresencial
//Subclase de Usuarios, aquí gestionaremos lo relativo a los Vendedores.
//Tenemos el menú de los vendedores, los métodos para vender (eliminar elementos del array), etc.
namespace GestionDeMuebles
{
    class Vendedores : Usuarios
    {
        Usuarios[] u = Singleton.GetUsuarios();
        protected float comisionAcumulada;
        protected float porcentajeComision;
        string opcionVender;
        string descripcionBusqueda;

        public Vendedores()
        {

        }
        public Vendedores(string nombre, string apellidos, string nick, string password, float comisionAcumulada, float porcentajeComision)
            : base(nombre, apellidos, nick, password)
        {
            this.comisionAcumulada = comisionAcumulada;
            this.porcentajeComision = porcentajeComision;
        }
        public void SetComisionAcumulada(float comisionAcumulada)
        {
            this.comisionAcumulada = comisionAcumulada;
        }
        public float GetComisionAcumulada()
        {
            return comisionAcumulada;
        }
        public void SetPorcentajeComision(float porcentajeComision)
        {
            this.porcentajeComision = porcentajeComision;
        }
        public float GetPorcentajeComision()
        {
            return porcentajeComision;
        }
        public override string Mostrar()
        {
            return base.Mostrar() + ";" + comisionAcumulada + ";" + porcentajeComision;
        }
        public void Vende()
        {
            int opcion;
            do
            {
                Console.WriteLine("Menú");
                Console.WriteLine("1. Venta de mesa de ordenador");
                Console.WriteLine("2. Venta de mesa de oficina");
                Console.WriteLine("3. Venta de mesa de comedor");
                Console.WriteLine("4. Venta de mesa de color o material...");
                Console.WriteLine("5. Venta de silla de oficina");
                Console.WriteLine("6. Veneta de silla de comedor");
                Console.WriteLine("7. Venta de silla de color o material...");
                Console.WriteLine("8. Ver comisión acumulada");
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
                case 1: // Venta de mesa de ordenador
                    VenderMesaOrdenador();
                    break;
                case 2: // Venta de mesa de oficina
                    VenderMesaOficina();
                    break;
                case 3: // Venta de mesa de comedor
                    VenderMesaComedor();
                    break;
                case 4: // Venta de mesa de color o material...
                    VenderMesaPorColorMaterial();
                    break;
                case 5: // Venta de silla de oficina
                    VenderSillaOficina();
                    break;
                case 6: // Venta de silla de comedor
                    VenderSillaComedor();
                    break;
                case 7: // Venta de silla de color o material...
                    VenderSillaPorColorMaterial();
                    break;
                case 8:
                    Console.WriteLine("Comisión acumulada: " + ((Vendedores)u[1]).GetComisionAcumulada() + " euros");
                    break;
                case 0: // Salir
                    ActualizarFichero();
                    Console.WriteLine("El fichero ha sido actualizado.");
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("No es una opción válida");
                    break;
            }
        }

        public void VenderMesaOrdenador()
        {
            mueblesDisponibles = false;
            for (int i = 0; i < a.GetContadorMuebles(); i++)
            {


                if (Convert.ToString(m[i].GetType()) == "GestionDeMuebles.MesasOrdenador")
                {
                    ImprimirMesasOrdenador(i);
                    Console.WriteLine();
                    mueblesDisponibles = true;
                }
            }
            if (mueblesDisponibles == false)
                Console.WriteLine("No hay muebles de este tipo disponibles para vender");
            else
            {
                Console.WriteLine("Indica la posición del mueble que quieres vender");
                Console.WriteLine("Teclea \"salir\" si no va a vender ninguna");
                opcionVender = Console.ReadLine();
                if (opcionVender != "salir")
                {
                    try
                    {
                        posicionMueble = Convert.ToInt32(opcionVender);
                        //Aquí sumamos el porcentaje de comisión que le corresponda al vendedor al realizar una venta
                        ((Vendedores)u[1]).SetComisionAcumulada(((Vendedores)u[1]).GetComisionAcumulada() +
                            (m[posicionMueble].GetPrecioVenta() * ((Vendedores)u[1]).GetPorcentajeComision()));
                        //Eliminamos el elemento del array que se haya vendido, moviendo una posición todos los otros elementos
                        for (int i = posicionMueble; i < a.GetContadorMuebles() - 1; i++)
                            m[i] = m[i + 1];
                        a.SetContadorMuebles(a.GetContadorMuebles() - 1);//Restamos uno al contador
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
            }
        }//Fin método VenderMesaOrdenador

        public void VenderMesaOficina()
        {
            mueblesDisponibles = false;
            for (int i = 0; i < a.GetContadorMuebles(); i++)
            {
                if (Convert.ToString(m[i].GetType()) == "GestionDeMuebles.MesasOficina")
                {
                    ImprimirMesasOficina(i);
                    Console.WriteLine();
                    mueblesDisponibles = true;
                }
            }
            if (mueblesDisponibles == false)
                Console.WriteLine("No hay muebles de este tipo disponibles para vender");
            else
            {
                try
                {
                    Console.WriteLine("Indica la posición del mueble que quieres vender");
                    Console.WriteLine("Teclea \"salir\" si no va a vender ninguna");
                    opcionVender = Console.ReadLine();
                    if (opcionVender != "salir")
                    {
                        posicionMueble = Convert.ToInt32(opcionVender);
                        ((Vendedores)u[1]).SetComisionAcumulada(((Vendedores)u[1]).GetComisionAcumulada() +
                            (m[posicionMueble].GetPrecioVenta() * ((Vendedores)u[1]).GetPorcentajeComision()));

                        for (int i = posicionMueble; i < a.GetContadorMuebles() - 1; i++)
                            m[i] = m[i + 1];
                        a.SetContadorMuebles(a.GetContadorMuebles() - 1);
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Ha habido un error: " + e.Message);
                    Console.WriteLine("No se ha registrado la venta");
                }
                catch (Exception o)
                {
                    Console.WriteLine("Ha habido un error: " + o.Message);
                    Console.WriteLine("No se ha registrado la venta");
                }
            }
        }//Fin del método vender mesa oficina

        public void VenderMesaComedor()
        {
            mueblesDisponibles = false;
            for (int i = 0; i < a.GetContadorMuebles(); i++)
            {
                if (Convert.ToString(m[i].GetType()) == "GestionDeMuebles.MesasComedor")
                {
                    ImprimirMesasComedor(i);
                    Console.WriteLine();
                    mueblesDisponibles = true;
                }
            }
            if (mueblesDisponibles == false)
                Console.WriteLine("No hay muebles de este tipo disponibles para vender");
            else
            {
                try
                {
                    Console.WriteLine("Indica la posición del mueble que quieres vender");
                    Console.WriteLine("Teclea \"salir\" si no va a vender ninguna");
                    opcionVender = Console.ReadLine();
                    if (opcionVender != "salir")
                    {
                        posicionMueble = Convert.ToInt32(opcionVender);
                        ((Vendedores)u[1]).SetComisionAcumulada(((Vendedores)u[1]).GetComisionAcumulada() +
                            (m[posicionMueble].GetPrecioVenta() * ((Vendedores)u[1]).GetPorcentajeComision()));

                        for (int i = posicionMueble; i < a.GetContadorMuebles() - 1; i++)
                            m[i] = m[i + 1];
                        a.SetContadorMuebles(a.GetContadorMuebles() - 1);
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Ha habido un error: " + e.Message);
                    Console.WriteLine("No se ha registrado la venta");
                }
                catch (Exception o)
                {
                    Console.WriteLine("Ha habido un error: " + o.Message);
                    Console.WriteLine("No se ha registrado la venta");
                }
            }
        }//Fin del método vender mesa comedor

        public void VenderSillaOficina()
        {
            mueblesDisponibles = false;
            for (int i = 0; i < a.GetContadorMuebles(); i++)
            {
                if (Convert.ToString(m[i].GetType()) == "GestionDeMuebles.SillasOficina")
                {
                    ImprimirSillasOficina(i);
                    Console.WriteLine();
                    mueblesDisponibles = true;
                }
            }
            if (mueblesDisponibles == false)
                Console.WriteLine("No hay muebles de este tipo disponibles para vender");
            else
            {
                try
                {
                    Console.WriteLine("Indica la posición del mueble que quieres vender");
                    Console.WriteLine("Teclea \"salir\" si no va a vender ninguna");
                    opcionVender = Console.ReadLine();
                    if (opcionVender != "salir")
                    {
                        posicionMueble = Convert.ToInt32(opcionVender);
                        ((Vendedores)u[1]).SetComisionAcumulada(((Vendedores)u[1]).GetComisionAcumulada() +
                            (m[posicionMueble].GetPrecioVenta() * ((Vendedores)u[1]).GetPorcentajeComision()));

                        for (int i = posicionMueble; i < a.GetContadorMuebles() - 1; i++)
                            m[i] = m[i + 1];
                        a.SetContadorMuebles(a.GetContadorMuebles() - 1);
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Ha habido un error: " + e.Message);
                    Console.WriteLine("No se ha registrado la venta");
                }
                catch (Exception o)
                {
                    Console.WriteLine("Ha habido un error: " + o.Message);
                    Console.WriteLine("No se ha registrado la venta");
                }
            }
        }//Fin del método vender silla oficina

        public void VenderSillaComedor()
        {
            mueblesDisponibles = false;
            for (int i = 0; i < a.GetContadorMuebles(); i++)
            {
                if (Convert.ToString(m[i].GetType()) == "GestionDeMuebles.SillasComedor")
                {
                    ImprimirSillasComedor(i);
                    Console.WriteLine();
                    mueblesDisponibles = true;
                }
            }
            if (mueblesDisponibles == false)
                Console.WriteLine("No hay muebles de este tipo disponibles para vender");
            else
            {
                try
                {
                    Console.WriteLine("Indica la posición del mueble que quieres vender");
                    Console.WriteLine("Teclea \"salir\" si no va a vender ninguna");
                    opcionVender = Console.ReadLine();
                    if (opcionVender != "salir")
                    {
                        posicionMueble = Convert.ToInt32(opcionVender);
                        ((Vendedores)u[1]).SetComisionAcumulada(((Vendedores)u[1]).GetComisionAcumulada() +
                            (m[posicionMueble].GetPrecioVenta() * ((Vendedores)u[1]).GetPorcentajeComision()));

                        for (int i = posicionMueble; i < a.GetContadorMuebles() - 1; i++)
                            m[i] = m[i + 1];
                        a.SetContadorMuebles(a.GetContadorMuebles() - 1);
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Ha habido un error: " + e.Message);
                    Console.WriteLine("No se ha registrado la venta");
                }
                catch (Exception o)
                {
                    Console.WriteLine("Ha habido un error: " + o.Message);
                    Console.WriteLine("No se ha registrado la venta");
                }
            }
        }//Fin del método vender silla comedor

        public void VenderMesaPorColorMaterial()
        {
            mueblesDisponibles = false;
            Console.WriteLine("Indica el material o el color por el cuál quieres realizar la búsqueda");
            descripcionBusqueda = Console.ReadLine();
            for (int i = 0; i < a.GetContadorMuebles(); i++)
            {
                if (m[i].GetMaterial() == descripcionBusqueda || m[i].GetColor() == descripcionBusqueda)
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
                }
            }
            if (mueblesDisponibles == false)
                Console.WriteLine("No hay muebles de este tipo disponibles para vender");
            else
            {
                try
                {
                    Console.WriteLine("Indica la posición del mueble que quieres vender");
                    Console.WriteLine("Teclea \"salir\" si no va a vender ninguna");
                    opcionVender = Console.ReadLine();
                    if (opcionVender != "salir")
                    {
                        posicionMueble = Convert.ToInt32(opcionVender);
                        for (int i = posicionMueble; i < a.GetContadorMuebles() - 1; i++)
                            m[i] = m[i + 1];
                        a.SetContadorMuebles(a.GetContadorMuebles() - 1);
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Ha habido un error: " + e.Message);
                    Console.WriteLine("No se ha registrado la venta");
                }
                catch (Exception o)
                {
                    Console.WriteLine("Ha habido un error: " + o.Message);
                    Console.WriteLine("No se ha registrado la venta");
                }
            }
        }//Fin del método vender mesa por color o material

        public void VenderSillaPorColorMaterial()
        {
            mueblesDisponibles = false;
            Console.WriteLine("Indica el material o el color por el cuál quieres realizar la búsqueda");
            descripcionBusqueda = Console.ReadLine();
            for (int i = 0; i < a.GetContadorMuebles(); i++)
            {
                if (m[i].GetMaterial() == descripcionBusqueda || m[i].GetColor() == descripcionBusqueda)
                {
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
                }
            }
            if (mueblesDisponibles == false)
                Console.WriteLine("No hay muebles de este tipo disponibles para vender");
            else
            {
                try
                {
                    Console.WriteLine("Indica la posición del mueble que quieres vender");
                    Console.WriteLine("Teclea \"salir\" si no va a vender ninguna");
                    opcionVender = Console.ReadLine();
                    if (opcionVender != "salir")
                    {
                        posicionMueble = Convert.ToInt32(opcionVender);
                        for (int i = posicionMueble; i < a.GetContadorMuebles() - 1; i++)
                            m[i] = m[i + 1];
                        a.SetContadorMuebles(a.GetContadorMuebles() - 1);
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Ha habido un error: " + e.Message);
                    Console.WriteLine("No se ha registrado la venta");
                }
                catch (Exception o)
                {
                    Console.WriteLine("Ha habido un error: " + o.Message);
                    Console.WriteLine("No se ha registrado la venta");
                }
            }
        }//Fin del método vender silla por color o material
    }
}
