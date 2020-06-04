using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPagos.Models.DTO
{
    public class Pago
    {
        #region Accesadores y Mutadores
        public long idFolio { get; set; }

        public int rutPago { get; set; }

        public int montoPago { get; set; }

        public string estadoPago { get; set; }

        public DateTime fechaPago { get; set; }

        public string tipoPago { get; set; }

        public int medioPago { get; set; }

        public string isapre { get; set; }
        #endregion

    }
}