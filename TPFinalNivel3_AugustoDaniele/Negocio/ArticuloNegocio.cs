using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

 namespace  Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulos> listar(string id = "")
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();

   
            try
            {
                datos.setearConsulta2("sp_consulta_articulos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();

                    aux.IdArt = (int)datos.Lector["Id"];
                    aux.CodigoArt = (string)datos.Lector["Codigo"];
                    aux.NombreArt = (string)datos.Lector["Nombre"];
                    aux.DescripcionArt = (string)datos.Lector["Descripcion"];
                    aux.IdMarca= new Marcas();
                    aux.IdMarca.Id = (int)datos.Lector["IdMarca"];
                    aux.IdMarca.Descripcion = (string)datos.Lector["Marca"];           
                    aux.IdCategorias = new Categorias();
                    aux.IdCategorias.Id = (int)datos.Lector["IdCategoria"];
                    aux.IdCategorias.Descripcion = (string)datos.Lector["Categoria"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.PrecioArt = (decimal)datos.Lector["Precio"];
                    aux.Activo = (int)datos.Lector["Activo"];

                    lista.Add(aux);

                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }  
            
            
        }



        public void agregar(Articulos nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta2("sp_agregar_articulo");
                datos.setearParametros("@Codigo", nuevo.CodigoArt);
                datos.setearParametros("@Nombre", nuevo.NombreArt);
                datos.setearParametros("@Descripcion", nuevo.DescripcionArt);
                datos.setearParametros("@IdMarca", nuevo.IdMarca.Id);
                datos.setearParametros("@IdCategoria", nuevo.IdCategorias.Id);
                datos.setearParametros("@ImagenUrl", nuevo.ImagenUrl);
                datos.setearParametros("@Precio", nuevo.PrecioArt);
                datos.setearParametros("@Activo", nuevo.Activo);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }    
        }

        public void eliminarFisico (int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta2("Sp_Eliminar_Fisico");
                datos.setearParametros("@id",id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public void eliminarLogico(int id,int activo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta2("Sp_Elimina_Logico");
                datos.setearParametros("@id", id);
                datos.setearParametros("@Activo", activo);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void modificar(Articulos modificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta2("ModificarArticulo");
                datos.setearParametros("@Codigo", modificar.CodigoArt);
                datos.setearParametros("@Nombre", modificar.NombreArt);
                datos.setearParametros("@Descripcion", modificar.DescripcionArt);
                datos.setearParametros("@IdMarca", modificar.IdMarca.Id);
                datos.setearParametros("@IdCategoria", modificar.IdCategorias.Id);
                datos.setearParametros("@ImagenUrl", modificar.ImagenUrl);
                datos.setearParametros("@Precio", modificar.PrecioArt);
                datos.setearParametros("@Activo", modificar.Activo);
                datos.setearParametros("@Id", modificar.IdArt);

                datos.ejecutarAccion();


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Articulos> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "select a.Id,a.Codigo , a.Nombre ,a.Descripcion,a.IdMarca " +
                    ",m.Descripcion Marca,a.IdCategoria ,c.Descripcion Categoria, a.ImagenUrl,a.Precio " +
                    "from ARTICULOS A join CATEGORIAS C on a.IdCategoria = c.Id join Marcas m on a.IdMarca = m.Id and ";

                if (campo == "Codigo")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Codigo like '" + filtro + "%'";
                            break;
                        case "Termina con ":
                            consulta += "Codigo like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Codigo like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre like '" + filtro + "%'";
                            break;
                        case "Termina con ":
                            consulta += "Nombre like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Nombre like '%" + filtro + "%'";
                            break;
                    }
                }                

                else
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Precio > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "Precio < " + filtro;
                            break;
                        default:
                            consulta += "Precio = " + filtro;
                            break;
                    }
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();

                    aux.IdArt = (int)datos.Lector["Id"];
                    aux.CodigoArt = (string)datos.Lector["Codigo"];
                    aux.NombreArt = (string)datos.Lector["Nombre"];
                    aux.DescripcionArt = (string)datos.Lector["Descripcion"];
                    aux.IdMarca = new Marcas();
                    aux.IdMarca.Id = (int)datos.Lector["IdMarca"];
                    aux.IdMarca.Descripcion = (string)datos.Lector["Marca"];
                    aux.IdCategorias = new Categorias();
                    aux.IdCategorias.Id = (int)datos.Lector["IdCategoria"];
                    aux.IdCategorias.Descripcion = (string)datos.Lector["Categoria"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.PrecioArt = (decimal)datos.Lector["Precio"];
                    aux.Activo = (int)datos.Lector["Activo"];


                    lista.Add(aux);
                }



                return lista;
            }
            catch (Exception)
            {

                throw;
            }

            datos.cerrarConexion();
        }

    }
}
