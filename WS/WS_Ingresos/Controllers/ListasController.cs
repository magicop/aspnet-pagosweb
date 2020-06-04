using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WS_Ingresos.Filters;
using WS_Ingresos.Models.Contracts;

namespace WS_Ingresos.Controllers
{
    public class ListasController : ApiController
    {
        #region Variable y constructor

        private IListasPagoWebRepository _listasRepository;

        public ListasController(IListasPagoWebRepository listasRepository)
        {
            this._listasRepository = listasRepository;
        }
        #endregion

        #region ListaPeriodos
        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetListaPeriodos/")]

        public IHttpActionResult GetPeriodos()
        {
            try
            {
                var periodos = _listasRepository.GetPeriodos();

                if (periodos != null)
                {
                    return Ok(periodos);
                }
                return NotFound();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
        #endregion

        #region ListaTipopago
        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetListaTipopagos/")]

        public IHttpActionResult GetTipopago()
        {
            try
            {
                var tipopago = _listasRepository.GetTipopago();

                if (tipopago != null)
                {
                    return Ok(tipopago);
                }
                return NotFound();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
        #endregion

        #region ListaMediopago
        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetListaMediopagos/")]

        public IHttpActionResult GetMediopago()
        {
            try
            {
                var tipopago = _listasRepository.GetMediopago();

                if (tipopago != null)
                {
                    return Ok(tipopago);
                }
                return NotFound();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
        #endregion

        #region ListaEstadopago
        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetListaEstadopagos/")]

        public IHttpActionResult GetEstadopago()
        {
            try
            {
                var tipopago = _listasRepository.GetEstadopago();

                if (tipopago != null)
                {
                    return Ok(tipopago);
                }
                return NotFound();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
        #endregion

        #region ListaIsapre
        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetListaIsapres/")]

        public IHttpActionResult GetIsapre()
        {
            try
            {
                var tipopago = _listasRepository.GetIsapre();

                if (tipopago != null)
                {
                    return Ok(tipopago);
                }
                return NotFound();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
        #endregion
    }
}