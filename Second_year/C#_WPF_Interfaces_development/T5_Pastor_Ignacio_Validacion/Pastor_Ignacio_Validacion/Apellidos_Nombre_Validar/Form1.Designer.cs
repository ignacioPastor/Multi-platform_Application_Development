namespace Apellidos_Nombre_Validar
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblInfoCamposObligatorios = new System.Windows.Forms.Label();
            this.gBoxDatosUsuario = new System.Windows.Forms.GroupBox();
            this.mtbTarjeta = new System.Windows.Forms.MaskedTextBox();
            this.tbConfirmarPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmarPassword = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbNick = new System.Windows.Forms.TextBox();
            this.lblNick = new System.Windows.Forms.Label();
            this.lblEquipo = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.gBoxDatosPersonales = new System.Windows.Forms.GroupBox();
            this.cbNacionalidad = new System.Windows.Forms.ComboBox();
            this.rbGeneroFemenino = new System.Windows.Forms.RadioButton();
            this.rbGeneroMasculino = new System.Windows.Forms.RadioButton();
            this.cbAnyoNacimiento = new System.Windows.Forms.ComboBox();
            this.cbMesNacimiento = new System.Windows.Forms.ComboBox();
            this.cbDiaNacimiento = new System.Windows.Forms.ComboBox();
            this.tbTelefono = new System.Windows.Forms.TextBox();
            this.tbCorreo = new System.Windows.Forms.TextBox();
            this.tbApellidos = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblNacionalidad = new System.Windows.Forms.Label();
            this.lblApellidos = new System.Windows.Forms.Label();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.lblGenero = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbConformidad = new System.Windows.Forms.CheckBox();
            this.tbCuenta = new System.Windows.Forms.TextBox();
            this.tbDC = new System.Windows.Forms.TextBox();
            this.tbOficina = new System.Windows.Forms.TextBox();
            this.tbEntidad = new System.Windows.Forms.TextBox();
            this.tbNif = new System.Windows.Forms.TextBox();
            this.tbTitular = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbIban = new System.Windows.Forms.TextBox();
            this.lbConformidad = new System.Windows.Forms.Label();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.errorProviderFecha = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gBoxDatosUsuario.SuspendLayout();
            this.gBoxDatosPersonales.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderFecha)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(9, 8);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(369, 448);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblInfoCamposObligatorios);
            this.tabPage1.Controls.Add(this.gBoxDatosUsuario);
            this.tabPage1.Controls.Add(this.gBoxDatosPersonales);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(361, 422);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Datos personales";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblInfoCamposObligatorios
            // 
            this.lblInfoCamposObligatorios.AutoSize = true;
            this.lblInfoCamposObligatorios.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoCamposObligatorios.Location = new System.Drawing.Point(11, 398);
            this.lblInfoCamposObligatorios.Name = "lblInfoCamposObligatorios";
            this.lblInfoCamposObligatorios.Size = new System.Drawing.Size(259, 13);
            this.lblInfoCamposObligatorios.TabIndex = 35;
            this.lblInfoCamposObligatorios.Text = "*Los campos marcados con asterisco son obligatorios";
            // 
            // gBoxDatosUsuario
            // 
            this.gBoxDatosUsuario.Controls.Add(this.mtbTarjeta);
            this.gBoxDatosUsuario.Controls.Add(this.tbConfirmarPassword);
            this.gBoxDatosUsuario.Controls.Add(this.lblConfirmarPassword);
            this.gBoxDatosUsuario.Controls.Add(this.tbPassword);
            this.gBoxDatosUsuario.Controls.Add(this.tbNick);
            this.gBoxDatosUsuario.Controls.Add(this.lblNick);
            this.gBoxDatosUsuario.Controls.Add(this.lblEquipo);
            this.gBoxDatosUsuario.Controls.Add(this.lblPassword);
            this.gBoxDatosUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxDatosUsuario.Location = new System.Drawing.Point(5, 236);
            this.gBoxDatosUsuario.Name = "gBoxDatosUsuario";
            this.gBoxDatosUsuario.Size = new System.Drawing.Size(352, 159);
            this.gBoxDatosUsuario.TabIndex = 32;
            this.gBoxDatosUsuario.TabStop = false;
            this.gBoxDatosUsuario.Text = "Datos de Banca Online";
            // 
            // mtbTarjeta
            // 
            this.mtbTarjeta.BeepOnError = true;
            this.mtbTarjeta.Location = new System.Drawing.Point(137, 114);
            this.mtbTarjeta.Margin = new System.Windows.Forms.Padding(2);
            this.mtbTarjeta.Mask = ">LL00000LLL??";
            this.mtbTarjeta.Name = "mtbTarjeta";
            this.mtbTarjeta.PromptChar = '-';
            this.mtbTarjeta.Size = new System.Drawing.Size(200, 20);
            this.mtbTarjeta.TabIndex = 17;
            this.mtbTarjeta.Leave += new System.EventHandler(this.mtbTarjeta_Leave);
            // 
            // tbConfirmarPassword
            // 
            this.tbConfirmarPassword.Location = new System.Drawing.Point(137, 91);
            this.tbConfirmarPassword.Name = "tbConfirmarPassword";
            this.tbConfirmarPassword.Size = new System.Drawing.Size(200, 20);
            this.tbConfirmarPassword.TabIndex = 13;
            this.tbConfirmarPassword.Leave += new System.EventHandler(this.tbConfirmarPassword_Leave);
            // 
            // lblConfirmarPassword
            // 
            this.lblConfirmarPassword.AutoSize = true;
            this.lblConfirmarPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblConfirmarPassword.Location = new System.Drawing.Point(6, 93);
            this.lblConfirmarPassword.Name = "lblConfirmarPassword";
            this.lblConfirmarPassword.Size = new System.Drawing.Size(111, 13);
            this.lblConfirmarPassword.TabIndex = 16;
            this.lblConfirmarPassword.Text = "*Confirmar contraseña";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(137, 65);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(200, 20);
            this.tbPassword.TabIndex = 12;
            this.tbPassword.Leave += new System.EventHandler(this.tbPassword_Leave);
            // 
            // tbNick
            // 
            this.tbNick.Location = new System.Drawing.Point(137, 39);
            this.tbNick.Name = "tbNick";
            this.tbNick.Size = new System.Drawing.Size(200, 20);
            this.tbNick.TabIndex = 11;
            this.tbNick.Leave += new System.EventHandler(this.tbNick_Leave);
            // 
            // lblNick
            // 
            this.lblNick.AutoSize = true;
            this.lblNick.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblNick.Location = new System.Drawing.Point(6, 41);
            this.lblNick.Name = "lblNick";
            this.lblNick.Size = new System.Drawing.Size(33, 13);
            this.lblNick.TabIndex = 9;
            this.lblNick.Text = "*Nick";
            // 
            // lblEquipo
            // 
            this.lblEquipo.AutoSize = true;
            this.lblEquipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblEquipo.Location = new System.Drawing.Point(6, 119);
            this.lblEquipo.Name = "lblEquipo";
            this.lblEquipo.Size = new System.Drawing.Size(107, 13);
            this.lblEquipo.TabIndex = 7;
            this.lblEquipo.Text = "Número tarjeta online";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblPassword.Location = new System.Drawing.Point(6, 67);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(65, 13);
            this.lblPassword.TabIndex = 8;
            this.lblPassword.Text = "*Contraseña";
            // 
            // gBoxDatosPersonales
            // 
            this.gBoxDatosPersonales.Controls.Add(this.cbNacionalidad);
            this.gBoxDatosPersonales.Controls.Add(this.rbGeneroFemenino);
            this.gBoxDatosPersonales.Controls.Add(this.rbGeneroMasculino);
            this.gBoxDatosPersonales.Controls.Add(this.cbAnyoNacimiento);
            this.gBoxDatosPersonales.Controls.Add(this.cbMesNacimiento);
            this.gBoxDatosPersonales.Controls.Add(this.cbDiaNacimiento);
            this.gBoxDatosPersonales.Controls.Add(this.tbTelefono);
            this.gBoxDatosPersonales.Controls.Add(this.tbCorreo);
            this.gBoxDatosPersonales.Controls.Add(this.tbApellidos);
            this.gBoxDatosPersonales.Controls.Add(this.lblTelefono);
            this.gBoxDatosPersonales.Controls.Add(this.lblNacionalidad);
            this.gBoxDatosPersonales.Controls.Add(this.lblApellidos);
            this.gBoxDatosPersonales.Controls.Add(this.lblFechaNacimiento);
            this.gBoxDatosPersonales.Controls.Add(this.lblGenero);
            this.gBoxDatosPersonales.Controls.Add(this.lblNombre);
            this.gBoxDatosPersonales.Controls.Add(this.lblCorreo);
            this.gBoxDatosPersonales.Controls.Add(this.tbNombre);
            this.gBoxDatosPersonales.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxDatosPersonales.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gBoxDatosPersonales.Location = new System.Drawing.Point(5, 5);
            this.gBoxDatosPersonales.Name = "gBoxDatosPersonales";
            this.gBoxDatosPersonales.Size = new System.Drawing.Size(352, 224);
            this.gBoxDatosPersonales.TabIndex = 31;
            this.gBoxDatosPersonales.TabStop = false;
            this.gBoxDatosPersonales.Text = "Datos personales";
            // 
            // cbNacionalidad
            // 
            this.cbNacionalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNacionalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cbNacionalidad.FormattingEnabled = true;
            this.cbNacionalidad.Items.AddRange(new object[] {
            "España",
            "Unión Europea",
            "Otros"});
            this.cbNacionalidad.Location = new System.Drawing.Point(137, 134);
            this.cbNacionalidad.Name = "cbNacionalidad";
            this.cbNacionalidad.Size = new System.Drawing.Size(200, 21);
            this.cbNacionalidad.TabIndex = 8;
            this.cbNacionalidad.SelectedIndexChanged += new System.EventHandler(this.cbNacionalidad_Change);
            // 
            // rbGeneroFemenino
            // 
            this.rbGeneroFemenino.AutoSize = true;
            this.rbGeneroFemenino.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbGeneroFemenino.Location = new System.Drawing.Point(216, 110);
            this.rbGeneroFemenino.Name = "rbGeneroFemenino";
            this.rbGeneroFemenino.Size = new System.Drawing.Size(71, 17);
            this.rbGeneroFemenino.TabIndex = 7;
            this.rbGeneroFemenino.TabStop = true;
            this.rbGeneroFemenino.Text = "Femenino";
            this.rbGeneroFemenino.UseVisualStyleBackColor = true;
            // 
            // rbGeneroMasculino
            // 
            this.rbGeneroMasculino.AutoSize = true;
            this.rbGeneroMasculino.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbGeneroMasculino.Location = new System.Drawing.Point(137, 110);
            this.rbGeneroMasculino.Name = "rbGeneroMasculino";
            this.rbGeneroMasculino.Size = new System.Drawing.Size(73, 17);
            this.rbGeneroMasculino.TabIndex = 6;
            this.rbGeneroMasculino.TabStop = true;
            this.rbGeneroMasculino.Text = "Masculino";
            this.rbGeneroMasculino.UseVisualStyleBackColor = true;
            // 
            // cbAnyoNacimiento
            // 
            this.cbAnyoNacimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAnyoNacimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cbAnyoNacimiento.FormattingEnabled = true;
            this.cbAnyoNacimiento.Items.AddRange(new object[] {
            "1925",
            "1926",
            "1927",
            "1928",
            "1929",
            "1930",
            "1931",
            "1932",
            "1933",
            "1934",
            "1935",
            "1936",
            "1937",
            "1938",
            "1939",
            "1940",
            "1941",
            "1942",
            "1943",
            "1944",
            "1945",
            "1946",
            "1947",
            "1948",
            "1949",
            "1950",
            "1951",
            "1952",
            "1953",
            "1954",
            "1955",
            "1956",
            "1957",
            "1958",
            "1959",
            "1960",
            "1961",
            "1962",
            "1963",
            "1964",
            "1965",
            "1966",
            "1967",
            "1968",
            "1969",
            "1970",
            "1971",
            "1972",
            "1973",
            "1974",
            "1975",
            "1976",
            "1977",
            "1978",
            "1979",
            "1980",
            "1981",
            "1982",
            "1983",
            "1984",
            "1985",
            "1986",
            "1987",
            "1988",
            "1989",
            "1990",
            "1991",
            "1992",
            "1993",
            "1994",
            "1995",
            "1996",
            "1997",
            "1998",
            "1999",
            "2000",
            "2001",
            "2002",
            "2003",
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016"});
            this.cbAnyoNacimiento.Location = new System.Drawing.Point(271, 84);
            this.cbAnyoNacimiento.Name = "cbAnyoNacimiento";
            this.cbAnyoNacimiento.Size = new System.Drawing.Size(66, 21);
            this.cbAnyoNacimiento.TabIndex = 5;
            this.cbAnyoNacimiento.SelectedIndexChanged += new System.EventHandler(this.cbAnyoNacimiento_Change);
            // 
            // cbMesNacimiento
            // 
            this.cbMesNacimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMesNacimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cbMesNacimiento.FormattingEnabled = true;
            this.cbMesNacimiento.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.cbMesNacimiento.Location = new System.Drawing.Point(192, 84);
            this.cbMesNacimiento.Name = "cbMesNacimiento";
            this.cbMesNacimiento.Size = new System.Drawing.Size(73, 21);
            this.cbMesNacimiento.TabIndex = 4;
            this.cbMesNacimiento.SelectedIndexChanged += new System.EventHandler(this.cbMesNacimiento_Change);
            // 
            // cbDiaNacimiento
            // 
            this.cbDiaNacimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDiaNacimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cbDiaNacimiento.FormattingEnabled = true;
            this.cbDiaNacimiento.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.cbDiaNacimiento.Location = new System.Drawing.Point(137, 84);
            this.cbDiaNacimiento.Name = "cbDiaNacimiento";
            this.cbDiaNacimiento.Size = new System.Drawing.Size(49, 21);
            this.cbDiaNacimiento.TabIndex = 3;
            this.cbDiaNacimiento.SelectedIndexChanged += new System.EventHandler(this.cbDiaNacimiento_Change);
            // 
            // tbTelefono
            // 
            this.tbTelefono.Location = new System.Drawing.Point(137, 188);
            this.tbTelefono.Name = "tbTelefono";
            this.tbTelefono.Size = new System.Drawing.Size(100, 20);
            this.tbTelefono.TabIndex = 10;
            this.tbTelefono.Leave += new System.EventHandler(this.tbTelefono_Leave);
            // 
            // tbCorreo
            // 
            this.tbCorreo.Location = new System.Drawing.Point(137, 161);
            this.tbCorreo.Name = "tbCorreo";
            this.tbCorreo.Size = new System.Drawing.Size(200, 20);
            this.tbCorreo.TabIndex = 9;
            this.tbCorreo.Leave += new System.EventHandler(this.tbCorreo_Leave);
            // 
            // tbApellidos
            // 
            this.tbApellidos.Location = new System.Drawing.Point(137, 57);
            this.tbApellidos.Name = "tbApellidos";
            this.tbApellidos.Size = new System.Drawing.Size(200, 20);
            this.tbApellidos.TabIndex = 2;
            this.tbApellidos.Leave += new System.EventHandler(this.tbApellidos_Leave);
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblTelefono.Location = new System.Drawing.Point(6, 190);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(49, 13);
            this.lblTelefono.TabIndex = 10;
            this.lblTelefono.Text = "Teléfono";
            // 
            // lblNacionalidad
            // 
            this.lblNacionalidad.AutoSize = true;
            this.lblNacionalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblNacionalidad.Location = new System.Drawing.Point(6, 136);
            this.lblNacionalidad.Name = "lblNacionalidad";
            this.lblNacionalidad.Size = new System.Drawing.Size(73, 13);
            this.lblNacionalidad.TabIndex = 4;
            this.lblNacionalidad.Text = "*Nacionalidad";
            // 
            // lblApellidos
            // 
            this.lblApellidos.AutoSize = true;
            this.lblApellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblApellidos.Location = new System.Drawing.Point(6, 59);
            this.lblApellidos.Name = "lblApellidos";
            this.lblApellidos.Size = new System.Drawing.Size(49, 13);
            this.lblApellidos.TabIndex = 3;
            this.lblApellidos.Text = "Apellidos";
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblFechaNacimiento.Location = new System.Drawing.Point(6, 86);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(91, 13);
            this.lblFechaNacimiento.TabIndex = 2;
            this.lblFechaNacimiento.Text = "Fecha nacimiento";
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblGenero.Location = new System.Drawing.Point(6, 110);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(42, 13);
            this.lblGenero.TabIndex = 1;
            this.lblGenero.Text = "Género";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblNombre.Location = new System.Drawing.Point(6, 32);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(48, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "*Nombre";
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblCorreo.Location = new System.Drawing.Point(6, 163);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(97, 13);
            this.lblCorreo.TabIndex = 5;
            this.lblCorreo.Text = "*Correo electrónico";
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(137, 30);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(200, 20);
            this.tbNombre.TabIndex = 1;
            this.tbNombre.Leave += new System.EventHandler(this.tbNombre_Leave);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(361, 422);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Datos bancarios";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbConformidad);
            this.groupBox1.Controls.Add(this.tbCuenta);
            this.groupBox1.Controls.Add(this.tbDC);
            this.groupBox1.Controls.Add(this.tbOficina);
            this.groupBox1.Controls.Add(this.tbEntidad);
            this.groupBox1.Controls.Add(this.tbNif);
            this.groupBox1.Controls.Add(this.tbTitular);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbIban);
            this.groupBox1.Controls.Add(this.lbConformidad);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 157);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos bancarios";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(208, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Oficina";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label8.Location = new System.Drawing.Point(171, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Entidad";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label5.Location = new System.Drawing.Point(245, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "DC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label2.Location = new System.Drawing.Point(269, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Cuenta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(135, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "IBAN";
            // 
            // cbConformidad
            // 
            this.cbConformidad.AutoSize = true;
            this.cbConformidad.Location = new System.Drawing.Point(321, 118);
            this.cbConformidad.Margin = new System.Windows.Forms.Padding(2);
            this.cbConformidad.Name = "cbConformidad";
            this.cbConformidad.Size = new System.Drawing.Size(15, 14);
            this.cbConformidad.TabIndex = 16;
            this.cbConformidad.UseVisualStyleBackColor = true;
            this.cbConformidad.CheckedChanged += new System.EventHandler(this.cbConformidad_Change);
            // 
            // tbCuenta
            // 
            this.tbCuenta.Location = new System.Drawing.Point(271, 30);
            this.tbCuenta.Name = "tbCuenta";
            this.tbCuenta.Size = new System.Drawing.Size(66, 20);
            this.tbCuenta.TabIndex = 14;
            this.tbCuenta.Leave += new System.EventHandler(this.tbCuenta_Leave);
            // 
            // tbDC
            // 
            this.tbDC.Location = new System.Drawing.Point(247, 30);
            this.tbDC.Name = "tbDC";
            this.tbDC.Size = new System.Drawing.Size(20, 20);
            this.tbDC.TabIndex = 13;
            this.tbDC.Leave += new System.EventHandler(this.tbDC_Leave);
            // 
            // tbOficina
            // 
            this.tbOficina.Location = new System.Drawing.Point(210, 30);
            this.tbOficina.Name = "tbOficina";
            this.tbOficina.Size = new System.Drawing.Size(33, 20);
            this.tbOficina.TabIndex = 12;
            this.tbOficina.Leave += new System.EventHandler(this.tbOficina_Leave);
            // 
            // tbEntidad
            // 
            this.tbEntidad.Location = new System.Drawing.Point(173, 30);
            this.tbEntidad.Name = "tbEntidad";
            this.tbEntidad.Size = new System.Drawing.Size(33, 20);
            this.tbEntidad.TabIndex = 11;
            this.tbEntidad.Leave += new System.EventHandler(this.tbEntidad_Leave);
            // 
            // tbNif
            // 
            this.tbNif.Location = new System.Drawing.Point(137, 84);
            this.tbNif.Name = "tbNif";
            this.tbNif.Size = new System.Drawing.Size(200, 20);
            this.tbNif.TabIndex = 9;
            this.tbNif.Leave += new System.EventHandler(this.tbNif_Leave);
            // 
            // tbTitular
            // 
            this.tbTitular.Location = new System.Drawing.Point(137, 57);
            this.tbTitular.Name = "tbTitular";
            this.tbTitular.Size = new System.Drawing.Size(200, 20);
            this.tbTitular.TabIndex = 2;
            this.tbTitular.Leave += new System.EventHandler(this.tbTitular_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.Location = new System.Drawing.Point(6, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "*Titular";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.Location = new System.Drawing.Point(6, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "*NIF";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.Location = new System.Drawing.Point(6, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "*IBAN";
            // 
            // tbIban
            // 
            this.tbIban.Location = new System.Drawing.Point(137, 30);
            this.tbIban.Name = "tbIban";
            this.tbIban.Size = new System.Drawing.Size(33, 20);
            this.tbIban.TabIndex = 1;
            this.tbIban.Leave += new System.EventHandler(this.tbIban_Leave);
            // 
            // lbConformidad
            // 
            this.lbConformidad.Location = new System.Drawing.Point(6, 118);
            this.lbConformidad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbConformidad.Name = "lbConformidad";
            this.lbConformidad.Size = new System.Drawing.Size(305, 39);
            this.lbConformidad.TabIndex = 17;
            this.lbConformidad.Text = "El cliente mustra su conformidad aceptando los términos de este contrato";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(261, 460);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(107, 23);
            this.btnRegistrar.TabIndex = 35;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            this.btnRegistrar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnRegistrar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(125, 460);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(107, 23);
            this.btnCancelar.TabIndex = 36;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // errorProviderFecha
            // 
            this.errorProviderFecha.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 482);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Registro";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.gBoxDatosUsuario.ResumeLayout(false);
            this.gBoxDatosUsuario.PerformLayout();
            this.gBoxDatosPersonales.ResumeLayout(false);
            this.gBoxDatosPersonales.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderFecha)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        internal System.Windows.Forms.Label lblInfoCamposObligatorios;
        internal System.Windows.Forms.GroupBox gBoxDatosUsuario;
        internal System.Windows.Forms.TextBox tbConfirmarPassword;
        internal System.Windows.Forms.Label lblConfirmarPassword;
        internal System.Windows.Forms.TextBox tbPassword;
        internal System.Windows.Forms.TextBox tbNick;
        internal System.Windows.Forms.Label lblNick;
        internal System.Windows.Forms.Label lblEquipo;
        internal System.Windows.Forms.Label lblPassword;
        internal System.Windows.Forms.GroupBox gBoxDatosPersonales;
        internal System.Windows.Forms.ComboBox cbNacionalidad;
        internal System.Windows.Forms.RadioButton rbGeneroFemenino;
        internal System.Windows.Forms.RadioButton rbGeneroMasculino;
        internal System.Windows.Forms.ComboBox cbAnyoNacimiento;
        internal System.Windows.Forms.ComboBox cbMesNacimiento;
        internal System.Windows.Forms.ComboBox cbDiaNacimiento;
        internal System.Windows.Forms.TextBox tbTelefono;
        internal System.Windows.Forms.TextBox tbCorreo;
        internal System.Windows.Forms.TextBox tbApellidos;
        internal System.Windows.Forms.Label lblTelefono;
        internal System.Windows.Forms.Label lblNacionalidad;
        internal System.Windows.Forms.Label lblApellidos;
        internal System.Windows.Forms.Label lblFechaNacimiento;
        internal System.Windows.Forms.Label lblGenero;
        internal System.Windows.Forms.Label lblNombre;
        internal System.Windows.Forms.Label lblCorreo;
        internal System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.TabPage tabPage2;
        internal System.Windows.Forms.Button btnRegistrar;
        internal System.Windows.Forms.Button btnCancelar;
        internal System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbConformidad;
        internal System.Windows.Forms.TextBox tbCuenta;
        internal System.Windows.Forms.TextBox tbDC;
        internal System.Windows.Forms.TextBox tbOficina;
        internal System.Windows.Forms.TextBox tbEntidad;
        internal System.Windows.Forms.TextBox tbNif;
        internal System.Windows.Forms.TextBox tbTitular;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox tbIban;
        private System.Windows.Forms.Label lbConformidad;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mtbTarjeta;
        private System.Windows.Forms.ErrorProvider errorProviderFecha;
    }
}

