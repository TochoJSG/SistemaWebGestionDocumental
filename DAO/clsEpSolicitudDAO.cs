using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace WebEpSIF.DAO
{
    public class clsEpSolicitudDAO
    {

        public bool InsertEpSolPago(string descripcion)
        {

            clsConexion sqlCon = new clsConexion();
            try
            {
                string sqlCadena = "insert into abscolor(idcolor,color) values( 333 ,'" + descripcion + "')";
                SqlCommand sqlCmd = new SqlCommand(sqlCadena, sqlCon.getConexion());
                int Resultado = sqlCmd.ExecuteNonQuery();
                return Resultado > 0;
            }
            catch (Exception)
            {
                return false;
            }

         }





    }
}