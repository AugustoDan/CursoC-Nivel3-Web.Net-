using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
namespace ArticulosWeb
{
    public partial class Registrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente();
                ClienteNegocio negocio = new ClienteNegocio();
                EmailService emailService = new EmailService();

                cliente.Email = txtEmail.Text;
                cliente.Contraseña = txtPassword.Text;             
                cliente.Id = negocio.insertarNuevo(cliente);
                Session.Add("cliente", cliente);

                Response.Redirect("Default.aspx", false);
                emailService.construirCorrero(cliente.Email, "Bienvenido/a ", "Hola te damos la bienvenida a la ionics");
                emailService.enviarEmail();
                

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx"); // Redirige a Default.aspx
        }

    }
}