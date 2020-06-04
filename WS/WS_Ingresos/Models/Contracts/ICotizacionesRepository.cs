using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS_Ingresos.Models.Dto;

namespace WS_Ingresos.Models.Contracts
{
    public interface ICotizacionesRepository
    {
        ICollection<Cuponera> GetCuponera(int rut, string isapre);
        ICollection<Cotizaciones> GetCotizacionesNew(int rut, string isapre);
        ICollection<Periodo> GetPeriodoPagado(int rut, string isapre);
        Excedentes GetSaldoExcedentes(int rut, string isapre, string tipo);
        ICollection<Excedente> GetDetalleExcedentes(int rut, string isapre);
        bool PostDatosCotizaNew(int rut, int periodo, int periodoAnt, int valorPesos, DateTime fechaRef, DateTime fechaCreacion, string estado, string empresa, int reajuste, int interes, int recargo, int total, int folio, string idPago);
        ICollection<CotizacionesSubsidio> GetCotizaciones(int rut, string empresa, int fechaInicio, int fechaFin);
        ICollection<CotizacionesSubsidio2> GetSubsidio(int rut, string empresa, int fechaInicio, int fechaFin);
        ICollection<AfiliadoCertificado> GetAfiliadosCotizaciones(int rutEmpleador, string isapre);
        ICollection<AfiliadoCertificado> GetAfiliadoCotizaciones(int rutEmpleador, int rutAfil, string isapre);
        ICollection<CertificadoCotiza> GetCertificadoCotiza(int rutEmpleador, int rutAfil, string isapre);
        long GetFolioPagoCotizaciones();
        ICollection<DetalleCotizaciones> GetDetalleCotizaciones(int rut, string isapre, string nomApeAfiliado);
    }
}
