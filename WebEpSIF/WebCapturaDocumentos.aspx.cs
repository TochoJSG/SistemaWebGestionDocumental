using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using MySqlConnector;
using SAT.Services.ConsultaCFDIService;
using SW.Services.Status;


namespace WebEpSIF
{
    public partial class WebCapturaDocumentos : System.Web.UI.Page
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

        static int IdCandidatura;

        WebEpSIF.NEGOCIO.NAdministraSolicitudes NAdmiSol = new WebEpSIF.NEGOCIO.NAdministraSolicitudes();



        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                //Button btn = new Button();
                //btn.ID = "btnFechaInicio";


                //Convert.ToDateTime(NAdmiSol.NFechaServidor()).ToString ();
                //btn.Click += new EventHandler(btnFechaInicio_Click );


              
               //DateTime FechaP = DateTime.ParseExact(txtFechaInicio.Text, "dd-MM-yyyy", null);

                //"dd/MM/yyyy"

                if (!Page.IsPostBack)
                {


                    if (Session["IdUsuario"] == null)
                    {

                        Response.Redirect("WebLogin.aspx");
                       

                    }

                    else
                    {

                        IdUsuarioGlobal = Convert.ToInt32(Session["IdUsuario"]);
                        IDUSUARIOADMINISTRACARGA.Text = Session["IdUsuario"].ToString();
                        USUARIOADMINISTRACARGA.Text = Session["UsuarioMapeado"].ToString();


                    }


                    pIdEvento = Convert.ToInt32(Session["IdEvento"]);
                    pIdDependencia = Convert.ToInt32(Session["IdDependencia"]);
                    pIdEjercicioPresupuestal = Convert.ToInt32(Session["IdEjercicioPresupuestal"]);
                    //IdUsuarioGlobal = Convert.ToInt32(Session["IdUsuario"]);
                    IdColectiva = Convert.ToInt32(Session["IdColectiva"]);

                    CalFechaInicio.Visible = false;
                    CalFechaFin.Visible = false;

                    DateTime dd = Convert.ToDateTime(NAdmiSol.NFechaServidor());
                    txtFechaInicio.Text = dd.ToString("yyyy-MM-dd");
                    txtFechaFin.Text = dd.ToString("yyyy-MM-dd");

                    ddlCandidato.Enabled = false;
                    ddlColectivaDetalle.Enabled = false;
                    ddlConcepto.Enabled = false;
                    ddlDistrito.Enabled = false;
                    ddlDocumento.Enabled = false;
                    ddlColectivaDetalle.Enabled = false;
                    ddlEventoEspecifico.Enabled = false;
                    ddlPeriodo.Enabled = false;
                    ddlTipoGasto.Enabled = false;

                    


                }

                
                   
                   

                    //CargaColectivaDetalle(0);
                    //CargaTipoDocumento();
                    //CargaPeriodo();


                    //CargaDistrito(0, 0);
                    //CargaCandidato(0, 0, 0,IdUsuarioGlobal);
                    //CargaEvento(0);
                    //CargaDocumento(0,0,0);
                    //CargaConcepto(0);
                    //CargaEventoEspecifico(0, 0, 0, 0, 0);
                    //CargaTipoDocumento();
                    //CargaPeriodo();
                    //CargaColectivaDetalle(IdUsuarioGlobal);



                    //RefrescaGrid();

                    if ( Convert.ToInt32(Session["Sololectura"]) == 1)
                    {

                        ButtonNuevo.Enabled = false;
                        ButtonNuevo.BackColor = System.Drawing.Color.Gray;



                    }
                    else
                    {
                        ButtonNuevo.Enabled = true;

                    }



                    //ddlPeriodo.Items.Insert(0, new ListItem("[TODOS...]", "0"));
                    //ddlEventoEspecifico.Items.Insert(0, new ListItem("[TODOS...]", "0"));

                        //ddlColectivaDetalle.Items.Insert(0, new ListItem("[TODOS...]", "0"));

                        //ddlDistrito.Items.Insert(0, new ListItem("[TODOS...]", "0"));
                        //ddlCandidato.Items.Insert(0, new ListItem("[TODOS...]", "0"));
                        //ddlConcepto.Items.Insert(0, new ListItem("[TODOS...]", "0"));
                        //ddlTipoGasto.Items.Insert(0, new ListItem("[TODOS...]", "0"));
                        //ddlDocumento.Items.Insert(0, new ListItem("[TODOS...]", "0"));



                        //ddlClavePresupuestal.Items.Insert(0, new ListItem("[SELECCIONAR LA CLAVE PRESUPUESTAL...]", "0"));
                        //ddlColectivaDetalle.Items.Insert(0, new ListItem("[SELECCIONAR EL NIVEL...]", "0"));
                        //ddlDocumento.Items.Insert(0, new ListItem("[SELECCIONAR EL DOCUMENTO...]", "0"));
                        // ddlConcepto.Items.Insert(0, new ListItem("[SELECCIONAR EL TIPO DE DOCUMENTO...]", "0"));
                        // btnFechaInicio  .Click += new EventHandler(this.btnFechaInicio_Click);
                        dt = TablaDetalle();

                //Button1.Attributes.Add("onclick", "confirm('Confirmar()'))");
                // Form.DefaultButton = this.btnFechaInicio .UniqueID;

                Session["DataTemp"] = dt;
                //}
            }



            catch (Exception ex)
            {
                //Response.Redirect("Error.aspx"); 
            }

        }





        protected void CargaDistrito(int pIdCandidatura, int pIdEstado, int pIdusuario)
        {

            ddlDistrito.DataSource = NAdmiSol.NCargaDistrito(pIdCandidatura, pIdEstado, pIdusuario);
            ddlDistrito.DataTextField = "Distrito";
            ddlDistrito.DataValueField = "IdDistrito";
            ddlDistrito.DataBind();
            ddlDistrito.Items.Insert(0, new ListItem("[TODOS...]", "0"));



        }

        protected void CargaCandidato(int pIdCandidatura, int pIdEstado, int pIDdistrito, int IdUsuario)
        {

            ddlCandidato.DataSource = NAdmiSol.NCargaCandidato(pIdCandidatura, pIdEstado, pIDdistrito, IdUsuario);
            ddlCandidato.DataTextField = "Candidato";
            ddlCandidato.DataValueField = "IdCandidato";
            ddlCandidato.DataBind();
            ddlCandidato.Items.Insert(0, new ListItem("[TODOS...]", "0"));



        }


        protected void CargaEvento(int pIdConcepto, int pIdCandidato)
        {

            ddlConcepto.DataSource = NAdmiSol.NCargaEvento(pIdConcepto, pIdCandidato);
            ddlConcepto.DataTextField = "Evento";
            ddlConcepto.DataValueField = "IdEvento";
            ddlConcepto.DataBind();
            ddlConcepto.Items.Insert(0, new ListItem("[TODOS...]", "0"));



        }

        protected void CargaDocumento(int pIdevento,int pIdConcepto, int pIdCandidato)
        {

            ddlDocumento.DataSource = NAdmiSol.NCargaDocumento(pIdevento, pIdConcepto,  pIdCandidato);
            ddlDocumento.DataTextField = "Documento";
            ddlDocumento.DataValueField = "IdDocumento";
            ddlDocumento.DataBind();
            ddlDocumento.Items.Insert(0, new ListItem("[TODOS...]", "0"));



        }

        protected void CargaConcepto(int pIdCandidato)
        {

            ddlTipoGasto.DataSource = NAdmiSol.NCargaConcepto(pIdCandidato);
            ddlTipoGasto.DataTextField = "Concepto";
            ddlTipoGasto.DataValueField = "IdConcepto";
            ddlTipoGasto.DataBind();
            ddlTipoGasto.Items.Insert(0, new ListItem("[TODOS...]", "0"));



        }

        protected void CargaEventoEspecifico(int pIdEvento, int pIdDependencia, int pIEjercicioPresupuestal, int pIdUsuario, int pIdCandidatura)
        {

            ddlEventoEspecifico.DataSource = NAdmiSol.NCargaEventoEspecifico(pIdUsuario, pIdCandidatura);
            ddlEventoEspecifico.DataTextField = "Estado";
            ddlEventoEspecifico.DataValueField = "IdEstado";
            ddlEventoEspecifico.DataBind();
            ddlEventoEspecifico.Items.Insert(0, new ListItem("[TODOS...]", "0"));



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
            ddlConcepto.Items.Insert(0, new ListItem("[TODOS...]", "0"));



        }


        protected void CargaPeriodo()
        {

            ddlPeriodo.DataSource = NAdmiSol.NCargaPeriodo();
            ddlPeriodo.DataTextField = "Periodo";
            ddlPeriodo.DataValueField = "idperiodo";
            ddlPeriodo.DataBind();
            ddlPeriodo.Items.Insert(0, new ListItem("[TODOS...]", "0"));



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
            //dr[7] = FileUploadEstados.FileName;



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
            dr = dt.NewRow();
            dr[0] = n;
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





        //protected void btnAgregar_Click(object sender, EventArgs e)
        //{

        //    //if (IsValid)
        //    //{


        //    //    AgregaRegistroDetalle(pptal,ConDocumento);

        //    //    //DataTable dt = (DataTable)Session["DataTemp"];



        //    //}








        //    if (FileUploadEstados.FileName == "")
        //    {

        //        Response.Write("<script language=javascript>");
        //        Response.Write("alert('Favor de seleccionar el archivo...')");
        //        Response.Write("</script>");
        //        return;
        //    }

        //    string strDocumentoExtensiones = NAdmiSol.NCargaExtenciones(Convert.ToInt32(ddlDocumento.SelectedValue));

        //    //DisponibleConsultado = NAdmiSol.fnExtenciones(Convert.ToInt32(ddlClavePresupuestal.SelectedValue));

        //    if (FileUploadEstados.HasFile)
        //    {
        //        // Get the name of the file to upload.
        //        string strArchivo = Server.HtmlEncode(FileUploadEstados.FileName);

        //        // Get the extension of the uploaded file.
        //        string strExtension = System.IO.Path.GetExtension(strArchivo);

        //        bool AplicaExtencion = strDocumentoExtensiones.Contains(strExtension.ToUpper());

        //        // Allow only files with .doc or .xls extensions
        //        // to be uploaded.
        //        if ((AplicaExtencion == false))

        //        {

        //            Response.Write("<script language=javascript>");
        //            Response.Write("alert('Extension de archivo incorrecta...')");
        //            Response.Write("</script>");
        //            return;



        //        }
        //    }

        //    if (FileUploadEstados.HasFile)
        //    {
        //        // Get the name of the file to upload.
        //        string strArchivo = Server.HtmlEncode(FileUploadEstados.FileName);

        //        // Get the extension of the uploaded file.
        //        string strExtension = System.IO.Path.GetExtension(strArchivo);

        //        // Allow only files with .doc or .xls extensions
        //        // to be uploaded.
        //        if ((strExtension == ".xml"))

        //        {
        //            XmlDocument CFDI = new XmlDocument();
        //            CFDI.Load(FileUploadEstados.FileContent);
        //            XmlNode nodoEmisor = CFDI.GetElementsByTagName("cfdi:Emisor").Item(0);
        //            string valorRFCEmisor = nodoEmisor.Attributes.GetNamedItem("Rfc").Value;

        //            XmlNode nodoReceptor = CFDI.GetElementsByTagName("cfdi:Receptor").Item(0);
        //            string valorRFCReceptor = nodoReceptor.Attributes.GetNamedItem("Rfc").Value;

        //            XmlNode nodoUUID = CFDI.GetElementsByTagName("tfd:TimbreFiscalDigital").Item(0);
        //            string valorUUID = nodoUUID.Attributes.GetNamedItem("UUID").Value;

        //            XmlNode nodoConcepto = CFDI.GetElementsByTagName("cfdi:Comprobante").Item(0);
        //            string valorImporte = nodoConcepto.Attributes.GetNamedItem("Total").Value;

        //            Status status = new Status("https://consultaqr.facturaelectronica.sat.gob.mx/ConsultaCFDIService.svc");
        //            Acuse response = status.GetStatusCFDI(valorRFCEmisor, valorRFCReceptor, Convert.ToString(valorImporte), valorUUID);
        //            //Console.WriteLine(response.CodigoEstatus);
        //            //Console.WriteLine(response.Estado);
        //            //Console.WriteLine(response.EsCancelable);
        //            //Console.WriteLine(response.EstatusCancelacion);
        //            //Console.ReadLine();

        //            if (response.Estado == "Cancelado")
        //            {

        //                Response.Write("<script language=javascript>");
        //                Response.Write("alert('El estatus del CFDI en SAT es Cancelado...')");
        //                Response.Write("</script>");
        //                return;
        //            }

        //            if (response.Estado == "No Encontrado")
        //            {
        //                Response.Write("<script language=javascript>");
        //                Response.Write("alert('El estatus del CFDI en SAT es No Encontrado...')");
        //                Response.Write("</script>");
        //                return;
        //            }



        //        }
        //    }

        //    int pIdMatrizEncabezado = NAdmiSol.NInsertaEncabezadoMatriz(Convert.ToInt32(ddlPeriodo.SelectedValue), Convert.ToInt32(ddlColectivaDetalle.SelectedValue), Convert.ToInt32(ddlEventoEspecifico.SelectedValue), Convert.ToInt32(ddlDistrito.SelectedValue), Convert.ToInt32(ddlCandidato.SelectedValue), Convert.ToInt32(ddlTipoGasto.SelectedValue), Convert.ToInt32(ddlConcepto.SelectedValue), Convert.ToInt32(ddlDocumento.SelectedValue));

        //    byte[] file = null;

        //    Stream MySistemFile = FileUploadEstados.FileContent;
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        MySistemFile.CopyTo(ms);
        //        file = ms.ToArray();
        //    }


        //    using (Model.ELECCIONES2021Entities1 db = new Model.ELECCIONES2021Entities1())
        //    {

        //        Model.RegistroArchivos oRegistroArchivos = new Model.RegistroArchivos();
        //        oRegistroArchivos.IdEstado = Convert.ToInt32(ddlEventoEspecifico.SelectedValue);
        //        oRegistroArchivos.IdNivel = Convert.ToInt32(ddlColectivaDetalle.SelectedValue);
        //        oRegistroArchivos.IdConcepto = Convert.ToInt32(ddlTipoGasto.SelectedValue);
        //        oRegistroArchivos.NombreArchivo = FileUploadEstados.FileName;
        //        oRegistroArchivos.IdPeriodo = Convert.ToInt32(ddlPeriodo.SelectedValue);
        //        oRegistroArchivos.IdRegistroMatriz = pIdMatrizEncabezado;
        //        oRegistroArchivos.Archivo = file;
        //        oRegistroArchivos.fechacarga = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-dd"));
        //        db.RegistroArchivos.Add(oRegistroArchivos);
        //        db.SaveChanges();


        //        //               [IdRegistroUnico] [int] IDENTITY(1,1) NOT NULL,

        //        //   [IdEstado] [int] NULL,
        //        //[IdTipoGasto] [int] NULL,
        //        //[IdNivel] [int] NULL,
        //        //[IdPeriodo] [int] NULL,
        //        //[IdRegistroMatriz] [int] NULL,
        //        //[NombreArchivo] [varchar] (255) NULL,




        //    }
        //    RefrescaGrid();

        //}









        protected void ddlPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {




        }



        protected void ddlCandidato_SelectedIndexChanged(object sender, EventArgs e)
        {

            CargaConcepto(Convert.ToInt32(ddlCandidato.SelectedValue));

        }






        protected void ddlColectivaDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {

            IdCandidatura = Convert.ToInt32(ddlColectivaDetalle.SelectedValue);

            IdUsuarioGlobal = Convert.ToInt32(IDUSUARIOADMINISTRACARGA.Text);

            CargaEventoEspecifico(0, 0, 0, IdUsuarioGlobal, IdCandidatura);

        }



        protected void CargaColectivaDetalle(int pIdUsuario)
        {


            ddlColectivaDetalle.DataSource = NAdmiSol.NCargaColectivaEventoEspecifico(pIdUsuario);
            ddlColectivaDetalle.DataTextField = "DescripcionNivel";
            ddlColectivaDetalle.DataValueField = "Idnivel";
            ddlColectivaDetalle.DataBind();
            ddlColectivaDetalle.Items.Insert(0, new ListItem("[TODOS...]", "0"));


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
            IdPeriodo = Convert.ToInt32(ddlPeriodo.SelectedValue);

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


            //if (gvDetalleSolicitud.Rows.Count == 0)
            //{
            //    Response.Write("<script language=javascript>");
            //    Response.Write("alert('Favor de capturar el detalle de la solicitud.')");
            //    Response.Write("</script>");

            //}

            //if (Convert.ToInt32(Session["pptal"]) == 1)
            //{
            //    if (Session["DataTemp"] != null)
            //    {

            //        DataTable dt = (DataTable)Session["DataTemp"];

            //        string expression;
            //        expression = "pptal = 1";
            //        DataRow[] foundRows;

            //        // Use the Select method to find all rows matching the filter.
            //        foundRows = dt.Select(expression);

            //        if (foundRows.Length > 0)
            //        {

            //            GeneraDetalleSolicitud(gvDetalleSolicitud);
            //            Response.Redirect("WebImprimirSolicitud.aspx");

            //        }


            //        else
            //        {

            //            Response.Write("<script language=javascript>");
            //            Response.Write("alert('El Evento Generico es presupuestal, favor de capturar una Clave Presupuestal.')");
            //            Response.Write("</script>");
            //        }

            //    }
            //}

        }

        protected void onrowdeleting(object sender, GridViewDeleteEventArgs e)
        {
            

            ////DataTable dt1 = Session["DataTemp"] as DataTable;

            ////DataRow[] rows = dt1.Select(string.Format("IdRegistro = {0}", id));



            //DataTable dt = new DataTable();
            //dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id", typeof(int)),
            //                new DataColumn("Name", typeof(string)),
            //                new DataColumn("Country",typeof(string)) });
            //dt.Rows.Add(1, "Jonathan Orozco", "Monterrey");
            //dt.Rows.Add(2, "Jesus Corona", "México");
            //dt.Rows.Add(3, "Cirilo Zaucedo", "Tijuana");
            //dt.Rows.Add(4, "Humberto Suazo", "Chile");
            //GridView1.DataSource = dt;
            //GridView1.DataBind();

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





        }


        protected void ondatabound(object sender, GridViewRowEventArgs e)
        {
            //switch (e.Row.RowType)
            //{
            //    case DataControlRowType.Header:

            //        e.Row.Cells[0].Visible = true;
            //        e.Row.Cells[1].Visible = true;
            //        e.Row.Cells[2].Visible = true;
            //        e.Row.Cells[3].Visible = true;
            //        e.Row.Cells[4].Visible = true;
            //        e.Row.Cells[5].Visible = true;
            //        e.Row.Cells[6].Visible = true;
            //        e.Row.Cells[7].Visible = true;
            //        e.Row.Cells[8].Visible = true;
            //        e.Row.Cells[9].Visible = true;
            //        e.Row.Cells[10].Visible = true;
            //        // e.Row.Cells[11].Visible = true;
            //        break;
            //    case DataControlRowType.DataRow:

            //        e.Row.Cells[0].Visible = true;
            //        e.Row.Cells[1].Visible = true;
            //        e.Row.Cells[2].Visible = true;
            //        e.Row.Cells[3].Visible = true;
            //        e.Row.Cells[4].Visible = true;
            //        e.Row.Cells[5].Visible = true;
            //        e.Row.Cells[6].Visible = true;
            //        e.Row.Cells[7].Visible = true;
            //        e.Row.Cells[8].Visible = true;
            //        e.Row.Cells[9].Visible = true;
            //        e.Row.Cells[10].Visible = true;
            //        //e.Row.Cells[11].Visible = true;
            //        //e.Row.Cells[11].Visible = false;
            //        break;


            //}

        }





        void GeneraDetalleSolicitud(GridView GridVewDetalleSolicitud)
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



        //protected void gvDetalleSolicitud_RowCommand(object sender, GridViewCommandEventArgs e)
        //{

        //    if (e.CommandName == "Select")
        //    {
        //        //
        //        // Se obtiene indice de la row seleccionada
        //        //
        //        int index = Convert.ToInt32(e.CommandArgument);

        //        //
        //        // Obtengo el id de la entidad que se esta editando
        //        // en este caso de la entidad Person
        //        //
        //        int id = Convert.ToInt32(gvDetalleSolicitud.DataKeys[index].Value);


        //        using (WebEpSIF.Model.ELECCIONES2021Entities1 db = new WebEpSIF.Model.ELECCIONES2021Entities1())
        //        {


        //            db.Database.CommandTimeout = 0;
        //            var oRegistroArchivo = db.RegistroArchivos.Find(id);
        //            string path = AppDomain.CurrentDomain.BaseDirectory;
        //            string folder = path + "/temp/";
        //            string fullFilePath = folder + oRegistroArchivo.NombreArchivo;

        //            if (!Directory.Exists(folder))
        //                Directory.CreateDirectory(folder);

        //            //if (File.Exists(fullFilePath))
        //            //    Directory.Delete(fullFilePath);

        //            File.WriteAllBytes(fullFilePath, oRegistroArchivo.Archivo);
        //            System.Diagnostics.Process.Start(fullFilePath);

        //        }

        //    }
        //    if (e.CommandName == "Descarga")
        //    {
        //        //
        //        // Se obtiene indice de la row seleccionada
        //        //
        //        int index = Convert.ToInt32(e.CommandArgument);

        //        //
        //        // Obtengo el id de la entidad que se esta editando
        //        // en este caso de la entidad Person
        //        //
        //        int id = Convert.ToInt32(gvDetalleSolicitud.DataKeys[index].Value);


        //        using (WebEpSIF.Model.ELECCIONES2021Entities1 db = new WebEpSIF.Model.ELECCIONES2021Entities1())
        //        {


        //            db.Database.CommandTimeout = 0;
        //            var oRegistroArchivo = db.RegistroArchivos.Find(id);
        //            float t = oRegistroArchivo.Archivo.Length;


        //            //float rt = t / 8;
        //            //int tt = Convert.ToInt32(rt);



        //            string path = AppDomain.CurrentDomain.BaseDirectory;
        //            string folder = "C:/Evidencias/Camp2021/";
        //            string fullFilePath = folder + oRegistroArchivo.NombreArchivo;





        //            if (!Directory.Exists(folder))
        //                Directory.CreateDirectory(folder);

        //            //if (File.Exists(fullFilePath))
        //            //    Directory.Delete(fullFilePath);





        //            File.WriteAllBytes(fullFilePath, oRegistroArchivo.Archivo);
        //            //System.Diagnostics.Process.Start(fullFilePath);

        //        }

        //    }

        //}


        void RefrescaGrid()
        {

            if ((txtFechaInicio.Text=="")| (txtFechaFin.Text==""))
            {

                Response.Redirect("WebLogin.aspx"); 

            }


            if ((txtFechaInicio.Text == null) | (txtFechaFin.Text == null))
            {

                Response.Redirect("WebLogin.aspx");

            }



            DateTime FechaInicial = Convert.ToDateTime(txtFechaInicio.Text);
            DateTime FechaFinal = Convert.ToDateTime(txtFechaFin.Text);


            gvDetalleSolicitud.DataSource = null;
            gvDetalleSolicitud.DataBind();
            IdUsuarioGlobal = Convert.ToInt32(Session["IdUsuario"]);
            //gvDetalleSolicitud.AutoGenerateSelectButton = true;

            if (!CheckBoxTodos.Checked)
            {

                gvDetalleSolicitud.DataSource = NAdmiSol.NCargaListadoCarpetas(0, 0, 0,0, 0, 0,0, 0, FechaInicial.ToString("yyyy-MM-dd"), FechaFinal.ToString("yyyy-MM-dd"), IdUsuarioGlobal, -1);

            }
            else

            {
                gvDetalleSolicitud.DataSource = NAdmiSol.NCargaListadoCarpetas(Convert.ToInt32(ddlPeriodo.SelectedValue), Convert.ToInt32(ddlEventoEspecifico.SelectedValue), Convert.ToInt32(ddlColectivaDetalle.SelectedValue), Convert.ToInt32(ddlDistrito.SelectedValue), Convert.ToInt32(ddlCandidato.SelectedValue), Convert.ToInt32(ddlTipoGasto.SelectedValue), Convert.ToInt32(ddlConcepto.SelectedValue), Convert.ToInt32(ddlDocumento.SelectedValue), FechaInicial.ToString("yyyy-MM-dd"), FechaFinal.ToString("yyyy-MM-dd"), IdUsuarioGlobal, 0);

            }


            gvDetalleSolicitud.DataBind();
            //gvDetalleSolicitud.Columns[2].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //gvDetalleSolicitud.Columns[11].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //gvDetalleSolicitud.Columns[12].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //gvDetalleSolicitud.Columns[13].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //gvDetalleSolicitud.Columns[14].ItemStyle.HorizontalAlign = HorizontalAlign.Center;

        }

        protected void gvDetalleSolicitud_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvDetalleSolicitud_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDetalleSolicitud.PageIndex = e.NewPageIndex;
            RefrescaGrid();
        }

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

        //protected void cvArchivo_ServerValidate(object source, ServerValidateEventArgs args)
        //{
        //    if (FileUploadEstados.FileName == "")
        //    {

        //        args.IsValid = false;
        //    }
        //    else
        //    {

        //        args.IsValid = true;

        //    }

        //}



        protected void ddlEventoEspecifico_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaDistrito(Convert.ToInt32(ddlColectivaDetalle.SelectedValue), Convert.ToInt32(ddlEventoEspecifico.SelectedValue), IdUsuarioGlobal );
        }

        protected void ddlDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {

            // lblExtensiones.Text = NAdmiSol.NCargaExtenciones(Convert.ToInt32(ddlDocumento.SelectedValue));


        }

        protected void ddlConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaDocumento(Convert.ToInt32(ddlConcepto.SelectedValue), Convert.ToInt32(ddlTipoGasto.SelectedValue), Convert.ToInt32(ddlCandidato.SelectedValue));
        }





        protected void txtFechaFin_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnFechaFin_Click(object sender, EventArgs e)
        {
            if (CalFechaFin.Visible)
            {

                CalFechaFin.Visible = false;
            }
            else
            {

                CalFechaFin.Visible = true;
            }
            CalFechaFin.Attributes.Add("style", "position:absolute");
        }

        protected void btnFechaInicio_Click(object sender, EventArgs e)
        {
            if (CalFechaInicio.Visible)
            {

                CalFechaInicio.Visible = false;
            }
            else
            {

                CalFechaInicio.Visible = true;
            }
            CalFechaInicio.Attributes.Add("style", "position:absolute");

        }

        protected void CalFechaInicio_SelectionChanged(object sender, EventArgs e)
        {
            txtFechaInicio.Text = CalFechaInicio.SelectedDate.ToShortDateString();
            CalFechaInicio.Visible = false;
        }

        protected void CalFechaFin_SelectionChanged(object sender, EventArgs e)
        {
            txtFechaFin.Text = CalFechaFin.SelectedDate.ToShortDateString();
            CalFechaFin.Visible = false;
        }

        protected void btnConsultaCarpetas_Click(object sender, EventArgs e)
        {
            RefrescaGrid();
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnDescargar_Click(object sender, EventArgs e)
        {





            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[1] { new DataColumn("Id", typeof(int))
                            });









            for (int i = 0; i < gvDetalleSolicitud.Rows.Count; i++)
            {


                CheckBox chkdescarga = (CheckBox)gvDetalleSolicitud.Rows[i].Cells[0].FindControl("chbItem");

                if (chkdescarga.Checked)

                {
                    int id = Convert.ToInt32(gvDetalleSolicitud.Rows[i].Cells[1].Text);

                    string AgrupadorCarpeta = Convert.ToString(gvDetalleSolicitud.Rows[i].Cells[2].Text);



                    if (CheckBoxBorrados.Checked)
                    {
                        dt = NAdmiSol.NCargaRegistrosMatriz(id, 0);

                    }
                    else
                    {

                        dt = NAdmiSol.NCargaRegistrosMatriz(id, 1);
                    }

                    foreach (DataRow fila in dt.Rows)
                    {

                       
                        string valor = fila["IdRegistroUnico"].ToString();
                        int idArchivo = Convert.ToInt32 (  valor);
                        byte[] archivo = GetById(idArchivo);
                        //Response.Clear();
                        //Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", "nombrearch.docx"));

                        Response.AddHeader("content-disposition", string.Format("attachment;filename=nombrearch.docx"));
                        //Response.ContentType = "application/octet-stream";
                        Response.BinaryWrite(archivo);
                        archivo = null;

                        //Response.End();



                    }



                    }



                }


                    















            //// codigo original


            //DataTable dt = new DataTable();
            //dt.Columns.AddRange(new DataColumn[1] { new DataColumn("Id", typeof(int))
            //                });



            //for (int i = 0; i < gvDetalleSolicitud.Rows.Count; i++)
            //{


            //    CheckBox chkdescarga = (CheckBox)gvDetalleSolicitud.Rows[i].Cells[0].FindControl("chbItem");

            //    if (chkdescarga.Checked)

            //    {
            //        int id = Convert.ToInt32(gvDetalleSolicitud.Rows[i].Cells[1].Text);

            //        string AgrupadorCarpeta = Convert.ToString(gvDetalleSolicitud.Rows[i].Cells[2].Text);


            //        using (WebEpSIF.Model.ELECCIONES2021Entities1 db = new WebEpSIF.Model.ELECCIONES2021Entities1())
            //        {



            //            string path = AppDomain.CurrentDomain.BaseDirectory;
            //            string folder = "C:/Evidencias/" + AgrupadorCarpeta + "/";

            //            if (CheckBoxBorrados.Checked)
            //            {
            //                dt = NAdmiSol.NCargaRegistrosMatriz(id, 0);

            //            }
            //            else
            //            {

            //                dt = NAdmiSol.NCargaRegistrosMatriz(id, 1);
            //            }

            //            foreach (DataRow fila in dt.Rows)
            //            {
            //                string valor = fila["IdRegistroUnico"].ToString();
            //                db.Database.CommandTimeout = 0;
            //                var oRegistroArchivo = db.RegistroArchivos.Find(Convert.ToInt32(valor));
            //                float t = oRegistroArchivo.Archivo.Length;
            //                string fullFilePath = folder + oRegistroArchivo.NombreArchivo;

            //                if (!Directory.Exists(folder))
            //                    Directory.CreateDirectory(folder);

            //                if (File.Exists(fullFilePath))
            //                    Directory.Delete(fullFilePath);

            //                File.WriteAllBytes(fullFilePath, oRegistroArchivo.Archivo);

            //                //Response.ContentType = "text/xml";
            //                //Response.ContentEncoding = System.Text.Encoding.UTF8;
            //                //Response.AppendHeader("NombreCabecera", "MensajeCabecera");
            //                //Response.TransmitFile(Server.MapPath(fullFilePath));
            //                //Response.End();










            //System.Diagnostics.Process.Start(fullFilePath);
            // }
            //dt.Rows.Add(id);
            //}

            //}

            //}
            //    // codigo respaldo




            //}

            //DataTable dt = new DataTable();
            //dt.Columns.AddRange(new DataColumn[1] { new DataColumn("Id", typeof(int))
            //                });



            //for (int i = 0; i < gvDetalleSolicitud.Rows.Count; i++)
            //{


            //    CheckBox chkdescarga = (CheckBox)gvDetalleSolicitud.Rows[i].Cells[0].FindControl("chbItem");

            //    if (chkdescarga.Checked)

            //    {
            //        int id = Convert.ToInt32(gvDetalleSolicitud.Rows[i].Cells[1].Text);

            //        string AgrupadorCarpeta = Convert.ToString(gvDetalleSolicitud.Rows[i].Cells[2].Text);


            //        using (WebEpSIF.Model.ELECCIONES2021Entities1 db = new WebEpSIF.Model.ELECCIONES2021Entities1())
            //        {




            //            if (CheckBoxBorrados.Checked)
            //            {
            //                dt = NAdmiSol.NCargaRegistrosMatriz(id, 0);

            //            }
            //            else
            //            {

            //                dt = NAdmiSol.NCargaRegistrosMatriz(id, 1);
            //            }

            //            foreach (DataRow fila in dt.Rows)
            //            {
            //                string valor = fila["IdRegistroUnico"].ToString();
            //                db.Database.CommandTimeout = 0;
            //                var oRegistroArchivo = db.RegistroArchivos.Find(Convert.ToInt32(valor));





            //                byte[] archivo = GetById(Convert.ToInt32 (  valor));

            //                Response.Clear();

            //                // Response.AddHeader("content-disposition", string.Format("attachment;filename= nombrearch.pdf"));


            //                Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", "nombrearch.pdf"));


            //                Response.ContentType = "application/octet-stream";

            //                Response.BinaryWrite(archivo);
            //                Response.End();

            //            }

            //        }

            //    }



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



            //return null;

        }





        protected void CheckBoxBorrados_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            //Response.Redirect("DownLoad.aspx");

            
            Session["TipoOperacion"] = "NuevoAgrupador";
            Response.Redirect("WebGeneraSolicitud.aspx");


        }

        protected void gvDetalleSolicitud_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (Convert.ToInt32(Session["Sololectura"]) == 1)
            {
                Response.Write("<script>alert('El usuario no tiene acceso a esta funcionalidad, favor de revisar su perfil con el administrador... .')</script>");
                return;

            }

            




            if (e.CommandName == "Edd")
            {


                Session["TipoOperacion"] = "Editar";
                int index = Convert.ToInt32(e.CommandArgument);
                int id = Convert.ToInt32(gvDetalleSolicitud.DataKeys[index].Value);
                

                if (NAdmiSol.NRegistroCancelado(id) == 1)
                {

                    Response.Write("<script>alert('No se puede Editar un registro CANCELADO...')</script>");
                    return;



                }

                Session["IdRegistroMatriz"] = id;

                Session["IdUsuario"] = IDUSUARIOADMINISTRACARGA.Text;

                Session["UsuarioMapeado"] = USUARIOADMINISTRACARGA.Text;



                Response.Redirect("WebGeneraSolicitud.aspx");

            }

            if (e.CommandName == "Nuevo")
            {

                Session["TipoOperacion"] = "Nuevo";
                int index = Convert.ToInt32(e.CommandArgument);
                int id = Convert.ToInt32(gvDetalleSolicitud.DataKeys[index].Value);
                Session["IdRegistroMatriz"] = id;

                if (NAdmiSol.NRegistroCancelado(id) == 1)
                {

                    Response.Write("<script>alert('No se puede generar un Nuevo agrupador con un registro CANCELADO...')</script>");
                    return;



                }
                Session["IdRegistroMatriz"] = id;
                
                Session["IdUsuario"] = IDUSUARIOADMINISTRACARGA.Text;

                Session["UsuarioMapeado"] = USUARIOADMINISTRACARGA.Text;



                Response.Redirect("WebGeneraSolicitud.aspx");
            }


            if (e.CommandName == "Cancelar")
            {

                Session["IdUsuario"] = IDUSUARIOADMINISTRACARGA.Text;

                Session["UsuarioMapeado"] = USUARIOADMINISTRACARGA.Text;


                int index = Convert.ToInt32(e.CommandArgument);
                int id = Convert.ToInt32(gvDetalleSolicitud.DataKeys[index].Value);

                if (NAdmiSol.NRegistroCancelado(id) == 1)
                {

                    Response.Write("<script>alert('El registro ya esta cancelado CANCELADO...')</script>");
                    return;



                }


                int Bloqueado = NAdmiSol.NRegistroBloqueado(id);

                if (Bloqueado == 1)
                {


                    Response.Write("<script language=javascript>");
                    Response.Write("alert('No es posible cancelar un registro cargado en el INE o Ejercido...')");
                    Response.Write("</script>");
                    return;

                }

                Session["IdMatriz"] = id;
                Response.Redirect("WebFormConfirmaCancelar.aspx");



               

                //NAdmiSol.NCancelarPoliza(Convert.ToInt32(id));
                //Response.Write("<script>alert('Registro Cancelado... .')</script>");

                //RefrescaGrid();
            }

            if (e.CommandName == "Gasto")
            {

                Session["IdUsuario"] = IDUSUARIOADMINISTRACARGA.Text;

                Session["UsuarioMapeado"] = USUARIOADMINISTRACARGA.Text;


                int index = Convert.ToInt32(e.CommandArgument);
                int id = Convert.ToInt32(gvDetalleSolicitud.DataKeys[index].Value);

                if (NAdmiSol.NRegistroCancelado(id) == 1)
                {

                    Response.Write("<script>alert('No se puede capturar el gasto para un registro CANCELADO...')</script>");
                    return;



                }




                int Espptal = NAdmiSol.NRegistroEspptal(id);


                if (Espptal == 1)
                {

                    Session["IdMatriz"] = id;
                    Response.Redirect("WebFormCapturaGasto.aspx");


                }

                else
                {

                    Response.Write("<script language=javascript>");
                    Response.Write("alert('El Tipo de Gasto no tiene presupuesto asignado o es no presupuestal...')");
                    Response.Write("</script>");
                    return;

                }





                //NAdmiSol.NCancelarPoliza(Convert.ToInt32(id));
                //Response.Write("<script>alert('Registro Cancelado... .')</script>");

                //RefrescaGrid();
            }
        }

        protected void CheckBoxTodos_CheckedChanged(object sender, EventArgs e)
        {


            if (CheckBoxTodos.Checked)
            {

                ddlCandidato.Enabled = true;
                ddlColectivaDetalle.Enabled = true;
                ddlConcepto.Enabled = true;
                ddlDistrito.Enabled = true;
                ddlDocumento.Enabled = true;
                ddlColectivaDetalle.Enabled = true;
                ddlEventoEspecifico.Enabled = true;
                ddlPeriodo.Enabled = true;
                ddlTipoGasto.Enabled = true;


                CargaPeriodo();
                CargaColectivaDetalle(IdUsuarioGlobal);
                CargaEventoEspecifico(0, 0, 0, 0, 0);
                CargaDistrito(0, 0,IdUsuarioGlobal );
                CargaCandidato(0, 0, 0, IdUsuarioGlobal);
                CargaConcepto(0);
                CargaEvento(0, 0);
                CargaDocumento(0, 0, 0);
                //CargaEvento(0);
            }

            else

            {
                ddlCandidato.Enabled = false;
                ddlColectivaDetalle.Enabled = false;
                ddlConcepto.Enabled = false;
                ddlDistrito.Enabled = false;
                ddlDocumento.Enabled = false;
                ddlColectivaDetalle.Enabled = false;
                ddlEventoEspecifico.Enabled = false;
                ddlPeriodo.Enabled = false;
                ddlTipoGasto.Enabled = false;


                //ddlCandidato.Text = "";
                //ddlColectivaDetalle.Text = "";
                //ddlConcepto.Text = "";
                //ddlDistrito.Text = "";
                //ddlDocumento.Text = "";
                //ddlColectivaDetalle.Text = "";
                //ddlEventoEspecifico.Text = "";

            }




            //CargaDistrito(0, 0);
            //CargaCandidato(0, 0, 0,IdUsuarioGlobal);
            //CargaEvento(0);
            //CargaDocumento(0,0,0);
            //CargaConcepto(0);
            //CargaEventoEspecifico(0, 0, 0, 0, 0);
            //CargaTipoDocumento();
            //CargaPeriodo();
            //CargaColectivaDetalle(IdUsuarioGlobal);


        }

       
    }
}
