using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Ingresos.Models.Dto
{
    public class Cargas
    {
        public int Correlativo { get; set; }
        public string Nombres { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public int Rut { get; set; }
        public string DV { get; set; }
        public string FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string Parentesco { get; set; }
        public string RutConcatenado { get; set; }
    }
}