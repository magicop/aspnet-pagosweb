using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Ingresos.Models.Dto
{
    public class InfoFolioNegociacion
    {
        public long folioPago { get; set; }
        public string fechaGeneracion { get; set; }
        public long montoPago { get; set; }
        public List<Periodo> periodos { get; set; }
    }
}