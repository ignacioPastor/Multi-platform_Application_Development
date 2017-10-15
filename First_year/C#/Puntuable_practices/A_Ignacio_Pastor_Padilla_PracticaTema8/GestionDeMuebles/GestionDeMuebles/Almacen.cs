using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//Ignacio Pastor Padilla - Practica Tema 8 - Programación - DAM Semipresencial
//En esta clase cargamos en el array de muebles los datos del fichero y gestionamos el trabajo del usuario (metodo trabajar).
namespace GestionDeMuebles
{
    class Almacen
    {
        int contadorMuebles = 0;
        Muebles[] m = Singleton.GetMuebles();
        String[] mueblesPartidos;
        string linea;

        public Almacen()
        {
            CargarDatosFichero();
        }
        public int GetContadorMuebles()
        {
            return contadorMuebles;
        }
        public void SetContadorMuebles(int contadorMuebles)
        {
            this.contadorMuebles = contadorMuebles;
        }

        public void CargarDatosFichero() //Metodo para cargar los datos del fichero en el array de muebles
        {
            if (File.Exists("muebles.txt"))//Comprobamos que el fichero existe para que no nos dé error
            {
                StreamReader ficheroLectura = File.OpenText("muebles.txt");
                try
                {
                    do
                    {
                        linea = ficheroLectura.ReadLine();
                        if (linea != null)
                        {
                            mueblesPartidos = linea.Split(';');//Leemos línea a línea, si no es null, la descomponemos y asignamos valores
                            if(mueblesPartidos[0] == "GestionDeMuebles.MesasComedor")
                            {
                                m[contadorMuebles] = new MesasComedor();//Inicializamos el objeto

                                m[contadorMuebles].SetMaterial(mueblesPartidos[1]);
                                m[contadorMuebles].SetColor(mueblesPartidos[2]);
                                m[contadorMuebles].SetFechaFabricacion(mueblesPartidos[3]);
                                m[contadorMuebles].SetPrecioVenta(Convert.ToSingle(mueblesPartidos[4]));
                                ((MesasComedor)m[contadorMuebles]).SetAlto(Convert.ToSingle(mueblesPartidos[5]));
                                ((MesasComedor)m[contadorMuebles]).SetAncho(Convert.ToSingle(mueblesPartidos[6]));
                                ((MesasComedor)m[contadorMuebles]).SetLargo(Convert.ToSingle(mueblesPartidos[7]));
                                ((MesasComedor)m[contadorMuebles]).SetNumeroPatas(Convert.ToUInt16(mueblesPartidos[8]));
                                ((MesasComedor)m[contadorMuebles]).SetFormaPatas(mueblesPartidos[9]);

                                contadorMuebles++;
                            }
                            else if(mueblesPartidos[0] == "GestionDeMuebles.MesasOficina")
                            {
                                m[contadorMuebles] = new MesasOficina();

                                m[contadorMuebles].SetMaterial(mueblesPartidos[1]);
                                m[contadorMuebles].SetColor(mueblesPartidos[2]);
                                m[contadorMuebles].SetFechaFabricacion(mueblesPartidos[3]);
                                m[contadorMuebles].SetPrecioVenta(Convert.ToSingle(mueblesPartidos[4]));
                                ((MesasOficina)m[contadorMuebles]).SetAlto(Convert.ToSingle(mueblesPartidos[5]));
                                ((MesasOficina)m[contadorMuebles]).SetAncho(Convert.ToSingle(mueblesPartidos[6]));
                                ((MesasOficina)m[contadorMuebles]).SetLargo(Convert.ToSingle(mueblesPartidos[7]));
                                ((MesasOficina)m[contadorMuebles]).SetNumeroCajones(Convert.ToUInt16(mueblesPartidos[8]));
                                ((MesasOficina)m[contadorMuebles]).SetRuedas(Convert.ToBoolean(mueblesPartidos[9]));

                                contadorMuebles++;
                            }
                            else if (mueblesPartidos[0] == "GestionDeMuebles.MesasOrdenador")
                            {
                                m[contadorMuebles] = new MesasOrdenador();

                                m[contadorMuebles].SetMaterial(mueblesPartidos[1]);
                                m[contadorMuebles].SetColor(mueblesPartidos[2]);
                                m[contadorMuebles].SetFechaFabricacion(mueblesPartidos[3]);
                                m[contadorMuebles].SetPrecioVenta(Convert.ToSingle(mueblesPartidos[4]));
                                ((MesasOrdenador)m[contadorMuebles]).SetAlto(Convert.ToSingle(mueblesPartidos[5]));
                                ((MesasOrdenador)m[contadorMuebles]).SetAncho(Convert.ToSingle(mueblesPartidos[6]));
                                ((MesasOrdenador)m[contadorMuebles]).SetLargo(Convert.ToSingle(mueblesPartidos[7]));
                                ((MesasOrdenador)m[contadorMuebles]).SetNumeroCajones(Convert.ToUInt16(mueblesPartidos[8]));
                                ((MesasOrdenador)m[contadorMuebles]).SetRuedas(Convert.ToBoolean(mueblesPartidos[9]));
                                ((MesasOrdenador)m[contadorMuebles]).SetLargoBandejaTeclado(Convert.ToSingle(mueblesPartidos[10]));
                                ((MesasOrdenador)m[contadorMuebles]).SetAnchoBandejaTeclado(Convert.ToSingle(mueblesPartidos[11]));

                                contadorMuebles++;
                            }
                            else if(mueblesPartidos[0] == "GestionDeMuebles.SillasOficina")
                            {
                                m[contadorMuebles] = new SillasOficina();

                                m[contadorMuebles].SetMaterial(mueblesPartidos[1]);
                                m[contadorMuebles].SetColor(mueblesPartidos[2]);
                                m[contadorMuebles].SetFechaFabricacion(mueblesPartidos[3]);
                                m[contadorMuebles].SetPrecioVenta(Convert.ToSingle(mueblesPartidos[4]));
                                ((SillasOficina)m[contadorMuebles]).SetAntebrazos(Convert.ToBoolean(mueblesPartidos[5]));
                                ((SillasOficina)m[contadorMuebles]).SetMaterialPata(mueblesPartidos[6]);
                                ((SillasOficina)m[contadorMuebles]).SetNumeroRuedas(Convert.ToUInt16(mueblesPartidos[7]));

                                contadorMuebles++;
                            }
                            else if(mueblesPartidos[0] == "GestionDeMuebles.SillasComedor")
                            {
                                m[contadorMuebles] = new SillasComedor();

                                m[contadorMuebles].SetMaterial(mueblesPartidos[1]);
                                m[contadorMuebles].SetColor(mueblesPartidos[2]);
                                m[contadorMuebles].SetFechaFabricacion(mueblesPartidos[3]);
                                m[contadorMuebles].SetPrecioVenta(Convert.ToSingle(mueblesPartidos[4]));
                                ((SillasComedor)m[contadorMuebles]).SetAntebrazos(Convert.ToBoolean(mueblesPartidos[5]));
                                ((SillasComedor)m[contadorMuebles]).SetMaterialAsiento(mueblesPartidos[6]);
                                ((SillasComedor)m[contadorMuebles]).SetMaterialRespaldo(mueblesPartidos[7]);
                                ((SillasComedor)m[contadorMuebles]).SetFormaPatas(mueblesPartidos[8]);

                                contadorMuebles++;
                            }//fin if else para identificar datos y meter en array
                        }//fin if linea != null
                    }
                    while (linea != null);

                    ficheroLectura.Close();//Cerramos el fichero
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ha habido un error al cargar los datos del fichero en el array de muebles");
                    Console.WriteLine(e.Message);
                }
            }//Fin del if de File.Exists
        } //Fin metodo CargarDatosFichero

        public void Trabaja(Usuarios nick)
        {
            if (Convert.ToString(nick.GetType()) == "GestionDeMuebles.Operarios")
            {
                Operarios o = new Operarios();
                o.Fabrica();
            }
            else if (Convert.ToString(nick.GetType()) == "GestionDeMuebles.Vendedores")
            {
                Vendedores v = new Vendedores();
                v.Vende();
            }
        }
    }
}
