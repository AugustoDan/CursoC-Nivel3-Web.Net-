<%@ Page Title="Contacto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="ArticulosWeb.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .contact-container {
            text-align: center;
            margin-top: 20px;
        }

        .page-title {
            font-size: 24px;
            color: #333;
        }

        .sub-title {
            font-size: 18px;
            color: #666;
        }

        .contact-address {
            font-size: 16px;
            margin-top: 20px;
            color: #777;
        }

        .contact-address a {
            color: #007bff;
            text-decoration: none;
        }

        .contact-address a:hover {
            text-decoration: underline;
        }
    </style>
    <div class="contact-container">
     
        <h3 class="sub-title">Bienvenido a nuestra página de contacto</h3>
        <p class="contact-address">
            Puedes encontrarnos en la siguiente dirección:
            <br />
            123 la rioja, Cordoba
            <br />
            Código Postal: 5000
            <br />
        </p>

        <p class="contact-address">
            También puedes ponerte en contacto con nosotros a través de los siguientes medios:
            <br />
            <strong>Soporte:</strong> <a href="mailto:soporte@ejemplo.com">soporte@ejemplo.com</a>
            <br />
            <strong>Marketing:</strong> <a href="mailto:marketing@ejemplo.com">marketing@ejemplo.com</a>
        </p>

        <p class="contact-address">
            Si tienes alguna pregunta, comentario o sugerencia, no dudes en escribirnos. Estamos aquí para ayudarte.
        </p>
    </div>
</asp:Content>