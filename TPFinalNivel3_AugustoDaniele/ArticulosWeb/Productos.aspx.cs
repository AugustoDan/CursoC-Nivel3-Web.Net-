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
    public partial class Productos : System.Web.UI.Page
    {
        public List<Articulos> ListaArticulo { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                ListaArticulo = negocio.listar().Where(articulo => articulo.Activo != 0).ToList();
                Repetidor.DataSource = ListaArticulo;
                Repetidor.DataBind();
            }

        }


        protected void AgregarAlCarrito_Click(object sender, EventArgs e)
        {
            if (Session["cliente"] == null)
            {
                Response.Redirect("Error.aspx");
                return;  
            }


            Button btn = (Button)sender;
            decimal precio = decimal.Parse(btn.CommandArgument);
            TextBox txtCantidad = (TextBox)btn.Parent.FindControl("txtCantidad");
            int cantidad = int.Parse(txtCantidad.Text);
            decimal totalCarrito = Convert.ToDecimal(Session["TotalCarrito"] ?? 0.0);
            totalCarrito += (precio * cantidad);
            Session["TotalCarrito"] = totalCarrito;
            lblTotal.Text = totalCarrito.ToString("0.00");
        }


        protected void AumentarCantidad_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;
            int itemIndex = item.ItemIndex;
            TextBox txtCantidad = (TextBox)Repetidor.Items[itemIndex].FindControl("txtCantidad");
            int cantidad = int.Parse(txtCantidad.Text);
            cantidad++;
            txtCantidad.Text = cantidad.ToString();
        }

        protected void DisminuirCantidad_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;
            int itemIndex = item.ItemIndex;
            TextBox txtCantidad = (TextBox)Repetidor.Items[itemIndex].FindControl("txtCantidad");
            int cantidad = int.Parse(txtCantidad.Text);
            if (cantidad > 0)
            {
                cantidad--;
                txtCantidad.Text = cantidad.ToString();
            }
        }

        

    }
}