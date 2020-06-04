using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WS_Ingresos.Exceptions;
using WS_Ingresos.Filters;
using WS_Ingresos.Models.Contracts;
using WS_Ingresos.Models.Dto;
using WS_Ingresos.Resources;

namespace WS_Ingresos.Controllers
{
    public class PagosController : ApiController
    {
        private IConsultaWebRepository _pagosRepository;

        public PagosController(IConsultaWebRepository pagosRepository)
        {
            this._pagosRepository = pagosRepository;
        }


        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetPagos/{idfolio?}/{rut?}/{monto?}/{estado?}/{fechaDesde?}/{fechaHasta?}/{tipoPago?}/{medioPago?}/{*isapre}")]

        public IHttpActionResult GetPagos(int? idfolio, int? rut, int? monto, int? estado, DateTime? fechaDesde, DateTime? fechaHasta, string tipoPago, int? medioPago, int? isapre)
        {
            try
            {

                var aux_fechad = ((DateTime)fechaDesde).ToShortDateString();
                var aux_fechah = ((DateTime)fechaHasta).ToShortDateString();

                var pagos = _pagosRepository.GetPagos(idfolio, rut, monto, estado, Convert.ToDateTime(aux_fechad), Convert.ToDateTime(aux_fechah), tipoPago, medioPago, isapre);

                if (pagos != null)
                {
                    return Ok(pagos);
                }
                return NotFound();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [SecureResourceAttribute]
        [Route("api/RegularizarPago/{rut}/{i_wtp_id}")]
        public IHttpActionResult RegularizarPago(int rut, int i_wtp_id)
        {
            try
            {
                var pagos = _pagosRepository.RegularizarPago(rut, i_wtp_id);

                if (pagos != false)
                {
                    return Ok(pagos);
                }
                return NotFound();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetPagoRut/{rut}/")]

        public IHttpActionResult GetPagoRut(int rut)
        {
            try
            {
                var pagos = _pagosRepository.GetPagoRut(rut);

                if (pagos != null)
                {
                    return Ok(pagos);
                }
                return NotFound();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }



    }
}