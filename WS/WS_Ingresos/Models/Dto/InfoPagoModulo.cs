using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Ingresos.Models.Dto
{
    public class InfoPagoModulo
    {
        public string codigoAutorizacion { get; set; }
        public long? dbTotal { get; set; }
        public DateTime? fechaContable { get; set; }
        public DateTime? fechaPago { get; set; }
        public string marca { get; set; }
        public long? monto { get; set; }
        public string numeroCta { get; set; }
        public string numeroTarjeta { get; set; }
        public string numBoleta { get; set; }
        public string numOperacion { get; set; }
        public string terminal { get; set; }
        public string tipoTarjeta { get; set; }
    }
}