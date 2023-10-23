<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="ArticulosWeb.Registrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        h2 {
            color: #333;  
            font-size: 24px;  
        }

        label {
            font-weight: bold;  
        }

        .form-control {
            width: 100%; 
            padding: 10px;  
            margin-bottom: 15px;  
            border: 1px solid #ccc; 
            border-radius: 5px;  
        }

        .btn-primary {
            background-color: #007bff;  
            border-color: #007bff;  
            color: #fff;  
            font-weight: bold;  
            padding: 10px 20px; 
            font-size: 18px;  
        }
    </style>

    <h2>Registro</h2>

    <div class="form-group">
        <label for="txtEmail">Correo Electrónico:</label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="txtPassword">Contraseña:</label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
    </div>

    <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-primary" OnClick="btnRegistrar_Click" />

    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelar_Click" />


</asp:Content>
