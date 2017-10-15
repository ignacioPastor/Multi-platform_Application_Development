namespace Pastor_Ignacio_Facturas
{
    partial class frmDatosFactura
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbDatosCliente = new System.Windows.Forms.GroupBox();
            this.bImprimir = new System.Windows.Forms.Button();
            this.tbDireccion = new System.Windows.Forms.TextBox();
            this.tbLocalidad = new System.Windows.Forms.TextBox();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.dpFechaFactura = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbDetalleFactura = new System.Windows.Forms.GroupBox();
            this.dgDetalle = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.tbNif = new System.Windows.Forms.TextBox();
            this.cFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cImpBruto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbDatosCliente.SuspendLayout();
            this.gbDetalleFactura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDatosCliente
            // 
            this.gbDatosCliente.Controls.Add(this.tbNif);
            this.gbDatosCliente.Controls.Add(this.label5);
            this.gbDatosCliente.Controls.Add(this.bImprimir);
            this.gbDatosCliente.Controls.Add(this.tbDireccion);
            this.gbDatosCliente.Controls.Add(this.tbLocalidad);
            this.gbDatosCliente.Controls.Add(this.tbNombre);
            this.gbDatosCliente.Controls.Add(this.dpFechaFactura);
            this.gbDatosCliente.Controls.Add(this.label4);
            this.gbDatosCliente.Controls.Add(this.label3);
            this.gbDatosCliente.Controls.Add(this.label2);
            this.gbDatosCliente.Controls.Add(this.label1);
            this.gbDatosCliente.Location = new System.Drawing.Point(31, 33);
            this.gbDatosCliente.Name = "gbDatosCliente";
            this.gbDatosCliente.Size = new System.Drawing.Size(696, 175);
            this.gbDatosCliente.TabIndex = 0;
            this.gbDatosCliente.TabStop = false;
            this.gbDatosCliente.Text = "Datos Cliente";
            // 
            // bImprimir
            // 
            this.bImprimir.Location = new System.Drawing.Point(584, 69);
            this.bImprimir.Name = "bImprimir";
            this.bImprimir.Size = new System.Drawing.Size(94, 45);
            this.bImprimir.TabIndex = 8;
            this.bImprimir.Text = "Imprimir";
            this.bImprimir.UseVisualStyleBackColor = true;
            this.bImprimir.Click += new System.EventHandler(this.bImprimir_Click);
            // 
            // tbDireccion
            // 
            this.tbDireccion.Location = new System.Drawing.Point(87, 120);
            this.tbDireccion.Name = "tbDireccion";
            this.tbDireccion.Size = new System.Drawing.Size(416, 20);
            this.tbDireccion.TabIndex = 7;
            // 
            // tbLocalidad
            // 
            this.tbLocalidad.Location = new System.Drawing.Point(87, 62);
            this.tbLocalidad.Name = "tbLocalidad";
            this.tbLocalidad.Size = new System.Drawing.Size(308, 20);
            this.tbLocalidad.TabIndex = 6;
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(87, 30);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(308, 20);
            this.tbNombre.TabIndex = 5;
            // 
            // dpFechaFactura
            // 
            this.dpFechaFactura.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFechaFactura.Location = new System.Drawing.Point(549, 30);
            this.dpFechaFactura.Name = "dpFechaFactura";
            this.dpFechaFactura.Size = new System.Drawing.Size(129, 20);
            this.dpFechaFactura.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(496, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fecha";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Dirección";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Localidad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // gbDetalleFactura
            // 
            this.gbDetalleFactura.Controls.Add(this.dgDetalle);
            this.gbDetalleFactura.Location = new System.Drawing.Point(31, 214);
            this.gbDetalleFactura.Name = "gbDetalleFactura";
            this.gbDetalleFactura.Size = new System.Drawing.Size(696, 175);
            this.gbDetalleFactura.TabIndex = 1;
            this.gbDetalleFactura.TabStop = false;
            this.gbDetalleFactura.Text = "Detalle Factura";
            // 
            // dgDetalle
            // 
            this.dgDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cFecha,
            this.cCantidad,
            this.cDescripcion,
            this.cImpBruto,
            this.cImporte});
            this.dgDetalle.Location = new System.Drawing.Point(24, 19);
            this.dgDetalle.Name = "dgDetalle";
            this.dgDetalle.Size = new System.Drawing.Size(654, 142);
            this.dgDetalle.TabIndex = 0;
            this.dgDetalle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDetalle_CellContentClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "NIF";
            // 
            // tbNif
            // 
            this.tbNif.Location = new System.Drawing.Point(87, 93);
            this.tbNif.Name = "tbNif";
            this.tbNif.Size = new System.Drawing.Size(182, 20);
            this.tbNif.TabIndex = 10;
            // 
            // cFecha
            // 
            this.cFecha.HeaderText = "Fecha";
            this.cFecha.Name = "cFecha";
            this.cFecha.Width = 90;
            // 
            // cCantidad
            // 
            this.cCantidad.HeaderText = "Cantidad";
            this.cCantidad.Name = "cCantidad";
            this.cCantidad.Width = 80;
            // 
            // cDescripcion
            // 
            this.cDescripcion.HeaderText = "Descripción";
            this.cDescripcion.Name = "cDescripcion";
            this.cDescripcion.Width = 281;
            // 
            // cImpBruto
            // 
            this.cImpBruto.HeaderText = "Imp. Bruto";
            this.cImpBruto.Name = "cImpBruto";
            this.cImpBruto.Width = 80;
            // 
            // cImporte
            // 
            this.cImporte.HeaderText = "Importe";
            this.cImporte.Name = "cImporte";
            this.cImporte.Width = 80;
            // 
            // frmDatosFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 401);
            this.Controls.Add(this.gbDetalleFactura);
            this.Controls.Add(this.gbDatosCliente);
            this.Name = "frmDatosFactura";
            this.Text = "Factura";
            this.Load += new System.EventHandler(this.DatosFactura_Load);
            this.gbDatosCliente.ResumeLayout(false);
            this.gbDatosCliente.PerformLayout();
            this.gbDetalleFactura.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDetalle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatosCliente;
        private System.Windows.Forms.Button bImprimir;
        private System.Windows.Forms.TextBox tbDireccion;
        private System.Windows.Forms.TextBox tbLocalidad;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.DateTimePicker dpFechaFactura;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbDetalleFactura;
        private System.Windows.Forms.DataGridView dgDetalle;
        private System.Windows.Forms.TextBox tbNif;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cImpBruto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cImporte;
    }
}

