using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WebEpSIF.DAO
{
    public class clsConexion
    {


        


            public SqlConnection getConexion()
        {

            //try
            //{
            //string CadenaConexion = @"Data Source=ABSRODRIGOG\SQLSERVER2016;Initial Catalog=SISTEMAGOBIERNO;Persist Security Info=True;User ID=USUARIO200wEmFKEHOz$UEM;Password=a";
            // string CadenaConexion = @"Data Source=ABSRODRIGOG\SQLSERVER2016;Initial Catalog=DBSIIFWEB;Persist Security Info=True;User ID=USUARIO200wEmFKEHOz$UEM;Password=a";
            // string CadenaConexion = @"Data Source=mssql-18130-0.cloudclusters.net,18176;Initial Catalog=ELECCIONES2021;Persist Security Info=True;User ID=LAU;Password=Gar#$2021";

            // string CadenaConexion = @"Data Source=mssql-18130-0.cloudclusters.net,18176;Initial Catalog=ELECCIONES2021;Persist Security Info=True;User ID=LAU;Password=Gar#$2021";

            string CadenaConexion = @"Data Source=38.17.53.107,18176;Initial Catalog=ELECCIONES2021;User Id=LAU;Password=Gar#$2021";

            // < add name = "conSiif" connectionString = "Data Source=10.1.103.5\SQLSERVER2012;Initial Catalog=DBSIIF_AGS_PRUEBAS;Persist Security Info=True;User ID=USUARIOCONSULTAVHE;Password=siif#2018;Min Pool Size=500;Max Pool Size=600;Pooling=true;" />



            //string CadenaConexion = @"Data Source=FINANZASSIIF;Initial Catalog=DBSIIFPRUEBAS;Persist Security Info=True;User ID=USUARIO200wEmFKEHOz$UEM;Password=a";

            SqlConnection sqlCnn = new SqlConnection(CadenaConexion);
            
                sqlCnn.Open();
                return sqlCnn;
            
            //}

            //catch (Exception)
            //{
            //    return null;
            //}


        }

    }
}