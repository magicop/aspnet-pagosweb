using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using WS_Ingresos.Exceptions;
using WS_Ingresos.Filters;
using WS_Ingresos.Models.Contracts;
using WS_Ingresos.Models.Dto;
using WS_Ingresos.Resources;

namespace WS_Ingresos.Controllers
{
    public class CotizacionesController : ApiController
    {
        private ICotizacionesRepository _cotizacionesRepository;
        private IAfiliadoRepository _afiliadoRepository;
        private IEmpleadorRepository _empleadorRepository;

        public CotizacionesController(ICotizacionesRepository cotizacionesRepository, IAfiliadoRepository afiliadoRepository, IEmpleadorRepository empleadorRepository)
        {
            this._cotizacionesRepository = cotizacionesRepository;
            this._afiliadoRepository = afiliadoRepository;
            this._empleadorRepository = empleadorRepository;
        }

        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetCuponera/{rut}/{isapre}")]
        public IHttpActionResult GetCuponera(int rut, string isapre)
        {
            try
            {
                var cuponera = _cotizacionesRepository.GetCuponera(rut, isapre);
                if (cuponera != null)
                {
                    return Ok(cuponera);
                }
                return NotFound();

            }
            catch (IngresosException)
            {
                return BadRequest(string.Format(ExceptionMessages.Ex_Cuponera, rut, isapre));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetCotizacionesNew/{rut}/{isapre}")]
        public IHttpActionResult GetCotizacionesNew(int rut, string isapre)
        {
            try
            {
                var cuponera = _cotizacionesRepository.GetCotizacionesNew(rut, isapre);
                if (cuponera != null)
                {
                    return Ok(cuponera);
                }
                return NotFound();

            }
            catch (IngresosException)
            {
                return BadRequest(string.Format(ExceptionMessages.Ex_Cotizaciones, rut, isapre));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetPeriodoPagado/{rut}/{isapre}")]
        public IHttpActionResult GetPeriodoPagado(int rut, string isapre)
        {
            try
            {
                var periodos = _cotizacionesRepository.GetPeriodoPagado(rut, isapre);
                if (periodos != null)
                {
                    return Ok(periodos);
                }
                return NotFound();

            }
            catch (IngresosException)
            {
                return BadRequest(string.Format(ExceptionMessages.Ex_Cotizaciones, rut, isapre));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [SecureResourceAttribute]
        public IHttpActionResult PostDatosCotizaNew(int rut, int periodo, int periodoAnt, int valorPesos, DateTime fechaRef, DateTime fechaCreacion, string estado, string empresa, int reajuste, int interes, int recargo, int total, int folio, string idPago)
        {
            try
            {
                var respuesta = _cotizacionesRepository.PostDatosCotizaNew(rut, periodo, periodoAnt, valorPesos, fechaRef, fechaCreacion, estado, empresa, reajuste, interes, recargo, total, folio, idPago);
                if (respuesta)
                {
                    var Respuesta = new { Resultado = respuesta };
                    return Ok(Respuesta);
                }
                return NotFound();

            }
            catch (IngresosException)
            {
                return BadRequest(string.Format(ExceptionMessages.Ex_DatosCotizaNew, rut, periodo, periodoAnt, valorPesos, fechaRef, fechaCreacion, estado, empresa, reajuste, interes, recargo, total, folio, idPago));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetSaldoExcedentes/{rut}/{isapre}/{tipo}")]
        public IHttpActionResult GetSaldoExcedentes(int rut, string isapre, string tipo)
        {
            try
            {
                var excedentes = _cotizacionesRepository.GetSaldoExcedentes(rut, isapre, tipo);
                if (excedentes != null)
                {
                    return Ok(excedentes);
                }
                return NotFound();

            }
            catch (IngresosException)
            {
                return BadRequest(string.Format(ExceptionMessages.Ex_SaldoExcedentes, rut, isapre, tipo));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetCertSubsidio/{rut}/{empresa}/{fechaInicio}/{fechaFin}/{canal}")]
        /*CEVY: Utilizado por Módulo de AutoAtención, Lógica extraida de sitio privado ../TusCertificados/certificadoSubsidio.aspx
         Se considera parámetro canal, para destinguir a futuro*/
        public HttpResponseMessage GetCertSubsidio(int rut, string empresa, int fechaInicio, int fechaFin, string canal)
        {
            try
            {
                var cotizaciones = _cotizacionesRepository.GetCotizaciones(rut, empresa, fechaInicio, fechaFin);
                if (cotizaciones != null)
                {
                    if (cotizaciones.Count > 0)
                    {
                        string urlCertificado = string.Empty;
                        string urlWebService = ConfigurationManager.AppSettings["UrlWebService"];
                       
                        urlCertificado = urlWebService + "/Certificados/CertificadoSubsidios?rut=" + rut + "&empresa=" + empresa + 
                            "&fechaInicio=" + fechaInicio + "&fechaFin=" + fechaFin;
                        
                        var bytesArrayCert = Utils.ConvertUrlToPDFBytes(urlCertificado, empresa);                       

                        if (bytesArrayCert != null)
                        {
                            var result = new HttpResponseMessage(HttpStatusCode.OK)
                            {
                                Content = new ByteArrayContent(bytesArrayCert)
                            };
                            result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline")
                            {
                                FileName = "CertificadoSubsidio.pdf",
                                Size = bytesArrayCert.Length
                            };
                            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                            return result;
                        }
                        else
                            return new HttpResponseMessage(HttpStatusCode.NotFound);
                    }
                    else
                        return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
                return new HttpResponseMessage(HttpStatusCode.NotFound);

            }
            catch (IngresosException)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetCartolaExcedentes/{rut}/{isapre}/{canal}")]
        /*CEVY: Utilizado por Módulo de AutoAtención, Lógica extraida de sitio privado ..TusCotizaciones/cartolaexcedentes.aspx
         Se considera parámetro canal, para destinguir a futuro*/
        public HttpResponseMessage GetCartolaExcedentes(int rut, string isapre, string canal)
        {
            try
            {
                string urlCertificado = string.Empty;
                string urlWebService = ConfigurationManager.AppSettings["UrlWebService"];

                urlCertificado = urlWebService + "/Certificados/CartolaExcedentes?rut=" + rut + "&isapre=" + isapre;

                var bytesArrayCert = Utils.ConvertUrlToPDFBytes(urlCertificado, isapre);

                if (bytesArrayCert != null)
                {
                    var result = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new ByteArrayContent(bytesArrayCert)
                    };
                    result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline")
                    {
                        FileName = "CartolaExcedentes.pdf",
                        Size = bytesArrayCert.Length
                    };
                    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                    return result;
                }
                else
                    return new HttpResponseMessage(HttpStatusCode.NotFound);                

            }
            catch (IngresosException)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }        

        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetAfiliadosCotizaciones/{rutEmpleador}/{isapre}")]
        public IHttpActionResult GetAfiliadosCotizaciones(int rutEmpleador, string isapre)
        {
            try
            {
                var afiliados = _cotizacionesRepository.GetAfiliadosCotizaciones(rutEmpleador, isapre);
                if (afiliados != null)
                {
                    return Ok(afiliados);
                }
                return NotFound();

            }
            catch (IngresosException)
            {
                return BadRequest(string.Format(ExceptionMessages.Ex_AfiliadosCotizaciones, rutEmpleador, isapre));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetAfiliadoCotizaciones/{rutEmpleador}/{rutAfil}/{isapre}")]
        public IHttpActionResult GetAfiliadoCotizaciones(int rutEmpleador, int rutAfil, string isapre)
        {
            try
            {
                var afiliado = _cotizacionesRepository.GetAfiliadoCotizaciones(rutEmpleador, rutAfil, isapre);
                if (afiliado != null)
                {
                    return Ok(afiliado);
                }
                return NotFound();

            }
            catch (IngresosException)
            {
                return BadRequest(string.Format(ExceptionMessages.Ex_AfiliadoCotizaciones, rutEmpleador, isapre));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetCertificadoCotiza/{rutEmpleador}/{rutAfil}/{isapre}")]
        public IHttpActionResult GetCertificadoCotiza(int rutEmpleador, int rutAfil, string isapre)
        {
            try
            {
                var certificado = _cotizacionesRepository.GetCertificadoCotiza(rutEmpleador, rutAfil, isapre);
                if (certificado != null)
                {
                    return Ok(certificado);
                }
                return NotFound();

            }
            catch (IngresosException)
            {
                return BadRequest(string.Format(ExceptionMessages.Ex_AfiliadoCotizaciones, rutEmpleador, isapre));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetFolioPagoCotizaciones")]
        public IHttpActionResult GetFolioPagoCotizaciones()
        {
            try
            {
                var folio = _cotizacionesRepository.GetFolioPagoCotizaciones();

                if (folio > 0)
                {
                    var Folio = new { Folio = folio };
                    return Ok(Folio);
                }
                return NotFound();

            }
            catch (IngresosException)
            {
                return BadRequest(string.Format(ExceptionMessages.Ex_Folio));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetDatosEmpleadorByRutAfil/{rutAfil}/{isapre}")]
        public IHttpActionResult GetDatosEmpleadorByRutAfil(int rutAfil, string isapre)
        {
            try
            {
                var datosEmpl = _afiliadoRepository.GetDatosEmpleador(rutAfil, isapre);
                var empleador = _empleadorRepository.GetDatosEmpleador(datosEmpl.rut, isapre);

                if (empleador != null)
                {
                    return Ok(empleador);
                }
                return NotFound();

            }
            catch (IngresosException)
            {
                return BadRequest(string.Format(ExceptionMessages.Ex_GetDatosEmpleadorByRutAfil, rutAfil, isapre));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetDatosEmpleadorByRutEmpl/{rutEmpl}/{isapre}")]
        public IHttpActionResult GetDatosEmpleadorByRutEmpl(int rutEmpl, string isapre)
        {
            try
            {
                var empleador = _empleadorRepository.GetDatosEmpleador(rutEmpl, isapre);

                if (empleador != null)
                {
                    return Ok(empleador);
                }
                return NotFound();

            }
            catch (IngresosException)
            {
                return BadRequest(string.Format(ExceptionMessages.Ex_GetDatosEmpleadorByRutEmpl, rutEmpl, isapre));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetDetalleCotizaciones/{rutAfil}/{isapre}")]
        public IHttpActionResult GetDetalleCotizaciones(int rutAfil, string isapre)
        {
            try
            {
                var nombreAfil = _afiliadoRepository.GetDatosAfiliado(rutAfil, isapre).nombreCompleto;
                var detCotizaciones = _cotizacionesRepository.GetDetalleCotizaciones(rutAfil, isapre, nombreAfil);


                if (detCotizaciones != null)
                {
                    return Ok(detCotizaciones);
                }
                return NotFound();

            }
            catch (IngresosException)
            {
                return BadRequest(string.Format(ExceptionMessages.Ex_GetDetalleCotizaciones, rutAfil, isapre));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetDatosAfiliado/{rutAfil}/{isapre}")]
        public IHttpActionResult GetDatosAfiliado(int rutAfil, string isapre)
        {
            try
            {
                var datosAfiliado = _afiliadoRepository.GetDatosAfiliado(rutAfil, isapre);

                if (datosAfiliado != null)
                {
                    return Ok(datosAfiliado);
                }
                return NotFound();

            }
            catch (IngresosException)
            {
                return BadRequest(string.Format(ExceptionMessages.Ex_GetDatosAfiliado, rutAfil, isapre));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetCartolaCotizaciones/{rut}/{isapre}")]
        public HttpResponseMessage GetCartolaCotizaciones(int rut, string isapre)
        {
            try
            {
                string urlCertificado = string.Empty;
                string urlWebService = ConfigurationManager.AppSettings["UrlWebService"];

                urlCertificado = urlWebService + "/Planilla/CartolaCotizaciones?rutAfil=" + rut + "&isapre=" + isapre;

                var bytesArrayCert = Utils.ConvertUrlToPDFBytes(urlCertificado, isapre);

                if (bytesArrayCert != null)
                {
                    var result = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new ByteArrayContent(bytesArrayCert)
                    };
                    
                    result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue(System.Net.Mime.DispositionTypeNames.Inline)
                    {
                        FileName = "CartolaCotizaciones.pdf",
                        Size = bytesArrayCert.Length
                    };
                    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                    return result;
                }
                else
                    return new HttpResponseMessage(HttpStatusCode.NotFound);

            }
            catch (IngresosException)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }   
    }
}
