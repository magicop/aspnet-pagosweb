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
    public class DeudaController : Controller
    {

        #region Variables y Action Index

        // Llama a la API Rest para que ejecute el Webservice
        IngresosRest _restIngresos = new IngresosRest();

        #region Cargar periodos

        private List<SelectListItem> CargarMotivos()
        {
            var comboBox = new List<SelectListItem>();

            var periodosList = _restIngresos.GetPeriodos();

            foreach (var doc in periodosList)
            {
                SelectListItem item = new SelectListItem();
                item.Text = doc.codigo.ToString();
                item.Value = doc.descripcion;

                comboBox.Add(item);
            }

            return comboBox;
        }
        #endregion

        [HttpGet]
        public ActionResult Index()
        {
            #region Comentario
            //var mapper = new DtoToViewModel();
            //var model = new 
            //var model = mapper.ToDTO(_restIngresos.GetPeriodos());

            //var items1 = CargarMotivos();
            //model.lstPeriodos = new SelectList(items1, "Value", "Text");
            #endregion

            // Crea un model con el constructor para invocar los select list
            var model = new ListaModel();

            return View(model);
        }

        #endregion

        #region Action Resultado
        public ActionResult Resultado(ListaModel d)
        {
            try
            {
                DtoToViewModel ToDTO = new DtoToViewModel();
                // Obtiene las deudas en al BDD
                List<Deuda> model = _restIngresos.GetDetalleDeudas(Convert.ToInt32(d.CodPeriodo));
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }
        #endregion
    }
}