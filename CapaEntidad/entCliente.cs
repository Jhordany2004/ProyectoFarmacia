using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntCliente
    {
        // Propiedad para obtener o establecer el ID del cliente
        public int ClienteID { get; set; }

        // Propiedad para obtener o establecer el nombre del cliente
        public string Nombre { get; set; }

        // Propiedad para obtener o establecer el DNI del cliente
        public int DNI { get; set; }

        // Propiedad para obtener o establecer el ID de la categoría del cliente
        public int CategoriaID { get; set; }
    }

}
