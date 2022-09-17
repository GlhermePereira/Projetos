using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Threading;

namespace prj_SchoON.cls
{
    public class clsImportarNotas:clsBanco
    {

          public string cd_aluno { get; set; }
            public string data_nota { get; set; }
            public string cd_mateira { get; set; }


            public clsImportarNotas()
                : base()
            {
              
                cd_aluno = "";
                data_nota = "";
                cd_mateira = "";
            }



        public bool VerificarNotas( string cd_materia,string cd_aluno, string dt_nota)
        {
            MySqlDataReader dados = null;
            string[,] valores = new string[3, 2];
            valores[0, 0] = "vCodigo_Materia";
            valores[0, 1] = cd_materia;
            valores[1, 0] = "vCodigo_Aluno";
            valores[1, 1] = cd_aluno;
            valores[2, 0] = "vData_Nota";
            valores[2, 1] = dt_nota;

            if (!ConsultaPorSP("verificar_notas", valores, ref dados))
            {
                FecharConexao();
                return false;
            }
            if (dados.HasRows)
            {
                if (dados.Read())
                {
                     DateTime date_time = DateTime.Parse(dados[2].ToString());
                data_nota = date_time.ToString("yyyy-MM-dd");
                return false;
                }
               
               
     
              
                
           
            }
            return true;
            
          


        }

            public bool enviar_notas(string cd_aluno,string dt_nota, string cd_tipo_nota,string cd_materia,string ds_nota, string cd_trimestre,string cd_nota_atribuida)
            {
                /*vCodigo_aluno,vData_Nota,vCodigo_Nota,vCodigo_Materia,vDs_Nota,vNota_Atribuida);/*/
                MySqlDataReader dados = null;
                string[,] valores = new string[7, 2];
                valores[0, 0] = "vCodigo_aluno";
                valores[0, 1] = cd_aluno;
                valores[1, 0] = "vData_Nota";
                valores[1, 1] = dt_nota;
                valores[2, 0] = "vCodigo_Nota";
                valores[2, 1] = cd_tipo_nota;
                valores[3, 0] = "vCodigo_Materia";
                valores[3, 1] = cd_materia;
                valores[4, 0] = "vDs_Nota";
                valores[4, 1] = ds_nota;
                valores[4, 0] = "vTrimestre";
                valores[4, 1] = cd_trimestre;
                valores[5, 0] = "vNota_Atribuida";
                valores[5, 1] = cd_nota_atribuida;
               

                List<string> email_recebidos = new List<string>();

                if (!ConsultaPorSP("inserir_notas", valores, ref dados))
                {
                    FecharConexao();
                    return false;
                }
              
                return true;

            }



    }
}