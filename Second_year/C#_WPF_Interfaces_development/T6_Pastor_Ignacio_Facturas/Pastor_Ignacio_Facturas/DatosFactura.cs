using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pastor_Ignacio_Facturas
{
    /// <summary>
    /// Formulario principal de la aplicación. Aquí se recogerán los datos de los productos facturados
    /// y los datos de la empresa a la que se realiza la factura
    /// </summary>
    public partial class frmDatosFactura : Form
    {
        public frmDatosFactura()
        {
            InitializeComponent();
        }

        private void dgDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void DatosFactura_Load(object sender, EventArgs e)
        {
            dgDetalle.AutoGenerateColumns = false;

            dgDetalle.Columns["cFecha"].DataPropertyName = "Fecha";
            dgDetalle.Columns["cCantidad"].DataPropertyName = "Cantidad";
            dgDetalle.Columns["cDescripcion"].DataPropertyName = "Descripcion";
            dgDetalle.Columns["cImpBruto"].DataPropertyName = "ImpBruto";
            dgDetalle.Columns["cImporte"].DataPropertyName = "Importe";
        }
        /// <summary>
        /// Gestiona la lectura de datos del formulario y los envía al report para imprimir
        /// </summary>
        private void InvoiceGenerate()
        {
            //Instanciamos una factura y le asignamos la información recogida
            Factura invoice = new Pastor_Ignacio_Facturas.Factura();

            invoice.Nombre = tbNombre.Text;
            invoice.Direccion = tbDireccion.Text;
            invoice.Localidad = tbLocalidad.Text;
            invoice.Nif = tbNif.Text;
            invoice.Fecha = dpFechaFactura.Value.Date;
            invoice.NumeroFactura = GenerateNumber();

            //Por cada artículo, lo instanciamos y lo añadimos a la lista de artículos de la factura
            foreach (DataGridViewRow row in dgDetalle.Rows)
            {
                Articulo articulo = new Articulo();
                
                articulo.Fecha = Convert.ToDateTime(row.Cells["cFecha"].Value);
                articulo.Cantidad = Convert.ToSingle(row.Cells["cCantidad"].Value);
                articulo.Descripcion = Convert.ToString(row.Cells["cDescripcion"].Value);
                articulo.ImpBruto = Convert.ToSingle(row.Cells["cImpBruto"].Value);
                articulo.Importe = Convert.ToSingle(row.Cells["cImporte"].Value);

                if(articulo.ImpBruto != 0 && articulo.Importe != 0 && articulo.Cantidad != 0 && articulo.Descripcion != null)
                    invoice.ListaArticulosEnFactura.Add(articulo);
            }

            FacturaRpt facturaReport = new FacturaRpt();

            facturaReport.Invoice.Add(invoice);
            facturaReport.Detail = invoice.ListaArticulosEnFactura;
            facturaReport.Show();
            
        }
        private int GenerateNumber()
        {
            Random r = new Random();

            return r.Next(1000, 100000);
        }
        /// <summary>
        /// Lanza el tratamiento de los datos cuando se pulsa el botón imprimir.
        /// Se controlan aquí los errores meramente para mantener la integridad del programa.
        /// Siendo el objeto de la práctica la gestión de la impresión y por falta de tiempo, no le he dedicado más tiempo
        /// a hacer validaciones de los campos ni informes detallados de los errores.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                InvoiceGenerate();
            }
            catch(Exception error)
            {
                MessageBox.Show("Se ha producido un error en el tratamiento de los datos introducidos."
                        + " Por favor, revisa su formato.\nError: " + error.Message);
            }
            
        }
    }
}
