using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Ingresos.Models.Dto
{
    public class DetalleDeuda
    {        
        public double ValorDeuda { get; set; }
        public double Gastos { get; set; }
        public string Glosa { get; set; }
        public double Interes { get; set; }
        public string Periodo { get; set; }
        public string Producto { get; set; }
        public double Reajuste { get; set; }
        public double Recargo { get; set; }
        public string SubProducto { get; set; }
        public double InteresRec { get; set; }
        public double Total { get; set; }
    }
}