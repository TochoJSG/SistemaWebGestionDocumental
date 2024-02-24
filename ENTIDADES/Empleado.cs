using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebEpSIF.ENTIDADES

{
    public class Empleado
    {

        public int IdEmpleado { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }

        public int Carga { get; set; }

        public int Sololectura { get; set; }

        public Empleado() { }

        public Empleado(int IdEmpleado, string Usuario, string Password,int Carga, int Sololectura)
        {

            this.IdEmpleado = IdEmpleado;
            this.Usuario = Usuario;
            this.Password = Password;
            this.Carga = Carga;
            this.Sololectura = Sololectura;
        }


    }
}
