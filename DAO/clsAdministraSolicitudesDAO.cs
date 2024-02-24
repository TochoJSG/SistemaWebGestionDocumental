using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using ENTIDADES;
namespace WebEpSIF.DAO
{
    public class clsAdministraSolicitudesDAO
    {


        string CadenaConexion = @"Data Source=38.17.53.107,18176;Initial Catalog=ELECCIONES2021;User Id=LAU;Password=Gar#$2021";

        // < add name = "conSiif" connectionString = "Data Source=10.1.103.5\SQLSERVER2012;Initial Catalog=DBSIIF_AGS_PRUEBAS;Persist Security Info=True;User ID=USUARIOCONSULTAVHE;Password=siif#2018;Min Pool Size=500;Max Pool Size=600;Pooling=true;" />


        //string CadenaConexion = @"Data Source=FINANZASSIIF;Initial Catalog=DBSIIFPRUEBAS;Persist Security Info=True;User ID=USUARIO200wEmFKEHOz$UEM;Password=a";

        //SqlConnection sqlCnn = new SqlConnection(CadenaConexion);
        public DataTable fnCargaTipoSolicitud( string strSQL )
        {
            clsConexion sqlCon = new clsConexion();
            try
            {
                SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion());
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                sqlCon.getConexion().Close(); 
                return dt;
                

             }
            catch (Exception)
            {
                return null;
            }
        }



        public DataTable fnCargaEventoGenericoEncabezado(string strSQL)
        {
            clsConexion sqlCon = new clsConexion();
            try
            {
                SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion());
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;


            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable fnCargaTipoDocumento(string strSQL)
        {
            clsConexion sqlCon = new clsConexion();
            try
            {
                SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion());
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;


            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable fnCargaPeriodo(string strSQL)
        {
            using (SqlConnection sqlCnn = new SqlConnection(CadenaConexion))
            {

                try
                {
                    SqlCommand Cmd = new SqlCommand(strSQL, sqlCnn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    sqlCnn.Close();
                    return dt;


                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        //public DataTable fnCargaDocumento(string strSQL, int pIdColectiva,  int pIdCveDef, int pIdTipoDocumento)
        //{
        //    clsConexion sqlCon = new clsConexion();
        //    try
        //    {
        //        SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion());
        //        Cmd.CommandType = CommandType.StoredProcedure;
        //        SqlDataAdapter da = new SqlDataAdapter(Cmd);
        //        Cmd.Parameters.AddWithValue("@pIdColectiva", pIdColectiva);
        //        Cmd.Parameters.AddWithValue("@pIdCveDef", pIdCveDef);
        //        Cmd.Parameters.AddWithValue("@pIdTipoDocumento", pIdTipoDocumento);
               
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);
        //        return dt;


        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}




        public DataTable fnCargaEventoEspecifico(string strSQL,int pIdUsuario, int pIdCandidatura)
        {
            using (SqlConnection sqlCnn = new SqlConnection(CadenaConexion))
            {

                try
                {
                    SqlCommand Cmd = new SqlCommand(strSQL, sqlCnn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);

                    Cmd.Parameters.AddWithValue("@pIdUsuario", pIdUsuario);
                    Cmd.Parameters.AddWithValue("@pIdCandidatura", pIdCandidatura);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    sqlCnn.Close();
                    return dt;


                }
                catch (Exception)
                {
                    return null;
                }
            }
        }


        public DataTable fnCargaDistrito(string strSQL,  int pIdCandidatura, int pIdEstado,int pIdUsuario)
        {
            using (SqlConnection sqlCnn = new SqlConnection(CadenaConexion))
            {

                try
                {
                    SqlCommand Cmd = new SqlCommand(strSQL, sqlCnn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);

                    Cmd.Parameters.AddWithValue("@pIdCandidatura", pIdCandidatura);
                    Cmd.Parameters.AddWithValue("@pIdEstado", pIdEstado);
                    Cmd.Parameters.AddWithValue("@pIdUsuario", pIdUsuario);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    sqlCnn.Close();
                    return dt;


                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public DataTable fnCargaArchivosMatriz(string strSQL, int pIdRegistroMatriz, int pIncluyeBorrados)
        {
            using (SqlConnection sqlCnn = new SqlConnection(CadenaConexion))
            {

                try
                {
                    SqlCommand Cmd = new SqlCommand(strSQL, sqlCnn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);

                    Cmd.Parameters.AddWithValue("@pIdRegistroMatriz", pIdRegistroMatriz);
                    Cmd.Parameters.AddWithValue("@pIncluyeBorrados", pIncluyeBorrados);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    sqlCnn.Close();
                    return dt;


                }
                catch (Exception)
                {
                    return null;
                }
            }
        }



        public DataTable fnCargaCandidato(string strSQL, int pIdCandidatura, int pIdEstado, int pIdDistrito, int IdUsuario)
        {
            using (SqlConnection sqlCnn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    SqlCommand Cmd = new SqlCommand(strSQL, sqlCnn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);

                    Cmd.Parameters.AddWithValue("@pIdCandidatura", pIdCandidatura);
                    Cmd.Parameters.AddWithValue("@pIdEstado", pIdEstado);
                    Cmd.Parameters.AddWithValue("@pIdDistrito", pIdDistrito);
                    Cmd.Parameters.AddWithValue("@pIdUsuario", IdUsuario);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    sqlCnn.Close();
                    return dt;


                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public DataTable fnCargaEvento(string strSQL, int pIdConcepto, int pIdCandidato)
        {
            using (SqlConnection sqlCnn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    SqlCommand Cmd = new SqlCommand(strSQL, sqlCnn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);

                    Cmd.Parameters.AddWithValue("@pIdConcepto", pIdConcepto);
                    Cmd.Parameters.AddWithValue("@pIdCandidato", pIdCandidato);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    sqlCnn.Close();
                    return dt;


                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public DataTable fnCargaDocumento(string strSQL, int pIdEvento, int pIdConcepto, int pidCandidato)
        {
            using (SqlConnection sqlCnn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    SqlCommand Cmd = new SqlCommand(strSQL, sqlCnn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);

                    Cmd.Parameters.AddWithValue("@pIdEvento", pIdEvento);
                    Cmd.Parameters.AddWithValue("@pIdConcepto", pIdConcepto);
                    Cmd.Parameters.AddWithValue("@pidCandidato", pidCandidato);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    sqlCnn.Close();

                    return dt;


                }
                catch (Exception)
                {
                    return null;
                }
            }
        }




        public DataTable fnCargaConcepto(string strSQL, int pIdCandidato)
        {
            using (SqlConnection sqlCnn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    SqlCommand Cmd = new SqlCommand(strSQL, sqlCnn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);

                    Cmd.Parameters.AddWithValue("@pIdCandidato", pIdCandidato);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    sqlCnn.Close();
                    return dt;


                }
                catch (Exception)
                {
                    return null;
                }
            }
        }


        public DataTable fnCargaClavePresupuestal(string strSQL, int pIdEventoEspecifico, int pIdCveDef, int pIdUsuario)
        {
            using (SqlConnection sqlCnn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    SqlCommand Cmd = new SqlCommand(strSQL, sqlCnn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    Cmd.Parameters.AddWithValue("@pIdEventoEspecifico", pIdEventoEspecifico);
                    Cmd.Parameters.AddWithValue("@pIdCveDef", pIdCveDef);
                    Cmd.Parameters.AddWithValue("@pIdUsuario", pIdUsuario);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;


                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public DataTable fnCargaDependenciaEncabezado(string strSQL,int pIdModulo,int pIdEjercicioContable, int pIdUsuario )
        {
            clsConexion sqlCon = new clsConexion();
            try
            {
                SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion());
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                Cmd.Parameters.AddWithValue("@ModuloId", pIdModulo);
                Cmd.Parameters.AddWithValue("@EjercicioContableId", pIdEjercicioContable);
                Cmd.Parameters.AddWithValue("@pIdUsuario", pIdUsuario);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;

            }
            catch (Exception)
            {
                return null;
            }
        }



        public DataTable fnCargaComprometidoEvento(string strSQL, int pIdEjercicioContable, int pIdDependencia, int pIdEvento)
        {
            clsConexion sqlCon = new clsConexion();
            try
            {
                SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion());
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                Cmd.Parameters.AddWithValue("@pIdCveDef", pIdEjercicioContable);
                Cmd.Parameters.AddWithValue("@pIdDependencia", pIdDependencia);
                Cmd.Parameters.AddWithValue("@pIdEvento", pIdEvento);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable fnCargaColectivaEventoEspecifico(string strSQL, int pIdUsuario)
        {
            clsConexion sqlCon = new clsConexion();
            try
            {
                SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion());
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                Cmd.Parameters.AddWithValue("@pIdUsuario", pIdUsuario);
                
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;

            }
            catch (Exception)
            {
                return null;
            }
        }


        public DataTable fnCargaReporteSolicitud(string strSQL, int pIdSolicitud)
        {
            clsConexion sqlCon = new clsConexion();
            try
            {
                SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion());
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                Cmd.Parameters.AddWithValue("@li_SolPago", pIdSolicitud);

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;

            }
            catch (Exception)
            {
                return null;
            }
        }


        public DataTable fnCargaBeneficiarioEncabezado(string strSQL,  int pIdEvento, string pBeneficiario)
        {
            clsConexion sqlCon = new clsConexion();
            try
            {
                SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion());
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                Cmd.Parameters.AddWithValue("@pIdEvento", pIdEvento);
                Cmd.Parameters.AddWithValue("@pNombre", pBeneficiario);
               
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;

            }
            catch (Exception)
            {
                return null;
            }
        }



        public DataTable fnCargaCLABE(string strSQL, int pIdColectiva)
        {
            clsConexion sqlCon = new clsConexion();
            try
            {
                SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion());
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                Cmd.Parameters.AddWithValue("@pIdColectiva", pIdColectiva);

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;

            }
            catch (Exception)
            {
                return null;
            }
        }


        public DataTable fnCargaCandidatoMatriz(string strSQL, int pIdEstado)
        {
            using (SqlConnection sqlCnn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    SqlCommand Cmd = new SqlCommand(strSQL, sqlCnn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    Cmd.Parameters.AddWithValue("@IdEstado", pIdEstado);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    sqlCnn.Close();
                    
                    return dt;

                }
                catch (Exception)
                {
                    return null;
                }
            }
        
        }







        public DataTable fnCargaEstadoMatriz(string strSQL)
        {
            using (SqlConnection sqlCnn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    SqlCommand Cmd = new SqlCommand(strSQL, sqlCnn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    sqlCnn.Close();

                    
                    return dt;

                }
                catch (Exception)
                {
                    return null;
                }
            }
        }


        public DataTable fnCargaConceptoSol(string strSQL, int pIdEvento)
        {
            clsConexion sqlCon = new clsConexion();
            try
            {
                SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion());
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                Cmd.Parameters.AddWithValue("@pIdEvento", pIdEvento);

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;

            }
            catch (Exception)
            {
                return null;
            }
        }


        public DataTable fnCargaEstatusSolicitud(string strSQL, int pTipo)
        {
            clsConexion sqlCon = new clsConexion();
            try
            {
                SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion());
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                Cmd.Parameters.AddWithValue("TipoSolicitudId", pTipo);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;


            }
            catch (Exception)
            {
                return null;
            }
        }


        public DataTable fnCargaListadoSolicitudes(string strSQL, string pFechaInicial,string pFechaFinal,int pEjercicioContableId,int pModuloId,string pParametroTipoSolPago, string pParametroConcEstatusSp, int pNumeroInicial,int pNumeroFinal,  int pRangoNumero,int pFiltrarPorFechas,int IdUsuario)
        {
            clsConexion sqlCon = new clsConexion();
            try
            {
                SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion());
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                Cmd.Parameters.AddWithValue("@FechaInicial", pFechaInicial);
                Cmd.Parameters.AddWithValue("@FechaFinal", pFechaFinal);
                Cmd.Parameters.AddWithValue("@EjercicioContableId", pEjercicioContableId);
                Cmd.Parameters.AddWithValue("@ModuloId", pModuloId);
                Cmd.Parameters.AddWithValue("@ParametroTipoSolPago", pParametroTipoSolPago);
                Cmd.Parameters.AddWithValue("@ParametroConcEstatusSp", pParametroConcEstatusSp);
                Cmd.Parameters.AddWithValue("@NumeroInicial", pNumeroInicial);
                Cmd.Parameters.AddWithValue("@NumeroFinal", pNumeroFinal);
                Cmd.Parameters.AddWithValue("@RangoNumero", pRangoNumero);
                Cmd.Parameters.AddWithValue("@FiltrarPorFechas", pFiltrarPorFechas);
                Cmd.Parameters.AddWithValue("@pIdUsuario", IdUsuario);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }



        public DataTable fnCargaListadoDocumentos(string strSQL, int pIdEstado,int pIdNivel,int pIdTpogasto, string pFechaInicial, string pFechaFinal,  int IdUsuario, int IdRegistroMatriz)
        {
            using (SqlConnection sqlCnn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    //                @pIdEstado
                    //@pIdNivel
                    //@pIdTpogasto
                    //@pFechaInicial
                    //@pFechaFinal
                    //@pIdUsuarioweb





                    SqlCommand Cmd = new SqlCommand(strSQL, sqlCnn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    Cmd.Parameters.AddWithValue("@pIdEstado", pIdEstado);
                    Cmd.Parameters.AddWithValue("@pIdNivel", pIdNivel);
                    Cmd.Parameters.AddWithValue("@pIdConcepto", pIdTpogasto);
                    Cmd.Parameters.AddWithValue("@pFechaInicial", pFechaInicial);
                    Cmd.Parameters.AddWithValue("@pFechaFinal", pFechaFinal);
                    Cmd.Parameters.AddWithValue("@pIdUsuarioweb", IdUsuario);
                    Cmd.Parameters.AddWithValue("@pIdMatrizRegistro", IdRegistroMatriz);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    sqlCnn.Close();
                    return dt;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }


        public DataTable fnCargaListadoCarpetas(string strSQL, int pIdPeriodo, int pIdEstado, int pIdNivel, int pIdDistrito, int pIdCandidato, int pIdConcepto, int pIdEvento, int pIdDocumento, string pFechaInicial, string pFechaFinal, int IdUsuario, int Estatus)
        {
            using (SqlConnection sqlCnn = new SqlConnection(CadenaConexion))
            {
                try
                {




                    SqlCommand Cmd = new SqlCommand(strSQL, sqlCnn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    Cmd.Parameters.AddWithValue("@pIdPeriodo", pIdPeriodo);
                    Cmd.Parameters.AddWithValue("@pIdEstado", pIdEstado);
                    Cmd.Parameters.AddWithValue("@pIdNivel", pIdNivel);
                    Cmd.Parameters.AddWithValue("@pIdDistrito", pIdDistrito);
                    Cmd.Parameters.AddWithValue("@pIdCandidato", pIdCandidato);
                    Cmd.Parameters.AddWithValue("@pIdConcepto", pIdConcepto);
                    Cmd.Parameters.AddWithValue("@pIdEvento", pIdEvento);
                    Cmd.Parameters.AddWithValue("@pIdDocumento", pIdDocumento);
                    Cmd.Parameters.AddWithValue("@pFechaInicial", pFechaInicial);
                    Cmd.Parameters.AddWithValue("@pFechaFinal", pFechaFinal);
                    Cmd.Parameters.AddWithValue("@pIdUsuarioweb", IdUsuario);
                    Cmd.Parameters.AddWithValue("@pEstatus", Estatus);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    sqlCnn.Close();
                    return dt;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }




        public DataTable fnCargaHistorialEstatusSolicitud(string strSQL,  int pIdSolicitud)
        {
            clsConexion sqlCon = new clsConexion();
            try
            {
                SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion());
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                Cmd.Parameters.AddWithValue("IdSolicitud", pIdSolicitud);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public DataTable fnCargaMatriz(string strSQL, int pIdEstado)
        {
            using (SqlConnection sqlCnn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    SqlCommand Cmd = new SqlCommand(strSQL, sqlCnn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    Cmd.Parameters.AddWithValue("@IdCandidato", pIdEstado);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    sqlCnn.Close();
                    return dt;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
        public int fnEjercicioPresupuestal(string strSQL,int  pAnio)
        {
            clsConexion sqlCon = new clsConexion();
            try
            {
                SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion());
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@Anio", pAnio);
                SqlParameter pIdCveDep = new SqlParameter("@EjercicioContableId", SqlDbType.Int, 5);
                pIdCveDep.Direction = ParameterDirection.Output;
                Cmd.Parameters.Add(pIdCveDep);
                Cmd.ExecuteNonQuery();
                return (int)pIdCveDep.Value;

            }
            catch (Exception)
            {
                return 0;
            }
        }


        //@pIdPeriodo int,
        //                               @pIdNivel int , 
        //                               @pIdEstado int,
        //	   @pIdDistrito int,
        //	   @pIdCandidato int,
        //	   @pIdConcepto int,
        //	   @pIdEvento int,
        //	   @pIdDocumento int,
        //	   @pIdRegistroMatriz int output)
        public int fnInsertaEncabezadoMatriz(string strSQL, int pIdRegistromatrizcaptura, int pIdUsuarioGlobal, int pIdPeriodo, int pIdNivel, int pIdEstado, int pIdDistrito, int pIdCandidato, int pIdConcepto, int pIdEvento, int pIdDocumento, string pAgrupador, decimal pImporte, DataTable CargaArchivo)
        {
           
            using (SqlConnection sqlCnn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    SqlCommand Cmd = new SqlCommand(strSQL, sqlCnn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@pIdRegistroMatrizCaptura", pIdRegistromatrizcaptura);
                    Cmd.Parameters.AddWithValue("@pIdUsuarioGlobal", pIdUsuarioGlobal);

                    Cmd.Parameters.AddWithValue("@pIdPeriodo", pIdPeriodo);
                    Cmd.Parameters.AddWithValue("@pIdNivel", pIdNivel);
                    Cmd.Parameters.AddWithValue("@pIdEstado", pIdEstado);
                    Cmd.Parameters.AddWithValue("@pIdDistrito", pIdDistrito);
                    Cmd.Parameters.AddWithValue("@pIdCandidato", pIdCandidato);
                    Cmd.Parameters.AddWithValue("@pIdConcepto", pIdConcepto);
                    Cmd.Parameters.AddWithValue("@pIdEvento", pIdEvento);
                    Cmd.Parameters.AddWithValue("@pIdDocumento", pIdDocumento);
                    Cmd.Parameters.AddWithValue("@pAgrupador", pAgrupador);
                    Cmd.Parameters.AddWithValue("@pImporteOperacion", pImporte);
                    Cmd.Parameters.AddWithValue("@TableCargaArchivo", CargaArchivo);
                    SqlParameter pIdCveDep = new SqlParameter("@pIdRegistroMatriz", SqlDbType.Int, 5);
                    pIdCveDep.Direction = ParameterDirection.Output;
                    Cmd.Parameters.Add(pIdCveDep);
                    sqlCnn.Open();
                    Cmd.ExecuteNonQuery();
                    sqlCnn.Close();
                    return (int)pIdCveDep.Value;
                }
                
                catch (Exception)
                {
                    return 0;
                }
            }
        }
        public decimal fnConsultaDisponibleClave(string strSQL, int pIdClave,int pMes)
        {
            clsConexion sqlCon = new clsConexion();
            try
            {
                SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion());
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@pIdClave", pIdClave);
                Cmd.Parameters.AddWithValue("@pMes", pMes);
                SqlParameter pDisponible = new SqlParameter("@pDisponible", SqlDbType.Decimal, 14);
                pDisponible.Direction = ParameterDirection.Output;
                Cmd.Parameters.Add(pDisponible);
                Cmd.ExecuteNonQuery();
                return (decimal)pDisponible.Value;

            }
            catch (Exception)
            {
                return 0;
            }
        }

        public string fnFechaServidor()
        {
            clsConexion sqlCon = new clsConexion();
            try
                {



                    //SqlCommand Cmd = new SqlCommand("spFechaServidorRemoto", sqlCnn);
                    //Cmd.CommandType = CommandType.StoredProcedure;

                    //SqlParameter FechaSalida = new SqlParameter("@FechaServidor", SqlDbType.VarChar, 88);
                    //FechaSalida.Direction = ParameterDirection.Output;
                    //Cmd.Parameters.Add(FechaSalida);
                    //Cmd.ExecuteNonQuery();
                    ////sqlCnn.Close();
                    //return (string)FechaSalida.Value;


                    SqlCommand Cmd = new SqlCommand("spFechaServidorRemoto", sqlCon.getConexion() );
                    Cmd.CommandType = CommandType.StoredProcedure;
                  
                    SqlParameter CapturaColectivaDetalle = new SqlParameter("@FechaServidor", SqlDbType.VarChar, 88);
                    CapturaColectivaDetalle.Direction = ParameterDirection.Output;
                    Cmd.Parameters.Add(CapturaColectivaDetalle);
                    Cmd.ExecuteNonQuery();
                    sqlCon. getConexion().Close();
                    return (string)CapturaColectivaDetalle.Value;









                }
                catch (Exception)
                {
                    return "";
                }
            
        }






        public string fnExtenciones(string strSQL, int pIdDocumento)
        {
            clsConexion sqlCon = new clsConexion();
            
                try
                {
                    //SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion());
                    //Cmd.CommandType = CommandType.StoredProcedure;
                    //Cmd.Parameters.AddWithValue("@pIdDocumento", pIdDocumento);
                    //SqlParameter pExt = new SqlParameter("@pExtensiones", SqlDbType.VarChar);
                    //pExt.Direction = ParameterDirection.Output;
                    //Cmd.Parameters.Add(pExt);

                    //Cmd.ExecuteNonQuery();
                    //return (string)pExt.Value;



                    SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion() );
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@pIdDocumento", pIdDocumento);
                    SqlParameter CapturaColectivaDetalle = new SqlParameter("@pExtensiones", SqlDbType.VarChar, 88);
                    CapturaColectivaDetalle.Direction = ParameterDirection.Output;
                    Cmd.Parameters.Add(CapturaColectivaDetalle);
                    Cmd.ExecuteNonQuery();
                    sqlCon.getConexion().Close();
                    return (string)CapturaColectivaDetalle.Value;




                }
                catch (Exception)
                {
                    return "";
                }
            
        }

        public int fnRegistroBloqueado(string strSQL, int pIdRegistroMatriz)
        {
            clsConexion sqlCon = new clsConexion();

            try
            {
                //SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion());
                //Cmd.CommandType = CommandType.StoredProcedure;
                //Cmd.Parameters.AddWithValue("@pIdDocumento", pIdDocumento);
                //SqlParameter pExt = new SqlParameter("@pExtensiones", SqlDbType.VarChar);
                //pExt.Direction = ParameterDirection.Output;
                //Cmd.Parameters.Add(pExt);

                //Cmd.ExecuteNonQuery();
                //return (string)pExt.Value;



                SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion());
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@pIdRegistroMatriz", pIdRegistroMatriz);
                SqlParameter CapturaColectivaDetalle = new SqlParameter("@pBloqueado", SqlDbType.Int, 5);
                CapturaColectivaDetalle.Direction = ParameterDirection.Output;
                Cmd.Parameters.Add(CapturaColectivaDetalle);
                Cmd.ExecuteNonQuery();
                sqlCon.getConexion().Close();
                return (int)CapturaColectivaDetalle.Value;




            }
            catch (Exception)
            {
                return 0;
            }

        }

        public int fnRegistroEsPresupuestal(string strSQL, int pIdRegistroMatriz)
        {
            clsConexion sqlCon = new clsConexion();

            try
            {
                //SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion());
                //Cmd.CommandType = CommandType.StoredProcedure;
                //Cmd.Parameters.AddWithValue("@pIdDocumento", pIdDocumento);
                //SqlParameter pExt = new SqlParameter("@pExtensiones", SqlDbType.VarChar);
                //pExt.Direction = ParameterDirection.Output;
                //Cmd.Parameters.Add(pExt);

                //Cmd.ExecuteNonQuery();
                //return (string)pExt.Value;



                SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion());
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@pIdRegistroMatriz", pIdRegistroMatriz);
                SqlParameter CapturaColectivaDetalle = new SqlParameter("@pEspptal", SqlDbType.Int, 5);
                CapturaColectivaDetalle.Direction = ParameterDirection.Output;
                Cmd.Parameters.Add(CapturaColectivaDetalle);
                Cmd.ExecuteNonQuery();
                sqlCon.getConexion().Close();
                return (int)CapturaColectivaDetalle.Value;




            }
            catch (Exception)
            {
                return 0;
            }

        }



        public int fnRegistroCancelado(string strSQL, int pIdRegistroMatriz)
        {
            clsConexion sqlCon = new clsConexion();

            try
            {
                //SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion());
                //Cmd.CommandType = CommandType.StoredProcedure;
                //Cmd.Parameters.AddWithValue("@pIdDocumento", pIdDocumento);
                //SqlParameter pExt = new SqlParameter("@pExtensiones", SqlDbType.VarChar);
                //pExt.Direction = ParameterDirection.Output;
                //Cmd.Parameters.Add(pExt);

                //Cmd.ExecuteNonQuery();
                //return (string)pExt.Value;



                SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion());
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@pIdRegistroMatriz", pIdRegistroMatriz);
                SqlParameter CapturaColectivaDetalle = new SqlParameter("@pEstatus", SqlDbType.Int, 5);
                CapturaColectivaDetalle.Direction = ParameterDirection.Output;
                Cmd.Parameters.Add(CapturaColectivaDetalle);
                Cmd.ExecuteNonQuery();
                sqlCon.getConexion().Close();
                return (int)CapturaColectivaDetalle.Value;




            }
            catch (Exception)
            {
                return 0;
            }

        }






        public decimal fnDisponibleAgrupador(string strSQL, int pIdEstado, int pIdDistrito, int pIdConcepto,int pIdEvento)
        {
            clsConexion sqlCon = new clsConexion();

            try
            {

                //@pIdCandidato int, @pIdConcepto int, @pIdEvento


                SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion());
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@pIdEstado", pIdEstado);
                Cmd.Parameters.AddWithValue("@pIdDistrito", pIdDistrito);
                Cmd.Parameters.AddWithValue("@pIdConcepto", pIdConcepto);
               
                Cmd.Parameters.AddWithValue("@pIdEvento", pIdEvento);
                SqlParameter DisponibleAgrupador = new SqlParameter("@pDisponible", SqlDbType.Decimal, 14);
                DisponibleAgrupador.Direction = ParameterDirection.Output;
                Cmd.Parameters.Add(DisponibleAgrupador);
                Cmd.ExecuteNonQuery();
                sqlCon.getConexion().Close();
                return (decimal )DisponibleAgrupador.Value;




            }
            catch (Exception)
            {
                return 0;
            }

        }



        public decimal fnCapturadoAgrupador(string strSQL, int pIdEstado, int pIdDistrito, int pIdConcepto, int pIdEvento)
        {
            clsConexion sqlCon = new clsConexion();

            try
            {

                //@pIdCandidato int, @pIdConcepto int, @pIdEvento


                SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion());
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@pIdEstado", pIdEstado);
                Cmd.Parameters.AddWithValue("@pIdDistrito", pIdDistrito);
                Cmd.Parameters.AddWithValue("@pIdConcepto", pIdConcepto);

                Cmd.Parameters.AddWithValue("@pIdEvento", pIdEvento);
                SqlParameter DisponibleAgrupador = new SqlParameter("@pDisponible", SqlDbType.Decimal, 14);
                DisponibleAgrupador.Direction = ParameterDirection.Output;
                Cmd.Parameters.Add(DisponibleAgrupador);
                Cmd.ExecuteNonQuery();
                sqlCon.getConexion().Close();
                return (decimal)DisponibleAgrupador.Value;




            }
            catch (Exception)
            {
                return 0;
            }

        }

















        public int fnExisteArchivoCargaAgrupador(string strSQL, int pIdRegistroMatriz, string pNombreArchivo)
        {
            clsConexion sqlCon = new clsConexion();

            try
            {
                


                SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion());
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@pIdMatrizEncabezado", pIdRegistroMatriz);
                Cmd.Parameters.AddWithValue("@NombreArchivo", pNombreArchivo);
                SqlParameter CapturaColectivaDetalle = new SqlParameter("@pExiste", SqlDbType.Int, 5);
                CapturaColectivaDetalle.Direction = ParameterDirection.Output;
                Cmd.Parameters.Add(CapturaColectivaDetalle);
                Cmd.ExecuteNonQuery();
                sqlCon.getConexion().Close();
                return (int)CapturaColectivaDetalle.Value;




            }
            catch (Exception)
            {
                return 0;
            }

        }


        public string fnEstatusValidaRFC(string strSQL, string pRFC)
        {
            clsConexion sqlCon = new clsConexion();

            try
            {
               


                SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion());
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@pRFC", pRFC);
                SqlParameter CapturaColectivaDetalle = new SqlParameter("@pSituacionContribuyente", SqlDbType.VarChar, 88);
                CapturaColectivaDetalle.Direction = ParameterDirection.Output;
                Cmd.Parameters.Add(CapturaColectivaDetalle);
                Cmd.ExecuteNonQuery();
                sqlCon.getConexion().Close();
                return (string)CapturaColectivaDetalle.Value;




            }
            catch (Exception)
            {
                return "";
            }

        }






        public DataTable  fnCargaagrupador(string strSQL, int pIdRegistroMatriz, int idusuarioglobal)
        {
            using (SqlConnection sqlCnn = new SqlConnection(CadenaConexion))
            {
                try
                {




                    SqlCommand Cmd = new SqlCommand(strSQL, sqlCnn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    Cmd.Parameters.AddWithValue("@pIdRegistroMatriz", pIdRegistroMatriz);
                    Cmd.Parameters.AddWithValue("@pIdUsuarioGlobal", idusuarioglobal);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    sqlCnn.Close();
                    return dt;


                }
                catch (Exception)
                {
                    return null;
                }
            }
        }




        public decimal fnConsultaDisponibleDocumento(string strSQL,int pIdDocumento)
        {
            clsConexion sqlCon = new clsConexion();
            try
            {
                SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion());
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@pIdDocumento", pIdDocumento);
             
                SqlParameter pDisponible = new SqlParameter("@pDisponibleDocumento", SqlDbType.Decimal, 14);
                pDisponible.Direction = ParameterDirection.Output;
                Cmd.Parameters.Add(pDisponible);
                Cmd.ExecuteNonQuery();
                return (decimal)pDisponible.Value;

            }
            catch (Exception)
            {
                return 0;
            }
        }






        public int fnCapturaColectivaDetalle(string strSQL, int pIdEventoEspecifico)
        {
            clsConexion sqlCon = new clsConexion();
            try
            {
                SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion());
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@pIdEventoEspecifico", pIdEventoEspecifico);
                SqlParameter CapturaColectivaDetalle = new SqlParameter("@ConColectivaDetalle", SqlDbType.Int, 5);
                CapturaColectivaDetalle.Direction = ParameterDirection.Output;
                Cmd.Parameters.Add(CapturaColectivaDetalle);
                Cmd.ExecuteNonQuery();
                return (int)CapturaColectivaDetalle.Value;

            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int fnInsertaEncabezadoSolicitud(string strSQL, int pBeneficiarioId,int pEventoGenericoId,int pDependenciaId, int pGenComprometido, int pComprometidoId, int pFuenteFinanciamientoId,int pSolicitudAnteriorId, int pCuentaBancariaId, int pMesAPagar,string pDescripcion,string pBeneficiarioCheque, string pFecha, int pEjercicioContableId)
        {

            //@SolicitudId INT OUTPUT,
            //@BeneficiarioId INT,
            //@EventoGenericoId   INT,
            //@DependenciaId INT,
            //@ComprometidoId     INT = NULL,
            //@FuenteFinanciamientoId INT = NULL,
            //@SolicitudAnteriorId    INT = NULL,
            //@CuentaBancariaId INT = NULL,
            //@MesAPagar          SMALLINT = NULL,
            //@Descripcion VARCHAR(255),
            //@BeneficiarioCheque VARCHAR(120) = NULL,
            //@Fecha DATETIME,
            //@EjercicioContableId    INT

                clsConexion sqlCon = new clsConexion();
            
                try
                {
                    SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion());
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@BeneficiarioId", pBeneficiarioId);
                    Cmd.Parameters.AddWithValue("@EventoGenericoId", pEventoGenericoId);
                    Cmd.Parameters.AddWithValue("@DependenciaId", pDependenciaId);
                    Cmd.Parameters.AddWithValue("@GeneraComprometido", pGenComprometido);
                    Cmd.Parameters.AddWithValue("@ComprometidoId", pComprometidoId);
                    Cmd.Parameters.AddWithValue("@FuenteFinanciamientoId", pFuenteFinanciamientoId);
                    Cmd.Parameters.AddWithValue("@SolicitudAnteriorId", pSolicitudAnteriorId);
                    Cmd.Parameters.AddWithValue("@CuentaBancariaId", pCuentaBancariaId);
                    Cmd.Parameters.AddWithValue("@MesAPagar", pMesAPagar);
                    Cmd.Parameters.AddWithValue("@Descripcion", pDescripcion);
                    Cmd.Parameters.AddWithValue("@BeneficiarioCheque", pBeneficiarioCheque);
                    Cmd.Parameters.AddWithValue("@Fecha", pFecha);
                    Cmd.Parameters.AddWithValue("@EjercicioContableId", pEjercicioContableId);
                    SqlParameter pIdSolicitud = new SqlParameter("@SolicitudId", SqlDbType.Int, 5);
                    pIdSolicitud.Direction = ParameterDirection.Output;
                    Cmd.Parameters.Add(pIdSolicitud);
                    Cmd.ExecuteNonQuery();
                    sqlCon.getConexion().Close();
                    return (int)pIdSolicitud.Value;

                }
                catch (Exception)
                {
                    return 0;
                }
            
        }

        public int fnInsertaDetalleSolicitud(string strSQL, string pDetallesolicitud)
        {

           
            clsConexion sqlCon = new clsConexion();
            try
            {
                SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion());
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@xmlDetalle", pDetallesolicitud);
               
                SqlParameter NumeroSolicitud = new SqlParameter("@pNumeroSolicitud", SqlDbType.Int, 5);
                NumeroSolicitud.Direction = ParameterDirection.Output;
                Cmd.Parameters.Add(NumeroSolicitud);
                Cmd.ExecuteNonQuery();
                return (int)NumeroSolicitud.Value;

            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void fnBorraRegistroUnico(string strSQL, int pIdRegistroUnico, int IdUsuarioEliminar)
        {


            clsConexion sqlCon = new clsConexion();
            
                try
                {
                    SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion() );
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@pIdRegistroUnico", pIdRegistroUnico);
                    Cmd.Parameters.AddWithValue("@pIdUsuarioGlobal", IdUsuarioEliminar);

                Cmd.ExecuteNonQuery();
                sqlCon.getConexion().Close();

                }
                catch (Exception)
                {

                }
            
        }


        public void fnActualizaRegistroAgrupador(string strSQL, int pIdRegistroMatriz, decimal pImporte)
        {


            clsConexion sqlCon = new clsConexion();

            try
            {
                SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion());
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@pIdRegistroMatriz", pIdRegistroMatriz);
                Cmd.Parameters.AddWithValue("@pImporte", pImporte);
                Cmd.ExecuteNonQuery();
                sqlCon.getConexion().Close();

            }
            catch (Exception)
            {

            }

        }





        public void fnCancelarPoliza(string strSQL, int pIdRegistroMatriz)
        {


            clsConexion sqlCon = new clsConexion();
            
                try
                {
                    SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion());
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@pIdMatrizRegistro", pIdRegistroMatriz);


                    Cmd.ExecuteNonQuery();
                    sqlCon.getConexion().Close();

                }
                catch (Exception)
                {

                }
            
        }





        public void fnSustituirRegistroUnico(string strSQL, int pIdRegistroUnico, int IdUsuarioGlobal)
        {


            clsConexion sqlCon = new clsConexion();
            
                try
                {
                    SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion() );
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@pIdRegistroUnico", pIdRegistroUnico);
                     Cmd.Parameters.AddWithValue("@pidUsuarioGlobal", IdUsuarioGlobal);

                    Cmd.ExecuteNonQuery();
                    sqlCon.getConexion().Close();

                }
                catch (Exception)
                {

                }
            
        }





        public void fnActualizaPw(string strSQL, int pIdUsuario,string pPw)
        {


            clsConexion sqlCon = new clsConexion();

            try
            {
                    SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion());
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@pIdUsuario", pIdUsuario);
                    Cmd.Parameters.AddWithValue("@pPw", pPw);


                    Cmd.ExecuteNonQuery();
                    sqlCon.getConexion().Close();

                }
                catch (Exception)
                {

                }
            
        }



        public DataTable fnCargaConfiguracionEventoGenerico(string strSQL, int pIdEvento)
        {
            clsConexion sqlCon = new clsConexion();
            try
            {
                SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion());
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                Cmd.Parameters.AddWithValue("@pIdEvento", pIdEvento);
                
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
                
            }
            catch (Exception)
            {
                return null;
            }
        }


        public DataTable fnCargaConfiguracionEventoEspecifico(string strSQL, int pIdEventoEspecifico)
        {
            clsConexion sqlCon = new clsConexion();
            try
            {
                SqlCommand Cmd = new SqlCommand(strSQL, sqlCon.getConexion());
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                Cmd.Parameters.AddWithValue("@pIdEventoEspecifico", pIdEventoEspecifico);

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;

            }
            catch (Exception)
            {
                return null;
            }
        }


    }
}