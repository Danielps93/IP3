<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IP3._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="form-group">
        <label for="exampleInputEmail1">CPF:</label>
        <input type="text" class="form-control" id="txtCPF" aria-describedby="emailHelp" placeholder="Digite o CPF" runat="server">
    </div>

    <button type="button" class="btn btn-primary" id="BtnConsultaDivida" onserverclick="BtnConsultaDivida_ServerClick" runat="server">Consultar Divida</button>
    <button type="button" class="btn btn-primary" id="BtnSimularNeg" onserverclick="BtnSimularNeg_ServerClick" runat="server">Simular Negociacao</button>
    <button type="button" class="btn btn-primary" id="BtnConfirmarNeg" onserverclick="BtnConfirmarNeg_ServerClick" runat="server">Confirmar Negociação</button>
    <button type="button" class="btn btn-primary" id="BtnCancelarNeg" onserverclick="BtnCancelarNeg_ServerClick" runat="server">Cancelar Negociação</button>
    <hr />
    <div>
         <asp:Label runat="server" ID="lblResultado"/>       
    </div>

</asp:Content>
