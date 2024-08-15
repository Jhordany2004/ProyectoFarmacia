using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Conexion
    {
        // Patrón de Diseño Singleton
        // Creación de una única instancia de la clase Conexion
        private static readonly Conexion _instancia = new Conexion();
        // Propiedad que devuelve la única instancia de la clase Conexion
        public static Conexion Instancia
        {
            get { return Conexion._instancia; }
        }

        // Cadena de conexión a la base de datos SQL Server
        // Actualiza los detalles de conexión según tu servidor
        private string connectionString = "Server=.;Database=Farmacia;Integrated Security=True;";

        // Método para conectar a la base de datos
        public SqlConnection Conectar()
        {
            // Creación de una nueva conexión SQL utilizando la cadena de conexión
            SqlConnection cn = new SqlConnection(connectionString);

            try
            {
                // Intento de abrir la conexión SQL
                cn.Open();
            }
            catch (Exception ex)
            {
                // Manejo de excepciones en caso de errores de conexión
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
            }

            // Devolución de la conexión SQL
            return cn;
        }
    }
}
