using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Ingresos.Models.Dto
{
    public class SolicitudDevolucionExcesos
    {
        public int p_Afil_nRut { get; set; }
        public int p_Agencia_Destino { get; set; }
        public string p_Canal { get; set; }
        public string p_CtaCte_Banco { get; set; }
        public string p_CtaCte_Numero { get; set; }
        public string p_CtaCte_Tipo { get; set; }
        public string p_Forma_Pago { get; set; }
        public string p_Isapre { get; set; }
        //public int p_Numero_Solicitud { get; set; }
    }
}