using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Threading;

namespace prj_SchoON.cls
{
    public class clsImportarAlunos:clsBanco
    {


        
          public string CodigoAluno { get; set; }
            public string Codigo_Turma { get; set; }
            public string AnoTurma { get; set; }


            public clsImportarAlunos()
                : base()
            {
              
                CodigoAluno = "";
                Codigo_Turma = "";
                AnoTurma = "";
            }


        public bool verificar_alunos(string cd_aluno, string cd_turma, string aa_turma)
        {
            MySqlDataReader dados = null;
            string[,] valores = new string[4, 2];
            valores[0, 0] = "vCodigo_Aluno";
            valores[0, 1] = cd_aluno;
            valores[1, 0] = "vCodigo_Turma";
            valores[1, 1] = cd_turma;
            valores[2, 0] = "vAno_Turma";
            valores[2, 1] = aa_turma;

            if (!ConsultaPorSP("verificar_alunos", valores, ref dados))
            {
                FecharConexao();
                return false;
            }
            if (dados.HasRows)
            {
                if (dados.Read())
                {
                    CodigoAluno = dados[0].ToString();
                    Codigo_Turma = dados[1].ToString();
                    AnoTurma = dados[2].ToString();

                    return false;
                    FecharConexao();
                }






            }
            FecharConexao();
            return true;




        }


        public bool inserir_alunos(string cd_aluno, string nm_aluno, string nm_email_responsavel)
        {
            /*cd_aluno,nm_aluno,nm_email_responsavel/*/
            MySqlDataReader dados = null;
            string[,] valores = new string[3, 2];
            valores[0, 0] = "vCodigo_Aluno";
            valores[0, 1] = cd_aluno;
            valores[1, 0] = "vNome_aluno";
            valores[1, 1] = nm_aluno;
            valores[2, 0] = "vNome_Email_Responsavel";
            valores[2, 1] = nm_email_responsavel;

         


            List<string> email_recebidos = new List<string>();

            if (!ConsultaPorSP("inserir_aluno", valores, ref dados))
            {
                FecharConexao();
                return false;
            }
            FecharConexao();
            return true;

        }
        public bool inserir_lista_aluno(string cd_aluno, string cd_turma, string aa_turma)
        {
            /*vCodigo_aluno,vData_Nota,vCodigo_Nota,vCodigo_Materia,vDs_Nota,vNota_Atribuida);/*/
            MySqlDataReader dados = null;
            string[,] valores = new string[3, 2];
            valores[0, 0] = "vCodigo_Aluno";
            valores[0, 1] = cd_aluno;
            valores[1, 0] = "vCodigo_Turma";
            valores[1, 1] = cd_turma;
            valores[2, 0] = "vAno_Turma";
            valores[2, 1] = aa_turma;
         


            List<string> email_recebidos = new List<string>();

            if (!ConsultaPorSP("inserir_lista_aluno", valores, ref dados))
            {
                FecharConexao();
                return false;
            }
            FecharConexao();
            return true;

        }



    }
}