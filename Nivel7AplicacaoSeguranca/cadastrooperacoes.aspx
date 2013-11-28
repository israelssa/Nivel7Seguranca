<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cadastrooperacoes.aspx.cs" Inherits="Nivel7AplicacaoSeguranca.cadastrooperacoes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style4
        {
            height: 21px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td colspan="2">
                CADASTRO DE OPERAÇÕES<asp:ValidationSummary ID="ValidationSummary1" 
                    runat="server" ForeColor="#FF3300" 
                    HeaderText="Verifique os seguintes campos:" />
            </td>
        </tr>
        <tr>
            <td class="style4">
                Aplicacao:<asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToValidate="ddlAplicacao" ErrorMessage="Aplicacao" ForeColor="#FF3300" 
                    Operator="GreaterThan" Type="Integer" ValueToCompare="0">*</asp:CompareValidator>
            </td>
            <td class="style4">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtNomeOperacao" ErrorMessage="Nome da Operacão" 
                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                Nome da operacão:</td>
        </tr>
        <tr>
            <td valign="top">
                <asp:DropDownList ID="ddlAplicacao" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlAplicacao_SelectedIndexChanged" 
                    DataSourceID="dtsAplicacao" ondatabound="ddlAplicacao_DataBound" 
                    DataTextField="NomeAplicacao" DataValueField="IDAplicacao">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="dtsAplicacao" runat="server" 
                    SelectMethod="GetAllAplicacaoAtivos" TypeName="Nivel7BLLSeguranca.AplicacaoBLL">
                </asp:ObjectDataSource>
            </td>
            <td valign="top">
                <asp:TextBox ID="txtNomeOperacao" runat="server" Width="192px" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnSalvar" runat="server" onclick="btnSalvar_Click" 
                    Text="Salvar" />
&nbsp;<asp:Button ID="btnSalvarNovo" runat="server" onclick="btnSalvarNovo_Click" 
                    Text="Salvar e Novo" />
&nbsp;<asp:Button ID="btnNovo" runat="server" onclick="btnNovo_Click" Text="Novo" 
                    CausesValidation="False" />
&nbsp;<asp:Button ID="btnExcluir" runat="server" onclick="btnExcluir_Click" Text="Excluir" 
                    Enabled="False" 
                    onclientclick="return confirm(&quot;Deseja excluir esta operacão?&quot;)" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="grdOperacoes" runat="server" AutoGenerateColumns="False" 
                     DataKeyNames="IDOperacao" 
                    onselectedindexchanged="grdOperacoes_SelectedIndexChanged" 
                    DataSourceID="dtsOperacao">
                    <Columns>
                        <asp:CommandField SelectText="[Editar]" ShowSelectButton="True" />
                        <asp:BoundField DataField="NomeOperacao" HeaderText="NomeOperacao" 
                            ReadOnly="True" SortExpression="NomeOperacao" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="dtsOperacao" runat="server" 
                    SelectMethod="GetOperacoesByIDAplicacao" 
                    TypeName="Nivel7BLLSeguranca.OperacaoSistemaBLL">
                    <SelectParameters>
                        <asp:Parameter Name="IDAplicacao" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
