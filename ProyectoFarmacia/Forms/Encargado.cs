using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;


namespace ProyectoFarmacia.Forms
{
    public partial class Encargado : Form
    {
        private string connectionString = "Server=.;Database=Farmacia;Integrated Security=True;";
        
        public Encargado()
        {
            InitializeComponent();
            listarEncargado();
            txtClave.UseSystemPasswordChar = true;
            txtIdEncargado.Visible = false;
        }
        //Listar los usuarios a la tabla Usuario
        public DataTable ListarUsuarios()
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT UsuarioID, Nombre FROM Usuarios";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        dataTable.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                throw new Exception("Error al listar usuarios", ex);
            }

            return dataTable;
        }
        //Listar tabla
        public void listarEncargado()
        {
            try
            {
                // Obtener el DataTable de usuarios desde la capa de datos
                DataTable dataTable = ListarUsuarios();

                // Asignar el DataTable al DataSource del DataGridView
                dtaEncargado.DataSource = dataTable;

                // Opcional: Puedes ocultar la columna de Contraseña si es que existe
                if (dtaEncargado.Columns.Contains("Contraseña"))
                {
                    dtaEncargado.Columns["Contraseña"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                Console.WriteLine();
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Este método se ejecuta cuando se hace clic en el botón Registrar
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Obtener el nombre de usuario desde el cuadro de texto txtNombre
            string usuario = txtNombre.Text;

            // Obtener la clave desde el cuadro de texto txtClave
            string clave = txtClave.Text;

            // Llamar a la función RegistrarUsuario con el nombre de usuario y la clave como parámetros
            RegistrarUsuario(usuario, clave);

            Limpiar();// Llamar a la función Limpiar para limpiar los controles
            listarEncargado();// Llamar a la función listarEncargado para actualizar la lista de encargados
        }
        public void RegistrarUsuario(string nombre, string contraseña)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Insertar el nuevo usuario en la base de datos
                    string query = "INSERT INTO Usuarios (Nombre, Contraseña) VALUES (@Nombre, @Contraseña)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@Contraseña", contraseña);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                throw new Exception("Error al registrar usuario", ex);
            }
        }

        //Metodo para limpiar los campos
        private void Limpiar()
        {
            txtIdEncargado.Text = "";
            txtNombre.Text = "";
            txtClave.Text = "";
        }

        // Este método se ejecuta cuando se hace clic en el botón Modificar
        private void btnModificar_Click(object sender, EventArgs e) // boton modificar
        {
            Limpiar();// Llamar a la función Limpiar para limpiar los controles
            listarEncargado(); // Llamar a la función listarEncargado para actualizar la lista de encargados
            txtIdEncargado.Enabled = true;
            btnRegistrar.Visible = true;
        }
        // Este método se ejecuta cuando se hace clic en el botón Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();// Llamar a la función Limpiar para limpiar los controles
            txtIdEncargado.Enabled = true;
            btnRegistrar.Visible = true;
        }
        // Este método se ejecuta cuando se hace clic en el botón Eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Limpiar();// Llamar a la función Limpiar para limpiar los controles
            listarEncargado(); // Llamar a la función listarEncargado para actualizar la lista de encargados
        }
    }
}
 
