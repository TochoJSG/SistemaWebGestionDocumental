using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

//using System.Web.UI;
//using System.Web.UI.WebControls;

namespace WebEpSIF.NEGOCIO
{
    public class NAdministraSolicitudes
    {

        DataTable dt = new DataTable();

        public DataTable NCargaDependenciaEncbezado(int pIdModulo, int pIdEjercicioContable, int pIdUsuario)
        {
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnCargaDependenciaEncabezado = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            dt = FnCargaDependenciaEncabezado.fnCargaDependenciaEncabezado("spDependenciaEncabezadoWeb",pIdModulo,pIdEjercicioContable,pIdUsuario);
            return dt;
        }


        public DataTable NCargaEventoGenericoEncabezado()
        {
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnCargaEventoGenericoEncabezado = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            dt = FnCargaEventoGenericoEncabezado.fnCargaEventoGenericoEncabezado("spEventoGenericoWeb");
            return dt;
        }

        public DataTable NCargaEventoEspecifico(int pIdUsuario, int pIdCandidatura)
        {
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnCargaEventoEspecifico = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            dt = FnCargaEventoEspecifico.fnCargaEventoEspecifico("spEstadoCandidatura",  pIdUsuario, pIdCandidatura);
            return dt;
        }

        
        public DataTable NCargaDistrito(int pIdCandidatura, int pIdEstado, int pIdusuario)
        {
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnCargaDistrito = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            dt = FnCargaDistrito.fnCargaDistrito("spDistritoCandidatura", pIdCandidatura, pIdEstado, pIdusuario);
            return dt;
        }

        public DataTable NCargaRegistrosMatriz(int pIdEncabezadoMatriz ,int pIncluyeBorrados)
        {
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnCargaArchivosMatriz = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            dt = FnCargaArchivosMatriz.fnCargaArchivosMatriz("spIdentificadoresArchivo", pIdEncabezadoMatriz, pIncluyeBorrados);
            return dt;
        }

        public string NCargaExtenciones(int pIdDocumento)
        {


            string strExtencion = "";
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnExtenciones = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            strExtencion = FnExtenciones.fnExtenciones("spExtensionesDocumento", pIdDocumento);
            return strExtencion;


        }

        public int NRegistroBloqueado(int pIdRegistroMatriz)
        {


            int strExtencion = 0;
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnExtenciones = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            strExtencion = FnExtenciones.fnRegistroBloqueado("spRegistroBloqueado", pIdRegistroMatriz);
            return strExtencion;


        }


        public int NRegistroEspptal(int pIdRegistroMatriz)
        {


            int strExtencion = 0;
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnExtenciones = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            strExtencion = FnExtenciones.fnRegistroEsPresupuestal("spEsPresupuestal", pIdRegistroMatriz);
            return strExtencion;


        }



        public int NRegistroCancelado(int pIdRegistroMatriz)
        {


            int strExtencion = 0;
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnExtenciones = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            strExtencion = FnExtenciones.fnRegistroCancelado("spEstatusEncabezado", pIdRegistroMatriz);
            return strExtencion;


        }








        public decimal NCapturadoAgrupador(int pIdEstado, int pIdDistrito, int pIdConcepto, int pIdEvento)
        {


            decimal DisponibleA = 0;
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnDisponible = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            DisponibleA = FnDisponible.fnCapturadoAgrupador("spCapturadoAgrupador", pIdEstado,  pIdDistrito, pIdConcepto, pIdEvento);
            return DisponibleA;


        }

        public decimal  NCalculaDisponible(int pIdEstado ,int pIdDistrito, int pIdConcepto, int pIdEvento)
        {


            decimal DisponibleA = 0;
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnDisponible = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            DisponibleA = FnDisponible.fnDisponibleAgrupador("spCalculaDisponible", pIdEstado,  pIdDistrito,  pIdConcepto,  pIdEvento);
            return DisponibleA;


        }

        




        public int NValidaExisteArchivoAgrupador(int pIdRegistroMatriz, string pNombreArchivo)
        {


            int intExiste = 0;
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnExisteArchivoCarga = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            intExiste = FnExisteArchivoCarga.fnExisteArchivoCargaAgrupador("spExisteArchivoAgrupador", pIdRegistroMatriz, pNombreArchivo);
            return intExiste;


        }









        public string NCargaEstatusRFCSAT(string pRFC)
        {


            string strExtencion = "";
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnExtenciones = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            strExtencion = FnExtenciones.fnEstatusValidaRFC("spValidaRFCSAT", pRFC);
            return strExtencion;


        }









        public string NFechaServidor()
        {


            string strExtencion = "";
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnExtenciones = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            strExtencion = FnExtenciones.fnFechaServidor ();
            return strExtencion;


        }





        public DataTable NCargaAgrupador(int pIdRegistroMatriz, int IdUsuarioGlobal)
        {
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnCargaAgrupador = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            dt = FnCargaAgrupador.fnCargaagrupador("spConsultaAgrupador", pIdRegistroMatriz, IdUsuarioGlobal);
            return dt;
        }




        public DataTable NCargaCandidato(int pIdCandidatura, int pIdEstado,int pIdDistrito, int IdUsuario)
        {
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnCargaCandidato = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            dt = FnCargaCandidato.fnCargaCandidato("spDistritoCandidato", pIdCandidatura, pIdEstado, pIdDistrito, IdUsuario);
            return dt;
        }

        public DataTable NCargaEvento(int pIdConcepto, int pTdCandidato)
        {
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnCargaEvento = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            dt = FnCargaEvento.fnCargaEvento("spConceptoEvento", pIdConcepto, pTdCandidato);
            return dt;
        }

        public DataTable NCargaDocumento(int pIdEvento, int pIdConcepto, int pIdCandidato)
        {
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnCargaEvento = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            dt = FnCargaEvento.fnCargaDocumento("spEventoDocumeno", pIdEvento, pIdConcepto, pIdCandidato);
            return dt;
        }
        public DataTable NCargaConcepto(int pIdCandidato)
        {
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnCargaConcepto = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            dt = FnCargaConcepto.fnCargaConcepto("spCandidatoConcepto", pIdCandidato);
            return dt;
        }




        public DataTable NCargaClavePresupuestal(int pIdEventoEspecifico, int pIdCveDef,   int pIdUsuario)
        {
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnCargaClavePresupuestal = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            dt = FnCargaClavePresupuestal.fnCargaClavePresupuestal("spCalculadisponibleClavesWeb", pIdEventoEspecifico, pIdCveDef, pIdUsuario);
            return dt;
        }




        //public DataTable NCargaDocumento(int pIdColectiva, int pIdCveDef, int pIdTipoDocumento)
        //{
        //    WebEpSIF.DAO.clsAdministraSolicitudesDAO FnCargaDocumento = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
        //    dt = FnCargaDocumento.fnCargaDocumento("spCargaDocumentosWeb", pIdColectiva, pIdCveDef, pIdTipoDocumento);
        //    return dt;
        //}



        public DataTable NCargaTipoDocumento()
        {
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnCargaTipoDocumento = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            dt = FnCargaTipoDocumento.fnCargaTipoDocumento("spCargaTipoGastoWeb");
            return dt;
        }

        public DataTable NCargaPeriodo()
        {
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnCargaPeriodo = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            dt = FnCargaPeriodo.fnCargaPeriodo("spPeriodos");
            return dt;
        }

        public DataTable NCargaComprometidoEvento(int pIdEjercicioContable, int pIdDependencia, int pIdevento)
        {
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnCargaComprometidoEvento = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            dt = FnCargaComprometidoEvento.fnCargaComprometidoEvento("spNumComprometidoWeb",  pIdEjercicioContable,pIdDependencia,pIdevento);
            return dt;
        }


        public DataTable NCargaColectivaEventoEspecifico(int pIdUsuario)
        {
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnCargaColectivaEventoEspecifico = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            dt = FnCargaColectivaEventoEspecifico.fnCargaColectivaEventoEspecifico("spCargaNivelWeb", pIdUsuario);
            return dt;
        }


        public DataTable NCargaBeneficiarioEncabezado(int pIdEvento, string pBeneficiario)
        {
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnCargaBeneficiarioEncabezado = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            dt = FnCargaBeneficiarioEncabezado.fnCargaBeneficiarioEncabezado("spBuscaColectivaWeb", pIdEvento, pBeneficiario);
            return dt;
        }


        public DataTable NCargaCLABE(int pIdColectiva)
        {
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnCargaCLABE = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            dt = FnCargaCLABE.fnCargaCLABE("spConsultaCLABEWEB", pIdColectiva);
            return dt;
        }

        public DataTable NCargaCandidatoMatriz(int pIdEstado)
        {
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnCargaCandidatoMatriz = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            dt = FnCargaCandidatoMatriz.fnCargaCandidatoMatriz("spCandidatoMatriz", pIdEstado);
            return dt;
        }

        public DataTable NCargaEstadoMatriz()
        {
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnCargaEstadoMatriz = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            dt = FnCargaEstadoMatriz.fnCargaEstadoMatriz("spEstadoCandidatoMatriz");
            return dt;
        }



        public DataTable NCargaConceptoSol(int pIdEvento)
        {
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnCargaConceptoSol = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            dt = FnCargaConceptoSol.fnCargaConceptoSol("spConceptoEventoWeb", pIdEvento);
            return dt;
        }


        public DataTable  NCargaTipoSolicitud()
        {
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnCargaTipoSolicitud = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            dt = FnCargaTipoSolicitud.fnCargaTipoSolicitud("spTipoSolicitudGet");
            return dt;
        }

        public DataTable NCargaEstatusSolicitud(int pTipo)
        {
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnCargaEstatusSolicitud = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            dt = FnCargaEstatusSolicitud.fnCargaEstatusSolicitud("SpEstatusSolicitudesGetList", pTipo);
            return dt;
        }
        

        public DataTable NCargaHistorialEstatusSolicitud(int pIdSolicitud)
        {
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnCargaHistorialEstatusSolicitud = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            dt = FnCargaHistorialEstatusSolicitud.fnCargaHistorialEstatusSolicitud("spConsultaEstatusSolicitud", pIdSolicitud);
            return dt;
        }


        public DataTable NCargaMatrizArchivos(int pIdCandidato)
        {
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnCargaMatriz = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            dt = FnCargaMatriz.fnCargaMatriz("spMatrizCargaAvance", pIdCandidato);
            return dt;
        }



        public DataTable NCargaListadoSolicitud(string pFechaInicial, string pFechaFinal, int pEjercicioContableId, int pModuloId, string pParametroTipoSolPago, string pParametroConcEstatusSp, int pNumeroInicial, int pNumeroFinal, int pRangoNumero,  int pFiltrarPorFechas,int IdUsuario)
        {
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnCargaListadoSolicitudes = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            dt = FnCargaListadoSolicitudes.fnCargaListadoSolicitudes("spSolicitudPagoGetList", pFechaInicial, pFechaFinal, pEjercicioContableId, pModuloId, pParametroTipoSolPago, pParametroConcEstatusSp, pNumeroInicial, pNumeroFinal, pRangoNumero, pFiltrarPorFechas,  IdUsuario);
            return dt;
        }


        public DataTable NCargaListadoDocumentos(int pIdEstado, int pIdNivel, int pIdTpogasto,string pFechaInicial, string pFechaFinal, int IdUsuario, int IdRegistroMatriz)
        {
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnCargaListadoDocumentos = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            dt = FnCargaListadoDocumentos.fnCargaListadoDocumentos("spConsultaArchivos", pIdEstado,  pIdNivel,  pIdTpogasto,pFechaInicial, pFechaFinal,  IdUsuario, IdRegistroMatriz);
            return dt;
        }


        public DataTable NCargaListadoCarpetas(int pIdPeriodo, int pIdEstado, int pIdNivel, int pIdDistrito, int pIdCandidato, int pIdConcepto, int pIdEvento, int pIdDocumento, string pFechaInicial, string pFechaFinal, int IdUsuario, int Estatus)
        {
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnCargaListadoCarpetas = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            dt = FnCargaListadoCarpetas.fnCargaListadoCarpetas("spConsultaCarpetasDescarga",  pIdPeriodo,  pIdEstado,  pIdNivel,  pIdDistrito,  pIdCandidato,  pIdConcepto,  pIdEvento,  pIdDocumento,  pFechaInicial,  pFechaFinal,  IdUsuario, Estatus);
            return dt;
        }




        public int NIdentificadorEjercicio(int pAnio)
        {
            int IdCveDef = 0;
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnEjercicioPresupuestal = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            IdCveDef = FnEjercicioPresupuestal.fnEjercicioPresupuestal("spEjercicioContableGetId", pAnio);
            return IdCveDef;
        }


        public int NInsertaEncabezadoMatriz(int pIdRegistroMatrizcaptura , int pIdUsuarioGlobal, int pIdPeriodo, int pIdNivel, int pIdEstado, int pIdDistrito, int pIdCandidato, int pIdConcepto, int pIdEvento, int pIdDocumento, string pAgrupador, decimal pImporte, DataTable CargaArchivo)
        {
            int pIdRegistroMatriz = 0;
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnEjercicioPresupuestal = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            pIdRegistroMatriz = FnEjercicioPresupuestal.fnInsertaEncabezadoMatriz("spInsertaEncabezadoMatriz", pIdRegistroMatrizcaptura,  pIdUsuarioGlobal, pIdPeriodo,  pIdNivel,  pIdEstado,  pIdDistrito,  pIdCandidato,  pIdConcepto,  pIdEvento,  pIdDocumento, pAgrupador, pImporte, CargaArchivo);
            return pIdRegistroMatriz;
        }







        public decimal NConsultaDisponibleClave(int pIdClave,int pMes)
        {
            decimal Disponible = 0;
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnConsultaDisponibleClave = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            Disponible = FnConsultaDisponibleClave.fnConsultaDisponibleClave("spImporteDisponibleClaveWeb", pIdClave, pMes);
            return Disponible;
        }

        public decimal NConsultaDisponibleDocumento(int pIdDocumento)
        {
            decimal Disponible = 0;
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnConsultaDisponibleDocumento = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            Disponible = FnConsultaDisponibleDocumento.fnConsultaDisponibleDocumento("spDisponibleDocumentoWeb", pIdDocumento);
            return Disponible;
        }



        public int NEventoEspecificoColectivaDetalle(int pIdEventoEspecifico)
        {
            int CapturaColectivaDetalle = 0;
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnCapturaColectivaDetalle = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            CapturaColectivaDetalle = FnCapturaColectivaDetalle.fnCapturaColectivaDetalle("spCapturaColectivaDetalleWeb", pIdEventoEspecifico);
            return CapturaColectivaDetalle;
        }




        public int NInsertaEncabezadoSolicitud( int pBeneficiarioId, int pEventoGenericoId, int pDependenciaId, int pGenComprometido, int pComprometidoId, int pFuenteFinanciamientoId, int pSolicitudAnteriorId, int pCuentaBancariaId, int pMesAPagar, string pDescripcion, string pBeneficiarioCheque, string pFecha, int pEjercicioContableId)

        {
            int IdSolicitud = 0;
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnInsertaEncabezadoSolicitud = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            IdSolicitud = FnInsertaEncabezadoSolicitud.fnInsertaEncabezadoSolicitud("spSolicitudPagoInsert", pBeneficiarioId, pEventoGenericoId, pDependenciaId, pGenComprometido, pComprometidoId, pFuenteFinanciamientoId, pSolicitudAnteriorId, pCuentaBancariaId, pMesAPagar, pDescripcion, pBeneficiarioCheque, pFecha, pEjercicioContableId);

            return IdSolicitud;
        }

        public int NInsertaDetalleSolicitud(string pDetalleSolicitud)

        {
            int IdSolicitud = 0;
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnInsertaDetalleSolicitud = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            IdSolicitud = FnInsertaDetalleSolicitud.fnInsertaDetalleSolicitud("spInsertaDetalleSolicitudWeb", pDetalleSolicitud);

            return IdSolicitud;
        }





        public DataTable NCargaConfiguracionEventoGenerico(int pEventoGenericoId)

        {
           
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnCargaConfiguracionEventoGenerico = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            dt = FnCargaConfiguracionEventoGenerico.fnCargaConfiguracionEventoGenerico("spConfiguracioneventoGenericoWeb",  pEventoGenericoId);

            return dt;
        }

        public DataTable NCargaConfiguracionEventoEspecifico(int pIdEventoEspecifico)

        {

            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnCargaConfiguracionEventoEspecifico = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            dt = FnCargaConfiguracionEventoEspecifico.fnCargaConfiguracionEventoEspecifico("spConfiguracionEventoEspecifico", pIdEventoEspecifico);

            return dt;
        }


        public DataTable NCargaReporteSolicitudPago(int pIdSolicitud)
        {
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnCargaReporteSolicitud = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            dt = FnCargaReporteSolicitud.fnCargaReporteSolicitud("sprptSolPagoWeb", pIdSolicitud);
            return dt;
        }



        public void NBorraArchivo(int pIdRegistroUnico, int pIdUsuarioEliminar)

        {
            
            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnBorraRegistro = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            FnBorraRegistro.fnBorraRegistroUnico("spBorraArchivo", pIdRegistroUnico, pIdUsuarioEliminar);

           
        }

        public void NActualizaImporteAgrupa(int pIdRegistroMatriz, decimal pImporte)

        {

            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnBorraRegistro = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            FnBorraRegistro.fnActualizaRegistroAgrupador("spAlmacenaMontoAgrupador", pIdRegistroMatriz, pImporte);


        }







        public void NCancelarPoliza(int pIdRegistroMatriz)

        {

            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnBorraRegistro = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            FnBorraRegistro.fnCancelarPoliza("spCancelarPoliza", pIdRegistroMatriz);


        }




        public void NSustituirArchivo(int pIdRegistroUnico, int Idusuarioglobal)

        {

            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnBorraRegistro = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            FnBorraRegistro.fnSustituirRegistroUnico("spSustituirArchivo", pIdRegistroUnico, Idusuarioglobal);


        }



        public void NActualizaPW(int pIdUsuario, string pPw)

        {

            WebEpSIF.DAO.clsAdministraSolicitudesDAO FnActualizaPw = new WebEpSIF.DAO.clsAdministraSolicitudesDAO();
            FnActualizaPw.fnActualizaPw("spActualizaPassword", pIdUsuario, pPw);


        }




    }
}