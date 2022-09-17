using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prj_schoon_pais.cls;
using System.IO;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Data;

namespace prj_schoon_pais
{
    public partial class enviar_recado_funcionario : System.Web.UI.Page
    {
        string caminho_base = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            ClsResponderRecados EnviarRecado = new ClsResponderRecados();
            List<string> emails = new List<string>();
            List<string> nome_recado = new List<string>();
            nome_recado = EnviarRecado.nome_tipo_recado();




            if (!IsPostBack)
            {
                for (int i = 0; i < nome_recado.Count; i++)
                {


                    dropDownTipoRecado.Items.Add(nome_recado[i]);
                }

               
                        lblNomeFuncionario.Text ="Destinatário: " + Session["nomeFuncionario"].ToString();
                        dropDownTipoRecado.Items.Insert(0, new ListItem("-- Tipos Recados --", ""));
            }











        }


       


        protected void btnEnviar_Click(object sender, EventArgs e)
        {

            string caminho_base = "";
                        string codigo_aluno = "";






            DateTime localDate = DateTime.Now;
            ClsResponderRecados EnviarRecado = new ClsResponderRecados();
            string emailUsuario = "";
            if (Session["emailUsuario"] != null && Session["emailUsuario"].ToString() != "")
            {
                emailUsuario = Session["emailUsuario"].ToString();
            }

            codigo_aluno = EnviarRecado.Codigo_Aluno(emailUsuario);

           
            DateTime dataform = Convert.ToDateTime(localDate);
            string date = "";
    
            int microsecond = 0;
            microsecond = dataform.Millisecond * 1000;
            date = dataform.ToString("yyyy-MM-dd HH:mm:ss") + "." + microsecond.ToString();
            MySqlCommand cSQL = new MySqlCommand();
           
            string cd_tipo_recado = dropDownTipoRecado.SelectedIndex.ToString();

            

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


            cSQL = new MySqlCommand("Insert into  recado values (" + cd_tipo_recado + ",'" + emailUsuario + "','" +
                  Session["emailFuncionario"].ToString() + "','" + date + "','" + txtDescricaoRecado.Text + "'," + codigo_aluno
                  + ",null,'" + txt_titulo.Text + "',1,0)", conexao);
            cSQL.Parameters.Clear();




         


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

        protected void btnSair_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("index.aspx");
        }
    }
}