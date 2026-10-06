using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAgenda.Modelos
{
    public class Contactos
    {
        public int ID_CONTACTO { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public string TELEFONO { get; set; }
        public string CORREO { get; set; }
        public DateTime FECHA_ADICION { get; set; }
        public string ADICIONADO_POR { get; set; }
        public DateTime? FECHA_MODIFICACION { get; set; }
        public string MODIFICADO_POR { get; set; }
    }
}