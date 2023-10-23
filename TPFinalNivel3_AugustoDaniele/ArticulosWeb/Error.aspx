<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Error.aspx.cs" Inherits="ArticulosWeb.Error" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f0f0f0;
        }

        .container {
            text-align: center;
            
        }

        .message {
            font-size: 24px;
            margin-bottom: 20px;
        }

        .login-button {
            background-color: #007BFF;
            color: #fff;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            font-size: 18px;
            cursor: pointer;
            margin-bottom: 10px;
        }

        .login-button:hover {
            background-color: #0056b3;
        }

        .register-button {
            background-color: #28a745;
            color: #fff;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            font-size: 18px;
            cursor: pointer;
        }

        .register-button:hover {
            background-color: #1d9238;
        }
    </style>
    <div class="container">
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <div class="message">
            Debes iniciar sesión o registrarte.
        </div>
        <a href="Login.aspx" class="login-button">Iniciar sesión</a>
        <a href="Registrar.aspx" class="register-button">Registrarte</a>
    </div>
</asp:Content>