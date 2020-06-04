using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Ingresos.Models.Dto
{
    public class DetallePeriodo
    {
        public int periodoRemun { get; set; }
        public int periodoRecau { get; set; }
        public int subProducto { get; set; }
        public long montoPago { get; set; }
        public long montoGastoCob { get; set; }
        public long montoDeuda { get; set; }
        public long montoReajuste { get; set; }
        public long montoInteres { get; set; }
        public long montoRecargo { get; set; }
        public long montoHonorario { get; set; }
    }
}