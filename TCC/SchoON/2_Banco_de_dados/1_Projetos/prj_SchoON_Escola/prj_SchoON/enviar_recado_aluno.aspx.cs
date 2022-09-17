using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prj_SchoON.cls;
using System.IO;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.Data;
using System.Threading;

namespace prj_SchoON
{
    public partial class enviar_recado : System.Web.UI.Page
    {
        string caminho_base = "";
        string emailUsuario = "";
        string codigo_aluno = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            ClsEnviarRecado EnviarRecado = new ClsEnviarRecado();
            List<string> emails = new List<string>();
            List<string> siglas_turmas = new List<string>();
            List<string> nome_recado = new List<string>();
           
            nome_recado=EnviarRecado.nome_tipo_recado();
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
                    dropDownTipoRecado.Items.Add(nome_recado[i]);
                }
                dropDownTipoRecado.Items.Insert(0, new ListItem("-- Assunto --", ""));
              

                for (int i = 0; i < siglas_turmas.Count; i++)
                {
                    DropDownTurma.Items.Add(siglas_turmas[i]);
                }
                DropDownTurma.Items.Insert(0, new ListItem("-- Turmas --", ""));

                dp_nm_alunos.Items.Insert(0, new ListItem("-- Nomes Alunos --", ""));

               



            }
         
        }

       
        protected void txtCodigoAluno_TextChanged(object sender, EventArgs e)
        {
             ClsEnviarRecado EnviarRecado = new ClsEnviarRecado();
            string codigo_aluno = txtCodigoAluno.Text;
          /*  string email_responsavel = EnviarRecado.email_responsavel(txtCodigoAluno.Text);/*/
            
             
                    lblNomeALuno.Text = EnviarRecado.nome_aluno(codigo_aluno);
                    lblNomeResponsavel.Text = EnviarRecado.nome_responsavel(EnviarRecado.email_responsavel(codigo_aluno));
       
         
               
            
            
        }


     


        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (Session["emailUsuario"] != null && Session["emailUsuario"].ToString() != "")
            {
                emailUsuario = Session["emailUsuario"].ToString();
            }

            
             DateTime localDate = DateTime.Now;
            ClsEnviarRecado EnviarRecado = new ClsEnviarRecado();
            DateTime dataform = Convert.ToDateTime(localDate);
            string date = "";
            byte[] foto = null;
            int microsecond = 0;
            microsecond = dataform.Millisecond * 1000;
            date = dataform.ToString("yyyy-MM-dd HH:mm:ss") + "." + microsecond.ToString();
            MySqlCommand cSQL = new MySqlCommand();
            codigo_aluno = dp_nm_alunos.SelectedIndex.ToString();
                  string cd_tipo_recado = dropDownTipoRecado.SelectedIndex.ToString();

                  if (fl_upload_imagen.HasFile==true)
                  {
                      HttpPostedFile postedFile = fl_upload_imagen.PostedFile;
            string filename = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(filename);
            int fileSize = postedFile.ContentLength;
           

            #region Tratamanento da Imagem
            MemoryStream ms = new MemoryStream();
            Bitmap figura = new Bitmap(fl_upload_imagen.FileContent);
            figura.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            foto = ms.ToArray();
            #endregion
                  }
            
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
         

        if (txtCodigoAluno.Enabled==false)
            {


                cSQL = new MySqlCommand("Insert into  recado values (" + cd_tipo_recado + ",'" + emailUsuario + "','" +
                    EnviarRecado.email_responsavel(codigo_aluno) + "','" + date + "','" + txtDescricaoRecado_turma.Text + "'," + codigo_aluno + ",@img,'" + txt_titulo.Text + "',0,0)", conexao);
            cSQL.Parameters.Clear();
               // EnviarRecado.enviar_recado(cd_tipo_recado, emailUsuario, EnviarRecado.email_responsavel(codigo_aluno),
               //     date, txtDescricaoRecado.Text, codigo_aluno, foto.ToString(), txt_titulo.Text, "0", "0");
            }
            else
            {
                cSQL = new MySqlCommand("Insert into  recado values (" + cd_tipo_recado + ",'" + emailUsuario + "','" +
                      EnviarRecado.email_responsavel(txtCodigoAluno.Text) + "','" + date + "','" + txtDescricaoRecado_turma.Text + "'," + txtCodigoAluno.Text 
                      + ",@img,'" + txt_titulo.Text + "',0,0)", conexao);
                cSQL.Parameters.Clear();
                // EnviarRecado.enviar_recado(cd_tipo_recado, emailUsuario, EnviarRecado.email_responsavel(txtCodigoAluno.Text),
                  //  date, txtDescricaoRecado.Text, txtCodigoAluno.Text, foto.ToString(), txt_titulo.Text, "0", "0");
            }

            

            MySqlParameter parametroImagem = new MySqlParameter("@img", MySqlDbType.Binary);
            parametroImagem.Value = foto;

            cSQL.Parameters.Add(parametroImagem);

            try
            {
                cSQL.ExecuteNonQuery();
                if (conexao.State == ConnectionState.Open) { conexao.Close(); }
               
            }
            catch
            {
                if (conexao.State == ConnectionState.Open) { conexao.Close(); }
             
            }


         

           

      
          

         

           
           

            
      
            Response.Redirect("enviados.aspx");
        }

        protected void DropDownTurma_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DropDownTurma.SelectedIndex != 0)
            {
                txtCodigoAluno.Enabled = false;
                dp_nm_alunos.Items.Clear();
                ClsEnviarRecado EnviarRecado = new ClsEnviarRecado();
                List<string> cd_alunos = new List<string>();
                lblNomeALuno.Text = "";
                lblNomeResponsavel.Text = "";
                cd_alunos = EnviarRecado.CodigoAluno(DropDownTurma.SelectedIndex.ToString());
                
                     for (int i = 0; i < cd_alunos.Count; i++)
                {
                    dp_nm_alunos.Items.Add(EnviarRecado.nome_aluno(cd_alunos[i]));
                }
                     dp_nm_alunos.Items.Insert(0, new ListItem("-- Nomes Alunos --", ""));
                
               
              
                
            }
           
           
                
            
                
            
        }

        protected void dp_nm_alunos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dp_nm_alunos.SelectedIndex!=0)
            {
              
                    ClsEnviarRecado EnviarRecado = new ClsEnviarRecado();
                List<string> cd_alunos = new List<string>();
                cd_alunos = EnviarRecado.CodigoAluno(DropDownTurma.SelectedIndex.ToString());
                string cd_aluno = "";
                emailUsuario = Session["emailUsuario"].ToString();
                cd_aluno = dp_nm_alunos.SelectedIndex.ToString();
                lblNomeALuno.Text = "";
                lblNomeResponsavel.Text = "";
                for (int i = 0; i < cd_alunos.Count; i++)
                {
                    if (cd_alunos[i] == cd_aluno)
                    {
                        lblNomeALuno.Text = EnviarRecado.nome_aluno(cd_aluno);
                        lblNomeResponsavel.Text = EnviarRecado.nome_responsavel(EnviarRecado.email_responsavel(cd_aluno));

                    }

                
                 }
             

                
                
            }
            
                
        }

     


        

        protected void tipos_recados_turma_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("index.aspx");
        }

    }
}