using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Net.Mail;
namespace WebEpSIF
{
    public partial class WebFormAltaSolPagoEnc : System.Web.UI.Page
    {

        WebEpSIF.NEGOCIO.NAdministraSolicitudes NAdmiSol = new WebEpSIF.NEGOCIO.NAdministraSolicitudes();

        int pIdEjercicioPresupuestal;
        int IdUsuarioGlobal; 
        int pIdDependencia = 0;
        int pIdevento = 0;
        int pIdColectiva = 0;
        int pIdSolicitud = 0;
        Boolean estado = true;
        string merror;

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {

                //IdUsuarioGlobal = Convert.ToInt32(Session["IdUsuario"]);
                //pIdEjercicioPresupuestal = Convert.ToInt32(Session["IdEjercicioPresupuestal"]);
                //CargaDependenciaEncabezado();
                //CargaEventoEncabezado();
                //ddlFuenteFinanciamiento.Items.Insert(0, new ListItem("[SELECCIONAR EL CONCEPTO...]", "0"));
                //ddlBeneficiario.Items.Insert(0, new ListItem("[SELECCIONAR EL BENEFICIARIO...]", "0"));
                CargaEstadoMatriz();
                Label3.Visible = false;

            }

            //if (Session["IdUsuario"] != null && Session["pIdEjercicioPresupuestal"] != null)
            //{
            //    IdUsuarioGlobal = Convert.ToInt32(Session["IdUsuario"]);
            //    pIdEjercicioPresupuestal = Convert.ToInt32(Session["pIdEjercicioPresupuestal"]);

            //}


        }

        protected void btnGuardarEncabezado_Click(object sender, EventArgs e)
        {

            //pIdDependencia = Convert.ToInt32(ddlDependencia.SelectedValue);
            //pIdevento = Convert.ToInt32(ddlEventoGenerico.SelectedValue);
            //int pIdBeneficiario = Convert.ToInt32(ddlBeneficiario.SelectedValue);
            //int pIdComprometido = Convert.ToInt32(ddlNumeroComprometido.SelectedValue);
            //int pIdFuenteFinanciamiento  = Convert.ToInt32(ddlFuenteFinanciamiento.SelectedValue);
            //int pIdCuentaBancaria = Convert.ToInt32(ddlCLABECuenta.SelectedValue);
            //int pGenComprometido = 1;
            //DateTime dd = DateTime.Now;
            //int pMes =  Convert.ToInt32(dd.Month);
            //string pFechaGlobal = dd.ToShortDateString();
            //pIdEjercicioPresupuestal = Convert.ToInt32(Session["IdEjercicioPresupuestal"]);

            //if (pIdComprometido == 0)
            //{
            //    pGenComprometido = 1;

            //}
            //else
            //{
            //    pGenComprometido = 0;
            //}

            //pIdSolicitud = NAdmiSol.NInsertaEncabezadoSolicitud(pIdBeneficiario , pIdevento, pIdDependencia, pGenComprometido, pIdComprometido, pIdFuenteFinanciamiento,0, pIdCuentaBancaria, pMes, txtConcepto.Text.ToUpper(), txtBeneficiarioCheque.Text, pFechaGlobal, pIdEjercicioPresupuestal);
            //Session["IdSolicitud"] = pIdSolicitud;
            //Session["IdEvento"] = pIdevento;
            //Session["IdColectiva"] = pIdBeneficiario;
            //Response.Redirect("WebGeneraSolicitud.aspx?");
        }


        protected void CargaDependenciaEncabezado()
        {
            //ddlDependencia.DataSource = NAdmiSol.NCargaDependenciaEncbezado(30, pIdEjercicioPresupuestal, IdUsuarioGlobal);
            //ddlDependencia.DataTextField = "Descripcion";
            //ddlDependencia.DataValueField = "IdDependencia";
            //ddlDependencia.DataBind();
            //ddlDependencia.Items.Insert(0, new ListItem("[SELECCIONAR LA DEPENDENCIA...]", "0"));


        }


        protected void CargaEventoEncabezado()
        {
            //ddlEventoGenerico.DataSource = NAdmiSol.NCargaEventoGenericoEncabezado();
            //ddlEventoGenerico.DataTextField = "EventoGenerico";
            //ddlEventoGenerico.DataValueField = "IdEvento";
            //ddlEventoGenerico.DataBind();
            //ddlEventoGenerico.Items.Insert(0, new ListItem("[SELECCIONAR EL EVENTO GENERICO...]", "0"));



        }


        protected void CargaComprometidoEvento(int pIdEjercicioPresupuestal, int pIdDependencia,int  pIdevento)
        {


            //ddlNumeroComprometido.DataSource = NAdmiSol.NCargaComprometidoEvento(pIdEjercicioPresupuestal, pIdDependencia, pIdevento);
            //ddlNumeroComprometido.DataTextField = "NumComprometido";
            //ddlNumeroComprometido.DataValueField = "IdComp";
            //ddlNumeroComprometido.DataBind();
            //ddlNumeroComprometido.Items.Insert(0, new ListItem("[SELECCIONAR LA JUSTIFICACION...]", "0"));


        }


        protected void CargaBeneficiarioEncabezado(int pIdEvento, string pBeneficiario)
        {

           



        }


        protected void CargaCandidatoMatriz(int pIdEstado)
        {
            ddlCandidato.DataSource = NAdmiSol.NCargaCandidatoMatriz(pIdEstado);
            ddlCandidato.DataTextField = "Candidato";
            ddlCandidato.DataValueField = "IdCandidato";
            ddlCandidato.DataBind();
            ddlCandidato.Items.Insert(0, new ListItem("[SELECCIONAR EL CANDIDATO...]", "0"));


        }

        protected void CargaEstadoMatriz()
        {
            ddlEstado .DataSource = NAdmiSol.NCargaEstadoMatriz();
            ddlEstado.DataTextField = "Estado";
            ddlEstado.DataValueField = "IdEstado";
            ddlEstado.DataBind();
            ddlEstado.Items.Insert(0, new ListItem("[SELECCIONAR EL ESTADO...]", "0"));


        }








        void RefrescaGrid()
        {

           

            GridViewMatriz.DataSource = null;
            GridViewMatriz.DataBind();
            IdUsuarioGlobal = Convert.ToInt32(Session["IdUsuario"]);
            //gvDetalleSolicitud.AutoGenerateSelectButton = true;
            GridViewMatriz.DataSource = NAdmiSol.NCargaMatrizArchivos(Convert.ToInt32(ddlCandidato.SelectedValue));
            GridViewMatriz.DataBind();

            GridViewMatriz.Columns[1].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            GridViewMatriz.Columns[2].ItemStyle.HorizontalAlign = HorizontalAlign.Center;

            GridViewMatriz.Columns[3].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            GridViewMatriz.Columns[4].ItemStyle.HorizontalAlign = HorizontalAlign.Center;

            GridViewMatriz.Columns[5].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            GridViewMatriz.Columns[6].ItemStyle.HorizontalAlign = HorizontalAlign.Center;

            GridViewMatriz.Columns[7].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            GridViewMatriz.Columns[8].ItemStyle.HorizontalAlign = HorizontalAlign.Center;

            GridViewMatriz.Columns[9].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            GridViewMatriz.Columns[10].ItemStyle.HorizontalAlign = HorizontalAlign.Center;

            GridViewMatriz.Columns[11].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            GridViewMatriz.Columns[12].ItemStyle.HorizontalAlign = HorizontalAlign.Center;

            GridViewMatriz.Columns[13].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            GridViewMatriz.Columns[14].ItemStyle.HorizontalAlign = HorizontalAlign.Center;

            GridViewMatriz.Columns[15].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            GridViewMatriz.Columns[16].ItemStyle.HorizontalAlign = HorizontalAlign.Center;

            GridViewMatriz.Columns[17].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            GridViewMatriz.Columns[18].ItemStyle.HorizontalAlign = HorizontalAlign.Center;

            GridViewMatriz.Columns[19].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
           
            //GridViewMatriz.Columns[11].ItemStyle.HorizontalAlign = HorizontalAlign.Center;


        }


        protected void CargaConceptoSol(int pIdEvento)
        {
            //ddlFuenteFinanciamiento.DataSource = NAdmiSol.NCargaConceptoSol(pIdEvento);
            //ddlFuenteFinanciamiento.DataTextField = "Concepto";
            //ddlFuenteFinanciamiento.DataValueField = "IdConceptoSol";
            //ddlFuenteFinanciamiento.DataBind();
            //ddlFuenteFinanciamiento.Items.Insert(0, new ListItem("[SELECCIONAR EL CONCEPTO...]", "0"));

        }

        protected void GridViewMatriz_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void ccorreo(string destinatario, string asunto, string mensaje, string cc)

        {

            MailMessage correo = new MailMessage();
            SmtpClient protocolo = new SmtpClient();
            correo.To.Add(destinatario);
            correo.CC.Add(cc);
            correo.From = new MailAddress("rodrigo.garcia.psp@gmail.com", "Rodrigo García", System.Text.Encoding.UTF8);
            correo.Subject = asunto;
            correo.SubjectEncoding = System.Text.Encoding.UTF8;
            correo.Body = mensaje;
            correo.BodyEncoding = System.Text.Encoding.UTF8;
            correo.IsBodyHtml = false;
            protocolo.Credentials = new System.Net.NetworkCredential("rodrigo.garcia.psp@gmail.com", "Gar$#90p3");
            protocolo.Port = 587;
            protocolo.Host = "smtp.gmail.com";
            protocolo.EnableSsl = true;
            try
            {
                protocolo.Send(correo);

            }
            catch (SmtpException error)
            {
                estado = false;
                merror = error.Message.ToString();

            }
        }

        protected void btnEnvioCorreo_Click(object sender, EventArgs e)
        {
            ccorreo("rodrigo.garcia.psp@gmail.com", "Aviso de Avance en Carga de Evidencias", "Favor de subir las evidencias..", "rodrigo_grc@hotmail.com");
            if (estado)
            {
                Label3.Visible = true;
                Label3.Text = "   Correo Enviado...     ";

            }
            else

            {
                Response.Write("Error al enviar...<br>" + merror);
            }

            //oscarruiz_a@hotmail.com
            // othoniel.godoy@rcconsulting.mx
            //acoconsultor@rcconsulting.mx

            //lauralau.gama@gmail.com
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }


        protected void ExportToExcel()
        {
            //Response.Clear();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            //Response.Charset = "";
            //Response.ContentType = "application/vnd.ms-excel";
            //using (System.IO.StringWriter sw = new System.IO.StringWriter())
            //{
            //    HtmlTextWriter hw = new HtmlTextWriter(sw);

            //    GridViewMatriz.AllowPaging = true;

            //    GridViewMatriz.HeaderRow.BackColor = Color.White;
            //    foreach (TableCell cell in GridViewMatriz.HeaderRow.Cells)
            //    {
            //        cell.BackColor = GridViewMatriz.HeaderStyle.BackColor;
            //    }
            //    foreach (GridViewRow row in GridViewMatriz.Rows)
            //    {
            //        row.BackColor = Color.White;
            //        foreach (TableCell cell in row.Cells)
            //        {
            //            if (row.RowIndex % 2 == 0)
            //            {
            //                cell.BackColor = GridViewMatriz.AlternatingRowStyle.BackColor;
            //            }
            //            else
            //            {
            //                cell.BackColor = GridViewMatriz.RowStyle.BackColor;
            //            }
            //            cell.CssClass = "textmode";
            //        }
            //    }

            //    GridViewMatriz.RenderControl(hw);

            //    //style to format numbers to string
            //    string style = @"<style> .textmode { } </style>";
            //    Response.Write(style);
            //    Response.Output.Write(sw.ToString());
            //    Response.Flush();
            //    Response.End();
            //}

            Response.Clear();

            
            Response.AddHeader("content-disposition", "attachment;filename = "  + ddlCandidato.SelectedItem.Text + ".xls");
            Response.ContentType = "application/xls";

            System.IO.StringWriter stringWriter = new System.IO.StringWriter();

            System.Web.UI.HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
            GridViewMatriz.RenderControl(htmlTextWriter);
            Response.Write(stringWriter.ToString());

            Response.End();







        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void GridViewMatriz_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           if(e.Row.RowType == DataControlRowType.DataRow )
            {

                e.Row.Cells[0].ForeColor = System.Drawing.Color.White;
                e.Row.Cells[1].ForeColor = System.Drawing.Color.White;

                string  Concepto = DataBinder.Eval(e.Row.DataItem, "Concepto").ToString();

                if (Concepto == "AGENDA DEL CANDIDATO")

                {
                    e.Row.Cells[0].BackColor = System.Drawing.Color.DarkTurquoise;
                    e.Row.Cells[1].BackColor = System.Drawing.Color.DarkTurquoise;
                    

                }

                if (Concepto == "ACTAS DE VERIFICACIÓN")

                {
                    e.Row.Cells[0].BackColor = System.Drawing.Color.Coral;
                    e.Row.Cells[1].BackColor = System.Drawing.Color.Coral;


                }

                if (Concepto == "TRANSFERENCIAS BANCARIAS")

                {

                    e.Row.Cells[0].BackColor = System.Drawing.Color.Gold;
                    e.Row.Cells[1].BackColor = System.Drawing.Color.Gold;


                }



                if (Concepto == "APORTACIONES EN ESPECIE DEL PARTIDO")

                {

                    e.Row.Cells[1].BackColor = System.Drawing.Color.LimeGreen;
                    e.Row.Cells[0].BackColor = System.Drawing.Color.LimeGreen;

                }

                if (Concepto == "GASTO DIRECTO")

                {

                    e.Row.Cells[1].BackColor = System.Drawing.Color.RoyalBlue;
                    e.Row.Cells[0].BackColor = System.Drawing.Color.RoyalBlue;

                }


                if (Concepto == "APORTACIONES EN ESPECIE")

                {

                    e.Row.Cells[1].BackColor = System.Drawing.Color.Orange;
                    e.Row.Cells[0].BackColor = System.Drawing.Color.Orange;

                }





                int factura = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CANTIDADFACTURAPDF").ToString());  
                if(factura <0)
                {

                    e.Row.Cells[2].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[2].BackColor = System.Drawing.Color.White;
                }
                if (factura == 0)
                {

                    e.Row.Cells[2].ForeColor = System.Drawing.Color.White  ;
                    e.Row.Cells[2].BackColor = System.Drawing.Color.Pink;
                }
                if (factura > 0)
                {

                    e.Row.Cells[2].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[2].BackColor = System.Drawing.Color.GreenYellow;
                }


                int xmlCol = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CANTIDADXML").ToString());
                if (xmlCol < 0)
                {

                    e.Row.Cells[3].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[3].BackColor = System.Drawing.Color.White;
                }
                if (xmlCol == 0)
                {

                    e.Row.Cells[3].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[3].BackColor = System.Drawing.Color.Pink;
                }
                if (xmlCol > 0)
                {

                    e.Row.Cells[3].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[3].BackColor = System.Drawing.Color.GreenYellow;
                }

                int pago = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CANTIDADPAG").ToString());
                if (pago < 0)
                {

                    e.Row.Cells[4].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[4].BackColor = System.Drawing.Color.White;
                }
                if (pago == 0)
                {

                    e.Row.Cells[4].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[4].BackColor = System.Drawing.Color.Pink;
                }
                if (pago > 0)
                {

                    e.Row.Cells[4].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[4].BackColor = System.Drawing.Color.GreenYellow;
                }

                int contrato = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CANTIDADCON").ToString());
                if (contrato < 0)
                {

                    e.Row.Cells[5].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[5].BackColor = System.Drawing.Color.White;
                }
                if (contrato == 0)
                {

                    e.Row.Cells[5].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[5].BackColor = System.Drawing.Color.Pink;
                }
                if (contrato > 0)
                {

                    e.Row.Cells[5].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[5].BackColor = System.Drawing.Color.GreenYellow;
                }


                int avisoc = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CANTIDADAVC").ToString());
                if (avisoc < 0)
                {

                    e.Row.Cells[6].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[6].BackColor = System.Drawing.Color.White;
                }
                if (avisoc == 0)
                {

                    e.Row.Cells[6].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[6].BackColor = System.Drawing.Color.Pink;
                }
                if (avisoc > 0)
                {

                    e.Row.Cells[6].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[6].BackColor = System.Drawing.Color.GreenYellow;
                }


                int avisou = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CANTIDADAUV").ToString());
                if (avisou < 0)
                {

                    e.Row.Cells[7].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[7].BackColor = System.Drawing.Color.White;
                }
                if (avisou == 0)
                {

                    e.Row.Cells[7].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[7].BackColor = System.Drawing.Color.Pink;
                }
                if (avisou > 0)
                {

                    e.Row.Cells[7].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[7].BackColor = System.Drawing.Color.GreenYellow;
                }

                int imf = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CANTIDADIMF").ToString());
                if (imf < 0)
                {

                    e.Row.Cells[8].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[8].BackColor = System.Drawing.Color.White;
                }
                if (imf == 0)
                {

                    e.Row.Cells[8].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[8].BackColor = System.Drawing.Color.Pink;
                }
                if (imf > 0)
                {

                    e.Row.Cells[8].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[8].BackColor = System.Drawing.Color.GreenYellow;
                }


                int hom = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CANTIDADHOM").ToString());
                if (hom < 0)
                {

                    e.Row.Cells[9].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[9].BackColor = System.Drawing.Color.White;
                }
                if (hom == 0)
                {

                    e.Row.Cells[9].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[9].BackColor = System.Drawing.Color.Pink;
                }
                if (imf > 0)
                {

                    e.Row.Cells[9].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[9].BackColor = System.Drawing.Color.GreenYellow;
                }


                int cre = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CANTIDADCRE").ToString());
                if (cre < 0)
                {

                    e.Row.Cells[10].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[10].BackColor = System.Drawing.Color.White;
                }
                if (cre == 0)
                {

                    e.Row.Cells[10].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[10].BackColor = System.Drawing.Color.Pink;
                }
                if (cre > 0)
                {

                    e.Row.Cells[10].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[10].BackColor = System.Drawing.Color.GreenYellow;
                }

                int rei = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CANTIDADREI").ToString());
                if (rei < 0)
                {

                    e.Row.Cells[11].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[11].BackColor = System.Drawing.Color.White;
                }
                if (rei == 0)
                {

                    e.Row.Cells[11].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[11].BackColor = System.Drawing.Color.Pink;
                }
                if (rei > 0)
                {

                    e.Row.Cells[11].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[11].BackColor = System.Drawing.Color.GreenYellow;
                }

                int pec = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CANTIDADPEC").ToString());
                if (pec < 0)
                {

                    e.Row.Cells[12].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[12].BackColor = System.Drawing.Color.White;
                }
                if (pec == 0)
                {

                    e.Row.Cells[12].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[12].BackColor = System.Drawing.Color.Pink;
                }
                if (pec > 0)
                {

                    e.Row.Cells[12].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[12].BackColor = System.Drawing.Color.GreenYellow;
                }


                int kar = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CANTIDADKAR").ToString());
                if (kar < 0)
                {

                    e.Row.Cells[13].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[13].BackColor = System.Drawing.Color.White;
                }
                if (kar == 0)
                {

                    e.Row.Cells[13].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[13].BackColor = System.Drawing.Color.Pink;
                }
                if (kar > 0)
                {

                    e.Row.Cells[13].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[13].BackColor = System.Drawing.Color.GreenYellow;
                }

                int rep = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CANTIDADREP").ToString());
                if (rep < 0)
                {

                    e.Row.Cells[14].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[14].BackColor = System.Drawing.Color.White;
                }
                if (rep == 0)
                {

                    e.Row.Cells[14].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[14].BackColor = System.Drawing.Color.Pink;
                }
                if (rep > 0)
                {

                    e.Row.Cells[14].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[14].BackColor = System.Drawing.Color.GreenYellow;
                }

                int cot = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CANTIDADCOT").ToString());
                if (cot < 0)
                {

                    e.Row.Cells[15].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[15].BackColor = System.Drawing.Color.White;
                }
                if (cot == 0)
                {

                    e.Row.Cells[15].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[15].BackColor = System.Drawing.Color.Pink;
                }
                if (cot > 0)
                {

                    e.Row.Cells[15].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[15].BackColor = System.Drawing.Color.GreenYellow;
                }

                int exp = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CANTIDADEXP").ToString());
                if (exp < 0)
                {

                    e.Row.Cells[16].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[16].BackColor = System.Drawing.Color.White;
                }
                if (exp == 0)
                {

                    e.Row.Cells[16].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[16].BackColor = System.Drawing.Color.Pink;
                }
                if (exp > 0)
                {

                    e.Row.Cells[16].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[16].BackColor = System.Drawing.Color.GreenYellow;
                }


                int otr = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CANTIDADOTR").ToString());
                if (otr < 0)
                {

                    e.Row.Cells[17].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[17].BackColor = System.Drawing.Color.White;
                }
                if (otr == 0)
                {

                    e.Row.Cells[17].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[17].BackColor = System.Drawing.Color.Pink;
                }
                if (otr > 0)
                {

                    e.Row.Cells[17].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[17].BackColor = System.Drawing.Color.GreenYellow;
                }

                int rlp = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CANTIDADRLP").ToString());
                if (rlp < 0)
                {

                    e.Row.Cells[18].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[18].BackColor = System.Drawing.Color.White;
                }
                if (rlp == 0)
                {

                    e.Row.Cells[18].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[18].BackColor = System.Drawing.Color.Pink;
                }
                if (rlp > 0)
                {

                    e.Row.Cells[18].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[18].BackColor = System.Drawing.Color.GreenYellow;
                }


                int esc = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CANTIDADESC").ToString());
                if (esc < 0)
                {

                    e.Row.Cells[19].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[19].BackColor = System.Drawing.Color.White;
                }
                if (esc == 0)
                {

                    e.Row.Cells[19].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[19].BackColor = System.Drawing.Color.Pink;
                }
                if (esc > 0)
                {

                    e.Row.Cells[19].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[19].BackColor = System.Drawing.Color.GreenYellow;
                }












            }



        }

        protected void btnEnvioExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

       

        protected void ddlDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      

        protected void ddlEstado_SelectedIndexChanged1(object sender, EventArgs e)
        {
            CargaCandidatoMatriz(Convert.ToInt32(ddlEstado.SelectedValue));
            Label3.Visible = false;
        }

        protected void ddlCandidato_SelectedIndexChanged1(object sender, EventArgs e)
        {
            RefrescaGrid();
            Label3.Visible = false; 
        }







        //protected void ddlEventoGenerico_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    pIdevento = Convert.ToInt32(ddlEventoGenerico.SelectedValue);


        //    DataTable dtDatosEvento = new DataTable();

        //    dtDatosEvento = NAdmiSol.NCargaConfiguracionEventoGenerico(pIdevento);

        //    string PorProceso = dtDatosEvento.Rows[0]["PorProceso"].ToString();
        //    string DiasParaPago = dtDatosEvento.Rows[0]["DiasParaPago"].ToString();
        //    string Pptal = dtDatosEvento.Rows[0]["Pptal"].ToString();
        //    string Correccion = dtDatosEvento.Rows[0]["Correccion"].ToString();
        //    string ConDocumento = dtDatosEvento.Rows[0]["ConDocumento"].ToString();
        //    string CapturaBenefCheque = dtDatosEvento.Rows[0]["CapturaBenefCheque"].ToString();
        //    string AfectaPpto = dtDatosEvento.Rows[0]["AfectaPpto"].ToString();
        //    string SinPolizaEgr = dtDatosEvento.Rows[0]["SinPolizaEgr"].ToString();
        //    string afectapptocomp = dtDatosEvento.Rows[0]["afectapptocomp"].ToString();
        //    string afectapptoprecomp = dtDatosEvento.Rows[0]["afectapptoprecomp"].ToString();
        //    string afectapptoejercido = dtDatosEvento.Rows[0]["afectapptoejercido"].ToString();
        //    string FechaVirtual = dtDatosEvento.Rows[0]["FechaVirtual"].ToString();
        //    string modificabenefdoc = dtDatosEvento.Rows[0]["modificabenefdoc"].ToString();
        //    string Viatico = dtDatosEvento.Rows[0]["Viatico"].ToString();

        //    Session["PorProceso"] = PorProceso;

        //    Session["DiasParaPago"] = DiasParaPago;

        //    Session["Pptal"] = Pptal;

        //    Session["Correccion"] = Correccion;

        //    Session["ConDocumento"] = ConDocumento;

        //    Session["CapturaBenefCheque"] = CapturaBenefCheque;

        //    Session["AfectaPpto"] = AfectaPpto;

        //    Session["SinPolizaEgr"] = SinPolizaEgr;

        //    Session["afectapptocomp"] = afectapptocomp;

        //    Session["afectapptoprecomp"] = afectapptoprecomp;

        //    Session["afectapptoejercido"] = afectapptoejercido;

        //    Session["FechaVirtual"] = FechaVirtual;

        //    Session["modificabenefdoc"] = modificabenefdoc;

        //    Session["Viatico"] = Viatico;


        //    pIdDependencia = Convert.ToInt32(ddlDependencia.SelectedValue);


        //    pIdEjercicioPresupuestal = Convert.ToInt32(Session["IdEjercicioPresupuestal"]);
        //    CargaComprometidoEvento(pIdEjercicioPresupuestal, pIdDependencia, pIdevento);
        //    CargaConceptoSol(pIdevento);
        //    ddlBeneficiario.SelectedValue = "0";
        //    ddlCLABECuenta.SelectedValue = "0";
        //    ddlFuenteFinanciamiento.SelectedValue = "0";
        //    txtBuscColectiva.Text = "";

        //}


        //protected void ddlBeneficiario_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    pIdColectiva = Convert.ToInt32(ddlBeneficiario.SelectedValue);
        //    CargaCLABE(pIdColectiva);
        //    Session["IdColectiva"] = pIdColectiva;

        //}

        //protected void btnBuscar_Click(object sender, EventArgs e)
        //{
        //    pIdevento = Convert.ToInt32(ddlEventoGenerico.SelectedValue);
        //    CargaBeneficiarioEncabezado(pIdevento, txtBuscColectiva.Text);
        //    txtBuscColectiva.Text = "";
        //}

        //protected void ddlDependencia_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    pIdDependencia = Convert.ToInt32(ddlDependencia.SelectedValue);

        //    Session["IdDependencia"] = pIdDependencia;
        //}
    }
}