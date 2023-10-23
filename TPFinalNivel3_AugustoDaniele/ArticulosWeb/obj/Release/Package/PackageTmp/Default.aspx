<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ArticulosWeb._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="jumbotron">
            <h1>Bienvenidos a IonicsElectronic</h1>
            <p class="lead">Bienvenido a nuestra tienda en línea de productos electrónicos.</p>
        </div>
    </div>

    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <h2>Productos Destacados</h2>
                <p>
                    Explora nuestra amplia selección de productos electrónicos, desde teléfonos inteligentes hasta dispositivos de última generación.
                </p>
                <p>
                    <a class="btn btn-default" href="Productos.aspx">Expolar Productos &raquo;</a>
                </p>
            </div>
            <div class="col-md-4">
               
            </div>
            <div class="col-md-4">
                <h2>Contacto</h2>
                <p>
                    ¿Tienes alguna pregunta o comentario? ¡Contáctanos!
                </p>
                <p>
                    <a class="btn btn-default" href="Contact.aspx">Contáctanos &raquo;</a>
                </p>
            </div>
        </div>
    </div>

</asp:Content>
