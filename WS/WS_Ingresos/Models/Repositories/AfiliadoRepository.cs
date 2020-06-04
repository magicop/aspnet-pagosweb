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
    public class AfiliadoRepository:IAfiliadoRepository
    {
        public DatosAfiliado GetDatosAfiliado(int rut, string isapre)
        {
            try
            {
                using (var context = new IsaWebProdEntities())
                {
                    var out_prsText = new System.Data.Entity.Core.Objects.ObjectParameter("pr_sText", typeof(string));

                    var datosAfilEntity = context.PKG_MIS_ANTECEDENTES_DATOS_DEL_AFILIADO(rut, isapre, out_prsText).FirstOrDefault();

                    MapperEntityToDTO mapper = new MapperEntityToDTO();
                    DatosAfiliado datosAfiliado = new DatosAfiliado();
                    if (datosAfilEntity != null)
                    {
                        datosAfiliado = mapper.ToDTO(datosAfilEntity);
                        return datosAfiliado;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }

        public DatosEmpleador GetDatosEmpleador(int rut, string isapre)
        {
            try
            {
                using(var context = new IsaWebProdEntities())
                {
                    var out_prsText = new System.Data.Entity.Core.Objects.ObjectParameter("pr_sText", typeof(string));

                    var datosEmpleadorEntity = context.PKG_ANTECEDENTES_DEL_EMPLEADOR_TRAEREMPLEADOR(rut, isapre, out_prsText).FirstOrDefault();

                    MapperEntityToDTO mapper = new MapperEntityToDTO();
                    DatosEmpleador datosEmpleador = new DatosEmpleador();
                    if (datosEmpleadorEntity != null)
                    {
                        datosEmpleador = mapper.ToDTO(datosEmpleadorEntity);
                        return datosEmpleador;
                    }
                    else
                        return null;
                }
            }
            catch(Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }
    }
}