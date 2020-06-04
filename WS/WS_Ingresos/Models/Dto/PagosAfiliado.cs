using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Ingresos.Models.Dto
{
    public class PagosAfiliado
    {
        public string CuentaNumero { get; set; }
        public string BancoId { get; set; }
        public string CuentaTipo { get; set; }
    }
}