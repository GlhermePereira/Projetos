using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace prj_schoon_pais.cls
{
    public class clsSelecionarHorario:clsBanco
    {

        
        public string nm_responsavel { get; set; }
        public string tipo_recado { get; set; }
        public string cd_tipo_recado { get; set; }
        public string cd_aluno { get; set; }
            public string nm_aluno { get; set; }
            public string nmEmailRemetente { get; set; }
            public string nm_email_responsavel { get; set; }
            public string img_recado { get; set; }
            public string Codigo_Sigla_Turma { get; set; }
            public string Codigo_Turma { get; set; }


            public clsSelecionarHorario()
                : base()
            {
                cd_aluno = "";
                nm_responsavel = "";
                nmEmailRemetente = "";
                Codigo_Sigla_Turma = "";
                nm_aluno = "";
                img_recado = "";
                Codigo_Turma = "";
                tipo_recado = "";
                cd_tipo_recado = "";
              
            }





            public bool selecionar_horario(string cd_turma) 
            {

               
                MySqlDataReader dados = null;
                if (Consultar("select  img_horario from turma where cd_turma="+cd_turma, ref dados) == true)
                {

                    if (dados.HasRows)
                    {
                        if (dados.Read())
                        {
                          
                           

                            if (dados[0] == null || dados[0].ToString() == "")
                            {
                                img_recado = "";
                            }
                            else
                            {
                                byte[] foto = (byte[])dados[0];
                                string base64String = Convert.ToBase64String(foto, 0, foto.Length);
                                img_recado = "";
                                img_recado += base64String;
                            }
                           



                        }

                        if (!dados.IsClosed) { dados.Close(); }
                        FecharConexao();
                    }
                    FecharConexao();
                    return true;

                }
                FecharConexao();
                return false;
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


            public string selecionar_turma_aluno(string cd_aluno)
            {


                MySqlDataReader dados = null;
                if (Consultar("select tm.img_horario,tm.cd_turma from turma tm join lista_aluno ls on (tm.cd_turma=ls.cd_turma) join aluno al on (ls.cd_aluno=al.cd_aluno) where ls.cd_aluno=" + cd_aluno, ref dados) == true)
                {

                    if (dados.HasRows)
                    {
                        if (dados.Read())
                        {



                            if (dados[0].ToString()==null || dados[0].ToString()=="")
                            {
                                return null;
                            }
                            else
                            {
                                byte[] foto = (byte[])dados[0];
                                string base64String = Convert.ToBase64String(foto, 0, foto.Length);
                                img_recado = "";
                                img_recado += base64String;
                            }




                        }

                        if (!dados.IsClosed) { dados.Close(); }
                        FecharConexao();
                    }
                    FecharConexao();
                    return img_recado;

                }
                FecharConexao();
                return null;
            }









            public List<string> Codigos_Turmas()
        {
            List<string> cd_turma = new List<string>();
            MySqlDataReader dados = null;
            if (Consultar("select  cd_turma,cd_sg_turma,img_horario from turma", ref dados) == true)
            {

                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        cd_turma.Add(dados[0].ToString());
                    


                    }

                    if (!dados.IsClosed) { dados.Close(); }
                    FecharConexao();
                }
                FecharConexao();
                return cd_turma;

            }
            FecharConexao();
            return null;


        }


            public List<string> Siglas_Turmas()
            {
                List<string> cd_Siglas = new List<string>();
                MySqlDataReader dados = null;
                if (Consultar("select  cd_turma,cd_sg_turma,img_horario from turma", ref dados) == true)
                {

                    if (dados.HasRows)
                    {
                        while (dados.Read())
                        {
                            cd_Siglas.Add(dados[1].ToString());



                        }

                        if (!dados.IsClosed) { dados.Close(); }
                        FecharConexao();
                    }
                    FecharConexao();
                    return cd_Siglas;

                }
                FecharConexao();
                return null;


            }


    }
}