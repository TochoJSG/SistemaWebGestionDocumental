using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text.RegularExpressions;
using System.IO;

namespace WebSIF.WebForms
{
    public partial class WebFormAdministraSolicitudes : System.Web.UI.Page
    {
        WebEpSIF.NEGOCIO.NAdministraSolicitudes NAdmiSol = new WebEpSIF.NEGOCIO.NAdministraSolicitudes();


        int pIdEjercicioPresupuestal = 0;
        int IdUsuarioGlobal;

        protected void calFechaI_SelectionChanged(object sender, EventArgs e)
        {
            txtFechaInicio.Text = calFechaInicio.SelectedDate.ToShortDateString();  
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                pIdEjercicioPresupuestal = CargaIdCvedef(2019);
                calFechaInicio.Visible = false;
                calFechaFin.Visible = false;
                //CargaListaTipoSolicitud();
                //CargaListaEstatusSolicitud();
                DateTime dd = DateTime.Now;
                IdUsuarioGlobal = Convert.ToInt32(Session["IdUsuario"]);
                txtFechaInicio.Text = dd.ToShortDateString();
                txtFechaFin.Text = dd.ToShortDateString();
               // CargaEventoEspecifico(IdUsuarioGlobal);
                CargaColectivaDetalle(0);
                CargaTipoDocumento();
                Session["IdEjercicioPresupuestal"] = pIdEjercicioPresupuestal;

             

               }

            //if (Request.Params["IdUsuario"] != null)
            //{    
            //    IdUsuarioGlobal = Convert.ToInt32(Request.Params["IdUsuario"]);
            //}

               
            
            
        }

        protected void CargaEventoEspecifico( int pIdUsuario,int pIdCandidatura)
        {

            ddlEventoEspecifico.DataSource = NAdmiSol.NCargaEventoEspecifico(pIdUsuario, pIdCandidatura);
            ddlEventoEspecifico.DataTextField = "Descripcion";
            ddlEventoEspecifico.DataValueField = "IdEstado";
            ddlEventoEspecifico.DataBind();
            ddlEventoEspecifico.Items.Insert(0, new ListItem("[TODOS...]", "0"));



        }


        protected void CargaTipoDocumento()
        {

            ddlConcepto.DataSource = NAdmiSol.NCargaTipoDocumento();
            ddlConcepto.DataTextField = "DescripcionTipoGasto";
            ddlConcepto.DataValueField = "idtipogasto";
            ddlConcepto.DataBind();
            ddlConcepto.Items.Insert(0, new ListItem("[TODOS...]", "0"));



        }
        protected void CargaColectivaDetalle(int pIdEventoEspecifico)
        {


            ddlColectivaDetalle.DataSource = NAdmiSol.NCargaColectivaEventoEspecifico(pIdEventoEspecifico);
            ddlColectivaDetalle.DataTextField = "DescripcionNivel";
            ddlColectivaDetalle.DataValueField = "Idnivel";
            ddlColectivaDetalle.DataBind();
            ddlColectivaDetalle.Items.Insert(0, new ListItem("[TODOS...]", "0"));


        }

        void RefrescaGrid(int pIdRegistroMatriz)
        {

            DateTime FechaInicial = Convert.ToDateTime(txtFechaInicio.Text);
            DateTime FechaFinal = Convert.ToDateTime(txtFechaFin.Text);


            gvDetalleSolicitud.DataSource = null;
            gvDetalleSolicitud.DataBind();
            IdUsuarioGlobal = Convert.ToInt32(Session["IdUsuario"]);
            gvDetalleSolicitud.AutoGenerateSelectButton = true;
            gvDetalleSolicitud.DataSource = NAdmiSol.NCargaListadoDocumentos(Convert.ToInt32(ddlEventoEspecifico.SelectedValue) , Convert.ToInt32(ddlColectivaDetalle .SelectedValue), Convert.ToInt32(ddlConcepto.SelectedValue), FechaInicial.ToString("yyyy-MM-dd"), FechaFinal.ToString("yyyy-MM-dd"), IdUsuarioGlobal, pIdRegistroMatriz);
            gvDetalleSolicitud.DataBind();

        }
        protected void btnFechaInicio_Click(object sender, EventArgs e)
        {
            calFechaInicio.Visible = !calFechaInicio.Visible;   
        }

        protected void btnFechaFin_Click(object sender, EventArgs e)
        {
            calFechaFin.Visible = !calFechaFin.Visible;  
        }

        protected void calFechaFin_SelectionChanged(object sender, EventArgs e)
        {
            txtFechaFin.Text = calFechaFin.SelectedDate.ToShortDateString();    
        }

        

        protected void CargaListaTipoSolicitud()
        {
            //ddlTipoSolicitud.DataSource = NAdmiSol.NCargaTipoSolicitud();
            //ddlTipoSolicitud.DataTextField = "Descripcion";
            //ddlTipoSolicitud.DataValueField = "TipoSolicitudId";
            //ddlTipoSolicitud.DataBind();

            
        }

        protected void CargaListaEstatusSolicitud()
        {
            //ddlEstatusSolicitud.DataSource = NAdmiSol.NCargaEstatusSolicitud(0);
            //ddlEstatusSolicitud.DataTextField = "Descripcion";
            //ddlEstatusSolicitud.DataValueField = "EstatusSolicitudId";
            //ddlEstatusSolicitud.DataBind();
        }


        protected int CargaIdCvedef(int pAnio)
        {
            int pIdCveDef = 0;
            pIdCveDef = NAdmiSol.NIdentificadorEjercicio(pAnio);
            return pIdCveDef;
        }


        protected void CargaListadoSolicitudes()
        {


            DateTime FechaInicial = Convert.ToDateTime(txtFechaInicio.Text);
            DateTime FechaFinal = Convert.ToDateTime(txtFechaFin.Text);

            String strEstatusSolicitud;
            String strTipoSolicitud;

            int intIdConcEstatussp;
            int IdTipoSolPago;


            if (chkSolicitudesTodas.Checked)
            {
                IdTipoSolPago = -1;
                intIdConcEstatussp = -1;
            }
            else
            {
                //intIdConcEstatussp = Convert.ToInt32(ddlEstatusSolicitud.SelectedValue);
                //IdTipoSolPago = Convert.ToInt32(ddlTipoSolicitud.SelectedValue);

            }


            //strTipoSolicitud = "<SolicitudPagoDTO><tiposolpago>" + Convert.ToString(IdTipoSolPago)  + "</tiposolpago></SolicitudPagoDTO>";
            //strEstatusSolicitud = "<SolicitudPagoDTO><concestatussp>" + Convert.ToString(intIdConcEstatussp) + "</concestatussp></SolicitudPagoDTO>";

            //int intNumeroSolicitud = 0;

            //String strNumeroSolicitud = txtNumSolicitud.Text.Trim();
            //int intRangoNumero;

            //if (!ValidaNumeroSolicitud(strNumeroSolicitud))
            //{
            //    intNumeroSolicitud = 0;
            //    intRangoNumero = 0;

            //}
            //else
            //{

            //    intNumeroSolicitud = Convert.ToInt32(strNumeroSolicitud);
            //    intRangoNumero = 1;
            //}


            //gvHistorialEstatusSolicitud.DataSource = null;
            //gvHistorialEstatusSolicitud.DataBind();

            pIdEjercicioPresupuestal = Convert.ToInt32( Session["IdEjercicioPresupuestal"]);
            IdUsuarioGlobal = Convert.ToInt32(Session["IdUsuario"]);

            //gvListadoSolicitudes.AutoGenerateSelectButton = true;
            //gvListadoSolicitudes.DataSource = NAdmiSol.NCargaListadoSolicitud(FechaInicial.ToString("yyyy-MM-dd"), FechaFinal.ToString("yyyy-MM-dd"), pIdEjercicioPresupuestal, 30, strTipoSolicitud, strEstatusSolicitud, intNumeroSolicitud, intNumeroSolicitud, intRangoNumero,1,IdUsuarioGlobal);
            //gvListadoSolicitudes.DataBind(); 

        }



        protected void CargaHistorialEstatusSolicitud(int pIdSolicitud)
        {
            //gvHistorialEstatusSolicitud.DataSource = NAdmiSol.NCargaHistorialEstatusSolicitud(pIdSolicitud);
            //gvHistorialEstatusSolicitud.DataBind();

        }








        public static Boolean ValidaNumeroSolicitud(String NumeroSolicitud)
        {
            string Numeros = "[0-9]";

            if (Regex.IsMatch(NumeroSolicitud, Numeros))
            {
                if (Regex.Replace(NumeroSolicitud, Numeros, String.Empty).Length == 0)
                { return true; }
                else
                { return false; }
            }
            else
            {
                return false;
            }
        }

        protected void gvListadoSolicitudes_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            //e.Row.Cells[3].Width = 400;
            //e.Row.Cells[4].Width = 400;
            //e.Row.Cells[5].Width = 400;
            //e.Row.Cells[6].Width = 400;
            

            switch (e.Row.RowType)
            {
               case DataControlRowType.Header:

                    //e.Row.Cells[0].Visible = false;
                    //e.Row.Cells[1].Visible = true;
                    //e.Row.Cells[2].Visible = true;
                    //e.Row.Cells[3].Visible = true;
                    //e.Row.Cells[4].Visible = true;
                    //e.Row.Cells[5].Visible = true;
                    //e.Row.Cells[6].Visible = true;
                    //e.Row.Cells[7].Visible = true;
                    //e.Row.Cells[8].Visible = true;
                    //e.Row.Cells[9].Visible = true;
                    //e.Row.Cells[10].Visible = false;
                    //e.Row.Cells[11].Visible = true;
                    //e.Row.Cells[12].Visible = false;
                    //e.Row.Cells[13].Visible = true;
                    //e.Row.Cells[14].Visible = false;
                    //e.Row.Cells[15].Visible = false;
                    //e.Row.Cells[16].Visible = false;
                    //e.Row.Cells[17].Visible = false;
                    //e.Row.Cells[18].Visible = false;




                    break;
                case DataControlRowType.DataRow:

                    //e.Row.Cells[0].Visible = false;
                    //e.Row.Cells[1].Visible = true;
                    //e.Row.Cells[2].Visible = true;
                    //e.Row.Cells[3].Visible = true;
                    //e.Row.Cells[4].Visible = true;
                    //e.Row.Cells[5].Visible = true;
                    //e.Row.Cells[6].Visible = true;
                    //e.Row.Cells[7].Visible = true;
                    //e.Row.Cells[8].Visible = true;
                    //e.Row.Cells[9].Visible = true;
                    //e.Row.Cells[10].Visible = false;
                    //e.Row.Cells[11].Visible = true;
                    //e.Row.Cells[12].Visible = false;
                    //e.Row.Cells[13].Visible = true;
                    //e.Row.Cells[14].Visible = false;
                    //e.Row.Cells[15].Visible = false;
                    //e.Row.Cells[16].Visible = false;
                    //e.Row.Cells[17].Visible = false;
                    //e.Row.Cells[18].Visible = false;










                    //e.Row.Cells[8].Text = Convert.ToDateTime(e.Row.Cells[8].Text).ToString("dd/MM/yyyy");
                    //e.Row.Cells[9].Text = string.Format("{0:c}", Convert.ToDecimal(e.Row.Cells[9].Text));



                    //e.Row.Cells[2].Width = 135;

                    //e.Row.Cells[2].Width = 135;
                    //e.Row.Cells[11].Width = 70;
                    //e.Row.Cells[1].Font.Bold = true;

                    break;


            }








        }

        

        protected void gvListadoSolicitudes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //NSelSolicitud.KeepSelection((GridView)sender);
            //gvListadoSolicitudes.PageIndex = e.NewPageIndex;
            CargaListadoSolicitudes();
        }

        protected void gvListadoSolicitudes_PageIndexChanged(object sender, EventArgs e)
        {
            //NSelSolicitud.RestoreSelection((GridView)sender);
        }

        protected void gvListadoSolicitudes_SelectedIndexChanged(object sender, EventArgs e)
        {

            //GridViewRow row = gvListadoSolicitudes.SelectedRow;

            ////
            //// Obtengo el id de la entidad que se esta editando
            //// en este caso de la entidad Person
            ////
            //int id = Convert.ToInt32(gvListadoSolicitudes.DataKeys[row.RowIndex].Value);

            //int id = Convert.ToInt32( gvListadoSolicitudes.SelectedRow.Cells[2].Text); 


            //CargaHistorialEstatusSolicitud(id);
        }

        protected void gvListadoSolicitudes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            

            
        }

     
        protected void btnNuevaSolicitud_Click(object sender, EventArgs e)
        {

            pIdEjercicioPresupuestal = CargaIdCvedef(2019);
            Session["IdEjercicioPresupuestal"] = pIdEjercicioPresupuestal;
            Response.Redirect("WebGeneraSolicitud.aspx");
               
        }

        

        protected void gvListadoSolicitudes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            switch (e.Row.RowType)
            {
                case DataControlRowType.Header:

                    //e.Row.Cells[0].Visible = false;
                    //e.Row.Cells[1].Visible = true;
                    //e.Row.Cells[2].Visible = false;
                    //e.Row.Cells[3].Visible = true;
                    //e.Row.Cells[4].Visible = true;
                    //e.Row.Cells[5].Visible = true;
                    //e.Row.Cells[6].Visible = true;
                    //e.Row.Cells[7].Visible = true;
                    //e.Row.Cells[8].Visible = true;
                    //e.Row.Cells[9].Visible = true;
                    //e.Row.Cells[10].Visible = false;
                    //e.Row.Cells[11].Visible = true;
                    //e.Row.Cells[12].Visible = false;
                    //e.Row.Cells[13].Visible = true;
                    //e.Row.Cells[14].Visible = false;
                    //e.Row.Cells[15].Visible = false;
                    //e.Row.Cells[16].Visible = false;
                    //e.Row.Cells[17].Visible = false;
                    //e.Row.Cells[18].Visible = false;




                    break;
                case DataControlRowType.DataRow:

                    //e.Row.Cells[0].Visible = false;
                    //e.Row.Cells[1].Visible = true;
                    //e.Row.Cells[2].Visible = false;
                    //e.Row.Cells[3].Visible = true;
                    //e.Row.Cells[4].Visible = true;
                    //e.Row.Cells[5].Visible = true;
                    //e.Row.Cells[6].Visible = true;
                    //e.Row.Cells[7].Visible = true;
                    //e.Row.Cells[8].Visible = true;
                    //e.Row.Cells[9].Visible = true;
                    //e.Row.Cells[10].Visible = false;
                    //e.Row.Cells[11].Visible = true;
                    //e.Row.Cells[12].Visible = false;
                    //e.Row.Cells[13].Visible = true;
                    //e.Row.Cells[14].Visible = false;
                    //e.Row.Cells[15].Visible = false;
                    //e.Row.Cells[16].Visible = false;
                    //e.Row.Cells[17].Visible = false;
                    //e.Row.Cells[18].Visible = false;










                    //e.Row.Cells[8].Text = Convert.ToDateTime(e.Row.Cells[8].Text).ToString("dd/MM/yyyy");
                    //e.Row.Cells[9].Text = string.Format("{0:c}", Convert.ToDecimal(e.Row.Cells[9].Text));



                    //e.Row.Cells[2].Width = 135;

                    //e.Row.Cells[2].Width = 135;
                    //e.Row.Cells[11].Width = 70;
                    //e.Row.Cells[1].Font.Bold = true;

                    break;


            }
        }



        protected void gvDetalleSolicitud_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            

            if (e.CommandName == "Select")
            {
                //
                // Se obtiene indice de la row seleccionada
                //
                int index = Convert.ToInt32(e.CommandArgument);

                //
                // Obtengo el id de la entidad que se esta editando
                // en este caso de la entidad Person
                //
                int id = Convert.ToInt32(gvDetalleSolicitud.DataKeys[index].Value);


                using (WebEpSIF.Model.ELECCIONES2021Entities1 db = new WebEpSIF.Model.ELECCIONES2021Entities1())
                {


                    db.Database.CommandTimeout = 0;
                    var oRegistroArchivo = db.RegistroArchivos.Find(id);
                    string path = AppDomain.CurrentDomain.BaseDirectory;
                    string folder = path + "/temp/";
                    string fullFilePath = folder + oRegistroArchivo.NombreArchivo;

                    if (!Directory.Exists(folder))
                        Directory.CreateDirectory(folder);

                    //if (File.Exists(fullFilePath))
                    //    Directory.Delete(fullFilePath);

                    File.WriteAllBytes(fullFilePath, oRegistroArchivo.Archivo);
                    System.Diagnostics.Process.Start(fullFilePath);

                }

            }
            if (e.CommandName == "Descarga")
            {
                //
                // Se obtiene indice de la row seleccionada
                //
                int index = Convert.ToInt32(e.CommandArgument);

                //
                // Obtengo el id de la entidad que se esta editando
                // en este caso de la entidad Person
                //
                int id = Convert.ToInt32(gvDetalleSolicitud.DataKeys[index].Value);


                using (WebEpSIF.Model.ELECCIONES2021Entities1 db = new WebEpSIF.Model.ELECCIONES2021Entities1())
                {


                    db.Database.CommandTimeout = 0;
                    var oRegistroArchivo = db.RegistroArchivos.Find(id);
                    float t = oRegistroArchivo.Archivo.Length;


                    //float rt = t / 8;
                    //int tt = Convert.ToInt32(rt);

                   

                    string path = AppDomain.CurrentDomain.BaseDirectory;
                    string folder = "C:/Evidencias/Camp2021/";
                    string fullFilePath = folder + oRegistroArchivo.NombreArchivo;

                    
                     


                    if (!Directory.Exists(folder))
                        Directory.CreateDirectory(folder);

                    //if (File.Exists(fullFilePath))
                    //    Directory.Delete(fullFilePath);

                  



                    File.WriteAllBytes(fullFilePath, oRegistroArchivo.Archivo);
                    //System.Diagnostics.Process.Start(fullFilePath);

                }

            }
        }





        protected void ddlEventoEspecifico_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlColectivaDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void onrowdeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            string id = gvDetalleSolicitud.DataKeys[index].Value.ToString();

            //DataTable dt1 = Session["DataTemp"] as DataTable;

            //DataRow[] rows = dt1.Select(string.Format("IdRegistro = {0}", id));

            //if (rows.Length > 0)
            //{
            //    dt1.Rows.Remove(rows[0]);
            //}

            //Session["DataTemp"] = dt1;

            //gvDetalleSolicitud.DataSource = dt1;
            //gvDetalleSolicitud.DataBind();
            //txtDisponibleClave.Text = "";
            //txtImporte.Text = "";
            //txtDisponibleDocumento.Text = "";




            //NAdmiSol.NBorraArchivo(Convert.ToInt32(id));

            //RefrescaGrid(0);

        }
        protected void ondatabound(object sender, GridViewRowEventArgs e)
        {
            switch (e.Row.RowType)
            {
                case DataControlRowType.Header:

                    e.Row.Cells[0].Visible = false;
                    e.Row.Cells[1].Visible = false;
                    e.Row.Cells[2].Visible = false;
                    e.Row.Cells[3].Visible = false;
                    e.Row.Cells[4].Visible = true;
                    e.Row.Cells[5].Visible = true;
                    e.Row.Cells[6].Visible = true;
                    e.Row.Cells[7].Visible = true;
                    e.Row.Cells[8].Visible = true;
                    e.Row.Cells[9].Visible = true;
                    e.Row.Cells[10].Visible = true;
                    //e.Row.Cells[11].Visible = false;
                    break;
                case DataControlRowType.DataRow:

                    e.Row.Cells[0].Visible = false;
                    e.Row.Cells[1].Visible = false;
                    e.Row.Cells[2].Visible = false;
                    e.Row.Cells[3].Visible = false;
                    e.Row.Cells[4].Visible = true;
                    e.Row.Cells[5].Visible = true;
                    e.Row.Cells[6].Visible = true;
                    e.Row.Cells[7].Visible = true;
                    e.Row.Cells[8].Visible = true;
                    e.Row.Cells[9].Visible = true;
                    e.Row.Cells[10].Visible = true;
                    //e.Row.Cells[11].Visible = false;
                    break;


            }

        }

        protected void gvDetalleSolicitud_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
        



        protected void txtFechaFin_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnActualiza_Click(object sender, EventArgs e)
        {
            RefrescaGrid(0);
        }

        protected void gvDetalleSolicitud_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvDetalleSolicitud_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDetalleSolicitud.PageIndex = e.NewPageIndex;
            RefrescaGrid(0);
        }

        protected void gvDetalleSolicitud_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnGetData_Click(object sender, EventArgs e)
        {

        }

       

        protected void Button1_Click1(object sender, EventArgs e)
        {
            
        }

        protected void btnOtrosEstatus_Click(object sender, EventArgs e)
        {

        }
    }
}