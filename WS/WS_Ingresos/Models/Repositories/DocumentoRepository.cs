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
    public class DocumentoRepository:IDocumentoRepository
    {
        public ICollection<Documento> GetDocumentosPendientesDeCobro(int rut, string isapre, string canal)
        {
            try
            {
                using (var context = new IsaWebContEntities())
                {
                    var documentosEntity = context.PKG_CIRC_EXCESO_DOCUMENTOS_PRC_DOCUMENTOS_PENDIENTES(rut, isapre, canal).ToList();

                    List<Documento> documentos = new List<Documento>();
                    MapperEntityToDTO mapper = new MapperEntityToDTO();

                    foreach (var item in documentosEntity)
                    {
                        documentos.Add(mapper.ToDTO(item));
                    }

                    return documentos;
                }
            }
            catch (Exception ex)
            {
                throw new IngresosException(ex.InnerException, ex.Message);
            }
        }
    }
}