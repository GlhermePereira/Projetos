using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace prj_schoon_pais.cls
{
     class clsLogin:clsBanco
    {

         public string email { get; set; }
         public string senha { get; set; }
         public string varTipoUsuario { get; set; }

           public clsLogin():base()
           {
                email = "";
                senha = "";
                varTipoUsuario = "";
  
           }


           public string tipoUsuario(string email_usuario) ///<summary> verifica o email e devolve o tipo do usario, em formato string </summary>
           {
               MySqlDataReader dados = null;
               string[,] valores = new string[2, 2];
               valores[0, 0] = "vEmail";
               valores[0, 1] = email_usuario;


               if (!ConsultaPorSP("verificar_tipo_usuario", valores, ref dados))
               {
                   FecharConexao();

               }
              
               if (dados.HasRows)
               {

                   if (dados.Read())
                   {
                       varTipoUsuario = dados[0].ToString();

                   }

                   if (!dados.IsClosed)
                   {
                       dados.Close();
                   }

                   FecharConexao();

               }
               return varTipoUsuario;
           }  
 
           public bool login(string email, string senha) ///<summary> verifica se o email e a senha estão corretos. Retorna bool. </summary>
           {
               MySqlDataReader dados = null;
               string[,] valores = new string[2, 2];
               valores[0, 0] = "vEmail";
               valores[0, 1] = email;
               valores[1, 0] = "vSenha";
               valores[1, 1] = senha;
               List<string> emailRecebidos = new List<string>();




               if (!ConsultaPorSP("login", valores, ref dados))
               {
                   FecharConexao();
                   return false;
               }
               if (dados.HasRows)
               {

                   if (dados.Read())
                   {
                       email = dados[0].ToString();
                       senha = dados[1].ToString();
                   }

                   if (!dados.IsClosed)
                   {
                       dados.Close(); 
                   }

                   FecharConexao();
                   return true;
               }
               return false;

           }

           public string nomeUsuario(string email_funcionario) ///<summary> verifica o email, e devolve o nome do usuario </summary>
           {
               MySqlDataReader dados = null;
               string nmUsuario = "";
               if (Consultar("select nm_usuario from usuario where nm_email_usuario='" + email_funcionario + "'", ref dados) == true)
               {

                   if (dados.HasRows)
                   {
                       if (dados.Read())
                       {
                           nmUsuario = dados[0].ToString();

                       }

                       if (!dados.IsClosed) { dados.Close(); }
                       FecharConexao();
                   }

                   return nmUsuario;

               }

               return null;


           }
  
     }
}