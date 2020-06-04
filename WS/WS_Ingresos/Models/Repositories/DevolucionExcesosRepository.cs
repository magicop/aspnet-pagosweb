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
    public class DevolucionExcesosRepository:IDevolucionExcesosRepository
    {
        public ICollection<DevolucionExcesos> GetSaldoExcesosDia(int rut, string isapre, string canal)
        {
            try
            {
                using (var context = new IsaWebProdEntities())
                {                                       
                    var devolucionExEntity = context.PKG_CIRC_EXCESO_SALDO_PRC_SALDO_EXCESO(rut, isapre, canal).ToList();

                    List<DevolucionExcesos> devolucionExcesos = new List<DevolucionExcesos>();
                    MapperEntityToDTO mapper = new MapperEntityToDTO();

                    foreach (var item in devolucionExEntity)
                    {
                        devolucionExcesos.Add(mapper.ToDTO(item));
                    }

                    return devolucionExcesos;
                }
            }
            catch (Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }

        public DetalleExcesosRegistroIndividual GetDetalleExcesosRegistroIndividual(int rut, string isapre, string canal)
        {
            try
            {
                using (var context = new IsaWebProdEntities())
                {
                    var out_pRetorno = new System.Data.Entity.Core.Objects.ObjectParameter("p_Retorno", typeof(string));
                    context.PKG_CIRC_EXCESO_SALDO_SP_FECHA_INVENTARIO(isapre, canal, out_pRetorno);

                    var devolucionesEntity = context.PKG_CIRC_EXCESO_SALDO_SP_INVENTARIO_SALDO(rut, isapre, canal).ToList();

                    var inventariosEntity = context.PKG_CIRC_EXCESO_SALDO_SP_INVENTARIO_DOCUMENTOS(rut, isapre, canal).ToList();

                    MapperEntityToDTO mapper = new MapperEntityToDTO();
                    DetalleExcesosRegistroIndividual detalle = new DetalleExcesosRegistroIndividual();

                    detalle.periodo = out_pRetorno.Value.ToString();

                    List<DevolucionExcesos> devolucionExcesos = new List<DevolucionExcesos>();
                    foreach (var item in devolucionesEntity)
                    {
                        devolucionExcesos.Add(mapper.ToDTO(item));
                    }

                    detalle.devoluciones = devolucionExcesos;

                    List<InventarioDocumento> inventarioDocumentos = new List<InventarioDocumento>();
                    foreach (var item in inventariosEntity)
                    {
                        inventarioDocumentos.Add(mapper.ToDTO(item));

                    }

                    detalle.documentos = inventarioDocumentos;

                    return detalle;
                }
            }
            catch (Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }

        public string PostSolicitudDevolucionExcesos(SolicitudDevolucionExcesos solicitud)
        {
            try
            {
                using (var context = new IsaWebProdEntities())
                {
                    var out_pNumeroSolicitud = new System.Data.Entity.Core.Objects.ObjectParameter("p_Numero_Solicitud", typeof(decimal));
                    var out_pTexto = new System.Data.Entity.Core.Objects.ObjectParameter("p_Texto", typeof(string));

                    context.PKG_CIRC_EXCESO_SALDO_SP_GENERA_SOLICITUD_EXCESO(solicitud.p_Afil_nRut, solicitud.p_Forma_Pago, solicitud.p_Agencia_Destino,
                        solicitud.p_CtaCte_Numero, solicitud.p_CtaCte_Tipo, solicitud.p_CtaCte_Banco, solicitud.p_Canal, solicitud.p_Isapre,
                        out_pNumeroSolicitud, out_pTexto);

                    MapperEntityToDTO mapper = new MapperEntityToDTO();                                        

                    return out_pTexto.Value.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }

        public string PostSolicitudReemision(List<SolicitudReemision> solicitudes)
        {
            try
            {
                using (var context = new IsaWebContEntities())
                {
                    var out_pCodigoError = new System.Data.Entity.Core.Objects.ObjectParameter("p_Codigo_Error", typeof(Int32));
                    var out_pTexto = new System.Data.Entity.Core.Objects.ObjectParameter("p_Texto", typeof(string));

                    foreach(var solicitud in solicitudes)
                    {
                        context.PKG_CIRC_EXCESO_DOCUMENTOS_PRC_ACTIVAR_DOCUMENTOSSAP(solicitud.Rut, solicitud.Sociedad, solicitud.IdMaestro,
                            solicitud.Cuenta, solicitud.DocumentoNumero, solicitud.FechaDoc, solicitud.ClaseDoc, solicitud.DocPago,
                            solicitud.Valor, solicitud.Estado, solicitud.MotivoGiro, solicitud.Posicion, solicitud.Canal, solicitud.FormaPago,
                            solicitud.AgenciaDestino, solicitud.CtaCteNumero, solicitud.CtaCteTipo, solicitud.CtaCteBanco, solicitud.FormaRevalidacion,
                            out_pCodigoError, out_pTexto);
                    }                    

                    MapperEntityToDTO mapper = new MapperEntityToDTO();

                    return out_pTexto.Value.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }

        public Cuenta GetCuenta(int rut, string isapre)
        {
            try
            {
                using (var context = new IsaWebProdEntities())
                {
                    var p_Numero_Cta = new System.Data.Entity.Core.Objects.ObjectParameter("p_Numero_Cta", typeof(string));
                    var p_Tipo_Cta = new System.Data.Entity.Core.Objects.ObjectParameter("p_Tipo_Cta", typeof(string));
                    var p_Banco_Cta = new System.Data.Entity.Core.Objects.ObjectParameter("p_Banco_Cta", typeof(string));

                    context.PKG_CIRC_EXCESO_SALDO_SP_RETORNA_CUENTA_PRINCIPAL(rut, isapre, p_Numero_Cta, p_Tipo_Cta, p_Banco_Cta);
                                        
                    Cuenta cuenta = new Cuenta();

                    cuenta.CuentaNumero = p_Numero_Cta.Value.ToString();
                    cuenta.BancoId = p_Banco_Cta.Value.ToString();
                    cuenta.CuentaTipo = p_Tipo_Cta.Value.ToString();

                    return cuenta;
                }
            }
            catch (Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }

        public string GetDeuda(int rut, string isapre)
        {
            try
            {
                using (var context = new IsaWebProdEntities())
                {
                    var p_deuda = new System.Data.Entity.Core.Objects.ObjectParameter("p_deuda", typeof(string));

                    context.PKG_CIRC_EXCESO_SALDO_PRC_AFILIADO_DEUDA(rut, isapre, p_deuda);

                    return p_deuda.Value.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }
    }
}