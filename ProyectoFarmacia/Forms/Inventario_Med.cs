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
    public partial class Inventario_Med : Form
    {
        private string connectionString = "Server=.;Database=Farmacia;Integrated Security=True;";
        int medicinaID = 0;
        public Inventario_Med()
        {
            InitializeComponent();
            listarInventarioMed();
            txtIdMedicina.Enabled = false;
            btnLimpiar.Visible = false;
        }
        public void listarInventarioMed()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT MedicinaID, Nombre, Descripcion, PrecioVenta, Stock FROM Medicina";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        // Asignar el DataTable a la fuente de datos de tu componente de interfaz gráfica (por ejemplo, un DataGridView)
                        // Ejemplo asumiendo que tienes un DataGridView llamado dgvInventarioMed:
                        dtaInventarioMed.DataSource = dataTable;
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
        //Metodo para limpiar los campos
        private void Limpiar()
        {
            txtIdMedicina.Text = "";
            txtDescr.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
        }
        private void iconButton5_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Insertar medicina en la tabla Medicina
                string nombreMedicina = txtNombre.Text;
                string descripcion = txtDescr.Text;
                decimal precioVenta = decimal.Parse(txtPrecio.Text);
                int stock = int.Parse(txtStock.Text);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Medicina (Nombre, Descripcion, PrecioVenta, Stock) VALUES (@Nombre, @Descripcion, @PrecioVenta, @Stock)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", nombreMedicina);
                        command.Parameters.AddWithValue("@Descripcion", descripcion);
                        command.Parameters.AddWithValue("@PrecioVenta", precioVenta);
                        command.Parameters.AddWithValue("@Stock", stock);

                        command.ExecuteNonQuery();
                    }
                }

                // Limpiar y listar nuevamente el inventario
                Limpiar();
                listarInventarioMed();
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        // Método para eliminar la medicina por MedicinaID
        private void EliminarMedicina(int medicinaID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Medicina WHERE MedicinaID = @MedicinaID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MedicinaID", medicinaID);
                    command.ExecuteNonQuery();
                }
            }
        }
        private void dtaInventarioMed_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Verificar si el clic fue en una celda válida
                if (e.RowIndex != -1 && e.ColumnIndex != -1)
                {
                    // Obtener el valor de la celda en la columna que contiene el ID de la medicina
                    object idCellValue = dtaInventarioMed.Rows[e.RowIndex].Cells["MedicinaID"].Value;

                    // Verificar si el valor no es nulo
                    if (idCellValue != null)
                    {
                        medicinaID = Convert.ToInt32(idCellValue);

                        // Ahora puedes utilizar el medicinaID según tus necesidades
                        //MessageBox.Show($"ID de la Medicina: {medicinaID}");
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            int medicinaID = Convert.ToInt32(txtIdMedicina.Text); // Asume que tienes un TextBox llamado txtIdArea para ingresar el ID del área a eliminar
            DialogResult dialogResult = MessageBox.Show("¿Estás seguro de que quieres eliminar?", "Confirmacion", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                EliminarMedicina(medicinaID);
                listarInventarioMed();
                Limpiar();
                groupBox1.Enabled = true;
                btnRegistrar.Visible = true;
                btnLimpiar.Visible = false;
                
                MessageBox.Show("Medicamento eliminado correctamente.");
            }
            
        }

        // Este método se ejecuta cuando se hace clic en una celda en el DataGridView de proveedores
        private void dtaInventarioMed_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow filaActual = dtaInventarioMed.Rows[e.RowIndex];//
            txtIdMedicina.Text = filaActual.Cells[0].Value.ToString();
            txtNombre.Text = filaActual.Cells[1].Value.ToString();
            txtDescr.Text = filaActual.Cells[2].Value.ToString();
            txtPrecio.Text = filaActual.Cells[3].Value.ToString();
            txtStock.Text = filaActual.Cells[4].Value.ToString();
            groupBox1.Enabled = false;
            btnLimpiar.Visible = true;
            btnRegistrar.Visible = false;
        }

        //Metodo para limpiar y cancelacion del DataGridView de proveedores
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            groupBox1.Enabled = true;
            btnLimpiar.Visible = false;
            btnRegistrar.Visible = true;
        }
    }
}
