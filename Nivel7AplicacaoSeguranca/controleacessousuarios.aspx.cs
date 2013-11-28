using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nivel7BLLSeguranca;
using Nivel7DALSeguranca;
using System.Linq.Expressions;

namespace Nivel7AplicacaoSeguranca
{
    public partial class controleacessousuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadGrdUsuario();
            }
        }

        void loadGrdUsuario()
        {
            UsuarioBLL usuariobll = new UsuarioBLL();
            grdUsuarios.DataSource = usuariobll.GetAllUsuarioAplicacaoPerfilAtivo();
            grdUsuarios.DataBind();
        }

        void loadGrdUsuario(string nameUsuario)
        {
            UsuarioBLL usuariobll = new UsuarioBLL();
            List<vwAplicacaoUsuarioPerfil> aplicacaoUsuarioPerfil = usuariobll.GetUsuarioByName(nameUsuario);
            if (aplicacaoUsuarioPerfil.Count() > 0)
            {
                grdUsuarios.DataSource = aplicacaoUsuarioPerfil;
                grdUsuarios.DataBind();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        protected void ddlAplicacao_DataBound(object sender, EventArgs e)
        {
            ddlAplicacao.Items.Insert(0, "Selecione");
        }

        protected void ddlAplicacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAplicacao.SelectedIndex > 0)
            {
                dtsPerfil.SelectParameters["IDAplicacao"].DefaultValue = ddlAplicacao.SelectedValue;
            }
            else
            {
                ddlPerfil.SelectedIndex = 0;
            }
        }

        protected void ddlPerfil_DataBound(object sender, EventArgs e)
        {
            ddlPerfil.Items.Insert(0, "Selecione");
        }

        protected void grdUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["IDUsuario"] = grdUsuarios.SelectedDataKey["IDUsuario"];
            Session["IDAplicacao"] = grdUsuarios.SelectedDataKey["IDAplicacao"];
            UsuarioBLL usuariobll = new UsuarioBLL();
            if (usuariobll.VerificaExistenciaRegistro(Convert.ToInt32(Session["IDUsuario"]), Convert.ToInt32(Session["IDAplicacao"])))
            {
                UsuarioAplicacaoPerfil associacao = new UsuarioAplicacaoPerfil();
                associacao = usuariobll.GetUsuarioAplicacaoPerfilByID(Convert.ToInt32(Session["IDAplicacao"]), Convert.ToInt32(Session["IDUsuario"]));

                if (!associacao.AcessoPermitido.Value)
                {
                    cbBloquear.Checked = true;
                }
                else
                {
                    cbBloquear.Checked = false;
                }

                ddlAplicacao.SelectedValue = associacao.IDAplicacao.ToString();
                dtsPerfil.SelectParameters["IDAplicacao"].DefaultValue = associacao.IDAplicacao.ToString();                
                dtsPerfil.DataBind();
                ddlPerfil.DataBind();
                ddlPerfil.SelectedValue = associacao.IDPerfilSistema.ToString();
                AbilitarValidadorSenha(false);
            }
        }

        void AbilitarValidadorSenha(bool situacao)
        {
            if (situacao)
            {
                vlSenha.Enabled = true;
                vlRepitaSenha.Enabled = true;
            }
            else
            {
                vlSenha.Enabled = false;
                vlRepitaSenha.Enabled = false;
            }
        }

        void Salvar()
        {
            UsuarioBLL usuariobll = new UsuarioBLL();
            if ((Session["IDUsuario"] != null) && (!usuariobll.VerificaExistenciaRegistro(Convert.ToInt32(Session["IDUsuario"]), int.Parse(ddlAplicacao.SelectedValue))))
            {
                UsuarioAplicacaoPerfil associacao = new UsuarioAplicacaoPerfil()
                {
                    IDAplicacao = int.Parse(ddlAplicacao.SelectedValue),
                    IDPerfilSistema = int.Parse(ddlPerfil.SelectedValue),
                    IDUsuario = Convert.ToInt32(Session["IDUsuario"]),
                    Senha = txtRepitaSenha.Text,
                    AcessoPermitido = AcessoPermitido()
                };
                usuariobll.insertUsuarioAplicacaoPerfil(associacao);
                loadGrdUsuario();
            }
            else
                if ((Session["IDUsuario"] != null) && (usuariobll.VerificaExistenciaRegistro(Convert.ToInt32(Session["IDUsuario"]), int.Parse(ddlAplicacao.SelectedValue))) && (ddlAplicacao.SelectedValue.ToString() == Session["IDAplicacao"].ToString()))
                {
                    UsuarioAplicacaoPerfil associacao = new UsuarioAplicacaoPerfil();
                    associacao.IDAplicacao = int.Parse(ddlAplicacao.SelectedValue);
                    associacao.IDPerfilSistema = int.Parse(ddlPerfil.SelectedValue);
                    associacao.IDUsuario = Convert.ToInt32(Session["IDUsuario"]);
                    associacao.AcessoPermitido = AcessoPermitido();
                    usuariobll.UpdateUsuarioAplicacaoPerfil(Convert.ToInt32(Session["IDAplicacao"]), associacao);
                    loadGrdUsuario();
                }
                else
                    if ((Session["IDUsuario"] != null) && (usuariobll.VerificaExistenciaRegistro(Convert.ToInt32(Session["IDUsuario"]), int.Parse(ddlAplicacao.SelectedValue))) && (ddlAplicacao.SelectedValue.ToString() != Session["IDAplicacao"].ToString()))
                    {
                        if (!usuariobll.VerificaExistenciaRegistro(Convert.ToInt32(Session["IDUsuario"]), int.Parse(ddlAplicacao.SelectedValue)))
                        {
                            UsuarioAplicacaoPerfil associacao = new UsuarioAplicacaoPerfil();
                            associacao.IDAplicacao = int.Parse(ddlAplicacao.SelectedValue);
                            associacao.IDPerfilSistema = int.Parse(ddlPerfil.SelectedValue);
                            associacao.IDUsuario = Convert.ToInt32(Session["IDUsuario"]);
                            associacao.AcessoPermitido = AcessoPermitido();
                            usuariobll.UpdateUsuarioAplicacaoPerfil(Convert.ToInt32(Session["IDAplicacao"]), associacao);
                            loadGrdUsuario();
                        }
                        else
                        {
                            String mensagem = "Usuário já cadastrado nesta aplicacao.";
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensagem De Alerta", "alert('" + mensagem + "');", true);
                        }
                    }
                    else
                    {
                        String mensagem = "Selecione um usuário.";
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensagem De Alerta", "alert('" + mensagem + "');", true);
                    }
        }

        bool AcessoPermitido()
        {
            if (cbBloquear.Checked)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        void LimparCampos()
        {
            ddlAplicacao.SelectedIndex = 0;
            ddlPerfil.SelectedIndex = 0;
            txtSenha.Text = "";
            txtRepitaSenha.Text = "";
            Session["IDUsuario"] = null;
            Session["IDAplicacao"] = null;
            AbilitarValidadorSenha(true);
        }

        protected void btnSalvarNovo_Click(object sender, EventArgs e)
        {
            Salvar();
            LimparCampos();
        }

        protected void btnSalvar_Click1(object sender, EventArgs e)
        {
            Salvar();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        protected void grdUsuarios_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (grdUsuarios.DataKeys[e.Row.RowIndex]["AcessoPermitido"].ToString() != "")
                {
                    if (bool.Parse(grdUsuarios.DataKeys[e.Row.RowIndex]["AcessoPermitido"].ToString()))
                    {
                        ((Image)e.Row.Cells[5].FindControl("imgStatus")).AlternateText = "Usuário Desbloqueado";
                        ((Image)e.Row.Cells[5].FindControl("imgStatus")).ImageUrl = "imagens/lock_open.png";
                    }
                    else
                    {
                        ((Image)e.Row.Cells[5].FindControl("imgStatus")).AlternateText = "Usuário Bloqueado";
                        ((Image)e.Row.Cells[5].FindControl("imgStatus")).ImageUrl = "imagens/lock.png";
                    }
                }
            }
        }

        protected void btnPesquisa_Click(object sender, EventArgs e)
        {
            UsuarioBLL usuariobll = new UsuarioBLL();
            if (txtBusca.Text != "")
            {
                loadGrdUsuario(txtBusca.Text);
            }
        }

        protected void btnTodos_Click(object sender, ImageClickEventArgs e)
        {
            loadGrdUsuario();
        }
    }
}

