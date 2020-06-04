using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Ingresos.Models.Dto
{
    public class PagoDeudaModel
    {
        public int Rut { get; set; }
        public int Periodo { get; set; }
        public int Monto { get; set; }
        public long Folio { get; set; }
        public long SubProducto { get; set; }
        public int Deuda { get; set; }
        public int Reajuste { get; set; }
        public int Interes { get; set; }
        public int Recargo { get; set; }
        public int Gasto { get; set; }
        public int Horario { get; set; }
    }
}