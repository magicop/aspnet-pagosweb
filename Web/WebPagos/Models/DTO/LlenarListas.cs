using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPagos.Models.DTO
{
    #region LlenarPeriodos
    public class LlenarPeriodos
    {
        public int codigo { get; set; }
        public string descripcion { get; set; }

        public SelectList lstPeriodos { get; set; }
    }
    #endregion

    #region LlenarTipopago
    public class LlenarTipopago
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
    }
    #endregion

    #region LlenarMediopago
    public class LlenarMediopago
    {
        public int codigo { get; set; }
        public string descripcion { get; set; }

        public SelectList lstMediopagos { get; set; }
    }
    #endregion

    #region LlenarEstadopago
    public class LlenarEstadopago
    {
        public int codigo { get; set; }
        public string descripcion { get; set; }

        public SelectList lstEstadopagos { get; set; }
    }
    #endregion

    #region LlenarIsapre
    public class LlenarIsapre
    {
        public int codigo { get; set; }
        public string descripcion { get; set; }

        public SelectList lstIsapres { get; set; }
    }
    #endregion
}