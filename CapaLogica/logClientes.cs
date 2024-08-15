using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logClientes
    {
        // Cadena de conexión a la base de datos SQL Server
        private string connectionString = "Server=.;Database=Farmacia;Integrated Security=True;";

        #region Singleton
        // Patrón de Diseño Singleton
        // Creación de una única instancia de la clase logClientes
        private static readonly logClientes _instancia = new logClientes();
        // Propiedad que devuelve la única instancia de la clase logClientes
        public static logClientes Instancia
        {
            get { return logClientes._instancia; }
        }
        #endregion

        // Método para obtener una lista de clientes
        public List<EntCliente> ObtenerClientes()
        {
            try
            {
                // Obtener la lista de clientes desde la capa de datos
                List<EntCliente> listaClientes = datCliente.Instancia.ObtenerClientes();

                // Devolver la lista de clientes
                return listaClientes;
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                throw new Exception("Error al obtener clientes", ex);
            }
        }

        // Método para editar un proveedor
        public void EditaProveedor(entProveedores En)
        {
            // Llamar al método EditarProvedor de la capa de datos para editar el proveedor
            datCliente.Instancia.EditarProvedor(En);
        }

    }
}
