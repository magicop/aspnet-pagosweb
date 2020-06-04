using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WS_Ingresos.Exceptions;
using WS_Ingresos.Models.Contracts;
using WS_Ingresos.Models.Dto;
using WS_Ingresos.Models.Entities;


namespace WS_Ingresos.Models.Repositories
{
    public class CotizacionesRepository : ICotizacionesRepository
    {
        public ICollection<Cuponera> GetCuponera(int rut, string isapre)
        {
            try
            {
                using (var context = new IsaWebProdEntities())
                {
                    var out_prsText = new System.Data.Entity.Core.Objects.ObjectParameter("pr_sText", typeof(string));

                    var cuponeraEntity = context.PKG_COTIZACIONES_SP_OBTIENE_CUPON_PAGO(rut, isapre, out_prsText).ToList();

                    List<Cuponera> cuponera = new List<Cuponera>();
                    MapperEntityToDTO mapper = new MapperEntityToDTO();

                    foreach (var item in cuponeraEntity)
                    {
                        cuponera.Add(mapper.ToDTO(item));
                    }

                    return cuponera;
                }
            }
            catch (Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }

        public ICollection<Cotizaciones> GetCotizacionesNew(int rut, string isapre)
        {
            try
            {
                using (var context = new IsaWebProdEntities())
                {
                    var out_prsText = new System.Data.Entity.Core.Objects.ObjectParameter("pr_sText", typeof(string));

                    var cuponeraEntity = context.PKG_COTIZACIONES_SP_OBTIENE_CARGO_NEW(rut, isapre, out_prsText).ToList();

                    List<Cotizaciones> cotizaciones = new List<Cotizaciones>();
                    MapperEntityToDTO mapper = new MapperEntityToDTO();

                    foreach (var item in cuponeraEntity)
                    {
                        cotizaciones.Add(mapper.ToDTO(item));
                    }

                    return cotizaciones;
                }
            }
            catch (Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }

        public ICollection<Periodo> GetPeriodoPagado(int rut, string isapre)
        {
            try
            {
                using (var context = new IsaWebProdEntities())
                {
                    var out_prsText = new System.Data.Entity.Core.Objects.ObjectParameter("pr_sText", typeof(string));

                    var periodoEntity = context.PKG_COTIZACIONES_SP_OBTIENE_PERIODO_PAGADO(rut, isapre, out_prsText).ToList();

                    List<Periodo> periodos = new List<Periodo>();
                    MapperEntityToDTO mapper = new MapperEntityToDTO();

                    foreach (var item in periodoEntity)
                    {
                        periodos.Add(mapper.ToDTO(item));
                    }

                    return periodos;
                }
            }
            catch (Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }

        public Excedentes GetSaldoExcedentes(int rut, string isapre, string tipo)
        {
            try
            {
                using (var context = new PSucursalSucuEntities())
                {
                    var p_retorno = new System.Data.Entity.Core.Objects.ObjectParameter("p_retorno", typeof(string));
                    var p_cuenta = new System.Data.Entity.Core.Objects.ObjectParameter("p_cuenta", typeof(string));


                    var periodoEntity = context.EXCEDENTE_DISPON_WEB(rut, isapre, p_retorno, tipo, p_cuenta);

                    Excedentes excedentes = new Excedentes();

                    excedentes.retorno = p_retorno.Value.ToString();
                    excedentes.cuenta = p_cuenta.Value.ToString();

                    return excedentes;
                }
            }
            catch (Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }

        public ICollection<Excedente> GetDetalleExcedentes(int rut, string isapre)
        {
            try
            {
                using(var context = new IsaWebProdEntities())
                {
                    var detalleExcedentesEntity = context.PKG_COTIZACIONES_SP_CART_EXCED(rut, isapre).ToList();

                    List<Excedente> excedentes = new List<Excedente>();
                    MapperEntityToDTO mapper = new MapperEntityToDTO();

                    foreach(var item in detalleExcedentesEntity)
                    {
                        excedentes.Add(mapper.ToDTO(item));
                    }

                    return excedentes;
                }
            }
            catch(Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }

        public bool PostDatosCotizaNew(int rut, int periodo, int periodoAnt, int valorPesos, DateTime fechaRef, DateTime fechaCreacion, string estado, string empresa, int reajuste, int interes, int recargo, int total, int folio, string idPago)
        {
            try
            {
                using (var context = new IsaWebProdEntities())
                {
                    byte[] IdPagoByte = Isapre.Utilidades.Banmedica.ParseHex(idPago);
                    context.PKG_COTIZACIONES_INSERT_DATOS_COTIZA_NEW(rut, periodo, periodoAnt, valorPesos, fechaRef, fechaCreacion, estado, empresa, reajuste, interes, recargo, total, folio, IdPagoByte);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }

        public ICollection<CotizacionesSubsidio> GetCotizaciones(int rut, string empresa, int fechaInicio, int fechaFin)
        {
            try
            {
                using (var context = new ConsafilProdEntities())
                {
                    var cotiEntity = context.PKG_SUBSI_LICENCIAS_V2_SP_CERT_SUBSI_1(rut, empresa, fechaInicio, fechaFin).ToList();

                    List<CotizacionesSubsidio> cotizaciones = new List<CotizacionesSubsidio>();
                    MapperEntityToDTO mapper = new MapperEntityToDTO();

                    foreach (var item in cotiEntity)
                    {
                        cotizaciones.Add(mapper.ToDTO(item));
                    }                    

                    return cotizaciones;
                }
            }
            catch (Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }

        public ICollection<CotizacionesSubsidio2> GetSubsidio(int rut, string empresa, int fechaInicio, int fechaFin)
        {
            try
            {
                using (var context = new ConsafilProdEntities())
                {
                    var cotiEntity = context.PKG_SUBSI_LICENCIAS_V2_SP_CERT_SUBSI_2(rut, empresa, fechaInicio, fechaFin).ToList();

                    List<CotizacionesSubsidio2> cotizaciones = new List<CotizacionesSubsidio2>();
                    MapperEntityToDTO mapper = new MapperEntityToDTO();

                    foreach (var item in cotiEntity)
                    {
                        cotizaciones.Add(mapper.ToDTO(item));
                    }

                    return cotizaciones;
                }
            }
            catch (Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }

        public ICollection<AfiliadoCertificado> GetAfiliadosCotizaciones(int rutEmpleador, string isapre)
        {
            try
            {
                using (var context = new EmpleadorEntities())
                {
                    var OUT_MENSAJEERROR = new System.Data.Entity.Core.Objects.ObjectParameter("OUT_MENSAJEERROR", typeof(string));

                    var afiliadoCertificadoEntity = context.PKG_EMPLEADORES_CERTIFICADOS_PRC_OBTIENE_AFILIADOS(rutEmpleador, isapre, OUT_MENSAJEERROR).ToList();

                    List<AfiliadoCertificado> afiliadoCertificado = new List<AfiliadoCertificado>();
                    MapperEntityToDTO mapper = new MapperEntityToDTO();

                    foreach (var item in afiliadoCertificadoEntity)
                    {
                        afiliadoCertificado.Add(mapper.ToDTO(item));
                    }

                    return afiliadoCertificado;
                }
            }
            catch (Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }

        public ICollection<AfiliadoCertificado> GetAfiliadoCotizaciones(int rutEmpleador, int rutAfil, string isapre)
        {
            try
            {
                using (var context = new EmpleadorEntities())
                {
                    var OUT_MENSAJEERROR = new System.Data.Entity.Core.Objects.ObjectParameter("OUT_MENSAJEERROR", typeof(string));

                    var afiliadoCertificadoEntity = context.PKG_EMPLEADORES_CERTIFICADOS_PRC_OBTIENE_AFILIADO_COTIZA(rutEmpleador, rutAfil, isapre, OUT_MENSAJEERROR).ToList();

                    List<AfiliadoCertificado> afiliadoCertificado = new List<AfiliadoCertificado>();
                    MapperEntityToDTO mapper = new MapperEntityToDTO();

                    foreach (var item in afiliadoCertificadoEntity)
                    {
                        afiliadoCertificado.Add(mapper.ToDTO(item));
                    }

                    return afiliadoCertificado;
                }
            }
            catch (Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }

        public ICollection<CertificadoCotiza> GetCertificadoCotiza(int rutEmpleador, int rutAfil, string isapre)
        {
            try
            {
                using (var context = new EmpleadorEntities())
                {
                    var OUT_MENSAJEERROR = new System.Data.Entity.Core.Objects.ObjectParameter("OUT_MENSAJEERROR", typeof(string));

                    var certificadoCotizaEntity = context.PKG_EMPLEADORES_CERTIFICADOS_PRC_CERTIFICADO_COTIZA(rutEmpleador, rutAfil, isapre, OUT_MENSAJEERROR).ToList();

                    List<CertificadoCotiza> certificadoCotiza = new List<CertificadoCotiza>();
                    MapperEntityToDTO mapper = new MapperEntityToDTO();

                    foreach (var item in certificadoCotizaEntity)
                    {
                        certificadoCotiza.Add(mapper.ToDTO(item));
                    }

                    return certificadoCotiza;
                }
            }
            catch (Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }

        public long GetFolioPagoCotizaciones()
        {
            try
            {
                using (var context = new IsaWebProdEntities())
                {
                    var secuenciaEntity = context.PGK_COMPRA_BONOS_SECUENCIA_WEBPAY().ToList();

                    long secuencia = 0;

                    foreach (var item in secuenciaEntity)
                    {
                        secuencia = Convert.ToInt64(item.SEQ_WEBPAY);
                    }

                    return secuencia;
                }
            }
            catch (Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }

        public ICollection<DetalleCotizaciones> GetDetalleCotizaciones(int rut, string isapre, string nomApeAfiliado)
        {
            try
            {
                using (var context = new IsaWebProdEntities())
                {
                    var out_prsText = new System.Data.Entity.Core.Objects.ObjectParameter("pr_sText", typeof(string));

                    var detalleCotizacionesEntity = context.PKG_DETALLE_COTIZACIONES_DETCOTIZACIONES(rut, isapre, nomApeAfiliado, out_prsText);

                    List<DetalleCotizaciones> detalleCotizaciones = new List<DetalleCotizaciones>();
                    MapperEntityToDTO mapper = new MapperEntityToDTO();
                    foreach (var item in detalleCotizacionesEntity)
                    {
                        detalleCotizaciones.Add(mapper.ToDTO(item));
                    }

                    return detalleCotizaciones;
                }
            }
            catch (Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }
    }
}
