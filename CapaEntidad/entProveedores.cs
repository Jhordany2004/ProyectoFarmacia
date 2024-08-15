using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entProveedores
    {
        // Propiedad para obtener o establecer el ID del proveedor
        public int ProveedorID { get; set; }

        // Propiedad para obtener o establecer el nombre del proveedor
        public string NombreProveedor { get; set; }

        // Propiedad para obtener o establecer la dirección del proveedor
        public string DireccionProveedor { get; set; }

        // Propiedad para obtener o establecer el teléfono del proveedor
        public string TelefonoProveedor { get; set; }
    }

}
