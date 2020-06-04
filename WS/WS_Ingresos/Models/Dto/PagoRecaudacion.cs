using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Ingresos.Models.Dto
{
    public class PagoRecaudacion
    {
        public string nombre { get; set; }
        public long folioPago { get; set; }
        public int rutAfiliado { get; set; }
        public string isapre { get; set; }
        public string descripcionTipo { get; set; }
        public DateTime fechaPago { get; set; }
        public string formaPago { get; set; }
        public string mail { get; set; }
        public long montoGastoCobTotal { get; set; }
        public long montoPagoTotal { get; set; }
        public List<DetallePeriodo> detallesPago { get; set; }
    }
}