using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WS_Ingresos.Models.Contracts;
using WS_Ingresos.Models.Dto;

namespace WS_Ingresos.Controllers
{
    public class CertificadosController : Controller
    {
        private ICotizacionesRepository _cotizacionesRepository;
        private IDeudasRepository _deudasRepository;
        private IAfiliadoRepository _afiliadoRepository;
        private IEmpleadorRepository _empleadorRepository;

        public CertificadosController(ICotizacionesRepository cotizacionesRepository, IDeudasRepository deudasRepository, IAfiliadoRepository afiliadoRepository, IEmpleadorRepository empleadorRepository)
        {
            this._cotizacionesRepository = cotizacionesRepository;
            this._deudasRepository = deudasRepository;
            this._afiliadoRepository = afiliadoRepository;
            this._empleadorRepository = empleadorRepository;
        }        

        public ActionResult CertificadoSubsidios(int rut, string empresa, int fechaInicio, int fechaFin)
        {
            try
            {
                var cotizaciones = _cotizacionesRepository.GetCotizaciones(rut, empresa, fechaInicio, fechaFin);
                var datosAfiliado = _afiliadoRepository.GetDatosAfiliado(rut, empresa);

                var subsidios = _cotizacionesRepository.GetSubsidio(rut, empresa, fechaInicio, fechaFin);

                var model = new CertificadoSubsidioViewModel();
                model.fecha = Utils.ConstruirFecha();
                model.nombreAfiliado = datosAfiliado.nombreCompleto;
                model.rutAfiliado = rut.ToString("N0") + "-" + Utils.CalcularDigito(rut);
                model.cotizaciones = cotizaciones;
                model.subsidios = subsidios;

                if (empresa.Equals("B"))
                    return View("CertificadoSubsidioB", model);
                else
                    return View("CertificadoSubsidioV", model);
            }            
            catch (Exception)
            {
                return null;
            }
        }

        public ActionResult CertificadoDeuda(int rut, string isapre)
        {
            try
            {
                var datosAfiliado = _afiliadoRepository.GetDatosAfiliado(rut, isapre);
                var deudas = _deudasRepository.GetDetalleDeuda(rut, isapre);

                if (datosAfiliado != null)
                {
                    var model = new CertificadoDeudaViewModel();
                    model.fecha = Utils.ConstruirFecha();
                    model.nombreAfiliado = datosAfiliado.nombreCompleto;
                    model.rutAfiliado = datosAfiliado.rutCompleto;
                    model.direccion = datosAfiliado.direccion;
                    model.comuna = datosAfiliado.comuna;
                    model.ciudad = datosAfiliado.ciudad;
                    model.fono = datosAfiliado.fono;
                    
                    foreach(var deuda in deudas)
                    {
                        model.gastosCobranza += deuda.Gastos;
                        model.totalGeneral += deuda.Total;
                    }
                    model.totalGeneral += model.gastosCobranza;
                    model.deudas = deudas;

                    if (isapre.Equals("B"))
                        return View("CertificadoDeudaB", model);
                    else
                        return View("CertificadoDeudaV", model);
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }            
        }

        public ActionResult CartolaExcedentes(int rut, string isapre)
        {
            try
            {
                var datosAfiliado = _afiliadoRepository.GetDatosAfiliado(rut, isapre);
                var detalleExcedentes = _cotizacionesRepository.GetDetalleExcedentes(rut, isapre);
                var datosEmpleador = _afiliadoRepository.GetDatosEmpleador(rut, isapre);
                var empleador = _empleadorRepository.GetDatosEmpleador(datosEmpleador.rut, isapre);

                if (datosAfiliado != null && empleador != null)
                {
                    var model = new CartolaExcedentesViewModel();
                    model.fecha = Utils.ConstruirFecha();
                    model.nombreAfiliado = datosAfiliado.nombreCompleto;
                    model.rutAfiliado = datosAfiliado.rutCompleto;
                    model.direccion = datosAfiliado.direccion;
                    model.comuna = datosAfiliado.comuna;
                    model.ciudad = datosAfiliado.ciudad;
                    model.fono = datosAfiliado.fono;

                    double texcedente = 0, treajuste = 0, tinteres = 0, tcomision = 0, tuso = 0;
                    foreach (var detalleExcedente in detalleExcedentes)
                    {
                        texcedente += Convert.ToDouble(detalleExcedente.mexcedente);
                        treajuste += Convert.ToDouble(detalleExcedente.mreajuste);
                        tinteres += Convert.ToDouble(detalleExcedente.minteres);
                        tcomision += Convert.ToDouble(detalleExcedente.mcomision);
                        tuso += Convert.ToDouble(detalleExcedente.muso);
                    }

                    Excedente blanco = new Excedente();
                    detalleExcedentes.Add(blanco);
                    
                    Excedente total = new Excedente();
                    total.mcomision = tcomision.ToString("N0");
                    total.mdisponible = "";
                    total.mexcedente = texcedente.ToString("N0");
                    total.minteres = tinteres.ToString("N0");
                    total.mreajuste = treajuste.ToString("N0");
                    total.msaldo = "";
                    total.muso = tuso.ToString("N0");
                    total.premun = "Totales $";
                    detalleExcedentes.Add(total);

                    model.excedentes = detalleExcedentes;
                    model.empleador = empleador;

                    if (isapre.Equals("B"))
                        return View("CartolaExcedentesB", model);
                    else
                        return View("CartolaExcedentesV", model);
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}