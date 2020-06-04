using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WS_Ingresos.Exceptions;
using WS_Ingresos.Filters;
using WS_Ingresos.Models.Contracts;
using WS_Ingresos.Models.Dto;
using WS_Ingresos.Resources;

namespace WS_Ingresos.Controllers
{
    public class PlanillaController : Controller
    {
        private ICotizacionesRepository _cotizacionesRepository;
        private IAfiliadoRepository _afiliadoRepository;
        private IEmpleadorRepository _empleadorRepository;

        public PlanillaController(ICotizacionesRepository cotizacionesRepository, IAfiliadoRepository afiliadoRepository, IEmpleadorRepository empleadorRepository)
        {
            this._cotizacionesRepository = cotizacionesRepository;
            this._afiliadoRepository = afiliadoRepository;
            this._empleadorRepository = empleadorRepository;
        }

        public ActionResult CartolaCotizaciones(int rutAfil, string isapre)
        {
            try
            {
                CartolaCotizacionesViewModel model = new CartolaCotizacionesViewModel();

                var rutEmpleador = _afiliadoRepository.GetDatosEmpleador(rutAfil, isapre).rut;
                model.Isapre = isapre;
                model.DatAfiliado = _afiliadoRepository.GetDatosAfiliado(rutAfil, isapre);
                model.DatEmpleador = _empleadorRepository.GetDatosEmpleador(rutEmpleador, isapre);
                model.DetCotizaciones = _cotizacionesRepository.GetDetalleCotizaciones(rutAfil, isapre, model.DatAfiliado.nombreCompleto);
                model.Fecha = Utils.ConstruirFecha();

                return View(model);
            }      
            catch (Exception)
            {
                return null;
            }
        }
    }
}