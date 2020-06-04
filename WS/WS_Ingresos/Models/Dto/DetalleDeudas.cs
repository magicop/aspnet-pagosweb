using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Ingresos.Models.Dto
{
    public class DetalleDeudas
    {
        public int folioPago { get; set; }

        public int premun { get; set; }

        public int csubproducto { get; set; }

        public int mdeuda { get; set; }

        public int mreajuste { get; set; }

        public int minteres { get; set; }

        public int mrecargo { get; set; }

        public int mhonorario { get; set; }

        public int mpagototal { get; set; }
    }

}