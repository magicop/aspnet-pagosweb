using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Ingresos.Models.Dto
{
    public class CertificadoSubsidioViewModel
    {
        public string fecha { get; set; }
        public string nombreAfiliado { get; set; }
        public string rutAfiliado { get; set; }
        public ICollection<CotizacionesSubsidio> cotizaciones { get; set; }
        public ICollection<CotizacionesSubsidio2> subsidios { get; set; }
    }
}