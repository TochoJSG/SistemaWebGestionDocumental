using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace WebEpSIF
{
    public partial class WebReporteSolicitudPago : System.Web.UI.Page
    {

        WebEpSIF.NEGOCIO.NAdministraSolicitudes NAdmiSol = new WebEpSIF.NEGOCIO.NAdministraSolicitudes();

        protected void Page_Load(object sender, EventArgs e)
        {

            crSolicitudPago report = new crSolicitudPago();
            report.SetDataSource(NAdmiSol.NCargaReporteSolicitudPago(Convert.ToInt32(Session["IdSolicitud"])));
            CrystalReportViewer1.ReportSource = report;
            CrystalReportViewer1.RefreshReport();

            //////rptSolicitud Reporte = new rptSolicitud();

            //////Reporte.SetParameterValue("@li_SolPago", "200142");

            //////CrystalReportViewer1.ReportSource = Reporte;
            //CrystalDecisions.Shared.ParameterField param = new CrystalDecisions.Shared.ParameterField();
            //param.ParameterFieldName = "li_SolPago";

            ////
            //// creo el valor que se asignara al parametro
            ////
            //CrystalDecisions.Shared.ParameterDiscreteValue discreteValue = new CrystalDecisions.Shared.ParameterDiscreteValue();
            //discreteValue.Value = "200142";
            //param.CurrentValues.Add(discreteValue);

            ////
            //// Asigno el paramametro a la coleccion
            ////
            //CrystalDecisions.Shared.ParameterFields paramFiels = new CrystalDecisions.Shared.ParameterFields();
            //paramFiels.Add(param);

            ////
            //// Asigno la coleccion de parametros al Crystal Viewer
            ////
            //CrystalReportViewer1.ParameterFieldInfo = paramFiels;

            ////
            //// Creo la instancia del reporte
            ////
            //rptSolicitud report = new rptSolicitud();

            ////
            //// Cambio el path de la base de datos
            ////
            //string rutadb = "SIFWEB";
            //string CadenaConexion = @"Data Source=ABSRODRIGOG\SQLSERVER2016;Initial Catalog=SIFWEB;Persist Security Info=True;User ID=USUARIO200wEmFKEHOz$UEM;Password=a";

            //report.DataSourceConnections[0].SetConnection(CadenaConexion, rutadb, false);

            ////
            //// Asigno el reporte a visor
            ////


            //CrystalReportViewer1.ReportSource = report;







        }

        

        }
    }
