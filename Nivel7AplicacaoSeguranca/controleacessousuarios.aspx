<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="controleacessousuarios.aspx.cs" Inherits="Nivel7AplicacaoSeguranca.controleacessousuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td>
                CONTROLE DE ACESSO A USUÁRIOS<asp:ValidationSummary ID="ValidationSummary1" 
                    runat="server" ForeColor="#FF3300" 
                    HeaderText="Verifique os seguintes campos:" />
            </td>
        </tr>
        <tr>
            <td>
                Aplicacao:<asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToValidate="ddlAplicacao" ErrorMessage="Aplicacao" 
                    Operator="GreaterThan" Type="Integer" ValueToCompare="0" 
                    ForeColor="#FF3300">*</asp:CompareValidator>
                <br />
                <asp:DropDownList ID="ddlAplicacao" runat="server" AutoPostBack="True" 
                    DataSourceID="dtsAplicacao" DataTextField="NomeAplicacao" 
                    DataValueField="IDAplicacao" ondatabound="ddlAplicacao_DataBound" 
                    onselectedindexchanged="ddlAplicacao_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="dtsAplicacao" runat="server" 
                    SelectMethod="GetAllAplicacaoAtivos" TypeName="Nivel7BLLSeguranca.AplicacaoBLL">
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td>
                Perfil:<asp:CompareValidator ID="CompareValidator2" runat="server" 
                    ControlToValidate="ddlPerfil" ErrorMessage="Perfil" 
                    Operator="GreaterThan" Type="Integer" ValueToCompare="0" 
                    ForeColor="#FF3300">*</asp:CompareValidator>
                <br />
                <asp:DropDownList ID="ddlPerfil" runat="server" DataSourceID="dtsPerfil" 
                    DataTextField="NomePerfil" DataValueField="IDPerfilSistema" 
                    ondatabound="ddlPerfil_DataBound">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="dtsPerfil" runat="server" 
                    SelectMethod="GetPerfilSistemaByIDAplicacao" 
                    TypeName="Nivel7BLLSeguranca.PerfilSistemaBLL">
                    <SelectParameters>
                        <asp:Parameter Name="IDAplicacao" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td>
                Senha:<asp:RequiredFieldValidator ID="vlSenha" runat="server" 
                    ControlToValidate="txtSenha" ErrorMessage="Senha" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="txtSenha" runat="server" MaxLength="10" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Repita Senha:<asp:RequiredFieldValidator ID="vlRepitaSenha" 
                    runat="server" ControlToValidate="txtRepitaSenha" ErrorMessage="Repita Senha" 
                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="txtRepitaSenha" runat="server" MaxLength="10" 
                    TextMode="Password"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator3" runat="server" 
                    ControlToCompare="txtSenha" ControlToValidate="txtRepitaSenha" 
                    ErrorMessage="Repita senha corretamente." ForeColor="#FF3300">*</asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>
                Bloqueado:
                <asp:CheckBox ID="cbBloquear" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSalvar" runat="server" Text="Salvar" 
                    onclick="btnSalvar_Click1"/>
            &nbsp;<asp:Button ID="btnSalvarNovo" runat="server" Text="Salvar e Novo" 
                    onclick="btnSalvarNovo_Click" />
&nbsp;<asp:Button ID="btnNovo" runat="server" Text="Novo" onclick="btnNovo_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:ImageButton ID="btnTodos" runat="server" CausesValidation="False" 
                    onclick="btnTodos_Click" />
                <asp:TextBox ID="txtBusca" runat="server" Width="268px"></asp:TextBox>
                <asp:Button ID="btnPesquisa" runat="server" Text="Pesquisar" 
                    CausesValidation="False" onclick="btnPesquisa_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grdUsuarios" runat="server" AutoGenerateColumns="False" DataKeyNames="IDUsuario,IDAplicacao,IDPerfilSistema,AcessoPermitido" 
                    onselectedindexchanged="grdUsuarios_SelectedIndexChanged" 
                    onrowcreated="grdUsuarios_RowCreated">
                    <Columns>
                        <asp:CommandField SelectText="[Selecione]" ShowSelectButton="True" />
                        <asp:BoundField DataField="Nome" HeaderText="Nome" ReadOnly="True" 
                            SortExpression="Nome" />
                        <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="True" 
                            SortExpression="Email" />
                        <asp:BoundField DataField="NomePerfil" HeaderText="Perfil" ReadOnly="True" 
                            SortExpression="NomePerfil" />
                        <asp:BoundField DataField="NomeAplicacao" HeaderText="Aplicacao" 
                            ReadOnly="True" SortExpression="NomeAplicacao" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Image ID="imgStatus" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        </table>
    <br />
</asp:Content>
