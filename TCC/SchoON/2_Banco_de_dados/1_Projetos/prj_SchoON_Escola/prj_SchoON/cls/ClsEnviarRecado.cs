using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Threading;
using System.IO;
using System.Drawing;

namespace prj_SchoON.cls
{
    public class ClsEnviarRecado:clsBanco
    {

        public string nm_responsavel { get; set; }
        public string tipo_recado { get; set; }
        public string cd_tipo_recado { get; set; }
        public string cd_aluno { get; set; }
            public string nm_aluno { get; set; }
            public string nmEmailRemetente { get; set; }
            public string nm_email_responsavel { get; set; }
            public string dtRecado { get; set; }
            public string nmEmailDestinario { get; set; }
            public string ds_recado { get; set; }


            public ClsEnviarRecado()
                : base()
            {
                cd_aluno = "";
                nm_responsavel = "";
                nmEmailRemetente = "";
                nmEmailDestinario = "";
                nm_aluno = "";
                dtRecado = "";
                ds_recado = "";
                tipo_recado = "";
                cd_tipo_recado = "";
              
            }


            public List<string> CodigoAluno(string cd_turma)
            {



                List<string> codigos_alunos = new List<string>();
                MySqlDataReader dados = null;
                if (Consultar("select cd_aluno from lista_aluno where cd_turma='"+cd_turma+"'", ref dados) == true)
                {

                    if (dados.HasRows)
                    {
                        while (dados.Read())
                        {
                            codigos_alunos.Add(dados[0].ToString());

                        }

                        if (!dados.IsClosed) { dados.Close(); }
                        FecharConexao();
                    }

                    return codigos_alunos;

                }

                return null;


            }
            public string CodigoAlunoNome(string nome_aluno)
            {



                string codigos_alunos ="";
                MySqlDataReader dados = null;
                if (Consultar("select cd_aluno from aluno where nm_aluno='" + nome_aluno + "'", ref dados) == true)
                {

                    if (dados.HasRows)
                    {
                        while (dados.Read())
                        {
                            codigos_alunos = dados[0].ToString();

                        }

                        if (!dados.IsClosed) { dados.Close(); }
                        FecharConexao();
                    }

                    return codigos_alunos;

                }

                return null;


            }





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










            public string nome_aluno(string rm_aluno)
            {
                MySqlDataReader dados = null;
                if (Consultar("select nm_aluno,cd_aluno from aluno where cd_aluno='" + rm_aluno + "'", ref dados) == true)
                {

                    if (dados.HasRows)
                    {
                        if (dados.Read())
                        {
                            nm_aluno = dados[0].ToString();
                            cd_aluno = dados[1].ToString();
                            

                        }

                        if (!dados.IsClosed) { dados.Close(); }
                        FecharConexao();
                    }

                    return nm_aluno;

                }

                return null;


            }





            public string email_responsavel(string rm_aluno)
            {
                MySqlDataReader dados = null;
                if (Consultar("select nm_email_responsavel from aluno where cd_aluno="+rm_aluno, ref dados) == true)
                {

                    if (dados.HasRows)
                    {
                        if (dados.Read())
                        {
                            nm_email_responsavel = dados[0].ToString();

                        }

                        if (!dados.IsClosed) { dados.Close(); }
                        FecharConexao();
                    }

                    return nm_email_responsavel;

                }

                return null;


            }


            public string nome_responsavel(string email_responsavel)
            {
                MySqlDataReader dados = null;
                if (Consultar("select nm_usuario from usuario where nm_email_usuario='" + email_responsavel + "'", ref dados) == true)
                {

                    if (dados.HasRows)
                    {
                        if (dados.Read())
                        {
                            nm_responsavel = dados[0].ToString();

                        }

                        if (!dados.IsClosed) { dados.Close(); }
                        FecharConexao();
                    }

                    return nm_responsavel;

                }

                return null;


            }


            public string CdAluno(string email_responsavel)
            {
                string cd_aluno = "";
                MySqlDataReader dados = null;
                if (Consultar("select cd_aluno from aluno where nm_email_responsavel='" + email_responsavel + "'", ref dados) == true)
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







          



    }
}
