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
    public class CargasController : ApiController
    {
        private ICargasRepository _cargasRepository;

        public CargasController(ICargasRepository cargasRepository)
        {
            this._cargasRepository = cargasRepository;
        }

        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetCargasActualizar/{rutAfil}/{isapre}")]
        public IHttpActionResult GetCargasActualizar(int rutAfil, string isapre)
        {
            try
            {
                ICollection<Cargas> result = new List<Cargas>();
                ICollection<Cargas> cargas = _cargasRepository.GetCargasActualizarAfilRut(rutAfil, isapre);
                if (cargas.Count > 0)
                {
                    foreach (Cargas carga in cargas)
                    {
                        ICollection<Cargas> cargasLog = _cargasRepository.GetCargasLogActualizarAfilRut(rutAfil, isapre, carga.Correlativo);
                        if (cargasLog.Count > 0)
                        {
                            Cargas element = cargasLog.FirstOrDefault();
                            if (element != null)
                            {
                                Utils.TranslateSexoIntToStringValue(element);
                                Utils.TranslateParentescoIntToStringValue(element);
                                result.Add(element);
                            }
                        }
                        else
                        {
                            Utils.TranslateSexoIntToStringValue(carga);
                            Utils.TranslateParentescoIntToStringValue(carga);
                            result.Add(carga);
                        }
                    }
                }

                if (result.Count > 0)
                {
                    return Ok(result);
                }
                return NotFound();

            }
            catch (IngresosException)
            {
                return BadRequest(string.Format(ExceptionMessages.Ex_Cargas, rutAfil, isapre));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
