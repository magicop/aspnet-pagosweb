using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Ingresos.Models.Dto
{
    public class InfoPago
    {
        public int idfolio = 0;
        public int rut = 0;
        public int monto = 0;
        public int estado = 0;
        public DateTime fechaDesde = Convert.ToDateTime("01/01/01");
        public DateTime fechaHasta = Convert.ToDateTime("01/01/01");
        public string tipoPago = "";
        public int medioPago = 0;

        public int Idfolio
        {
            get
            {
                return idfolio;
            }

            set
            {
                idfolio = value;
            }
        }

        public int Rut
        {
            get
            {
                return rut;
            }

            set
            {
                rut = value;
            }
        }

        public int Monto
        {
            get
            {
                return monto;
            }

            set
            {
                monto = value;
            }
        }

        public int Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }

        public DateTime FechaDesde
        {
            get
            {
                return fechaDesde;
            }

            set
            {
                fechaDesde = value;
            }
        }

        public DateTime FechaHasta
        {
            get
            {
                return fechaHasta;
            }

            set
            {
                fechaHasta = value;
            }
        }

        public string TipoPago
        {
            get
            {
                return tipoPago;
            }

            set
            {
                tipoPago = value;
            }
        }

        public int MedioPago
        {
            get
            {
                return medioPago;
            }

            set
            {
                medioPago = value;
            }
        }
    }
}