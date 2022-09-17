using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace prj_schoon_pais.cls
{
    public class clsNotas:clsBanco
    {
        public string nm_materia { get; set; }
        public string aulas_totais { get; set; }
            public string qtSemanalMateria { get; set; }
            public string dtNota { get; set; }
            public string cdNotaAtribuida { get; set; }
            public string cdAluno { get; set; }
            public int cdBimestre { get; set; }


           


            public clsNotas()
                : base()
            {
                nm_materia = "";
                dtNota = "";
                qtSemanalMateria = "";
                cdNotaAtribuida = "";
                cdAluno = "";
                aulas_totais = "";
                cdBimestre = 0;
  
              
            }
            public bool selecionar_notas(string cd_aluno,string dt_nota,string cd_materia)
        {

            MySqlDataReader dados = null;
            string[,] valores = new string[3, 2];
            valores[0, 0] = "vCodigoAluno";
            valores[0, 1] = cd_aluno;
            valores[1, 0] = "vDataNota";
            valores[1, 1] = dt_nota.Substring(0,10);
            valores[2, 0] = "vCodigoMateria";
            valores[2, 1] = cd_materia;
    

            List<string> email_recebidos = new List<string>();
            List<string> notas_alunos = new List<string>();

            if (!ConsultaPorSP("nota_especifico", valores, ref dados))
            {
                FecharConexao();
                return false;
            }
            if (dados.HasRows)
            {
                if (dados.Read())
                {
                   
                    nm_materia = dados[0].ToString();
                    aulas_totais = dados[1].ToString();
                    qtSemanalMateria = dados[2].ToString();
                    dtNota = dados[3].ToString().Substring(0, 10);
                    cdBimestre = int.Parse(dados[3].ToString().Substring(0, 1));
                    cdNotaAtribuida = dados[4].ToString();

                   
                }

                if (!dados.IsClosed) { dados.Close(); }
                FecharConexao();
            }

            return true;
        }
          


            public List<string> datas_notas(string cd_aluno)
            {
                List<string> datas = new List<string>();

                string data_nota = "";
                datas.Clear();

                MySqlDataReader dados = null;
                string[,] valores = new string[1, 2];
                valores[0, 0] = "vCodigoAluno";
                valores[0, 1] = cd_aluno;
                if (!ConsultaPorSP("selecionar_notas", valores, ref dados))
                {
                    FecharConexao();
                }
                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        data_nota = dados[3].ToString().Substring(9, 1);
                        cdBimestre = int.Parse(data_nota);
                        datas.Add(dados[3].ToString());
                    }

                    if (!dados.IsClosed) { dados.Close(); }
                    FecharConexao();
                }
                return datas;
            }






            public List<string> codigos_materias(string cd_aluno)
            {
                List<string> codigos = new List<string>();

               
                codigos.Clear();

                MySqlDataReader dados = null;
                string[,] valores = new string[1, 2];
                valores[0, 0] = "vCodigoAluno";
                valores[0, 1] = cd_aluno;
                if (!ConsultaPorSP("selecionar_notas", valores, ref dados))
                {
                    FecharConexao();
                }
                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        codigos.Add(dados[5].ToString());
                      
                    }

                    if (!dados.IsClosed) { dados.Close(); }
                    FecharConexao();
                }
                return codigos;
            }





        public string Codigo_Aluno(string email_responsavel)
        {
            MySqlDataReader dados = null;
            
            if (Consultar("select cd_aluno from aluno where nm_email_responsavel='" + email_responsavel+"'", ref dados) == true)
            {

                if (dados.HasRows)
                {
                    if (dados.Read())
                    {
                        cdAluno = dados[0].ToString();

                    }

                    if (!dados.IsClosed) { dados.Close(); }
                    FecharConexao();
                }

                return cdAluno;

            }

            return null;


        }
    }
}