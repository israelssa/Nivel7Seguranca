<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="mudancasenha.aspx.cs" Inherits="Nivel7AplicacaoSeguranca.mudancasenha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {}
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td colspan="2">
                MUDANÇA DE SENHA<asp:ValidationSummary ID="ValidationSummary1" 
                    runat="server" ForeColor="#FF3300" 
                    HeaderText="Verifique os seguintes campos:" />
                </td>
        </tr>
        
        
        <tr>
            <td>
                <asp:ObjectDataSource ID="dtsUsuario" runat="server" 
                    SelectMethod="GetAllUsuarioAplicacaoPerfil" 
                    TypeName="Nivel7BLLSeguranca.UsuarioBLL"></asp:ObjectDataSource>
                </td>
            <td rowspan="2" valign="top">
                <asp:GridView ID="grdUsuario" runat="server" AutoGenerateColumns="False" 
                    DataSourceID="dtsUsuario" DataKeyNames="IDAplicacao, IDUsuario" 
                    onselectedindexchanged="grdUsuario_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField SelectText="[Selecione]" ShowSelectButton="True" />
                        <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
                        <asp:BoundField DataField="NomePerfil" HeaderText="NomePerfil" 
                            SortExpression="NomePerfil" />
                        <asp:BoundField DataField="NomeAplicacao" HeaderText="NomeAplicacao" 
                            SortExpression="NomeAplicacao" />
                    </Columns>
                </asp:GridView>
                </td>
        </tr>
        
        
        <tr>
            <td class="style1">
                Nova senha:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                    runat="server" ControlToValidate="txtNovaSenha" ErrorMessage="Nova Senha" 
                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="txtNovaSenha" runat="server" MaxLength="50" 
                    TextMode="Password"></asp:TextBox>
                <br />
                Repita Nova Senha:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                    runat="server" ErrorMessage="Repita Nova Senha" ForeColor="#FF3300" 
                    ControlToValidate="txtValidSenha">*</asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="txtValidSenha" runat="server" MaxLength="50" 
                    TextMode="Password"></asp:TextBox>
                <asp:CompareValidator ID="cvdSenha" runat="server" 
                    ControlToCompare="txtNovaSenha" ControlToValidate="txtValidSenha" 
                    ErrorMessage="Senha Incorreta."></asp:CompareValidator>
                <br />
                <asp:Button ID="btnSalvar" runat="server" Text="Salvar" 
                    onclick="btnSalvar_Click" />
                </td>
        </tr>
        </table>
</asp:Content>
