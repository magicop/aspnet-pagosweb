﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WS_Ingresos.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class IsaWebProdEntities : DbContext
    {
        public IsaWebProdEntities()
            : base("name=IsaWebProdEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<DevolucionExcesoEntity> PKG_CIRC_EXCESO_SALDO_PRC_SALDO_EXCESO(Nullable<decimal> p_AFIL_NRUT, string p_ISAPRE, string p_CANAL)
        {
            var p_AFIL_NRUTParameter = p_AFIL_NRUT.HasValue ?
                new ObjectParameter("P_AFIL_NRUT", p_AFIL_NRUT) :
                new ObjectParameter("P_AFIL_NRUT", typeof(decimal));
    
            var p_ISAPREParameter = p_ISAPRE != null ?
                new ObjectParameter("P_ISAPRE", p_ISAPRE) :
                new ObjectParameter("P_ISAPRE", typeof(string));
    
            var p_CANALParameter = p_CANAL != null ?
                new ObjectParameter("P_CANAL", p_CANAL) :
                new ObjectParameter("P_CANAL", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DevolucionExcesoEntity>("PKG_CIRC_EXCESO_SALDO_PRC_SALDO_EXCESO", p_AFIL_NRUTParameter, p_ISAPREParameter, p_CANALParameter);
        }
    
        public virtual ObjectResult<DevolucionExcesosEntity> PKG_CIRC_EXCESO_SALDO_SP_INVENTARIO_SALDO(Nullable<decimal> p_AFIL_NRUT, string p_ISAPRE, string p_CANAL)
        {
            var p_AFIL_NRUTParameter = p_AFIL_NRUT.HasValue ?
                new ObjectParameter("P_AFIL_NRUT", p_AFIL_NRUT) :
                new ObjectParameter("P_AFIL_NRUT", typeof(decimal));
    
            var p_ISAPREParameter = p_ISAPRE != null ?
                new ObjectParameter("P_ISAPRE", p_ISAPRE) :
                new ObjectParameter("P_ISAPRE", typeof(string));
    
            var p_CANALParameter = p_CANAL != null ?
                new ObjectParameter("P_CANAL", p_CANAL) :
                new ObjectParameter("P_CANAL", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DevolucionExcesosEntity>("PKG_CIRC_EXCESO_SALDO_SP_INVENTARIO_SALDO", p_AFIL_NRUTParameter, p_ISAPREParameter, p_CANALParameter);
        }
    
        public virtual ObjectResult<InventarioDocumentoEntity> PKG_CIRC_EXCESO_SALDO_SP_INVENTARIO_DOCUMENTOS(Nullable<decimal> p_AFIL_NRUT, string p_ISAPRE, string p_CANAL)
        {
            var p_AFIL_NRUTParameter = p_AFIL_NRUT.HasValue ?
                new ObjectParameter("P_AFIL_NRUT", p_AFIL_NRUT) :
                new ObjectParameter("P_AFIL_NRUT", typeof(decimal));
    
            var p_ISAPREParameter = p_ISAPRE != null ?
                new ObjectParameter("P_ISAPRE", p_ISAPRE) :
                new ObjectParameter("P_ISAPRE", typeof(string));
    
            var p_CANALParameter = p_CANAL != null ?
                new ObjectParameter("P_CANAL", p_CANAL) :
                new ObjectParameter("P_CANAL", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<InventarioDocumentoEntity>("PKG_CIRC_EXCESO_SALDO_SP_INVENTARIO_DOCUMENTOS", p_AFIL_NRUTParameter, p_ISAPREParameter, p_CANALParameter);
        }
    
        public virtual int PKG_CIRC_EXCESO_SALDO_SP_FECHA_INVENTARIO(string p_ISAPRE, string p_CANAL, ObjectParameter p_RETORNO)
        {
            var p_ISAPREParameter = p_ISAPRE != null ?
                new ObjectParameter("P_ISAPRE", p_ISAPRE) :
                new ObjectParameter("P_ISAPRE", typeof(string));
    
            var p_CANALParameter = p_CANAL != null ?
                new ObjectParameter("P_CANAL", p_CANAL) :
                new ObjectParameter("P_CANAL", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PKG_CIRC_EXCESO_SALDO_SP_FECHA_INVENTARIO", p_ISAPREParameter, p_CANALParameter, p_RETORNO);
        }
    
        public virtual int PKG_CIRC_EXCESO_SALDO_SP_GENERA_SOLICITUD_EXCESO(Nullable<decimal> p_AFIL_NRUT, string p_FORMA_PAGO, Nullable<decimal> p_AGENCIA_DESTINO, string p_CTACTE_NUMERO, string p_CTACTE_TIPO, string p_CTACTE_BANCO, string p_CANAL, string p_ISAPRE, ObjectParameter p_NUMERO_SOLICITUD, ObjectParameter p_TEXTO)
        {
            var p_AFIL_NRUTParameter = p_AFIL_NRUT.HasValue ?
                new ObjectParameter("P_AFIL_NRUT", p_AFIL_NRUT) :
                new ObjectParameter("P_AFIL_NRUT", typeof(decimal));
    
            var p_FORMA_PAGOParameter = p_FORMA_PAGO != null ?
                new ObjectParameter("P_FORMA_PAGO", p_FORMA_PAGO) :
                new ObjectParameter("P_FORMA_PAGO", typeof(string));
    
            var p_AGENCIA_DESTINOParameter = p_AGENCIA_DESTINO.HasValue ?
                new ObjectParameter("P_AGENCIA_DESTINO", p_AGENCIA_DESTINO) :
                new ObjectParameter("P_AGENCIA_DESTINO", typeof(decimal));
    
            var p_CTACTE_NUMEROParameter = p_CTACTE_NUMERO != null ?
                new ObjectParameter("P_CTACTE_NUMERO", p_CTACTE_NUMERO) :
                new ObjectParameter("P_CTACTE_NUMERO", typeof(string));
    
            var p_CTACTE_TIPOParameter = p_CTACTE_TIPO != null ?
                new ObjectParameter("P_CTACTE_TIPO", p_CTACTE_TIPO) :
                new ObjectParameter("P_CTACTE_TIPO", typeof(string));
    
            var p_CTACTE_BANCOParameter = p_CTACTE_BANCO != null ?
                new ObjectParameter("P_CTACTE_BANCO", p_CTACTE_BANCO) :
                new ObjectParameter("P_CTACTE_BANCO", typeof(string));
    
            var p_CANALParameter = p_CANAL != null ?
                new ObjectParameter("P_CANAL", p_CANAL) :
                new ObjectParameter("P_CANAL", typeof(string));
    
            var p_ISAPREParameter = p_ISAPRE != null ?
                new ObjectParameter("P_ISAPRE", p_ISAPRE) :
                new ObjectParameter("P_ISAPRE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PKG_CIRC_EXCESO_SALDO_SP_GENERA_SOLICITUD_EXCESO", p_AFIL_NRUTParameter, p_FORMA_PAGOParameter, p_AGENCIA_DESTINOParameter, p_CTACTE_NUMEROParameter, p_CTACTE_TIPOParameter, p_CTACTE_BANCOParameter, p_CANALParameter, p_ISAPREParameter, p_NUMERO_SOLICITUD, p_TEXTO);
        }
    
        public virtual ObjectResult<CotizacionEntity> PKG_COTIZACIONES_SP_OBTIENE_CUPON_PAGO(Nullable<decimal> pR_NRUT, string pR_SEMPRESA, ObjectParameter pR_STEXT)
        {
            var pR_NRUTParameter = pR_NRUT.HasValue ?
                new ObjectParameter("PR_NRUT", pR_NRUT) :
                new ObjectParameter("PR_NRUT", typeof(decimal));
    
            var pR_SEMPRESAParameter = pR_SEMPRESA != null ?
                new ObjectParameter("PR_SEMPRESA", pR_SEMPRESA) :
                new ObjectParameter("PR_SEMPRESA", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CotizacionEntity>("PKG_COTIZACIONES_SP_OBTIENE_CUPON_PAGO", pR_NRUTParameter, pR_SEMPRESAParameter, pR_STEXT);
        }
    
        public virtual ObjectResult<CargoNewEntity> PKG_COTIZACIONES_SP_OBTIENE_CARGO_NEW(Nullable<decimal> pR_NRUT, string pR_SEMPRESA, ObjectParameter pR_STEXT)
        {
            var pR_NRUTParameter = pR_NRUT.HasValue ?
                new ObjectParameter("PR_NRUT", pR_NRUT) :
                new ObjectParameter("PR_NRUT", typeof(decimal));
    
            var pR_SEMPRESAParameter = pR_SEMPRESA != null ?
                new ObjectParameter("PR_SEMPRESA", pR_SEMPRESA) :
                new ObjectParameter("PR_SEMPRESA", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CargoNewEntity>("PKG_COTIZACIONES_SP_OBTIENE_CARGO_NEW", pR_NRUTParameter, pR_SEMPRESAParameter, pR_STEXT);
        }
    
        public virtual ObjectResult<PeriodoEntity> PKG_COTIZACIONES_SP_OBTIENE_PERIODO_PAGADO(Nullable<decimal> pR_NRUT, string pR_SEMPRESA, ObjectParameter pR_STEXT)
        {
            var pR_NRUTParameter = pR_NRUT.HasValue ?
                new ObjectParameter("PR_NRUT", pR_NRUT) :
                new ObjectParameter("PR_NRUT", typeof(decimal));
    
            var pR_SEMPRESAParameter = pR_SEMPRESA != null ?
                new ObjectParameter("PR_SEMPRESA", pR_SEMPRESA) :
                new ObjectParameter("PR_SEMPRESA", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PeriodoEntity>("PKG_COTIZACIONES_SP_OBTIENE_PERIODO_PAGADO", pR_NRUTParameter, pR_SEMPRESAParameter, pR_STEXT);
        }
    
        public virtual int PKG_COTIZACIONES_INSERT_DATOS_COTIZA_NEW(Nullable<decimal> pR_NRUT, Nullable<decimal> pR_PRECAU, Nullable<decimal> pR_PREMUN, Nullable<decimal> pR_MPAGO, Nullable<System.DateTime> pR_FREFER, Nullable<System.DateTime> pR_FCREACION, string pR_XESTADO, string pR_CEMPRESA, Nullable<decimal> pR_REAJUSTE, Nullable<decimal> pR_INTERES, Nullable<decimal> pR_RECARGO, Nullable<decimal> pR_TOTAL, Nullable<decimal> pR_FOLIO, byte[] pR_WLPID)
        {
            var pR_NRUTParameter = pR_NRUT.HasValue ?
                new ObjectParameter("PR_NRUT", pR_NRUT) :
                new ObjectParameter("PR_NRUT", typeof(decimal));
    
            var pR_PRECAUParameter = pR_PRECAU.HasValue ?
                new ObjectParameter("PR_PRECAU", pR_PRECAU) :
                new ObjectParameter("PR_PRECAU", typeof(decimal));
    
            var pR_PREMUNParameter = pR_PREMUN.HasValue ?
                new ObjectParameter("PR_PREMUN", pR_PREMUN) :
                new ObjectParameter("PR_PREMUN", typeof(decimal));
    
            var pR_MPAGOParameter = pR_MPAGO.HasValue ?
                new ObjectParameter("PR_MPAGO", pR_MPAGO) :
                new ObjectParameter("PR_MPAGO", typeof(decimal));
    
            var pR_FREFERParameter = pR_FREFER.HasValue ?
                new ObjectParameter("PR_FREFER", pR_FREFER) :
                new ObjectParameter("PR_FREFER", typeof(System.DateTime));
    
            var pR_FCREACIONParameter = pR_FCREACION.HasValue ?
                new ObjectParameter("PR_FCREACION", pR_FCREACION) :
                new ObjectParameter("PR_FCREACION", typeof(System.DateTime));
    
            var pR_XESTADOParameter = pR_XESTADO != null ?
                new ObjectParameter("PR_XESTADO", pR_XESTADO) :
                new ObjectParameter("PR_XESTADO", typeof(string));
    
            var pR_CEMPRESAParameter = pR_CEMPRESA != null ?
                new ObjectParameter("PR_CEMPRESA", pR_CEMPRESA) :
                new ObjectParameter("PR_CEMPRESA", typeof(string));
    
            var pR_REAJUSTEParameter = pR_REAJUSTE.HasValue ?
                new ObjectParameter("PR_REAJUSTE", pR_REAJUSTE) :
                new ObjectParameter("PR_REAJUSTE", typeof(decimal));
    
            var pR_INTERESParameter = pR_INTERES.HasValue ?
                new ObjectParameter("PR_INTERES", pR_INTERES) :
                new ObjectParameter("PR_INTERES", typeof(decimal));
    
            var pR_RECARGOParameter = pR_RECARGO.HasValue ?
                new ObjectParameter("PR_RECARGO", pR_RECARGO) :
                new ObjectParameter("PR_RECARGO", typeof(decimal));
    
            var pR_TOTALParameter = pR_TOTAL.HasValue ?
                new ObjectParameter("PR_TOTAL", pR_TOTAL) :
                new ObjectParameter("PR_TOTAL", typeof(decimal));
    
            var pR_FOLIOParameter = pR_FOLIO.HasValue ?
                new ObjectParameter("PR_FOLIO", pR_FOLIO) :
                new ObjectParameter("PR_FOLIO", typeof(decimal));
    
            var pR_WLPIDParameter = pR_WLPID != null ?
                new ObjectParameter("PR_WLPID", pR_WLPID) :
                new ObjectParameter("PR_WLPID", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PKG_COTIZACIONES_INSERT_DATOS_COTIZA_NEW", pR_NRUTParameter, pR_PRECAUParameter, pR_PREMUNParameter, pR_MPAGOParameter, pR_FREFERParameter, pR_FCREACIONParameter, pR_XESTADOParameter, pR_CEMPRESAParameter, pR_REAJUSTEParameter, pR_INTERESParameter, pR_RECARGOParameter, pR_TOTALParameter, pR_FOLIOParameter, pR_WLPIDParameter);
        }
    
        public virtual ObjectResult<DetalleDeudaEntity> PKG_COTIZACIONES_SP_OBTIENE_DEUDA(Nullable<decimal> pR_NRUT, string pR_SEMPRESA, ObjectParameter pR_STEXT)
        {
            var pR_NRUTParameter = pR_NRUT.HasValue ?
                new ObjectParameter("PR_NRUT", pR_NRUT) :
                new ObjectParameter("PR_NRUT", typeof(decimal));
    
            var pR_SEMPRESAParameter = pR_SEMPRESA != null ?
                new ObjectParameter("PR_SEMPRESA", pR_SEMPRESA) :
                new ObjectParameter("PR_SEMPRESA", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DetalleDeudaEntity>("PKG_COTIZACIONES_SP_OBTIENE_DEUDA", pR_NRUTParameter, pR_SEMPRESAParameter, pR_STEXT);
        }
    
        public virtual ObjectResult<SecuenciaDeudaEntity> PKG_COTIZACIONES_SECUENCIA_PAGODEUDA()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SecuenciaDeudaEntity>("PKG_COTIZACIONES_SECUENCIA_PAGODEUDA");
        }
    
        public virtual int PKG_COTIZACIONES_INSERT_PAGO_DEUDA(Nullable<decimal> pR_NRUT, Nullable<decimal> pR_NPERIODO, Nullable<decimal> pR_NMONTO, Nullable<decimal> pR_NFOLIO, Nullable<decimal> pR_NSUBPRODUCTO, Nullable<decimal> pR_NDEUDA, Nullable<decimal> pR_NREAJUSTE, Nullable<decimal> pR_NINTERES, Nullable<decimal> pR_NRECARGO, Nullable<decimal> pR_NGASTOS, Nullable<decimal> pR_NHONORARIO)
        {
            var pR_NRUTParameter = pR_NRUT.HasValue ?
                new ObjectParameter("PR_NRUT", pR_NRUT) :
                new ObjectParameter("PR_NRUT", typeof(decimal));
    
            var pR_NPERIODOParameter = pR_NPERIODO.HasValue ?
                new ObjectParameter("PR_NPERIODO", pR_NPERIODO) :
                new ObjectParameter("PR_NPERIODO", typeof(decimal));
    
            var pR_NMONTOParameter = pR_NMONTO.HasValue ?
                new ObjectParameter("PR_NMONTO", pR_NMONTO) :
                new ObjectParameter("PR_NMONTO", typeof(decimal));
    
            var pR_NFOLIOParameter = pR_NFOLIO.HasValue ?
                new ObjectParameter("PR_NFOLIO", pR_NFOLIO) :
                new ObjectParameter("PR_NFOLIO", typeof(decimal));
    
            var pR_NSUBPRODUCTOParameter = pR_NSUBPRODUCTO.HasValue ?
                new ObjectParameter("PR_NSUBPRODUCTO", pR_NSUBPRODUCTO) :
                new ObjectParameter("PR_NSUBPRODUCTO", typeof(decimal));
    
            var pR_NDEUDAParameter = pR_NDEUDA.HasValue ?
                new ObjectParameter("PR_NDEUDA", pR_NDEUDA) :
                new ObjectParameter("PR_NDEUDA", typeof(decimal));
    
            var pR_NREAJUSTEParameter = pR_NREAJUSTE.HasValue ?
                new ObjectParameter("PR_NREAJUSTE", pR_NREAJUSTE) :
                new ObjectParameter("PR_NREAJUSTE", typeof(decimal));
    
            var pR_NINTERESParameter = pR_NINTERES.HasValue ?
                new ObjectParameter("PR_NINTERES", pR_NINTERES) :
                new ObjectParameter("PR_NINTERES", typeof(decimal));
    
            var pR_NRECARGOParameter = pR_NRECARGO.HasValue ?
                new ObjectParameter("PR_NRECARGO", pR_NRECARGO) :
                new ObjectParameter("PR_NRECARGO", typeof(decimal));
    
            var pR_NGASTOSParameter = pR_NGASTOS.HasValue ?
                new ObjectParameter("PR_NGASTOS", pR_NGASTOS) :
                new ObjectParameter("PR_NGASTOS", typeof(decimal));
    
            var pR_NHONORARIOParameter = pR_NHONORARIO.HasValue ?
                new ObjectParameter("PR_NHONORARIO", pR_NHONORARIO) :
                new ObjectParameter("PR_NHONORARIO", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PKG_COTIZACIONES_INSERT_PAGO_DEUDA", pR_NRUTParameter, pR_NPERIODOParameter, pR_NMONTOParameter, pR_NFOLIOParameter, pR_NSUBPRODUCTOParameter, pR_NDEUDAParameter, pR_NREAJUSTEParameter, pR_NINTERESParameter, pR_NRECARGOParameter, pR_NGASTOSParameter, pR_NHONORARIOParameter);
        }
    
        public virtual int PKG_CIRC_EXCESO_SALDO_SP_RETORNA_CUENTA_PRINCIPAL(Nullable<decimal> p_AFIL_NRUT, string p_ISAPRE, ObjectParameter p_NUMERO_CTA, ObjectParameter p_TIPO_CTA, ObjectParameter p_BANCO_CTA)
        {
            var p_AFIL_NRUTParameter = p_AFIL_NRUT.HasValue ?
                new ObjectParameter("P_AFIL_NRUT", p_AFIL_NRUT) :
                new ObjectParameter("P_AFIL_NRUT", typeof(decimal));
    
            var p_ISAPREParameter = p_ISAPRE != null ?
                new ObjectParameter("P_ISAPRE", p_ISAPRE) :
                new ObjectParameter("P_ISAPRE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PKG_CIRC_EXCESO_SALDO_SP_RETORNA_CUENTA_PRINCIPAL", p_AFIL_NRUTParameter, p_ISAPREParameter, p_NUMERO_CTA, p_TIPO_CTA, p_BANCO_CTA);
        }
    
        public virtual int PKG_CIRC_EXCESO_SALDO_PRC_AFILIADO_DEUDA(Nullable<decimal> p_AFIL_NRUT, string p_ISAPRE, ObjectParameter p_DEUDA)
        {
            var p_AFIL_NRUTParameter = p_AFIL_NRUT.HasValue ?
                new ObjectParameter("P_AFIL_NRUT", p_AFIL_NRUT) :
                new ObjectParameter("P_AFIL_NRUT", typeof(decimal));
    
            var p_ISAPREParameter = p_ISAPRE != null ?
                new ObjectParameter("P_ISAPRE", p_ISAPRE) :
                new ObjectParameter("P_ISAPRE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PKG_CIRC_EXCESO_SALDO_PRC_AFILIADO_DEUDA", p_AFIL_NRUTParameter, p_ISAPREParameter, p_DEUDA);
        }
    
        public virtual ObjectResult<CargasEntity> PKG_MIS_ANTECEDENTES_TRAERCARGAS(Nullable<decimal> pR_NRUT, string pR_SEMPRESA, ObjectParameter pR_STEXT)
        {
            var pR_NRUTParameter = pR_NRUT.HasValue ?
                new ObjectParameter("PR_NRUT", pR_NRUT) :
                new ObjectParameter("PR_NRUT", typeof(decimal));
    
            var pR_SEMPRESAParameter = pR_SEMPRESA != null ?
                new ObjectParameter("PR_SEMPRESA", pR_SEMPRESA) :
                new ObjectParameter("PR_SEMPRESA", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CargasEntity>("PKG_MIS_ANTECEDENTES_TRAERCARGAS", pR_NRUTParameter, pR_SEMPRESAParameter, pR_STEXT);
        }
    
        public virtual ObjectResult<CargasLogEntity> PKG_MIS_ANTECEDENTES_TRAERCARGASLOG(Nullable<decimal> pR_NRUT, string pR_SEMPRESA, Nullable<decimal> pR_CARG_CCORR, ObjectParameter pR_STEXT)
        {
            var pR_NRUTParameter = pR_NRUT.HasValue ?
                new ObjectParameter("PR_NRUT", pR_NRUT) :
                new ObjectParameter("PR_NRUT", typeof(decimal));
    
            var pR_SEMPRESAParameter = pR_SEMPRESA != null ?
                new ObjectParameter("PR_SEMPRESA", pR_SEMPRESA) :
                new ObjectParameter("PR_SEMPRESA", typeof(string));
    
            var pR_CARG_CCORRParameter = pR_CARG_CCORR.HasValue ?
                new ObjectParameter("PR_CARG_CCORR", pR_CARG_CCORR) :
                new ObjectParameter("PR_CARG_CCORR", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CargasLogEntity>("PKG_MIS_ANTECEDENTES_TRAERCARGASLOG", pR_NRUTParameter, pR_SEMPRESAParameter, pR_CARG_CCORRParameter, pR_STEXT);
        }
    
        public virtual ObjectResult<DatosAfiliadoEntity> PKG_MIS_ANTECEDENTES_DATOS_DEL_AFILIADO(Nullable<decimal> pR_NRUT, string pR_SEMPRESA, ObjectParameter pR_STEXT)
        {
            var pR_NRUTParameter = pR_NRUT.HasValue ?
                new ObjectParameter("PR_NRUT", pR_NRUT) :
                new ObjectParameter("PR_NRUT", typeof(decimal));
    
            var pR_SEMPRESAParameter = pR_SEMPRESA != null ?
                new ObjectParameter("PR_SEMPRESA", pR_SEMPRESA) :
                new ObjectParameter("PR_SEMPRESA", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DatosAfiliadoEntity>("PKG_MIS_ANTECEDENTES_DATOS_DEL_AFILIADO", pR_NRUTParameter, pR_SEMPRESAParameter, pR_STEXT);
        }
    
        public virtual ObjectResult<DetalleExcedenteEntity> PKG_COTIZACIONES_SP_CART_EXCED(Nullable<decimal> pRM_RUT_AFILIADO, string pRM_ISAP_CEMPRESA)
        {
            var pRM_RUT_AFILIADOParameter = pRM_RUT_AFILIADO.HasValue ?
                new ObjectParameter("PRM_RUT_AFILIADO", pRM_RUT_AFILIADO) :
                new ObjectParameter("PRM_RUT_AFILIADO", typeof(decimal));
    
            var pRM_ISAP_CEMPRESAParameter = pRM_ISAP_CEMPRESA != null ?
                new ObjectParameter("PRM_ISAP_CEMPRESA", pRM_ISAP_CEMPRESA) :
                new ObjectParameter("PRM_ISAP_CEMPRESA", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DetalleExcedenteEntity>("PKG_COTIZACIONES_SP_CART_EXCED", pRM_RUT_AFILIADOParameter, pRM_ISAP_CEMPRESAParameter);
        }
    
        public virtual ObjectResult<DatosEmpleadorEntity> PKG_ANTECEDENTES_DEL_EMPLEADOR_TRAEREMPLEADOR(Nullable<decimal> pR_NRUT, string pR_SEMPRESA, ObjectParameter pR_STEXT)
        {
            var pR_NRUTParameter = pR_NRUT.HasValue ?
                new ObjectParameter("PR_NRUT", pR_NRUT) :
                new ObjectParameter("PR_NRUT", typeof(decimal));
    
            var pR_SEMPRESAParameter = pR_SEMPRESA != null ?
                new ObjectParameter("PR_SEMPRESA", pR_SEMPRESA) :
                new ObjectParameter("PR_SEMPRESA", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DatosEmpleadorEntity>("PKG_ANTECEDENTES_DEL_EMPLEADOR_TRAEREMPLEADOR", pR_NRUTParameter, pR_SEMPRESAParameter, pR_STEXT);
        }
    
        public virtual int DATOS_DEL_EMPLEADOR(Nullable<decimal> rUTEMP, string iSAP, ObjectParameter sQL_EMPL_TAPELLIDO_PATERNO, ObjectParameter sQL_EMPL_TAPELLIDO_MATERNO, ObjectParameter sQL_EMPL_TNOMBRE_RAZON_SOCIAL, ObjectParameter sQL_EMPL_NRUT, ObjectParameter sQL_EMPL_XDV, ObjectParameter sQL_CEPA_TCALLE, ObjectParameter sQL_CEPA_TNUMERO, ObjectParameter sQL_CEPA_TDEPTO, ObjectParameter sQL_CEPA_TBLOCK, ObjectParameter sQL_CEPA_TVILLA, ObjectParameter sQL_COMUNA, ObjectParameter sQL_CIUDAD, ObjectParameter sQL_REGION, ObjectParameter sQL_STEXT)
        {
            var rUTEMPParameter = rUTEMP.HasValue ?
                new ObjectParameter("RUTEMP", rUTEMP) :
                new ObjectParameter("RUTEMP", typeof(decimal));
    
            var iSAPParameter = iSAP != null ?
                new ObjectParameter("ISAP", iSAP) :
                new ObjectParameter("ISAP", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DATOS_DEL_EMPLEADOR", rUTEMPParameter, iSAPParameter, sQL_EMPL_TAPELLIDO_PATERNO, sQL_EMPL_TAPELLIDO_MATERNO, sQL_EMPL_TNOMBRE_RAZON_SOCIAL, sQL_EMPL_NRUT, sQL_EMPL_XDV, sQL_CEPA_TCALLE, sQL_CEPA_TNUMERO, sQL_CEPA_TDEPTO, sQL_CEPA_TBLOCK, sQL_CEPA_TVILLA, sQL_COMUNA, sQL_CIUDAD, sQL_REGION, sQL_STEXT);
        }
    
        public virtual ObjectResult<SecuenciaCotizacionesEntity> PGK_COMPRA_BONOS_SECUENCIA_WEBPAY()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SecuenciaCotizacionesEntity>("PGK_COMPRA_BONOS_SECUENCIA_WEBPAY");
        }
    
        public virtual int PKG_PAGOS_RECAUDACIONES_SP_ACTUALIZA_REGRECA(Nullable<decimal> pR_NFOLIO, Nullable<decimal> pR_NRUT, string pR_CEMPRESA, string pR_STIPO, string pR_SFORMAPAGO, ObjectParameter pR_STEXT)
        {
            var pR_NFOLIOParameter = pR_NFOLIO.HasValue ?
                new ObjectParameter("PR_NFOLIO", pR_NFOLIO) :
                new ObjectParameter("PR_NFOLIO", typeof(decimal));
    
            var pR_NRUTParameter = pR_NRUT.HasValue ?
                new ObjectParameter("PR_NRUT", pR_NRUT) :
                new ObjectParameter("PR_NRUT", typeof(decimal));
    
            var pR_CEMPRESAParameter = pR_CEMPRESA != null ?
                new ObjectParameter("PR_CEMPRESA", pR_CEMPRESA) :
                new ObjectParameter("PR_CEMPRESA", typeof(string));
    
            var pR_STIPOParameter = pR_STIPO != null ?
                new ObjectParameter("PR_STIPO", pR_STIPO) :
                new ObjectParameter("PR_STIPO", typeof(string));
    
            var pR_SFORMAPAGOParameter = pR_SFORMAPAGO != null ?
                new ObjectParameter("PR_SFORMAPAGO", pR_SFORMAPAGO) :
                new ObjectParameter("PR_SFORMAPAGO", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PKG_PAGOS_RECAUDACIONES_SP_ACTUALIZA_REGRECA", pR_NFOLIOParameter, pR_NRUTParameter, pR_CEMPRESAParameter, pR_STIPOParameter, pR_SFORMAPAGOParameter, pR_STEXT);
        }
    
        public virtual int PKG_PAGOS_RECAUDACIONES_SP_INSERT_REGRECA_DETALLE(Nullable<decimal> pR_NFOLIO, Nullable<decimal> pR_NRUT, string pR_CEMPRESA, string pR_STIPO, Nullable<decimal> pR_NDEUDA, Nullable<decimal> pR_NGASTOCOB, Nullable<decimal> pR_NHONORARIO, Nullable<decimal> pR_NINTERES, Nullable<decimal> pR_NPAGO, Nullable<decimal> pR_NREAJUSTE, Nullable<decimal> pR_NRECARGO, Nullable<decimal> pR_NPERIODORECAU, Nullable<decimal> pR_NPERIODOREMUN, Nullable<decimal> pR_NSUBPRODUCTO, ObjectParameter pR_STEXT)
        {
            var pR_NFOLIOParameter = pR_NFOLIO.HasValue ?
                new ObjectParameter("PR_NFOLIO", pR_NFOLIO) :
                new ObjectParameter("PR_NFOLIO", typeof(decimal));
    
            var pR_NRUTParameter = pR_NRUT.HasValue ?
                new ObjectParameter("PR_NRUT", pR_NRUT) :
                new ObjectParameter("PR_NRUT", typeof(decimal));
    
            var pR_CEMPRESAParameter = pR_CEMPRESA != null ?
                new ObjectParameter("PR_CEMPRESA", pR_CEMPRESA) :
                new ObjectParameter("PR_CEMPRESA", typeof(string));
    
            var pR_STIPOParameter = pR_STIPO != null ?
                new ObjectParameter("PR_STIPO", pR_STIPO) :
                new ObjectParameter("PR_STIPO", typeof(string));
    
            var pR_NDEUDAParameter = pR_NDEUDA.HasValue ?
                new ObjectParameter("PR_NDEUDA", pR_NDEUDA) :
                new ObjectParameter("PR_NDEUDA", typeof(decimal));
    
            var pR_NGASTOCOBParameter = pR_NGASTOCOB.HasValue ?
                new ObjectParameter("PR_NGASTOCOB", pR_NGASTOCOB) :
                new ObjectParameter("PR_NGASTOCOB", typeof(decimal));
    
            var pR_NHONORARIOParameter = pR_NHONORARIO.HasValue ?
                new ObjectParameter("PR_NHONORARIO", pR_NHONORARIO) :
                new ObjectParameter("PR_NHONORARIO", typeof(decimal));
    
            var pR_NINTERESParameter = pR_NINTERES.HasValue ?
                new ObjectParameter("PR_NINTERES", pR_NINTERES) :
                new ObjectParameter("PR_NINTERES", typeof(decimal));
    
            var pR_NPAGOParameter = pR_NPAGO.HasValue ?
                new ObjectParameter("PR_NPAGO", pR_NPAGO) :
                new ObjectParameter("PR_NPAGO", typeof(decimal));
    
            var pR_NREAJUSTEParameter = pR_NREAJUSTE.HasValue ?
                new ObjectParameter("PR_NREAJUSTE", pR_NREAJUSTE) :
                new ObjectParameter("PR_NREAJUSTE", typeof(decimal));
    
            var pR_NRECARGOParameter = pR_NRECARGO.HasValue ?
                new ObjectParameter("PR_NRECARGO", pR_NRECARGO) :
                new ObjectParameter("PR_NRECARGO", typeof(decimal));
    
            var pR_NPERIODORECAUParameter = pR_NPERIODORECAU.HasValue ?
                new ObjectParameter("PR_NPERIODORECAU", pR_NPERIODORECAU) :
                new ObjectParameter("PR_NPERIODORECAU", typeof(decimal));
    
            var pR_NPERIODOREMUNParameter = pR_NPERIODOREMUN.HasValue ?
                new ObjectParameter("PR_NPERIODOREMUN", pR_NPERIODOREMUN) :
                new ObjectParameter("PR_NPERIODOREMUN", typeof(decimal));
    
            var pR_NSUBPRODUCTOParameter = pR_NSUBPRODUCTO.HasValue ?
                new ObjectParameter("PR_NSUBPRODUCTO", pR_NSUBPRODUCTO) :
                new ObjectParameter("PR_NSUBPRODUCTO", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PKG_PAGOS_RECAUDACIONES_SP_INSERT_REGRECA_DETALLE", pR_NFOLIOParameter, pR_NRUTParameter, pR_CEMPRESAParameter, pR_STIPOParameter, pR_NDEUDAParameter, pR_NGASTOCOBParameter, pR_NHONORARIOParameter, pR_NINTERESParameter, pR_NPAGOParameter, pR_NREAJUSTEParameter, pR_NRECARGOParameter, pR_NPERIODORECAUParameter, pR_NPERIODOREMUNParameter, pR_NSUBPRODUCTOParameter, pR_STEXT);
        }
    
        public virtual int PKG_PAGOS_RECAUDACIONES_SP_INSERT_REGRECA_ENCABEZADO(Nullable<decimal> pR_NFOLIO, Nullable<decimal> pR_NRUT, string pR_CEMPRESA, string pR_SMAIL, Nullable<decimal> pR_NGASTOCOBTOT, Nullable<decimal> pR_NPAGOTOT, string pR_STIPO, ObjectParameter pR_STEXT)
        {
            var pR_NFOLIOParameter = pR_NFOLIO.HasValue ?
                new ObjectParameter("PR_NFOLIO", pR_NFOLIO) :
                new ObjectParameter("PR_NFOLIO", typeof(decimal));
    
            var pR_NRUTParameter = pR_NRUT.HasValue ?
                new ObjectParameter("PR_NRUT", pR_NRUT) :
                new ObjectParameter("PR_NRUT", typeof(decimal));
    
            var pR_CEMPRESAParameter = pR_CEMPRESA != null ?
                new ObjectParameter("PR_CEMPRESA", pR_CEMPRESA) :
                new ObjectParameter("PR_CEMPRESA", typeof(string));
    
            var pR_SMAILParameter = pR_SMAIL != null ?
                new ObjectParameter("PR_SMAIL", pR_SMAIL) :
                new ObjectParameter("PR_SMAIL", typeof(string));
    
            var pR_NGASTOCOBTOTParameter = pR_NGASTOCOBTOT.HasValue ?
                new ObjectParameter("PR_NGASTOCOBTOT", pR_NGASTOCOBTOT) :
                new ObjectParameter("PR_NGASTOCOBTOT", typeof(decimal));
    
            var pR_NPAGOTOTParameter = pR_NPAGOTOT.HasValue ?
                new ObjectParameter("PR_NPAGOTOT", pR_NPAGOTOT) :
                new ObjectParameter("PR_NPAGOTOT", typeof(decimal));
    
            var pR_STIPOParameter = pR_STIPO != null ?
                new ObjectParameter("PR_STIPO", pR_STIPO) :
                new ObjectParameter("PR_STIPO", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PKG_PAGOS_RECAUDACIONES_SP_INSERT_REGRECA_ENCABEZADO", pR_NFOLIOParameter, pR_NRUTParameter, pR_CEMPRESAParameter, pR_SMAILParameter, pR_NGASTOCOBTOTParameter, pR_NPAGOTOTParameter, pR_STIPOParameter, pR_STEXT);
        }
    
        public virtual ObjectResult<DetallePagoEntity> PKG_PAGOS_RECAUDACIONES_SP_OBTIENE_DETALLE_PAGO(Nullable<decimal> pR_NFOLIO, Nullable<decimal> pR_NRUT, string pR_CEMPRESA, string pR_STIPO, ObjectParameter pR_STEXT)
        {
            var pR_NFOLIOParameter = pR_NFOLIO.HasValue ?
                new ObjectParameter("PR_NFOLIO", pR_NFOLIO) :
                new ObjectParameter("PR_NFOLIO", typeof(decimal));
    
            var pR_NRUTParameter = pR_NRUT.HasValue ?
                new ObjectParameter("PR_NRUT", pR_NRUT) :
                new ObjectParameter("PR_NRUT", typeof(decimal));
    
            var pR_CEMPRESAParameter = pR_CEMPRESA != null ?
                new ObjectParameter("PR_CEMPRESA", pR_CEMPRESA) :
                new ObjectParameter("PR_CEMPRESA", typeof(string));
    
            var pR_STIPOParameter = pR_STIPO != null ?
                new ObjectParameter("PR_STIPO", pR_STIPO) :
                new ObjectParameter("PR_STIPO", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DetallePagoEntity>("PKG_PAGOS_RECAUDACIONES_SP_OBTIENE_DETALLE_PAGO", pR_NFOLIOParameter, pR_NRUTParameter, pR_CEMPRESAParameter, pR_STIPOParameter, pR_STEXT);
        }
    
        public virtual ObjectResult<DetCotizacionesEntity> PKG_DETALLE_COTIZACIONES_DETCOTIZACIONES(Nullable<decimal> pR_NRUT, string pR_SEMPRESA, string pR_SNOMAFIL, ObjectParameter pR_STEXT)
        {
            var pR_NRUTParameter = pR_NRUT.HasValue ?
                new ObjectParameter("PR_NRUT", pR_NRUT) :
                new ObjectParameter("PR_NRUT", typeof(decimal));
    
            var pR_SEMPRESAParameter = pR_SEMPRESA != null ?
                new ObjectParameter("PR_SEMPRESA", pR_SEMPRESA) :
                new ObjectParameter("PR_SEMPRESA", typeof(string));
    
            var pR_SNOMAFILParameter = pR_SNOMAFIL != null ?
                new ObjectParameter("PR_SNOMAFIL", pR_SNOMAFIL) :
                new ObjectParameter("PR_SNOMAFIL", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DetCotizacionesEntity>("PKG_DETALLE_COTIZACIONES_DETCOTIZACIONES", pR_NRUTParameter, pR_SEMPRESAParameter, pR_SNOMAFILParameter, pR_STEXT);
        }
    }
}
