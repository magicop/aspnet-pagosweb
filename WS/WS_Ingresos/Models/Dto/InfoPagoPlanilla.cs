using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Ingresos.Models.Dto
{
    public class InfoPagoPlanilla
    {
        public long folioPago { get; set; }
        public int tipo { get; set; }/*Tipo --> 1 Pago de Deuda, 2 --> Pago de Cotizaciones, 3 --> Pago de Folio Negociación*/
        public string formaPago { get; set; }
        public int rutAfiliado { get; set; }
        public string isapre { get; set; }
        public int agencia { get; set; }                        
        public string accion { get; set; }
        public string canal { get; set; }
        public InfoPagoModulo infoPago { get; set; }
    }
}