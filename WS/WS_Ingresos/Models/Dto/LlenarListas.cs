using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Ingresos.Models.Dto
{
    #region Clase LlenarPeriodos
    public class LlenarPeriodos
    {
        public int codigo { get; set; }
        public string descripcion { get; set; }
    }
    #endregion

    #region Clase LlenarTipopago
    public class LlenarTipopago{
        public string codigo { get; set; }
        public string descripcion { get; set; }
    }
    #endregion

    #region Clase LlenarMediopago
    public class LlenarMediopago
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
    }
    #endregion

    #region Clase LlenarEstadopago
    public class LlenarEstadopago
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
    }
    #endregion

    #region Clase LlenarIsapre
    public class LlenarIsapre
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
    }
    #endregion
}