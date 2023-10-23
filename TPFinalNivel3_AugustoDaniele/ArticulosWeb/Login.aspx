<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.cs" Inherits="ArticulosWeb.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f2f2f2;
            text-align: center;
        }

        .login-container {
            background-color: #ffffff;
            border: 1px solid #ccc;
            max-width: 300px;
            margin: 100px auto;
            padding: 20px;
            border-radius: 5px;
        }

        h2 {
            color: #333;
        }

        label {
            display: block;
            margin-bottom: 10px;
            color: #333;
        }

        input[type="text"],
        input[type="password"] {
            width: 100%;
            padding: 10px;
            margin-bottom: 20px;
            border: 1px solid #ccc;
            border-radius: 3px;
        }

        input[type="submit"] {
            background-color: #007BFF;
            color: #fff;
            padding: 10px 20px;
            border: none;
            border-radius: 3px;
            cursor: pointer;
        }

            input[type="submit"]:hover {
                background-color: #0056b3;
            }
    </style>
    <div class="login-container">
        <h2>Iniciar Sesión</h2>
        <form action="procesar_login.php" method="post">
            <label for="username">Email:</label>
            <input  id="txtUsuario" name="usuario" runat="server" ><br>

            <label for="password">Contraseña:</label>
            <input type="password" id="txtContraseña" name="password"  runat="server" ><br>

            <asp:Button Text="Ingresar" id="btnLogin" onclick="btnLogin_Click" runat="server" />
            <br />    <br />
           <asp:Button Text="Registrarse" runat="server" OnClick="RedireccionarARegistrar" />
        </form>
    </div>


</asp:Content>
