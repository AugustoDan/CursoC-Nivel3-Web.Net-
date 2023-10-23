using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
namespace ArticulosWeb
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            imgAvatar.ImageUrl = "https://simg.nicepng.com/png/small/202-2022264_usuario-annimo-usuario-annimo-user-icon-png-transparent.png";

            if (!(Page is Login || Page is _Default || Page is Registrar || Page is Error || Page is Productos))
            {
                if (!Seguridad.sesionActiva(Session["cliente"]))
                {
                    Response.Redirect("Login.aspx", false);
                }
                else
                {
                    Cliente cliente = (Cliente)Session["cliente"];
                    lblUser.Text = cliente.Email;
                    if (!string.IsNullOrEmpty(cliente.ImagenPerfil))
                        imgAvatar.ImageUrl = "~/Images/" + cliente.ImagenPerfil;
                }
            }
            else
            {
                if (Seguridad.sesionActiva(Session["cliente"]))
                {
                    Cliente cliente = (Cliente)Session["cliente"];
                    lblUser.Text = cliente.Email;
                    if (!string.IsNullOrEmpty(cliente.ImagenPerfil))
                        imgAvatar.ImageUrl = "~/Images/" + cliente.ImagenPerfil;
                }
                else
                {
                    // Aquí estableces la imagen y el nombre predeterminados si no hay sesión activa
                    imgAvatar.ImageUrl = "https://simg.nicepng.com/png/small/202-2022264_usuario-annimo-usuario-annimo-user-icon-png-transparent.png";
                    lblUser.Text = "";
                }
            }            

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }

    }
}