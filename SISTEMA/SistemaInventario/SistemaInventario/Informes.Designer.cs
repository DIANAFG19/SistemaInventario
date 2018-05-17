namespace SistemaInventario
{
    partial class Informes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Informes));
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnBuscarE = new System.Windows.Forms.Button();
            this.tbNumEmpleado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvEmpleado = new System.Windows.Forms.DataGridView();
            this.btnExportarEmpleado = new System.Windows.Forms.Button();
            this.dgvArticulos = new System.Windows.Forms.DataGridView();
            this.btnBuscarF = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnBuscarArea = new System.Windows.Forms.Button();
            this.btnExportar5 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbAreas = new System.Windows.Forms.ComboBox();
            this.dgvAreas = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.fecha2 = new System.Windows.Forms.DateTimePicker();
            this.btnExportarFechas = new System.Windows.Forms.Button();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.fecha = new System.Windows.Forms.DateTimePicker();
            this.dgvFechas = new System.Windows.Forms.DataGridView();
            this.btnExportarArticulos = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.pbCerrar = new System.Windows.Forms.PictureBox();
            this.lCerrarSesion = new System.Windows.Forms.Label();
            this.lRegresar = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbMinimizar = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAreas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFechas)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCerrar)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizar)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnBuscarE);
            this.tabPage1.Controls.Add(this.tbNumEmpleado);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.dgvEmpleado);
            this.tabPage1.Controls.Add(this.btnExportarEmpleado);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1329, 621);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Empleado";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnBuscarE
            // 
            this.btnBuscarE.BackColor = System.Drawing.Color.DimGray;
            this.btnBuscarE.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarE.ForeColor = System.Drawing.Color.White;
            this.btnBuscarE.Location = new System.Drawing.Point(611, 77);
            this.btnBuscarE.Name = "btnBuscarE";
            this.btnBuscarE.Size = new System.Drawing.Size(100, 45);
            this.btnBuscarE.TabIndex = 1;
            this.btnBuscarE.Text = "Buscar";
            this.btnBuscarE.UseVisualStyleBackColor = false;
            this.btnBuscarE.Click += new System.EventHandler(this.btnEBuscar_Click);
            // 
            // tbNumEmpleado
            // 
            this.tbNumEmpleado.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNumEmpleado.Location = new System.Drawing.Point(611, 33);
            this.tbNumEmpleado.MaxLength = 12;
            this.tbNumEmpleado.Name = "tbNumEmpleado";
            this.tbNumEmpleado.Size = new System.Drawing.Size(320, 27);
            this.tbNumEmpleado.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(444, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 19);
            this.label2.TabIndex = 140;
            this.label2.Text = "Número de Empleado";
            // 
            // dgvEmpleado
            // 
            this.dgvEmpleado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvEmpleado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvEmpleado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpleado.Location = new System.Drawing.Point(24, 128);
            this.dgvEmpleado.Name = "dgvEmpleado";
            this.dgvEmpleado.ReadOnly = true;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvEmpleado.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEmpleado.Size = new System.Drawing.Size(1282, 438);
            this.dgvEmpleado.TabIndex = 2;
            // 
            // btnExportarEmpleado
            // 
            this.btnExportarEmpleado.BackColor = System.Drawing.Color.DimGray;
            this.btnExportarEmpleado.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarEmpleado.ForeColor = System.Drawing.Color.White;
            this.btnExportarEmpleado.Location = new System.Drawing.Point(611, 572);
            this.btnExportarEmpleado.Name = "btnExportarEmpleado";
            this.btnExportarEmpleado.Size = new System.Drawing.Size(100, 43);
            this.btnExportarEmpleado.TabIndex = 0;
            this.btnExportarEmpleado.Text = "Exportar";
            this.btnExportarEmpleado.UseVisualStyleBackColor = false;
            this.btnExportarEmpleado.Click += new System.EventHandler(this.btnExportarEmpleado_Click);
            // 
            // dgvArticulos
            // 
            this.dgvArticulos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvArticulos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulos.Location = new System.Drawing.Point(6, 6);
            this.dgvArticulos.Name = "dgvArticulos";
            this.dgvArticulos.Size = new System.Drawing.Size(1317, 554);
            this.dgvArticulos.TabIndex = 1;
            // 
            // btnBuscarF
            // 
            this.btnBuscarF.BackColor = System.Drawing.Color.DimGray;
            this.btnBuscarF.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarF.ForeColor = System.Drawing.Color.White;
            this.btnBuscarF.Location = new System.Drawing.Point(611, 137);
            this.btnBuscarF.Name = "btnBuscarF";
            this.btnBuscarF.Size = new System.Drawing.Size(103, 43);
            this.btnBuscarF.TabIndex = 119;
            this.btnBuscarF.Text = "Buscar";
            this.btnBuscarF.UseVisualStyleBackColor = false;
            this.btnBuscarF.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(717, 97);
            this.textBox2.MaxLength = 10;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(177, 27);
            this.textBox2.TabIndex = 118;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(912, 97);
            this.textBox3.MaxLength = 10;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(177, 27);
            this.textBox3.TabIndex = 117;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(716, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 19);
            this.label6.TabIndex = 116;
            this.label6.Text = "Hasta";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnBuscarArea);
            this.tabPage4.Controls.Add(this.btnExportar5);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.cbAreas);
            this.tabPage4.Controls.Add(this.dgvAreas);
            this.tabPage4.Location = new System.Drawing.Point(4, 28);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1329, 621);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Área";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnBuscarArea
            // 
            this.btnBuscarArea.BackColor = System.Drawing.Color.DimGray;
            this.btnBuscarArea.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarArea.ForeColor = System.Drawing.Color.White;
            this.btnBuscarArea.Location = new System.Drawing.Point(606, 71);
            this.btnBuscarArea.Name = "btnBuscarArea";
            this.btnBuscarArea.Size = new System.Drawing.Size(103, 43);
            this.btnBuscarArea.TabIndex = 120;
            this.btnBuscarArea.Text = "Buscar";
            this.btnBuscarArea.UseVisualStyleBackColor = false;
            this.btnBuscarArea.Click += new System.EventHandler(this.btnBuscarArea_Click);
            // 
            // btnExportar5
            // 
            this.btnExportar5.BackColor = System.Drawing.Color.DimGray;
            this.btnExportar5.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar5.ForeColor = System.Drawing.Color.White;
            this.btnExportar5.Location = new System.Drawing.Point(606, 560);
            this.btnExportar5.Name = "btnExportar5";
            this.btnExportar5.Size = new System.Drawing.Size(103, 43);
            this.btnExportar5.TabIndex = 114;
            this.btnExportar5.Text = "Exportar";
            this.btnExportar5.UseVisualStyleBackColor = false;
            this.btnExportar5.Click += new System.EventHandler(this.btnExportar5_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(499, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 19);
            this.label7.TabIndex = 79;
            this.label7.Text = "Área";
            // 
            // cbAreas
            // 
            this.cbAreas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAreas.FormattingEnabled = true;
            this.cbAreas.Items.AddRange(new object[] {
            "",
            "Sistemas",
            "Ventas",
            "Administracion",
            "Publicidad",
            "Calidad",
            "R.H."});
            this.cbAreas.Location = new System.Drawing.Point(544, 33);
            this.cbAreas.Name = "cbAreas";
            this.cbAreas.Size = new System.Drawing.Size(291, 27);
            this.cbAreas.TabIndex = 0;
            // 
            // dgvAreas
            // 
            this.dgvAreas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAreas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAreas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAreas.Location = new System.Drawing.Point(21, 125);
            this.dgvAreas.Name = "dgvAreas";
            this.dgvAreas.Size = new System.Drawing.Size(1274, 424);
            this.dgvAreas.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(275, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 19);
            this.label5.TabIndex = 115;
            this.label5.Text = "De";
            // 
            // fecha2
            // 
            this.fecha2.Location = new System.Drawing.Point(769, 38);
            this.fecha2.Name = "fecha2";
            this.fecha2.Size = new System.Drawing.Size(307, 27);
            this.fecha2.TabIndex = 114;
            this.fecha2.Value = new System.DateTime(2018, 4, 12, 0, 0, 0, 0);
            this.fecha2.ValueChanged += new System.EventHandler(this.fecha2_ValueChanged);
            // 
            // btnExportarFechas
            // 
            this.btnExportarFechas.BackColor = System.Drawing.Color.DimGray;
            this.btnExportarFechas.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarFechas.ForeColor = System.Drawing.Color.White;
            this.btnExportarFechas.Location = new System.Drawing.Point(611, 566);
            this.btnExportarFechas.Name = "btnExportarFechas";
            this.btnExportarFechas.Size = new System.Drawing.Size(103, 43);
            this.btnExportarFechas.TabIndex = 113;
            this.btnExportarFechas.Text = "Exportar";
            this.btnExportarFechas.UseVisualStyleBackColor = false;
            this.btnExportarFechas.Click += new System.EventHandler(this.btnExportar4_Click);
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(433, 97);
            this.textBox15.MaxLength = 10;
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(177, 27);
            this.textBox15.TabIndex = 112;
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(250, 97);
            this.textBox14.MaxLength = 10;
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(177, 27);
            this.textBox14.TabIndex = 0;
            // 
            // fecha
            // 
            this.fecha.Location = new System.Drawing.Point(303, 38);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(307, 27);
            this.fecha.TabIndex = 110;
            this.fecha.Value = new System.DateTime(2018, 4, 12, 0, 0, 0, 0);
            this.fecha.ValueChanged += new System.EventHandler(this.fecha_ValueChanged);
            // 
            // dgvFechas
            // 
            this.dgvFechas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvFechas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvFechas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFechas.Location = new System.Drawing.Point(28, 186);
            this.dgvFechas.Name = "dgvFechas";
            this.dgvFechas.Size = new System.Drawing.Size(1267, 374);
            this.dgvFechas.TabIndex = 0;
            // 
            // btnExportarArticulos
            // 
            this.btnExportarArticulos.BackColor = System.Drawing.Color.DimGray;
            this.btnExportarArticulos.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarArticulos.ForeColor = System.Drawing.Color.White;
            this.btnExportarArticulos.Location = new System.Drawing.Point(611, 566);
            this.btnExportarArticulos.Name = "btnExportarArticulos";
            this.btnExportarArticulos.Size = new System.Drawing.Size(106, 49);
            this.btnExportarArticulos.TabIndex = 0;
            this.btnExportarArticulos.Text = "Exportar";
            this.btnExportarArticulos.UseVisualStyleBackColor = false;
            this.btnExportarArticulos.Click += new System.EventHandler(this.btnExportarArticulos_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnExportarArticulos);
            this.tabPage2.Controls.Add(this.dgvArticulos);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1329, 621);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Equipo";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnBuscarF);
            this.tabPage3.Controls.Add(this.textBox2);
            this.tabPage3.Controls.Add(this.textBox3);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.fecha2);
            this.tabPage3.Controls.Add(this.btnExportarFechas);
            this.tabPage3.Controls.Add(this.textBox15);
            this.tabPage3.Controls.Add(this.textBox14);
            this.tabPage3.Controls.Add(this.fecha);
            this.tabPage3.Controls.Add(this.dgvFechas);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1329, 621);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Fechas";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // pbCerrar
            // 
            this.pbCerrar.Image = ((System.Drawing.Image)(resources.GetObject("pbCerrar.Image")));
            this.pbCerrar.Location = new System.Drawing.Point(1310, 12);
            this.pbCerrar.Name = "pbCerrar";
            this.pbCerrar.Size = new System.Drawing.Size(35, 29);
            this.pbCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCerrar.TabIndex = 107;
            this.pbCerrar.TabStop = false;
            this.pbCerrar.Click += new System.EventHandler(this.pbCerrar_Click);
            // 
            // lCerrarSesion
            // 
            this.lCerrarSesion.AutoSize = true;
            this.lCerrarSesion.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCerrarSesion.ForeColor = System.Drawing.SystemColors.Control;
            this.lCerrarSesion.Location = new System.Drawing.Point(20, 38);
            this.lCerrarSesion.Name = "lCerrarSesion";
            this.lCerrarSesion.Size = new System.Drawing.Size(145, 29);
            this.lCerrarSesion.TabIndex = 106;
            this.lCerrarSesion.Text = "Cerrar sesion";
            this.lCerrarSesion.Click += new System.EventHandler(this.lCerrarSesion_Click);
            // 
            // lRegresar
            // 
            this.lRegresar.AutoSize = true;
            this.lRegresar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lRegresar.ForeColor = System.Drawing.SystemColors.Control;
            this.lRegresar.Location = new System.Drawing.Point(22, 10);
            this.lRegresar.Name = "lRegresar";
            this.lRegresar.Size = new System.Drawing.Size(102, 29);
            this.lRegresar.TabIndex = 105;
            this.lRegresar.Text = "Regresar";
            this.lRegresar.Click += new System.EventHandler(this.lRegresar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(574, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(239, 59);
            this.label3.TabIndex = 6;
            this.label3.Text = "INFORMES";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.pbMinimizar);
            this.panel1.Controls.Add(this.lCerrarSesion);
            this.panel1.Controls.Add(this.lRegresar);
            this.panel1.Controls.Add(this.pbCerrar);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1362, 81);
            this.panel1.TabIndex = 11;
            // 
            // pbMinimizar
            // 
            this.pbMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("pbMinimizar.Image")));
            this.pbMinimizar.Location = new System.Drawing.Point(1269, 12);
            this.pbMinimizar.Name = "pbMinimizar";
            this.pbMinimizar.Size = new System.Drawing.Size(35, 29);
            this.pbMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMinimizar.TabIndex = 119;
            this.pbMinimizar.TabStop = false;
            this.pbMinimizar.Click += new System.EventHandler(this.pbMinimizar_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 87);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1337, 653);
            this.tabControl1.TabIndex = 12;
            // 
            // Informes
            // 
            this.AcceptButton = this.btnExportarArticulos;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::SistemaInventario.Properties.Resources.Logo_Negativo_CDMX_PGJ;
            this.ClientSize = new System.Drawing.Size(1361, 752);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Informes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Informes_Load);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAreas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFechas)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCerrar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizar)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnExportarEmpleado;
        private System.Windows.Forms.DataGridView dgvArticulos;
        private System.Windows.Forms.Button btnBuscarF;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnExportar5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbAreas;
        private System.Windows.Forms.DataGridView dgvAreas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker fecha2;
        private System.Windows.Forms.Button btnExportarFechas;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.DateTimePicker fecha;
        private System.Windows.Forms.DataGridView dgvFechas;
        private System.Windows.Forms.Button btnExportarArticulos;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PictureBox pbCerrar;
        private System.Windows.Forms.Label lCerrarSesion;
        private System.Windows.Forms.Label lRegresar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnBuscarE;
        private System.Windows.Forms.TextBox tbNumEmpleado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvEmpleado;
        private System.Windows.Forms.PictureBox pbMinimizar;
        private System.Windows.Forms.Button btnBuscarArea;
    }
}