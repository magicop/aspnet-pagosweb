using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Ingresos.Models.Dto
{
    public class ReqSuperIntendencia
    {
        public string TipoCotizacion { get; set; }
        public string Rut { get; set; }
        public string Periodo { get; set; }
        public string Estado { get; set; }
        public string NombreAseguradora { get; set; }
        public string Deso { get; set; }

        //Pagos Historicos
        public string isapre { get; set; }
        public string fecEmision { get; set; }
        public string motivo { get; set; }
        public long monto { get; set; }
        public string formaPago { get; set; }
        public long nroDocumento { get; set; }
        public string estado { get; set; }
        public string procRevalidacion { get; set; }
        public long FecEmisionOrd { get; set; }
        public long chedEstado { get; set; }
        public string pagEscalafon { get; set; }

        //MAN-39751
        public string ptipoRut { get; set; }
    }
}