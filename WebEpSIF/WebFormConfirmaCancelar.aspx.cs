using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebEpSIF
{
    public partial class WebFormConfirmaCancelar : System.Web.UI.Page
    {

        WebEpSIF.NEGOCIO.NAdministraSolicitudes NAdmiSol = new WebEpSIF.NEGOCIO.NAdministraSolicitudes();


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(Session["IdMatriz"]);
            NAdmiSol.NCancelarPoliza(Convert.ToInt32(id));
            Response.Redirect("WebCapturaDocumentos.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebCapturaDocumentos.aspx");
        }
    }
}