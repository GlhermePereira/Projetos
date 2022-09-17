using System;
using MySql.Data.MySqlClient;

namespace prj_schoon_pais.lib
{
    public partial class buscarNotificacao : System.Web.UI.Page
    {
        MySqlConnection conexao;
        MySqlCommand cSQL;
        MySqlDataReader dados;
     
        string comando = "";
        string linhaConexao = "SERVER=localhost;UID=root;PASSWORD=root;DATABASE=prjschoon";
        protected void Page_Load(object sender, EventArgs e)
        {
            string emailUsuario = "";


            if (Session["emailUsuario"] != null && Session["emailUsuario"].ToString() != "")
            {
                emailUsuario = Session["emailUsuario"].ToString();

            }

            string retorno = "";
            conexao = new MySqlConnection(linhaConexao);
            try
            {
                conexao.Open();
            }
            catch (Exception)
            {
                retorno = "0";
                if (conexao.State == System.Data.ConnectionState.Open) { conexao.Close(); conexao.Dispose(); }
                Response.Write(retorno);
                return;
            }
            comando = "SELECT count(ic_recado_lido) FROM recado where ic_recado_lido = 0 and nm_email_destinatario='" + emailUsuario + "'";
            cSQL = new MySqlCommand(comando, conexao);
            dados = cSQL.ExecuteReader();
            if (dados.HasRows)
            {
                if (dados.Read())
                {
                    if (int.Parse(dados[0].ToString()) > 0)
                    {
                        retorno = dados[0].ToString();
                    }
                    else
                    {
                        retorno = "0";
                    }

 
                }
            }
            else
            {
                retorno = "0";
                return;
            }
            if (!dados.IsClosed) { dados.Close(); }
            if (conexao.State == System.Data.ConnectionState.Open) { conexao.Close(); conexao.Dispose(); }

            Response.Write(retorno);
        }
    }
}