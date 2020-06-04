using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Ingresos.Models.Dto
{
    public class CotizacionesSubsidio2
    {         
        public string periodoSub { get; set; }
        public string licenciaSub { get; set; }
        public int calTrabSub { get; set; }
        public int diasSub { get; set; }
        public string rentaNeta { get; set; }
        public string subsidio { get; set; }
    }
}