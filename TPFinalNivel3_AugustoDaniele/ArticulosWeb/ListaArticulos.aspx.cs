using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
namespace ArticulosWeb
{
    public partial class About : Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

                    if (!Seguridad.esAdmin(Session["cliente"]))
                    {
                        Session.Add("error", "Se requiere permiso de admin");
                        Response.Redirect("Error.aspx", false);
                    }
                    try
                    {

                        if (!IsPostBack)
                        {
                   
                            ArticuloNegocio negocio = new ArticuloNegocio();
                            List<Articulos> listaArticulos = negocio.listar();


                            CategoriaNegocio Categorianegocio = new CategoriaNegocio();
                            List<Categorias> listaCategoria = Categorianegocio.listar();

                            MarcaNegocio Marcasnegocio = new MarcaNegocio();
                            List<Marcas> listaMarcas = Marcasnegocio.listar();

                            
                            Session.Add("listaArticulos", negocio.listar());

                            dgvArticulos.DataSource = Session["listaArticulos"];
                            dgvArticulos.DataBind();

                   
                

                            ddlCategoria.DataSource = listaCategoria;
                            ddlCategoria.DataValueField = "Id";
                            ddlCategoria.DataTextField = "Descripcion";
                            ddlCategoria.DataBind();

                            ddlMarca.DataSource = listaMarcas;
                            ddlMarca.DataValueField = "Id";
                            ddlMarca.DataTextField = "Descripcion";
                            ddlMarca.DataBind();
                        }


                        string id = Request.QueryString["idArt"] != null ? Request.QueryString["idArt"].ToString() : "";
                        if (id != "" && !IsPostBack)
                        {
                            ArticuloNegocio negocio = new ArticuloNegocio();
                            Articulos seleccionado = (negocio.listar(id))[0];

                               


                            Session.Add("articuloSeleccionado", seleccionado);

                            txtCodigo.Text = seleccionado.CodigoArt;
                            txtNombre.Text = seleccionado.NombreArt;
                            txtDescripcion.Text = seleccionado.DescripcionArt;
                            txtImagenUrl.Text = seleccionado.ImagenUrl;
                            txtPrecio.Text = seleccionado.PrecioArt.ToString();

                            ddlCategoria.SelectedValue = seleccionado.IdCategorias.Id.ToString();
                            ddlMarca.SelectedValue = seleccionado.IdMarca.Id.ToString();
                  
                            txtImagenUrl_TextChanged(sender, e);

                 
                        }
                    }
                    catch (Exception ex)
                    {
                        Session.Add("error", ex);
                        throw;
                    }

            
            


        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }
       

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string idArticulo = Session["IdArticuloSeleccionado"] as string;

                Articulos nuevo = new Articulos();
                ArticuloNegocio negocio = new ArticuloNegocio();
                Categorias categoriaNuevo = new Categorias();
                CategoriaNegocio Categorianegocio = new CategoriaNegocio();

                if (!string.IsNullOrEmpty(idArticulo))
                {
                    nuevo.IdArt = int.Parse(idArticulo);
                }

                nuevo.CodigoArt = txtCodigo.Text;
                nuevo.NombreArt = txtNombre.Text;
                nuevo.DescripcionArt = txtDescripcion.Text;
                nuevo.ImagenUrl = txtImagenUrl.Text;
                nuevo.PrecioArt = Decimal.Parse(txtPrecio.Text);
                nuevo.IdMarca = new Marcas();
                nuevo.IdMarca.Id = int.Parse(ddlMarca.SelectedValue);
                nuevo.IdCategorias = new Categorias();
                nuevo.IdCategorias.Id = int.Parse(ddlCategoria.SelectedValue);
                nuevo.Activo = int.Parse(txtActivo.Text);

                if (!string.IsNullOrEmpty(idArticulo))
                {
                    negocio.modificar(nuevo);
                }
                else
                {
                    negocio.agregar(nuevo);
                }

                Response.Redirect("ListaArticulos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void btnEliminarLogico_Click(object sender, EventArgs e)
        {
            try
            {
                int idArticulo = int.Parse(((ImageButton)sender).CommandArgument);

                ArticuloNegocio negocio = new ArticuloNegocio();
                negocio.eliminarLogico(idArticulo,0);

                Response.Redirect("ListaArticulos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int idArticulo = int.Parse(((ImageButton)sender).CommandArgument);

                ArticuloNegocio negocio = new ArticuloNegocio();
                negocio.eliminarFisico(idArticulo);

                Response.Redirect("ListaArticulos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void btnRestaurar_Click(object sender, EventArgs e)
        {
            try
            {
                int idArticulo = int.Parse(((ImageButton)sender).CommandArgument);

                ArticuloNegocio negocio = new ArticuloNegocio();
                negocio.eliminarLogico(idArticulo, 1);

                Response.Redirect("ListaArticulos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }


        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
               

                string idArticulo = ((ImageButton)sender).CommandArgument;
                    ArticuloNegocio negocio = new ArticuloNegocio();
                  
                    List<Articulos> listaArticulos = negocio.listar();
                    Articulos seleccionado = listaArticulos.FirstOrDefault(a => a.IdArt.ToString() == idArticulo);
         

                    txtCodigo.Text = seleccionado.CodigoArt;
                    txtNombre.Text = seleccionado.NombreArt;
                    txtDescripcion.Text = seleccionado.DescripcionArt;
                    //ddlCategoria.SelectedValue = seleccionado.IdCategorias.ToString();
                    //ddlMarca.SelectedValue = seleccionado.IdMarca.ToString();
                    txtImagenUrl.Text = seleccionado.ImagenUrl;
                    txtPrecio.Text = seleccionado.PrecioArt.ToString();
                    txtActivo.Text = seleccionado.Activo.ToString();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#myModal').modal();", true);

                    Session["IdArticuloSeleccionado"] = idArticulo;

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }

    
        }

        //private void LimpiarModal()
        //{
        //    // Borra los valores de los campos del modal
        //    txtCodigo.Text = string.Empty;
        //    txtNombre.Text = string.Empty;
        //    txtDescripcion.Text = string.Empty;
        //    //ddlCategoria.ClearSelection();
        //    //ddlMarca.ClearSelection();
        //    txtImagenUrl.Text = string.Empty;
        //    txtPrecio.Text = string.Empty;
        //    txtActivo.Text = string.Empty;
        //}

        protected void btnCerrarModal_Click(object sender, EventArgs e)
        {
            
        }
        protected void dgvArticulos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int activo = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Activo"));

                ImageButton btnDarDeBaja = (ImageButton)e.Row.FindControl("btnDarDeBaja");
                ImageButton btnRestaurar = (ImageButton)e.Row.FindControl("btnRestaurar");

                if (activo == 1)
                {
                    btnDarDeBaja.Visible = true;
                    btnRestaurar.Visible = false;
                }
                else
                {
                    btnDarDeBaja.Visible = false;
                    btnRestaurar.Visible = true;
                    e.Row.BackColor = System.Drawing.Color.Red;  
                }
            }
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            
            List<Articulos> lista = (List<Articulos>)Session["listaArticulos"];
            List<Articulos> listaFiltrada = lista.FindAll(x => x.CodigoArt.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvArticulos.DataSource = listaFiltrada;
            dgvArticulos.DataBind();
        }
    }
}