using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPagos.Models.RestApi;

namespace WebPagos.Models.DTO
{
    public class ListaModel
    {
        // Crea el modelo para asignar los valores al combobox

        #region Accesadores y Mutadores
        public string CodPeriodo { get; set; }
        public SelectList LstPeriodos { get; set; }
        public string CodMediopago { get; set; }
        public SelectList LstMediopagos { get; set; }
        public string CodEstadopago { get; set; }
        public SelectList LstEstadopagos { get; set; }
        public string CodIsapre { get; set; }
        public SelectList LstIsapres { get; set; }
        #endregion

        #region Constructor
        // Inicializa el constructor sin parámetros y le asigna los valores correspondientes
        public ListaModel()
        {
            var _restIngresos = new RestApi.IngresosRest();

            var lstPeriodos =  _restIngresos.GetPeriodos();
            LstPeriodos = new SelectList(lstPeriodos, "codigo", "descripcion");

            var lstMediopagos = _restIngresos.GetMediopago();
            LstMediopagos = new SelectList(lstMediopagos, "codigo", "descripcion");

            var lstEstadopagos = _restIngresos.GetEstadopago();
            LstEstadopagos = new SelectList(lstEstadopagos, "codigo", "descripcion");

            var lstIsapres = _restIngresos.GetIsapre();
            LstIsapres = new SelectList(lstIsapres, "codigo", "descripcion");
        }
        #endregion

    }

}