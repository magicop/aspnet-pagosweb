using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WS_Ingresos.Models.Dto;

namespace WS_Ingresos.Models.Contracts
{
    public interface IDetalleDeudasRepository
    {
        ICollection<DetalleDeudas> GetDetalleDeudas(int periodo);
    }
}