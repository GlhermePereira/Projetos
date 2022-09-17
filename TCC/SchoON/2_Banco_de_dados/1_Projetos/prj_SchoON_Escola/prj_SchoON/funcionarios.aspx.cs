using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prj_SchoON.cls;

namespace prj_SchoON
{
    public partial class funcionarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string emailUsuario = "";
            string TipoUsuario = "";
            string Fucnionarios = "";

            if (Session["emailUsuario"] != null && Session["emailUsuario"].ToString() != "")
            {
                emailUsuario = Session["emailUsuario"].ToString();

            }
            else
            {
                Response.Redirect("index.aspx");
            }
            clsCadastrarFuncionario CadastrarFuncionarios = new clsCadastrarFuncionario();
            List<string> nome_funcio = new List<string>();
            List<string> nome_email_funcio = new List<string>();
            nome_funcio = CadastrarFuncionarios.nomes_funcionarios();
            nome_email_funcio = CadastrarFuncionarios.emails_funcionarios();

            for (int i = 0; i < nome_email_funcio.Count; i++)
            {
                Session["nome_func"] = nome_funcio[i].ToString();
                Session["emailfunc"] = nome_email_funcio[i].ToString();
                Fucnionarios+="<div class='funcionario'>";
                Fucnionarios+="<div class='paddingFuncionario'>";
                        

                    Fucnionarios+="        <span class='nomeFuncionario'>"+ nome_funcio[i].ToString()+"</span>";
                      Fucnionarios+="      <span class='emailFuncionario'>"+nome_email_funcio[i].ToString()+"</span>";

                     Fucnionarios+="       <div class='fr areaBotaoExluir'>";

                     Fucnionarios += "        <a  href='excluir_funcionario.aspx' class='botaoExcluir'>Excluir    </a>";
                        Fucnionarios+="    </div>";
                            
                     Fucnionarios+="   </div>";
              Fucnionarios+="      </div>";
             Fucnionarios+="   <div class='espacamento'></div>";
            }
            lt_funcionarios.Text = Fucnionarios;
            



        }

        protected void btn_cadastrar_func_Click(object sender, EventArgs e)
        {
            Response.Redirect("importar_funcionarios.aspx");
        }

        protected void txt_nm_funcionario_TextChanged(object sender, EventArgs e)
        {

            string emailUsuario = "";
            string TipoUsuario = "";
            string Fucnionarios = "";

            if (Session["emailUsuario"] != null && Session["emailUsuario"].ToString() != "")
            {
                emailUsuario = Session["emailUsuario"].ToString();

            }
            else
            {
                Response.Redirect("index.aspx");
            }
            clsCadastrarFuncionario CadastrarFuncionarios = new clsCadastrarFuncionario();
            List<string> nome_funcio = new List<string>();
            List<string> nome_email_funcio = new List<string>();
            nome_funcio = CadastrarFuncionarios.nomes_funcionarios();
            nome_email_funcio = CadastrarFuncionarios.emails_funcionarios();

            for (int i = 0; i < nome_email_funcio.Count; i++)
            {
                if (nome_funcio[i].ToString()==txt_nm_funcionario.Text)
                { 
                    Fucnionarios += "<div class='funcionario'>";
                Fucnionarios += "<div class='paddingFuncionario'>";


                Fucnionarios += "        <span id='nm_func' class='nomeFuncionario'>" + nome_funcio[i].ToString() + "</span>";
                Fucnionarios += "      <span id='nm_email_func' class='emailFuncionario'>" + nome_email_funcio[i].ToString() + "</span>";

                Fucnionarios += "       <div class='fr areaBotaoExluir'>";

                Fucnionarios += "      <a  href='excluir_funcionarios' class='botaoExcluir'>Excluir    </a>";
                Fucnionarios += "    </div>";

                Fucnionarios += "   </div>";
                Fucnionarios += "      </div>";
                Fucnionarios += "   <div class='espacamento'></div>";
                    
                }
               
            }
            lt_funcionarios.Text = Fucnionarios;
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("index.aspx");
        }
    }
}