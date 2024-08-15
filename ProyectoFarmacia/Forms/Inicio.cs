using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FontAwesome.Sharp;
using ProyectoFarmacia.Forms;

namespace ProyectoFarmacia
{
    public partial class Inicio : Form
    {
        public static IconMenuItem MenuActivo = null;
        public static Form FormularioActivo = null;

        public Inicio()
        {
            InitializeComponent();
            // Asignar el texto almacenado en la propiedad Tag del formulario al texto de la etiqueta lblUsuario
            lblUsuario.Text = (string)this.Tag;
        }

        // Este método se utiliza para mostrar el nombre de usuario logeado en una etiqueta (lblUsuario)
        public void MostrarUsuarioLogeado(string nombreUsuario)
        {
            lblUsuario.Text = nombreUsuario;
        }

        // Este método se utiliza para abrir un formulario dentro de un contenedor específico
        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            // Si hay un menú activo, cambiar su color de fondo a blanco
            if (MenuActivo != null){
                MenuActivo.BackColor = Color.White;
            }
            // Cambiar el color de fondo del menú actual al color seleccionado (gris)
            menu.BackColor = Color.Silver;
            MenuActivo = menu;
            // Si hay un formulario activo, cerrarlo
            if (FormularioActivo != null)
            {
                FormularioActivo.Close();
            }
            // Asignar el formulario actual y ajustar su configuración
            FormularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.DarkCyan;

            // Agregar el formulario al contenedor
            contenedor.Controls.Add(formulario);
            formulario.Show();
        }

        // Este método se ejecuta cuando se hace clic en el menú "Venta"
        private void menuVenta_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuVenta, new Venta());// Abrir el formulario de Venta
        }

        // Este método se ejecuta cuando se hace clic en el submenú "Suministra"
        private void submenuSuministra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuProveedor, new Suministra());// Abrir el formulario de Suministra
        }

        // Este método se ejecuta cuando se hace clic en el submenú "Registrar" bajo el menú "Proveedor"
        private void submenu3Registrar_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuProveedor, new Proveedor());// Abrir el formulario de Proveedor
        }

        // Este método se ejecuta cuando se hace clic en el menú "Encargado"
        private void menuEncargado_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuEncargado, new Encargado());// Abrir el formulario de Encargado
        }

        // Este método se ejecuta cuando se hace clic en el menú "Afiliados"
        private void menuAfiliados_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuAfiliados, new Afiliados());// Abrir el formulario de Afiliados
        }

        // Este método se ejecuta cuando se hace clic en el menú "Medicamento"
        private void menuMedicamento_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuMedicamento, new Inventario_Med());// Abrir el formulario de Inventario de Medicamentos
        }

        // Este método se ejecuta cuando se hace clic en un icono, muestra un mensaje de agradecimiento y cierra la aplicación
        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Estás seguro de que quieres salir?", "Confirmacion", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Gracias por su preferencia");
                Application.Exit();
            }
            
        }
    }
}
