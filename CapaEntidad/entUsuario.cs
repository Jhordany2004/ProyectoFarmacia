using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntUsuario
    {
        // Propiedad para obtener o establecer el ID del usuario
        public int UsuarioID { get; set; }

        // Propiedad para obtener o establecer el nombre del usuario
        public string Nombre { get; set; }

        // Propiedad para obtener o establecer la contraseña del usuario
        public string Contraseña { get; set; }
    }

}
