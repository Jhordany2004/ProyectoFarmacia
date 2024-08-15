using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntDetalleVenta
    {
        // Propiedad para obtener o establecer el ID del detalle
        public int DetalleID { get; set; }

        // Propiedad para obtener o establecer el ID de la venta
        public int VentaID { get; set; }

        // Propiedad para obtener o establecer el ID del producto
        public int ProductoID { get; set; }

        // Propiedad para obtener o establecer la cantidad del producto
        public int Cantidad { get; set; }

        // Propiedad para obtener o establecer el precio unitario del producto
        public decimal PrecioUnitario { get; set; }

        // Propiedad para obtener o establecer el descuento aplicado al producto
        public decimal Descuento { get; set; }

        // Propiedad para obtener o establecer el total del producto (Cantidad * PrecioUnitario - Descuento)
        public decimal TotalProducto { get; set; }
    }

}
