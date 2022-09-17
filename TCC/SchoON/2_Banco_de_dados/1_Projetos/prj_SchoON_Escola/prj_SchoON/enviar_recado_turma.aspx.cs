using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prj_SchoON.cls;
using System.IO;
using System.Threading;
using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;

namespace prj_SchoON
{
    public partial class enviar_recado_turma : System.Web.UI.Page
    {
         string caminho_base = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            ClsEnviarRecado EnviarRecado = new ClsEnviarRecado();
            List<string> siglas_turmas = new List<string>();
            List<string> nome_recado = new List<string>();
            nome_recado = EnviarRecado.nome_tipo_recado();
            siglas_turmas = EnviarRecado.Sigla_Turma();

             if (Session["emailUsuario"] != null && Session["emailUsuario"].ToString() != "")
            {
                 lit_nome_usuario.Text = Session["nomeUsuario"].ToString();
            }
             else
             {
                 Response.Redirect("index.aspx");
             }


            if (!IsPostBack)
            {
                for (int i = 0; i < nome_recado.Count; i++)
                {
                    tipos_recados_turma.Items.Add(nome_recado[i]);
                }
                tipos_recados_turma.Items.Insert(0, new ListItem("-- Tipos Recado --", ""));
                for (int i = 0; i < siglas_turmas.Count; i++)
                {
                    dp_turmas.Items.Add(siglas_turmas[i]);
                }
                dp_turmas.Items.Insert(0, new ListItem("-- Turmas --", ""));

            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {

            caminho_base = Request.PhysicalApplicationPath + @"\uploads";
            ClsEnviarRecado EnviarRecado = new ClsEnviarRecado();
            DirectoryInfo diretorio = new DirectoryInfo(caminho_base);
            FileInfo[] lista_arquivos = diretorio.GetFiles();
            List<string> siglas_turmas = new List<string>();
            List<string> nome_recado = new List<string>();
            List<string> cd_aluno = new List<string>();
           
             List<string> email_responsavel = new List<string>();


             cd_aluno = EnviarRecado.CodigoAluno(dp_turmas.SelectedIndex.ToString());
           
            string emailUsuario = "";

            if (fl_upload_imagen_turma.PostedFile != null)
            {
                string nome_original_arquivo = Path.GetFileName(fl_upload_imagen_turma.PostedFile.FileName);
                string tipo_arquivo = fl_upload_imagen_turma.PostedFile.ContentType;

                int tamanho_arquivo = fl_upload_imagen_turma.PostedFile.ContentLength;


                fl_upload_imagen_turma.PostedFile.SaveAs(Request.PhysicalApplicationPath + @"uploads\" + nome_original_arquivo + ".jpg");

            }

           

            if (Session["emailUsuario"] != null && Session["emailUsuario"].ToString() != "")
            {
                emailUsuario = Session["emailUsuario"].ToString();
            }
            string cd_tipo_recado = tipos_recados_turma.SelectedIndex.ToString();

            /*Email de cada responsavel, codigo aluno,*/




            for (int i = 0; i < cd_aluno.Count; i++)
            {
                DateTime localDate = DateTime.Now;
                 Thread.Sleep(1500);

                 DateTime dataform = Convert.ToDateTime(localDate);
                 string date = "";
                 date = dataform.ToString("yyyy-MM-dd HH:mm:ss");
              /*/   EnviarRecado.enviar_recado(cd_tipo_recado, emailUsuario,EnviarRecado.email_responsavel(cd_aluno[i]),
                    date, txtDescricaoRecado.Text, cd_aluno[i], diretorio.ToString(),txt_titulo.Text,"0","0");
               * */
            }
            
            Response.Redirect("enviados.aspx");
        }

        protected void btnEnviarRecadoTurma_Click(object sender, EventArgs e)
        {
            string emailUsuario = "";
            if (Session["emailUsuario"] != null && Session["emailUsuario"].ToString() != "")
            {
                emailUsuario = Session["emailUsuario"].ToString();
            }



            ClsEnviarRecado EnviarRecado = new ClsEnviarRecado();


      
            string cd_tipo_recado = tipos_recados_turma.SelectedIndex.ToString();
            List<string> siglas_turmas = new List<string>();
            List<string> nome_recado = new List<string>();
            List<string> cd_aluno = new List<string>();

            cd_aluno = EnviarRecado.CodigoAluno(dp_turmas.SelectedIndex.ToString());
            byte[] foto = null;
            #region Conexão
            MySqlConnection conexao = new MySqlConnection("SERVER=localhost;UID=root;PASSWORD=root;DATABASE=prjschoon");
            try
            {
                conexao.Open();
            }
            catch
            {
            }
            #endregion
            HttpPostedFile postedFile = fl_upload_imagen_turma.PostedFile;
            string filename = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(filename);
            int fileSize = postedFile.ContentLength;
            MySqlCommand cSQL = new MySqlCommand();
            if (fl_upload_imagen_turma.HasFile == true)
            {
                #region Tratamanento da Imagem
                MemoryStream ms = new MemoryStream();
                Bitmap figura = new Bitmap(fl_upload_imagen_turma.FileContent);
                figura.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                foto = ms.ToArray();
                #endregion

            }




            List<string> cd_alunos = new List<string>();
            cd_alunos = EnviarRecado.CodigoAluno(dp_turmas.SelectedIndex.ToString());
            for (int i = 0; i < cd_alunos.Count; i++)
            {
                DateTime localDate = DateTime.Now;



                string date = "";

                int microsecond = 0;
                microsecond = localDate.Millisecond * 1000;


                date = localDate.ToString("yyyy-MM-dd HH:mm:ss") + "." + microsecond.ToString();

                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }


                cSQL = new MySqlCommand("Insert into  recado values (" + cd_tipo_recado + ",'" + emailUsuario + "','" +
               EnviarRecado.email_responsavel(cd_alunos[i]) + "','" + date + "','" + txt_descricao_recado_turma.Text + "'," + cd_alunos[i] + ",@img,'" +
               txt_titulo_recado_turma.Text + "',0,0)", conexao);
                cSQL.Parameters.Clear();
                MySqlParameter parametroImagem = new MySqlParameter("@img", MySqlDbType.Binary);
                parametroImagem.Value = foto;

                cSQL.Parameters.Add(parametroImagem);



                cSQL.ExecuteNonQuery();
                conexao.Close();






            }















            Response.Redirect("enviados.aspx");

        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("index.aspx");
        }

    }
}