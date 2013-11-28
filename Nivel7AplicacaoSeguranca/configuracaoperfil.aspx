<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="configuracaoperfil.aspx.cs" Inherits="Nivel7AplicacaoSeguranca.CadastroOperacoes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td colspan="2">
                CONFIGURAÇÃO DE PERFIL</td>
        </tr>
        <tr>
            <td>
                Aplicação:<asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToValidate="ddlAplicacao" ErrorMessage="Aplicacao" ForeColor="#FF3300" 
                    Operator="GreaterThan" Type="Integer" ValueToCompare="0">*</asp:CompareValidator>
            </td>
            <td>
                Telas e operações permitidas:</td>
        </tr>
        <tr>
            <td rowspan="3" valign="top">
                <asp:DropDownList ID="ddlAplicacao" runat="server" DataSourceID="dtsAplicacao" 
                    DataTextField="NomeAplicacao" DataValueField="IDAplicacao" 
                    onselectedindexchanged="ddlAplicacao_SelectedIndexChanged" 
                    AutoPostBack="True" ondatabound="ddlAplicacao_DataBound" Width="100px">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="dtsAplicacao" runat="server" 
                    SelectMethod="GetAllAplicacaoAtivos" TypeName="Nivel7BLLSeguranca.AplicacaoBLL">
                </asp:ObjectDataSource>
                <br />
                Perfil:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtPerfil" ErrorMessage="Perfil" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="txtPerfil" runat="server"></asp:TextBox>
                <asp:Button ID="btnSalvarPerfil" runat="server" CausesValidation="False" 
                    onclick="btnSalvarPerfil_Click" Text="Adicionar perfil" />
                <br />
                Perfis Cadastrados:<br />
                <asp:ListBox ID="ltbPerfisCadastrados" runat="server" Height="114px" 
                    Width="250px" DataSourceID="dtsPerfil" DataTextField="NomePerfil" 
                    DataValueField="IDPerfilSistema" 
                    ondatabound="ltbPerfisCadastrados_DataBound" AutoPostBack="True" 
                    onselectedindexchanged="ltbPerfisCadastrados_SelectedIndexChanged"></asp:ListBox>
                <br />
                <asp:ObjectDataSource ID="dtsPerfil" runat="server" 
                    SelectMethod="GetPerfilSistemaByIDAplicacao" 
                    TypeName="Nivel7BLLSeguranca.PerfilSistemaBLL">
                    <SelectParameters>
                        <asp:Parameter Name="IDAplicacao" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <br />
                <asp:Button ID="btnExcluirperfil" runat="server" 
                    Text="Excluir perfil selecionado" onclick="btnExcluirperfil_Click" />
            </td>
            <td>
                <asp:GridView ID="grdOperacoesPermitidas" runat="server" 
                    AutoGenerateColumns="False" DataSourceID="dtsOperacoesPermitidas">
                    <Columns>
                        <asp:CommandField SelectText="[Editar]" ShowSelectButton="True" />
                        <asp:BoundField DataField="CodigoTela" HeaderText="CodigoTela" 
                            SortExpression="CodigoTela" />
                        <asp:BoundField DataField="NomeTela" HeaderText="NomeTela" 
                            SortExpression="NomeTela" />
                        <asp:BoundField DataField="NomeOperacao" HeaderText="NomeOperacao" 
                            SortExpression="NomeOperacao" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="dtsOperacoesPermitidas" runat="server" 
                    SelectMethod="GetOperacoesDoPerfil" 
                    TypeName="Nivel7BLLSeguranca.PerfilSistemaBLL">
                    <SelectParameters>
                        <asp:Parameter Name="IDPerfil" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td>
                Operações Permitidas:</td>
        </tr>
        <tr>
            <td valign="top">
                Tela:<br />
                <asp:DropDownList ID="ddlTela" runat="server" DataSourceID="dtsTelas" 
                    DataTextField="NomeTela" DataValueField="IDTela" 
                    ondatabound="ddlTela_DataBound" AutoPostBack="True" 
                    onselectedindexchanged="ddlTela_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="dtsTelas" runat="server" 
                    SelectMethod="GetTelaByIDAplicacao" 
                    TypeName="Nivel7BLLSeguranca.Tela_AplicaoBLL">
                    <SelectParameters>
                        <asp:Parameter Name="IDAplicacao" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <br />
                <asp:CheckBoxList ID="cblOperacao" runat="server" 
                    DataSourceID="dtsOperacoes" DataTextField="NomeOperacao" 
                    DataValueField="IDOperacao">
                </asp:CheckBoxList>
                <asp:ObjectDataSource ID="dtsOperacoes" runat="server" 
                    SelectMethod="GetOperacoesDaTela" 
                    TypeName="Nivel7BLLSeguranca.OperacaoSistemaBLL">
                    <SelectParameters>
                        <asp:Parameter Name="IDTela" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <br />
                <asp:Button ID="btnSalvar" runat="server" Text="Salvar Operacão" 
                    onclick="btnSalvar_Click" />
                <br />
            </td>
        </tr>
        </table>
</asp:Content>
