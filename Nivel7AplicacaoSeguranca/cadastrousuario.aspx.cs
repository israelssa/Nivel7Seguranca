using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nivel7BLLSeguranca;
using Nivel7DALSeguranca;

namespace Nivel7AplicacaoSeguranca
{
    public partial class CadastroDeUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadUsuarios();
        }

        void LoadUsuarios()
        {
            dtsUsuario.DataBind();
            gdvUsuarios.DataBind();            
        }
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        protected void gdvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {            
            Session["IDUsuario"] = gdvUsuarios.SelectedValue;

            UsuarioBLL usuarios = new UsuarioBLL();
            Usuario usuario = new Usuario();

            usuario = usuarios.GetUsuarioByID(Convert.ToInt32(Session["IDUsuario"]));

            txtNomeUsuario.Text = usuario.Nome;
            txtEmail.Text = usuario.Email;
            txtBairro.Text = usuario.Bairro;
            txtRua.Text = usuario.Rua;
            txtNumeroCasa.Text = usuario.NumeroCasa;
            txtMunicipio.Text = usuario.Municipio;
            txtEstado.Text = usuario.Estado;
            txtTelefoneFixo.Text = usuario.TelefoneFixo;
            txtCelular.Text = usuario.Celular;

            btnExcluir.Enabled = true;
        }

        void Salvar()
        {
            if (Session["IDUsuario"] == null)
            {
                UsuarioBLL usuarios = new UsuarioBLL();
                Usuario usuario = new Usuario()
                {
                    Nome = txtNomeUsuario.Text,
                    Email = txtEmail.Text,
                    Bairro = txtBairro.Text,
                    Rua = txtRua.Text,
                    NumeroCasa = txtNumeroCasa.Text,
                    Municipio = txtMunicipio.Text,
                    Estado = txtEstado.Text,
                    TelefoneFixo = txtTelefoneFixo.Text,
                    Celular = txtCelular.Text
                };

                Session["IDUsuario"] = usuarios.InsertUsuario(usuario);
     
                LoadUsuarios();

                btnExcluir.Enabled = true;
            }
            else
            {
                UsuarioBLL usuarios = new UsuarioBLL();
                Usuario usuario = new Usuario();

                usuario = usuarios.GetUsuarioByID(Convert.ToInt32(Session["IDUsuario"]));

                usuario.Nome = txtNomeUsuario.Text;
                usuario.Email = txtEmail.Text;
                usuario.Bairro = txtBairro.Text;
                usuario.Rua = txtRua.Text;
                usuario.NumeroCasa = txtNumeroCasa.Text;
                usuario.Municipio = txtMunicipio.Text;
                usuario.Estado = txtEstado.Text;
                usuario.TelefoneFixo = txtTelefoneFixo.Text;
                usuario.Celular = txtCelular.Text;

                usuarios.UpdateUsuario(usuario);
            
                LoadUsuarios();

            }
        }

        void LimparCampos()
        {
            Session["IDUsuario"] = null;
            txtNomeUsuario.Text = "";
            txtEmail.Text = "";
            txtBairro.Text = "";
            txtRua.Text = "";
            txtNumeroCasa.Text = "";
            txtMunicipio.Text = "";
            txtEstado.Text = "";
            txtTelefoneFixo.Text = "";
            txtCelular.Text = "";
            btnExcluir.Enabled = false;
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        protected void btnSalvarNovo_Click(object sender, EventArgs e)
        {
            Salvar();
            LimparCampos();
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            UsuarioBLL usuarios = new UsuarioBLL();           

            usuarios.DeleteUsuario(Convert.ToInt32(Session["IDUsuario"]));           
            LimparCampos();
            LoadUsuarios();
        }

    }
}