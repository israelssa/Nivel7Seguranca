<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cadastrotelasistema.aspx.cs" Inherits="Nivel7AplicacaoSeguranca.cadastrotelasistema" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style5
        {
            font-weight: normal;
        }
        .style6
        {
            height: 59px;
        }
        .style7
        {
            width: 100%;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="style7">
        <tr>
            <td>
<asp:ValidationSummary ID="ValidationSummary1" 
                            runat="server" ForeColor="#FF3300" HeaderText="Verifique os Seguintes Campos:" />
                            
            </td>
        </tr>
        <tr>
            <td>
    <asp:Menu ID="mnuTab" runat="server" onmenuitemclick="mnuTab_MenuItemClick" 
        Orientation="Horizontal">
        <Items>
            <asp:MenuItem Text="Telas de Sistema" Value="Tela"></asp:MenuItem>
            <asp:MenuItem Text="Operações de Telas" Value="Operacao"></asp:MenuItem>
        </Items>
    </asp:Menu>
            </td>
        </tr>
        <tr>
            <td>
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">
            <table>
                <tr>
                    <td colspan="4">
                        CADASTRO DE TELAS DE SISTEMAS
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                        Aplicacão:&nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" 
                            ControlToValidate="ddlAplicacao" ErrorMessage="Aplicacao" ForeColor="#FF3300" 
                            Operator="GreaterThan" Type="Integer" ValidationGroup="tela" ValueToCompare="0">*</asp:CompareValidator>
                    </td>
                    <td class="style5">
                        Nome da Tela:<asp:RequiredFieldValidator ID="rfvNome" runat="server" 
                            ControlToValidate="txtNomeTela" ErrorMessage="Nome da Tela" ForeColor="#FF3300" 
                            ValidationGroup="tela">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        Código da Tela:<asp:RequiredFieldValidator ID="rfvCodTela" runat="server" 
                            ControlToValidate="txtCodTela" ErrorMessage="Código da Tela" 
                            ForeColor="#FF3300" ValidationGroup="tela">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        Nome do Arquivo:<asp:RequiredFieldValidator ID="rfvNomeArquivo" runat="server" 
                            ControlToValidate="txtNomeArquivo" ErrorMessage="Nome do Arquivo" 
                            ForeColor="#FF3300" ValidationGroup="tela">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style6" valign="top">
                        <asp:DropDownList ID="ddlAplicacao" runat="server" 
                            ondatabound="ddlAplicacaovw1_DataBound" 
                            onselectedindexchanged="ddlAplicacaovw1_SelectedIndexChanged" 
                            DataSourceID="dtsAplicacao" DataTextField="NomeAplicacao" 
                            DataValueField="IDAplicacao" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="dtsAplicacao" runat="server" 
                            SelectMethod="GetAllAplicacaoAtivos" TypeName="Nivel7BLLSeguranca.AplicacaoBLL">
                        </asp:ObjectDataSource>
                    </td>
                    <td class="style6" valign="top">
                        <asp:TextBox ID="txtNomeTela" runat="server" MaxLength="50" Width="200px" 
                            TabIndex="1"></asp:TextBox>
                    </td>
                    <td class="style6" valign="top">
                        <asp:TextBox ID="txtCodTela" runat="server" Width="200px" 
                            TabIndex="2" onkeyup="formataInteiro(this,event);"></asp:TextBox>
                    </td>
                    <td class="style6" valign="top">
                        <asp:TextBox ID="txtNomeArquivo" runat="server" MaxLength="50" Width="200px" 
                            TabIndex="3"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="grdTelas" runat="server" AutoGenerateColumns="False" 
                            DataKeyNames="IDTela" 
                            onselectedindexchanged="grdTelas_SelectedIndexChanged" 
                            DataSourceID="dtsTelasdaAplicacao">
                            <Columns>
                                <asp:CommandField SelectText="[Editar]" ShowSelectButton="True" />
                                <asp:BoundField DataField="NomeTela" HeaderText="NomeTela" ReadOnly="True" 
                                    SortExpression="NomeTela" />
                                <asp:BoundField DataField="CodigoTela" HeaderText="CodigoTela" ReadOnly="True" 
                                    SortExpression="CodigoTela" />
                                <asp:BoundField DataField="NomeArquivo" HeaderText="NomeArquivo" 
                                    ReadOnly="True" SortExpression="NomeArquivo" />
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="dtsTelasdaAplicacao" runat="server" 
                            SelectMethod="GetTelaByIDAplicacao" 
                            TypeName="Nivel7BLLSeguranca.Tela_AplicaoBLL">
                            <SelectParameters>
                                <asp:Parameter Name="IDAplicacao" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <table>
                <tr>
                    <td>
                        ASSOCIAÇÃO TELA/OPERAÇÃO</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td valign="top">
                       

                        Tela:<asp:RequiredFieldValidator ID="rfvTela" runat="server" 
                            ControlToValidate="ddlTela" ErrorMessage="Tela" ForeColor="#FF3300" 
                            InitialValue="0" ValidationGroup="operacao">*</asp:RequiredFieldValidator>
                        <br />
                        <asp:DropDownList ID="ddlTela" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="ddlTela_SelectedIndexChanged" 
                            DataSourceID="dtsTela" DataTextField="NomeTela" DataValueField="IDTela" 
                            ondatabound="ddlTela_DataBound">
                        </asp:DropDownList>

                        <asp:ObjectDataSource ID="dtsTela" runat="server" 
                            SelectMethod="GetAllTelaAtivos" TypeName="Nivel7BLLSeguranca.TelaSistemaBLL">
                        </asp:ObjectDataSource>

                    </td>
                    <td>
                        Operações:<asp:CheckBoxList ID="cblOperacoes" runat="server" Enabled="False" 
                            DataSourceID="dtsOperacaoTela" DataTextField="NomeOperacao" 
                            DataValueField="IDOperacao" TabIndex="1">
                        </asp:CheckBoxList>
                        <asp:ObjectDataSource ID="dtsOperacaoTela" runat="server" 
                            SelectMethod="GetOperacoesByIDAplicacao" 
                            TypeName="Nivel7BLLSeguranca.OperacaoSistemaBLL">
                            <SelectParameters>
                                <asp:Parameter Name="IDAplicacao" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
            </table>
        </asp:View>
       
    </asp:MultiView>
            </td>
        </tr>
        <tr>
            <td>
    <asp:Button ID="btnSalvar" runat="server" onclick="Salvar_Click" 
        Text="Salvar" ValidationGroup="tela" />
    &nbsp;<asp:Button ID="btnSalvarNovo" runat="server" onclick="btnSalvarNovo_Click" 
        Text="Salvar e Novo" />
    &nbsp;<asp:Button ID="btnNovo" runat="server" CausesValidation="False" 
        onclick="btnNovo_Click" Text="Novo" />
    &nbsp;<asp:Button ID="btnExcluir" runat="server" Enabled="False" 
        onclick="btnExcluir_Click" 
        onclientclick="return confirm(&quot;Deseja Excluir Essa Tela&quot;)" 
        Text="Excluir" />
            </td>
        </tr>
    </table>
    </asp:Content>
