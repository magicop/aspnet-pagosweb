using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS_Ingresos.Models.Dto;

namespace WS_Ingresos.Models.Contracts
{
    public interface IAfiliadoRepository
    {
        DatosAfiliado GetDatosAfiliado(int rut, string isapre);
        DatosEmpleador GetDatosEmpleador(int rut, string isapre);
    }
}
