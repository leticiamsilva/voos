<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Voos._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
    <div class="row">
        <!-- Todos os Trajetos -->
        <h1>Trajeto - PEGAR INFO DO XML</h1>
        {trajetos.map((index, item)=> (
        <div>item.nome</div>)}
            
                
        
        <div class="col-md-3">
            <h2>Data</h2>
            <p>
                Lorem Ipsun
            </p>
        </div>
        <div class="col-md-3">
            <h2>Hora</h2>
            <p>
                Lorem Ipsun
            </p>
        </div>
    
        <div class="col-md-2">
            <h2>Voo</h2>
            <p>
                Lorem Ipsun   
            </p>
        </div>
        <!-- Cada info dos voos do trajeto-->
        <div class="col-md-2">
            <h2>Tipo</h2>
            <p>
                Lorem Ipsun
            </p>
        </div>
        <div class="col-md-2">
            <h2>Valor</h2>
            <p>
                Lorem Ipsun
            </p>
        </div>
    </div>
    </div>

</asp:Content>
