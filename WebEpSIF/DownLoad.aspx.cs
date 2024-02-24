using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebEpSIF
{
    public partial class DownLoad : System.Web.UI.Page
    {


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






        protected void Page_Load(object sender, EventArgs e)
        {

            // Request.QueryString["id"] = "25";


           



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




        protected void Button1_Click(object sender, EventArgs e)
        {

            int idRegUnico = Convert.ToInt32(Session["IdRegistroUnico"]);

            byte[] archivo = GetById(idRegUnico);

            string strNombreArchivo = GetNombreById(idRegUnico);

            Response.Clear();

            Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", strNombreArchivo));


            Response.BinaryWrite(archivo);

            Response.End();
         





        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebGeneraSolicitud.aspx");
        }
    }
}