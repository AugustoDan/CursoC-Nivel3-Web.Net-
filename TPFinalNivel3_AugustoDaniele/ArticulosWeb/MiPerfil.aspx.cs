using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace ArticulosWeb
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.sesionActiva(Session["cliente"]))
                    {
                        Cliente cliente = (Cliente)Session["cliente"];
                        txtEmail.Text = cliente.Email;
                        txtEmail.ReadOnly = true;
                        txtNombre.Text = cliente.Nombre;
                        txtApellido.Text = cliente.Apellido;
                        txtFechaNacimiento.Text = cliente.FechaNacimiento.ToString("yyyy-MM-dd");
                        if (!string.IsNullOrEmpty(cliente.ImagenPerfil))
                            imgNuevoPerfil.ImageUrl = "~/Images/" + cliente.ImagenPerfil;
                    }
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                    

                ClienteNegocio negocio = new ClienteNegocio();
                Cliente cliente = (Cliente)Session["cliente"];

                ////Escribir img si se cargó algo.
                if (txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + cliente.Id + ".jpg");
                    cliente.ImagenPerfil = "perfil-" + cliente.Id + ".jpg";

                }

                cliente.Nombre = txtNombre.Text;
                cliente.Apellido = txtApellido.Text;
                cliente.FechaNacimiento =  DateTime.Parse(txtFechaNacimiento.Text);

                

                Image img =  (Image)Master.FindControl("ImgAvatar");
                img.ImageUrl = "~/Images/" + cliente.ImagenPerfil;

                negocio.actualizar(cliente);


            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
    }
}