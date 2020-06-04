using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS_Ingresos.Models.Dto;

namespace WS_Ingresos.Models.Contracts
{
    public interface IRecaudacionRepository
    {
        RespuestaPlanilla GeneraPlanilla(long folioPago, InfoPlanilla infoPlanilla);
        long SecuenciaPagoDeuda();
        long SecuenciaPagoCotiza();
        string PagoPlanilla(InfoPagoPlanilla infoPago);
        string InsertRegRecaEnc(long folioPago, int rutAfiliado, string isapre, string email, long gastoCobTotal, long pagoTotal,
            string tipo);
        string InsertRegRecaDet(long folioPago, int rutAfiliado, string isapre, string tipo, long deuda, long gastoCob, long honorario,
            long interes, long pago, long reajuste, long recargo, int periodoRecau, int periodoRemun, int subProducto);
        string UpdateRegReca(long folioPago, int rutAfiliado, string isapre, string tipo, string formaPago);
        PagoRecaudacion ObtienePagoRecaudacion(long folioPago, int rutAfiliado, string isapre, string tipo);
        ICollection<InfoFolioNegociacion> ObtieneFoliosNegociacion(int rutAfiliado, string isapre);
        string InsertaInfoPagoModulo(InfoPagoModulo infoPagoModulo, int rut, string isapre, string canal, int tipoPago, long folio, string formaPago);
        bool ActualizaAgencia(int agencia, long folioPago);
    }
}
