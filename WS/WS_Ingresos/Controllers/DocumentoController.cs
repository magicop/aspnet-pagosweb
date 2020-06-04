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
    public class DocumentoController : ApiController
    {
        private IDocumentoRepository _documentoRepository;

        public DocumentoController(IDocumentoRepository documentoRepository)
        {
            this._documentoRepository = documentoRepository;
        }

        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetDocumentosPendientesDeCobro/{rut}/{isapre}/{canal}")]
        public IHttpActionResult GetDocumentosPendientesDeCobro(int rut, string isapre, string canal)
        {
            try
            {
                var documentos = _documentoRepository.GetDocumentosPendientesDeCobro(rut, isapre, canal);
                if (documentos != null)
                {
                    return Ok(documentos);
                }
                return NotFound();

            }
            catch (IngresosException)
            {
                return BadRequest(string.Format(ExceptionMessages.Ex_Documento, rut, isapre, canal));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
