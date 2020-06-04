using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Ingresos.Models.Dto
{
    public class CertificadoCotiza
    {
        public int Periodo { get; set; }
        public string Pactado { get; set; }
        public string Pagado { get; set; }
        public string DNP { get; set; }
        public string Licencia { get; set; }
        public DateTime Fecha { get; set; }
        public string FechaPago { get; set; }
    }
}