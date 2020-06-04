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
    public class CargasRepository : ICargasRepository
    {
        public ICollection<Cargas> GetCargasActualizarAfilRut(int rutAfil, string isapre)
        {
            try
            {
                using (var context = new IsaWebProdEntities())
                {
                    var out_prsText = new System.Data.Entity.Core.Objects.ObjectParameter("pr_sText", typeof(string));

                    var cargasEntity = context.PKG_MIS_ANTECEDENTES_TRAERCARGAS(rutAfil, isapre, out_prsText).ToList();

                    List<Cargas> cargas = new List<Cargas>();
                    MapperEntityToDTO mapper = new MapperEntityToDTO();

                    foreach (var item in cargasEntity)
                    {
                        cargas.Add(mapper.ToDTO(item));
                    }

                    return cargas;
                }
            }
            catch (Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }

        public ICollection<Cargas> GetCargasLogActualizarAfilRut(int rutAfil, string isapre, int correlativo)
        {
            try
            {
                using (var context = new IsaWebProdEntities())
                {
                    var out_prsText = new System.Data.Entity.Core.Objects.ObjectParameter("pr_sText", typeof(string));

                    var cargasEntity = context.PKG_MIS_ANTECEDENTES_TRAERCARGASLOG(rutAfil, isapre, correlativo, out_prsText).ToList();

                    List<Cargas> cargas = new List<Cargas>();
                    MapperEntityToDTO mapper = new MapperEntityToDTO();

                    foreach (var item in cargasEntity)
                    {
                        cargas.Add(mapper.ToDTO(item));
                    }

                    return cargas;
                }
            }
            catch (Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }
    }
}