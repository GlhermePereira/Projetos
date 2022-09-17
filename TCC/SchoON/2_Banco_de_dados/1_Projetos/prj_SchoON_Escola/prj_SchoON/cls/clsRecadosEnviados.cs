using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Threading;

namespace prj_SchoON.cls
{
    public class clsRecadosEnviados:clsBanco
    {
        string date = "";
            public string nmRemetente { get; set; }
            public string nmUsuario { get; set; }
            public string dsRecado { get; set; }
            public string nmEmailRemetente { get; set; }
            public string dtRecado { get; set; }
            public string date_recado_milisecond { get; set; }

            public string email_usuario { get; set; }
            public string senha_usuario { get; set; }
            public string tipo_usuario { get; set; }
            public string TituloRecado { get; set; }
            public string TipoRecado { get; set; }
            public string NomeTipoRecado { get; set; }
            public string img_recado { get; set; }



            public clsRecadosEnviados()
                : base()
            {
                nmRemetente = "";
                date_recado_milisecond = "";
                nmEmailRemetente = "";
                dsRecado = "";
                dtRecado = "";
                email_usuario = "";
                nmUsuario = "";
                senha_usuario = "";
                tipo_usuario = "";
                TituloRecado = "";
                TipoRecado = "";
                NomeTipoRecado = "";
            }

            #region recados recebidos funcionario
            public List<string> emails_recebidos_funcionario(string EmailFuncionario)
            {
                List<string> emails = new List<string>();
                emails.Clear();

                MySqlDataReader dados = null;
                string[,] valores = new string[1, 2];

                valores[0, 0] = "vEmail_Funcionario";
                valores[0, 1] = EmailFuncionario;
                if (!ConsultaPorSP("todos_recados_enviados_func", valores, ref dados))
                {
                    FecharConexao();
                }
                if (dados.HasRows)
                {
                    while (dados.Read())
                    {

                        emails.Add(dados[5].ToString());
                    }

                    if (!dados.IsClosed) { dados.Close(); }
                    FecharConexao();
                }
                FecharConexao();
                return emails;
            }

            public string filt_nome_responsavel(string nm_responsavel)
            {
                MySqlDataReader dados = null;
                if (Consultar("select nm_usuario from usuario where nm_usuario='" + nm_responsavel + "'", ref dados) == true)
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



            public string Nome_Tipo_Recado_Funcionario(string cd_tipo_recado)
            {

                MySqlDataReader dados = null;
                if (Consultar("select nm_tipo_recado from tipo_recado where cd_tipo_recado='"+TipoRecado+"'", ref dados) == true)
                {

                    if (dados.HasRows)
                    {
                        while (dados.Read())
                        {
                            NomeTipoRecado = dados[0].ToString();
      

                        }

                        if (!dados.IsClosed) { dados.Close(); }
                        FecharConexao();
                    }

                    return NomeTipoRecado;

                }
                FecharConexao();
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
                FecharConexao();
                return null;


            }



            public bool Recados_enviados_funcionario(string EmailFuncionario, string DataRecado)
            {
                MySqlDataReader dados = null;
              
                string[,] valores = new string[2, 2];
                valores[0, 0] = "vEmail_Funcionario";
                valores[0, 1] = EmailFuncionario;
                valores[1, 0] = "vData_Recado";
                valores[1, 1] = DataRecado;

                List<string> email_recebidos = new List<string>();

                if (!ConsultaPorSP("recado_especifico_enviado_func", valores, ref dados))
                {
                    FecharConexao();
                    return false;
                }
                if (dados.HasRows)
                {
                    if (dados.Read())
                    {
                     
                        DateTime localDate = DateTime.Now;

    
                        
                        DateTime date_time_banco = DateTime.Parse(dados[3].ToString());
                        
                        string mesExtenso = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(date_time_banco.Month).ToLower();
                         int microsecond = 0;






                         microsecond = date_time_banco.Millisecond * 1000;
                         date_recado_milisecond = date_time_banco.ToString("yyyy-MM-dd HH:mm:ss") + "." + microsecond.ToString();
                       
       
                      
                
                       
                        
                       
                        
                        mesExtenso = char.ToUpper(mesExtenso[0]) + mesExtenso.Substring(1);
                        if (localDate.Month == date_time_banco.Month)
                        {
                            if (localDate.Day == date_time_banco.Day)
                            {
                                if (date_time_banco.Minute<10)
                                {
                                    dtRecado = date_time_banco.Hour.ToString()+" : "+  "0"+date_time_banco.Minute.ToString();
                                }
                                else
                                {
                                    dtRecado = date_time_banco.Hour.ToString()+" : "+  date_time_banco.Minute.ToString();
                                }
                                
                            }


                        }
                        else
                        {
                            dtRecado=date_time_banco.ToString("M");
                            
                        }


                        dsRecado = dados[2].ToString();
                        nmRemetente = dados[1].ToString();
                        nmEmailRemetente = dados[4].ToString();
                        TituloRecado = dados[0].ToString();
                        TipoRecado = dados[6].ToString();
                        Nome_Tipo_Recado_Funcionario(TipoRecado.ToString());

                    }
                    if (!dados.IsClosed) { dados.Close(); }
                    FecharConexao();
                }
         
                return true;
            }


            public bool Recado_especifico_enviado(string EmailFuncionario, string DataRecado)
            {
                MySqlDataReader dados = null;

                string[,] valores = new string[2, 2];
                valores[0, 0] = "vEmail_Funcionario";
                valores[0, 1] = EmailFuncionario;
                valores[1, 0] = "vData_Recado";
                valores[1, 1] = DataRecado;

                List<string> email_recebidos = new List<string>();

                if (!ConsultaPorSP("recado_especifico_enviado_func", valores, ref dados))
                {
                    FecharConexao();
                    return false;
                }
                if (dados.HasRows)
                {
                    if (dados.Read())
                    {
                        int microsecond = 0;
                        string data_local = "";
                        DateTime localDate = DateTime.Now;

                        microsecond = localDate.Millisecond * 1000;

                        DateTime date_time_banco = DateTime.Parse(dados[3].ToString());
                        data_local = localDate.ToString("yyyy-MM-dd HH:mm:ss") + "." + microsecond.ToString();
                        microsecond = date_time_banco.Millisecond * 1000;
                        date = date_time_banco.ToString("yyyy-MM-dd HH:mm:ss") + "." + microsecond.ToString();

         







                            dtRecado = date_time_banco.ToString("M");

                        

                        if (dados[7] == null || dados[7].ToString() == "")
                        {
                            img_recado = "";
                        }
                        else
                        {
                            byte[] foto = (byte[])dados[7];
                            string base64String = Convert.ToBase64String(foto, 0, foto.Length);
                            img_recado += base64String;
                        }

                        dsRecado = dados[2].ToString();
                        nmRemetente = dados[1].ToString();
                        nmEmailRemetente = dados[4].ToString();
                        TituloRecado = dados[0].ToString();
                        TipoRecado = dados[6].ToString();
                        Nome_Tipo_Recado_Funcionario(TipoRecado.ToString());
                    }
                    if (!dados.IsClosed) { dados.Close(); }
                    FecharConexao();
                }
          
                return true;
            }


            public List<string> datas_recados(string nm_email_func)
            {
                List<string> data = new List<string>();

                data.Clear();
                MySqlDataReader dados = null;
                string[,] valores = new string[1, 2];



                valores[0, 0] = "vEmail_Funcionario";
                valores[0, 1] = nm_email_func;
                if (!ConsultaPorSP("todos_recados_enviados_func", valores, ref dados))
                {

                    FecharConexao();

                }
                if (dados.HasRows)
                {
                    while (dados.Read())
                    {

                        DateTime dataform = Convert.ToDateTime(dados[3]);
                        int microsecond = 0;
                        microsecond = dataform.Millisecond * 1000;
                        date = dataform.ToString("yyyy-MM-dd HH:mm:ss") + "." + microsecond.ToString();
                        
                        
                        data.Add(date);



                    }

                }
                if (!dados.IsClosed)
                {
                    dados.Close();
                }

                FecharConexao();
                return data;
            }

            public string nome_destinatario(string email_funcionario)
            {
                MySqlDataReader dados = null;
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
            #endregion




    }
        
}
