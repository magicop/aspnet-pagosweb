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
    public class ListasPagoWebRepository : IListasPagoWebRepository
    {
        #region GetPeriodos
        public ICollection<LlenarPeriodos> GetPeriodos()
        {
            try
            {
                using (var context = new PagosWebEntities())
                {
                    var out_prsText = new System.Data.Entity.Core.Objects.ObjectParameter("except_text", typeof(string));

                    CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-ES");

                    var periodos = context.PKG_CONSULTAS_WEB_LLENARLISTAS("periodo",out_prsText);

                    List<LlenarPeriodos> listPeriodos = new List<LlenarPeriodos>();
                    MapperEntityToDTO mapper = new MapperEntityToDTO();

                    foreach (var item in periodos)
                    {
                        listPeriodos.Add(mapper.ToDTO(item));
                    }

                    return listPeriodos;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region GetTipopago
        public ICollection<LlenarTipopago> GetTipopago()
        {
            try
            {
                using (var context = new PagosWebEntities())
                {
                    var out_prsText = new System.Data.Entity.Core.Objects.ObjectParameter("except_text", typeof(string));

                    CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-ES");

                    var pagos = context.PKG_CONSULTAS_WEB_LLENARLISTAS("tipopago", out_prsText);

                    List<LlenarTipopago> listPagos = new List<LlenarTipopago>();
                    MapperEntityToDTO mapper = new MapperEntityToDTO();

                    foreach (var item in pagos)
                    {
                        listPagos.Add(mapper.ToDTO2(item));
                    }

                    return listPagos;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region GetMediopago
        public ICollection<LlenarMediopago> GetMediopago()
        {
            try
            {
                using (var context = new PagosWebEntities())
                {
                    var out_prsText = new System.Data.Entity.Core.Objects.ObjectParameter("except_text", typeof(string));

                    CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-ES");

                    var periodos = context.PKG_CONSULTAS_WEB_LLENARLISTAS("mediopago", out_prsText);

                    List<LlenarMediopago> listPeriodos = new List<LlenarMediopago>();
                    MapperEntityToDTO mapper = new MapperEntityToDTO();

                    foreach (var item in periodos)
                    {
                        listPeriodos.Add(mapper.ToDTO3(item));
                    }

                    return listPeriodos;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
        #endregion

        #region GetEstadopago
        public ICollection<LlenarEstadopago> GetEstadopago()
        {
            try
            {
                using (var context = new PagosWebEntities())
                {
                    var out_prsText = new System.Data.Entity.Core.Objects.ObjectParameter("except_text", typeof(string));

                    CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-ES");

                    var periodos = context.PKG_CONSULTAS_WEB_LLENARLISTAS("estadopago", out_prsText);

                    List<LlenarEstadopago> listPeriodos = new List<LlenarEstadopago>();
                    MapperEntityToDTO mapper = new MapperEntityToDTO();

                    foreach (var item in periodos)
                    {
                        listPeriodos.Add(mapper.ToDTO4(item));
                    }

                    return listPeriodos;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
        #endregion

        #region GetIsapre
        public ICollection<LlenarIsapre> GetIsapre()
        {
            try
            {
                using (var context = new PagosWebEntities())
                {
                    var out_prsText = new System.Data.Entity.Core.Objects.ObjectParameter("except_text", typeof(string));

                    CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-ES");

                    var periodos = context.PKG_CONSULTAS_WEB_LLENARLISTAS("isapre", out_prsText);

                    List<LlenarIsapre> listPeriodos = new List<LlenarIsapre>();
                    MapperEntityToDTO mapper = new MapperEntityToDTO();

                    foreach (var item in periodos)
                    {
                        listPeriodos.Add(mapper.ToDTO5(item));
                    }

                    return listPeriodos;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
        #endregion
    }
}