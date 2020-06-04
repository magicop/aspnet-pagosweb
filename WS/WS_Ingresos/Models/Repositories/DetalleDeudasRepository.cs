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
    public class DetalleDeudasRepository : IDetalleDeudasRepository
    {
        public ICollection<DetalleDeudas> GetDetalleDeudas(int periodo)
        {
            try
            {
                using (var context = new PagosWebEntities())
                {
                    var out_prsText = new System.Data.Entity.Core.Objects.ObjectParameter("except_text", typeof(string));

                    CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-ES");

                    var detalleDeudas = context.PKG_CONSULTAS_WEB_DETALLES_DEUDAS(periodo, out_prsText);

                    List<DetalleDeudas> listDeudas = new List<DetalleDeudas>();
                    MapperEntityToDTO mapper = new MapperEntityToDTO();

                    foreach (var item in detalleDeudas)
                    {
                        listDeudas.Add(mapper.ToDTO2(item));
                    }

                    return listDeudas;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
    }
}