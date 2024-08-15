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

namespace ProyectoFarmacia
{
    public partial class Suministra : Form
    {
        private string connectionString = "Server=.;Database=Farmacia;Integrated Security=True;";

        public Suministra()
        {
            InitializeComponent();
            listarInventarioMed();
            cargarProveedores();
            btnLimpiar.Visible = false;
            txtNombreM.Enabled = false;
            txtNombreP.Enabled = false;
        }
        private void iconButton5_Click(object sender, EventArgs e)
        {
            // Obtener el ID del proveedor desde el cuadro de texto txtIdProveedor y convertirlo a un entero
            int idP = int.Parse(txtIdProveedor.Text);

            // Obtener el ID del medicamento desde el cuadro de texto txtIdMedicamento y convertirlo a un entero
            int idM = int.Parse(txtIdMedicamento.Text);

            // Llamar a la función AsignarProveedorAMedicina con los IDs del medicamento y el proveedor como parámetros
            AsignarProveedorAMedicina(idM, idP);

            // Llamar a la función Limpiar para limpiar los controles después de asignar el proveedor al medicamento
            Limpiar();

            // Llamar a la función listarInventarioMed para actualizar la lista de inventario de medicamentos
            listarInventarioMed();

            // Ocultar el botón de limpiar después de realizar la asignación
            btnLimpiar.Visible = false;
        }

        //Metodo para limpiar los campos
        private void Limpiar()
        {
            txtIdProveedor.Text = "";
            txtNombreM.Text = "";
            txtNombreP.Text = "";
            txtIdMedicamento.Text = "";
        }
        private void AsignarProveedorAMedicina(int medicinaID, int proveedorID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Verificar si la medicina ya tiene un proveedor asignado
                    string verificarQuery = "SELECT ProveedorID FROM Medicina WHERE MedicinaID = @MedicinaID";
                    using (SqlCommand verificarCommand = new SqlCommand(verificarQuery, connection))
                    {
                        verificarCommand.Parameters.AddWithValue("@MedicinaID", medicinaID);
                        object proveedorExistente = verificarCommand.ExecuteScalar();

                        if (proveedorExistente != DBNull.Value)
                        {
                            // La medicina ya tiene un proveedor asignado, puedes manejarlo según tus necesidades
                            MessageBox.Show("La medicina ya tiene un proveedor asignado.");
                            return;
                        }
                    }

                    // Asignar el proveedor a la medicina
                    string asignarQuery = "UPDATE Medicina SET ProveedorID = @ProveedorID WHERE MedicinaID = @MedicinaID";
                    using (SqlCommand asignarCommand = new SqlCommand(asignarQuery, connection))
                    {
                        asignarCommand.Parameters.AddWithValue("@ProveedorID", proveedorID);
                        asignarCommand.Parameters.AddWithValue("@MedicinaID", medicinaID);

                        int filasAfectadas = asignarCommand.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Proveedor asignado a la medicina correctamente.");
                            // Actualizar la lista de medicamentos en el DataGridView
                            listarInventarioMed();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo asignar el proveedor a la medicina.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                Console.WriteLine();
                MessageBox.Show("Error al asignar el proveedor a la medicina: " + ex.Message);
            }
        }

        public void listarInventarioMed()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                SELECT 
                    M.MedicinaID, 
                    M.Nombre, 
                    M.Descripcion, 
                    M.PrecioVenta, 
                    M.Stock,
                    ISNULL(P.NombreProveedor, 'NO TIENE PROVEEDOR') AS Proveedor
                FROM Medicina M
                LEFT JOIN Proveedores P ON M.ProveedorID = P.ProveedorID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        // Asignar el DataTable a la fuente de datos de tu componente de interfaz gráfica (por ejemplo, un DataGridView)
                        // Ejemplo asumiendo que tienes un DataGridView llamado dgvInventarioMed:
                        dtaSuministra.DataSource = dataTable;
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
        public void cargarProveedores()
        {
            // Obtener el DataTable de proveedores desde la capa de datos
            DataTable dataTable = ListarProveedores();

            // Asignar el DataTable al DataGridView
            dtaProveedor.DataSource = dataTable;

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
        // Este método se ejecuta cuando se hace clic en una celda en el DataGridView de suministra
        private void dtaProveedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow filaActual = dtaProveedor.Rows[e.RowIndex];//
            txtIdProveedor.Text = filaActual.Cells[0].Value.ToString();
            txtNombreP.Text = filaActual.Cells[1].Value.ToString();
            btnLimpiar.Visible = true;
        }
        // Este método se ejecuta cuando se hace clic en una celda en el DataGridView de proveedores
        private void dtaSuministra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow filaActual = dtaSuministra.Rows[e.RowIndex];//
            txtIdMedicamento.Text = filaActual.Cells[0].Value.ToString();
            txtNombreM.Text = filaActual.Cells[1].Value.ToString();
            btnLimpiar.Visible = true;
        }
        //Boton limpiar para cancelar la seleccion de DataGridView e limpiar
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            btnLimpiar.Visible = false;
        }
    }
}
