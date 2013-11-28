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
    public partial class CadastroAplicacao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadAplicacoes();
        }

        void LoadAplicacoes()
        {
            dtsAplicacao.DataBind();
            gdvAplicacao.DataBind();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        protected void gdvAplicacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["IDAplicacao"] = gdvAplicacao.SelectedValue;            

            AplicacaoBLL aplicacoes = new AplicacaoBLL();
            Aplicacao aplicacao = new Aplicacao();

            aplicacao = aplicacoes.GetAplicacaoByID(Convert.ToInt32(Session["IDAplicacao"]));

            txtNomeAplicacao.Text = aplicacao.NomeAplicacao;
            txtDescricao.Text = aplicacao.Descricao;         

            btnExcluir.Enabled = true;
        }

        void LimparCampos()
        {
            btnExcluir.Enabled = false;
            txtDescricao.Text = null;
            txtNomeAplicacao.Text = null;
            Session["IdAplicacao"] = null;
        }

        void Salvar()
        {

            if (Session["IdAplicacao"] == null)
            {

                AplicacaoBLL bllAplicacao = new AplicacaoBLL();
                Aplicacao aplicacao = new Aplicacao()
                
                {
                    NomeAplicacao = txtNomeAplicacao.Text,
                    Descricao = txtDescricao.Text
                };              
               
                Session["IDAplicacao"] = bllAplicacao.Insert(aplicacao);
                LoadAplicacoes();      

                btnExcluir.Enabled = true;
            }
            else
            {
                
                AplicacaoBLL aplicacoes = new AplicacaoBLL();
                Aplicacao aplicacao = new Aplicacao();

                aplicacao = aplicacoes.GetAplicacaoByID(Convert.ToInt32(Session["IDAplicacao"]));

                aplicacao.NomeAplicacao = txtNomeAplicacao.Text;
                aplicacao.Descricao = txtDescricao.Text;

                aplicacoes.Update(aplicacao);
               
                LoadAplicacoes();                

                btnExcluir.Enabled = true;
            }
        }
        

        protected void btnSalvarNovo_Click(object sender, EventArgs e)
        {
            Salvar();
            LimparCampos();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            AplicacaoBLL aplicacoes = new AplicacaoBLL();
            Aplicacao aplicacao = new Aplicacao();           

            aplicacoes.Delete(Convert.ToInt32(Session["IdAplicacao"]));      

            LimparCampos();
            LoadAplicacoes();            
        }
    }
}