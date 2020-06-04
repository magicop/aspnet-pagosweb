using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS_Ingresos.Models.Dto;

namespace WS_Ingresos.Models.Contracts
{
    public interface IReqSuperIntendenciaRepository
    {
        ICollection<ReqSuperIntendencia> GetEstadoByRut(string isapre, int rut);
        ICollection<ReqSuperIntendencia> GetHistoricoByRut(string isapre, int rut);
    }
}
