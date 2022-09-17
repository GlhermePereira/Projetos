using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prj_SchoON.cls;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;

namespace prj_SchoON
{
    public partial class responder_recados : System.Web.UI.Page
    {
        string codigo_aluno = "";
        string caminho_base = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            ClsEnviarRecado EnviarRecado = new ClsEnviarRecado();
            List<string> emails = new List<string>();
            List<string> nome_recado = new List<string>();
            nome_recado = EnviarRecado.nome_tipo_recado();
            if (Session["emailUsuario"] != null && Session["emailUsuario"].ToString() != "")
            {
                lit_nome_usuario.Text = Session["nomeUsuario"].ToString();
            }
            else
            {
                Response.Redirect("index.aspx");
            }

            codigo_aluno =  EnviarRecado.CdAluno(Session["emailResponsavel"].ToString());



            if (!IsPostBack)
            {
                for (int i = 0; i < nome_recado.Count; i++)
                {


                    dropDownTipoRecado.Items.Add(nome_recado[i]);
                  
                }
                dropDownTipoRecado.Items.Insert(0, new ListItem("-- Tipos Recados --", ""));

                lblNomeALuno.Text = EnviarRecado.nome_aluno(codigo_aluno);
                lblNomeResponsavel.Text = EnviarRecado.nome_responsavel(Session["emailResponsavel"].ToString());
            }
           
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            string emailUsuario = "";
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
            codigo_aluno = EnviarRecado.CdAluno(Session["emailResponsavel"].ToString());
            string cd_tipo_recado = dropDownTipoRecado.SelectedIndex.ToString();

            if (fl_upload_imagen.HasFile == true)
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


            

                cSQL = new MySqlCommand("Insert into  recado values (" + codigo_aluno + ",'" + emailUsuario + "','" +
                    EnviarRecado.email_responsavel(codigo_aluno) + "','" + date + "','" + txtDescricaoRecado.Text + "'," + codigo_aluno + ",@img,'" + txt_titulo_recado.Text + "',0,0)", conexao);
                cSQL.Parameters.Clear();
                // EnviarRecado.enviar_recado(cd_tipo_recado, emailUsuario, EnviarRecado.email_responsavel(codigo_aluno),
                //     date, txtDescricaoRecado.Text, codigo_aluno, foto.ToString(), txt_titulo.Text, "0", "0");
          

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

        protected void btnSair_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("index.aspx");
        }
    }
}