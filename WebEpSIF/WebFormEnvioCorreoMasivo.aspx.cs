using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace WebEpSIF
{
    public partial class WebFormEnvioCorreoMasivo : System.Web.UI.Page
    {

        Boolean estado = true;
        string merror;
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public  void ccorreo(string destinatario, string asunto, string mensaje, string cc)

        {

            MailMessage correo = new MailMessage();
            SmtpClient protocolo = new SmtpClient();
            correo.To.Add(destinatario);
            correo.CC.Add(cc);
            correo.From = new MailAddress("rodrigo.garcia.psp@gmail.com", "Rodrigo García", System.Text.Encoding.UTF8);
            correo.Subject = asunto;
            correo.SubjectEncoding = System.Text.Encoding.UTF8;
            correo.Body = mensaje;
            correo.BodyEncoding = System.Text.Encoding.UTF8;
            correo.IsBodyHtml = false;
            protocolo.Credentials = new System.Net.NetworkCredential("rodrigo.garcia.psp@gmail.com", "Gar$#90p3");
            protocolo.Port = 587;
            protocolo.Host = "smtp.gmail.com";
            protocolo.EnableSsl = true;
            try
            {
                protocolo.Send(correo);

            }
            catch (SmtpException error)
            {
                estado = false;
                merror = error.Message.ToString();

            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            ccorreo("rodrigo.garcia.psp@gmail.com", "Aviso de Avance en Carga de Evidencias","Favor de subir las evidencias..","rodrigo_grc@hotmail.com");
            if (estado)
            {
                Response.Write("El correo se envio");

            }
            else

            {
                Response.Write("Error al enviar...<br>" + merror);
            }


        }
    }
}