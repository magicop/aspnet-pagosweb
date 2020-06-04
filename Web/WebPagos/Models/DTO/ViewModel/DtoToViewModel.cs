using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebPagos.Models.DTO;
using WebPagos.Models.DTO.ViewModel;

namespace WebPagos.Models.Dto.ViewModel
{
    public class DtoToViewModel
    {
        #region DTOPago
        public List<Pago> ToDTO_Pago(List<Pago> itemList)
        {
            List<Pago> pagoList = new List<Pago>();

            foreach (Pago item in itemList)
            {

                Pago pa = new Pago();

                pa.idFolio = Convert.ToInt64(item.idFolio);
                pa.rutPago = Convert.ToInt32(item.rutPago);
                pa.montoPago = Convert.ToInt32(item.montoPago);
                pa.estadoPago = item.estadoPago;
                pa.fechaPago = Convert.ToDateTime(item.fechaPago);
                pa.tipoPago = item.tipoPago;
                pa.medioPago = Convert.ToInt32(item.medioPago);
                pa.isapre = item.isapre;

                pagoList.Add(pa);
            }

            return pagoList;
        }

        public EditarPagoViewModel ToDTO_Pago(Pago item)
        {
            var pa = new EditarPagoViewModel();

            pa.idFolio = Convert.ToInt32(item.idFolio);
            pa.rutPago = Convert.ToInt32(item.rutPago);
            pa.montoPago = Convert.ToInt32(item.montoPago);
            pa.estadoPago = item.estadoPago;
            pa.fechaPago = Convert.ToDateTime(item.fechaPago);
            pa.tipoPago = item.tipoPago;
            pa.medioPago = Convert.ToInt32(item.medioPago);
            pa.isapre = item.isapre;

            return pa;
        }
        #endregion

        #region DTODeuda
        public List<Deuda> ToDTO_Deuda(List<Deuda> itemList)
        {
            List<Deuda> deudaList = new List<Deuda>();

            foreach (Deuda item in deudaList)
            {

                Deuda de = new Deuda();

                de.folioPago = Convert.ToInt32(item.folioPago);
                de.premun = Convert.ToInt32(item.premun);
                de.csubproducto = Convert.ToInt32(item.csubproducto);
                de.mdeuda = Convert.ToInt32(item.mdeuda);
                de.mreajuste = Convert.ToInt32(item.mreajuste);
                de.minteres = Convert.ToInt32(item.minteres);
                de.mrecargo = Convert.ToInt32(item.mrecargo);
                de.mhonorario = Convert.ToInt32(item.mhonorario);
                de.mpagototal = Convert.ToInt32(item.mpagototal);

                deudaList.Add(de);
            }

            return deudaList;
        }

        public EditarDeudaViewModel ToDTO_Deuda(Deuda item)
        {
            var de = new EditarDeudaViewModel();

            de.folioPago = Convert.ToInt32(item.folioPago);
            de.premun = Convert.ToInt32(item.premun);
            de.csubproducto = Convert.ToInt32(item.csubproducto);
            de.mdeuda = Convert.ToInt32(item.mdeuda);
            de.mreajuste = Convert.ToInt32(item.mreajuste);
            de.minteres = Convert.ToInt32(item.minteres);
            de.mrecargo = Convert.ToInt32(item.mrecargo);
            de.mhonorario = Convert.ToInt32(item.mhonorario);
            de.mpagototal = Convert.ToInt32(item.mpagototal);

            return de;
        }
        #endregion

        #region DTOLista

        #region Comentarios
        //public List<LlenarPeriodos> ToDTO_Periodos(List<LlenarPeriodos> itemList)
        //{
        //    List<LlenarPeriodos> periodoList = new List<LlenarPeriodos>();

        //    foreach (LlenarPeriodos item in periodoList)
        //    {

        //        LlenarPeriodos pe = new LlenarPeriodos();

        //        pe.codigo = Convert.ToInt32(item.codigo);
        //        pe.descripcion = item.descripcion;
        //        pe.lstPeriodos = null;


        //        periodoList.Add(pe);
        //    }

        //    return periodoList;
        //}
        #endregion

        public List<LlenarTipopago> ToDTO(List<LlenarTipopago> itemList)
        {
            List<LlenarTipopago> tpList = new List<LlenarTipopago>();

            foreach (LlenarTipopago item in tpList)
            {

                LlenarTipopago tp = new LlenarTipopago();

                tp.codigo = item.codigo;
                tp.descripcion = item.descripcion;


                tpList.Add(tp);
            }

            return tpList;
        }

        
        #endregion


        #region Comentarios
        //public List<IndexDocAdjViewModel> ToDTO_Iavm(List<Buzon_Web> itemList)
        //{
        //    List<IndexDocAdjViewModel> edvmList = new List<IndexDocAdjViewModel>();

        //    foreach (Buzon_Web item in itemList)
        //    {
        //        IndexDocAdjViewModel edvm = new IndexDocAdjViewModel();

        //        edvm.RutAfil = item.RutAfil;
        //        edvm.AreaBackOffice = item.AreaBackOffice;
        //        edvm.CanalEnvio = item.CanalEnvio;
        //        edvm.RutCarg = item.RutCarg;
        //        edvm.Descripcion = item.Descripcion;
        //        edvm.Estado = item.Estado;
        //        edvm.FechaHora = item.FechaHora;
        //        edvm.IdDocumento = item.IdDocumento;
        //        edvm.IdSolicitud = item.IdSolicitud;
        //        edvm.Isapre = item.Isapre;
        //        edvm.MailDestinatario = item.MailDestinatario;
        //        edvm.Motivo = item.Motivo;
        //        edvm.NombreArchivo = item.NombreArchivo;
        //        edvm.Observacion = item.Observacion;
        //        edvm.IdArchivo = item.IdArchivo;

        //        edvmList.Add(edvm);
        //    }

        //    return edvmList;
        //}
        #endregion

    }
}