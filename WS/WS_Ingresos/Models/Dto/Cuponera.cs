using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Ingresos.Models.Dto
{
    public class Cuponera
    {
        public string Nombre { get; set; }
        public string Rut { get; set; }
        public string Periodo { get; set; }
        public string FechaVencimiento { get; set; }
        public string Monto { get; set; }
        public string Direccion { get; set; }
        public string Block { get; set; }
        public string Depto { get; set; }
        public string Villa { get; set; }
        public string FechaUF { get; set; }
        public string Folio { get; set; }
        public string Ciudad { get; set; }
        public string Comuna { get; set; }
        public string Plan { get; set; }
        public string Independiente { get; set; }
    }
}