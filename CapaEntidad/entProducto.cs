using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntProducto
    {
        // Propiedad para obtener o establecer el ID del producto
        public int ProductoID { get; set; }

        // Propiedad para obtener o establecer el nombre del producto
        public string Nombre { get; set; }

        // Propiedad para obtener o establecer el precio del producto
        public decimal Precio { get; set; }

        // Propiedad para obtener o establecer el stock del producto
        public int Stock { get; set; }
    }

}
