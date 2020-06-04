using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Ingresos.Models.Dto
{
    
    public class Cotizaciones
    {
        public string PeriodoPago { get; set; }
        public string MontoUF { get; set; }
        public string Unidad { get; set; }
        public string MontoAPagar { get; set; }
        public string FechaPago { get; set; }
        public string ValorGES { get; set; }
        public string NewReajuste { get; set; }
        public string NewInteres { get; set; }
        public string NewRecargo { get; set; }
        public string NewValorTotal { get; set; }
    }
}