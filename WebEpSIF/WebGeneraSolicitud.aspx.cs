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
    public partial class WebGeneraSolicitud : System.Web.UI.Page
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




                    pIdEvento = Convert.ToInt32(Session["IdEvento"]);
                    pIdDependencia = Convert.ToInt32(Session["IdDependencia"]);
                    pIdEjercicioPresupuestal = Convert.ToInt32(Session["IdEjercicioPresupuestal"]);
                    //IdUsuarioGlobal = Convert.ToInt32(Session["IdUsuario"]);
                    IdColectiva = Convert.ToInt32(Session["IdColectiva"]);
                    strTipoOperacio = Convert.ToString(Session["TipoOperacion"]);


                    IDUSUARIOCAPTURA .Text =  Session["IdUsuario"].ToString();

                    USUARIOCAPTURA.Text = Session["UsuarioMapeado"].ToString ();

                   


                    if ((Session["IdUsuario"] == null )| (IDUSUARIOCAPTURA.Text==""))
                    {
                        Response.Redirect("WebLogin.aspx");
                    }
                    else
                    {
                        IdUsuarioGlobal = Convert.ToInt32(IDUSUARIOCAPTURA.Text);
                        ViewState["IdUsuarioGlobal"] = IdUsuarioGlobal;

                    }












                    if (strTipoOperacio == "Nuevo")

                    {





                        IdUsuarioGlobal = Convert.ToInt32(IDUSUARIOCAPTURA.Text);
                        IDAGRUPADOR.Text = Session["IdRegistroMatriz"].ToString();
                        if (Session["IdRegistroMatriz"] == null)
                        {
                            Response.Redirect("WebCapturaDocumentos.aspx");
                        }
                        else
                        {

                            pIdRegistroMatriz = Convert.ToInt32 ( IDAGRUPADOR.Text);
                        }

                        LabelEtiquetaAgrupador.Visible = true;
                        LabelAgrupador.Visible = true;



                        dt = NAdmiSol.NCargaAgrupador(pIdRegistroMatriz, IdUsuarioGlobal);
                        dt.Rows[0]["Agrupador"].ToString();
                        strAgrupador = strAgrupador = dt.Rows[0]["Agrupador"].ToString();
                        LabelAgrupador.Text = strAgrupador.Substring(0, 25);
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


                        CargaDocumento(gIdEvento, gIdConcepto, gIdCandidato);


                        ddlPeriodo.Enabled = false;
                        ddlColectivaDetalle.Enabled = false;
                        ddlEventoEspecifico.Enabled = false;
                        ddlDistrito.Enabled = false;
                        ddlCandidato.Enabled = false;
                        ddlTipoGasto.Enabled = false;
                        ddlConcepto.Enabled = false;
                        //ddlDocumento.Enabled = false;
                        RefrescaGrid(0);

                    }
                    gRegistroInsertado = false;
                    if (strTipoOperacio == "Editar")

                    {


                        IDAGRUPADOR.Text = Session["IdRegistroMatriz"].ToString();
                        IdUsuarioGlobal = Convert.ToInt32(IDUSUARIOCAPTURA.Text  );

                        if (Session["IdRegistroMatriz"] == null)
                        {
                            Response.Redirect("WebCapturaDocumentos.aspx");
                        }
                        else
                        {

                            pIdRegistroMatriz = Convert.ToInt32 (IDAGRUPADOR.Text);
                        }


                        LabelEtiquetaAgrupador.Visible = true;
                        LabelAgrupador.Visible = true;
                        dt = NAdmiSol.NCargaAgrupador(pIdRegistroMatriz, IdUsuarioGlobal);
                        strAgrupador = dt.Rows[0]["Agrupador"].ToString();




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
                        ddlPeriodo.Enabled = false;
                        ddlColectivaDetalle.Enabled = false;
                        ddlEventoEspecifico.Enabled = false;
                        ddlDistrito.Enabled = false;
                        ddlCandidato.Enabled = false;
                        ddlTipoGasto.Enabled = false;
                        ddlConcepto.Enabled = false;
                        //ddlDocumento.Enabled = false;

                        CargaDocumento(gIdEvento, gIdConcepto, gIdCandidato);
                        RefrescaGrid(pIdRegistroMatriz);

                    }






                    if (strTipoOperacio == "NuevoAgrupador")

                    {
                        IdUsuarioGlobal = Convert.ToInt32( ViewState["IdUsuarioGlobal"]);
                        LabelEtiquetaAgrupador.Visible = false;
                        LabelAgrupador.Visible = false;
                        CargaColectivaDetalle(IdUsuarioGlobal);
                        //CargaTipoDocumento();
                        CargaPeriodo();
                        RefrescaGrid(0);
                        //Label8.Visible = false;
                        //TextBoxCapturado.Visible = false;
                        Label6.Visible = false;
                        Label7.Visible = false;
                        //TextBoxDisponible.Visible = false;
                        txtImporte.Visible = false;
                        //gEsPptal = 0;
                        //gDisponible = 0;
                        //gImporteAgrupador = 0;

                    }




                }






            }





            catch (Exception ex)
            {
                //Response.Redirect("Error.aspx"); 
            }

        }





        protected void CargaDistrito(int pIdCandidatura, int pIdEstado, int pIdUsuario)
        {

            ddlDistrito.DataSource = NAdmiSol.NCargaDistrito(pIdCandidatura, pIdEstado, pIdUsuario);
            ddlDistrito.DataTextField = "Distrito";
            ddlDistrito.DataValueField = "IdDistrito";
            ddlDistrito.DataBind();
            ddlDistrito.Items.Insert(0, new ListItem("[SELECCIONAR EL DISTRITO...]", "0"));



        }

        protected void CargaCandidato(int pIdCandidatura, int pIdEstado, int pIDdistrito, int IdUsuario)
        {

            ddlCandidato.DataSource = NAdmiSol.NCargaCandidato(pIdCandidatura, pIdEstado, pIDdistrito, IdUsuario);
            ddlCandidato.DataTextField = "Candidato";
            ddlCandidato.DataValueField = "IdCandidato";
            ddlCandidato.DataBind();
            ddlCandidato.Items.Insert(0, new ListItem("[SELECCIONAR EL CANDIDATO...]", "0"));



        }


        protected void CargaEvento(int pIdConcepto, int IdCandidato)
        {

            ddlConcepto.DataSource = NAdmiSol.NCargaEvento(pIdConcepto, IdCandidato);
            ddlConcepto.DataTextField = "Evento";
            ddlConcepto.DataValueField = "IdEvento";
            ddlConcepto.DataBind();
            ddlConcepto.Items.Insert(0, new ListItem("[SELECCIONAR EL CONCEPTO...]", "0"));



        }

        protected void CargaDocumento(int pIdevento, int IdConcepto, int IdCandidato)
        {

            ddlDocumento.DataSource = NAdmiSol.NCargaDocumento(pIdevento, IdConcepto, IdCandidato);
            ddlDocumento.DataTextField = "Documento";
            ddlDocumento.DataValueField = "IdDocumento";
            ddlDocumento.DataBind();
            ddlDocumento.Items.Insert(0, new ListItem("[SELECCIONAR EL DOCUMENTO...]", "0"));



        }

        protected void CargaConcepto(int pIdCandidato)
        {

            ddlTipoGasto.DataSource = NAdmiSol.NCargaConcepto(pIdCandidato);
            ddlTipoGasto.DataTextField = "Concepto";
            ddlTipoGasto.DataValueField = "IdConcepto";
            ddlTipoGasto.DataBind();
            ddlTipoGasto.Items.Insert(0, new ListItem("[SELECCIONAR EL CONCEPTO...]", "0"));



        }

        protected void CargaEventoEspecifico(int pIdEvento, int pIdDependencia, int pIEjercicioPresupuestal, int pIdUsuario, int pIdCandidatura)
        {




            ddlEventoEspecifico.DataSource = NAdmiSol.NCargaEventoEspecifico(pIdUsuario, pIdCandidatura);
            ddlEventoEspecifico.DataTextField = "Estado";
            ddlEventoEspecifico.DataValueField = "IdEstado";
            ddlEventoEspecifico.DataBind();
            ddlEventoEspecifico.Items.Insert(0, new ListItem("[SELECCIONAR EL ESTADO...]", "0"));



        }








        private DataTable TablaDetalle()
        {
            DataTable DetalleSolicitud = new DataTable();
            DetalleSolicitud.Columns.Add("IdRegistro", typeof(Int32));
            DetalleSolicitud.Columns.Add("IdEstado", typeof(Int32));
            DetalleSolicitud.Columns.Add("IdNivel", typeof(Int32));
            DetalleSolicitud.Columns.Add("IdTipoGasto", typeof(Int32));

            DetalleSolicitud.Columns.Add("Estado", typeof(string));
            DetalleSolicitud.Columns.Add("Nivel", typeof(string));
            DetalleSolicitud.Columns.Add("TipoGasto", typeof(string));
            DetalleSolicitud.Columns.Add("Archivo", typeof(string));
            return DetalleSolicitud;
        }





        protected void CargaTipoDocumento()
        {

            ddlConcepto.DataSource = NAdmiSol.NCargaTipoDocumento();
            ddlConcepto.DataTextField = "DescripcionTipoGasto";
            ddlConcepto.DataValueField = "idtipogasto";
            ddlConcepto.DataBind();
            ddlConcepto.Items.Insert(0, new ListItem("[SELECCIONAR EL TIPO DE GASTO...]", "0"));



        }


        protected void CargaPeriodo()
        {

            ddlPeriodo.DataSource = NAdmiSol.NCargaPeriodo();
            ddlPeriodo.DataTextField = "Periodo";
            ddlPeriodo.DataValueField = "idperiodo";
            ddlPeriodo.DataBind();
            ddlPeriodo.Items.Insert(0, new ListItem("[SELECCIONAR EL PERIODO...]", "0"));



        }












        void RefrescaGrid(int IdRegistroMatrizCapturados)
        {



            gvDetalleSolicitud.DataSource = null;
            gvDetalleSolicitud.DataBind();
            IdUsuarioGlobal = Convert.ToInt32(Session["IdUsuario"]);
            
              

            //gvDetalleSolicitud.AutoGenerateSelectButton = true;
            gvDetalleSolicitud.DataSource = NAdmiSol.NCargaListadoDocumentos(0, 0, 0, DateTime.Today.ToString("yyyy-MM-dd"), DateTime.Today.ToString("yyyy-MM-dd"), IdUsuarioGlobal, IdRegistroMatrizCapturados);
            gvDetalleSolicitud.DataBind();

        }

        void AgregaRegistroDetalle(string EsPresupuestal, string EsConDocumento)
        {





            ViewState["n"] = n;
            n = Convert.ToInt32(ViewState["n"]) + 1;
            //ImporteCapturado = Convert.ToDecimal(txtImporte.Text);
            //ImporteDocumentoCapturado = Convert.ToDecimal(txtImporte.Text);

            Session["DataTemp"] = dt;
            dr = dt.NewRow();
            dr[0] = n;


            dr[1] = Convert.ToInt32(ddlEventoEspecifico.SelectedValue);
            dr[2] = Convert.ToInt32(ddlColectivaDetalle.SelectedValue);
            dr[3] = Convert.ToInt32(ddlConcepto.SelectedValue);


            dr[4] = ddlEventoEspecifico.SelectedItem.Text;
            dr[5] = ddlColectivaDetalle.SelectedItem.Text;
            dr[6] = ddlConcepto.SelectedItem.Text;
            dr[7] = FileUploadEstados.FileName;



            //    dr[3] = ddlEventoEspecifico.SelectedItem.Text;
            //    if (EsPresupuestal =="1")

            //    {
            //        //dr[1] = Convert.ToInt32(ddlClavePresupuestal.SelectedValue);
            //        //dr[4] = ddlClavePresupuestal.SelectedItem.Text;
            //    dr[9] = 1;
            //    }
            //    else
            //    {
            //        dr[1] = 0;
            //        dr[4] = "";
            //    dr[9] = 0;
            //}

            //    if (EsConDocumento =="1")
            //    {
            //         //dr[2] = Convert.ToInt32(ddlDocumento.SelectedValue);
            //         //dr[5] = ddlDocumento.SelectedItem.Text;
            //         dr[7] = ImporteDocumentoCapturado;
            //    }
            //    else
            //    {
            //        dr[2] = 0;
            //        dr[5] = "";
            //        dr[7] = 0;
            //    }

            //dr[6] = ImporteCapturado;
            //dr[8] = Convert.ToInt32(Session["IdSolicitud"]);
            //dr[10] = Convert.ToInt32(ddlEventoEspecifico.SelectedValue);
            //dr[11] = Convert.ToInt32(ddlColectivaDetalle.SelectedValue);

            dt.Rows.Add(dr);

            Session["DataTemp"] = dt;




            //DateTime dd = DateTime.Now;
            //int pMes = Convert.ToInt32(dd.Month);

            //if (EsPresupuestal == "1")
            //{

            //    //ImporteCapturado = Convert.ToDecimal(ImporteCapturadoClave(Convert.ToInt32(ddlClavePresupuestal.SelectedValue)));
            //    //DisponibleEnclavePresupuestal = DisponibleConsultado - ImporteCapturado;

            //   // txtDisponibleClave.Text = string.Format("{0,0:c}", DisponibleConsultado - ImporteCapturado);

            //}
            // DisponibleDocumento = NAdmiSol.fnExtenciones(Convert.ToInt32(ddlDocumento.SelectedValue));
            //else
            //{
            //    DisponibleConsultado = 0;
            //    ImporteCapturado = 0;
            //   // txtDisponibleClave.Text = "";

            //}
            //if (EsConDocumento == "1")
            //{
            //    //DisponibleDocumento = NAdmiSol.NConsultaDisponibleDocumento(Convert.ToInt32(ddlDocumento.SelectedValue));
            //    //ImporteDocumentoCapturado = Convert.ToDecimal(ImporteCapturadoDocumento(Convert.ToInt32(ddlDocumento.SelectedValue)));
            //    DisponibleEnDocumento = DisponibleDocumento - ImporteDocumentoCapturado;

            //    //txtDisponibleDocumento.Text = string.Format("{0,0:c}", (DisponibleDocumento - ImporteDocumentoCapturado));


            //}
            //else
            //{
            //    DisponibleDocumento =0;
            //    DisponibleEnDocumento = 0;
            //    ImporteDocumentoCapturado = 0;
            //    //txtDisponibleDocumento.Text = "";
            //}



            this.gvDetalleSolicitud.DataSource = Session["DataTemp"];
            this.gvDetalleSolicitud.DataBind();

        }



        //static DataTable GetDataTableFromCsv(string path, bool isFirstRowHeader)
        //{
        //    string header = isFirstRowHeader ? "Yes" : "No";

        //    string pathOnly = Path.GetDirectoryName( @"C:/Evidencias/"); 


        //    string fileName = Path.GetFileName(path);




        //    string sql = @"SELECT * FROM [" + fileName + "]";

        //    using (OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathOnly)) 

        //    //using (OleDbConnection connection = new OleDbConnection(
        //    //       @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + "C:/Evidencias/" +
        //    //       ";Extended Properties=\"Text;HDR=" + header + "\""))




        //    using (OleDbCommand command = new OleDbCommand(sql, connection))
        //    using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
        //    {
        //        DataTable dataTable = new DataTable();
        //        //dataTable.Locale = CultureInfo.CurrentCulture;
        //        adapter.Fill(dataTable);
        //        return dataTable;
        //    }
        //}

        protected void btnAgregar_Click(object sender, EventArgs e)
        {


            if (!FileUploadEstados.HasFiles)
            {

                Response.Write("<script language=javascript>");
                Response.Write("alert('Archivo no Válido...')");
                Response.Write("</script>");
                return;
            }

            if (FileUploadEstados.FileName == "")
            {

                Response.Write("<script language=javascript>");
                Response.Write("alert('Favor de seleccionar el archivo...')");
                Response.Write("</script>");
                return;
            }



            int pIdMatrizEncabezado = 0;

            if (FileUploadEstados.HasFiles)
            {
                foreach (HttpPostedFile uploadedFile in FileUploadEstados.PostedFiles)
                {


                    if (FileUploadEstados.HasFiles)
                    {
                        // Get the name of the file to upload.
                        string strArchivo = Server.HtmlEncode(uploadedFile.FileName);

                        // Get the extension of the uploaded file.
                        string strExtension = System.IO.Path.GetExtension(strArchivo);

                        if (!(lblExtensiones.Text == "") | !(lblExtensiones.Text == null))
                        {

                            strDocumentoExtensiones = lblExtensiones.Text;
                        }
                        else
                        {
                            strDocumentoExtensiones = "NNNNNNNN";
                        }

                        bool AplicaExtencion = strDocumentoExtensiones.Contains(strExtension.ToUpper());


                         


                        // Allow only files with .doc or .xls extensions
                        // to be uploaded.
                        if ((AplicaExtencion == false))

                        {

                            Response.Write("<script language=javascript>");
                            Response.Write("alert('Extensión de archivo incorrecta, favor de seleccionar el archivo con la extensión según el tipo de documento...')");
                            Response.Write("</script>");
                            return;



                        }
                    }

                    if (FileUploadEstados.HasFiles)
                    {
                        // Get the name of the file to upload.
                        string strArchivo = Server.HtmlEncode(uploadedFile.FileName);

                        // Get the extension of the uploaded file.
                        string strExtension = System.IO.Path.GetExtension(strArchivo);




                        // Allow only files with .doc or .xls extensions
                        // to be uploaded.


                        if ((strExtension == ".xml"))

                        {
                            XmlDocument CFDI = new XmlDocument();
                            //CFDI.Load(FileUploadEstados.FileContent);
                            //CFDI.Load(uploadedFile.ContentType);
                            CFDI.Load(uploadedFile.InputStream);
                            XmlNode nodoEmisor = CFDI.GetElementsByTagName("cfdi:Emisor").Item(0);
                            string valorRFCEmisor = nodoEmisor.Attributes.GetNamedItem("Rfc").Value;

                            XmlNode nodoReceptor = CFDI.GetElementsByTagName("cfdi:Receptor").Item(0);
                            string valorRFCReceptor = nodoReceptor.Attributes.GetNamedItem("Rfc").Value;

                            XmlNode nodoUUID = CFDI.GetElementsByTagName("tfd:TimbreFiscalDigital").Item(0);
                            string valorUUID = nodoUUID.Attributes.GetNamedItem("UUID").Value;

                            XmlNode nodoConcepto = CFDI.GetElementsByTagName("cfdi:Comprobante").Item(0);
                            string valorImporte = nodoConcepto.Attributes.GetNamedItem("Total").Value;

                            Status status = new Status("https://consultaqr.facturaelectronica.sat.gob.mx/ConsultaCFDIService.svc");
                            Acuse response = status.GetStatusCFDI(valorRFCEmisor, valorRFCReceptor, Convert.ToString(valorImporte), valorUUID);
                            //Console.WriteLine(response.CodigoEstatus);
                            //Console.WriteLine(response.Estado);
                            //Console.WriteLine(response.EsCancelable);
                            //Console.WriteLine(response.EstatusCancelacion);
                            //Console.ReadLine();

                            if (response.Estado == "Cancelado")
                            {

                                //Response.Write("<script language=javascript>");
                                //Response.Write("alert('El estatus del CFDI en SAT es Cancelado...')");
                                //Response.Write("</script>");

                                ClientScript.RegisterStartupScript(typeof(Page), "script", "alertMessageCancelado('" + strArchivo + "');", true);

                                return;
                            }

                            if (response.Estado == "No Encontrado")
                            {
                                //Response.Write("<script language=javascript>");
                                //Response.Write("alert('El estatus del CFDI en SAT es No Encontrado...')");
                                //Response.Write("</script>");

                                ClientScript.RegisterStartupScript(typeof(Page), "script", "alertMessageNoEncontrado('" + strArchivo + "');", true);




                                return;
                            }







                            string strEstatusRFCSAT = NAdmiSol.NCargaEstatusRFCSAT(valorRFCEmisor);

                            if (!String.IsNullOrEmpty(strEstatusRFCSAT))
                            {


                                if (strEstatusRFCSAT == "Definitivo")
                                {

                                    //Response.Write("<script language=javascript>");
                                    //Response.Write("alert('El estatus del CFDI en SAT es Cancelado...')");
                                    //Response.Write("</script>");

                                    ClientScript.RegisterStartupScript(typeof(Page), "script", "alertMessageDefinitivo('" + strEstatusRFCSAT + "');", true);

                                    return;
                                }

                                if (strEstatusRFCSAT == "Presunto")
                                {

                                    //Response.Write("<script language=javascript>");
                                    //Response.Write("alert('El estatus del CFDI en SAT es Cancelado...')");
                                    //Response.Write("</script>");

                                    ClientScript.RegisterStartupScript(typeof(Page), "script", "alertMessagePresunto('" + strEstatusRFCSAT + "');", true);

                                    return;
                                }

                            }

                        }



                    }

                }
            }













            DataTable ArchivoUsuario = new DataTable();

            ArchivoUsuario.Columns.Add("IdEstado", typeof(Int32));
            ArchivoUsuario.Columns.Add("IdNivel", typeof(Int32));
            ArchivoUsuario.Columns.Add("IdPeriodo", typeof(Int32));
            ArchivoUsuario.Columns.Add("IdRegistroMatriz", typeof(Int32));
            ArchivoUsuario.Columns.Add("NombreArchivo", typeof(string));
            ArchivoUsuario.Columns.Add("Archivo", typeof(Byte[]));
            ArchivoUsuario.Columns.Add("IdConcepto", typeof(Int32));
            ArchivoUsuario.Columns.Add("baja", typeof(Int32));
            ArchivoUsuario.Columns.Add("IdUsuarioweb", typeof(Int32));
            ArchivoUsuario.Columns.Add("idevento", typeof(Int32));
            ArchivoUsuario.Columns.Add("iddocumento", typeof(Int32));

            string strAgrupadorInserta = "";

            foreach (HttpPostedFile uploadedFile in FileUploadEstados.PostedFiles)
            {



                if ((strTipoOperacio == "Nuevo") | (strTipoOperacio == "Editar"))

                {
                    dt = null;
                    pIdRegistroMatriz = Convert.ToInt32(IDAGRUPADOR.Text);
                    
                    if ((IDUSUARIOCAPTURA.Text == "") | (IDUSUARIOCAPTURA.Text == null))
                    {
                        Response.Redirect("WebLogin.aspx");

                    }
                    else
                    {
                        IdUsuarioGlobal = Convert.ToInt32(IDUSUARIOCAPTURA.Text);
                    }


                    if ((IDAGRUPADOR.Text == "") | (IDAGRUPADOR.Text == null))
                    {
                        Response.Redirect("WebLogin.aspx");

                    }



                    dt = NAdmiSol.NCargaAgrupador(Convert.ToInt32(IDAGRUPADOR.Text), Convert.ToInt32(IDUSUARIOCAPTURA.Text));
                    strAgrupadorInserta = dt.Rows[0]["Agrupador"].ToString();
                    gIdNivel = Convert.ToInt32(dt.Rows[0]["IdNivel"].ToString());
                    gIdEstado = Convert.ToInt32(dt.Rows[0]["IdEstado"].ToString());
                    gIdDistrito = Convert.ToInt32(dt.Rows[0]["IdDistrito"].ToString());
                    gIdCandidato = Convert.ToInt32(dt.Rows[0]["IdCandidato"].ToString());
                    gIdConcepto = Convert.ToInt32(dt.Rows[0]["IdConcepto"].ToString());
                    gIdEvento = Convert.ToInt32(dt.Rows[0]["IdEvento"].ToString());
                    gIdPeriodo = Convert.ToInt32(dt.Rows[0]["IdPeriodo"].ToString());
                    gIdDocumento = Convert.ToInt32(ddlDocumento.SelectedValue);

                    ViewState["gIdNivel"] = gIdNivel;
                    ViewState["gIdEstado"] = gIdEstado;
                    ViewState["gIdDistrito"] = gIdDistrito;
                    ViewState["gIdCandidato"] = gIdCandidato;
                    ViewState["gIdConcepto"] = gIdConcepto;
                    ViewState["gIdEvento"] = gIdEvento;
                    ViewState["gIdPeriodo"] = gIdPeriodo;
                    ViewState["gIdDocumento"] = gIdDocumento;

                    if (strTipoOperacio == "Nuevo")
                    {

                        pIdRegistroMatriz = Convert.ToInt32(IDAGRUPADOR.Text);
                       

                        if ((IDUSUARIOCAPTURA.Text == "") | (IDUSUARIOCAPTURA.Text == null))
                        {
                            Response.Redirect("WebLogin.aspx");

                        }
                        else
                        {
                            IdUsuarioGlobal = Convert.ToInt32(IDUSUARIOCAPTURA.Text);
                        }





                        strAgrupadorInserta = strAgrupadorInserta.Substring(0,25) ;

                    }
                    pIdRegistroMatriz = Convert.ToInt32(IDAGRUPADOR.Text);
                   


                    if ((IDUSUARIOCAPTURA.Text == "") | (IDUSUARIOCAPTURA.Text == null))
                    {
                        Response.Redirect("WebLogin.aspx");

                    }
                    else
                    {
                        IdUsuarioGlobal = Convert.ToInt32(IDUSUARIOCAPTURA.Text);
                    }





                    ViewState["strAgrupadorInserta"] = strAgrupadorInserta;
                    
                   


                }

                else

                {
                    pIdRegistroMatriz = 0;


                    if ((IDUSUARIOCAPTURA.Text == "")|(IDUSUARIOCAPTURA.Text==null))
                    {
                        Response.Redirect("WebLogin.aspx");

                    }
                    else
                    {
                        IdUsuarioGlobal = Convert.ToInt32(IDUSUARIOCAPTURA.Text);
                    }
                    

                    gIdNivel = Convert.ToInt32(ddlColectivaDetalle.SelectedValue);
                    gIdEstado = Convert.ToInt32(ddlEventoEspecifico.SelectedValue);
                    gIdDistrito = Convert.ToInt32(ddlDistrito.SelectedValue);
                    gIdCandidato = Convert.ToInt32(ddlCandidato.SelectedValue);
                    gIdConcepto = Convert.ToInt32(ddlTipoGasto.SelectedValue);
                    gIdEvento = Convert.ToInt32(ddlConcepto.SelectedValue);
                    gIdDocumento = Convert.ToInt32(ddlDocumento.SelectedValue);
                    gIdPeriodo = Convert.ToInt32(ddlPeriodo.SelectedValue);

                    ViewState["gIdNivel"] = gIdNivel;
                    ViewState["gIdEstado"] = gIdEstado;
                    ViewState["gIdDistrito"] = gIdDistrito;
                    ViewState["gIdCandidato"] = gIdCandidato;
                    ViewState["gIdConcepto"] = gIdConcepto;
                    ViewState["gIdEvento"] = gIdEvento;
                    ViewState["gIdPeriodo"] = gIdPeriodo;
                    ViewState["gIdDocumento"] = gIdDocumento;
                    ViewState["strAgrupadorInserta"] = "N";


                }

               

                Stream fs =  uploadedFile.InputStream;
                //Stream fs = FileUploadEstados.PostedFile.InputStream;

                BinaryReader br = new BinaryReader(fs);

                Byte[] bytes = br.ReadBytes((Int32)fs.Length);







                DataRow row = ArchivoUsuario.NewRow();



                gIdNivel =   Convert.ToInt32(ViewState["gIdNivel"]) ;
                gIdEstado = Convert.ToInt32(ViewState["gIdEstado"]) ;
                gIdDistrito = Convert.ToInt32(ViewState["gIdDistrito"]) ;
                gIdCandidato = Convert.ToInt32(ViewState["gIdCandidato"]) ;
                gIdConcepto = Convert.ToInt32(ViewState["gIdConcepto"]) ;
                gIdEvento = Convert.ToInt32(ViewState["gIdEvento"]) ;
                gIdPeriodo = Convert.ToInt32(ViewState["gIdPeriodo"]) ;
                gIdDocumento = Convert.ToInt32(ViewState["gIdDocumento"]) ;

             
                IdUsuarioGlobal = Convert.ToInt32(IDUSUARIOCAPTURA.Text);

                strAgrupadorInserta = ViewState["strAgrupadorInserta"].ToString() ;
                row["IdEstado"] = gIdEstado;
                row["IdNivel"] = gIdNivel;
                row["IdPeriodo"] = gIdPeriodo;
                row["IdRegistroMatriz"] = pIdMatrizEncabezado;
                row["NombreArchivo"] = uploadedFile.FileName;
                row["Archivo"] = bytes;
                row["IdConcepto"] = gIdConcepto;
                row["baja"] = 0;
                row["IdUsuarioweb"] = Convert.ToInt32(IDUSUARIOCAPTURA.Text); 
                row["idevento"] = gIdEvento;
                row["iddocumento"] = gIdDocumento;
                ArchivoUsuario.Rows.Add(row);
                

            }


            IdUsuarioGlobal  = Convert.ToInt32(IDUSUARIOCAPTURA.Text);
            if ((strTipoOperacio == "Nuevo") | (strTipoOperacio == "Editar"))

            {

               pIdRegistroMatriz = Convert.ToInt32(IDAGRUPADOR.Text);
            }
            else
            {
                pIdRegistroMatriz = 0;
            }
            ViewState["pIdRegistroMatrizRegistros"] = pIdRegistroMatriz;
            pIdMatrizEncabezado = NAdmiSol.NInsertaEncabezadoMatriz(    pIdRegistroMatriz,
                                                                            Convert.ToInt32(IDUSUARIOCAPTURA.Text),
                                                                            gIdPeriodo,
                                                                            gIdNivel,
                                                                            gIdEstado,
                                                                            gIdDistrito,
                                                                            gIdCandidato,
                                                                            gIdConcepto,
                                                                            gIdEvento,
                                                                            gIdDocumento,
                                                                            strAgrupadorInserta,
                                                                            gImporte,
                                                                            ArchivoUsuario);





           

            for (int i = 0; i < gvDetalleSolicitud.Rows.Count; i++)
            {


                CheckBox chkdescarga = (CheckBox)gvDetalleSolicitud.Rows[i].Cells[0].FindControl("chbItem");

                if (chkdescarga.Checked)

                {

                    int id = Convert.ToInt32(gvDetalleSolicitud.Rows[i].Cells[1].Text);
                    ViewState["IdRegistroSustituye"] = id;
                    int IdSustituye = Convert.ToInt32(ViewState["IdRegistroSustituye"]);
                    int IdUsuarioSustituye = Convert.ToInt32(IDUSUARIOCAPTURA.Text);
                    NAdmiSol.NSustituirArchivo(Convert.ToInt32(IdSustituye), IdUsuarioSustituye);
                }

            }
            Response.Write("<script language=javascript>");
            Response.Write("alert('Carga procesada satisfactoriamente...')");
            Response.Write("</script>");


            ddlPeriodo.Enabled = false;
            ddlColectivaDetalle.Enabled = false;
            ddlEventoEspecifico.Enabled = false;
            ddlDistrito.Enabled = false;
            ddlCandidato.Enabled = false;
            ddlTipoGasto.Enabled = false;
            ddlConcepto.Enabled = false;



            int IdRegistroMatrizInsertaArchivo = 0;
            IdRegistroMatrizInsertaArchivo = Convert.ToInt32(ViewState["pIdRegistroMatrizRegistros"]);
            
            
            RefrescaGrid(IdRegistroMatrizInsertaArchivo);


        

        }

    
        public void CargarDatos(string strm)
        {
            DataTable tabla = null;
            StreamReader lector = new StreamReader(strm);
            String fila = String.Empty;
            Int32 cantidad = 0;
            do
            {
                fila = lector.ReadLine();
                if (fila == null)
                {
                    break;
                }
                if (0 == cantidad++)
                {
                    tabla = this.CrearTabla(fila);
                }
                this.AgregarFila(fila, tabla);
            } while (true);
            dt = tabla;


        }


        private DataRow AgregarFila(String fila, DataTable tabla)
        {
            int cantidadColumnas = 100;
            String[] valores = fila.Split(new char[] { ',' });
            Int32 numeroTotalValores = valores.Length;
            if (numeroTotalValores > cantidadColumnas)
            {
                Int32 diferencia = numeroTotalValores - cantidadColumnas;
                for (Int32 i = 0; i < diferencia; i++)
                {

                    String nombreColumna = String.Format("{0}", (cantidadColumnas + i));
                    tabla.Columns.Add(nombreColumna, Type.GetType("System.String"));
                }
                cantidadColumnas = numeroTotalValores;
            }
            int idx = 0;
            DataRow dfila = tabla.NewRow();
            foreach (String val in valores)
            {
                String nombreColumna = String.Format("{0}", idx++);
                dfila[nombreColumna] = val.Trim();
            }
            tabla.Rows.Add(dfila);
            return dfila;
        }
        private DataTable CrearTabla(String fila)
        {
            int cantidadColumnas;
            DataTable tabla = new DataTable("Datos");
            String[] valores = fila.Split(new char[] { ',' });
            cantidadColumnas = valores.Length;
            int idx = 0;
            foreach (String val in valores)
            {
                String nombreColumna = String.Format("{0}", idx++);
                tabla.Columns.Add(nombreColumna, Type.GetType("System.String"));
            }
            return tabla;
        }







        protected void ddlPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {




        }

        

            protected void ddlCandidato_SelectedIndexChanged(object sender, EventArgs e)
        {

            CargaConcepto( Convert.ToInt32(ddlCandidato.SelectedValue));

        }


        



        protected void ddlColectivaDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {

            IdCandidatura = Convert.ToInt32(ddlColectivaDetalle.SelectedValue);
            int IdUsuarioEstado = 0;

            if (IDUSUARIOCAPTURA.Text == "")
            {
                Response.Redirect("WebLogin.aspx");
            }
            else
            {
                 IdUsuarioEstado = Convert.ToInt32(IDUSUARIOCAPTURA.Text);

            }
           
            CargaEventoEspecifico(0, 0, 0, IdUsuarioEstado, IdCandidatura); 

        }



        protected void CargaColectivaDetalle(int pIdUsuario)
        {


            ddlColectivaDetalle.DataSource = NAdmiSol.NCargaColectivaEventoEspecifico(pIdUsuario);
            ddlColectivaDetalle.DataTextField = "DescripcionNivel";
            ddlColectivaDetalle.DataValueField = "Idnivel";
            ddlColectivaDetalle.DataBind();
            ddlColectivaDetalle.Items.Insert(0, new ListItem("[SELECCIONAR EL NIVEL...]", "0"));


        }

        


        protected void cvTipoDocumento_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int IdTipoDocumento;
            IdTipoDocumento = Convert.ToInt32(ddlConcepto.SelectedValue);

            string ConDocumento = Convert.ToString(Session["ConDocumento"]);

           
                if (IdTipoDocumento == 0)

                {

                    args.IsValid = false;


                }
                else
                {
                    args.IsValid = true;
                }

            }


        protected void cvPeriodo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int IdPeriodo;
            IdPeriodo = Convert.ToInt32(ddlPeriodo .SelectedValue);

            IdPeriodo = 0;

            if (IdPeriodo == 0)

            {

                args.IsValid = false;


            }
            else
            {
                args.IsValid = true;
            }

        }




        protected void cvColectivaDetalle_ServerValidate(object source, ServerValidateEventArgs args)
        {

            int IdColectivaDetalle;
            IdColectivaDetalle = Convert.ToInt32(ddlColectivaDetalle.SelectedValue);

            

            
                if (IdColectivaDetalle == 0)

                {

                    args.IsValid = false;


                }
                else
                {
                    args.IsValid = true;
                }

           



        }

        
        protected void btnGuardarDetalle_Click(object sender, EventArgs e)
        {


            if (gvDetalleSolicitud.Rows.Count == 0)
            {
                Response.Write("<script language=javascript>");
                Response.Write("alert('Favor de capturar el detalle de la solicitud.')");
                Response.Write("</script>");

            }

            if (Convert.ToInt32(Session["pptal"]) == 1)
            {
                if (Session["DataTemp"] != null)
                {

                    DataTable dt = (DataTable)Session["DataTemp"];

                    string expression;
                    expression = "pptal = 1";
                    DataRow[] foundRows;

                    // Use the Select method to find all rows matching the filter.
                    foundRows = dt.Select(expression);

                    if (foundRows.Length > 0)
                    {

                        GeneraDetalleSolicitud(gvDetalleSolicitud);
                        Response.Redirect("WebImprimirSolicitud.aspx");

                    }


                    else
                    {

                        Response.Write("<script language=javascript>");
                        Response.Write("alert('El Evento Generico es presupuestal, favor de capturar una Clave Presupuestal.')");
                        Response.Write("</script>");
                    }

                }
            }

        }

        //protected void onrowdeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    int index = Convert.ToInt32(e.RowIndex);
        //    string id = gvDetalleSolicitud.DataKeys[index].Value.ToString();

        //    //DataTable dt1 = Session["DataTemp"] as DataTable;

        //    //DataRow[] rows = dt1.Select(string.Format("IdRegistro = {0}", id));

        //    //if (rows.Length > 0)
        //    //{
        //    //    dt1.Rows.Remove(rows[0]);
        //    //}

        //    //Session["DataTemp"] = dt1;

        //    //gvDetalleSolicitud.DataSource = dt1;
        //    //gvDetalleSolicitud.DataBind();
        //    //txtDisponibleClave.Text = "";
        //    //txtImporte.Text = "";
        //    //txtDisponibleDocumento.Text = "";


        //    int index = Convert.ToInt32(e.RowIndex);
        //    string id = gvDetalleSolicitud.DataKeys[index].Value.ToString();

        //    NAdmiSol.NBorraArchivo(Convert.ToInt32(   id));

        //    RefrescaGrid(pIdRegistroMatriz);

        //}

        
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
                  // e.Row.Cells[11].Visible = true;
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
                    //e.Row.Cells[11].Visible = true;
                    //e.Row.Cells[11].Visible = false;
                    break;


            }

        }

       
        


         void GeneraDetalleSolicitud (GridView GridVewDetalleSolicitud)
        {


            try
            {
                XDocument xml = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("registros"));

                XElement xl;

                foreach (GridViewRow gvRow in GridVewDetalleSolicitud.Rows)

                {
                    xl = new XElement("rows",
                                           new XElement("IdRegistro", gvRow.Cells[0].Text),
                                           new XElement("IdClave", gvRow.Cells[1].Text),
                                           new XElement("IdDocumento", gvRow.Cells[2].Text),
                                           new XElement("EventoEspecifico", gvRow.Cells[3].Text),
                                           new XElement("ClavePresupuestal", gvRow.Cells[4].Text),
                                           new XElement("Documento", gvRow.Cells[5].Text),
                                           new XElement("ImporteDocumento", gvRow.Cells[7].Text),
                                           new XElement("ImporteDocumento", gvRow.Cells[7].Text),
                                           new XElement("IdSolicitud", gvRow.Cells[8].Text),
                                           new XElement("pptal", gvRow.Cells[9].Text),
                                           new XElement("IdEventoEsp", gvRow.Cells[10].Text),
                                           new XElement("IdColectiva", gvRow.Cells[11].Text)
                                      );

                    xml.Element("registros").Add(xl);

                }

                Session["NumeroSolicitud"] = NAdmiSol.NInsertaDetalleSolicitud(xml.ToString());


            }
            catch (Exception ex) { throw ex; }


        }




        protected void cvImporteMayor_ServerValidate(object source, ServerValidateEventArgs args)
        {
           
            //decimal Importe;

            //if (txtImporte.Text == "")
            //{
            //    Importe = 0;
            //}
            //else
            //{
            //    Importe = Convert.ToDecimal(txtImporte.Text);
            //}
             



            //if (Importe <= 0)
            //{
            //    args.IsValid = false;

            //}
            //else
            //{
            //    args.IsValid = true;
            //}

        }

        public static byte[] GetById(int Id)
        {

            string CadenaConexion = @"Data Source=38.17.53.107,18176;Initial Catalog=ELECCIONES2021;User Id=LAU;Password=Gar#$2021";
            SqlConnection sqlCnn = new SqlConnection(CadenaConexion);
            sqlCnn.Open();
            string query = @"SELECT archivo
                            FROM RegistroArchivos
                            WHERE IdRegistroUnico = @id";

            SqlCommand cmd = new SqlCommand(query, sqlCnn);
            cmd.Parameters.AddWithValue("@id", Id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return (byte[])reader["archivo"];
            }
            else
            {
              return null;
            }



        }


        public static string GetNombreById(int Id)
        {

            string CadenaConexion = @"Data Source=38.17.53.107,18176;Initial Catalog=ELECCIONES2021;User Id=LAU;Password=Gar#$2021";
            SqlConnection sqlCnn = new SqlConnection(CadenaConexion);
            sqlCnn.Open();
            string query = @"SELECT NombreArchivo
                            FROM RegistroArchivos
                            WHERE IdRegistroUnico = @id";

            SqlCommand cmd = new SqlCommand(query, sqlCnn);
            cmd.Parameters.AddWithValue("@id", Id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return (string)reader["NombreArchivo"];
            }
            else
            {
                return null;
            }



        }



        //protected void gvDetalleSolicitud_RowCommand(object sender, GridViewCommandEventArgs e)
        //{




        //    byte[] archivo = GetById(29);

        //    Response.Clear();

        //    Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", "nombrearch.docx"));
        //    //Response.AddHeader("content-disposition", string.Format("attachment; filename=" + Path.GetFileName(filePath)));

        //    // Response.ContentType = "application/octet-stream";

        //    Response.BinaryWrite(archivo);
        //    Response.End();

        //    //if (e.CommandName == "Select")
        //    //{
        //    //    ////
        //    //    //// Se obtiene indice de la row seleccionada
        //    //    ////
        //    //    int index = Convert.ToInt32(e.CommandArgument);

        //    //    ////
        //    //    //// Obtengo el id de la entidad que se esta editando
        //    //    //// en este caso de la entidad Person
        //    //    ////
        //    //    int id = Convert.ToInt32(gvDetalleSolicitud.DataKeys[index].Value);





        //    //    byte[] archivo = GetById(id);

        //    //    Response.Clear();

        //    //    Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", "nombrearch.docx"));
        //    //    //Response.AddHeader("content-disposition", string.Format("attachment; filename=" + Path.GetFileName(filePath)));

        //    //     Response.ContentType = "application/octet-stream";

        //    //    Response.BinaryWrite(archivo);
        //    //    Response.End();














        //    //using (Model.ELECCIONES2021Entities1 db = new Model.ELECCIONES2021Entities1())
        //    //{

        //    //    var oRegistroArchivo = db.RegistroArchivos.Find(id);
        //    //    string path = AppDomain.CurrentDomain.BaseDirectory;
        //    //    string folder = path + "/temp/";
        //    //    string fullFilePath = folder + oRegistroArchivo.NombreArchivo;

        //    //    if (!Directory.Exists(folder))
        //    //        Directory.CreateDirectory(folder);

        //    //    //if (File.Exists(fullFilePath))
        //    //    //    Directory.Delete(fullFilePath);

        //    //    File.WriteAllBytes(fullFilePath, oRegistroArchivo.Archivo);
        //    //    Process.Start(fullFilePath);

        //    //}

        //    //}

        //}

        protected void ddlTipoGasto_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaEvento(Convert.ToInt32(ddlTipoGasto.SelectedValue), Convert.ToInt32(ddlCandidato.SelectedValue));

        }

        protected void ddlDistrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaCandidato(Convert.ToInt32(ddlColectivaDetalle.SelectedValue), Convert.ToInt32(ddlEventoEspecifico.SelectedValue), Convert.ToInt32(ddlDistrito.SelectedValue),IdUsuarioGlobal);
        }


        protected void gvDetalleSolicitud_SelectedIndexChanged(object sender, EventArgs e)
        {
  
        }

        protected void cvArchivo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if(FileUploadEstados.FileName == "")
            {

                args.IsValid = false;
            }
            else
            {

                args.IsValid = true;

            }

        }

       

        protected void ddlEventoEspecifico_SelectedIndexChanged(object sender, EventArgs e)
        {

           
            int IdUsuarioDistrito = 0;

            if (IDUSUARIOCAPTURA.Text == "")
            {
                Response.Redirect("WebLogin.aspx");
            }
            else
            {
                IdUsuarioDistrito = Convert.ToInt32(IDUSUARIOCAPTURA.Text);

            }
            CargaDistrito(Convert.ToInt32(ddlColectivaDetalle.SelectedValue), Convert.ToInt32(ddlEventoEspecifico.SelectedValue), IdUsuarioDistrito);
        }

        protected void ddlDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {

            CargaExtensiones();



        }


        private void CargaExtensiones()
        {

            lblExtensiones.Text = NAdmiSol.NCargaExtenciones(Convert.ToInt32(ddlDocumento.SelectedValue));

            strDocumentoExtensiones = NAdmiSol.NCargaExtenciones(Convert.ToInt32(ddlDocumento.SelectedValue));
        }


        protected void ddlConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaDocumento(Convert.ToInt32(ddlConcepto.SelectedValue), Convert.ToInt32(ddlTipoGasto.SelectedValue), Convert.ToInt32(ddlCandidato.SelectedValue));

            //gDisponible =  NAdmiSol.NCalculaDisponible(Convert.ToInt32(ddlCandidato.SelectedValue), Convert.ToInt32(ddlTipoGasto.SelectedValue), Convert.ToInt32(ddlConcepto.SelectedValue));
            //gImporteAgrupador = NAdmiSol.NCapturadoAgrupador(Convert.ToInt32(ddlCandidato.SelectedValue), Convert.ToInt32(ddlTipoGasto.SelectedValue), Convert.ToInt32(ddlConcepto.SelectedValue));
            //gDisponible = gDisponible - gImporteAgrupador;
            //if (gDisponible == -1)
            //{

            //    Label6.Visible = false;
            //    Label7.Visible = false;
            //    Label8.Visible = false;
            //    TextBoxCapturado.Visible = false;
            //    TextBoxDisponible.Visible = false;
            //    txtImporte.Visible = false;
            //    gEsPptal = 0;


            //}
            //else
            //{

            //    Label6.Visible = true;
            //    Label7.Visible = true;
            //    TextBoxDisponible.Visible = true;
            //    txtImporte.Visible = true;
            //    Label8.Visible = true;
            //    TextBoxCapturado.Visible = true;
            //    TextBoxDisponible.Visible = true;
            //    TextBoxCapturado.Text = gImporteAgrupador.ToString();
            //    TextBoxDisponible.Text = gDisponible.ToString();
            //    gEsPptal = 1;

            //}


        }



        protected void gvDetalleSolicitud_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

           

        }

        protected void gvDetalleSolicitud_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int index = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(gvDetalleSolicitud.DataKeys[index].Value);
            if (e.CommandName == "Eliminar")
            {

                ViewState["IdRegistroEliminar"] = id;
                int IdRegistroEliminar = Convert.ToInt32(ViewState["IdRegistroEliminar"]);
                int IdUsuarioEliminar = Convert.ToInt32(IDUSUARIOCAPTURA.Text);
                NAdmiSol.NBorraArchivo(IdRegistroEliminar, IdUsuarioEliminar);
                int IdRegistroMatrizRecuperado = Convert.ToInt32(IDAGRUPADOR.Text);

                RefrescaGrid(IdRegistroMatrizRecuperado);


            }

            if (e.CommandName == "Seleccionar")
            {
                //byte[] archivo = GetById(id);

                //string strNombreArchivo = GetNombreById(id);

                //Response.Clear();

                //Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", strNombreArchivo));


                //Response.BinaryWrite(archivo);

                //Response.End();

                Session["IdRegistroUnico"] = id;
                Response.Redirect("DownLoad.aspx");
                //CargaExtensiones();

            }

            //Response.Write("<script language=javascript>");
            //Response.Write("alert('Archivo Eliminado Satisfactoriamente...')");
            //Response.Write("</script>");

        }

        protected void gvDetalleSolicitud_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvDetalleSolicitud_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebCapturaDocumentos.aspx");
        }
    }
}