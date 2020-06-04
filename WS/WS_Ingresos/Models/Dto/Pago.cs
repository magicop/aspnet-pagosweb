using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Ingresos.Models.Dto
{
    public class Pago
    {
        public long idFolio { get; set; }

        public int rutPago { get; set; }

        public int montoPago { get; set; }

        public int estadoPago { get; set; }

        public DateTime fechaPago { get; set; }

        public string tipoPago { get; set; }

        public int medioPago { get; set; }

        public int isapre { get; set; }
    }
}