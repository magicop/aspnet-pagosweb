using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS_Ingresos.Models.Dto;

namespace WS_Ingresos.Models.Contracts
{
    public interface IDevolucionExcesosRepository
    {
        ICollection<DevolucionExcesos> GetSaldoExcesosDia(int rut, string isapre, string canal);
        DetalleExcesosRegistroIndividual GetDetalleExcesosRegistroIndividual(int rut, string isapre, string canal);
        string PostSolicitudDevolucionExcesos(SolicitudDevolucionExcesos solicitud);
        string PostSolicitudReemision(List<SolicitudReemision> solicitudes);
        Cuenta GetCuenta(int rut, string isapre);
        string GetDeuda(int rut, string isapre);
    }
}
