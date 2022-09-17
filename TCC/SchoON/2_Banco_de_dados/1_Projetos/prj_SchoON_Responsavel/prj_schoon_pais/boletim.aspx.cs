using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using prj_schoon_pais.cls;
using MySql.Data.MySqlClient;
using System.Web.UI.DataVisualization.Charting;

namespace prjNotas
{
    public partial class boletim : System.Web.UI.Page
    {

        MySqlConnection conexao = null;
        MySqlCommand cSQL = null;
        MySqlDataReader data = null;
        MySqlDataReader data2 = null;
        string comando = "";
        string linhaConexao = "SERVER=localhost;UID=root;PASSWORD=root;DATABASE=prjschoon";
        
        protected void Page_Load(object sender, EventArgs e)
        {



            #region INSTANCIAMENTO E DECLARAÇÃO DE VARIAVEIS
            string emailUsuario = "";
            if (Session["emailUsuario"] != null && Session["emailUsuario"].ToString() != "")
            {
                emailUsuario = Session["emailUsuario"].ToString();

            }
            clsNotas notas = new clsNotas();
            clsBanco banco = new clsBanco();
            DataTable dados = new DataTable();
            DataTable dadosNota = new DataTable();
             string codMateria = "";
            string codTrimestre = "";
            
            #endregion

            DateTime moment = new DateTime();
            moment = DateTime.Today;
            int ano = moment.Year;

            #region BOLETIM, NOTAS E GRAFICOS DA MATERIA


                        #region boletim
            dados.Columns.Add("Matéria");
            dados.Columns.Add("1º Trimestre");
            dados.Columns.Add("2º Trimestre");
            dados.Columns.Add("3º Trimestre");
            dados.Columns.Add("Link 1º Trimestre");
            dados.Columns.Add("Link 2º Trimestre");
            dados.Columns.Add("Link 3º Trimestre");
            dados.Columns.Add("Frequência");


            if (notas.boletim(ref dados, emailUsuario, ano.ToString()))
            {
               
                dgvBoletim.DataSource = dados;
                dgvBoletim.DataBind();

            }
            #endregion

                        #region Detalhes sobre a nota clicada
            if (Request["cd_materia"] != null && Request["cd_trimestre"] != null)
            {
                if (!string.IsNullOrEmpty(Request["cd_materia"].ToString()) && !string.IsNullOrEmpty(Request["cd_trimestre"].ToString()))
                {
                    if (Request["cd_trimestre"].ToString() != "-")
                    {
                       
                        codMateria = Request["cd_materia"].ToString();
                        codTrimestre = Request["cd_trimestre"].ToString();



                        if (notas.notaEspecifica(codMateria, codTrimestre, ref dadosNota, emailUsuario))
                        {
                            dgvInformacaoNota.DataSource = dadosNota;
                            dgvInformacaoNota.DataBind();
                        }


#endregion


                        #region GRAFICOS

                        #region Grafico Nota Materia Especifica

                        conexao = new MySqlConnection(linhaConexao);
                        try
                        {
                            conexao.Open();
                        }
                        catch (Exception)
                        {
                            Response.Write("Erro na conexão com o Servidor");
                            return;
                        }

                        string comando = "select cd_nota_atribuida as 'Notas',cd_trimestre_nota as 'Trimestre'from nota where cd_tipo_nota = 4 and cd_materia= " + codMateria + " and cd_aluno= " + notas.codAluno(emailUsuario) + "";
                        cSQL = new MySqlCommand(comando, conexao);
                        data = cSQL.ExecuteReader();

                        chtNotas.DataSource = data;
                        chtNotas.DataBind();

                        if (!data.IsClosed) 
                        {
                            data.Close(); 
                        }

                        if (conexao.State == ConnectionState.Open) 
                        { 
                            conexao.Close();
                        }


                        #endregion

                        #region grafico faltas materia especificada

                        conexao = new MySqlConnection(linhaConexao);
                        try
                        {
                            conexao.Open();
                        }
                        catch (Exception)
                        {
                            Response.Write("Erro na conexão com o Servidor");
                            return;
                        }

                        string comando2 = "select sum(qt_falta_dia) as 'Faltas',cd_trimestre_aula as 'Trimestre' from aula  where cd_materia= " + codMateria + " and cd_aluno=" + notas.codAluno(emailUsuario) + " group by cd_trimestre_aula";
                        cSQL = new MySqlCommand(comando2, conexao);
                        data2 = cSQL.ExecuteReader();

                        chtFaltas.DataSource = data2;
                        chtFaltas.DataBind();

                        if (!data.IsClosed)
                        {
                            data2.Close();
                        }

                        if (conexao.State == ConnectionState.Open)
                        {
                            conexao.Close();
                        }


                        #endregion


                        #endregion
                    }
                }
            }

#endregion

  

        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("index.aspx");
        }
    }
}