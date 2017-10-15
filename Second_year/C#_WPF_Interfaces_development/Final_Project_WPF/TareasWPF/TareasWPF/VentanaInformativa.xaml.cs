using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
/// <summary>
/// Tareas WPF
/// <author>Ignacio Pastor Padilla</author>
/// Proyecto final - Segundo Trimestre - Desarrollo de Interfaces
/// Fecha 19/02/2017
/// </summary>
namespace TareasWPF
{
    /// <summary>
    /// Lógica de interacción para VentanaInformativa.xaml
    /// </summary>
    public partial class VentanaInformativa : Window
    {
        bool bigMode;
        public VentanaInformativa()
        {
            InitializeComponent();
        }
        public VentanaInformativa(string message)
        {
            InitializeComponent();
            tbMessage.Text = message;
        }
        public VentanaInformativa(string message, bool bigMode)
        {
            InitializeComponent();
            tbMessage.Text = message;
            this.bigMode = bigMode;
        }

        private void bAceptar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Width = 350;
            this.Height = 300;
            bAceptar.Margin = new Thickness(250, 230, 0, 0);
        }
    }
}
