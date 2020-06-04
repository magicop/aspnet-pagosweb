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
    public class DevolucionExcesosController : ApiController
    {
        private IDevolucionExcesosRepository _devolucionExcesosRepository;

        public DevolucionExcesosController(IDevolucionExcesosRepository devolucionExcesosRepository)
        {
            this._devolucionExcesosRepository = devolucionExcesosRepository;
        }

        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetSaldoExcesosDia/{rut}/{isapre}/{canal}")]
        public IHttpActionResult GetSaldoExcesosDia(int rut, string isapre, string canal)
        {
            try
            {
                var devExcesos = _devolucionExcesosRepository.GetSaldoExcesosDia(rut, isapre, canal);
                if (devExcesos != null)
                {
                    return Ok(devExcesos);
                }
                return NotFound();

            }
            catch (IngresosException)
            {
                return BadRequest(string.Format(ExceptionMessages.Ex_DevolucionExcesos,rut,isapre,canal));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetDetalleExcesosRegistroIndividual/{rut}/{isapre}/{canal}")]
        public IHttpActionResult GetDetalleExcesosRegistroIndividual(int rut, string isapre, string canal)
        {
            try
            {
                var detalleExcesosRI = _devolucionExcesosRepository.GetDetalleExcesosRegistroIndividual(rut, isapre, canal);
                if (detalleExcesosRI != null)
                {
                    return Ok(detalleExcesosRI);
                }
                return NotFound();

            }
            catch (IngresosException)
            {
                return BadRequest(string.Format(ExceptionMessages.Ex_DevolucionExcesosRI, rut, isapre, canal));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [SecureResourceAttribute]
        [Route("api/PostMedioPagoExceso")]
        public IHttpActionResult PostMedioPagoExceso([FromBody] SolicitudDevolucionExcesos solicitud)
        {
            try
            {
                string respuesta = _devolucionExcesosRepository.PostSolicitudDevolucionExcesos(solicitud);
                if (respuesta != null)
                {
                    var Respuesta = new { Resultado = respuesta };
                    return Ok(Respuesta);
                }
                return NotFound();

            }
            catch (IngresosException)
            {
                return BadRequest(string.Format(ExceptionMessages.Ex_SolicitudDevolucionExcesos, solicitud.p_Afil_nRut, solicitud.p_Isapre));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [SecureResourceAttribute]
        [Route("api/PostSolicitudReemision")]
        public IHttpActionResult PostSolicitudReemision([FromBody] List<SolicitudReemision> solicitudes)
        {
            try
            {
                string respuesta = _devolucionExcesosRepository.PostSolicitudReemision(solicitudes);
                if (respuesta != null)
                {
                    var Respuesta = new { Resultado = respuesta };
                    return Ok(Respuesta);
                }
                return NotFound();

            }
            catch (IngresosException)
            {
                return BadRequest(ExceptionMessages.Ex_SolicitudReemision);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetCuenta/{rut}/{isapre}")]
        public IHttpActionResult GetSaldoExcesosDia(int rut, string isapre)
        {
            try
            {
                var devExcesos = _devolucionExcesosRepository.GetCuenta(rut, isapre);
                if (devExcesos != null)
                {
                    return Ok(devExcesos);
                }
                return NotFound();

            }
            catch (IngresosException)
            {
                return BadRequest(string.Format(ExceptionMessages.Ex_Cuentas, rut, isapre));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetDeuda/{rut}/{isapre}")]
        public IHttpActionResult GetDeuda(int rut, string isapre)
        {
            try
            {
                var respuesta = _devolucionExcesosRepository.GetDeuda(rut, isapre);
                if (respuesta != null)
                {
                    var Respuesta = new { Resultado = respuesta };
                    return Ok(Respuesta);
                }
                return NotFound();

            }
            catch (IngresosException)
            {
                return BadRequest(string.Format(ExceptionMessages.Ex_Deudas, rut, isapre));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    } 
}
