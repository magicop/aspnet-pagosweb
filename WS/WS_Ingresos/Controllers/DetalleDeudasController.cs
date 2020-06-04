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
    public class DetalleDeudasController : ApiController
    {
        private IDetalleDeudasRepository _deudasRepository;

        public DetalleDeudasController(IDetalleDeudasRepository deudasRepository)
        {
            this._deudasRepository = deudasRepository;
        }

        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetDetalleDeudas/{periodo}")]

        public IHttpActionResult GetDetalleDeudas(int periodo)
        {
            try
            {
                var deudas = _deudasRepository.GetDetalleDeudas(periodo);

                if (deudas != null)
                {
                    return Ok(deudas);
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