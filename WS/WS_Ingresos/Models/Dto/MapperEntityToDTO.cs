using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WS_Ingresos.Models.Entities;

namespace WS_Ingresos.Models.Dto
{
    public class MapperEntityToDTO
    {
        public DetalleCotizaciones ToDTO(DetCotizacionesEntity entity)
        {
            DetalleCotizaciones dc = new DetalleCotizaciones();
            dc.FechaPago = entity.ABON_FECPAG;
            dc.MontoPago = Utils.formatoPeso(entity.ABON_VALOR.ToString());
            dc.PeriodoPago = entity.ABON_PEREM;
            dc.NombreRazonSocial = entity.EMPL_TNOMBRE_RAZON_SOCIAL;
            dc.RutEmpleador = Convert.ToInt32(entity.ENPA_RUT);
            dc.RutEmpleadorDV = Utils.formatoRut(entity.ENPA_RUT.ToString());
            return dc;
        }

        public CertificadoCotiza ToDTO(CertificadoCotizaEntity entity)
        {
            CertificadoCotiza cc = new CertificadoCotiza();
            cc.Periodo = Convert.ToInt32(entity.PERIODO);
            cc.Fecha = Convert.ToDateTime(entity.FECHA);
            cc.Pactado = entity.PACTADO.ToString();
            cc.Pagado = entity.PAGADO.ToString();
            cc.DNP =  entity.DNP.ToString();
            cc.FechaPago = entity.FECHAPAGO;
            cc.Licencia = entity.LICENCIA;
            return cc;
        }

        public AfiliadoCertificado ToDTO(AfiliadoCertificadoEntity entity)
        {
            AfiliadoCertificado ac = new AfiliadoCertificado();
            ac.vigencia = entity.AFIL_FINICIO_VIGENCIA_BENEFIC.ToString();
            ac.rut = Convert.ToInt32(entity.AFIL_NRUT);
            ac.nombre = entity.NOMBRE;

            return ac;
        }

        public Excedente ToDTO(DetalleExcedenteEntity entity)
        {
            Excedente excedente = new Excedente();
            excedente.premun = entity.CAEX_PREMUN;
            excedente.mexcedente = entity.CAEX_MEXCEDENTE == null ? "0" : ((decimal)entity.CAEX_MEXCEDENTE).ToString("N0");
            excedente.mreajuste = entity.CAEX_MREAJUSTE == null ? "0" : ((decimal)entity.CAEX_MREAJUSTE).ToString("N0");
            excedente.minteres = entity.CAEX_MINTERES == null ? "0" : ((decimal)entity.CAEX_MINTERES).ToString("N0");
            excedente.mcomision = entity.CAEX_MCOMISION == null ? "0" : ((decimal)entity.CAEX_MCOMISION).ToString("N0");
            excedente.msaldo = entity.CAEX_MSALDO == null ? "0" : ((decimal)entity.CAEX_MSALDO).ToString("N0");
            excedente.mdisponible = entity.CAEX_MDISPONIBLE == null ? "0" : ((decimal)entity.CAEX_MDISPONIBLE).ToString("N0");
            excedente.muso = entity.CAEX_MUSO == null ? "0" : ((decimal)entity.CAEX_MUSO).ToString("N0");

            return excedente;
        }

        public CotizacionesSubsidio ToDTO(CotizacionesSubsidioEntity entity)
        {
            CotizacionesSubsidio coti = new CotizacionesSubsidio();
            coti.AfpCaja = entity.CAFP;
            coti.CalTrabCot = entity.TRABAJADOR == null? 0 : (int)entity.TRABAJADOR;
            coti.DiasCot = entity.DIAS == null? 0 : (int)entity.DIAS;
            coti.Imponible = entity.IMPONIBLE == null? "0" : ((long)entity.IMPONIBLE).ToString("N0");
            coti.LicenciaCot = entity.LICENCIA == null? "0" : ((int)entity.LICENCIA).ToString("N0");
            coti.PeriodoCot = string.Format("{0} {1}", entity.PACO_FINICIO, entity.PACO_FFINAL);
            coti.Salud = entity.SALUD == null ? "0" : ((long)entity.SALUD).ToString("N0");
            coti.SCesantia = entity.MCESANTIA == null ? "0" : ((long)entity.MCESANTIA).ToString("N0");

            return coti;
        }

        public CotizacionesSubsidio2 ToDTO(CotizacionesSubsidio2Entity entity)
        {
            CotizacionesSubsidio2 coti = new CotizacionesSubsidio2();
            coti.periodoSub = string.Format("{0} {1}", entity.FINICIO, entity.FFINAL);
            coti.calTrabSub = entity.TRABAJADOR == null ? 0 : (int)entity.TRABAJADOR;
            coti.diasSub = entity.DIAS == null ? 0 : (int)entity.DIAS;
            coti.licenciaSub = entity.LICENCIA == null ? "0" : ((int)entity.LICENCIA).ToString("N0");
            coti.rentaNeta = entity.RENTA == null ? "0" : ((long)entity.RENTA).ToString("N0");
            coti.subsidio = entity.SUBSIDIO == null ? "0" : ((long)entity.SUBSIDIO).ToString("N0");

            return coti;
        }

        public Cargas ToDTO(CargasLogEntity entity)
        {
            Cargas carga = new Cargas();
            carga.ApMaterno = entity.CARG_TAPELLIDO_MATERNO;
            carga.ApPaterno = entity.CARG_TAPELLIDO_PATERNO;
            carga.Correlativo = Convert.ToInt32(entity.CARG_CCORR);
            carga.DV = entity.CARG_XDV;
            carga.FechaNacimiento = entity.CARG_FNACIMIENTO;
            carga.Nombres = entity.CARG_TNOMBRES;
            carga.Parentesco = entity.PARENTESCO;
            carga.Rut = Convert.ToInt32(entity.CARG_NRUT);
            carga.Sexo = entity.CARG_XSEXO;

            return carga;
        }

        public Cargas ToDTO(CargasEntity entity)
        {
            Cargas carga = new Cargas();
            carga.ApMaterno = entity.CARG_TAPELLIDO_MATERNO;
            carga.ApPaterno = entity.CARG_TAPELLIDO_PATERNO;
            carga.Correlativo = Convert.ToInt32(entity.CARG_CCORR);
            carga.DV = entity.CARG_XDV;
            carga.FechaNacimiento = entity.CARG_FNACIMIENTO;
            carga.Nombres = entity.CARG_TNOMBRES;
            carga.Parentesco = entity.PARENTESCO;
            carga.Rut = Convert.ToInt32(entity.CARG_NRUT);
            carga.Sexo = entity.CARG_XSEXO;

            return carga;
        }

        public DetalleDeuda ToDTO(DetalleDeudaEntity entity)
        {
            DetalleDeuda detalleDeuda = new DetalleDeuda();
            detalleDeuda.ValorDeuda = Convert.ToDouble(IntOrDefault(entity.DEUDA.ToString()));
            detalleDeuda.Gastos = Convert.ToDouble(IntOrDefault(entity.GASTOS.ToString()));
            detalleDeuda.Glosa = entity.GLOSA_SPRODUCTO;
            detalleDeuda.Interes = Convert.ToDouble(IntOrDefault(entity.INTERES.ToString()));
            detalleDeuda.Periodo = entity.PERIODO.ToString();
            detalleDeuda.Producto = entity.SPRODUCTO.ToString();
            detalleDeuda.Reajuste = Convert.ToDouble(IntOrDefault(entity.REAJUSTE.ToString()));
            detalleDeuda.Recargo = Convert.ToDouble(IntOrDefault(entity.RECARGO.ToString()));
            detalleDeuda.SubProducto = entity.SUBPRODUCTO.ToString();
            detalleDeuda.InteresRec = detalleDeuda.Interes + detalleDeuda.Recargo;
            detalleDeuda.Total = detalleDeuda.Reajuste + detalleDeuda.ValorDeuda + detalleDeuda.InteresRec + detalleDeuda.Gastos;

            return detalleDeuda;
        }

        public Periodo ToDTO(PeriodoEntity entity)
        {
            Periodo periodos = new Periodo();
            periodos.PeriodoPago = entity.PCOT_PREMUN;
            periodos.MontoPago = entity.PCOT_MPAGO.ToString();
            periodos.FechaPago = entity.PCOT_FCREACION;

            return periodos;
        }

        public Cuponera ToDTO(CotizacionEntity entity)
        {
            Cuponera cotizaciones = new Cuponera();
            cotizaciones.Block = entity.BLOCK;
            cotizaciones.Ciudad = entity.CIUDAD;
            cotizaciones.Comuna = entity.COMUNA;
            cotizaciones.Depto = entity.DEPTO;
            cotizaciones.Direccion = string.Format("{0} {1}", entity.CALLE, entity.NUMERO);
            cotizaciones.FechaUF = entity.F_UF_N;
            cotizaciones.FechaVencimiento = entity.F_VENCIM_N;
            cotizaciones.Folio = entity.SEC;
            cotizaciones.Independiente = entity.TITR_CCOD;
            cotizaciones.Monto = entity.COTIZ_PACTADA_N;
            cotizaciones.Nombre = string.Format("{0} {1} {2}", entity.AFIL_TAPELLIDO_PATERNO, entity.AFIL_TAPELLIDO_MATERNO, entity.AFIL_TNOMBRES);
            cotizaciones.Periodo = entity.PER_COTIZ_N;
            cotizaciones.Plan = entity.PLSA_CCD;
            cotizaciones.Rut = entity.AFIL_NRUT;
            cotizaciones.Villa = entity.VILLA;

            return cotizaciones;
        }

        public Cotizaciones ToDTO(CargoNewEntity entity)
        {
            Cotizaciones cotizaciones = new Cotizaciones();
            cotizaciones.PeriodoPago = entity.PERIODO.ToString(); ;
            cotizaciones.MontoUF = entity.VALOR.ToString();
            cotizaciones.Unidad = entity.UNIDAD;
            cotizaciones.MontoAPagar = entity.VALOR_PESOS.ToString();
            cotizaciones.FechaPago = entity.FECHA_REFERENCIA.ToString();
            cotizaciones.ValorGES = entity.MONTO_GES.ToString();
            cotizaciones.NewReajuste = entity.REAJUSTE.ToString();
            cotizaciones.NewInteres = entity.INTERES.ToString();
            cotizaciones.NewRecargo = entity.RECARGO.ToString() ;
            cotizaciones.NewValorTotal = entity.VALOR_TOTAL.ToString();

            return cotizaciones;
        }

        public ReqSuperIntendencia ToDTO(ReqSuperIntendenciaEntity entity)
        {
            ReqSuperIntendencia reqSuper = new ReqSuperIntendencia();
            reqSuper.TipoCotizacion = entity.TIPO_COTIZACION;
            reqSuper.Rut = entity.RUT;
            reqSuper.Periodo = entity.PERIODO;
            reqSuper.Estado = entity.ESTADO;
            reqSuper.NombreAseguradora = entity.NOMBRE_ASEGURADORA;
            reqSuper.Deso = entity.DESO_PERREMUN_AO.ToString();

            return reqSuper;
        }

        public DevolucionExcesos ToDTO(DevolucionExcesoEntity entity)
        {
            DevolucionExcesos devolucionEx = new DevolucionExcesos();
            devolucionEx.periodo = entity.TRAN_PREMUN.ToString();
            devolucionEx.excesoBruto = entity.MONTO_EXCESO.ToString();

            return devolucionEx;
        }

        public DevolucionExcesos ToDTO(DevolucionExcesosEntity entity)
        {
            DevolucionExcesos devolucionEx = new DevolucionExcesos();
            devolucionEx.periodo = entity.PERIODO_REMUNERACION.ToString();
            devolucionEx.excesoBruto = entity.MONTO_EXCESO.ToString();

            return devolucionEx;
        }

        public Documento ToDTO(DocumentoEntity entity)
        {
            Documento documento = new Documento();
            documento.Rut = entity.RUT;
            documento.Sociedad = entity.SOCIEDAD;
            documento.IdMaestro = entity.ID_MAESTRO;
            documento.Cuenta = entity.CUENTA;
            documento.DocumentoNumero = entity.DOCUMENTO;
            documento.FechaDoc = entity.FECHA_DOC;
            documento.ClaseDoc = entity.CLASE_DOC;
            documento.DocPago = entity.DOC_PAGO;
            documento.Valor = entity.VALOR.ToString();
            documento.Estado = entity.ESTADO;
            documento.MotivoGiro = entity.MOTIVO_GIRO;
            documento.Posicion = entity.POSICION.ToString();
            documento.GlosaTipoDocumento = entity.GLOSA_TIPO_DOCUMENTO;
            documento.GlosaEstado = entity.GLOSA_ESTADO;
            documento.FormaRevalidacion = entity.FORMA_REVALIDACION.ToString();

            return documento;
        }

        public InventarioDocumento ToDTO(InventarioDocumentoEntity entity)
        {
            InventarioDocumento inventario = new InventarioDocumento();
            inventario.FechaEmision = entity.FECHA_EMISION.ToString();
            inventario.TipoDocumento = entity.TIPO_DOCUMENTO;
            inventario.NumeroDocumento = entity.NUMERO_DOCUMENTO.ToString();
            inventario.Monto = entity.MONTO.ToString();

            return inventario;
        }

        public ReqSuperIntendencia ToDTO(ReqSuperIntendEntity entity)
        {
            ReqSuperIntendencia requerimientoSI = new ReqSuperIntendencia();
            requerimientoSI.Rut = entity.AFIL_NRUT.ToString();
            requerimientoSI.isapre = entity.ISAP_CEMPRESA;
            requerimientoSI.fecEmision = entity.FECHA_EMISION;
            requerimientoSI.motivo = entity.MOTIVO;
            requerimientoSI.monto = (Int64)entity.MONTO;
            requerimientoSI.formaPago = entity.FORMA_PAGO;
            requerimientoSI.nroDocumento = (Int64)entity.NUMERO_DOCUMENTO;
            requerimientoSI.estado = entity.ESTADO;
            requerimientoSI.procRevalidacion = entity.PROC_REVALIDACION;
            requerimientoSI.FecEmisionOrd = Int64.Parse(entity.FECHA_EMISION_ORDER);
            requerimientoSI.chedEstado = Int64.Parse(entity.CHEDA_ESTADO);
            requerimientoSI.pagEscalafon = entity.PAGE_ESCALAFON;

            return requerimientoSI;
        }

        public DatosAfiliado ToDTO(DatosAfiliadoEntity entity)
        {
            DatosAfiliado datosAfiliado = new DatosAfiliado();
            datosAfiliado.nombreCompleto = entity.TNOMBRES;
            datosAfiliado.rutCompleto = ((int)entity.AFIL_NRUT).ToString("N0") + "-" + entity.AFIL_XDV;
            datosAfiliado.direccion = entity.AFIL_TCALLE + " " + entity.AFIL_TNUMERO;
            datosAfiliado.comuna = entity.LOCA_TNOMBRE_COMUNA;
            datosAfiliado.ciudad = entity.LOCA_TNOMBRE_CIUDAD;
            datosAfiliado.fono = entity.AFIL_TFONO1 == null ? 0 : (long)entity.AFIL_TFONO1;

            return datosAfiliado;
        }

        public DatosEmpleador ToDTO(DatosEmpleadorEntity entity)
        {
            DatosEmpleador datosEmpleador = new DatosEmpleador();
            datosEmpleador.rut = (int)entity.RUT_EMPL;
            datosEmpleador.razonSocial = entity.EMPL_TNOMBRE_RAZON_SOCIAL;

            return datosEmpleador;
        }

        public PagoRecaudacion ToDTO(List<DetallePagoEntity> entity)
        {
            PagoRecaudacion pago = new PagoRecaudacion();
            pago.nombre = entity.FirstOrDefault().NOMBRE;
            pago.folioPago = (long)entity.FirstOrDefault().FOLIO_PAGO;
            pago.rutAfiliado = (int)entity.FirstOrDefault().AFIL_NRUT;
            pago.isapre = entity.FirstOrDefault().ISAP_CEMPRESA;
            pago.descripcionTipo = entity.FirstOrDefault().TIPO;
            pago.fechaPago = (DateTime)entity.FirstOrDefault().FECHA_PAGO;
            pago.formaPago = entity.FirstOrDefault().FORMA_PAGO;
            pago.mail = entity.FirstOrDefault().MAIL;
            pago.montoGastoCobTotal = entity.FirstOrDefault().MGASTOCOB_TOTAL != null ? (long)entity.FirstOrDefault().MGASTOCOB_TOTAL : 0;
            pago.montoPagoTotal = (long)entity.FirstOrDefault().MPAGO_TOTAL;
            
            List<DetallePeriodo> detalles = new List<DetallePeriodo>();
            foreach(var item in entity)
            {
                var detalle = new DetallePeriodo();
                detalle.periodoRemun = (int)item.PERIODO_REMUN;
                detalle.periodoRecau = (int)item.PERIODO_RECAU;
                detalle.montoDeuda = (long)item.MDEUDA;
                detalle.montoGastoCob = (long)item.MGASTOCOB;
                detalle.montoHonorario = (long)item.MHONORARIO;
                detalle.montoInteres = (long)item.MINTERES;
                detalle.montoPago = (long)item.MPAGO;
                detalle.montoReajuste = (long)item.MREAJUSTE;
                detalle.montoRecargo = (long)item.MRECARGO;
                detalle.subProducto = (int)item.SUBPRODUCTO;

                detalles.Add(detalle);
            }
            pago.detallesPago = detalles;

            return pago;
        }


        
        public List<InfoFolioNegociacion> ToDTO(NegociacionService.Pago[] entity)
        {
            List<InfoFolioNegociacion> folios = new List<InfoFolioNegociacion>();
            List<Periodo> periodos = new List<Periodo>();
            foreach(var item in entity)
            {
                var infoFolio = new InfoFolioNegociacion();
                infoFolio.folioPago = item.Folio;
                infoFolio.fechaGeneracion = item.FechaGeneracion;
                infoFolio.montoPago = item.MontoTotal;
                
                foreach(var itemP in item.Periodos)
                {
                    var periodo = new Periodo();
                    periodo.PeriodoPago = itemP.Periodo.ToString();
                    periodo.MontoPago = itemP.Monto.ToString();

                    periodos.Add(periodo);
                }

                infoFolio.periodos = periodos;

                folios.Add(infoFolio);
            }

            return folios;
        }

        public Pago ToDTO(PagoWebEntity entity)
        {
            Pago pa = new Pago();

            pa.idFolio = Convert.ToInt64(entity.FOLIO);
            pa.rutPago = Convert.ToInt32(entity.RUT);
            pa.montoPago = Convert.ToInt32(entity.MONTO);
            pa.estadoPago = Convert.ToInt32(entity.ESTADO);
            pa.fechaPago = Convert.ToDateTime(entity.FECHA);
            pa.tipoPago = entity.TIPOPAGO;
            pa.medioPago = Convert.ToInt32(entity.MEDIOPAGO);
            pa.isapre = Convert.ToInt32(entity.ISAPRE);

            return pa;
        }

        public Pago ToDTO(PagoRutEntity entity)
        {
            Pago pa = new Pago();

            pa.idFolio = Convert.ToInt32(entity.FOLIO);
            pa.rutPago = Convert.ToInt32(entity.RUT);
            pa.montoPago = Convert.ToInt32(entity.MONTO);
            pa.estadoPago = Convert.ToInt32(entity.ESTADO);
            pa.fechaPago = Convert.ToDateTime(entity.FECHA);
            pa.tipoPago = entity.TIPOPAGO;
            pa.medioPago = Convert.ToInt32(entity.MEDIOPAGO);
            pa.isapre = Convert.ToInt32(entity.ISAPRE);

            return pa;
        }

        public DetalleDeudas ToDTO2(DetalleDeudasEntity entity)
        {
            DetalleDeudas dd = new DetalleDeudas();

            dd.folioPago = Convert.ToInt32(entity.FOLIOPAGO);
            dd.premun = Convert.ToInt32(entity.REMUN);
            dd.csubproducto = Convert.ToInt32(entity.SUBPRODUCTO);
            dd.mdeuda = Convert.ToInt32(entity.DEUDA);
            dd.mreajuste = Convert.ToInt32(entity.REAJUSTE);
            dd.minteres = Convert.ToInt32(entity.INTERESES);
            dd.mrecargo = Convert.ToInt32(entity.RECARGO);
            dd.mhonorario = Convert.ToInt32(entity.HONORARIOS);
            dd.mpagototal = Convert.ToInt32(entity.PAGOTOTAL);

            return dd;
        }

        public LlenarPeriodos ToDTO(LlenarListaWebEntity entity)
        {
            LlenarPeriodos pe = new LlenarPeriodos();

            pe.codigo = Convert.ToInt32(entity.CODIGO);
            pe.descripcion = entity.DESCRIPCION;

            return pe;
        }

        public LlenarTipopago ToDTO2(LlenarListaWebEntity entity)
        {
            LlenarTipopago tp = new LlenarTipopago();

            tp.codigo = entity.CODIGO.ToString();
            tp.descripcion = entity.DESCRIPCION;

            return tp;
        }

        public LlenarMediopago ToDTO3(LlenarListaWebEntity entity)
        {
            LlenarMediopago tp = new LlenarMediopago();

            tp.codigo = entity.CODIGO.ToString();
            tp.descripcion = entity.DESCRIPCION;

            return tp;
        }

        public LlenarEstadopago ToDTO4(LlenarListaWebEntity entity)
        {
            LlenarEstadopago tp = new LlenarEstadopago();

            tp.codigo = entity.CODIGO.ToString();
            tp.descripcion = entity.DESCRIPCION;

            return tp;
        }

        public LlenarIsapre ToDTO5(LlenarListaWebEntity entity)
        {
            LlenarIsapre tp = new LlenarIsapre();

            tp.codigo = entity.CODIGO.ToString();
            tp.descripcion = entity.DESCRIPCION;

            return tp;
        }
        public string IntOrDefault(string value)
        {
            if (string.IsNullOrEmpty(value)) return "0";
            else return value;
        }
    }
}
