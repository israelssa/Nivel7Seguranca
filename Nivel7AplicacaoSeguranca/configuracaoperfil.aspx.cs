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
    public partial class CadastroOperacoes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlAplicacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["IDAplicacao"] = ddlAplicacao.SelectedValue;
            dtsTelas.SelectParameters["IDAplicacao"].DefaultValue = ddlAplicacao.SelectedValue;
            dtsPerfil.SelectParameters["IDAplicacao"].DefaultValue = ddlAplicacao.SelectedValue;            
        }

        protected void ddlAplicacao_DataBound(object sender, EventArgs e)
        {
            ddlAplicacao.Items.Insert(0, "Selecione");
        }

        protected void ddlTela_DataBound(object sender, EventArgs e)
        {
            ddlTela.Items.Insert(0, "Selecione");
        }

        protected void ddlTela_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtsOperacoes.SelectParameters["IDTela"].DefaultValue = ddlTela.SelectedValue;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if ((ltbPerfisCadastrados.SelectedIndex > 0) && (ddlTela.SelectedIndex > 0))
            {
                
                    PerfilSistemaBLL perfilsistemabll = new PerfilSistemaBLL();

                    var operacoesperfil = perfilsistemabll.GetOperacoesDoPerfil(int.Parse(ltbPerfisCadastrados.SelectedValue));

                    bool existe;

                    foreach (ListItem li in cblOperacao.Items)
                    {
                        existe = false;

                        if (li.Selected)
                        {
                            if (operacoesperfil != null)
                            {
                                foreach (vwOperacaoTelaPerfil to in operacoesperfil)
                                {
                                    if (int.Parse(li.Value) == to.IDOperacao)
                                    {
                                        existe = true;
                                    }
                                }
                            }
                            if (!existe)
                            {
                                perfilsistemabll.insertOperacaoTelaPerfil(int.Parse(li.Value),int.Parse(ddlTela.SelectedValue),int.Parse(ltbPerfisCadastrados.SelectedValue));
                            }
                        }
                        else
                        {
                            perfilsistemabll.deleteOperacaoTelaPerfil(int.Parse(li.Value), int.Parse(ddlTela.SelectedValue), int.Parse(ltbPerfisCadastrados.SelectedValue));
                        }
                    }
                                
            }
            else
            {
                String mensagem = "Escolha uma Tela";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensagem De Alerta", "alert('" + mensagem + "');", true);

            }
        }

        protected void ltbPerfisCadastrados_DataBound(object sender, EventArgs e)
        {
            ltbPerfisCadastrados.Items.Insert(0, "Selecione");
        }

        protected void btnSalvarPerfil_Click(object sender, EventArgs e)
        {
            
            if ((ddlAplicacao.SelectedIndex > 0)&&(Session["IDPerfil"] != null))
            {
                PerfilSistemaBLL perfilbll = new PerfilSistemaBLL();
                PerfilSistema perfil = new PerfilSistema()
                {
                    NomePerfil = txtPerfil.Text,
                    IDAplicacao = int.Parse(ddlAplicacao.SelectedValue)
                };
                perfilbll.InsertPerfilSistema(perfil);
            }
            else if (Session["IDPerfil"] != null)
            {
                PerfilSistemaBLL perfilbll = new PerfilSistemaBLL();
                PerfilSistema perfil = new PerfilSistema();   
                perfil = perfilbll.GetPerfilSistemaByID(Convert.ToInt32(Session["IDPerfil"]));
                perfil.NomePerfil = txtPerfil.Text;
                perfilbll.UpdatePerfilSistema(perfil);
                dtsPerfil.DataBind();
                ltbPerfisCadastrados.DataBind();    
            }
        }

        protected void btnExcluirperfil_Click(object sender, EventArgs e)
        {
            PerfilSistemaBLL perfilbll = new PerfilSistemaBLL();
            if (perfilbll.GetUsuarioDoPerfil(int.Parse(ltbPerfisCadastrados.SelectedValue)).Count() > 0)
            {
                String mensagem = "Existem usuários associados a este perfil.";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensagem De Alerta", "alert('" + mensagem + "');", true);
            }
            else
            {
                perfilbll.DeletePerfilSistema(int.Parse(ltbPerfisCadastrados.SelectedValue));
                dtsPerfil.DataBind();
                ltbPerfisCadastrados.DataBind();
            }
        }

        protected void ltbPerfisCadastrados_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["IDPerfil"] = ltbPerfisCadastrados.SelectedValue;
            dtsOperacoesPermitidas.SelectParameters["IDPerfil"].DefaultValue = ltbPerfisCadastrados.SelectedValue;
            txtPerfil.Text = ltbPerfisCadastrados.SelectedItem.ToString();
        }

    }
}