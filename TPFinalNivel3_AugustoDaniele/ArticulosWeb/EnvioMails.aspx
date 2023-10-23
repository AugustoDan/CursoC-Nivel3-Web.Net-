<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EnvioMails.aspx.cs" Inherits="ArticulosWeb.EnvioMails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" style="margin-top: 50px;">
        <h1 class="text-center">Envío de Emails</h1>
        <form action="procesar_formulario.aspx" method="post">
            <div class="form-group">
                <label for="txtDestinatario">Destinatario:</label>
                <asp:TextBox ID="txtDestinatario" runat="server" CssClass="form-control" required="required"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="txtAsunto">Asunto:</label>
                <asp:TextBox ID="txtAsunto" runat="server" CssClass="form-control" required="required"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="txtMensaje">Mensaje:</label>
                <asp:TextBox ID="txtMensaje" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" required="required"></asp:TextBox>
            </div>

            <button type="submit" class="btn btn-primary">Enviar Email</button>
        </form>
    </div>
</asp:Content>