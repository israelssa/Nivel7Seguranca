<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cadastroperfil.aspx.cs" Inherits="Nivel7AplicacaoSeguranca.cadastroperfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td colspan="3">
                CADASTRO DE PERFIL</td>
        </tr>
        <tr>
            <td valign="top">
                Aplicação:<br />
            </td>
            <td valign="top">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtNomePerfil" ErrorMessage="Nome Perfil" 
                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                Nome Perfil:</td>
            <td valign="top">
                PERFIS DA APLICACAO</td>
        </tr>
        <tr>
            <td valign="top">
                <asp:DropDownList ID="ddlAplicacao" runat="server" 
                    DataSourceID="dtsAplicacao" DataTextField="NomeAplicacao" 
                    DataValueField="IDAplicacao" AutoPostBack="True" 
                    ondatabound="ddlAplicacao_DataBound" 
                    onselectedindexchanged="ddlAplicacao_SelectedIndexChanged">
                    <asp:ListItem Enabled="False" Selected="True" Value="0">[Selecione]</asp:ListItem>
                </asp:DropDownList>
                <asp:ObjectDataSource ID="dtsAplicacao" runat="server" 
                    SelectMethod="GetAllAplicacaoAtivos" TypeName="Nivel7BLLSeguranca.AplicacaoBLL">
                </asp:ObjectDataSource>
            </td>
            <td valign="top">
                <asp:TextBox ID="txtNomePerfil" runat="server" Width="177px" MaxLength="50"></asp:TextBox>
            </td>
            <td valign="top">
                <asp:GridView ID="gdvPerfisCadastrados" runat="server" 
                    AutoGenerateColumns="False" DataSourceID="dtsPerfis" 
                    DataKeyNames="IDPerfilSistema" 
                    onselectedindexchanged="gdvPerfisCadastrados_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField SelectText="[Editar]" ShowSelectButton="True" />
                        <asp:BoundField DataField="NomePerfil" HeaderText="NomePerfil" ReadOnly="True" 
                            SortExpression="NomePerfil" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="dtsPerfis" runat="server" 
                    SelectMethod="GetPerfilSistemaByIDAplicacao" 
                    TypeName="Nivel7BLLSeguranca.PerfilSistemaBLL">
                    <SelectParameters>
                        <asp:Parameter Name="IDAplicacao" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button ID="btnSalvar" runat="server" Text="Salvar" 
                    onclick="btnSalvar_Click" />
            &nbsp;<asp:Button ID="btnSalvarNovo" runat="server" onclick="btnSalvarNovo_Click" 
                    Text="Salvar e Novo" />
&nbsp;<asp:Button ID="btnNovo" runat="server" onclick="btnNovo_Click" Text="Novo" 
                    CausesValidation="False" />
&nbsp;<asp:Button ID="btnExcluir" runat="server" onclick="btnExcluir_Click" Text="Excluir" />
            </td>
        </tr>
    </table>
</asp:Content>
