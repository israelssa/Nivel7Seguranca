using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nivel7DALSeguranca;
using Nivel7BLLSeguranca;

namespace Nivel7AplicacaoSeguranca
{
    public partial class cadastrotelasistema : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            TelaSistemaBLL telasistemabll = new TelaSistemaBLL();         

            telasistemabll.Delete(Convert.ToInt32(Session["IDTela"]));

            LoadTelas();
            LimparCampos();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        protected void Salvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        protected void grdTelas_SelectedIndexChanged(object sender, EventArgs e)
        { 
            TelaSistemaBLL telas = new TelaSistemaBLL();
            TelaSistema tela = new TelaSistema();

            Session["IDTela"] = grdTelas.SelectedValue;

            tela = telas.getTelaByID(Convert.ToInt32(grdTelas.SelectedValue));

            txtCodTela.Text = tela.CodigoTela.ToString();
            txtNomeArquivo.Text = tela.NomeArquivo;
            txtNomeTela.Text = tela.NomeTela;

            btnExcluir.Enabled = true;
        }

        void LoadTelas() 
        {
            dtsTelasdaAplicacao.SelectParameters["IDAplicacao"].DefaultValue = ddlAplicacao.SelectedValue;
            dtsTelasdaAplicacao.DataBind();
            grdTelas.DataBind();
        }

        void LimparCampos()
        {
            if (MultiView1.ActiveViewIndex == 0)
            {
                txtCodTela.Text = "";
                txtNomeArquivo.Text = "";
                txtNomeTela.Text = "";
                Session["IDTela"] = null;
                btnExcluir.Enabled = false;
            } 
            if (MultiView1.ActiveViewIndex == 1)
            {
                foreach (ListItem li in cblOperacoes.Items)
                {
                    if (li.Selected == true)
                    {
                        li.Selected = false;
                    }
                }
            }
            
        }

        protected void btnSalvarNovo_Click(object sender, EventArgs e)
        {
            Salvar();
            LimparCampos();
        }

        void Salvar()
        {
            if (MultiView1.ActiveViewIndex == 0)
            {
                if (ddlAplicacao.SelectedIndex > 0)
                {
                    if (Session["IDTela"] == null)
                    {
                        TelaSistemaBLL telassistemabll = new TelaSistemaBLL();
                        TelaSistema telasistema = new TelaSistema()
                        {
                            NomeTela = txtNomeTela.Text,
                            CodigoTela = Convert.ToInt32(txtCodTela.Text),
                            NomeArquivo = txtNomeArquivo.Text,
                            IDAplicacao = int.Parse(ddlAplicacao.SelectedValue)
                        };

                        Session["IDTela"] = telassistemabll.Insert(telasistema);

                        LoadTelas();
                        btnExcluir.Enabled = true;
                    }
                    else
                    {
                        TelaSistemaBLL telas = new TelaSistemaBLL();
                        TelaSistema tela = new TelaSistema();

                        tela = telas.getTelaByID(Convert.ToInt32(Session["IDTela"]));

                        tela.NomeArquivo = txtNomeArquivo.Text;
                        tela.NomeTela = txtNomeTela.Text;
                        tela.CodigoTela = Convert.ToInt32(txtCodTela.Text);

                        telas.Update(tela);

                        LoadTelas();

                        btnExcluir.Enabled = true;
                    }
                }
                else
                {
                    String mensagem = "Escolha uma aplicacao";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensagem De Alerta", "alert('" + mensagem + "');", true);

                }
            }
            if (MultiView1.ActiveViewIndex == 1)
            {
                if (ddlTela.SelectedIndex > 0)
                {
                    Tela_OperacaoBLL telaoperacaobll = new Tela_OperacaoBLL();

                    var operacoesdatela = telaoperacaobll.GetTelaOperacaoByIDTela(int.Parse(ddlTela.SelectedValue));

                    bool existe;

                    foreach (ListItem li in cblOperacoes.Items)
                    {
                        existe = false;

                        if (li.Selected)
                        {
                            if (operacoesdatela != null)
                            {
                                foreach (vwTelaOperacao to in operacoesdatela)
                                {
                                    if (int.Parse(li.Value) == to.IDOperacao)
                                    {
                                        existe = true;
                                    }
                                }
                            }
                            if (!existe)
                            {
                                telaoperacaobll.Insert(int.Parse(ddlTela.SelectedValue), int.Parse(li.Value));
                            }
                        }
                        else
                        {
                            telaoperacaobll.Delete(int.Parse(ddlTela.SelectedValue), int.Parse(li.Value));
                        }
                    }
                    LoadOperacoesdaTela();
                }
                else
                {
                    String mensagem = "Escolha uma Tela";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensagem De Alerta", "alert('" + mensagem + "');", true);

                }
            }
            
        }

        protected void mnuTab_MenuItemClick(object sender, MenuEventArgs e)
        {
            switch (mnuTab.SelectedValue){
                case "Tela": MultiView1.ActiveViewIndex = 0;
                             btnSalvar.ValidationGroup = "tela";                            
                             btnSalvarNovo.ValidationGroup = "tela";
                             btnExcluir.Visible = true;
                             btnNovo.Visible = true;
                             btnSalvarNovo.Visible = true;                            
                break;

                case "Operacao": MultiView1.ActiveViewIndex = 1;
                                 btnSalvar.ValidationGroup = "operacao";                                 
                                 btnSalvarNovo.ValidationGroup = "operacao";
                                 btnExcluir.Visible = false;
                                 btnNovo.Visible = false;
                                 btnSalvarNovo.Visible = false;
                break;
                
            }
        }

        protected void ddlTela_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTela.SelectedIndex > 0)
            {
                OperacaoSistemaBLL operacaosistemabll = new OperacaoSistemaBLL();
                TelaSistemaBLL telasistemabll = new TelaSistemaBLL();
                TelaSistema telasistema = new TelaSistema();
                telasistema = telasistemabll.getTelaByID(int.Parse(ddlTela.SelectedValue));
                dtsOperacaoTela.SelectParameters["IDAplicacao"].DefaultValue = (telasistema.IDAplicacao).ToString();
                dtsOperacaoTela.DataBind();
                cblOperacoes.DataBind();
                LoadOperacoesdaTela();
            }            
        }

        void LoadOperacoesdaTela()
        {
            Tela_OperacaoBLL telaoperacaobll = new Tela_OperacaoBLL();

            var resultado = telaoperacaobll.GetTelaOperacaoByIDTela(Convert.ToInt32(ddlTela.SelectedValue));

            foreach (vwTelaOperacao campos in resultado)
            {
                foreach (ListItem li in cblOperacoes.Items)
                {
                    if (campos.IDOperacao == int.Parse(li.Value))
                    {
                        li.Selected = true;
                    }
                }
            }

            cblOperacoes.Enabled = true;
        }

        protected void ddlAplicacaovw1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimparCampos();
            if (ddlAplicacao.SelectedIndex > 0)
            {
                LoadTelas();
            }
        } 

        protected void ddlAplicacaovw1_DataBound(object sender, EventArgs e)
        {
            ddlAplicacao.Items.Insert(0, "Selecione");
        }

        protected void ddlTela_DataBound(object sender, EventArgs e)
        {
            ddlTela.Items.Insert(0, "Selecione");
        }

    }
}