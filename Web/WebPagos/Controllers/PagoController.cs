using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPagos.Models.Dto.ViewModel;
using WebPagos.Models.DTO;
using WebPagos.Models.RestApi;

namespace WebPagos.Controllers
{
    public class PagoController : Controller
    {

        #region Variables y Action Index

        // Llama al Api Rest para llamar al Webservice
        IngresosRest _restIngresos = new IngresosRest();

        #region Cargar Listas
        private List<SelectListItem> CargarPeriodos()
        {
            var comboBoxPeriodos = new List<SelectListItem>();

            var periodosList = _restIngresos.GetPeriodos();

            foreach (var doc in periodosList)
            {
                SelectListItem item = new SelectListItem();
                item.Text = doc.descripcion;
                item.Value = doc.codigo.ToString();

                comboBoxPeriodos.Add(item);
            }

            return comboBoxPeriodos;
        }

        private List<SelectListItem> CargarTipopago()
        {
            var comboBoxTp = new List<SelectListItem>();

            var tpList = _restIngresos.GetTipopago();

            foreach (var doc in tpList)
            {
                SelectListItem item = new SelectListItem();
                item.Text = doc.descripcion;
                item.Value = doc.codigo.ToString();

                comboBoxTp.Add(item);
            }

            return comboBoxTp;
        }

        #endregion

        // GET: Pago
        public ActionResult Index()
        {
            #region Comentario
            //try
            //{
            //    //idSolicitud = Convert.ToInt64(Session["IdSolicitud"]);
            //    //var mapper = new DtoToViewModel();
            //    //var model = mapper.ToDTO_Tipopago(_restIngresos.GetTipopago());

            //    //PagoViewModel p = new PagoViewModel();
            //    //var items2 = CargarTipopago();
            //    //p.idFolio = 0;
            //    //p.montoPago = 0;
            //    //p.estadoPago = "";
            //    //p.fechaDesde = DateTime.Now;
            //    //p.fechaHasta = DateTime.Now;
            //    //p.tipoPago = new SelectList(items2, "Codigo", "Descripcion");
            //    //p.medioPago = "";
            //    //p.isapre = "";

            //    //return PartialView(model);
            //}
            //catch (Exception ex)
            //{
            //    return RedirectToAction("Error");
            //}
            #endregion
            return View(new PagoViewModel());
        }
        #endregion


        #region Resultado
        [HttpPost]
        public ActionResult Resultado(PagoViewModel p)
        {
            try
            {
                // Se pasa a clase DTO para mostrar el modelo
                DtoToViewModel ToDTO = new DtoToViewModel();
                List<Pago> model = _restIngresos.GetPagos(Convert.ToInt64(p.idFolio), p.rutPago, p.montoPago, Convert.ToInt32(p.CodEstadoPago), p.fechaDesde, p.fechaHasta, p.CodTipoPago, Convert.ToInt32(p.CodMedioPago), Convert.ToInt32(p.CodIsapre));
                return View(model);
            }
            catch (Exception ex)
            {
                //return RedirectToAction("Error");
                return View("Error");
            }
        }
        #endregion


        #region Action Regularizar
        [HttpGet]
        public ActionResult Regularizar(int rutPago, int medioPago)
        {
            DtoToViewModel ToDTO = new DtoToViewModel();

            _restIngresos.PostRegularizar(rutPago, medioPago);
            List<Pago> model = _restIngresos.GetPagoRut(rutPago);
            return View("Resultado", model);
        }
        #endregion

    }
}