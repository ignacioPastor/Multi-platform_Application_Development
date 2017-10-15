using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Ignacio Pastor Padilla - Practica Tema 8 - Programación - DAM Semipresencial
//En esta clase mostramos el menú de entrada para los usuarios y almacenamos en un array los datos de los usuarios
namespace GestionDeMuebles
{
    class EntradaUsuarios
    {
        bool continuar;
        int contadorUsuarios = 0;
        Usuarios[] u = Singleton.GetUsuarios();//Array para almacenar los datos de los usuarios
        Almacen a;
        string usuario, contrasenya;

        public EntradaUsuarios()
        {
            CargarUsuarios();//Cargamos los datos de los usuarios
            a = new Almacen();
        }
        public void MenuEntrada()//Menú de entrada para los usuarios
        {
            int posicionUsuario = -1;
            do
            {
                continuar = false;
                Console.WriteLine("Nota para el Profesor encargado de corregir: Los usuarios y contraseñas válidos son:");
                Console.WriteLine("nick: \"Operario\" con contraseña \"Soy un operario\"");
                Console.WriteLine("nick: \"Vendedor\" con contraseña \"Soy un vendedor\"");
                Console.WriteLine("Introduce tu nick");
                usuario = Console.ReadLine();
                Console.WriteLine("Introduce tu contraseña");
                contrasenya = Console.ReadLine();

                for (int i = 0; i < contadorUsuarios; i++)
                {
                    if (usuario == u[i].GetNick() && contrasenya == u[i].GetPassword())
                    {
                        posicionUsuario = i;
                        continuar = true;
                    }
                }
                if (continuar == false)
                    Console.WriteLine("No es un usuario o contraseña válido");
            }
            while (continuar == false);
            a.Trabaja(u[posicionUsuario]);
        }

        public void CargarUsuarios()
        {
            u[0] = new Operarios();
            u[1] = new Vendedores();

            u[0].SetNombre("Francisco");
            u[0].SetApellidos("Mendieta Guzman");
            u[0].SetNick("Operario");
            u[0].SetPassword("Soy un operario");
            ((Operarios)u[0]).SetTurno("L-V, mañanas");
            contadorUsuarios++;

            u[1].SetNombre("Marcos");
            u[1].SetApellidos("Rodriguez Martinez");
            u[1].SetNick("Vendedor");
            u[1].SetPassword("Soy un vendedor");
            ((Vendedores)u[1]).SetComisionAcumulada(0f);
            ((Vendedores)u[1]).SetPorcentajeComision(0.1f);
            contadorUsuarios++;
        }
    }
}
