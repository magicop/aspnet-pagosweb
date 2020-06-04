using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Ingresos.Models.Dto
{
    public class CotizacionesSubsidio
    {       
        public string AfpCaja { get; set; }
        public int CalTrabCot { get; set; }
        public int DiasCot { get; set; }
        public string Imponible { get; set; }
        public string LicenciaCot { get; set; }
        public string PeriodoCot { get; set; }
        public string Salud { get; set; }
        public string SCesantia { get; set; }
    }
}