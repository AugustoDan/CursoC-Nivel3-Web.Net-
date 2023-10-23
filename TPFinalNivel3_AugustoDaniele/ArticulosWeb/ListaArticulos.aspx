<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="ArticulosWeb.About" %>

  
   
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .table {
            width: 100%;
            border-collapse: collapse;
            border-spacing: 0;
            font-family: Arial, sans-serif;
        }

            .table th {
                background-color: #007BFF;
                color: white;
                font-weight: bold;
                padding: 8px;
                text-align: left;
            }

            .table tr:nth-child(even) {
                background-color: #f2f2f2;
            }

            .table td, .table th {
                border: 1px solid #dddddd;
                padding: 8px;
                text-align: left;
            }

            .table img {
                cursor: pointer;
            }

                .table img:hover {
                    opacity: 0.8;
                }

        .modal-content {
            border-radius: 10px;
        }

        .modal-header {
            background-color: #007BFF;
            color: white;
            border-radius: 10px 10px 0 0;
        }

        .modal-title {
            font-size: 24px;
        }

        .modal-body {
            padding: 20px;
        }

        .form-group label {
            font-weight: bold;
            font-size: 16px;
        }

        .form-control {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
            font-size: 16px;
        }

        .btn-primary {
            background-color: #007BFF;
            border: none;
            color: white;
            padding: 10px 20px;
            border-radius: 5px;
            font-size: 18px;
        }

        .btn-default {
            background-color: #ccc;
            border: none;
            color: white;
            padding: 10px 20px;
            border-radius: 5px;
            font-size: 18px;
        }
    </style>
    <h2>Lista de Articulos</h2>
    <br />

 
       
    <div class="row">
        <div class="col-6" style="margin-left: 905px;"">
            <div class="mb-3">
                <asp:Label Text="Filtrar" runat="server" />
                <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="filtro_TextChanged" />
            </div>
        </div>
    </div>
        <br />
     <asp:GridView ID="dgvArticulos" runat="server" CssClass="table" AutoGenerateColumns="false" OnRowDataBound="dgvArticulos_RowDataBound">
        <Columns>
            <asp:BoundField DataField="IdArt" HeaderText="ID" />
            <asp:BoundField DataField="CodigoArt" HeaderText="Codigo" />
            <asp:BoundField DataField="NombreArt" HeaderText="Nombre" />
            <asp:BoundField DataField="DescripcionArt" HeaderText="Descripcion" />
            <asp:BoundField DataField="IdMarca.Descripcion" HeaderText="Marca" />
            <asp:BoundField DataField="IdCategorias.Descripcion" HeaderText="Categoria" />
            <%--<asp:BoundField DataField="ImagenUrl" HeaderText="Imagen" />--%>
            <asp:BoundField DataField="PrecioArt" HeaderText="Precio" />
            <asp:BoundField DataField="Activo" HeaderText="Activo" />

            <asp:TemplateField HeaderText="Editar">
                <ItemTemplate>
                    <asp:ImageButton ID="btnEditar" runat="server" ImageUrl="~/Imagenes/btnEditar.png" Width="20" Height="20" CommandName="Editar" OnClick="btnEditar_Click" CommandArgument='<%# Eval("IdArt") %>' data-toggle="modal" data-target="#myModal" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Dar de Baja">
                <ItemTemplate>
                    <asp:ImageButton ID="btnDarDeBaja" runat="server" ImageUrl="~/Imagenes/btnEliminar.png" Width="20" Height="20" OnClick="btnEliminarLogico_Click" CommandName="DarDeBaja" CommandArgument='<%# Eval("IdArt") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Restaurar">
                <ItemTemplate>
                    <asp:ImageButton ID="btnRestaurar" runat="server" ImageUrl="~/Imagenes/btnRestaurar.png" Width="20" Height="20" OnClick="btnRestaurar_Click" CommandName="Restaurar" CommandArgument='<%# Eval("IdArt") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Eliminar">
            <ItemTemplate>
                <asp:ImageButton ID="btnEliminar" runat="server" ImageUrl="~/Imagenes/btnEliminare.png" Width="20" Height="20" 
                    OnClientClick="return confirm('¿Estás seguro de eliminar el artículo?');" 
                    OnClick="btnEliminar_Click" CommandName="Eliminar" CommandArgument='<%# Eval("IdArt") %>' />
            </ItemTemplate>
        </asp:TemplateField>

        </Columns>
    </asp:GridView>

 

    <div>
        <br />
        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal">
            Agregar Articulo
        </button>

   
    </div>


   

    <div id="myModal" class="modal fade" role="dialog">
    <div class="modal-dialog">
        <div class="modal-content" style="width: 802px;">
            <div class="modal-header">
                <h4 class="modal-title">Alta de Artículo</h4>
            </div>
            <div class="modal-body">
                <div class="row">
                    <div class="col-md-6">
                        <form id="formularioArticulo">
                            <div class="form-group">
                                <label for="CodigoArt">Código:</label>
                                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />
                            </div>
                            <div class="form-group">
                                <label for="NombreArt">Nombre:</label>
                                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                            </div>
                            <div class="form-group">
                                <label for="DescripcionArt">Descripción:</label>
                                <asp:TextBox runat="server" TextMode="MultiLine" ID="txtDescripcion" CssClass="form-control" />
                            </div>
                            <div class="form-group">
                                <label for="IdCategorias">Categoría:</label>
                                <asp:DropDownList ID="ddlCategoria" CssClass="form-select" runat="server"></asp:DropDownList>
                            </div>
                         
                        </form>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="ImagenUrl">URL de la Imagen:</label>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox runat="server" ID="txtImagenUrl" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged" />
                                    <asp:Image ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png" runat="server" ID="imgArticulo" Width="25%" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="form-group">
                            <label for="PrecioArt">Precio:</label>
                            <asp:TextBox ID="txtPrecio" runat="server" />
                        </div>
                        <div class="form-group">
                            <label for="Activo">Activo:</label>
                            <asp:TextBox runat="server" ID="txtActivo" CssClass="form-control" />
                        </div>

                           <div class="form-group">
                                <label for="IdMarca">Marca:</label>
                                <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
                            </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button Text="Guardar" ID="btnGuardar" class="btn btn-primary" OnClick="btnGuardar_Click" CommandArgument='<%# Eval("IdArt") %>' runat="server" />
                <button type="button" id="btnCerrarModal" class="btn btn-default" onclick="btnCerrarModal_Click" data-dismiss="modal">Cerrar</button>
            </div>
        </div>
    </div>
</div>

</asp:Content>
