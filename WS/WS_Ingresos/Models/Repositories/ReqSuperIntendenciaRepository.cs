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
    public class ReqSuperIntendenciaRepository:IReqSuperIntendenciaRepository
    {
        public ICollection<ReqSuperIntendencia> GetEstadoByRut(string isapre, int rut)
        {
            try
            {
                using (var context = new Cot2000ProdEntities())
                {                                       
                    var reqsSuperEntity = context.SP_CONSULTA_CIRCULAR164(rut, isapre).ToList();

                    List<ReqSuperIntendencia> reqsSuper = new List<ReqSuperIntendencia>();
                    MapperEntityToDTO mapper = new MapperEntityToDTO();

                    foreach (var item in reqsSuperEntity)
                    {
                        reqsSuper.Add(mapper.ToDTO(item));
                    }

                    return reqsSuper;
                }
            }
            catch (Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }

        public ICollection<ReqSuperIntendencia> GetHistoricoByRut(string isapre, int rut)
        {
            try
            {
                using (var context = new IsaWebContEntities())
                {
                    var out_pTipoRut = new System.Data.Entity.Core.Objects.ObjectParameter("P_TIPORUT", typeof(string));
                    var out_pEstado = new System.Data.Entity.Core.Objects.ObjectParameter("P_ESTADO", typeof(string));

                    var reqsSuperEntity = context.SP_HISTORICO_PAGOS_PUBLICO(rut, isapre, out_pTipoRut, out_pEstado).ToList();

                    List<ReqSuperIntendencia> reqsSuper = new List<ReqSuperIntendencia>();
                    MapperEntityToDTO mapper = new MapperEntityToDTO();

                    foreach (var item in reqsSuperEntity)
                    {
                        reqsSuper.Add(mapper.ToDTO(item));
                    }

                    return reqsSuper;
                }
            }
            catch (Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }
    }
}