using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace prj_schoon_pais.cls
{
     class clsNotas:clsBanco
    {


        public string aulasTotais { get; set; }
        public string faltasTotais { get; set; }
        public string frequenciaTotal { get; set; }
        public string cdAluno { get; set; }


         public bool boletim(ref DataTable dgvBoletim, string emailResponsavel, string ano)
         {
             MySqlDataReader data = null;   
             

             string[,] valores = new string[2, 2];
             valores[0, 0] = "vCodigoAluno";
             valores[0, 1] = codAluno(emailResponsavel);
             valores[1, 0] = "vAno";
             valores[1, 1] = ano;

             if (!ConsultaPorSP("selecionar_nota_trimestral",valores, ref data))
             {
                 FecharConexao();
                 return false;
             }
             else
             {
                 if (data.HasRows)
                 {
                     while (data.Read())
                     {
                         dgvBoletim.Rows.Add(data["Matéria"],data["1º Trimestre"], data["2º Trimestre"], data["3º Trimestre"],
                        "http://localhost:54653/boletim.aspx?cd_materia=" + data["cd_materia"].ToString() + "&cd_trimestre=1",
                        "http://localhost:54653/boletim.aspx?cd_materia=" + data["cd_materia"].ToString() + "&cd_trimestre=2",
                        "http://localhost:54653/boletim.aspx?cd_materia=" + data["cd_materia"].ToString() + "&cd_trimestre=3",
                         data["Frequência"]);                        
                     }
                     FecharConexao();
                 }
                 else 
                 {
                     FecharConexao();
                     return false;
                 }
             }

             return true;
         }

         public bool notaEspecifica(string cdMateria, string cdTrimestre, ref DataTable dgvNotaEsp, string emailResponsavel)
         {
             MySqlDataReader data = null;
             string[,] valores = new string[3, 2];
             valores[0, 0] = "vCodigoAluno";
             valores[0, 1] = codAluno(emailResponsavel);
             valores[1, 0] = "vCodigoTrimestre";
             valores[1, 1] = cdTrimestre;
             valores[2, 0] ="vCodigoMateria";
             valores[2, 1] = cdMateria;

             if (!ConsultaPorSP("nota_especifico", valores, ref data))
             {
                 FecharConexao();
                 return false;
             }
             else 
             {
                 if (data.HasRows)
                 {
                     dgvNotaEsp.Load(data);
                     FecharConexao();
                 }
                 else 
                 {
                     FecharConexao();
                     return false;
                 }
             }
             return true;
         }

         public string aulas()
         {
             MySqlDataReader data = null;

             if (Consultar("select sum(qt_total_aula_materia)from materia", ref data))
             {
                  if (data.HasRows)
                {
                    while (data.Read())
                    {
                        aulasTotais = data[0].ToString();

                    }

                    if (!data.IsClosed) 
                    { 
                        data.Close();
                    }
                    FecharConexao();

                    return aulasTotais;
                }
             }

            FecharConexao();
            return null;
         }

         public string faltas(string emailResponsavel)
         {
             MySqlDataReader data = null;

             if (Consultar("select sum(qt_falta_dia)from aula where cd_aluno= " + codAluno(emailResponsavel) +"", ref data))
             {
                 if (data.HasRows)
                 {
                     while (data.Read())
                     {
                         faltasTotais = data[0].ToString();

                     }

                     if (!data.IsClosed)
                     {
                         data.Close();
                     }
                     FecharConexao();

                     return faltasTotais;
                 }
             }

             FecharConexao();
             return null;
         }

         public string frequencia(string emailResponsavel)
         {
             double falta = 0.0;
             double aula = 0.0;
             double freq = 0.0;

             aula = double.Parse(aulas());
             falta = double.Parse(faltas(emailResponsavel));

             freq = Math.Round((100 - (falta * 100 / aula)),2);
             frequenciaTotal = freq.ToString() + "%" ;
             return frequenciaTotal;

         }

         public string codAluno(string emailResponsavel)
         {
             MySqlDataReader data = null;

             if (Consultar("select cd_aluno from aluno where nm_email_responsavel='" + emailResponsavel + "'", ref data))
             {
                 if (data.HasRows)
                 {
                     while (data.Read())
                     {
                         cdAluno = data[0].ToString();
                     }

                     if (!data.IsClosed)
                     {
                         data.Close();
                     }

                     FecharConexao();
                     return cdAluno;
                 }

             }

             FecharConexao();
             return null;
         }
    }
}