using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WS_Ingresos.Models.Dto;

namespace WS_Ingresos.Models.Contracts
{
    public interface IConsultaWebRepository
    {
        ICollection<Pago> GetPagos(int? idfolio, int? rut, int? monto, int? estado, DateTime? fechaDesde, DateTime? fechaHasta, string tipoPago, int? medioPago, int? isapre);

        ICollection<Pago> GetPagoRut(int rutpago);

        bool RegularizarPago(int rut, int i_wtp_id);

    }
}