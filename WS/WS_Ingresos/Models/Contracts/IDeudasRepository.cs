using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS_Ingresos.Models.Dto;

namespace WS_Ingresos.Models.Contracts
{
    public interface IDeudasRepository
    {
        ICollection<DetalleDeuda> GetDetalleDeuda(int rut, string isapre);
        long GetSecuenciaPagoDeuda();
        bool PostInsertPagoDeuda(int rut, int periodo, int monto, long folio, long subProducto, int deuda, int reajuste, int interes, int recargo, int gasto, int horario);
    }
}
