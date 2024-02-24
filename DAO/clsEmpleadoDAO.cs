using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WebEpSIF.DAO
{
    public class clsEmpleadoDAO
    {
        string CadenaConexion = @"Data Source=38.17.53.107,18176;Initial Catalog=ELECCIONES2021;User Id=LAU;Password=Gar#$2021";



        public ENTIDADES.Empleado AccesoSistema(string pUser, string pPassword)
        {
            ENTIDADES.Empleado objEmpleado = null;
            SqlDataReader dr = null;
            using (SqlConnection sqlCnn = new SqlConnection(CadenaConexion))
            {

                try
                {

                    //clsConexion sqlCon = new clsConexion();
                    SqlCommand Cmd = new SqlCommand("spValidaUsuarioWeb", sqlCnn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@pUsuario", pUser);
                    Cmd.Parameters.AddWithValue("@pPassword", pPassword);
                    sqlCnn.Open();
                    dr = Cmd.ExecuteReader();
                   
                    if (dr.Read())
                    {
                        objEmpleado = new ENTIDADES.Empleado();
                        objEmpleado.IdEmpleado = Convert.ToInt32(dr["IdEmpleado"].ToString());
                        objEmpleado.Usuario = dr["Usuario"].ToString();
                        objEmpleado.Password = dr["Password"].ToString();
                        objEmpleado.Carga = Convert.ToInt32(dr["Carga"].ToString());
                        objEmpleado.Sololectura = Convert.ToInt32(dr["Soloconsulta"].ToString());
                    }
                    sqlCnn.Close(); 

                }

                catch (Exception ex)
                {
                    objEmpleado = null;
                    throw ex;
                }
                return objEmpleado;


            }


           
        
        
        }



    }
}
