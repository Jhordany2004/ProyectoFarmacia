using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using FontAwesome.Sharp;
using ProyectoFarmacia.Forms;

namespace ProyectoFarmacia.Forms
{
    public partial class Venta : Form
    {
        private string connectionString = "Server=.;Database=Farmacia;Integrated Security=True;";
       
        public Venta()
        {
            InitializeComponent();
            ListarVentas();
            listarMedicamentos();
            OcultarGrupBoxs();
            btnRegistrarVenta.Enabled = false;
            btnRestart.Enabled = false;

        }
        // Este método se ejecuta cuando el texto en el TextBox4 cambia
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // Llamar a la función CalcularImporteTotal para realizar cálculos basados en el nuevo texto
            CalcularImporteTotal();
        }

        private void listarMedicamentos()
        {
            // Crear una instancia de SqlConnection usando la cadena de conexión
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Abrir la conexión a la base de datos
                connection.Open();

                // Crear una instancia de SqlCommand para ejecutar la consulta
                SqlCommand command = new SqlCommand("SELECT MedicinaID, Nombre FROM Medicina ORDER BY Nombre", connection);

                // Ejecutar la consulta y obtener un SqlDataReader
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Limpiar los elementos existentes en el ComboBox
                    comboBox1.Items.Clear();

                    // Recorrer los resultados de la consulta
                    while (reader.Read())
                    {
                        // Obtener el ID y el nombre de la medicina
                        int medicinaID = reader.GetInt32(0);
                        string nombreMedicina = reader.GetString(1);

                        // Agregar un nuevo elemento al ComboBox con el nombre de la medicina
                        comboBox1.Items.Add(nombreMedicina);
                    }
                }
            }
        }

        // Obtener ventas con detalles y devolver un DataTable
        public DataTable ObtenerVentasConDetalles()
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                    SELECT
                        V.VentaID,
                        C.Nombre AS Cliente,
                        U.Nombre AS Usuario,
                        V.FechaVenta,
                        SUM(DV.Cantidad * M.PrecioVenta) AS TotalVenta, -- Corregir cálculo del TotalVenta
                        DV.Cantidad,
                        M.Nombre AS Medicina,
                        M.PrecioVenta,
                        DV.Descuento,
                        CASE
                            WHEN DV.Descuento IS NULL THEN 'No tiene descuento'
                            ELSE 'Tiene descuento'
                        END AS EstadoDescuento
                    FROM Ventas V
                    JOIN Clientes C ON V.ClienteID = C.ClienteID
                    JOIN Usuarios U ON V.UsuarioID = U.UsuarioID
                    JOIN DetallesVenta DV ON V.VentaID = DV.VentaID
                    JOIN Medicina M ON DV.MedicinaID = M.MedicinaID
                    GROUP BY V.VentaID, C.Nombre, U.Nombre, V.FechaVenta, DV.Cantidad, M.Nombre, M.PrecioVenta, DV.Descuento";

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
                throw new Exception("Error al obtener ventas con detalles", ex);
            }

            return dataTable;
        }
        private void ObtenerPrecioMedicamento(string nombreMedicamento)
        {
            // Crear una instancia de SqlConnection usando la cadena de conexión
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Abrir la conexión a la base de datos
                connection.Open();

                // Consulta SQL para obtener el precio del medicamento por nombre
                string query = "SELECT PrecioVenta FROM Medicina WHERE Nombre = @Nombre";

                // Crear una instancia de SqlCommand para ejecutar la consulta
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Agregar el parámetro del nombre del medicamento a la consulta
                    command.Parameters.AddWithValue("@Nombre", nombreMedicamento);

                    // Ejecutar la consulta y obtener el precio del medicamento
                    object precio = command.ExecuteScalar();

                    // Verificar si se obtuvo un resultado
                    if (precio != null)
                    {
                        // Mostrar el precio del medicamento
                        //MessageBox.Show($"El precio de {nombreMedicamento} es: {precio.ToString()}");
                        textBoxPrecio.Text = precio.ToString();
                    }
                    else
                    {
                        MessageBox.Show($"No se encontró información para {nombreMedicamento}");
                    }
                }
            }
        }

        // Listar tabla
        public void ListarVentas()
        {   
            try
            {
                Console.WriteLine("Listar Ventas - Inicio");

                // Obtener el DataTable de ventas con detalles desde la capa de datos
                DataTable dataTable = ObtenerVentasConDetalles();

                Console.WriteLine("Número de filas en el DataTable: " + dataTable.Rows.Count);

                // Verificar si hay columnas en el DataTable
                foreach (DataColumn column in dataTable.Columns)
                {
                    Console.WriteLine("Columna: " + column.ColumnName);
                }

                // Asignar el DataTable al DataGridView
                dtaVenta.DataSource = dataTable;
                Console.WriteLine("Listar Ventas - Fin");
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                Console.WriteLine();
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        // Deshabilitar los GroupBoxs de venta y cliente
        public void OcultarGrupBoxs()
        {
            grupBoxVenta.Enabled = false;    // Deshabilitar el GroupBox relacionado con la venta
            grupBoxCliente.Enabled = false;  // Deshabilitar el GroupBox relacionado con el cliente
        }
        // Habilitar los GroupBoxs de venta y cliente
        public void MostrarGrupBoxs()
        {
            grupBoxVenta.Enabled = true;    // Habilitar el GroupBox relacionado con la venta
            grupBoxCliente.Enabled = true;  // Habilitar el GroupBox relacionado con el cliente
        }

        private void btnVerificarVenta_Click(object sender, EventArgs e)
        {
            // Obtener el ID de la venta desde algún control (supongamos que el TextBox se llama txtIDVENTA)
            int ventaID;
            if (!int.TryParse(txtIDVENTA.Text, out ventaID))
            {
                MessageBox.Show("Ingrese un ID de venta válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Filtrar la venta por el ID
            FiltrarVentaPorID(ventaID);
            btnRestart.Enabled = true;

        }

        private void FiltrarVentaPorID(int ventaID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Construir la consulta para filtrar la venta por ID
                    string query = @"
                SELECT
                    V.VentaID,
                    C.Nombre AS Cliente,
                    U.Nombre AS Usuario,
                    V.FechaVenta,
                    SUM(DV.Cantidad * M.PrecioVenta) AS TotalVenta,
                    DV.Cantidad,
                    M.Nombre AS Medicina,
                    M.PrecioVenta,
                    DV.Descuento,
                    CASE
                        WHEN DV.Descuento IS NULL THEN 'No tiene descuento'
                        ELSE 'Tiene descuento'
                    END AS EstadoDescuento
                FROM Ventas V
                JOIN Clientes C ON V.ClienteID = C.ClienteID
                JOIN Usuarios U ON V.UsuarioID = U.UsuarioID
                JOIN DetallesVenta DV ON V.VentaID = DV.VentaID
                JOIN Medicina M ON DV.MedicinaID = M.MedicinaID
                WHERE V.VentaID = @VentaID
                GROUP BY V.VentaID, C.Nombre, U.Nombre, V.FechaVenta, DV.Cantidad, M.Nombre, M.PrecioVenta, DV.Descuento";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Agregar el parámetro del ID de venta a la consulta
                        command.Parameters.AddWithValue("@VentaID", ventaID);

                        SqlDataReader reader = command.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        dtaVenta.DataSource = dataTable;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            DateTime fechaActual = DateTime.Now;// Obtener la fecha y hora actual
            DateTime soloFecha = fechaActual.Date;// Obtener solo la fecha (sin la hora) de la fecha actual
            lblFecha.Text = "Fecha Actual: " + fechaActual; // Mostrar la fecha actual en un control de etiqueta (label)
            string nombreM = comboBox1.Text;// Obtener el nombre del medicamento seleccionado en un ComboBox

            // Llamar a la función ObtenerPrecioMedicamento con el nombre del medicamento como parámetro
            ObtenerPrecioMedicamento(nombreM);

        }

        private void CalcularImporteTotal()
        {
            // Verificar si se ingresó un valor válido en txtCantidad
            if (int.TryParse(txtCant.Text, out int cantidad) && decimal.TryParse(textBoxPrecio.Text, out decimal precio))
            {
                // Calcular el importe total
                decimal importeTotal = cantidad * precio;

                // Mostrar el importe total en txtImporteTotal
                txtImporteTotal.Text = importeTotal.ToString();
            }
            else
            {
                // Si la cantidad o el precio no son válidos, mostrar un mensaje o realizar otra acción según tus necesidades
                txtImporteTotal.Text = "Error";
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Obtener el DNI del TextBox (supongamos que el TextBox se llama txtDNI)
            string dni = txtDNI.Text;

            // Crear una instancia de SqlConnection usando la cadena de conexión
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Abrir la conexión a la base de datos
                connection.Open();

                // Consulta SQL para obtener el ID, nombre del cliente y la categoría por medio del DNI
                string query = @"
                SELECT C.ClienteID, C.Nombre AS Cliente, Ca.Nombre AS Categoria
                FROM Clientes C
                JOIN Categorias Ca ON C.CategoriaID = Ca.CategoriaID
                WHERE C.DNI = @DNI";

                // Crear una instancia de SqlCommand para ejecutar la consulta
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Agregar el parámetro del DNI a la consulta
                    command.Parameters.AddWithValue("@DNI", dni);

                    // Ejecutar la consulta y obtener un SqlDataReader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Verificar si hay resultados
                        if (reader.Read())
                        {
                            // Mostrar el ID, nombre del cliente y la categoría
                            int clienteID = Convert.ToInt32(reader["ClienteID"]);
                            string nombreCliente = reader["Cliente"].ToString();
                            string nombreCategoria = reader["Categoria"].ToString();

                            // Muestra el ID del cliente en algún control (supongamos que hay un TextBox llamado txtClienteID)
                            txtIDC.Text = clienteID.ToString();

                            // Muestra el nombre del cliente y la categoría en los TextBox correspondientes
                            txtNombre.Text = nombreCliente;
                            txtCategoria.Text = nombreCategoria;
                        }
                        else
                        {
                            MessageBox.Show("Cliente no encontrado");
                        }
                    }
                }
            }
        }


        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            btnVerificarVenta.Enabled = true;
            OcultarGrupBoxs();
            try
            {
                // Obtener los valores necesarios desde los controles del formulario
                int clienteID = Convert.ToInt32(txtIDC.Text);
                int usuarioID = 1; // Puedes ajustar esto según el usuario actual
                DateTime fechaVenta = DateTime.Now.Date;
                decimal totalVenta = Convert.ToDecimal(txtImporteTotal.Text);

                // Crear una instancia de SqlConnection usando la cadena de conexión
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Abrir la conexión a la base de datos
                    connection.Open();

                    // Iniciar una transacción para garantizar la consistencia de los datos
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Obtener la categoría del cliente usando su ID
                            string obtenerCategoriaQuery = "SELECT Ca.Nombre FROM Clientes C JOIN Categorias Ca ON C.CategoriaID = Ca.CategoriaID WHERE C.ClienteID = @ClienteID;";
                            using (SqlCommand commandCategoria = new SqlCommand(obtenerCategoriaQuery, connection, transaction))
                            {
                                commandCategoria.Parameters.AddWithValue("@ClienteID", clienteID);
                                string nombreCategoria = commandCategoria.ExecuteScalar()?.ToString();

                                // Verificar si el cliente está afiliado y aplicar el descuento correspondiente
                                decimal descuentoCliente = (nombreCategoria == "Afiliado") ? 15m : 0;

                                // Insertar la venta en la tabla Ventas
                                string insertVentaQuery = @"
                                INSERT INTO Ventas (ClienteID, UsuarioID, FechaVenta, TotalVenta)
                                VALUES (@ClienteID, @UsuarioID, @FechaVenta, @TotalVenta);
                                SELECT SCOPE_IDENTITY();"; // Recuperar el ID de la venta recién insertada

                                using (SqlCommand commandVenta = new SqlCommand(insertVentaQuery, connection, transaction))
                                {
                                    commandVenta.Parameters.AddWithValue("@ClienteID", clienteID);
                                    commandVenta.Parameters.AddWithValue("@UsuarioID", usuarioID);
                                    commandVenta.Parameters.AddWithValue("@FechaVenta", fechaVenta);
                                    commandVenta.Parameters.AddWithValue("@TotalVenta", totalVenta * (1 - descuentoCliente)); // Aplicar el descuento

                                    // Obtener el ID de la venta recién insertada
                                    int ventaID = Convert.ToInt32(commandVenta.ExecuteScalar());

                                    // Insertar los detalles de la venta en la tabla DetallesVenta
                                    string insertDetallesQuery = @"
                                    INSERT INTO DetallesVenta (VentaID, Cantidad, PrecioUnitario, Descuento, TotalProducto, MedicinaID)
                                    VALUES (@VentaID, @Cantidad, @PrecioUnitario, @Descuento, @TotalProducto, @MedicinaID);";

                                    using (SqlCommand commandDetalles = new SqlCommand(insertDetallesQuery, connection, transaction))
                                    {
                                        // Obtener los valores necesarios desde los controles del formulario
                                        int cantidad = Convert.ToInt32(txtCant.Text);
                                        decimal precioUnitario = Convert.ToDecimal(textBoxPrecio.Text);
                                        decimal totalProducto = Convert.ToDecimal(txtImporteTotal.Text);
                                        string nombreMedicina = comboBox1.Text;

                                        // Obtener el ID de la medicina usando su nombre
                                        string obtenerMedicinaIDQuery = "SELECT MedicinaID FROM Medicina WHERE Nombre = @NombreMedicina;";
                                        using (SqlCommand commandMedicinaID = new SqlCommand(obtenerMedicinaIDQuery, connection, transaction))
                                        {
                                            commandMedicinaID.Parameters.AddWithValue("@NombreMedicina", nombreMedicina);
                                            int medicinaID = Convert.ToInt32(commandMedicinaID.ExecuteScalar());

                                            // Asignar los parámetros para la inserción de detalles de venta
                                            commandDetalles.Parameters.AddWithValue("@VentaID", ventaID);
                                            commandDetalles.Parameters.AddWithValue("@Cantidad", cantidad);
                                            commandDetalles.Parameters.AddWithValue("@PrecioUnitario", precioUnitario);
                                            commandDetalles.Parameters.AddWithValue("@Descuento", descuentoCliente);
                                            commandDetalles.Parameters.AddWithValue("@TotalProducto", totalProducto);
                                            commandDetalles.Parameters.AddWithValue("@MedicinaID", medicinaID);

                                            // Ejecutar la inserción de detalles de venta
                                            commandDetalles.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }

                            
                            transaction.Commit();// Confirmar la transacción
                            LimpiarControles();// Limpiar los controles del formulario después de realizar la venta
                            ListarVentas();// Actualizar la lista de ventas en el formulario

                            // Mostrar mensaje de éxito
                            MessageBox.Show("Venta Registrada Exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            // Revertir la transacción en caso de error
                            transaction.Rollback();
                            MessageBox.Show("Error al registrar la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error general: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LimpiarControles()
        {
            // Limpiar los controles del formulario después de realizar la venta
            txtIDC.Clear();
            txtDNI.Clear();
            txtNombre.Clear();
            txtCategoria.Clear();
            txtCant.Clear();
            textBoxPrecio.Clear();
            txtImporteTotal.Clear();
            comboBox1.SelectedIndex = -1;

        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
 
            ListarVentas(); // Llamar a la función para listar las ventas
            LimpiarControles();// Llamar a la función para limpiar los controles
            txtIDVENTA.Text = "";// Limpiar el campo de texto de ID de venta
            btnVerificarVenta.Enabled = true;// Habilitar el botón de verificar venta
            OcultarGrupBoxs();// Ocultar los GroupBoxs
            btnRegistrarVenta.Enabled = true;// Habilitar el botón de registrar venta

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            MostrarGrupBoxs();// Mostrar los GroupBoxs
            btnVerificarVenta.Enabled = false;// Deshabilitar el botón de verificar venta
            btnRegistrarVenta.Enabled = true;// Habilitar el botón de registrar venta
            btnRestart.Enabled = true;// Habilitar el botón de reiniciar
        }
    }
}
