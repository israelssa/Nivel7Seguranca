<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cadastroaplicacao.aspx.cs" Inherits="Nivel7AplicacaoSeguranca.CadastroAplicacao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style8
        {
            height: 110px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td colspan="2" class="style8">
                CADASTRO DE APLICAÇÃO<asp:ValidationSummary ID="ValidationSummary1" 
                    runat="server" ForeColor="#FF3300" 
                    HeaderText="Verifique os Seguintes Campos:" />
                </td>
        </tr>
        <tr>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtNomeAplicacao" ErrorMessage="Nome" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                Nome:</td>
            <td>
                <asp:TextBox ID="txtNomeAplicacao" runat="server" Width="217px" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtNomeAplicacao" ErrorMessage="Descricão" 
                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                Descrição:</td>
            <td>
                <asp:TextBox ID="txtDescricao" runat="server" Height="102px" TextMode="MultiLine" 
                    Width="687px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnSalvar" runat="server" onclick="btnSalvar_Click" 
                    Text="Salvar" />
&nbsp;<asp:Button ID="btnSalvarNovo" runat="server" Text="Salvar e Novo" 
                    onclick="btnSalvarNovo_Click" />
&nbsp;<asp:Button ID="btnNovo" runat="server" Text="Novo" onclick="btnNovo_Click" 
                    CausesValidation="False" />
&nbsp;<asp:Button ID="btnExcluir" runat="server" Enabled="False" onclick="btnExcluir_Click" 
                    Text="Excluir" 
                    onclientclick="return confirm(&quot;Deseja excluir esta aplicacão?&quot;)" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="gdvAplicacao" runat="server" AutoGenerateColumns="False" DataKeyNames="IDAplicacao" 
                    onselectedindexchanged="gdvAplicacao_SelectedIndexChanged" 
                    DataSourceID="dtsAplicacao">
                    <Columns>
                        <asp:CommandField SelectText="[Editar]" ShowSelectButton="True" />
                        <asp:BoundField DataField="NomeAplicacao" HeaderText="NomeAplicacao" 
                            ReadOnly="True" SortExpression="NomeAplicacao" />
                        <asp:BoundField DataField="Descricao" HeaderText="Descricao" ReadOnly="True" 
                            SortExpression="Descricao" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="dtsAplicacao" runat="server" 
                    SelectMethod="GetAllAplicacaoAtivos" TypeName="Nivel7BLLSeguranca.AplicacaoBLL">
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
