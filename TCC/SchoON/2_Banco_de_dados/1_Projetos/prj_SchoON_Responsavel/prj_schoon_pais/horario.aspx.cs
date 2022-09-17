using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prj_schoon_pais.cls;
using MySql.Data.MySqlClient;
using System.Data;

namespace prj_schoon_pais
{
    public partial class horario : System.Web.UI.Page
    {
        MySqlConnection conexao = null;
        MySqlCommand cSQL = null;
        MySqlDataReader data = null;
        string comando = "";
        string linhaConexao = "SERVER=localhost;UID=root;PASSWORD=root;DATABASE=prjschoon";
        protected void Page_Load(object sender, EventArgs e)
        {
            string emailUsuario = "";

            clsSelecionarHorario horarios = new clsSelecionarHorario();

            List<string> datas = new List<string>();

            string cadaRecado = "";


            if (Session["emailUsuario"] != null && Session["emailUsuario"].ToString() != "")
            {
                emailUsuario = Session["emailUsuario"].ToString();

            }



            string Turmas = "";
            List<string> Siglas = new List<string>();
            Siglas = horarios.Siglas_Turmas();
            Turmas = horarios.selecionar_turma_aluno(horarios.CdAluno(emailUsuario));

           









                        if (horarios.img_recado == "" || horarios.img_recado == null)
                        {
                            cadaRecado += "<span> Horario não existente </span>  ";
                        }
                        else
                        {
                          
                            cadaRecado += "       <figure>";
                            cadaRecado += "     <img class='imagemHorario' alt='Tabela de Horário escolar' src='data:image/jpeg;base64," + horarios.img_recado + "'>";
                            cadaRecado += "    </figure>";
                 
                        }











            lit_horarioEspecifico.Text = cadaRecado;





            #region INSTANCIAMENTO E DECLARAÇÃO DE VARIAVEIS
           
            if (Session["emailUsuario"] != null && Session["emailUsuario"].ToString() != "")
            {
                emailUsuario = Session["emailUsuario"].ToString();

            }
            clsNotas notas = new clsNotas();
            clsBanco banco = new clsBanco();
            DataTable dados = new DataTable();
            DataTable dadosNota = new DataTable();

            #endregion


            #region GRAFICOS

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

            string comando3 = "select sum(qt_falta_dia) as 'Faltas', cd_trimestre_aula as 'Trimestre' from aula where cd_aluno= " + notas.codAluno("marcelo.farias@gmail.com") + " group by cd_trimestre_aula";
            cSQL = new MySqlCommand(comando3, conexao);
            data = cSQL.ExecuteReader();

            chtFaltasTotais.DataSource = data;
            chtFaltasTotais.DataBind();

            if (!data.IsClosed)
            {
                data.Close();
            }

            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }

            #endregion


            
           lblAulasTotais.Text = notas.aulas(); //Quantidade total de aulas
            lblFaltasTotais.Text = notas.faltas(emailUsuario); //Quantidade total de faltas
            lblFrequencia.Text = notas.frequencia(emailUsuario); //Frequencia anual total em %

        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("index.aspx");
        }
    }
}