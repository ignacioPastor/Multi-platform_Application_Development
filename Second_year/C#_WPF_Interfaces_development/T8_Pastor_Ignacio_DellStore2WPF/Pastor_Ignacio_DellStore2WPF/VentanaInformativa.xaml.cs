﻿using System;
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

namespace Pastor_Ignacio_DellStore2WPF
{
    /// <summary>
    /// Lógica de interacción para VentanaInformativa.xaml
    /// </summary>
    public partial class VentanaInformativa : Window
    {

        public VentanaInformativa()
        {
            InitializeComponent();
        }
        public VentanaInformativa(string message)
        {
            InitializeComponent();
            tbMessage.Text = message;
        }

        private void bAceptar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
