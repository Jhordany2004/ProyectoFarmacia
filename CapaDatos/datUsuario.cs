using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class datUsuario
    {
        // Actualiza los detalles de conexión según tu servidor de Azure SQL
        private string connectionString = "Server=.;Database=Farmacia;Integrated Security=True;";

        #region Singleton   
        // Patrón de Diseño Singleton
        // Creación de una única instancia de la clase datUsuario
        private static readonly datUsuario _instancia = new datUsuario();
        // Propiedad que devuelve la única instancia de la clase datUsuario
        public static datUsuario Instancia
        {
            get { return datUsuario._instancia; }
        }
        #endregion

        // Método para validar las credenciales de un usuario
        public bool ValidarCredenciales(string nombreUsuario, string contraseña)
        {
            // Creación de una nueva conexión SQL utilizando la cadena de conexión
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Apertura de la conexión SQL
                connection.Open();
                // Consulta SQL que cuenta el número de usuarios con el nombre y la contraseña proporcionados
                string query = "SELECT COUNT(*) FROM Usuarios WHERE Nombre = @Nombre AND Contraseña = @Contraseña";
                // Creación de un nuevo comando SQL con la consulta y la conexión
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Añadir el nombre de usuario y la contraseña como parámetros al comando SQL
                    command.Parameters.AddWithValue("@Nombre", nombreUsuario);
                    command.Parameters.AddWithValue("@Contraseña", contraseña);
                    // Ejecución del comando SQL y conversión del resultado a int
                    int count = (int)command.ExecuteScalar();
                    // Si el conteo es mayor que 0, las credenciales son válidas y se devuelve true. Si no, se devuelve false.
                    return count > 0;
                }
            }
        }
    }
}
