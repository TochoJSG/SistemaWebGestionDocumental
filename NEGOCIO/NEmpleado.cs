using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using WebEpSIF.ENTIDADES;
using WebEpSIF.DAO;

namespace WebEpSIF.NEGOCIO
{
    public class NEmpleado
    {
        public Empleado NValidaUsuario(string Usuario, string Password)
        {

            try
            {
                WebEpSIF.DAO.clsEmpleadoDAO FNValidaUsuario = new WebEpSIF.DAO.clsEmpleadoDAO();
                return FNValidaUsuario.AccesoSistema(Usuario, Password);
            }
            catch(Exception ex)
            {
                throw ex;
            }


        }

    }
}
