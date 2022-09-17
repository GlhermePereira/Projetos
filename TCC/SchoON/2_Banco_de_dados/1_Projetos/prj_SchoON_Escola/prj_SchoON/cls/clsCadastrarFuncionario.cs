using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prj_SchoON.cls
{
    public class clsCadastrarFuncionario:clsBanco
    {
        public bool cadastrar_func(string cd_tipo_usuario, string nm_usuario, string nm_senha_usuario, string nm_email)
        {

            MySqlDataReader dados = null;
            string[,] valores = new string[4, 2];
            valores[0, 0] = "vCodigoTipoUsuario";
            valores[0, 1] = cd_tipo_usuario;
            valores[1, 0] = "vNomeUsuario";
            valores[1, 1] = nm_usuario;
            valores[2, 0] = "vNomeSenha";
            valores[2, 1] = nm_senha_usuario;
            valores[3, 0] = "vNomeEmail";
            valores[3, 1] = nm_email;



            List<string> email_recebidos = new List<string>();

            if (!ConsultaPorSP("inserir_funcionario", valores, ref dados))
            {
                FecharConexao();
                return false;
            }
            FecharConexao();
            return true;

        }

        public List<string> nomes_funcionarios()
        {

            List<string> nomes_func = new List<string>();
            MySqlDataReader dados = null;
            if (Consultar("select nm_usuario,nm_email_usuario from usuario where cd_tipo_usuario=2", ref dados) == true)
            {

                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        nomes_func.Add(dados[0].ToString());

                    }

                    if (!dados.IsClosed) { dados.Close(); }
                    FecharConexao();
                }

                return nomes_func;

            }
            FecharConexao();
            return null;


        }

        public List<string> emails_funcionarios()
        {

            List<string> emails_func = new List<string>();
            MySqlDataReader dados = null;
            if (Consultar("select nm_usuario,nm_email_usuario from usuario where cd_tipo_usuario=2", ref dados) == true)
            {

                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        emails_func.Add(dados[1].ToString());

                    }

                    if (!dados.IsClosed) { dados.Close(); }
                    FecharConexao();
                }

                return emails_func;

            }
            FecharConexao();
            return null;


        }

        public bool excluir_funcionario(string nm_usuario, string nm_email)
        {

            MySqlDataReader dados = null;
         



            List<string> email_recebidos = new List<string>();
            excluir_recados_enviados_func(nm_email);
            excluir_recados_recebidos_func(nm_email);
            if (!Consultar("  DELETE FROM usuario WHERE nm_usuario='"+nm_usuario+"' and nm_email_usuario='"+nm_email+"' and cd_tipo_usuario=2", ref dados))
            {
                FecharConexao();
                return false;
            }
            FecharConexao();
            return true;

        }
        public bool excluir_recados_recebidos_func(string nm_email)
        {

            MySqlDataReader dados = null;




            List<string> email_recebidos = new List<string>();

            if (!Consultar("delete  from recado where   nm_email_destinatario='"+nm_email+"'", ref dados))
            {
                FecharConexao();
                return false;
            }
            FecharConexao();
            return true;

        }

        public bool excluir_recados_enviados_func(string nm_email)
        {

            MySqlDataReader dados = null;




            List<string> email_recebidos = new List<string>();

            if (!Consultar("delete  from recado where   nm_email_remetente='" + nm_email + "'", ref dados))
            {
                FecharConexao();
                return false;
            }
            FecharConexao();
            return true;

        }










    }
}