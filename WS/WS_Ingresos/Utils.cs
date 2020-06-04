using ExpertPdf.HtmlToPdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using WS_Ingresos.Models.Dto;

namespace WS_Ingresos
{
    public class Utils
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly string licenseKey = ConfigurationManager.AppSettings["ConvertPdfLicenceKey"].ToString();

        public static void TranslateParentescoIntToStringValue(Cargas carga)
        {
            switch (carga.Parentesco)
            {
                case "1":
                    carga.Parentesco = "Conyuge";
                    break;
                case "2":
                    carga.Parentesco = "Padre";
                    break;
                case "3":
                    carga.Parentesco = "Madre";
                    break;
                case "4":
                    carga.Parentesco = "Hijo";
                    break;
                case "5":
                    carga.Parentesco = "Otro";
                    break;
                case "01":
                    carga.Parentesco = "Conyuge";
                    break;
                case "02":
                    carga.Parentesco = "Padre";
                    break;
                case "03":
                    carga.Parentesco = "Madre";
                    break;
                case "04":
                    carga.Parentesco = "Hijo";
                    break;
                case "05":
                    carga.Parentesco = "Otro";
                    break;
            }
        }

        public static void TranslateSexoIntToStringValue(Cargas carga)
        {
            switch (carga.Sexo)
            {
                case "1":
                    carga.Sexo = "Masculino";
                    break;
                case "2":
                    carga.Sexo = "Femenino";
                    break;
            }
        }

        public static string ConstruirFecha()
        {
            string result = "";
            result = DateTime.Now.Day.ToString();
            result += " de ";
            result += TraducirMes(DateTime.Now.Month);
            result += " de ";
            result += DateTime.Now.Year.ToString();
            return result;
        }

        public static string TraducirMes(int mes)
        {
            string result = "";
            switch (mes)
            {
                case 1:
                    result = "Enero";
                    break;
                case 2:
                    result = "Febrero";
                    break;
                case 3:
                    result = "Marzo";
                    break;
                case 4:
                    result = "Abril";
                    break;
                case 5:
                    result = "Mayo";
                    break;
                case 6:
                    result = "Junio";
                    break;
                case 7:
                    result = "Julio";
                    break;
                case 8:
                    result = "Agosto";
                    break;
                case 9:
                    result = "Septiembre";
                    break;
                case 10:
                    result = "Octubre";
                    break;
                case 11:
                    result = "Noviembre";
                    break;
                case 12:
                    result = "Diciembre";
                    break;
                default:
                    break;
            }
            return result;
        }

        public static string CalcularDigito(int rut)
        {
            int suma = 0;
            int multiplicador = 1;
            while (rut != 0)
            {
                multiplicador++;
                if (multiplicador == 8)
                    multiplicador = 2;
                suma += (rut % 10) * multiplicador;
                rut = rut / 10;
            }
            suma = 11 - (suma % 11);
            if (suma == 11)
                return "0";
            else if (suma == 10)
                return "K";
            else
                return suma.ToString();
        }

        /// <summary>
        /// Convierte el codigo Html de la URL especificada a un PDF y envia el 
        /// documento como un archivo adjunto al browser
        /// </summary>
        public static byte[] ConvertUrlToPDFBytes(string url, string isapre)
        {
            // Create the PDF converter. Optionally you can specify the virtual browser 
            // width as parameter. 1024 pixels is default, 0 means autodetect
            PdfConverter pdfConverter = new PdfConverter();

            // set the license key - required
            pdfConverter.LicenseKey = licenseKey;

            // set the converter options - optional
            pdfConverter.PdfDocumentOptions.PdfPageSize = PdfPageSize.A4;
            pdfConverter.PdfDocumentOptions.PdfCompressionLevel = PdfCompressionLevel.Normal;
            pdfConverter.PdfDocumentOptions.PdfPageOrientation = PDFPageOrientation.Portrait;


            // set if header and footer are shown in the PDF - optional - default is false 
            pdfConverter.PdfDocumentOptions.ShowHeader = false;
            pdfConverter.PdfDocumentOptions.ShowFooter = false;
            //set the PDF document margins
            pdfConverter.PdfDocumentOptions.LeftMargin = 20;
            pdfConverter.PdfDocumentOptions.RightMargin = 20;
            pdfConverter.PdfDocumentOptions.TopMargin = 20;
            pdfConverter.PdfDocumentOptions.BottomMargin = 20;

            // set to generate a pdf with selectable text or a pdf with embedded image - optional - default is true
            pdfConverter.PdfDocumentOptions.GenerateSelectablePdf = true;
            // set if the HTML content is resized if necessary to fit the PDF page width - optional - default is true
            pdfConverter.PdfDocumentOptions.FitWidth = false;
            // 
            // set the embedded fonts option - optional - default is false
            pdfConverter.PdfDocumentOptions.EmbedFonts = false;
            // set the live HTTP links option - optional - default is true
            pdfConverter.PdfDocumentOptions.LiveUrlsEnabled = false;

            if (pdfConverter.PdfDocumentOptions.GenerateSelectablePdf)
            {
                // set if the JavaScript is enabled during conversion to a PDF with selectable text 
                // - optional - default is false
                pdfConverter.ScriptsEnabled = false;
                // set if the ActiveX controls (like Flash player) are enabled during conversion 
                // to a PDF with selectable text - optional - default is false
                pdfConverter.ActiveXEnabled = false;
            }
            else
            {
                // set if the JavaScript is enabled during conversion to a PDF with embedded image 
                // - optional - default is true
                pdfConverter.ScriptsEnabledInImage = true;
                // set if the ActiveX controls (like Flash player) are enabled during conversion 
                // to a PDF with embedded image - optional - default is true
                pdfConverter.ActiveXEnabledInImage = true;
            }

            // set if the images in PDF are compressed with JPEG to reduce the PDF document size - optional - default is true
            pdfConverter.PdfDocumentOptions.JpegCompressionEnabled = false;

            if (isapre == "B")
                pdfConverter.PdfDocumentInfo.AuthorName = "Isapre Banmédica";
            else
                pdfConverter.PdfDocumentInfo.AuthorName = "Isapre Vida Tres";

            return pdfConverter.GetPdfBytesFromUrl(url);            
        }

        public static string GetCredencialesComunIsapre()
        {
            string auth = ConfigurationManager.AppSettings["User_WSComunIsapre"].ToString() + ":"
                + ConfigurationManager.AppSettings["Pass_WSComunIsapre"].ToString();
            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(auth);
            string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }

        public static string GetGlosaTipoRecaudacion(int tipo)
        {
            switch (tipo)
            {
                case 1: return "Pago Deudas";
                case 2: return "Pago Cotización";
                case 3: return "Pago Folio de Negociación";
                default: return "S/I";
            }
        }

        public static byte[] ConvertURLToPDFComprobante(string url, string isapre)
        {
            try
            {
                //string prefijoUrl = "";

                //if (isapre == "B")
                //{
                //    prefijoUrl = ConfigurationManager.AppSettings["urlBanmedica"];
                //}
                //else
                //{
                //    prefijoUrl = ConfigurationManager.AppSettings["urlVidaTres"];
                //}
                string urlToConvert = url;

                PdfConverter pdfConverter = new PdfConverter();

                // set the license key - required
                pdfConverter.LicenseKey = licenseKey;

                // set the converter options - optional
                //pdfConverter.PdfDocumentOptions.PdfPageSize = PdfPageSize.A4;
                pdfConverter.PdfDocumentOptions.PdfCompressionLevel = PdfCompressionLevel.Normal;
                pdfConverter.PdfDocumentOptions.PdfPageOrientation = PDFPageOrientation.Portrait;
                pdfConverter.PageHeight = 0;
                pdfConverter.PageWidth = 0;

                // set if header and footer are shown in the PDF - optional - default is false 
                pdfConverter.PdfDocumentOptions.ShowHeader = false;
                pdfConverter.PdfDocumentOptions.ShowFooter = false;

                //set the PDF document margins
                pdfConverter.PdfDocumentOptions.LeftMargin = 30;
                pdfConverter.PdfDocumentOptions.RightMargin = 20;
                pdfConverter.PdfDocumentOptions.TopMargin = 5;
                pdfConverter.PdfDocumentOptions.BottomMargin = 5;
                pdfConverter.PdfDocumentOptions.GenerateSelectablePdf = true;
                pdfConverter.PdfDocumentOptions.EmbedFonts = false;
                pdfConverter.PdfDocumentOptions.LiveUrlsEnabled = false;

                if (pdfConverter.PdfDocumentOptions.GenerateSelectablePdf)
                {
                    pdfConverter.ScriptsEnabled = false;
                    pdfConverter.ActiveXEnabled = false;
                }
                else
                {
                    pdfConverter.ScriptsEnabledInImage = true;
                    pdfConverter.ActiveXEnabledInImage = true;
                }

                pdfConverter.PdfDocumentOptions.JpegCompressionEnabled = false;

                if (isapre == "B")
                    pdfConverter.PdfDocumentInfo.AuthorName = "Isapre Banmédica";
                else
                    pdfConverter.PdfDocumentInfo.AuthorName = "Isapre VidaTres";

                byte[] pdfBytes = pdfConverter.GetPdfBytesFromHtmlString(urlToConvert);

                return pdfBytes;
            }
            catch(Exception ex)
            {
                log.Error(string.Format("[Utils-ConvertURLToPDFComprobante] Exception ex.message : {0}, ex.stacktrace : {1}", ex.Message, ex.StackTrace));
                return null;
            }            
        }

        public static string enviaCorreo(string mailremitente, string nombreremitente, string maildest, string nombredest, string body, string asunto, byte[] adjunto1, string nombreAdjunto1, string adjunto2)
        {
            try
            {
                System.Net.Mail.MailMessage oMsg = new System.Net.Mail.MailMessage();

                System.Net.Mail.MailAddress direcciondesde = null;
                System.Net.Mail.MailAddress dirEmailEnvia = null;

                if (nombreremitente != "")
                    direcciondesde = new System.Net.Mail.MailAddress(mailremitente, nombreremitente);
                else
                    direcciondesde = new System.Net.Mail.MailAddress(mailremitente);
                if (nombredest != "")
                    dirEmailEnvia = new System.Net.Mail.MailAddress(maildest, nombredest);
                else
                    dirEmailEnvia = new System.Net.Mail.MailAddress(maildest);

                oMsg.From = direcciondesde;
                oMsg.To.Add(dirEmailEnvia);
                oMsg.Subject = asunto;
                oMsg.Body = body;

                oMsg.IsBodyHtml = true;

                Stream stream = new MemoryStream(adjunto1);
                oMsg.Attachments.Add(new System.Net.Mail.Attachment(stream, nombreAdjunto1));
                if (!string.IsNullOrEmpty(adjunto2))
                    processAttachments(adjunto2, ref oMsg);
                System.Net.Mail.SmtpClient oClient = new System.Net.Mail.SmtpClient();
                oClient.Host = ConfigurationManager.AppSettings["ServidorCorreo"];
                oClient.Send(oMsg);
                oClient = null;
                oMsg.Dispose();
                oMsg = null;

                return "ok";
            }
            catch (Exception ex)
            {
                log.Error(string.Format("[Utils-enviaCorreo] Exception ex.message : {0}, ex.stacktrace : {1}", ex.Message, ex.StackTrace));
                return ex.Message;
            }
        }

        public static string enviaCorreo(string mailremitente, string nombreremitente, string maildest, string nombredest, string body, string asunto, byte[] adjunto1, string nombreAdjunto1, byte[] adjunto2, string nombreAdjunto2)
        {
            try
            {
                System.Net.Mail.MailMessage oMsg = new System.Net.Mail.MailMessage();

                System.Net.Mail.MailAddress direcciondesde = null;
                System.Net.Mail.MailAddress dirEmailEnvia = null;

                if (nombreremitente != "")
                    direcciondesde = new System.Net.Mail.MailAddress(mailremitente, nombreremitente);
                else
                    direcciondesde = new System.Net.Mail.MailAddress(mailremitente);
                if (nombredest != "")
                    dirEmailEnvia = new System.Net.Mail.MailAddress(maildest, nombredest);
                else
                    dirEmailEnvia = new System.Net.Mail.MailAddress(maildest);

                oMsg.From = direcciondesde;
                oMsg.To.Add(dirEmailEnvia);
                oMsg.Subject = asunto;
                oMsg.Body = body;

                oMsg.IsBodyHtml = true;

                Stream stream = new MemoryStream(adjunto1);
                oMsg.Attachments.Add(new System.Net.Mail.Attachment(stream, nombreAdjunto1));
                Stream stream1 = new MemoryStream(adjunto2);
                oMsg.Attachments.Add(new System.Net.Mail.Attachment(stream1, nombreAdjunto2));
                System.Net.Mail.SmtpClient oClient = new System.Net.Mail.SmtpClient();
                oClient.Host = ConfigurationManager.AppSettings["ServidorCorreo"];
                oClient.Send(oMsg);
                oClient = null;
                oMsg.Dispose();
                oMsg = null;

                return "ok";
            }
            catch (Exception ex)
            {
                log.Error(string.Format("[Utils-enviaCorreo] Exception ex.message : {0}, ex.stacktrace : {1}", ex.Message, ex.StackTrace));
                return ex.Message;
            }
        }

        private static bool processAttachments(string files, ref System.Net.Mail.MailMessage oMail)
        {
            bool flag = false;

            if (files != "")
            {
                if (files.Substring(files.Length - 1, 1) != ",") files = files + ",";

                string[] archivos = files.Split(',');

                for (int i = 0; i < archivos.Length - 1; i++)
                {
                    flag = false;
                    if (System.IO.File.Exists(archivos[i].ToString()))
                    {
                        oMail.Attachments.Add(new System.Net.Mail.Attachment(archivos[i].ToString()));
                        flag = true;
                    }
                }
            }
            return flag;
        }

        public static string formatoPeso(string monto)
        {
            try
            {
                return "$ " + Convert.ToDouble(monto).ToString("N0");
            }
            catch
            {
                return "$ " + monto;
            }
        }

        public static string formatoRut(string rut)
        {
            try
            {
                if (!string.IsNullOrEmpty(rut)) return Convert.ToDouble(rut).ToString("N0") + "-" + CalcularDigito(Convert.ToInt32(rut));
                else return string.Empty;
            }
            catch
            {
                return rut;
            }
        }

        public static HttpStatusCode SendMailOnDemand(MultipartFormDataContent multiPartContent)
        {
            try
            {
                Uri urlservice = new Uri(ConfigurationManager.AppSettings["urlOnDemand"]);
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, urlservice);

                requestMessage.Content = multiPartContent;
                HttpClient httpClient = new HttpClient();
                Task<HttpResponseMessage> httpRequest = httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseContentRead, System.Threading.CancellationToken.None);
                HttpResponseMessage httpResponse = httpRequest.Result;
                return httpResponse.StatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
