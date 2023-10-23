using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArticulosWeb
{
    public partial class EnvioMails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            EmailService emailservice = new EmailService();
            emailservice.construirCorrero(txtDestinatario.Text, txtAsunto.Text, txtMensaje.Text);
            try
            {
                emailservice.enviarEmail();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
     
            }
            
        }
    }
}