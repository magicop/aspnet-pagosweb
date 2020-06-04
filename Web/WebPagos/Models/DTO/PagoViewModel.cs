using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPagos.Models.DTO
{
    public class PagoViewModel
    {

        #region Accesadores y Mutadores
        public long idFolio { get; set; }
        public int rutPago { get; set; }
        public int montoPago { get; set; }
        public DateTime fechaDesde { get; set; }
        public DateTime fechaHasta { get; set; }
        public string CodEstadoPago { get; set; }
        public SelectList estadoPago { get; set; }
        public string CodMedioPago { get; set; }
        public SelectList medioPago { get; set; }
        public string CodIsapre { get; set; }
        public SelectList isapre { get; set; }
        public string CodTipoPago { get; set; }
        public SelectList tipoPago { get; set; }


        #endregion

        #region Constructor para inicializar el combobox
        public PagoViewModel()
        {
            //var _rest = new RestApi.IngresosRest();
            //var lstInfo = _rest.GetTipopago();
            //tipoPago = new SelectList(lstInfo, "codigo", "descripcion");

            tipoPago = new SelectList(new RestApi.IngresosRest().GetTipopago(), "codigo", "descripcion");
            estadoPago = new SelectList(new RestApi.IngresosRest().GetEstadopago(), "codigo", "descripcion");
            medioPago = new SelectList(new RestApi.IngresosRest().GetMediopago(), "codigo", "descripcion");
            isapre = new SelectList(new RestApi.IngresosRest().GetIsapre(), "codigo", "descripcion");

        }
        #endregion

    }
}