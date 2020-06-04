using System;
using System.Collections.Generic;
using System.Configuration;
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
    public class DeudasController : ApiController
    {
        private IDeudasRepository _deudasRepository;

        public DeudasController(IDeudasRepository cotizacionesRepository)
        {
            this._deudasRepository = cotizacionesRepository;
        }

        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetCertDeuda/{rut}/{isapre}/{canal}")]
        /*CEVY: Utilizado por Módulo de AutoAtención, Lógica extraida de sitio privado ../TusCertificados/certificadoDeuda.aspx
         Se considera parámetro canal, para destinguir a futuro*/
        public HttpResponseMessage GetCertDeuda(int rut, string isapre, string canal)
        {
            try
            {
                string urlCertificado = string.Empty;
                string urlWebService = ConfigurationManager.AppSettings["UrlWebService"];

                urlCertificado = urlWebService + "/Certificados/CertificadoDeuda?rut=" + rut + "&isapre=" + isapre;

                var bytesArrayCert = Utils.ConvertUrlToPDFBytes(urlCertificado, isapre);

                if (bytesArrayCert != null)
                {
                    var result = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new ByteArrayContent(bytesArrayCert)
                    };
                    result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline")
                    {
                        FileName = "CertificadoDeuda.pdf",
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
        [Route("api/GetSecuenciaPagoDeuda")]
        public IHttpActionResult GetSecuenciaPagoDeuda()
        {
            try
            {
                var Respuesta = new { Secuencia = _deudasRepository.GetSecuenciaPagoDeuda() };
                return Ok(Respuesta);
            }
            catch (IngresosException)
            {
                return BadRequest(string.Format(ExceptionMessages.Ex_SecuenciaDeuda));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [SecureResourceAttribute]
        [Route("api/PostInsertPagoDeuda")]
        public IHttpActionResult PostInsertPagoDeuda([FromBody] PagoDeudaModel model)
        {
            try
            {
                var respuesta = _deudasRepository.PostInsertPagoDeuda(model.Rut, model.Periodo, model.Monto, model.Folio, model.SubProducto, model.Deuda, model.Reajuste, model.Interes, model.Recargo, model.Gasto, model.Horario);
                if (respuesta)
                {
                    var Respuesta = new { Resultado = respuesta };
                    return Ok(Respuesta);
                }
                return NotFound();
            }
            catch (IngresosException)
            {
                return BadRequest(string.Format(ExceptionMessages.Ex_SecuenciaDeuda));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetDetalleDeuda/{rut}/{isapre}")]
        public IHttpActionResult GetDetalleDeuda(int rut, string isapre)
        {
            try
            {
                var deudas = _deudasRepository.GetDetalleDeuda(rut, isapre);

                if (deudas != null)
                {
                    return Ok(deudas);
                }
                return NotFound();
            }
            catch(IngresosException)
            {
                return BadRequest(string.Format(ExceptionMessages.Ex_GetDetalleDeuda, rut, isapre));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
