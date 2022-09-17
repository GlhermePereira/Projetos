using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Threading;

namespace prj_SchoON.cls
{
    public class clsImportarPais:clsBanco
    {
        public bool importar_pais(string cd_tipo_usuario, string nm_usuario, string nm_senha_usuario, string cd_telefone,string nm_email)
        {
           
            MySqlDataReader dados = null;
            string[,] valores = new string[5, 2];
            valores[0, 0] = "vCodigoTipoUsuario";
            valores[0, 1] = cd_tipo_usuario;
            valores[1, 0] = "vNomeUsuario";
            valores[1, 1] = nm_usuario;
            valores[2, 0] = "vNomeSenha";
            valores[2, 1] = nm_senha_usuario;
            valores[3, 0] = "vCodigoTelefone";
            valores[3, 1] = cd_telefone;
            valores[4, 0] = "vNomeEmail";
            valores[4, 1] = nm_email;



            List<string> email_recebidos = new List<string>();

            if (!ConsultaPorSP("inserir_pai", valores, ref dados))
            {
                FecharConexao();
                return false;
            }
            FecharConexao();
            return true;

        }
    }
}