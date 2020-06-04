using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Ingresos.Models.Dto
{
    public class DetalleCotizaciones
    {
        public int RutEmpleador { get; set; }
        public string RutEmpleadorDV { get; set; }
        public string NombreRazonSocial { get; set; }
        public string PeriodoPago { get; set; }
        public string FechaPago { get; set; }
        public string MontoPago { get; set; }
    }
}