using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using WS_Ingresos.Exceptions;
using WS_Ingresos.Filters;
using WS_Ingresos.Models.Contracts;
using WS_Ingresos.Models.Dto;
using WS_Ingresos.Resources;

namespace WS_Ingresos.Controllers
{
    public class RecaudacionController : ApiController
    {
        private IRecaudacionRepository _recaudacionRepository;

        public RecaudacionController(IRecaudacionRepository recaudacionRepository)
        {
            this._recaudacionRepository = recaudacionRepository;
        }

        [HttpPost]
        [SecureResourceAttribute]
        [Route("api/PostGeneraPlanilla")]
        public IHttpActionResult PostGeneraPlanilla([FromBody]InfoPlanilla model)
        {
            try
            {
                long folio = 0;
                RespuestaPlanilla respuesta = new RespuestaPlanilla();
                /*Tipo --> 1 Pago de Deuda, 2 --> Pago de Cotizaciones, 3 --> Pago de Folio Negociación*/
                if (model.tipo == 1)
                {
                    folio = _recaudacionRepository.SecuenciaPagoDeuda();
                    respuesta = _recaudacionRepository.GeneraPlanilla(folio, model);
                }
                else if (model.tipo == 2)
                {
                    //folio = _recaudacionRepository.SecuenciaPagoCotiza(); CEVY Se utiliza secuencia de deuda a pedido de FAB
                    folio = _recaudacionRepository.SecuenciaPagoDeuda();
                    foreach (var detalle in model.detallePeriodos)
                    {
                        detalle.periodoRecau = int.Parse(DateTime.ParseExact(detalle.periodoRemun.ToString(), "yyyyMM", CultureInfo.InvariantCulture).AddMonths(1).ToString("yyyyMM"));
                    }
                    respuesta = _recaudacionRepository.GeneraPlanilla(folio, model);
                }
                else if (model.tipo == 3)
                {
                    /*Sólo genero registro para comprobante*/
                    var respInsertEnc = _recaudacionRepository.InsertRegRecaEnc(model.folioPago, model.rutAfiliado, model.isapre, model.mail, model.montoGastoCobTotal,
                        model.montoPagoTotal, Utils.GetGlosaTipoRecaudacion(model.tipo));

                    if (respInsertEnc.Equals("OK"))
                    {
                        foreach (var item in model.detallePeriodos)
                        {
                            var respInsertDet = _recaudacionRepository.InsertRegRecaDet(model.folioPago, model.rutAfiliado, model.isapre,
                                Utils.GetGlosaTipoRecaudacion(model.tipo), item.montoDeuda, item.montoGastoCob, item.montoHonorario,
                                item.montoInteres, item.montoPago, item.montoReajuste, item.montoRecargo, item.periodoRecau, item.periodoRemun,
                                item.subProducto);
                            if (!respInsertDet.Equals("OK"))
                            {
                                return BadRequest(string.Format(ExceptionMessages.Ex_GeneraPlanilla, model.tipo, model.rutAfiliado, model.isapre));
                            }
                        }
                    }
                    else
                        return BadRequest(string.Format(ExceptionMessages.Ex_GeneraPlanilla, model.tipo, model.rutAfiliado, model.isapre));

                    respuesta.folioPago = model.folioPago;
                    respuesta.mensaje = "OK";
                }
                else
                    return BadRequest(string.Format(ExceptionMessages.Ex_GeneraPlanilla, model.tipo, model.rutAfiliado, model.isapre));

                return Ok(respuesta);
            }
            catch (IngresosException)
            {
                return BadRequest(string.Format(ExceptionMessages.Ex_GeneraPlanilla, model.tipo, model.rutAfiliado, model.isapre));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [SecureResourceAttribute]
        [Route("api/PostPagoPlanilla")]
        public IHttpActionResult PostPagoPlanilla([FromBody]InfoPagoPlanilla model)
        {
            try
            {
                if (model.formaPago.Equals("TRANSBANK"))
                {
                    var respInsInfoPago = _recaudacionRepository.InsertaInfoPagoModulo(model.infoPago, model.rutAfiliado, model.isapre, model.canal, model.tipo, model.folioPago,
                        model.infoPago.tipoTarjeta.Equals("DB") ? "DEBITO" : "CREDITO");
                }

                string respuesta = string.Empty;
                if (model.tipo.Equals(1) || model.tipo.Equals(2))
                    respuesta = _recaudacionRepository.PagoPlanilla(model);
                else if (model.tipo.Equals(3))
                {
                    PlanillasServices.PlanillasSoapClient planillas = new PlanillasServices.PlanillasSoapClient();
                    if (planillas.PagarPlanillas(model.folioPago, model.isapre, model.formaPago))
                        respuesta = "OK";
                    else
                        respuesta = "Error en pago de planilla, favor intente nuevamente.";
                }
                else
                    return BadRequest(string.Format(ExceptionMessages.Ex_PagoPlanilla, model.folioPago, model.rutAfiliado, model.isapre, model.agencia));

                if (respuesta.Equals("OK"))
                {
                    var respActPago = _recaudacionRepository.UpdateRegReca(model.folioPago, model.rutAfiliado, model.isapre, Utils.GetGlosaTipoRecaudacion(model.tipo), model.formaPago);
                    if (respActPago.Equals("OK"))
                    {
                        /*Registro log de canales virtuales*/

                        if (model.tipo == 3)
                        {
                            model.accion = "PFM";
                            _recaudacionRepository.ActualizaAgencia(model.agencia, model.folioPago);
                        }

                        registraLogTxCanalesVirtuales(model.rutAfiliado, model.isapre, model.accion, model.canal);
                        /*Envío de correo con comprobante según tipo*/
                        envioCorreoPagoRecaudacion(model.folioPago, model.rutAfiliado, model.isapre, model.tipo);
                    }
                }

                return Ok(respuesta);
            }
            catch (IngresosException)
            {
                return BadRequest(string.Format(ExceptionMessages.Ex_PagoPlanilla, model.folioPago, model.rutAfiliado, model.isapre, model.agencia));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetFoliosNegociacion/{rut}/{isapre}")]
        public IHttpActionResult GetFoliosNegociacion(int rut, string isapre)
        {
            try
            {
                var folios = _recaudacionRepository.ObtieneFoliosNegociacion(rut, isapre);

                if (folios != null)
                {
                    return Ok(folios);
                }
                return NotFound();
            }
            catch (IngresosException)
            {
                return BadRequest(string.Format(ExceptionMessages.Ex_GetFoliosNegociacion, rut, isapre));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        #region métodos privados
        private bool registraLogTxCanalesVirtuales(int rutAfiliado, string isapre, string accion, string canal)
        {
            string uriRequest = ConfigurationManager.AppSettings["UrlWSComunIsapre"].ToString() + "api/PostLogTxCanalesVirtuales";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlWSComunIsapre"].ToString());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string credenciales = Utils.GetCredencialesComunIsapre();
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + credenciales);

                string postBody = JsonConvert.SerializeObject(new
                {
                    accion = accion,
                    rutAfiliado = rutAfiliado,
                    isapre = isapre,
                    canal = canal
                });

                HttpResponseMessage response = client.PostAsync(uriRequest, new StringContent(postBody, Encoding.UTF8, "application/json")).Result;
                response.EnsureSuccessStatusCode();

                string responseBody = response.Content.ReadAsStringAsync().Result;
                var resultadoStd = JsonConvert.DeserializeObject<ResultadoStandard>(responseBody);

                return resultadoStd.Resultado.Equals("OK") ? true : false;
            }
        }

        private void envioCorreoPagoRecaudacion(long folioPago, int rutAfiliado, string isapre, int tipo)
        {
            try
            {
                PagoRecaudacion infoPago = _recaudacionRepository.ObtienePagoRecaudacion(folioPago, rutAfiliado, isapre, Utils.GetGlosaTipoRecaudacion(tipo));
                string url, mailEnvia, imagen, isapreN, mailRecibe, asunto; url = mailEnvia = imagen = isapreN = mailRecibe = asunto = string.Empty;
                int cont = 1;

                switch (tipo)
                {
                    case 1:
                        {
                            System.IO.StreamReader file = new System.IO.StreamReader(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["rutaPlantillaDeuda"]);
                            while (cont <= 72)
                            {
                                url = url + file.ReadLine();
                                cont++;
                            }
                            //Reemplazar variables de la plantilla
                            url = url.Replace("@fechapago", infoPago.fechaPago.ToString("dd'/'MM'/'yyyy HH:mm"));
                            url = url.Replace("@total", infoPago.montoPagoTotal.ToString());
                            url = url.Replace("@rut", infoPago.rutAfiliado.ToString() + "-" + Utils.CalcularDigito(infoPago.rutAfiliado));
                            url = url.Replace("@nombre", infoPago.nombre);
                            url = url.Replace("@id", infoPago.folioPago.ToString());
                            url = url.Replace("@monto", infoPago.montoPagoTotal.ToString());
                            url = url.Replace("@formapago", infoPago.formaPago);
                            string html = "";
                            double interesRec = 0;
                            foreach (var item in infoPago.detallesPago)
                            {
                                interesRec = Convert.ToDouble(item.montoInteres + item.montoRecargo);

                                html +=
                                "<tr>" +
                                "<td style='width: 50px'><font size=1 COLOR=red>" + item.periodoRemun + "<font></td>" +
                                "<td style='width: 300px'><font size=1>" + item.montoDeuda + "<font></td>" +
                                "<td style='width: 50px'><font size=1>" + item.montoReajuste + "<font></td>" +
                                "<td style='width: 50px'><font size=1>" + interesRec + "<font></td>" +
                                "<td style='width: 50px'><font size=1>" + item.montoGastoCob + "<font></td>" +
                                "<td style='width: 50px'><font size=1>" + item.montoPago + "<font></td>" +
                                "</tr>";
                            }

                            html +=
                                "<tr>" +
                                    "<td style='width: 500px' colspan='5' align='left'><font size=1><b>Total General</b><font></td>" +
                                    "<td style='width: 50px' align='right'><font size=1>" + infoPago.montoPagoTotal + "<font></td>" +
                                "</tr>";

                            url = url.Replace("@detalle", html);

                            if (infoPago.isapre == "B")
                            {

                                imagen = "<td><img src=' " + AppDomain.CurrentDomain.BaseDirectory + "images\\firma_certificado.gif' alt='firma' width='130' height='110' /></td><br />";
                                isapreN = "Banmédica";
                            }
                            else
                            {
                                imagen = "<img src=' " + AppDomain.CurrentDomain.BaseDirectory + "images\\firma_certificadoVida3.gif' alt='firma' width='130' height='121' /></td>";
                                isapreN = "Vida Tres";
                            }

                            url = url.Replace("@imagen", imagen);
                            url = url.Replace("@isapre", isapreN);

                            byte[] adjunto = Utils.ConvertURLToPDFComprobante(url, infoPago.isapre);

                            mailRecibe = infoPago.mail;
                            asunto = "Pago de deuda en línea";

                            string mail = ConfigurationManager.AppSettings["email"];
                            if (!string.IsNullOrEmpty(mail)) mailRecibe = mail;

                            MultipartFormDataContent multiPartContent = new MultipartFormDataContent();
                            multiPartContent.Add(new StringContent(infoPago.isapre.Equals("B") ? "PagoDeuda_BM" : "PagoDeuda_VT"), "id");
                            multiPartContent.Add(new StringContent(infoPago.rutAfiliado.ToString()), "rut");
                            multiPartContent.Add(new StringContent(infoPago.isapre), "isapre");
                            multiPartContent.Add(new StringContent(mailRecibe), "email");
                            multiPartContent.Add(new StringContent(infoPago.nombre), "nombre");

                            var fileContent1 = new ByteArrayContent(adjunto);
                            fileContent1.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                            {
                                FileName = "comprobante" + infoPago.rutAfiliado + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".pdf",
                                Name = "comprobante" + infoPago.rutAfiliado + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString()
                            };

                            fileContent1.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");
                            multiPartContent.Add(fileContent1);

                            var statusCode = Utils.SendMailOnDemand(multiPartContent);
                            break;
                        }
                    case 2:
                        {
                            System.IO.StreamReader file = new System.IO.StreamReader(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["rutaPlantilla"]);
                            while (cont <= 52)
                            {
                                url = url + file.ReadLine();
                                cont++;
                            }

                            //Reemplazar variables de la plantilla
                            url = url.Replace("@fechapago", infoPago.fechaPago.ToString("dd'/'MM'/'yyyy HH:mm"));
                            foreach (var item in infoPago.detallesPago)
                                url = url.Replace("@periodo", item.periodoRemun.ToString());
                            url = url.Replace("@rut", infoPago.rutAfiliado.ToString() + "-" + Utils.CalcularDigito(infoPago.rutAfiliado));
                            url = url.Replace("@nombre", infoPago.nombre);
                            url = url.Replace("@id", infoPago.folioPago.ToString());
                            url = url.Replace("@monto", infoPago.montoPagoTotal.ToString());
                            url = url.Replace("@formapago", infoPago.formaPago);

                            if (infoPago.isapre == "B")
                            {

                                imagen = "<td><img src=' " + AppDomain.CurrentDomain.BaseDirectory + "images\\firma_certificado.gif' alt='firma' width='130' height='110' /></td><br />";
                                isapreN = "Banmédica";
                            }
                            else
                            {
                                imagen = "<img src=' " + AppDomain.CurrentDomain.BaseDirectory + "images\\firma_certificadoVida3.gif' alt='firma' width='130' height='121' /></td>";
                                isapreN = "Vida Tres";
                            }

                            url = url.Replace("@imagen", imagen);
                            url = url.Replace("@isapre", isapreN);

                            byte[] adjunto = Utils.ConvertURLToPDFComprobante(url, infoPago.isapre);

                            mailRecibe = infoPago.mail;
                            asunto = "Pago de cotizaciones en línea";

                            string mail = ConfigurationManager.AppSettings["email"];
                            if (!string.IsNullOrEmpty(mail))
                                mailRecibe = mail;

                            MultipartFormDataContent multiPartContent = new MultipartFormDataContent();
                            multiPartContent.Add(new StringContent(infoPago.isapre.Equals("B") ? "PagoCotizacion_BM" : "PagoCotizacion_VT"), "id");
                            multiPartContent.Add(new StringContent(infoPago.rutAfiliado.ToString()), "rut");
                            multiPartContent.Add(new StringContent(infoPago.isapre), "isapre");
                            multiPartContent.Add(new StringContent(mailRecibe), "email");
                            multiPartContent.Add(new StringContent(infoPago.nombre), "nombre");

                            var fileContent1 = new ByteArrayContent(adjunto);
                            fileContent1.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                            {
                                FileName = "comprobante" + infoPago.rutAfiliado + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".pdf",
                                Name = "comprobante" + infoPago.rutAfiliado + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString()
                            };

                            fileContent1.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");
                            multiPartContent.Add(fileContent1);

                            var statusCode = Utils.SendMailOnDemand(multiPartContent);

                            break;
                        }
                    case 3:
                        {
                            System.IO.StreamReader file = new System.IO.StreamReader(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["rutaPlantillaFolio"]);
                            while (cont <= 52)
                            {
                                url = url + file.ReadLine();
                                cont++;
                            }

                            //Reemplazar variables de la plantilla
                            url = url.Replace("@fechapago", infoPago.fechaPago.ToString("dd'/'MM'/'yyyy HH:mm"));
                            url = url.Replace("@rut", infoPago.rutAfiliado.ToString() + "-" + Utils.CalcularDigito(infoPago.rutAfiliado));
                            url = url.Replace("@nombre", infoPago.nombre);
                            url = url.Replace("@id", infoPago.folioPago.ToString());
                            url = url.Replace("@monto", infoPago.montoPagoTotal.ToString());
                            url = url.Replace("@formapago", infoPago.formaPago);

                            if (infoPago.isapre == "B")
                            {

                                imagen = "<td><img src=' " + AppDomain.CurrentDomain.BaseDirectory + "images\\firma_certificado.gif' alt='firma' width='130' height='110' /></td><br />";
                                isapre = "Banmédica";
                            }
                            else
                            {
                                imagen = "<img src=' " + AppDomain.CurrentDomain.BaseDirectory + "images\\firma_certificadoVida3.gif' alt='firma' width='130' height='121' /></td>";
                                isapre = "Vida Tres";
                            }

                            url = url.Replace("@imagen", imagen);
                            url = url.Replace("@isapre", isapre);

                            //Convertir a PDF
                            byte[] adjunto = Utils.ConvertURLToPDFComprobante(url, infoPago.isapre);

                            //Enviar mail                            
                            mailRecibe = infoPago.mail;

                            string mail = ConfigurationManager.AppSettings["email"];
                            if (!string.IsNullOrEmpty(mail)) mailRecibe = mail;

                            byte[] planillas = null;
                            try
                            {
                                PlanillasServices.PlanillasSoapClient _planillasSoap = new PlanillasServices.PlanillasSoapClient();
                                PlanillasServices.Respuesta _planillas = _planillasSoap.ObtenerPlanilla(Convert.ToInt64(infoPago.folioPago));
                                planillas = _planillas.Planilla;
                            }
                            catch (Exception) { }

                            MultipartFormDataContent multiPartContent = new MultipartFormDataContent();
                            multiPartContent.Add(new StringContent(infoPago.isapre.Equals("B") ? "PagoFolioNegociacion_BM" : "PagoFolioNegociacion_VT"), "id");
                            multiPartContent.Add(new StringContent(infoPago.rutAfiliado.ToString()), "rut");
                            multiPartContent.Add(new StringContent(infoPago.isapre), "isapre");
                            multiPartContent.Add(new StringContent(mailRecibe), "email");
                            multiPartContent.Add(new StringContent(infoPago.nombre), "nombre");

                            var fileContent1 = new ByteArrayContent(adjunto);
                            fileContent1.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                            {
                                FileName = "comprobante" + infoPago.rutAfiliado + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".pdf",
                                Name = "comprobante" + infoPago.rutAfiliado + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString()
                            };

                            fileContent1.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");
                            multiPartContent.Add(fileContent1);

                            if (planillas != null)
                            {
                                var fileContent2 = new ByteArrayContent(planillas);
                                fileContent2.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                                {
                                    FileName = "planilla.pdf",
                                    Name = "planilla"
                                };

                                fileContent2.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");
                                multiPartContent.Add(fileContent2);
                            }

                            var statusCode = Utils.SendMailOnDemand(multiPartContent);

                            break;
                        }
                    default: break;
                }
            }
            catch (Exception) { }
        }

        #endregion métodos privados
    }
}
