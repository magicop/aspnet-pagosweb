using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Ingresos.Models.Dto
{
    public class CertificadoDeudaViewModel
    {
        public string nombreAfiliado { get; set; }
        public string rutAfiliado { get; set; }
        public string direccion { get; set; }
        public string comuna { get; set; }
        public string ciudad { get; set; }
        public long fono { get; set; }
        public double gastosCobranza { get; set; }
        public double totalGeneral { get; set; }
        public string fecha { get; set; }
        public ICollection<DetalleDeuda> deudas { get; set; }
    }
}