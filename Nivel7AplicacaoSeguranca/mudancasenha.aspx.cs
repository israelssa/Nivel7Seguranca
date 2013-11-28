using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nivel7BLLSeguranca;

namespace Nivel7AplicacaoSeguranca
{
    public partial class mudancasenha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Session["IDUsuario"] != null)
            {
                UsuarioBLL usuariobll = new UsuarioBLL();
                usuariobll.AtualizarSenha(Convert.ToInt32(Session["IDUsuario"]), Convert.ToInt32(Session["IDAplicacao"]), txtValidSenha.Text);
                String mensagem = "Senha Atualizada com sucesso.";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensagem De Alerta", "alert('" + mensagem + "');", true);
            }
            else
            {
                String mensagem = "Selecione um usuário.";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensagem De Alerta", "alert('" + mensagem + "');", true);
            }
        }

        protected void grdUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["IDUsuario"] = grdUsuario.SelectedDataKey["IDUsuario"];
            Session["IDAplicacao"] = grdUsuario.SelectedDataKey["IDAplicacao"];
        }
    }
}