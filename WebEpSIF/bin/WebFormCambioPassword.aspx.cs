using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebEpSIF
{
    public partial class WebFormCambioPassword : System.Web.UI.Page
    {


        WebEpSIF.NEGOCIO.NEmpleado NEmp = new WebEpSIF.NEGOCIO.NEmpleado();

        WebEpSIF.NEGOCIO.NAdministraSolicitudes NAdmiSol = new WebEpSIF.NEGOCIO.NAdministraSolicitudes();

        string strUsuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{

               
            //}

            //txtPwActual.AutoCompleteType = AutoCompleteType.None; 
              
        }

        protected void btnIngresar_Click1(object sender, EventArgs e)
        {

            if (txtPw.Text.Length < 8)
            {
                Response.Write("<script>alert('La contraseña debe ser de 8 caracteres...')</script>");
                return;
            }




            ENTIDADES.Empleado objEmpleado = new ENTIDADES.Empleado();

            strUsuario =  Convert.ToString (Session["Usuario"]) ;

            objEmpleado = NEmp.NValidaUsuario(strUsuario, txtPwActual.Text);

            if (objEmpleado != null)
            {
                //Response.Write("<script>alert('USUARIO CORRECTO.')</script>");

                NAdmiSol.NActualizaPW(Convert.ToInt32(objEmpleado.IdEmpleado),txtPw.Text );

                Session["IdUsuario"] = Convert.ToString(objEmpleado.IdEmpleado);


                Response.Redirect("WebLogin.aspx");


            }

            else
            {
                Response.Write("<script>alert('USUARIO INCORRECTO.')</script>");


            }
        }

        protected void ButtonCambio_Click1(object sender, EventArgs e)
        {

        }
    }
}