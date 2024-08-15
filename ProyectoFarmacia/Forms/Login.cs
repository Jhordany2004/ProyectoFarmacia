using CapaLogica;
using ProyectoFarmacia.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProyectoFarmacia
{
    public partial class Login : Form
    {
        public string nombreUsuario;
        public Login()
        {
            InitializeComponent();
            txtContraseña.PasswordChar = '*';
        }

        // Crear una instancia del formulario Inicio
        Inicio form = new Inicio();

        // Este método se ejecuta cuando se hace clic en el botón de cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Mostrar un cuadro de diálogo de confirmación
            DialogResult dialogResult = MessageBox.Show("¿Estás seguro de que quieres salir?", "Confirmacion", MessageBoxButtons.YesNo);
            // Verificar la respuesta del usuario
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Gracias por su visita");

               Application.Exit();
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            nombreUsuario = txtUsuario.Text;// Obtener el nombre de usuario del cuadro de texto txtUsuario
            form.Tag = txtUsuario.Text;// Asignar el texto del TextBox a la propiedad Tag del Form2

            string contraseña = txtContraseña.Text;// Obtener la contraseña del cuadro de texto txtContraseña

            // Verificar las credenciales utilizando el método ValidarCredenciales en la instancia del log de usuarios
            if (logUsuarios.Instancia.ValidarCredenciales(nombreUsuario, contraseña))
            {
                
                MessageBox.Show("Inicio de sesión exitoso");// Mostrar un mensaje de inicio de sesión exitoso
                Inicio frm = new Inicio();// Crear una instancia del formulario de inicio (Inicio)

                // Llamar al método MostrarUsuarioLogeado para mostrar el usuario logeado en el formulario de inicio
                frm.MostrarUsuarioLogeado(nombreUsuario);

                
                this.Hide();// Ocultar el formulario actual
                frm.Show();// Mostrar el formulario de inicio
            }
            else
            {
                // Mostrar un mensaje si las credenciales son incorrectas
                MessageBox.Show("Credenciales incorrectas");
            }

        }

        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            txtUsuario.Text = "";//Limpiar campo del text
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Llamar al método o realizar la acción deseada al presionar Enter
                btnIngresar.PerformClick();
                // Evitar que se procese la tecla Enter más de una vez
                e.Handled = true;
            }
        }
    }
}
