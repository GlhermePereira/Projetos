using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Threading;

namespace prj_schoon_pais.cls
{
    public class ClsResponderRecados:clsBanco
    {

      


         





            public List<string> nome_tipo_recado()
        {

            List<string> nomes_tipos_recados = new List<string>(); 
            MySqlDataReader dados = null;
            if (Consultar("select nm_tipo_recado from tipo_recado", ref dados) == true)
            {

                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        nomes_tipos_recados.Add(dados[0].ToString());

                    }

                    if (!dados.IsClosed) { dados.Close(); }
                    FecharConexao();
                }

                return nomes_tipos_recados;

            }

            return null;


        }

            public List<string> Sigla_Turma()
            {



                List<string> nomes_sigla_turma = new List<string>();
                MySqlDataReader dados = null;
                if (Consultar("select cd_sg_turma from turma", ref dados) == true)
                {

                    if (dados.HasRows)
                    {
                        while (dados.Read())
                        {
                            nomes_sigla_turma.Add(dados[0].ToString());

                        }

                        if (!dados.IsClosed) { dados.Close(); }
                        FecharConexao();
                    }

                    return nomes_sigla_turma;

                }

                return null;


            }


            public string CodigoTurma(string cd_sigla_turma)
            {


                string codigo_turma = "";
           
                MySqlDataReader dados = null;
                if (Consultar("select cd_turma from turma where cd_sg_turma='"+cd_sigla_turma+"'", ref dados) == true)
                {

                    if (dados.HasRows)
                    {
                        while (dados.Read())
                        {
                            codigo_turma=dados[0].ToString();

                        }

                        if (!dados.IsClosed) { dados.Close(); }
                        FecharConexao();
                    }

                    return codigo_turma;

                }

                return null;


            }










      


            public string Codigo_Aluno(string email_responsavel)
            {
                MySqlDataReader dados = null;
                string cd_aluno = "";
                if (Consultar("select cd_aluno from aluno where nm_email_responsavel='" + email_responsavel+"'", ref dados) == true)
                {

                    if (dados.HasRows)
                    {
                        if (dados.Read())
                        {
                            cd_aluno = dados[0].ToString();

                        }

                        if (!dados.IsClosed) { dados.Close(); }
                        FecharConexao();
                    }

                    return cd_aluno;

                }

                return null;


            }









            public bool enviar_recado(string cod_recado, string email_remetente,string email_destinario,string data_recado,string ds_recado,string cod_aluno,string imagen_recado) 
            {
                MySqlDataReader dados = null;
                string[,] valores = new string[7, 2];
                valores[0, 0] = "vCodigo_Recado";
                valores[0, 1] = cod_recado;
                valores[1, 0] = "vNome_Email_Remetente";
                valores[1, 1] = email_remetente;
                valores[2, 0] = "vNome_Email_Destinario";
                valores[2, 1] = email_destinario;
                valores[3, 0] = "vData_Recado";
                valores[3, 1] = data_recado;
                valores[4, 0] = "vDs_Recado";
                valores[4, 1] = ds_recado;
                valores[5, 0] = "vCodigo_aluno";
                valores[5, 1] = cod_aluno;
                valores[6, 0] = "vImagen_Recado";
                valores[6, 1] = imagen_recado;

                List<string> email_recebidos = new List<string>();

                if (!ConsultaPorSP("inserir_recado", valores, ref dados))
                {
                    FecharConexao();
                    return false;
                }
                if (dados.HasRows)
                {
                    if (dados.Read())
                    {
                        
                    }

                    if (!dados.IsClosed) { dados.Close(); }
                    FecharConexao();
                }
                return true;
	
            }



    }
}
