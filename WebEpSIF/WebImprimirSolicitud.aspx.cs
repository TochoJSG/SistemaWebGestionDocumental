using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebEpSIF
{
    public partial class WebImprimirSolicitud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)

            {

                //lblNumeroSolicitud.Text = Convert.ToString(Session["NumeroSolicitud"]);


            }

        }

        protected void btnImprimirSolicitud_Click(object sender, EventArgs e)
        {

            Response.Redirect("WebReporteSolicitudPago.aspx?");
        }

        protected void ButtonCambio_Click1(object sender, EventArgs e)
        {

        }
    }
}