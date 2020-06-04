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
    public class DeudasRepository : IDeudasRepository
    {
        public ICollection<DetalleDeuda> GetDetalleDeuda(int rut, string isapre)
        {
            try
            {
                using (var context = new IsaWebProdEntities())
                {
                    var out_prsText = new System.Data.Entity.Core.Objects.ObjectParameter("pr_sText", typeof(string));

                    var deudasEntity = context.PKG_COTIZACIONES_SP_OBTIENE_DEUDA(rut, isapre, out_prsText).ToList();
                    
                    List<DetalleDeuda> detallesDeuda = new List<DetalleDeuda>();
                    MapperEntityToDTO mapper = new MapperEntityToDTO();
                    foreach (var item in deudasEntity)
                    {
                        detallesDeuda.Add(mapper.ToDTO(item));
                    }

                    return detallesDeuda;
                }
            }
            catch (Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }

        public long GetSecuenciaPagoDeuda()
        {
            try
            {
                using (var context = new IsaWebProdEntities())
                {
                    var deudaEntity = context.PKG_COTIZACIONES_SECUENCIA_PAGODEUDA().ToList();

                    long secuencia = 0;

                    foreach (var item in deudaEntity)
                    {
                        secuencia = Convert.ToInt64(item.SEQ_PAGODEUDA);
                    }

                    return secuencia;
                }
            }
            catch (Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }

        public bool PostInsertPagoDeuda(int rut, int periodo, int monto, long folio, long subProducto, int deuda, int reajuste, int interes, int recargo, int gasto, int horario)
        {
            try
            {
                using (var context = new IsaWebProdEntities())
                {
                    context.PKG_COTIZACIONES_INSERT_PAGO_DEUDA(rut, periodo, monto, folio, subProducto, deuda, reajuste, interes, recargo, gasto, horario);

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