using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Ingresos.Models.Dto
{
    public class InfoPlanilla
    {
        public int folioPago { get; set; }
        public int tipo { get; set; }
        public int rutAfiliado { get; set; }
        public string isapre { get; set; }
        public string mail { get; set; }
        public long montoGastoCobTotal { get; set; }
        public long montoPagoTotal { get; set; }
        public List<DetallePeriodo> detallePeriodos { get; set; }   
    }
}