<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cadastrousuario.aspx.cs" Inherits="Nivel7AplicacaoSeguranca.CadastroDeUsuario" ValidateRequest="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
        <table>
            <tr>
                <td colspan="4">
                    CADASTRO DE USUÁRIOS<asp:ValidationSummary ID="ValidationSummary1" 
                        runat="server" HeaderText="Verifique os seguntes campos:" 
                        ForeColor="#FF3300" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RequiredFieldValidator ID="rfvNome" runat="server" 
                        ControlToValidate="txtNomeUsuario" ErrorMessage="Nome" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                    Nome:</td>
                <td>
                    <asp:TextBox ID="txtNomeUsuario" runat="server" Width="212px" MaxLength="50"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                        ControlToValidate="txtEmail" ErrorMessage="Email" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                    Email:</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" Width="232px" MaxLength="50"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" 
                        ControlToValidate="txtEmail" ErrorMessage="Email inválido!" ForeColor="#FF3300" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtBairro" ErrorMessage="Bairro" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                    Bairro:</td>
                <td>
                    <asp:TextBox ID="txtBairro" runat="server" MaxLength="30"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="txtRua" ErrorMessage="Rua" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                    Rua:</td>
                <td>
                    <asp:TextBox ID="txtRua" runat="server" Width="126px" MaxLength="50"></asp:TextBox>
                    <b>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" 
                        runat="server" ControlToValidate="txtNumeroCasa" ErrorMessage="Nº" 
                        ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                    </b> 
                    Nº:<b>&nbsp; </b> 
                    <asp:TextBox ID="txtNumeroCasa" runat="server" Width="53px" 
                        MaxLength="10" onkeyup="formataInteiro(this,event);"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtMunicipio" ErrorMessage="Município" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                    Municipio:</td>
                <td>
                    <asp:TextBox ID="txtMunicipio" runat="server" MaxLength="30"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txtEstado" ErrorMessage="Estado" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                    Estado:</td>
                <td>
                    <asp:TextBox ID="txtEstado" runat="server" MaxLength="30"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;Telefone Fixo:</td>
                <td>
                    <asp:TextBox ID="txtTelefoneFixo" runat="server" MaxLength="14" 
                        onkeyup="formataTelefone(this,event);"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="txtCelular" ErrorMessage="Celular" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                    Celular:</td>
                <td>
                    <asp:TextBox ID="txtCelular" runat="server" MaxLength="14" onkeyup="formataTelefone(this,event);" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btnSalvar" runat="server" onclick="btnSalvar_Click" 
                        Text="Salvar" />
                &nbsp;<asp:Button ID="btnSalvarNovo" runat="server" 
                         Text="Salvar e Novo" onclick="btnSalvarNovo_Click" />
&nbsp;<asp:Button ID="btnNovo" runat="server" onclick="btnNovo_Click" 
                        Text="Novo" CausesValidation="False" />
                &nbsp;<asp:Button ID="btnExcluir" runat="server" CausesValidation="False" 
                        Enabled="False" onclick="btnExcluir_Click" Text="Excluir" 
                        onclientclick="return confirm(&quot;Deseja excluir este usuario?&quot;)" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="gdvUsuarios" runat="server" AutoGenerateColumns="False" 
                        onselectedindexchanged="gdvUsuarios_SelectedIndexChanged" 
                        DataKeyNames="IDUsuario" 
                        style="margin-right: 0px" DataSourceID="dtsUsuario">
                        <Columns>
                            <asp:CommandField SelectText="[Editar]" ShowSelectButton="True" />
                            <asp:BoundField DataField="Rua" HeaderText="Rua" ReadOnly="True" 
                                SortExpression="Rua" />
                            <asp:BoundField DataField="Bairro" HeaderText="Bairro" ReadOnly="True" 
                                SortExpression="Bairro" />
                            <asp:BoundField DataField="Celular" HeaderText="Celular" ReadOnly="True" 
                                SortExpression="Celular" />
                            <asp:BoundField DataField="TelefoneFixo" HeaderText="TelefoneFixo" 
                                ReadOnly="True" SortExpression="TelefoneFixo" />
                            <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="True" 
                                SortExpression="Email" />
                            <asp:BoundField DataField="Nome" HeaderText="Nome" ReadOnly="True" 
                                SortExpression="Nome" />
                            <asp:BoundField DataField="Municipio" HeaderText="Municipio" ReadOnly="True" 
                                SortExpression="Municipio" />
                            <asp:BoundField DataField="NumeroCasa" HeaderText="NumeroCasa" ReadOnly="True" 
                                SortExpression="NumeroCasa" />
                            <asp:BoundField DataField="Estado" HeaderText="Estado" ReadOnly="True" 
                                SortExpression="Estado" />
                        </Columns>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="dtsUsuario" runat="server" 
                        SelectMethod="GetAllUsuarioAtivo" TypeName="Nivel7BLLSeguranca.UsuarioBLL">
                    </asp:ObjectDataSource>
                </td>
            </tr>
            </table>

    <p>
&nbsp;
    </p>
    </asp:Content>
