using WebPagos.Models.DTO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Script.Serialization;

namespace WebPagos.Models.RestApi
{
    public class IngresosRest 
    {

        #region Variables y Constructor
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public string urlrest { get; set; }

        // Pasa las credenciales para poder conectarse al sistema
        public IngresosRest()
        {
            urlrest = Convert.ToString(ConfigurationManager.AppSettings["RestApiIngresos"]);
            usuario = Convert.ToString(ConfigurationManager.AppSettings["UserIngresos"]);
            contrasena = Convert.ToString(ConfigurationManager.AppSettings["ContrasenaIngresos"]);
        }
        #endregion


        #region Métodos Pagos
        public List<Pago> GetPagos(long? idfolio, int? rut, int? monto, int? estado, DateTime? fechaDesde, DateTime? fechaHasta, string tipoPago, int? medioPago, int? isapre)
        {

            var aux_tipopago = (tipoPago == null) ? "null" : tipoPago;

            var fechavacia = Convert.ToDateTime("01-01-0001 0:00:00");

            var aux_fechad = (fechaDesde == null) ? string.Empty : (fechaDesde==DateTime.MinValue)? "01/01/1900" : ((DateTime)fechaDesde).ToShortDateString();
            var aux_fechah = (fechaHasta == null) ? string.Empty : (fechaHasta == DateTime.MinValue) ? "31/12/2200" : ((DateTime)fechaHasta).ToShortDateString();

            var aux_fechad2 = Convert.ToDateTime(aux_fechad).ToString("dd/MM/yyyy");
            var aux_fechah2 = Convert.ToDateTime(aux_fechah).ToString("dd/MM/yyyy");

            
            // Obtiene el link más los parametros
            var parametros = string.Format("/GetPagos/{0}/{1}/{2}/{3}/{4}/{5}/{6}/{7}/{8}", idfolio, rut, monto, estado, aux_fechad2, aux_fechah2, aux_tipopago, medioPago, isapre);
            JArray stuff = Utils.getServiceRest(urlrest, parametros, usuario, contrasena);

            var pagoList = new List<Pago>();

            if (stuff.Count > 0)
            {
                for (var i = 0; i < stuff.Count; i++)
                {
                    var pago = new Pago();

                    // Si stuff[i]["nombre"] no es nulo hacer la conversión
                    pago.idFolio = stuff[i]["idFolio"] != null ? Convert.ToInt64(stuff[i]["idFolio"].ToString()) : 0;
                    pago.rutPago = stuff[i]["rutPago"] != null ? Convert.ToInt32(stuff[i]["rutPago"].ToString()) : 0;
                    pago.montoPago = stuff[i]["montoPago"] != null ? Convert.ToInt32(stuff[i]["montoPago"].ToString()) : 0;
                    pago.estadoPago = Utils.EstadoPago(stuff[i]["estadoPago"] != null ? Convert.ToInt32(stuff[i]["estadoPago"].ToString()) : 0);
                    pago.fechaPago = stuff[i]["fechaPago"] != null ? Convert.ToDateTime(stuff[i]["fechaPago"].ToString()) : DateTime.Now;
                    pago.tipoPago = stuff[i]["tipoPago"] != null ? stuff[i]["tipoPago"].ToString() : string.Empty;
                    pago.medioPago = stuff[i]["medioPago"] != null ? Convert.ToInt32(stuff[i]["medioPago"].ToString()) : 0;
                    pago.isapre = Utils.IsaprePago(stuff[i]["isapre"] != null ? Convert.ToInt32(stuff[i]["isapre"].ToString()) : 0);

                    pagoList.Add(pago);
                }
            }

            return pagoList;
        }

        public List<Pago> GetPagoRut(int rutpago)
        {
            var parametros = string.Format("/GetPagoRut/{0}", rutpago);
            JArray stuff = Utils.getServiceRest(urlrest, parametros, usuario, contrasena);

            var pagoList = new List<Pago>();

            if (stuff.Count > 0)
            {
                for (var i = 0; i < stuff.Count; i++)
                {
                    var pago = new Pago();

                    pago.idFolio = stuff[i]["idFolio"] != null ? Convert.ToInt32(stuff[i]["idFolio"].ToString()) : 0;
                    pago.rutPago = stuff[i]["rutPago"] != null ? Convert.ToInt32(stuff[i]["rutPago"].ToString()) : 0;
                    pago.montoPago = stuff[i]["montoPago"] != null ? Convert.ToInt32(stuff[i]["montoPago"].ToString()) : 0;
                    pago.estadoPago = Utils.EstadoPago(stuff[i]["estadoPago"] != null ? Convert.ToInt32(stuff[i]["estadoPago"].ToString()) : 0);
                    pago.fechaPago = stuff[i]["fechaPago"] != null ? Convert.ToDateTime(stuff[i]["fechaPago"].ToString()) : DateTime.Now;
                    pago.tipoPago = stuff[i]["tipoPago"] != null ? stuff[i]["tipoPago"].ToString() : string.Empty;
                    pago.medioPago = stuff[i]["medioPago"] != null ? Convert.ToInt32(stuff[i]["medioPago"].ToString()) : 0;
                    pago.isapre = Utils.IsaprePago(stuff[i]["isapre"] != null ? Convert.ToInt32(stuff[i]["isapre"].ToString()) : 0);

                    pagoList.Add(pago);
                }
            }

            return pagoList;
        }

        public bool PostRegularizar(int rut, int i_wtp_id)
        {
            var parametros = string.Format("/RegularizarPago/{0}/{1}", rut, i_wtp_id);
            bool ok = Utils.postServiceRest(urlrest, parametros, usuario, contrasena);

            return ok;
        }
        #endregion

        #region Métodos Deuda
        public List<Deuda> GetDetalleDeudas(int periodo)
        {
            var parametros = string.Format("/GetDetalleDeudas/{0}", periodo);
            JArray stuff = Utils.getServiceRest(urlrest, parametros, usuario, contrasena);

            var deudaList = new List<Deuda>();

            if (stuff.Count > 0)
            {
                for (var i = 0; i < stuff.Count; i++)
                {
                    var deuda = new Deuda();

                    deuda.folioPago = stuff[i]["folioPago"] != null ? Convert.ToInt32(stuff[i]["folioPago"].ToString()) : 0;
                    deuda.premun = stuff[i]["premun"] != null ? Convert.ToInt32(stuff[i]["premun"].ToString()) : 0;
                    deuda.csubproducto = stuff[i]["csubproducto"] != null ? Convert.ToInt32(stuff[i]["csubproducto"].ToString()) : 0;
                    deuda.mdeuda = stuff[i]["mdeuda"] != null ? Convert.ToInt32(stuff[i]["mdeuda"].ToString()) : 0;
                    deuda.mreajuste = stuff[i]["mreajuste"] != null ? Convert.ToInt32(stuff[i]["mreajuste"].ToString()) : 0;
                    deuda.minteres = stuff[i]["interes"] != null ? Convert.ToInt32(stuff[i]["interes"].ToString()) : 0;
                    deuda.mrecargo = stuff[i]["mrecargo"] != null ? Convert.ToInt32(stuff[i]["mrecargo"].ToString()) : 0;
                    deuda.mhonorario = stuff[i]["mhonorario"] != null ? Convert.ToInt32(stuff[i]["mhonorario"].ToString()) : 0;
                    deuda.mpagototal = stuff[i]["mpagototal"] != null ? Convert.ToInt32(stuff[i]["mpagototal"].ToString()) : 0;

                    deudaList.Add(deuda);
                }
            }

            return deudaList;
        }
        #endregion

        #region Métodos Lista
        public List<LlenarPeriodos> GetPeriodos()
        {
            var parametros = string.Format("/GetListaPeriodos/");
            JArray stuff = Utils.getServiceRest(urlrest, parametros, usuario, contrasena);

            var periodosList = new List<LlenarPeriodos>();

            if (stuff.Count > 0)
            {
                for (var i = 0; i < stuff.Count; i++)
                {
                    var periodo = new LlenarPeriodos();

                    periodo.codigo = stuff[i]["codigo"] != null ? Convert.ToInt32(stuff[i]["codigo"].ToString()) : 0;
                    periodo.descripcion = stuff[i]["descripcion"] != null ? stuff[i]["descripcion"].ToString() : string.Empty;

                    periodosList.Add(periodo);
                }
            }

            return periodosList;
        }

        public List<LlenarTipopago> GetTipopago()
        {
            var parametros = string.Format("/GetListaTipopagos/");
            JArray stuff = Utils.getServiceRest(urlrest, parametros, usuario, contrasena);

            var tpList = new List<LlenarTipopago>();

            if (stuff.Count > 0)
            {
                for (var i = 0; i < stuff.Count; i++)
                {
                    var tipopago = new LlenarTipopago();

                    tipopago.codigo = stuff[i]["codigo"] != null ? stuff[i]["codigo"].ToString() : string.Empty;
                    tipopago.descripcion = stuff[i]["descripcion"] != null ? stuff[i]["descripcion"].ToString() : string.Empty;

                    tpList.Add(tipopago);
                }
            }

            return tpList;
        }

        public List<LlenarMediopago> GetMediopago()
        {
            var parametros = string.Format("/GetListaMediopagos/");
            JArray stuff = Utils.getServiceRest(urlrest, parametros, usuario, contrasena);

            var tpList = new List<LlenarMediopago>();

            if (stuff.Count > 0)
            {
                for (var i = 0; i < stuff.Count; i++)
                {
                    var tipopago = new LlenarMediopago();

                    tipopago.codigo = stuff[i]["codigo"] != null ? Convert.ToInt32(stuff[i]["codigo"].ToString()) : 0;
                    tipopago.descripcion = stuff[i]["descripcion"] != null ? stuff[i]["descripcion"].ToString() : string.Empty;

                    tpList.Add(tipopago);
                }
            }

            return tpList;
        }
  

        public List<LlenarEstadopago> GetEstadopago()
        {
            var parametros = string.Format("/GetListaEstadopagos/");
            JArray stuff = Utils.getServiceRest(urlrest, parametros, usuario, contrasena);

            var tpList = new List<LlenarEstadopago>();

            if (stuff.Count > 0)
            {
                for (var i = 0; i < stuff.Count; i++)
                {
                    var tipopago = new LlenarEstadopago();

                    tipopago.codigo = stuff[i]["codigo"] != null ? Convert.ToInt32(stuff[i]["codigo"].ToString()) : 0;
                    tipopago.descripcion = stuff[i]["descripcion"] != null ? stuff[i]["descripcion"].ToString() : string.Empty;

                    tpList.Add(tipopago);
                }
            }

            return tpList;
        }

        public List<LlenarIsapre> GetIsapre()
        {
            var parametros = string.Format("/GetListaIsapres/");
            JArray stuff = Utils.getServiceRest(urlrest, parametros, usuario, contrasena);

            var tpList = new List<LlenarIsapre>();

            if (stuff.Count > 0)
            {
                for (var i = 0; i < stuff.Count; i++)
                {
                    var tipopago = new LlenarIsapre();

                    tipopago.codigo = stuff[i]["codigo"] != null ? Convert.ToInt32(stuff[i]["codigo"].ToString()) : 0;
                    tipopago.descripcion = stuff[i]["descripcion"] != null ? stuff[i]["descripcion"].ToString() : string.Empty;

                    tpList.Add(tipopago);
                }
            }

            return tpList;
        }
        #endregion

        #region Comentarios
        //public List<Buzon_Web> GetListaDocumentos(int idMotivo)
        //{
        //    var Buzon_WebList = new List<Buzon_Web>();

        //    var parametros = string.Format("GetListaBuzonWeb/{0}", idMotivo);
        //    JArray stuff = Utils.getServiceRest(urlrest, parametros, usuario, contrasena);

        //    if (stuff.Count > 0)
        //    {
        //        for (var i = 0; i < stuff.Count; i++)
        //        {
        //            var buzon_Web = new Buzon_Web();

        //            buzon_Web.IdDocumento = stuff[i]["IdDocumento"] != null ? Convert.ToInt32(stuff[i]["IdDocumento"].ToString()) : 0;
        //            buzon_Web.Descripcion = stuff[i]["Descripcion"] != null ? stuff[i]["Descripcion"].ToString() : string.Empty;

        //            Buzon_WebList.Add(buzon_Web);
        //        }
        //    }
        //    return Buzon_WebList;
        //}

        //public bool PostInsertaSoliBuzonWebEncabezado(long idSolicitud, int rutAfil, int rutCarga, string isapre)
        //{
        //    var parametros = string.Format("PostInsertaSoliBuzonWebEncabezado/{0}/{1}/{2}/{3}", idSolicitud, rutAfil, rutCarga, isapre);
        //    var ok = Utils.postServiceRest(urlrest, parametros, usuario, contrasena);

        //    return ok;
        //}

        //public bool PostInsertaSoliBuzonWebDetalle(long idSolicitud, int idDocumento, string nombreArchivo, string observacion)
        //{
        //    var serializer = new JavaScriptSerializer();
        //    string jsonObject = serializer.Serialize(new { idSolicitud = idSolicitud, idDocumento = idDocumento, nombreArchivo = nombreArchivo, observacion = observacion });            
        //    string urlWS = urlrest + "PostInsertaSoliBuzonWebDetalle";
        //    var ok = Utils.postServiceRestJson(urlWS, jsonObject, usuario, contrasena);

        //    return ok;
        //}

        //public bool PostEditarArchivoBuzonWeb(int idArchivo, long idSolicitud, int idDocumento, string nombreArchivo, string observacion)
        //{
        //    var serializer = new JavaScriptSerializer();
        //    string jsonObject = serializer.Serialize(new { idArchivo = idArchivo, idSolicitud = idSolicitud, idDocumento = idDocumento, nombreArchivo = nombreArchivo, observacion = observacion });
        //    string urlWS = urlrest + "PostEditarArchivoBuzonWeb";
        //    var ok = Utils.postServiceRestJson(urlWS, jsonObject, usuario, contrasena);

        //    return ok;
        //}

        //public List<Buzon_Web> GetArchivosBuzonWeb(long idSolicitud)
        //{
        //    var Buzon_WebList = new List<Buzon_Web>();

        //    var parametros = string.Format("GetArchivosBuzonWeb/{0}", idSolicitud);
        //    JArray stuff = Utils.getServiceRest(urlrest, parametros, usuario, contrasena);

        //    if (stuff.Count > 0)
        //    {
        //        for (var i = 0; i < stuff.Count; i++)
        //        {
        //            var buzon_Web = new Buzon_Web();

        //            buzon_Web.RutAfil = stuff[i]["RutAfil"] != null ? Convert.ToInt32(stuff[i]["RutAfil"].ToString()) : 0;
        //            buzon_Web.AreaBackOffice = stuff[i]["AreaBackOffice"] != null ? Utils.Capitalize(stuff[i]["AreaBackOffice"].ToString()) : string.Empty;
        //            buzon_Web.CanalEnvio = stuff[i]["CanalEnvio"] != null ? Utils.Capitalize(stuff[i]["CanalEnvio"].ToString()) : string.Empty;
        //            buzon_Web.RutCarg = stuff[i]["RutCarg"] != null ? Convert.ToInt32(stuff[i]["RutCarg"].ToString()) : 0;
        //            buzon_Web.Descripcion = stuff[i]["Descripcion"] != null ? Utils.Capitalize(stuff[i]["Descripcion"].ToString()) : string.Empty;
        //            buzon_Web.Estado = stuff[i]["Estado"] != null ? Utils.Capitalize(stuff[i]["Estado"].ToString()) : string.Empty;
        //            buzon_Web.FechaHora = stuff[i]["FechaHora"] != null ? Convert.ToDateTime(stuff[i]["FechaHora"].ToString()) : DateTime.Now;
        //            buzon_Web.IdDocumento = stuff[i]["IdDocumento"] != null ? Convert.ToInt32(stuff[i]["IdDocumento"].ToString()) : 0;
        //            buzon_Web.IdSolicitud = stuff[i]["IdSolicitud"] != null ? Convert.ToInt64(stuff[i]["IdSolicitud"].ToString()) : 0;
        //            buzon_Web.Isapre = stuff[i]["Isapre"] != null ? Utils.Capitalize(stuff[i]["Isapre"].ToString()) : string.Empty;
        //            buzon_Web.MailDestinatario = stuff[i]["MailDestinatario"] != null ? Utils.Capitalize(stuff[i]["MailDestinatario"].ToString()) : string.Empty;
        //            buzon_Web.Motivo = stuff[i]["Motivo"] != null ? Utils.Capitalize(stuff[i]["Motivo"].ToString()) : string.Empty;
        //            buzon_Web.NombreArchivo = stuff[i]["NombreArchivo"] != null ? stuff[i]["NombreArchivo"].ToString() : string.Empty;
        //            buzon_Web.Observacion = stuff[i]["Observacion"] != null ? stuff[i]["Observacion"].ToString() : string.Empty;
        //            buzon_Web.IdArchivo = stuff[i]["IdArchivo"] != null ? Convert.ToInt32(stuff[i]["IdArchivo"].ToString()) : 0;

        //            Buzon_WebList.Add(buzon_Web);
        //        }
        //    }
        //    return Buzon_WebList;
        //}

        //public List<Buzon_Web> GetArchivosBuzonWeb(long idSolicitud, string areaBackOffice)
        //{
        //    var Buzon_WebList = new List<Buzon_Web>();

        //    var parametros = string.Format("GetArchivosBuzonWebBackOffice/{0}/{1}", idSolicitud, areaBackOffice);
        //    JArray stuff = Utils.getServiceRest(urlrest, parametros, usuario, contrasena);

        //    if (stuff.Count > 0)
        //    {
        //        for (var i = 0; i < stuff.Count; i++)
        //        {
        //            var buzon_Web = new Buzon_Web();

        //            buzon_Web.RutAfil = stuff[i]["RutAfil"] != null ? Convert.ToInt32(stuff[i]["RutAfil"].ToString()) : 0;
        //            buzon_Web.AreaBackOffice = stuff[i]["AreaBackOffice"] != null ? Utils.Capitalize(stuff[i]["AreaBackOffice"].ToString()) : string.Empty;
        //            buzon_Web.CanalEnvio = stuff[i]["CanalEnvio"] != null ? Utils.Capitalize(stuff[i]["CanalEnvio"].ToString()) : string.Empty;
        //            buzon_Web.RutCarg = stuff[i]["RutCarg"] != null ? Convert.ToInt32(stuff[i]["RutCarg"].ToString()) : 0;
        //            buzon_Web.Descripcion = stuff[i]["Descripcion"] != null ? Utils.Capitalize(stuff[i]["Descripcion"].ToString()) : string.Empty;
        //            buzon_Web.Estado = stuff[i]["Estado"] != null ? Utils.Capitalize(stuff[i]["Estado"].ToString()) : string.Empty;
        //            buzon_Web.FechaHora = stuff[i]["FechaHora"] != null ? Convert.ToDateTime(stuff[i]["FechaHora"].ToString()) : DateTime.Now;
        //            buzon_Web.IdDocumento = stuff[i]["IdDocumento"] != null ? Convert.ToInt32(stuff[i]["IdDocumento"].ToString()) : 0;
        //            buzon_Web.IdSolicitud = stuff[i]["IdSolicitud"] != null ? Convert.ToInt64(stuff[i]["IdSolicitud"].ToString()) : 0;
        //            buzon_Web.Isapre = stuff[i]["Isapre"] != null ? Utils.Capitalize(stuff[i]["Isapre"].ToString()) : string.Empty;
        //            buzon_Web.MailDestinatario = stuff[i]["MailDestinatario"] != null ? stuff[i]["MailDestinatario"].ToString() : string.Empty;
        //            buzon_Web.Motivo = stuff[i]["Motivo"] != null ? Utils.Capitalize(stuff[i]["Motivo"].ToString()) : string.Empty;
        //            buzon_Web.NombreArchivo = stuff[i]["NombreArchivo"] != null ? stuff[i]["NombreArchivo"].ToString() : string.Empty;
        //            buzon_Web.Observacion = stuff[i]["Observacion"] != null ? stuff[i]["Observacion"].ToString() : string.Empty;
        //            buzon_Web.IdArchivo = stuff[i]["IdArchivo"] != null ? Convert.ToInt32(stuff[i]["IdArchivo"].ToString()) : 0;

        //            Buzon_WebList.Add(buzon_Web);
        //        }
        //    }
        //    return Buzon_WebList;
        //}

        //public bool PostBorrarArchivoBuzonWeb(int idArchivo, long idSolicitud)
        //{
        //    var parametros = string.Format("PostBorrarArchivoBuzonWeb/{0}/{1}", idArchivo, idSolicitud);
        //    bool ok = Utils.postServiceRest(urlrest, parametros, usuario, contrasena);

        //    return ok;
        //}

        //public bool PostActualizarSoliBuzonWeb(long idSolicitud)
        //{
        //    var parametros = string.Format("PostActualizarSoliBuzonWeb/{0}", idSolicitud);
        //    bool ok = Utils.postServiceRest(urlrest, parametros, usuario, contrasena);

        //    return ok;
        //}

        //public long GetIdSoliBuzonWeb()
        //{
        //    var parametros = string.Format("GetIdSoliBuzonWeb");
        //    var id = Utils.getServiceRest(urlrest, parametros, usuario, contrasena);

        //    return id;
        //}

        //public List<Buzon_Web> GetSoliBuzonWeb(int rutAfil, int rutCarga, string isapre)
        //{
        //    List<Buzon_Web> SoliList = new List<Buzon_Web>();

        //    var parametros = string.Format("GetSoliBuzonWeb/{0}/{1}/{2}", rutAfil, rutCarga, isapre);
        //    JArray stuff = Utils.getServiceRest(urlrest, parametros, usuario, contrasena);

        //    if (stuff.Count > 0)
        //    {
        //        for (var i = 0; i < stuff.Count; i++)
        //        {
        //            var buzon_Web = new Buzon_Web();

        //            buzon_Web.IdSolicitud = stuff[i]["IdSolicitud"] != null ? Convert.ToInt32(stuff[i]["IdSolicitud"].ToString()) : 0;
        //            buzon_Web.FechaHora = stuff[i]["FechaHora"] != null ? Convert.ToDateTime(stuff[i]["FechaHora"].ToString()) : DateTime.Now;

        //            SoliList.Add(buzon_Web);
        //        }
        //    }
        //    return SoliList;
        //}

        //public List<Buzon_Web> GetListaMotivos()
        //{
        //    List<Buzon_Web> MotiList = new List<Buzon_Web>();

        //    var parametros = string.Format("GetListaMotivos/");
        //    JArray stuff = Utils.getServiceRest(urlrest, parametros, usuario, contrasena);

        //    if (stuff.Count > 0)
        //    {
        //        for (var i = 0; i < stuff.Count; i++)
        //        {
        //            Buzon_Web buzon_Web = new Buzon_Web();

        //            buzon_Web.IdMotivo = stuff[i]["IdMotivo"] != null ? Convert.ToInt32(stuff[i]["IdMotivo"].ToString()) : 0;
        //            buzon_Web.Motivo = stuff[i]["Motivo"] != null ? stuff[i]["Motivo"].ToString() : string.Empty;

        //            MotiList.Add(buzon_Web);
        //        }
        //    }
        //    return MotiList;
        //}

        //public List<Buzon_Web> GetBackOffice(long idSolicitud)
        //{
        //    var Buzon_WebList = new List<Buzon_Web>();

        //    var parametros = string.Format("GetBackOffice/{0}", idSolicitud);
        //    JArray stuff = Utils.getServiceRest(urlrest, parametros, usuario, contrasena);

        //    if (stuff.Count > 0)
        //    {
        //        for (var i = 0; i < stuff.Count; i++)
        //        {
        //            var buzon_Web = new Buzon_Web();
        //            buzon_Web.AreaBackOffice = stuff[i]["AreaBackOffice"] != null ? stuff[i]["AreaBackOffice"].ToString() : string.Empty;
        //            Buzon_WebList.Add(buzon_Web);
        //        }
        //    }
        //    return Buzon_WebList;
        //}
        #endregion


    }
}