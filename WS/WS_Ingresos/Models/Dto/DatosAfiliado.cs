using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Ingresos.Models.Dto
{
    public class DatosAfiliado
    {
        public string nombreCompleto { get; set; }
        public string rutCompleto { get; set; }
        public string direccion { get; set; }
        public string comuna { get; set; }
        public string ciudad { get; set; }
        public long fono { get; set; }
    }
}