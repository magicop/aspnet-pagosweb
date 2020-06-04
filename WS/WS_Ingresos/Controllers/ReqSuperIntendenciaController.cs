using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WS_Ingresos.Exceptions;
using WS_Ingresos.Filters;
using WS_Ingresos.Models.Contracts;
using WS_Ingresos.Resources;

namespace WS_Ingresos.Controllers
{
    public class ReqSuperIntendenciaController : ApiController
    {
        IReqSuperIntendenciaRepository _reqSuperIntendenciaRepository;

        public ReqSuperIntendenciaController(IReqSuperIntendenciaRepository reqSuperIntendenciaRepository)
        {
            this._reqSuperIntendenciaRepository = reqSuperIntendenciaRepository;
        }

        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetEstadoByRut/{isapre}/{rut}")]
        public IHttpActionResult GetEstadoByRut(string isapre, int rut)
        {
            try
            {
                var reqsSuper = _reqSuperIntendenciaRepository.GetEstadoByRut(isapre,rut);
                if (reqsSuper != null)
                {
                    return Ok(reqsSuper);
                }
                return NotFound();

            }
            catch (IngresosException)
            {
                return BadRequest(string.Format(ExceptionMessages.Ex_ReqSuperIntendencia, isapre, rut));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetHistoricoByRut/{isapre}/{rut}")]
        public IHttpActionResult GetHistoricoByRut(string isapre, int rut)
        {
            try
            {
                var reqsSuper = _reqSuperIntendenciaRepository.GetHistoricoByRut(isapre, rut);
                if (reqsSuper != null)
                {
                    return Ok(reqsSuper);
                }
                return NotFound();

            }
            catch (IngresosException)
            {
                return BadRequest(string.Format(ExceptionMessages.Ex_ReqSuperIntend, isapre, rut));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
