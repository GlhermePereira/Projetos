using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using prj_SchoON.cls;
using System.IO;

namespace prj_SchoON
{
    public partial class importar_funcionarios : System.Web.UI.Page
    {
        bool verificador = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["emailUsuario"] != null && Session["emailUsuario"].ToString() != "")
            {
                lit_nome_usuario.Text = Session["nomeUsuario"].ToString();
            }
            else
            {
                Response.Redirect("index.aspx");
            }
        }

       

        protected void btn_cadastrar_Click(object sender, EventArgs e)
        {
            clsCadastrarFuncionario CadastrarFuncionario = new clsCadastrarFuncionario();
            if (CadastrarFuncionario.cadastrar_func("2",txt_nome.Text,txt_senha.Text,txt_email.Text)==true)
            {
                  Response.Redirect("funcionarios.aspx");
            }
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("index.aspx");
        }
    }
}