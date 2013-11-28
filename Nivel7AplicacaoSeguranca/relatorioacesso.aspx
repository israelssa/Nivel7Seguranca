<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="relatorioacesso.aspx.cs" Inherits="Nivel7AplicacaoSeguranca.relatorioacesso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td>
                <b>HISTÓRICO DE ACESSO</b></td>
        </tr>
        <tr>
            <td>
                <b>
                <asp:TextBox ID="txtBuscar" runat="server" Width="316px"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" />
                </b>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gdvRelatorio" runat="server">
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
