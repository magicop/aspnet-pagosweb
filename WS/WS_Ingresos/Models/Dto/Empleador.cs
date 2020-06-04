using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Ingresos.Models.Dto
{
    public class Empleador
    {
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string nombreRazonSocial { get; set; }
        public int rut { get; set; }
        public string dv { get; set; }
        public string calle { get; set; }
        public string numero { get; set; }
        public string departamento { get; set; }
        public string block { get; set; }
        public string villa { get; set; }
        public string comuna { get; set; }
        public string ciudad { get; set; }
        public int region { get; set; }
    }
}