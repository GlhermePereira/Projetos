using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace prj_SchoON.cls
{
     class clsLogin:clsBanco
    {
         public string email { get; set; }
         public string senha { get; set; }
         public string TipoUsuario { get; set; }

           public clsLogin():base()
           {
               email = "";
                senha = "";
                TipoUsuario = "";
           }

           



           public string nome_destinatario(string email_funcionario)
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
               FecharConexao();
               return null;


           }
           public bool login(string email, string senha)
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
               FecharConexao();
               return false;

           }
    }
}