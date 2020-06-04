using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using WS_Ingresos.Models.Contracts;
using WS_Ingresos.Models.Dto;
using WS_Ingresos.Models.Entities;

namespace WS_Ingresos.Models.Repositories
{
    public class ConsultaWebRepository : IConsultaWebRepository
    {
        public ICollection<Pago> GetPagos(int? idfolio, int? rut, int? monto, int? estado, DateTime? fechaDesde, DateTime? fechaHasta, string tipoPago, int? medioPago, int? isapre)
        {
            try
            {
                using (var context = new PagosWebEntities())
                {
                    var out_prsText = new System.Data.Entity.Core.Objects.ObjectParameter("except_text", typeof(string));

                    CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-ES");

                    var aux_tipopago = (tipoPago == null) ? string.Empty : tipoPago;
                    aux_tipopago = (tipoPago == "null") ? string.Empty : tipoPago;

                    var aux_fechad = (fechaDesde == null) ? string.Empty : ((DateTime)fechaDesde).ToShortDateString();
                    var aux_fechah = (fechaHasta == null) ? string.Empty : ((DateTime)fechaHasta).ToShortDateString();

                    var aux_fechad2 = Convert.ToDateTime(aux_fechad).ToString("dd/MM/yyyy");
                    var aux_fechah2 = Convert.ToDateTime(aux_fechah).ToString("dd/MM/yyyy");

                    var pagosEntity = context.PKG_CONSULTAS_WEB_BUSCAR_PAGO_TEST(idfolio, rut, monto, estado, aux_fechad2, aux_fechah2, aux_tipopago, medioPago, isapre, out_prsText);

                    List<Pago> listPagos = new List<Pago>();
                    MapperEntityToDTO mapper = new MapperEntityToDTO();

                    foreach (var item in pagosEntity)
                    {
                        listPagos.Add(mapper.ToDTO(item));
                    }

                    return listPagos;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<Pago> GetPagoRut(int rutpago)
        {
            try
            {
                using (var context = new PagosWebEntities())
                {
                    var out_prsText = new System.Data.Entity.Core.Objects.ObjectParameter("except_text", typeof(string));

                    CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-ES");

                    var pagosRutEntity = context.PKG_CONSULTAS_WEB_BUSCAR_PAGO_RUT(rutpago, out_prsText);

                    List<Pago> listPagos = new List<Pago>();
                    MapperEntityToDTO mapper = new MapperEntityToDTO();

                    foreach (var item in pagosRutEntity)
                    {
                        listPagos.Add(mapper.ToDTO(item));
                    }

                    return listPagos;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public bool RegularizarPago(int rut, int i_wtp_id)
        {
            try
            {
                using (var context = new PagosWebEntities())
                {
                    
                    var out_prsText = new System.Data.Entity.Core.Objects.ObjectParameter("except_text", typeof(string));

                    var pagosEntity = context.PKG_CONSULTAS_WEB_REGULARIZAR_PAGO_TEST(rut, i_wtp_id, out_prsText);


                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }


    }
}