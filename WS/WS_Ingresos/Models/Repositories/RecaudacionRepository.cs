using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Web;
using WS_Ingresos.Exceptions;
using WS_Ingresos.Models.Contracts;
using WS_Ingresos.Models.Dto;
using WS_Ingresos.Models.Entities;

namespace WS_Ingresos.Models.Repositories
{
    public class RecaudacionRepository:IRecaudacionRepository
    {
        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public RespuestaPlanilla GeneraPlanilla(long folioPago, InfoPlanilla infoPlanilla)
        {
            try
            {
                using (var context = new BancobroProdEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        RespuestaPlanilla resp = new RespuestaPlanilla();

                        try
                        {
                            var out_retorno = new System.Data.Entity.Core.Objects.ObjectParameter("out_retorno", typeof(string));

                            var respInsertEnc = InsertRegRecaEnc(folioPago, infoPlanilla.rutAfiliado, infoPlanilla.isapre, infoPlanilla.mail, infoPlanilla.montoGastoCobTotal,
                                infoPlanilla.montoPagoTotal, Utils.GetGlosaTipoRecaudacion(infoPlanilla.tipo));

                            if (respInsertEnc.Equals("OK"))
                            {
                                foreach (var item in infoPlanilla.detallePeriodos)
                                {
                                    var respInsertDet = InsertRegRecaDet(folioPago, infoPlanilla.rutAfiliado, infoPlanilla.isapre, Utils.GetGlosaTipoRecaudacion(infoPlanilla.tipo),
                                        item.montoDeuda, item.montoGastoCob, item.montoHonorario, item.montoInteres, item.montoPago, item.montoReajuste, item.montoRecargo,
                                        item.periodoRecau, item.periodoRemun, item.subProducto);
                                    if(respInsertDet.Equals("OK"))
                                    { 
                                        context.PKG_RECAUDACIONES_SP_GENERA_PLANILLA(folioPago, infoPlanilla.tipo, infoPlanilla.rutAfiliado,
                                            infoPlanilla.isapre, infoPlanilla.montoGastoCobTotal, item.montoGastoCob, item.montoPago, item.periodoRemun,
                                            item.subProducto, item.montoDeuda, item.montoReajuste, item.montoInteres, item.montoRecargo,
                                            item.montoHonorario, out_retorno);

                                        if (!string.IsNullOrEmpty(out_retorno.Value.ToString()))
                                        {
                                            //log.Error(string.Format("[RecaudacionRepository-GeneraPlanilla] Error al generar planilla para folio: {0}, periodoRemun: {1}, [Error] : {2}", folioPago, item.periodoRemun, out_retorno.Value.ToString()));
                                            dbContextTransaction.Rollback();

                                            resp.folioPago = folioPago;
                                            resp.mensaje = "Ha ocurrido un error al procesar su solicitud, favor reintentar nuevamente!";
                                            return resp;
                                        }
                                    }
                                    else
                                    {
                                        resp.folioPago = folioPago;
                                        resp.mensaje = "Ha ocurrido un error al procesar su solicitud, favor reintentar nuevamente!";
                                        return resp;
                                    }
                                }

                                dbContextTransaction.Commit();
                                resp.folioPago = folioPago;
                                resp.mensaje = "OK";
                                return resp;
                            }
                            else
                            {
                                resp.folioPago = folioPago;
                                resp.mensaje = "Ha ocurrido un error al procesar su solicitud, favor reintentar nuevamente!";
                                return resp;
                            }
                        }
                        catch(Exception ex)
                        {
                            //log.Error("[RecaudacionRepository-GeneraPlanilla][Exception-Message] : " + ex.Message + ", [InnerException-Message] : " + ex.InnerException.Message);
                            resp.folioPago = folioPago;
                            resp.mensaje = "Ha ocurrido un error al procesar su solicitud, favor reintentar nuevamente!";
                            dbContextTransaction.Rollback();
                            return resp;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //log.Error("[RecaudacionRepository-GeneraPlanilla][Exception-Message] : " + ex.Message + ", [InnerException-Message] : " + ex.InnerException.Message);
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }

        public long SecuenciaPagoDeuda()
        {
            try
            {
                using (var context = new BancobroProdEntities())
                {
                    var out_folio = new System.Data.Entity.Core.Objects.ObjectParameter("out_folio", typeof(decimal));
                    var out_retorno = new System.Data.Entity.Core.Objects.ObjectParameter("out_retorno", typeof(string));

                    context.PKG_RECAUDACIONES_SECUENCIA_PAGODEUDA(out_folio, out_retorno);

                    return long.Parse(out_folio.Value.ToString());
                }
            }
            catch (Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }

        public long SecuenciaPagoCotiza()
        {
            try
            {
                using (var context = new BancobroProdEntities())
                {
                    var out_folio = new System.Data.Entity.Core.Objects.ObjectParameter("out_folio", typeof(decimal));
                    var out_retorno = new System.Data.Entity.Core.Objects.ObjectParameter("out_retorno", typeof(string));

                    context.PKG_RECAUDACIONES_SECUENCIA_PAGOCOTIZA(out_folio, out_retorno);

                    return long.Parse(out_folio.Value.ToString());
                }
            }
            catch (Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }

        public string PagoPlanilla(InfoPagoPlanilla infoPago)
        {
            try
            {
                string retorno = string.Empty;
                
                using (var context = new BancobroProdEntities())
                {
                    var out_retorno = new System.Data.Entity.Core.Objects.ObjectParameter("out_retorno", typeof(string));

                    context.PKG_RECAUDACIONES_SP_ACT_ESTADO_PLANILLA(infoPago.folioPago,infoPago.agencia,infoPago.isapre,out_retorno);                    

                    //log.Debug("[RecaudacionRepository-PagoPlanilla]...Respuesta PKG_RECAUDACIONES_SP_ACT_ESTADO_PLANILLA: " + out_retorno.Value.ToString());

                    retorno = string.IsNullOrEmpty(out_retorno.Value.ToString()) ? "OK" : out_retorno.Value.ToString();
                }

                using (var contextSucu = new PSucursalSucuEntities())
                {
                    var nCodError = new System.Data.Entity.Core.Objects.ObjectParameter("nCodError", typeof(decimal));
                    var sTextError = new System.Data.Entity.Core.Objects.ObjectParameter("sTextError", typeof(string));

                    //log.Debug(string.Format("[RecaudacionRepository-PagoPlanilla] rutAfiliado: {0}, isapre: {1}, folioPago: {2}, " +
                    //    "tipo: {3}, rutAdmCajero: {4}, agencia: {5}", infoPago.rutAfiliado, infoPago.isapre, infoPago.folioPago,
                    //    infoPago.tipo, int.Parse(ConfigurationManager.AppSettings["rutAdmCajero"].ToString()), infoPago.agencia));

                    contextSucu.PKG_PAGO_MODULO_PM_REGISTRA_PAGO(infoPago.rutAfiliado, infoPago.isapre, infoPago.folioPago, infoPago.tipo,
                        int.Parse(ConfigurationManager.AppSettings["rutAdmCajero"].ToString()), infoPago.agencia, nCodError, sTextError);

                    //log.Debug(string.Format("[RecaudacionRepository-PagoPlanilla]...Respuesta PKG_PAGO_MODULO_PM_REGISTRA_PAGO: CODERROR {0}, TEXTERROR {1}",
                    //    nCodError.Value.ToString(), sTextError.Value.ToString()));
                }

                return retorno;
            }
            catch (Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }

        public string InsertRegRecaEnc(long folioPago, int rutAfiliado, string isapre, string email, long gastoCobTotal, long pagoTotal, 
            string tipo)
        {
            try
            {
                using (var context = new IsaWebProdEntities())
                {
                    var pr_sText = new System.Data.Entity.Core.Objects.ObjectParameter("pr_sText", typeof(string));

                    context.PKG_PAGOS_RECAUDACIONES_SP_INSERT_REGRECA_ENCABEZADO(folioPago, rutAfiliado, isapre, email, gastoCobTotal, pagoTotal,
                        tipo, pr_sText);

                    return pr_sText.Value.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }

        public string InsertRegRecaDet(long folioPago, int rutAfiliado, string isapre, string tipo, long deuda, long gastoCob, long honorario, 
            long interes, long pago, long reajuste, long recargo, int periodoRecau, int periodoRemun, int subProducto)
        {
            try
            {
                using (var context = new IsaWebProdEntities())
                {
                    var pr_sText = new System.Data.Entity.Core.Objects.ObjectParameter("pr_sText", typeof(string));

                    context.PKG_PAGOS_RECAUDACIONES_SP_INSERT_REGRECA_DETALLE(folioPago, rutAfiliado, isapre, tipo, deuda, gastoCob, honorario,
                        interes, pago, reajuste, recargo, periodoRecau, periodoRemun, subProducto, pr_sText);

                    return pr_sText.Value.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }

        public string UpdateRegReca(long folioPago, int rutAfiliado, string isapre, string tipo, string formaPago)
        {
            try
            {
                using (var context = new IsaWebProdEntities())
                {
                    var pr_sText = new System.Data.Entity.Core.Objects.ObjectParameter("pr_sText", typeof(string));

                    context.PKG_PAGOS_RECAUDACIONES_SP_ACTUALIZA_REGRECA(folioPago, rutAfiliado, isapre, tipo, formaPago, pr_sText);

                    return pr_sText.Value.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }

        public PagoRecaudacion ObtienePagoRecaudacion(long folioPago, int rutAfiliado, string isapre, string tipo)
        {
            try
            {       
                using (var context = new IsaWebProdEntities())
                {
                    var pr_sText = new System.Data.Entity.Core.Objects.ObjectParameter("pr_sText", typeof(string));

                    var detallesPagoEntity = context.PKG_PAGOS_RECAUDACIONES_SP_OBTIENE_DETALLE_PAGO(folioPago, rutAfiliado, isapre, tipo, pr_sText).ToList();

                    PagoRecaudacion pago = new PagoRecaudacion();
                    if (detallesPagoEntity != null)
                    {
                        MapperEntityToDTO mapper = new MapperEntityToDTO();
                        pago = mapper.ToDTO(detallesPagoEntity);
                    }

                    return pago;
                }
            }
            catch (Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }

        public ICollection<InfoFolioNegociacion> ObtieneFoliosNegociacion(int rutAfiliado, string isapre)
        {
            try
            {
                using (var wsNegociacionClient = new NegociacionService.NegociacionSoapClient())
                {
                    NegociacionService.Pago[] pagos = wsNegociacionClient.ObtenerPagosPorRutIsapre(rutAfiliado, isapre);

                    List<InfoFolioNegociacion> folios = new List<InfoFolioNegociacion>();
                    if (pagos != null)
                    {
                        MapperEntityToDTO mapper = new MapperEntityToDTO();
                        folios = mapper.ToDTO(pagos);
                    }

                    return folios;
                }
            }
            catch (Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }

        public string InsertaInfoPagoModulo(InfoPagoModulo infoPagoModulo, int rut, string isapre, string canal, int tipoPago, long folio, string formaPago)
        {
            try
            {
                using (var context = new PSucursalSucuEntities())
                {
                    var nCodError = new System.Data.Entity.Core.Objects.ObjectParameter("nCodError", typeof(decimal));
                    var sTextError = new System.Data.Entity.Core.Objects.ObjectParameter("sTextError", typeof(string));

                    context.PKG_PAGO_MODULO_SP_INSERTAPAGOMODULO(rut, canal, infoPagoModulo.codigoAutorizacion,
                        infoPagoModulo.dbTotal, infoPagoModulo.fechaContable, infoPagoModulo.fechaPago, folio, formaPago,
                        isapre, infoPagoModulo.marca, infoPagoModulo.monto, infoPagoModulo.numeroCta, infoPagoModulo.numeroTarjeta,
                        infoPagoModulo.numBoleta, infoPagoModulo.numOperacion, infoPagoModulo.terminal, tipoPago, infoPagoModulo.tipoTarjeta,
                        nCodError, sTextError);

                    return (nCodError.Value.ToString() == "0") ? "OK": sTextError.Value.ToString();
                }
            }
            catch(Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }

        public bool ActualizaAgencia(int agencia, long folioPago)
        {
            try
            {
                using (var context = new BancobroProdEntities())
                {
                    var out_Retorno = new System.Data.Entity.Core.Objects.ObjectParameter("out_Retorno", typeof(string));

                    context.PKG_RECAUDACIONES_SP_ACT_AGENCIA(agencia, folioPago, out_Retorno);

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }
    }
}
