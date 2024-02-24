using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.UI.WebControls;

namespace WebSIF.NEGOCIO
{
    public class Selector
    {

        //public  void KeepSelection(GridView grid)
        //{
        //    //
        //    // se obtienen los id de solicitud checkeados de la pagina actual
        //    //
        //    List<int> checkedSolicitud = (from item in grid.Rows.Cast<GridViewRow>()
        //                             let check = (CheckBox)item.FindControl("chkSelection")
        //                             where check.Checked
        //                             select Convert.ToInt32(grid.DataKeys[item.RowIndex].Value)).ToList();

        //    //
        //    // se recupera de session la lista de seleccionados previamente
        //    //

        //    List<int> SolSel = new List<int>();
        //    SolSel.AddRange(checkedSolicitud);
        //    HttpContext.Current.Session["ProdSelection"] = SolSel;

        //    //HttpContext.Current.Session["ProdSelection"] = 1;
        //    List<int> SolicitudesIdSel = HttpContext.Current.Session["ProdSelection"] as List<int>;
            

        //    if (SolicitudesIdSel == null)
        //        SolicitudesIdSel = new List<int>();

        //    //
        //    // se cruzan todos los registros de la pagina actual del gridview con la lista de seleccionados,
        //    // si algun item de esa pagina fue marcado previamente no se devuelve
        //    //
        //    SolicitudesIdSel = (from item in SolicitudesIdSel
        //                        join item2 in grid.Rows.Cast<GridViewRow>()
        //                        on item equals Convert.ToInt32(grid.DataKeys[item2.RowIndex].Value) into g
        //                     where !g.Any()
        //                     select item).ToList();

        //    //
        //    // se agregan los seleccionados
        //    //
        //    SolicitudesIdSel.AddRange(checkedSolicitud);

        //    HttpContext.Current.Session["ProdSelection"] = SolicitudesIdSel;

        }

    //    public  void RestoreSelection(GridView grid)
    //    {

    //        List<int> SolicitudIdSel = HttpContext.Current.Session["ProdSelection"] as List<int>;

    //        if (SolicitudIdSel == null)
    //            return;

    //        //
    //        // se comparan los registros de la pagina del grid con los recuperados de la Session
    //        // los coincidentes se devuelven para ser seleccionados
    //        //
    //        List<GridViewRow> result = (from item in grid.Rows.Cast<GridViewRow>()
    //                                    join item2 in SolicitudIdSel
    //                                    on Convert.ToInt32(grid.DataKeys[item.RowIndex].Value) equals item2 into g
    //                                    where g.Any()
    //                                    select item).ToList();

    //        //
    //        // se recorre cada item para marcarlo
    //        //
    //        result.ForEach(x => ((CheckBox)x.FindControl("chkSelection")).Checked = true);

    //    }






    //}
}