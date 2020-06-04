using System;
using System.Collections.Generic;
using System.Web;

namespace WS_Ingresos.Models.Dto
{
    public class Periodo
    {
        public string PeriodoPago { get; set; }
        public string MontoPago { get; set; }
        public string FechaPago { get; set; }
    }
}