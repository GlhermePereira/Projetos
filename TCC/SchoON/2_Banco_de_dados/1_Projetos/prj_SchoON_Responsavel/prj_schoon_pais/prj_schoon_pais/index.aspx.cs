using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prj_schoon_pais.cls;

namespace prj_schoon_pais
{
    public partial class index : System.Web.UI.Page
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

                if (classeLogin.tipoUsuario(email) == "1")
                {

                    Session["emailUsuario"] = txt_email.Text;
                    Session["nomeUsuario"] = classeLogin.nomeUsuario(txt_email.Text);

                    Response.Redirect("recados.aspx");
                }
                else
                {
                    lblVerificacao.Text = "Email não autorizado nessa plataforma. Utilize a plataforma para a escola.";
                }

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