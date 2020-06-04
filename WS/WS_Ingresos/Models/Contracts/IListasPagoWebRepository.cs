﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WS_Ingresos.Models.Dto;

namespace WS_Ingresos.Models.Contracts
{
    public interface IListasPagoWebRepository
    {
        ICollection<LlenarPeriodos> GetPeriodos();

        ICollection<LlenarTipopago> GetTipopago();

        ICollection<LlenarMediopago> GetMediopago();

        ICollection<LlenarEstadopago> GetEstadopago();

        ICollection<LlenarIsapre> GetIsapre();
    }
}