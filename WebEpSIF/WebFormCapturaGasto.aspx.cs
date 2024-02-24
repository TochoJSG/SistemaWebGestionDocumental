using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Globalization;

using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Diagnostics;
using SAT.Services.ConsultaCFDIService;
using SW.Services.Status;
using System.Data.OleDb;
namespace WebEpSIF
{
    public partial class WebFormCapturaGasto : System.Web.UI.Page
    {

        static int pIdEvento = 0;
        static int pIdDependencia = 0;
        static int pIdEjercicioPresupuestal = 0;
        static int IdUsuarioGlobal = 0;
        static int pIdeventoEspecifico = 0;
        static string baja = "0";
        static string pptal = "0";
        static string ingresos = "0";
        static string viaticos = "0";
        static int ConColectivaDetalle;
        static int IdColectiva = 0;
        static int pIdEventoEspecifico = 0;

        static decimal ImporteCapturado = 0;
        static decimal DisponibleConsultado = 0;
        static string ConDocumento = "0";

        static decimal DisponibleEnclavePresupuestal = 0;
        static decimal DisponibleEnDocumento = 0;

        static DataTable dt;

        static DataRow dr;

        static object sumObject = null;
        static decimal CapturadoClave;

        static int n = 0;
        static decimal DisponibleDocumento = 0;
        static decimal ImporteDocumentoCapturado = 0;
        static int pIdRegistroMatriz = 0;
        static string strTipoOperacio = "";

        static int IdCandidatura;

        static string strAgrupador = "";
        static string strDocumentoExtensiones = "";




        static int gIdNivel;
        static int gIdEstado;
        static int gIdDistrito;
        static int gIdCandidato;
        static int gIdConcepto;
        static int gIdEvento;
        static int gIdDocumento;
        static int gIdPeriodo;

        static int gEsPptal = 0;
        static decimal gImporte = 0;
        static decimal gImporteAgrupador = 0;
        static decimal gDisponible = 0;
        static decimal gImporteTotal = 0;



        static Boolean gRegistroInsertado = false;

        static int gGlobalIdMatrizRegistro = 0;



        WebEpSIF.NEGOCIO.NAdministraSolicitudes NAdmiSol = new WebEpSIF.NEGOCIO.NAdministraSolicitudes();

        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {

                if (!Page.IsPostBack)
                {


                    IdUsuarioGlobal = Convert.ToInt32(Session["IdUsuario"]);
                    pIdRegistroMatriz = Convert.ToInt32(Session["IdMatriz"]);

                    LabelAgrupador.Visible = true;
                        dt = NAdmiSol.NCargaAgrupador(pIdRegistroMatriz, IdUsuarioGlobal);
                        strAgrupador = dt.Rows[0]["Agrupador"].ToString();



                        //pIdRegistroMatriz = Convert.ToInt32(Session["IdRegistroMatriz"]);

                        dt = NAdmiSol.NCargaAgrupador(pIdRegistroMatriz, IdUsuarioGlobal);
                        dt.Rows[0]["Agrupador"].ToString();

                        gIdNivel = Convert.ToInt32(dt.Rows[0]["IdNivel"].ToString());
                        gIdEstado = Convert.ToInt32(dt.Rows[0]["IdEstado"].ToString());
                        gIdDistrito = Convert.ToInt32(dt.Rows[0]["IdDistrito"].ToString());
                        gIdCandidato = Convert.ToInt32(dt.Rows[0]["IdCandidato"].ToString());
                        gIdConcepto = Convert.ToInt32(dt.Rows[0]["IdConcepto"].ToString());
                        gIdEvento = Convert.ToInt32(dt.Rows[0]["IdEvento"].ToString());
                        gIdDocumento = Convert.ToInt32(dt.Rows[0]["IdDocumento"].ToString());
                        gIdPeriodo = Convert.ToInt32(dt.Rows[0]["IdPeriodo"].ToString());

                        //lblExtensiones.Text = NAdmiSol.NCargaExtenciones(    Convert.ToInt32 (dt.Rows[0]["IdDocumento"].ToString())   );
                        //strDocumentoExtensiones = NAdmiSol.NCargaExtenciones(Convert.ToInt32(dt.Rows[0]["IdDocumento"].ToString()));

                        LabelAgrupador.Text = strAgrupador;
                      
                    


                    gDisponible = NAdmiSol.NCalculaDisponible(gIdEstado, gIdDistrito, gIdConcepto, gIdEvento);

                    decimal pptal = gDisponible;


                    gImporteAgrupador = NAdmiSol.NCapturadoAgrupador(gIdEstado, gIdDistrito, gIdConcepto, gIdEvento);
                    gDisponible = gDisponible - gImporteAgrupador;
                    //TextBoxCapturado.Text = gImporteAgrupador.ToString();
                    //TextBoxDisponible.Text = gDisponible.ToString();

                    //TextBoxCapturado.Text = (Convert.ToDecimal(gImporteAgrupador.ToString()), "C").ToString();
                    //if ((strTipoOperacio == "Editar")| (strTipoOperacio == "Nuevo"))

                    if (pptal == -1)
                    {
                        TextBoxCapturado.Text = "0";

                        TextBoxDisponible.Text = "0";
                    }
                    else
                    { 
                    TextBoxCapturado.Text = string.Format("{0,0:c}", gImporteAgrupador);

                    TextBoxDisponible.Text = string.Format("{0,0:c}", gDisponible);
                    }
                    //{


                    //    if (gDisponible == -1)
                    //    {

                    //        Label6.Visible = false;
                    //        Label7.Visible = false;
                    //        Label8.Visible = false;
                    //        TextBoxCapturado.Visible = false;
                    //        TextBoxDisponible.Visible = false;
                    //        txtImporte.Visible = false;
                    //        gEsPptal = 0;


                    //    }
                    //    else
                    //    {

                    //        Label6.Visible = true;
                    //        Label7.Visible = true;
                    //        TextBoxDisponible.Visible = true;
                    //        txtImporte.Visible = true;
                    //        Label8.Visible = true;
                    //        TextBoxCapturado.Text = gImporteAgrupador.ToString();
                    //        TextBoxDisponible.Text = gDisponible.ToString();
                    //        gEsPptal = 1;

                    //    }




                    //}









                }






            }





            catch (Exception ex)
            {
                //Response.Redirect("Error.aspx"); 
            }















        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {


            if (txtImporte.Text == "")
            {

                Response.Write("<script language=javascript>");
                Response.Write("alert('Favor de capturar el importe...')");
                Response.Write("</script>");
                return;

            }

            if (Convert.ToDecimal(txtImporte.Text) == 0)
            {

                Response.Write("<script language=javascript>");
                Response.Write("alert('El importe capturado es incorrecto...')");
                Response.Write("</script>");
                return;

            }



            if (gDisponible < Convert.ToDecimal(txtImporte.Text))
            {

                Response.Write("<script language=javascript>");
                Response.Write("alert('El importe capturado es mayor al Disponible...')");
                Response.Write("</script>");
                return;

            }

            if (Convert.ToDecimal(txtImporte.Text)<0)
            {

                Response.Write("<script language=javascript>");
                Response.Write("alert('El importe capturado es incorrecto...')");
                Response.Write("</script>");
                return;

            }



            


            NAdmiSol.NActualizaImporteAgrupa(pIdRegistroMatriz, Convert.ToDecimal(txtImporte.Text));
            gDisponible = NAdmiSol.NCalculaDisponible(gIdEstado ,gIdDistrito , gIdConcepto, gIdEvento);
            gImporteAgrupador = NAdmiSol.NCapturadoAgrupador(gIdEstado, gIdDistrito, gIdConcepto, gIdEvento);
            gDisponible = gDisponible - gImporteAgrupador;
            //TextBoxCapturado.Text =   gImporteAgrupador.ToString();
            //TextBoxDisponible.Text = gDisponible.ToString();


            TextBoxCapturado.Text = string.Format("{0,0:c}", gImporteAgrupador);

            TextBoxDisponible.Text = string.Format("{0,0:c}", gDisponible);

            Response.Redirect("WebCapturaDocumentos.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebCapturaDocumentos.aspx");
        }

        protected void TextBoxDisponible_TextChanged(object sender, EventArgs e)
        {

        }
    }
}