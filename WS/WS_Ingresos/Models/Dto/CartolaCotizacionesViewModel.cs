using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Ingresos.Models.Dto
{
    public class CartolaCotizacionesViewModel
    {
        public string Fecha { get; set; }
        public string Isapre { get; set; }
        public ICollection<DetalleCotizaciones> DetCotizaciones { get; set; }
        public Empleador DatEmpleador { get; set; }
        public DatosAfiliado DatAfiliado { get; set; }
    }
}