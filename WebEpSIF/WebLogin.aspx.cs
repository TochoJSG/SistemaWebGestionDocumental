using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebEpSIF
{
    public partial class WebLogin : System.Web.UI.Page
    {

        WebEpSIF.NEGOCIO.NEmpleado NEmp = new WebEpSIF.NEGOCIO.NEmpleado();


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
        protected void btnIngresar_Click1(object sender, EventArgs e)
        {
            ENTIDADES.Empleado objEmpleado = new ENTIDADES.Empleado();

            objEmpleado = NEmp.NValidaUsuario(txtUs.Text, txtPw.Text);

            try
            {


                if (objEmpleado != null)
                {
                    //Response.Write("<script>alert('USUARIO CORRECTO.')</script>");


                    if (objEmpleado.Carga == 1)
                    {

                        Session["IdUsuario"] = Convert.ToString(objEmpleado.IdEmpleado);
                        Session["UsuarioMapeado"] = Convert.ToString(objEmpleado.Usuario);


                        Session["Sololectura"] = Convert.ToString(objEmpleado.Sololectura);


                        if ((Session["IdUsuario"] == null) | (Session["UsuarioMapeado"] == null))
                        {
                            Response.Redirect("WebLogin.aspx");


                        }
                        else
                        {
                            Response.Redirect("DEfault.aspx");

                        }




                    }

                    else
                    {
                        Response.Write("<script>alert('El usuario no tiene acceso a esta funcionalidad, favor de revisar su perfil con el administrador... .')</script>");

                    }





                }

                else
                {
                    Response.Write("<script>alert('El usuarnio no existe, favor de verificar los datos de conexión...')</script>");


                }


            }
            catch
            {
                Response.Write("<script>alert('Por el momento el servidor se encuentra ocupado, favor de conectarse mas tarde...')</script>");


            }


        }

        protected void ButtonCambio_Click1(object sender, EventArgs e)
        {
            Session["Usuario"] = Convert.ToString(txtUs.Text);
            Response.Redirect("WebFormCambioPassword.aspx");
        }
    }
    }
