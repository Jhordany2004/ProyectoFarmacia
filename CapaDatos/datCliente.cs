using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class datCliente
    {

        // Actualiza los detalles de conexión según tu servidor de Azure SQL
        private string connectionString = "Server=.;Database=Farmacia;Integrated Security=True;";

        #region Singleton   
        // Patrón de Diseño Singleton
        // Creación de una única instancia de la clase datCliente
        private static readonly datCliente _instancia = new datCliente();
        // Propiedad que devuelve la única instancia de la clase datCliente
        public static datCliente Instancia
        {
            get { return datCliente._instancia; }
        }
        #endregion

        // Método para obtener una lista de clientes
        public List<EntCliente> ObtenerClientes()
        {
            // Creación de una nueva lista de clientes
            List<EntCliente> listaClientes = new List<EntCliente>();

            try
            {
                // Creación de una nueva conexión SQL utilizando la cadena de conexión
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Apertura de la conexión SQL
                    connection.Open();
                    // Consulta SQL para seleccionar los detalles de los clientes
                    string query = "SELECT ClienteID, Nombre, DNI, CategoriaID FROM Clientes";
                    // Creación de un nuevo comando SQL con la consulta y la conexión
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Ejecución del comando SQL y obtención de los resultados
                        SqlDataReader reader = command.ExecuteReader();
                        // Lectura de los resultados
                        while (reader.Read())
                        {
                            // Creación de un nuevo cliente con los detalles obtenidos
                            EntCliente cliente = new EntCliente
                            {
                                ClienteID = Convert.ToInt32(reader["ClienteID"]),
                                Nombre = reader["Nombre"].ToString(),
                                DNI = int.TryParse(reader["DNI"].ToString(), out int dniValue) ? dniValue : 0,
                                CategoriaID = Convert.ToInt32(reader["CategoriaID"])
                            };
                            // Añadir el cliente a la lista de clientes
                            listaClientes.Add(cliente);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                throw new Exception("Error al obtener clientes", ex);
            }

            // Devolver la lista de clientes
            return listaClientes;
        }

        // Método para editar un proveedor
        public Boolean EditarProvedor(entProveedores Pro)
        {
            SqlCommand cmd = null;
            Boolean edita = false;
            try
            {
                // Creación de una nueva conexión SQL utilizando la cadena de conexión
                SqlConnection oconexion = new SqlConnection(connectionString);
                // Creación de un nuevo comando SQL para el procedimiento almacenado spEditaProvedor
                cmd = new SqlCommand("spEditaProvedor", oconexion);
                cmd.CommandType = CommandType.StoredProcedure;
                // Añadir los detalles del proveedor como parámetros al comando SQL
                cmd.Parameters.AddWithValue("@ProveedorID", Pro.ProveedorID);
                cmd.Parameters.AddWithValue("@NombreProveedor", Pro.NombreProveedor);
                cmd.Parameters.AddWithValue("@DireccionProveedor", Pro.DireccionProveedor);
                cmd.Parameters.AddWithValue("@TelefonoProveedor", Pro.TelefonoProveedor);

                // Apertura de la conexión SQL
                oconexion.Open();
                // Ejecución del comando SQL y obtención del número de filas afectadas
                int i = cmd.ExecuteNonQuery();
                // Si el número de filas afectadas es mayor que 0, el proveedor se ha editado correctamente
                if (i > 0)
                {
                    edita = true;
                }
            }
            catch (Exception e)
            {
                // Lanzar la excepción
                throw e;
            }
            finally
            {
                // Cerrar la conexión SQL
                cmd.Connection.Close();
            }
            // Devolver si el proveedor se ha editado correctamente
            return edita;
        }
    }
}
