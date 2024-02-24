using System;
using System.IO;
using System.Web.UI.WebControls;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
namespace WebEpSIF
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                if ((Session["IdUsuario"]==null)| (Session["UsuarioMapeado"] == null))
                {

                    Response.Redirect("WebLogin.aspx");
                }

                else
                {
                    IDUSUARIO.Text = Session["IdUsuario"].ToString();

                    USUARIO.Text = Session["UsuarioMapeado"].ToString();

                }


            }
        }   
        protected void ImageMap1_Click(object sender, ImageMapEventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {


            int idRegUnico = 479;

            byte[] archivo = GetById(idRegUnico);

            //string strNombreArchivo = GetNombreById(idRegUnico);

            Response.Clear();

            Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", "Manual del Usuario del Sistema de Gestión Documental.pdf"));


            Response.BinaryWrite(archivo);

            Response.End();


        }


        public static byte[] GetById(int Id)
        {



            string CadenaConexion = @"Data Source=38.17.53.107,18176;Initial Catalog=ELECCIONES2021;User Id=LAU;Password=Gar#$2021";


            SqlConnection sqlCnn = new SqlConnection(CadenaConexion);
            sqlCnn.Open();





            string query = @"SELECT archivo
                            FROM ManualUsiario
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

        
    }
}