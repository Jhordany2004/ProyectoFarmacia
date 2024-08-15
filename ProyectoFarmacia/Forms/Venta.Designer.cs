
namespace ProyectoFarmacia.Forms
{
    partial class Venta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grupBoxCliente = new System.Windows.Forms.GroupBox();
            this.txtIDC = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grupBoxVenta = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtImporteTotal = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtCant = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxPrecio = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtIDVENTA = new System.Windows.Forms.TextBox();
            this.btnVerificarVenta = new FontAwesome.Sharp.IconButton();
            this.btnRegistrarVenta = new FontAwesome.Sharp.IconButton();
            this.btnRestart = new FontAwesome.Sharp.IconButton();
            this.btnNuevo = new FontAwesome.Sharp.IconButton();
            this.dtaVenta = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.grupBoxCliente.SuspendLayout();
            this.grupBoxVenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtaVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(881, 211);
            this.label1.TabIndex = 0;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.iconPictureBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.HospitalUser;
            this.iconPictureBox1.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 120;
            this.iconPictureBox1.Location = new System.Drawing.Point(29, 73);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(120, 120);
            this.iconPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.iconPictureBox1.TabIndex = 1;
            this.iconPictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 37);
            this.label2.TabIndex = 2;
            this.label2.Text = "VENTA";
            // 
            // grupBoxCliente
            // 
            this.grupBoxCliente.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.grupBoxCliente.Controls.Add(this.txtIDC);
            this.grupBoxCliente.Controls.Add(this.label6);
            this.grupBoxCliente.Controls.Add(this.txtCategoria);
            this.grupBoxCliente.Controls.Add(this.label4);
            this.grupBoxCliente.Controls.Add(this.btnBuscar);
            this.grupBoxCliente.Controls.Add(this.txtNombre);
            this.grupBoxCliente.Controls.Add(this.label10);
            this.grupBoxCliente.Controls.Add(this.txtDNI);
            this.grupBoxCliente.Controls.Add(this.label3);
            this.grupBoxCliente.Font = new System.Drawing.Font("Mongolian Baiti", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grupBoxCliente.Location = new System.Drawing.Point(165, 125);
            this.grupBoxCliente.Name = "grupBoxCliente";
            this.grupBoxCliente.Size = new System.Drawing.Size(695, 68);
            this.grupBoxCliente.TabIndex = 26;
            this.grupBoxCliente.TabStop = false;
            this.grupBoxCliente.Text = "Informacion del cliente";
            // 
            // txtIDC
            // 
            this.txtIDC.Location = new System.Drawing.Point(561, 30);
            this.txtIDC.Name = "txtIDC";
            this.txtIDC.ReadOnly = true;
            this.txtIDC.Size = new System.Drawing.Size(92, 20);
            this.txtIDC.TabIndex = 53;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(559, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 11);
            this.label6.TabIndex = 52;
            this.label6.Text = "ID";
            // 
            // txtCategoria
            // 
            this.txtCategoria.Location = new System.Drawing.Point(406, 30);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.ReadOnly = true;
            this.txtCategoria.Size = new System.Drawing.Size(148, 20);
            this.txtCategoria.TabIndex = 51;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(404, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 11);
            this.label4.TabIndex = 50;
            this.label4.Text = "Categoría";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnBuscar.IconColor = System.Drawing.Color.Black;
            this.btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscar.IconSize = 15;
            this.btnBuscar.Location = new System.Drawing.Point(182, 30);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(37, 20);
            this.btnBuscar.TabIndex = 49;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(239, 30);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(148, 20);
            this.txtNombre.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(237, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 11);
            this.label10.TabIndex = 3;
            this.label10.Text = "Nombre ";
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(15, 30);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(161, 20);
            this.txtDNI.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 11);
            this.label3.TabIndex = 0;
            this.label3.Text = "Dni";
            // 
            // grupBoxVenta
            // 
            this.grupBoxVenta.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.grupBoxVenta.Controls.Add(this.label5);
            this.grupBoxVenta.Controls.Add(this.txtImporteTotal);
            this.grupBoxVenta.Controls.Add(this.lblFecha);
            this.grupBoxVenta.Controls.Add(this.comboBox1);
            this.grupBoxVenta.Controls.Add(this.txtCant);
            this.grupBoxVenta.Controls.Add(this.label9);
            this.grupBoxVenta.Controls.Add(this.label8);
            this.grupBoxVenta.Controls.Add(this.label7);
            this.grupBoxVenta.Controls.Add(this.textBoxPrecio);
            this.grupBoxVenta.Font = new System.Drawing.Font("Mongolian Baiti", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grupBoxVenta.Location = new System.Drawing.Point(165, 51);
            this.grupBoxVenta.Name = "grupBoxVenta";
            this.grupBoxVenta.Size = new System.Drawing.Size(701, 68);
            this.grupBoxVenta.TabIndex = 28;
            this.grupBoxVenta.TabStop = false;
            this.grupBoxVenta.Text = "Datos de la venta";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(387, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 11);
            this.label5.TabIndex = 16;
            this.label5.Text = "Importe Total";
            // 
            // txtImporteTotal
            // 
            this.txtImporteTotal.Location = new System.Drawing.Point(389, 37);
            this.txtImporteTotal.Name = "txtImporteTotal";
            this.txtImporteTotal.ReadOnly = true;
            this.txtImporteTotal.Size = new System.Drawing.Size(76, 20);
            this.txtImporteTotal.TabIndex = 15;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(488, 43);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(41, 11);
            this.lblFecha.TabIndex = 14;
            this.lblFecha.Text = "______";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(16, 35);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 19);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // txtCant
            // 
            this.txtCant.Location = new System.Drawing.Point(154, 34);
            this.txtCant.Name = "txtCant";
            this.txtCant.Size = new System.Drawing.Size(100, 20);
            this.txtCant.TabIndex = 10;
            this.txtCant.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(152, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 11);
            this.label9.TabIndex = 9;
            this.label9.Text = "Cantidad";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(268, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 11);
            this.label8.TabIndex = 7;
            this.label8.Text = "Precio por unidad";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 11);
            this.label7.TabIndex = 6;
            this.label7.Text = "Nombre de medicamento";
            // 
            // textBoxPrecio
            // 
            this.textBoxPrecio.Location = new System.Drawing.Point(270, 34);
            this.textBoxPrecio.Name = "textBoxPrecio";
            this.textBoxPrecio.ReadOnly = true;
            this.textBoxPrecio.Size = new System.Drawing.Size(76, 20);
            this.textBoxPrecio.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label12.Font = new System.Drawing.Font("Mongolian Baiti", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(254, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "Id de venta:";
            // 
            // txtIDVENTA
            // 
            this.txtIDVENTA.Location = new System.Drawing.Point(257, 25);
            this.txtIDVENTA.Name = "txtIDVENTA";
            this.txtIDVENTA.Size = new System.Drawing.Size(209, 20);
            this.txtIDVENTA.TabIndex = 30;
            // 
            // btnVerificarVenta
            // 
            this.btnVerificarVenta.BackColor = System.Drawing.Color.DarkCyan;
            this.btnVerificarVenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerificarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerificarVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerificarVenta.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnVerificarVenta.IconChar = FontAwesome.Sharp.IconChar.FileCircleCheck;
            this.btnVerificarVenta.IconColor = System.Drawing.Color.White;
            this.btnVerificarVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVerificarVenta.IconSize = 25;
            this.btnVerificarVenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerificarVenta.Location = new System.Drawing.Point(484, 10);
            this.btnVerificarVenta.Name = "btnVerificarVenta";
            this.btnVerificarVenta.Size = new System.Drawing.Size(134, 43);
            this.btnVerificarVenta.TabIndex = 32;
            this.btnVerificarVenta.Text = "Verificar Venta";
            this.btnVerificarVenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVerificarVenta.UseVisualStyleBackColor = false;
            this.btnVerificarVenta.Click += new System.EventHandler(this.btnVerificarVenta_Click);
            // 
            // btnRegistrarVenta
            // 
            this.btnRegistrarVenta.BackColor = System.Drawing.Color.DarkCyan;
            this.btnRegistrarVenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarVenta.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRegistrarVenta.IconChar = FontAwesome.Sharp.IconChar.FileDownload;
            this.btnRegistrarVenta.IconColor = System.Drawing.Color.White;
            this.btnRegistrarVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRegistrarVenta.IconSize = 25;
            this.btnRegistrarVenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistrarVenta.Location = new System.Drawing.Point(624, 9);
            this.btnRegistrarVenta.Name = "btnRegistrarVenta";
            this.btnRegistrarVenta.Size = new System.Drawing.Size(134, 43);
            this.btnRegistrarVenta.TabIndex = 33;
            this.btnRegistrarVenta.Text = "Registrar Venta";
            this.btnRegistrarVenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRegistrarVenta.UseVisualStyleBackColor = false;
            this.btnRegistrarVenta.Click += new System.EventHandler(this.btnRegistrarVenta_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.Color.DarkCyan;
            this.btnRestart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestart.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRestart.IconChar = FontAwesome.Sharp.IconChar.FileContract;
            this.btnRestart.IconColor = System.Drawing.Color.White;
            this.btnRestart.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRestart.IconSize = 25;
            this.btnRestart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRestart.Location = new System.Drawing.Point(764, 9);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(96, 44);
            this.btnRestart.TabIndex = 54;
            this.btnRestart.Text = "Restart";
            this.btnRestart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.DarkCyan;
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnNuevo.IconChar = FontAwesome.Sharp.IconChar.DollyFlatbed;
            this.btnNuevo.IconColor = System.Drawing.Color.White;
            this.btnNuevo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNuevo.IconSize = 25;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(158, 10);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(90, 36);
            this.btnNuevo.TabIndex = 55;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // dtaVenta
            // 
            this.dtaVenta.AllowUserToAddRows = false;
            this.dtaVenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtaVenta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtaVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtaVenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtaVenta.Location = new System.Drawing.Point(0, 211);
            this.dtaVenta.MultiSelect = false;
            this.dtaVenta.Name = "dtaVenta";
            this.dtaVenta.ReadOnly = true;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dtaVenta.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dtaVenta.Size = new System.Drawing.Size(881, 296);
            this.dtaVenta.TabIndex = 56;
            // 
            // Venta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(881, 507);
            this.Controls.Add(this.dtaVenta);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnRegistrarVenta);
            this.Controls.Add(this.btnVerificarVenta);
            this.Controls.Add(this.txtIDVENTA);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.grupBoxVenta);
            this.Controls.Add(this.grupBoxCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "Venta";
            this.Text = "Venta";
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.grupBoxCliente.ResumeLayout(false);
            this.grupBoxCliente.PerformLayout();
            this.grupBoxVenta.ResumeLayout(false);
            this.grupBoxVenta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtaVenta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grupBoxCliente;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grupBoxVenta;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxPrecio;
        private System.Windows.Forms.TextBox txtCant;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtIDVENTA;
        private FontAwesome.Sharp.IconButton btnVerificarVenta;
        private FontAwesome.Sharp.IconButton btnRegistrarVenta;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblFecha;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtImporteTotal;
        private System.Windows.Forms.TextBox txtIDC;
        private System.Windows.Forms.Label label6;
        private FontAwesome.Sharp.IconButton btnRestart;
        private FontAwesome.Sharp.IconButton btnNuevo;
        private System.Windows.Forms.DataGridView dtaVenta;
    }
}