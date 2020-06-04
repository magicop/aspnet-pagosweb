using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPagos.Models.DTO
{
    public class Deuda
    {

        #region Accesadores y Mutadores
        public int folioPago { get; set; }

        public int premun { get; set; }

        public int csubproducto { get; set; }

        public int mdeuda { get; set; }

        public int mreajuste { get; set; }

        public int minteres { get; set; }

        public int mrecargo { get; set; }

        public int mhonorario { get; set; }

        public int mpagototal { get; set; }

        #endregion

    }

}