using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Ingresos.Models.Dto
{
    public class CartolaExcedentesViewModel
    {
        public string nombreAfiliado { get; set; }
        public string rutAfiliado { get; set; }
        public string direccion { get; set; }
        public string comuna { get; set; }
        public string ciudad { get; set; }
        public long fono { get; set; }
        public string fecha { get; set; }
        public Empleador empleador { get; set; }
        public ICollection<Excedente> excedentes { get; set; }
    }
}