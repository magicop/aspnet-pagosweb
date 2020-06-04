using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Ingresos.Models.Dto
{
    public class DetalleExcesosRegistroIndividual
    {
        public String periodo { get; set; }
        public List<DevolucionExcesos> devoluciones { get; set; }
        public List<InventarioDocumento> documentos { get; set; }
    }
}