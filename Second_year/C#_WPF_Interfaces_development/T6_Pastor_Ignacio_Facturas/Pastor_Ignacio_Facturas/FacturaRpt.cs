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
    /// Formulario que contiene el reportViewer donde se muestra el local report.
    /// </summary>
    public partial class FacturaRpt : Form
    {
        public FacturaRpt()
        {
            InitializeComponent();
        }
        public List<Factura> Invoice = new List<Factura>();
        public List<Articulo> Detail = new List<Articulo>();

        public void FacturaRpt_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Encabezado", Invoice));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Detalle", Detail));

            reportViewer1.RefreshReport();
        }
    }
}
