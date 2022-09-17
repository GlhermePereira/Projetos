using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prj_SchoON.cls;

namespace prj_SchoON
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            lblVerificacao.Text = "";

            #region verificações de existencia

            if (txt_email.Text == "")
            {
                lblVerificacao.Text = "Digite o Email.";
                return;
            }

            if (txt_senha.Text == "")
            {
                lblVerificacao.Text = "Digite a senha.";
                return;
            }

            #endregion

            string email = txt_email.Text;
            string senha = txt_senha.Text;

            clsLogin classeLogin = new clsLogin();
            if (classeLogin.login(email, senha) == true)
            {
                Session["emailUsuario"] = txt_email.Text;
                Session["nomeUsuario"] = classeLogin.nome_destinatario(txt_email.Text);

                Response.Redirect("recados.aspx");


            }
            else
            {
                lblVerificacao.Text = "Email e/ou senha incorreto/s";
                txt_email.Text = "";
                txt_senha.Text = "";
                return;
            
            }
        }

    

 
       
    }
}