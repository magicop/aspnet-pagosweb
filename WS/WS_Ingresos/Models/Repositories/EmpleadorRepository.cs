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
    public class EmpleadorRepository:IEmpleadorRepository
    {
        public Empleador GetDatosEmpleador(int rutEmpleador, string isapre)
        {
            try
            {
                using (var context = new IsaWebProdEntities())
                {
                    var out_prsApePat = new System.Data.Entity.Core.Objects.ObjectParameter("sql_EMPL_TAPELLIDO_PATERNO", typeof(string));
                    var out_prsApeMat = new System.Data.Entity.Core.Objects.ObjectParameter("sql_EMPL_TAPELLIDO_MATERNO", typeof(string));
                    var out_prsRazonSoc = new System.Data.Entity.Core.Objects.ObjectParameter("sql_EMPL_TNOMBRE_RAZON_SOCIAL", typeof(string));
                    var out_prnRut = new System.Data.Entity.Core.Objects.ObjectParameter("sql_EMPL_NRUT", typeof(decimal));
                    var out_prsDv = new System.Data.Entity.Core.Objects.ObjectParameter("sql_EMPL_XDV", typeof(string));
                    var out_prsCalle = new System.Data.Entity.Core.Objects.ObjectParameter("sql_CEPA_TCALLE", typeof(string));
                    var out_prsNumero = new System.Data.Entity.Core.Objects.ObjectParameter("sql_CEPA_TNUMERO", typeof(string));
                    var out_prsDepto = new System.Data.Entity.Core.Objects.ObjectParameter("sql_CEPA_TDEPTO", typeof(string));
                    var out_prsBlock = new System.Data.Entity.Core.Objects.ObjectParameter("sql_CEPA_TBLOCK", typeof(string));
                    var out_prsVilla = new System.Data.Entity.Core.Objects.ObjectParameter("sql_CEPA_TVILLA", typeof(string));
                    var out_prsComuna = new System.Data.Entity.Core.Objects.ObjectParameter("sql_COMUNA", typeof(string));
                    var out_prsCiudad = new System.Data.Entity.Core.Objects.ObjectParameter("sql_CIUDAD", typeof(string));
                    var out_prnRegion = new System.Data.Entity.Core.Objects.ObjectParameter("sql_REGION", typeof(decimal));
                    var out_prsText = new System.Data.Entity.Core.Objects.ObjectParameter("sql_sText", typeof(string));

                    context.DATOS_DEL_EMPLEADOR(rutEmpleador, isapre, out_prsApePat, out_prsApeMat, out_prsRazonSoc, out_prnRut, out_prsDv,
                        out_prsCalle, out_prsNumero, out_prsDepto, out_prsBlock, out_prsVilla, out_prsComuna, out_prsCiudad, out_prnRegion, out_prsText);

                    MapperEntityToDTO mapper = new MapperEntityToDTO();
                    if(!out_prsText.Value.ToString().Equals("No hay datos del rut "))
                    {
                        Empleador empleador = new Empleador();
                        empleador.apellidoPaterno = out_prsApePat.Value.ToString();
                        empleador.apellidoMaterno = out_prsApeMat.Value.ToString();
                        empleador.nombreRazonSocial = out_prsRazonSoc.Value.ToString();
                        empleador.rut = int.Parse(out_prnRut.Value.ToString());
                        empleador.dv = out_prsDv.Value.ToString();
                        empleador.calle = out_prsCalle.Value.ToString();
                        empleador.numero = out_prsNumero.Value.ToString();
                        empleador.departamento = out_prsDepto.Value.ToString();
                        empleador.block = out_prsBlock.Value.ToString();
                        empleador.villa = out_prsVilla.Value.ToString();
                        empleador.comuna = out_prsComuna.Value.ToString();
                        empleador.ciudad = out_prsCiudad.Value.ToString();
                        empleador.region = int.Parse(out_prnRegion.Value.ToString());

                        return empleador;
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
    }
}