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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            ClienteNegocio negocio = new ClienteNegocio();

            try
            {
                cliente.Email = txtUsuario.Value;
                cliente.Contraseña = txtContraseña.Value;
                if (negocio.Login(cliente))
                {
                    Session.Add("cliente",cliente);
                    Response.Redirect("Default.aspx",false);
                }
                else
                {
                    Session.Add("error", "User o Pass incorrectos");
                    Response.Redirect("Error.aspx",false);
                }             
            }

            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void RedireccionarARegistrar(object sender, EventArgs e)
        {
            // Redirige a la página "Registrar.aspx"
            Response.Redirect("Registrar.aspx");
        }

    }
}