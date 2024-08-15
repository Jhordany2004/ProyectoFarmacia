using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaLogica;

namespace ProyectoFarmacia.Forms
{
    public partial class Afiliados : Form
    {
        private string connectionString = "Server=.;Database=Farmacia;Integrated Security=True;";

        public Afiliados()
        {
            InitializeComponent();
            listarAfiliado();
            cargarCategorias();
        }

        private void cargarCategorias()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Nombre FROM Categorias";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();

                        // Limpiar items existentes antes de agregar nuevos
                        cbBuscar.Items.Clear();
                        comboBox2.Items.Clear();
                        while (reader.Read())
                        {
                            // Obtener el nombre de la categoría directamente
                            string nombreCategoria = reader["Nombre"].ToString();

                            // Agregar el nombre al control
                            cbBuscar.Items.Add(nombreCategoria);
                            comboBox2.Items.Add(nombreCategoria);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        //Listar tabla
        public void listarAfiliado()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT C.ClienteID, C.Nombre, C.DNI, CAT.Nombre AS NombreCategoria " +
                           "FROM Clientes C " +
                           "INNER JOIN Categorias CAT ON C.CategoriaID = CAT.CategoriaID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        dtaAfiliado.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                Console.WriteLine();
                MessageBox.Show("Error: " + ex.Message);
            }
        }

            public void ConsultarAfiliado(string dni, string categoria)
            {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Construir la consulta dinámica
                    string query = "SELECT C.ClienteID, C.Nombre, C.DNI, CAT.Nombre AS NombreCategoria " +
                                   "FROM Clientes C " +
                                   "INNER JOIN Categorias CAT ON C.CategoriaID = CAT.CategoriaID " +
                                   "WHERE (@DNI IS NULL OR C.DNI = @DNI) " +
                                   "AND (@Categoria IS NULL OR CAT.Nombre = @Categoria)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Parámetros para la consulta dinámica
                        command.Parameters.AddWithValue("@DNI", string.IsNullOrEmpty(dni) ? (object)DBNull.Value : dni);
                        command.Parameters.AddWithValue("@Categoria", string.IsNullOrEmpty(categoria) ? (object)DBNull.Value : categoria);

                        SqlDataReader reader = command.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        dtaAfiliado.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                Console.WriteLine();
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void iconButton5_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los valores de los campos del formulario
                string nombre = txtNombre.Text;
                string dni = txtDniCli.Text;

                // Validar que se haya seleccionado una categoría
                if (comboBox2.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione una categoría para el afiliado.");
                    return;
                }

                // Obtener el nombre de la categoría seleccionada
                string nombreCategoria = comboBox2.SelectedItem.ToString();

                // Obtener el ID de la categoría seleccionada desde la base de datos
                int categoriaID;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT CategoriaID FROM Categorias WHERE Nombre = @Nombre";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", nombreCategoria);
                        object result = command.ExecuteScalar();

                        // Verificar si el resultado no es nulo antes de convertir
                        if (result != null)
                        {
                            categoriaID = Convert.ToInt32(result);
                        }
                        else
                        {
                            MessageBox.Show("Error al obtener la categoría.");
                            return;
                        }
                    }
                }

                // Insertar el nuevo afiliado en la base de datos
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string insertQuery = "INSERT INTO Clientes (Nombre, DNI, CategoriaID) VALUES (@Nombre, @DNI, @CategoriaID)";
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@DNI", dni);
                        command.Parameters.AddWithValue("@CategoriaID", categoriaID);

                        // Ejecutar la consulta
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Afiliado insertado correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("Error al insertar el afiliado.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            // Limpiar y volver a listar los afiliados
            Limpiar();
            listarAfiliado();
        }

        private void Limpiar()
        {
            txtDniCli.Text = "";
            txtNombre.Text = "";
            comboBox2.SelectedIndex = -1;
        }

        private void btnBuscarEncargado_Click(object sender, EventArgs e)
        {
            string id = txtBuscarDNI.Text;
            string categoria = cbBuscar.Text;

            // Llamar a la función ConsultarAfiliado con los parámetros de nombre y categoría
            ConsultarAfiliado(id, categoria);
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            listarAfiliado();
            txtBuscarDNI.Text = "";
            cbBuscar.Text = "";
        }
    }
}
