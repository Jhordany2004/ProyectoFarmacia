
namespace ProyectoFarmacia
{
    partial class Inicio
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuEncargado = new FontAwesome.Sharp.IconMenuItem();
            this.menuAfiliados = new FontAwesome.Sharp.IconMenuItem();
            this.menuProveedor = new FontAwesome.Sharp.IconMenuItem();
            this.submenu3Registrar = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuSuministra = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMedicamento = new FontAwesome.Sharp.IconMenuItem();
            this.menuVenta = new FontAwesome.Sharp.IconMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.contenedor = new System.Windows.Forms.Panel();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEncargado,
            this.menuAfiliados,
            this.menuProveedor,
            this.menuMedicamento,
            this.menuVenta});
            this.menuStrip1.Location = new System.Drawing.Point(0, 61);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(885, 74);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuEncargado
            // 
            this.menuEncargado.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuEncargado.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
            this.menuEncargado.IconColor = System.Drawing.Color.Black;
            this.menuEncargado.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuEncargado.IconSize = 50;
            this.menuEncargado.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuEncargado.Name = "menuEncargado";
            this.menuEncargado.Size = new System.Drawing.Size(86, 70);
            this.menuEncargado.Text = "Encargado";
            this.menuEncargado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuEncargado.Click += new System.EventHandler(this.menuEncargado_Click);
            // 
            // menuAfiliados
            // 
            this.menuAfiliados.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuAfiliados.IconChar = FontAwesome.Sharp.IconChar.UserInjured;
            this.menuAfiliados.IconColor = System.Drawing.Color.Black;
            this.menuAfiliados.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuAfiliados.IconSize = 50;
            this.menuAfiliados.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuAfiliados.Name = "menuAfiliados";
            this.menuAfiliados.Size = new System.Drawing.Size(76, 70);
            this.menuAfiliados.Text = "Afiliados";
            this.menuAfiliados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuAfiliados.Click += new System.EventHandler(this.menuAfiliados_Click);
            // 
            // menuProveedor
            // 
            this.menuProveedor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenu3Registrar,
            this.submenuSuministra});
            this.menuProveedor.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuProveedor.IconChar = FontAwesome.Sharp.IconChar.AddressCard;
            this.menuProveedor.IconColor = System.Drawing.Color.Black;
            this.menuProveedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuProveedor.IconSize = 50;
            this.menuProveedor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuProveedor.Name = "menuProveedor";
            this.menuProveedor.Size = new System.Drawing.Size(83, 70);
            this.menuProveedor.Text = "Proveedor";
            this.menuProveedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // submenu3Registrar
            // 
            this.submenu3Registrar.Name = "submenu3Registrar";
            this.submenu3Registrar.Size = new System.Drawing.Size(140, 22);
            this.submenu3Registrar.Text = "Registrar";
            this.submenu3Registrar.Click += new System.EventHandler(this.submenu3Registrar_Click);
            // 
            // submenuSuministra
            // 
            this.submenuSuministra.Name = "submenuSuministra";
            this.submenuSuministra.Size = new System.Drawing.Size(140, 22);
            this.submenuSuministra.Text = "Suministra";
            this.submenuSuministra.Click += new System.EventHandler(this.submenuSuministra_Click);
            // 
            // menuMedicamento
            // 
            this.menuMedicamento.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuMedicamento.IconChar = FontAwesome.Sharp.IconChar.Medkit;
            this.menuMedicamento.IconColor = System.Drawing.Color.Black;
            this.menuMedicamento.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuMedicamento.IconSize = 50;
            this.menuMedicamento.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuMedicamento.Name = "menuMedicamento";
            this.menuMedicamento.Size = new System.Drawing.Size(110, 70);
            this.menuMedicamento.Text = "Medicamentos";
            this.menuMedicamento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuMedicamento.Click += new System.EventHandler(this.menuMedicamento_Click);
            // 
            // menuVenta
            // 
            this.menuVenta.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuVenta.IconChar = FontAwesome.Sharp.IconChar.MoneyBills;
            this.menuVenta.IconColor = System.Drawing.Color.Black;
            this.menuVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuVenta.IconSize = 50;
            this.menuVenta.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.menuVenta.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuVenta.Name = "menuVenta";
            this.menuVenta.Size = new System.Drawing.Size(62, 70);
            this.menuVenta.Text = "Venta";
            this.menuVenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuVenta.Click += new System.EventHandler(this.menuVenta_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.AutoSize = false;
            this.menuStrip2.BackColor = System.Drawing.Color.DarkCyan;
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip2.Size = new System.Drawing.Size(885, 61);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkCyan;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(26, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(441, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "SISTEMA DE VENTAS FARMACIA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Teal;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(620, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Usuario:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.BackColor = System.Drawing.Color.Teal;
            this.lblUsuario.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblUsuario.Location = new System.Drawing.Point(695, 19);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(82, 16);
            this.lblUsuario.TabIndex = 4;
            this.lblUsuario.Text = "lblUsuario";
            // 
            // contenedor
            // 
            this.contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedor.Location = new System.Drawing.Point(0, 135);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(885, 500);
            this.contenedor.TabIndex = 5;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.DarkCyan;
            this.iconPictureBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.RightToBracket;
            this.iconPictureBox1.IconColor = System.Drawing.SystemColors.ControlLightLight;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 49;
            this.iconPictureBox1.Location = new System.Drawing.Point(831, 0);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(54, 49);
            this.iconPictureBox1.TabIndex = 6;
            this.iconPictureBox1.TabStop = false;
            this.iconPictureBox1.Click += new System.EventHandler(this.iconPictureBox1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DarkCyan;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(836, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "SALIR";
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 635);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.contenedor);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private FontAwesome.Sharp.IconMenuItem menuEncargado;
        private FontAwesome.Sharp.IconMenuItem menuProveedor;
        private FontAwesome.Sharp.IconMenuItem menuAfiliados;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconMenuItem menuMedicamento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Panel contenedor;
        private FontAwesome.Sharp.IconMenuItem menuVenta;
        private System.Windows.Forms.ToolStripMenuItem submenuSuministra;
        private System.Windows.Forms.ToolStripMenuItem submenu3Registrar;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Label label3;
    }
}

