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
    public partial class cadastrooperacoes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
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
            OperacaoSistemaBLL operacoes = new OperacaoSistemaBLL();
            OperacaoSistema operacao = new OperacaoSistema();           

            operacoes.DeleteOperacao(Convert.ToInt32(Session["IDOperacao"]));          

            LimparCampos();
            LoadOperacoes(int.Parse(ddlAplicacao.SelectedValue));
        }

        protected void grdOperacoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["IDOperacao"] = grdOperacoes.SelectedValue;

            OperacaoSistemaBLL operacoes = new OperacaoSistemaBLL();
            OperacaoSistema operacao = new OperacaoSistema();

            operacao = operacoes.getOperacaoByIDOperacao(Convert.ToInt32(Session["IDOperacao"]));

            txtNomeOperacao.Text = operacao.NomeOperacao;

            operacoes = null;
            operacao = null;
            btnExcluir.Enabled = true;
        }

        void Salvar()
        {
            if (Session["IDOperacao"] == null)
            {
                OperacaoSistemaBLL operacoes = new OperacaoSistemaBLL();
                OperacaoSistema operacao = new OperacaoSistema()
                {
                    IDAplicacao = Convert.ToInt32(ddlAplicacao.SelectedValue) ,
                    NomeOperacao = txtNomeOperacao.Text
                };

                Session["IDOperacao"] =  operacoes.InsertOperacao(operacao);

                LoadOperacoes(int.Parse(ddlAplicacao.SelectedValue));
                btnExcluir.Enabled = true;

                operacoes = null;
                operacao = null;               
            }
            else
            {
                OperacaoSistemaBLL operacoes = new OperacaoSistemaBLL();
                OperacaoSistema operacao = new OperacaoSistema();

                operacao = operacoes.getOperacaoByIDOperacao(Convert.ToInt32(Session["IDOperacao"]));

                operacao.NomeOperacao = txtNomeOperacao.Text;

                operacoes.UpdateOperacao(operacao);

                LoadOperacoes(int.Parse(ddlAplicacao.SelectedValue));

                operacoes = null;
                operacao = null;
            }           
            
        }
        void LoadOperacoes(int IDAplicacao)
        {
            dtsOperacao.SelectParameters["IDAplicacao"].DefaultValue = IDAplicacao.ToString();
            dtsOperacao.DataBind();
            grdOperacoes.DataBind();
        }

        void LimparCampos()
        {
            Session["IDOperacao"] = null;
            txtNomeOperacao.Text = "";
            btnExcluir.Enabled = false;        
        }

        protected void ddlAplicacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAplicacao.SelectedIndex > 0)
            {
                txtNomeOperacao.Enabled = true;
                LoadOperacoes(int.Parse(ddlAplicacao.SelectedValue));
                LimparCampos();
            }
        }

        protected void ddlAplicacao_DataBound(object sender, EventArgs e)
        {
            ddlAplicacao.Items.Insert(0,"Selecione");
        }
    }
}