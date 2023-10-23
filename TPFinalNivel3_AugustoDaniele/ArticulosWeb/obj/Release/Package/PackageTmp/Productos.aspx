<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Productos.aspx.cs" Inherits="ArticulosWeb.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <asp:Repeater runat="server" ID="Repetidor">
            <ItemTemplate>
                <div class="col-md-4">
                    <div class="card">
                        <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" alt="..." style="width: 250px; height: 250px;">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("CodigoArt") %></h5>
                            <p class="card-text"><%#Eval("NombreArt") %></p>
                            <p class="card-text"><%#Eval("DescripcionArt") %></p>
                            <p>Precio: $<%#Eval("PrecioArt") %></p>
                            <div class="input-group" style="width: 250px;">

                                <asp:Button runat="server" Text="Agregar al Carrito" CssClass="btn btn-primary" OnClick="AgregarAlCarrito_Click" CommandArgument='<%#Eval("PrecioArt") %>' />

                                <span class="input-group-btn" style="width: 150px;">
                                    <asp:UpdatePanel runat="server" ID="updatePanel1">
                                        <ContentTemplate>
                                            <asp:Button runat="server" Text="+" CssClass="btn btn-default" OnClick="AumentarCantidad_Click" />
                                            <asp:TextBox runat="server" ID="txtCantidad" Text="0" CssClass="form-control input-number" Style="width: 76px;" />
                                            <asp:Button runat="server" Text="-" CssClass="btn btn-default" OnClick="DisminuirCantidad_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </span>

                            </div>
                        </div>
                    </div>
                </div>

            </ItemTemplate>
        </asp:Repeater>
    </div>
    <br />
    <div id="Div1" runat="server" class="panel panel-primary">
        <div class="panel-heading">Monto Total:</div>
        <div class="panel-body">
            <asp:Label ID="lblTotal" runat="server" Text="$0.00" CssClass="label label-success"></asp:Label>
             <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#confirmModal"> Comprar</button>
        </div>
    </div>
    <br />

   
     <div>
        <br />
       

   
    </div>
    <div id="confirmModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Confirmar Compra</h4>
                </div>
                <div class="modal-body">
                    <p>¿Estás seguro de que deseas realizar la compra?</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#confirmModal1"> Confirmar</button>
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
    </div>

     <div id="confirmModal1" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">asdasd</h4>
                </div>
                <div class="modal-body">
                    <p>Felicitaciones realizaste la compra con exito</p>
                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" Text="Confirmar" CssClass="btn btn-success" />
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
    </div>

    

</asp:Content>
