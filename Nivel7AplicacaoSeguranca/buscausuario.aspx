<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="buscausuario.aspx.cs" Inherits="Nivel7AplicacaoSeguranca.buscausuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="style1">
        <tr>
            <td>
                <b>GERÊNCIA DE USUÁRIO</b></td>
        </tr>
        <tr>
            <td class="style2">
                <b>
                <asp:TextBox ID="TextBox1" runat="server" Width="316px"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" />
                </b>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:GridView ID="gdvBuscaUsuario" runat="server">
                    <Columns>
                        <asp:TemplateField></asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
