using CapaEntidad;
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
using CapaLogica;

namespace ProyectoFarmacia.Forms
{
    public partial class Proveedor : Form
    {
        private string connectionString = "Server=.;Database=Farmacia;Integrated Security=True;";
        int proveedorID = 0;
        public Proveedor()
        {
            InitializeComponent();
            cargarProveedores();
            txtIdProveedor.Enabled = false;
            btnLimpiar.Visible = false;
        }

        public void cargarProveedores() 
        {
            DataTable dataTable = ListarProveedores();// Obtener el DataTable de proveedores desde la capa de datos
            dtaProveedor.DataSource = dataTable;// Asignar el DataTable al DataGridView
        }

        //Listar tabla
        public DataTable ListarProveedores()
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT ProveedorID, NombreProveedor, DireccionProveedor, TelefonoProveedor FROM Proveedores";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();

                        // Cargar los datos en el DataTable
                        dataTable.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                throw new Exception("Error al obtener la lista de proveedores", ex);
            }

            return dataTable;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Obtener los valores de los TextBox
                    string nombreProveedor = txtNombre.Text;
                    string direccionProveedor = txtDireccion.Text;
                    string telefonoProveedor = txtTelefono.Text;

                    // Consulta SQL para insertar el proveedor
                    string query = @"
                    INSERT INTO Proveedores (NombreProveedor, DireccionProveedor, TelefonoProveedor)
                    VALUES (@NombreProveedor, @DireccionProveedor, @TelefonoProveedor)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Agregar parámetros
                        command.Parameters.AddWithValue("@NombreProveedor", nombreProveedor);
                        command.Parameters.AddWithValue("@DireccionProveedor", direccionProveedor);
                        command.Parameters.AddWithValue("@TelefonoProveedor", telefonoProveedor);

                        // Ejecutar la consulta
                        command.ExecuteNonQuery();

                        
                        MessageBox.Show("Proveedor registrado exitosamente");
                    }
                    // Limpiar los TextBox después de la inserción
                    Limpiar();
                    cargarProveedores();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el proveedor: " + ex.Message);
            }
        }
        //Metodo de limpiar campos
        private void Limpiar()
        {
            txtIdProveedor.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
        }
        // Este método se ejecuta cuando se hace clic en el botón de modificar
        private void btnModificar_Click(object sender, EventArgs e)
        {

            try
            {// Crear una instancia de la entidad Proveedores
                entProveedores P = new entProveedores();

                // Asignar los valores de los cuadros de texto a las propiedades de la entidad
                P.ProveedorID = int.Parse(txtIdProveedor.Text.Trim());
                P.NombreProveedor = txtNombre.Text.Trim();
                P.DireccionProveedor = txtDireccion.Text.Trim();
                P.TelefonoProveedor = txtTelefono.Text.Trim();

                // Llamar al método de edición en la instancia del log de clientes para modificar el proveedor
                logClientes.Instancia.EditaProveedor(P);
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error en caso de excepción
                MessageBox.Show("Error.." + ex);
            }
            
            cargarProveedores();// Recargar la lista de proveedores
            Limpiar(); // Limpiar los cuadros de texto después de la modificación
            btnRegistrar.Visible = true;// Mostrar el botón de registrar
            btnLimpiar.Visible = false;// Ocultar el botón de limpiar
        }
        // Este método se ejecuta cuando se hace clic en una celda en el DataGridView de proveedores
        private void dtaProveedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Obtener la fila actual del DataGridView
            DataGridViewRow filaActual = dtaProveedor.Rows[e.RowIndex];

            // Asignar los valores de la fila a los cuadros de texto correspondientes
            txtIdProveedor.Text = filaActual.Cells[0].Value.ToString();
            txtNombre.Text = filaActual.Cells[1].Value.ToString();
            txtDireccion.Text = filaActual.Cells[2].Value.ToString();
            txtTelefono.Text = filaActual.Cells[3].Value.ToString();


            txtIdProveedor.Enabled = false;// Deshabilitar la edición del ID del proveedor
            btnRegistrar.Visible = false;// Ocultar el botón de registrar
            btnLimpiar.Visible = true;// Mostrar el botón de limpiar
        }

        // Este método se ejecuta cuando se hace clic en el botón de limpiar
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();// Llamar a la función Limpiar para limpiar los controles
            btnLimpiar.Visible = false;
            btnEliminar.Visible = true; 
            btnRegistrar.Visible = true; 
        }

        // Método para eliminar la medicina por MedicinaID
        private void EliminarProveedor(int proveedorID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Proveedores WHERE ProveedorID = @ProveedorID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProveedorID", proveedorID);
                    command.ExecuteNonQuery();
                }
            }
        }
        
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int proveedorID = Convert.ToInt32(txtIdProveedor.Text); // Asume que tienes un TextBox llamado txtIdArea para ingresar el ID del área a eliminar
            DialogResult dialogResult = MessageBox.Show("¿Estás seguro de que quieres eliminar?", "Confirmacion", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                EliminarProveedor(proveedorID);
                cargarProveedores();
                Limpiar();
                btnRegistrar.Visible = true;
                btnLimpiar.Visible = false;

                MessageBox.Show("Usuario eliminado correctamente.");
            }
        }
    }
}
