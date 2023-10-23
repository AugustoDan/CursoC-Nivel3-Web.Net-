using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppArticulos
{
    public partial class FormAltaArticulo : Form
    {
        
        private Articulos articulos = null;

        
        public FormAltaArticulo()
        {
            InitializeComponent();
        }
        public FormAltaArticulo(Articulos articulos)
        {
            InitializeComponent();
            this.articulos = articulos;
            Text = "Modificar Pokemon";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro quiere salir de la operacion", "SALIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Close();
            }
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {            
            ArticuloNegocio negocio = new ArticuloNegocio();


            try
            {
               
                    if (validarFiltro())
                        return;
               
                
                if (articulos == null)
                    articulos = new Articulos();

                articulos.CodigoArt = txtCodigo.Text;
                articulos.NombreArt = txtNombre.Text;
                articulos.DescripcionArt = txtDescripcion.Text;                              
                articulos.IdMarca = (Marcas)cboMarca.SelectedItem;
                articulos.IdCategorias = (Categorias)cboCategoria.SelectedItem;
                articulos.ImagenUrl = txtUrlImagen.Text;
                articulos.PrecioArt = decimal.Parse(txtPrecio.Text);


                if (articulos.IdArt != 0)
                {
                    negocio.modificar(articulos);
                    MessageBox.Show("Modificado exitosamente!");
                }
                else
                {
                    negocio.agregar(articulos);
                    MessageBox.Show("Agregado exitosamente!");
                   
                }
                
                Close();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString()); 
            }
        }
        public void cargarImagen(string imagen)
        {
            try
            {
                pbxArticulos.Load(imagen);
            }
            catch (Exception)
            {

                pbxArticulos.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }
        }

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrlImagen.Text);
        }

        private void FormAltaArticulo_Load(object sender, EventArgs e)
        {
            CategoriaNegocio categoriaNnegocio = new CategoriaNegocio();
            MarcaNegocio marcaNegocio = new MarcaNegocio();

            try
            {
                cboMarca.DataSource = marcaNegocio.listar();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";
                cboCategoria.DataSource = categoriaNnegocio.listar();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";

                if (articulos != null)
                {
                    txtCodigo.Text = articulos.CodigoArt;
                    txtNombre.Text = articulos.NombreArt;
                    txtDescripcion.Text = articulos.DescripcionArt;
                    txtUrlImagen.Text = articulos.ImagenUrl;
                    cargarImagen(articulos.ImagenUrl);
                    cboMarca.SelectedValue = articulos.IdMarca.Id;
                    cboCategoria.SelectedValue = articulos.IdCategorias.Id;
                    txtPrecio.Text = articulos.PrecioArt.ToString();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
       
        }

        private bool validarFiltro()
        {
            if (cboCategoria.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar categoria");
                return true;
            }
            if (cboMarca.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar marca");
                return true;
            }
            if (txtCodigo.Text == string.Empty || txtCodigo.Text == " ") 
            {
                MessageBox.Show("Por favor complete el campo codigo");
                return true;
            }
            if (txtNombre.Text == string.Empty || txtNombre.Text == " ") 
            {
                MessageBox.Show("Por favor complete el campo nombre");
                return true;
            }
            if (txtPrecio.Text == string.Empty || txtPrecio.Text == " ")
            {
                MessageBox.Show("Por favor complete el campo precio");
                return true;
            }
            if (!soloNumeros(txtPrecio.Text))
            {
                MessageBox.Show("Por favor complete el campo precio solo con numeros");
                return true;
            }


            return false;
        }

        private bool soloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if ((char.IsNumber(caracter)))
                    return true;
            }
            return false;
        } 


                
    }
}
