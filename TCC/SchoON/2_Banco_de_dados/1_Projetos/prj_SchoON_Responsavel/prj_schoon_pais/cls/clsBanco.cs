using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace prj_schoon_pais.cls
{
    public class clsBanco
    {
        #region Propriedades

        public string msg { get; set; }
        
        #endregion

        #region Variáveis

        public string linhaConexao = "";
        MySqlConnection conexao = null;
        MySqlCommand cSQL = null;

        #endregion

        #region Construtores

        public clsBanco()
        {
            linhaConexao = clsConexao.getConexao();
        }

        #endregion

        #region Abrir e fechar conexão
   
        private bool AbrirConexao()
        {
            linhaConexao = clsConexao.getConexao();

            conexao = new MySqlConnection(linhaConexao);

            try
            {
                if (conexao.State == ConnectionState.Closed)
	            {
		            conexao.Open();
	            }
            }
            catch (Exception erro)
            {
                msg = erro.Message;
                return false;
            }

            return true;
        }
       
 
        public void FecharConexao()
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }
      

        #endregion

        #region Consulta

        #region Consulta Comando
        public bool Consultar(string comando, ref MySqlDataReader dados)
        {
            if (AbrirConexao())
            {
                try
                {
                    MySqlCommand cSQL = new MySqlCommand(comando, conexao);
                    dados = cSQL.ExecuteReader();
                }
                catch (Exception erro)
                {
                    msg = erro.Message;
                    return false;
                }
            }

            else
            {
                return false;
            }
            return true;

        }
        #endregion

        #region Consulta por SP
        public bool ConsultaPorSP(string nmSP, string[,] args, ref MySqlDataReader dados)
        {
                   
           if (AbrirConexao())
            {
                try
                {
                    MySqlCommand cSQL = new MySqlCommand(nmSP, conexao);
                    cSQL.Parameters.Clear();
                    if (args != null)
                    {
                        for (int i = 0; i < args.Length/2; i++)
                        {
                            cSQL.Parameters.Add(new MySqlParameter(args[i,0], args[i,1]));
                        }
                    }
                    cSQL.CommandType = CommandType.StoredProcedure;
                    dados = cSQL.ExecuteReader();
                }
                catch (Exception erro)
                {
                    msg = erro.Message;
                    return false;
                }
            }

            else
            {
                return false;
            }
            return true;
        }
        #endregion

        #endregion

        #region Executar

        #region Executar
        public bool Executa(string comando)
        {
            MySqlCommand cSql = new MySqlCommand(comando, conexao);

            try
            {
                cSql.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Executa por SP
        public bool ExecutaPorSP(string nmSP, string[,] args)
        {

            if (AbrirConexao())
            {
                try
                {
                    MySqlCommand cSQL = new MySqlCommand(nmSP, conexao);
                    cSQL.Parameters.Clear();
                    if (args != null)
                    {
                        for (int i = 0; i < args.Length / 2; i++)
                        {
                            cSQL.Parameters.Add(new MySqlParameter(args[i, 0], args[i, 1]));
                        }
                    }
                    cSQL.CommandType = CommandType.StoredProcedure;
                    cSQL.ExecuteNonQuery();
                }
                catch (Exception erro)
                {
                    msg = erro.Message;
                    return false;
                }
            }

            else
            {
                return false;
            }
            return true;
        }
        #endregion

        #endregion

    }
}