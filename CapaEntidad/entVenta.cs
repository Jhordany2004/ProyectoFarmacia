using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntVenta
    {
        // Propiedad para obtener o establecer el ID de la venta
        public int VentaID { get; set; }

        // Propiedad para obtener o establecer el ID del cliente
        public int ClienteID { get; set; }

        // Propiedad para obtener o establecer el ID del usuario
        public int UsuarioID { get; set; }

        // Propiedad para obtener o establecer la fecha de la venta
        public DateTime FechaVenta { get; set; }

        // Propiedad para obtener o establecer el total de la venta
        public decimal TotalVenta { get; set; }
    }

}
