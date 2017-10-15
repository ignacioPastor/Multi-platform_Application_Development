using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//Ignacio Pastor Padilla - Practica Tema 8 - Programación - DAM Semipresencial
//Clase donde gestionamos las características comunes de Vendedores y Operarios
//Aquí tendremos los métodos de Imprimir las características de los muebles, que utilizaremos en Vendedores y Operarios
namespace GestionDeMuebles
{
    class Usuarios
    { 
        protected int posicionMueble;
        protected bool mueblesDisponibles;
        protected Almacen a = Singleton.GetAlmacen();
        protected Muebles[] m = Singleton.GetMuebles();
        protected string nombre;
        protected string apellidos;
        protected string nick;
        protected string password;

        public Usuarios()
        {
   
        }
        public Usuarios(string nombre, string apellidos, string nick, string password)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.nick = nick;
            this.password = password;
        }
        public void SetNombre(string nombre)
        {
            this.nombre = nombre;
        }
        public string GetNombre()
        {
            return nombre;
        }
        public void SetApellidos(string apellidos)
        {
            this.apellidos = apellidos;
        }
        public string GetApellidos()
        {
            return apellidos;
        }
        public void SetNick(string nick)
        {
            this.nick = nick;
        }
        public string GetNick()
        {
            return nick;
        }
        public void SetPassword(string password)
        {
            this.password = password;
        }
        public string GetPassword()
        {
            return password;
        }
        public virtual string Mostrar()
        {
            return nombre + ";" + apellidos + ";" + nick + ";" + password;
        }

        public void ImprimirMesasComedor(int i)
        {
            Console.WriteLine("Posición: {0}", i);
            Console.WriteLine("Material: {0}", m[i].GetMaterial());
            Console.WriteLine("Color: {0}", m[i].GetColor());
            Console.WriteLine("Fecha de Fabricación: {0}", m[i].GetFechaFabricacion());
            Console.WriteLine("Precio de Venta: {0}", m[i].GetPrecioVenta());
            Console.WriteLine("Altura: {0}", ((MesasComedor)m[i]).GetAlto());
            Console.WriteLine("Ancho: {0}", ((MesasComedor)m[i]).GetAncho());
            Console.WriteLine("Largo: {0}", ((MesasComedor)m[i]).GetLargo());
            Console.WriteLine("Numero de Patas: {0}", ((MesasComedor)m[i]).GetNumeroPatas());
            Console.WriteLine("Forma de las Patas: {0}", ((MesasComedor)m[i]).GetFormaPatas());
        }
        public void ImprimirMesasOficina(int i)
        {
            Console.WriteLine("Posición: {0}", i);
            Console.WriteLine("Material: {0}", m[i].GetMaterial());
            Console.WriteLine("Color: {0}", m[i].GetColor());
            Console.WriteLine("Fecha de Fabricación: {0}", m[i].GetFechaFabricacion());
            Console.WriteLine("Precio de Venta: {0}", m[i].GetPrecioVenta());
            Console.WriteLine("Altura: {0}", ((MesasOficina)m[i]).GetAlto());
            Console.WriteLine("Ancho: {0}", ((MesasOficina)m[i]).GetAncho());
            Console.WriteLine("Largo: {0}", ((MesasOficina)m[i]).GetLargo());
            Console.WriteLine("Numero de Cajones: {0}", ((MesasOficina)m[i]).GetNumeroCajones());
            Console.WriteLine("Tener ruedas: {0}", ((MesasOficina)m[i]).GetRuedas());
        }
        public void ImprimirMesasOrdenador(int i)
        {
            Console.WriteLine("Posición: {0}", i);
            Console.WriteLine("Material: {0}", m[i].GetMaterial());
            Console.WriteLine("Color: {0}", m[i].GetColor());
            Console.WriteLine("Fecha de Fabricación: {0}", m[i].GetFechaFabricacion());
            Console.WriteLine("Precio de Venta: {0}", m[i].GetPrecioVenta());
            Console.WriteLine("Altura: {0}", ((MesasOrdenador)m[i]).GetAlto());
            Console.WriteLine("Ancho: {0}", ((MesasOrdenador)m[i]).GetAncho());
            Console.WriteLine("Largo: {0}", ((MesasOrdenador)m[i]).GetLargo());
            Console.WriteLine("Numero de Cajones: {0}", ((MesasOrdenador)m[i]).GetNumeroCajones());
            Console.WriteLine("Tener ruedas: {0}", ((MesasOrdenador)m[i]).GetRuedas());
            Console.WriteLine("Largo de la Bandeja del Teclado: {0}", ((MesasOrdenador)m[i]).GetLargoBandejaTeclado());
            Console.WriteLine("Ancho de la Bandeja del Teclado: {0}", ((MesasOrdenador)m[i]).GetAnchoBandejaTeclado());
        }
        public void ImprimirSillasOficina(int i)
        {
            Console.WriteLine("Posición: {0}", i);
            Console.WriteLine("Material: {0}", m[i].GetMaterial());
            Console.WriteLine("Color: {0}", m[i].GetColor());
            Console.WriteLine("Fecha de Fabricación: {0}", m[i].GetFechaFabricacion());
            Console.WriteLine("Precio de Venta: {0}", m[i].GetPrecioVenta());
            Console.WriteLine("Lleva antebrazos: {0}", ((SillasOficina)m[i]).GetAntebrazos());
            Console.WriteLine("Material de la Pata: {0}", ((SillasOficina)m[i]).GetMaterialPata());
            Console.WriteLine("Numero de Ruedas: {0}", ((SillasOficina)m[i]).GetNumeroRuedas());
        }
        public void ImprimirSillasComedor(int i)
        {
            Console.WriteLine("Posición: {0}", i);
            Console.WriteLine("Material: {0}", m[i].GetMaterial());
            Console.WriteLine("Color: {0}", m[i].GetColor());
            Console.WriteLine("Fecha de Fabricación: {0}", m[i].GetFechaFabricacion());
            Console.WriteLine("Precio de Venta: {0}", m[i].GetPrecioVenta());
            Console.WriteLine("Lleva Antebrazos: {0}", ((SillasComedor)m[i]).GetAntebrazos());
            Console.WriteLine("Material del Asiento: {0}", ((SillasComedor)m[i]).GetMaterialAsiento());
            Console.WriteLine("Material del Respaldo: {0}", ((SillasComedor)m[i]).GetMaterialRespaldo());
            Console.WriteLine("Forma de las patas: {0}", ((SillasComedor)m[i]).GetFormaPatas());
        }
        public void ActualizarFichero()
        {
            StreamWriter fichero = File.CreateText("muebles.txt");
            for (int i = 0; i < a.GetContadorMuebles(); i++)
            {
                fichero.WriteLine(Convert.ToString(m[i].GetType()) + ";" + m[i].Mostrar());
            }

            fichero.Close();
        }
    }
}
