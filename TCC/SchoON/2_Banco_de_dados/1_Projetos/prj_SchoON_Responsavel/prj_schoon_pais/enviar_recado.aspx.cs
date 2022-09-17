using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prj_schoon_pais.cls;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;
using System.Drawing;
namespace prj_schoon_pais
{
    public partial class enviar_recado : System.Web.UI.Page
    {
        string caminho_base = "";
        string emailUsuario = "";
        string codigo_aluno = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            ClsEnviarRecado EnviarRecado = new ClsEnviarRecado();
            List<string> emails = new List<string>();
            List<string> siglas_turmas = new List<string>();
            List<string> nome_recado = new List<string>();
            List<string> nome_funcionario = new List<string>();

           nome_funcionario=  EnviarRecado.nome_func();
            nome_recado = EnviarRecado.nome_tipo_recado();
            siglas_turmas = EnviarRecado.Sigla_Turma();


           

            if (!IsPostBack)
            {
                for (int i = 0; i < nome_recado.Count; i++)
                {
                    dropDownTipoRecado.Items.Add(nome_recado[i]);
                }
                dropDownTipoRecado.Items.Insert(0, new ListItem("-- Assunto --", ""));

                for (int i = 0; i < nome_funcionario.Count; i++)
                {
                    dp_nm_funcionarios.Items.Add(nome_funcionario[i]);
                    
                }
                dp_nm_funcionarios.Items.Insert(0,new ListItem(" Funcionario ",""));




            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (Session["emailUsuario"] != null && Session["emailUsuario"].ToString() != "")
            {
                emailUsuario = Session["emailUsuario"].ToString();
            }


            DateTime localDate = DateTime.Now;
            ClsEnviarRecado EnviarRecado = new ClsEnviarRecado();
            DateTime dataform = Convert.ToDateTime(localDate);
            string date = "";
            date = dataform.ToString("yyyy-MM-dd HH:mm:ss");
            codigo_aluno = EnviarRecado.CdAluno(emailUsuario);
            string cd_tipo_recado = dropDownTipoRecado.SelectedIndex.ToString();


          
            MySqlCommand cSQL = new MySqlCommand();

           
            #region Conexão
            MySqlConnection conexao = new MySqlConnection("SERVER=localhost;UID=root;PASSWORD=root;DATABASE=prjschoon");
            try
            {
                conexao.Open();
            }
            catch
            {
            }
            #endregion




                cSQL = new MySqlCommand("Insert into  recado values (" + codigo_aluno + ",'" + emailUsuario + "','" +
                    EnviarRecado.email_funcionario(dp_nm_funcionarios.SelectedValue.ToString()) + "','" + date + "','" + txtDescricaoRecado.Text + "'," + codigo_aluno + ",null,'" + txt_titulo.Text + "',0,0)", conexao);
                cSQL.Parameters.Clear();
                // EnviarRecado.enviar_recado(cd_tipo_recado, emailUsuario, EnviarRecado.email_responsavel(codigo_aluno),
                //     date, txtDescricaoRecado.Text, codigo_aluno, foto.ToString(), txt_titulo.Text, "0", "0");
            
               
                // EnviarRecado.enviar_recado(cd_tipo_recado, emailUsuario, EnviarRecado.email_responsavel(txtCodigoAluno.Text),
                //  date, txtDescricaoRecado.Text, txtCodigoAluno.Text, foto.ToString(), txt_titulo.Text, "0", "0");
            



            


            try
            {
                cSQL.ExecuteNonQuery();
                if (conexao.State == ConnectionState.Open) { conexao.Close(); }

            }
            catch
            {
                if (conexao.State == ConnectionState.Open) { conexao.Close(); }

            }
















            Response.Redirect("enviados.aspx");

        }

        protected void dp_nm_funcionarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClsEnviarRecado EnviarRecado = new ClsEnviarRecado();
        




            

        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("index.aspx");
        }
    }
}