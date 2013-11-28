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
    public partial class cadastroperfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        protected void ddlAplicacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAplicacao.SelectedIndex > 0)
            {
                LoadPerfil();
            }
            LimparCampos();
        }

        void LoadPerfil()
        {
            dtsPerfis.SelectParameters["IDAplicacao"].DefaultValue = ddlAplicacao.SelectedValue;
            dtsPerfis.DataBind();
            gdvPerfisCadastrados.DataBind();
        }

        void Salvar()
        {
            if (ddlAplicacao.SelectedIndex > 0)
            {
                if (Session["IDPerfilSistema"] == null)
                {
                    PerfilSistemaBLL perfilsistemabll = new PerfilSistemaBLL();
                    PerfilSistema perfilsistema = new PerfilSistema()
                    {
                        NomePerfil = txtNomePerfil.Text,
                        IDAplicacao = Convert.ToInt32(ddlAplicacao.SelectedValue)
                    };

                    Session["IDPerfilSistema"] = perfilsistemabll.InsertPerfilSistema(perfilsistema);

                    LoadPerfil();
                }
                else
                {
                    PerfilSistemaBLL perfilsistemabll = new PerfilSistemaBLL();
                    PerfilSistema perfilsistema = new PerfilSistema();
                    
                    perfilsistema = perfilsistemabll.GetPerfilSistemaByID(Convert.ToInt32(Session["IDPerfilSistema"]));
                    perfilsistema.NomePerfil = txtNomePerfil.Text;
                    perfilsistemabll.UpdatePerfilSistema(perfilsistema);
                    LoadPerfil();
                }
            }
            else
            {
                String mensagem = "Escolha uma aplicacao";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensagem De Alerta", "alert('" + mensagem + "');", true);
            }
        }

        protected void ddlAplicacao_DataBound(object sender, EventArgs e)
        {
            ddlAplicacao.Items.Insert(0, "Selecione");
        }

        protected void btnSalvarNovo_Click(object sender, EventArgs e)
        {
            Salvar();
            LimparCampos();
        }

        void LimparCampos()
        {            
            Session["IDPerfilSistema"] = null;
            txtNomePerfil.Text = "";
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            PerfilSistemaBLL perfilsistemabll = new PerfilSistemaBLL();

            perfilsistemabll.DeletePerfilSistema(Convert.ToInt32(Session["IDPerfilSistema"]));

            LoadPerfil();
            LimparCampos();
        }

        protected void gdvPerfisCadastrados_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["IDPerfilSistema"] = gdvPerfisCadastrados.SelectedValue;
            PerfilSistemaBLL perfilsistemabll = new PerfilSistemaBLL();
            PerfilSistema perfilsistema = new PerfilSistema();
            perfilsistema = perfilsistemabll.GetPerfilSistemaByID(Convert.ToInt32(Session["IDPerfilSistema"]));
            txtNomePerfil.Text = perfilsistema.NomePerfil;

        }
    }
}