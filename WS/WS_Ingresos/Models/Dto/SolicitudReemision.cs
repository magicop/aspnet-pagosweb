using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WS_Ingresos.Models.Dto
{
    public class SolicitudReemision
    {
        public String Rut { get; set; }
        public String Sociedad { get; set; }
        public String IdMaestro { get; set; }
        public String Cuenta { get; set; }
        public String DocumentoNumero { get; set; } //Número de documento
        public String FechaDoc { get; set; } // Fecha de Emisión
        public String ClaseDoc { get; set; }
        public String DocPago { get; set; }
        public String Valor { get; set; } //Monto
        public String Estado { get; set; }
        public String MotivoGiro { get; set; }
        public String Posicion { get; set; }
        public String Canal { get; set; }

        public String FormaPago { get; set; }
        public int AgenciaDestino { get; set; }
        public String CtaCteNumero { get; set; }
        public String CtaCteTipo { get; set; }
        public String CtaCteBanco { get; set; }
        public String FormaRevalidacion { get; set; } //Forma Revalidación (0=en línea, "n"=Procedimiento "n")

        //public String GlosaTipoDocumento { get; set; } //Tipo de Documento
        //public String GlosaEstado { get; set; } // Estado     
    }
}