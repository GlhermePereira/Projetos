using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prj_SchoON.cls;
using MySql.Data.MySqlClient;
using System.IO;
using System.Drawing;
using System.Data;

namespace prj_SchoON
{
    public partial class inserirHorario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string emailUsuario = "";

            clsInserirHorario horarios = new clsInserirHorario();

            List<string> datas = new List<string>();

            string cadaRecado = "";
            

            if (Session["emailUsuario"] != null && Session["emailUsuario"].ToString() != "")
            {
                emailUsuario = Session["emailUsuario"].ToString();

            }



            List<string> Turmas = new List<string>();
            List<string> Siglas = new List<string>();
            Siglas = horarios.Siglas_Turmas();
            Turmas = horarios.Codigos_Turmas();

            if (!IsPostBack)
            {
                  for (int f = 0; f < Siglas.Count; f++)
                {


                    dp_turmas.Items.Add(Siglas[f]);

                }
                dp_turmas.Items.Insert(0, new ListItem("-- Turmas --", ""));

            }

            
              

     




            if (Turmas.Count > 0)
                {
                    for (int i = 0; i < Turmas.Count; i++)
                    {
                        if (horarios.selecionar_horario(Turmas[i]))
                        {
                            if (horarios.img_recado=="" || horarios.img_recado==null)
                            {
                             
                            }
                            else
                            {
                            cadaRecado += "    <div class='horarioEspecifico'>";
                            cadaRecado += "      <h1> Turma: " + horarios.Codigo_Sigla_Turma + "</h1>";
                            cadaRecado += "       <figure>";
                            cadaRecado += "     <img class='imagemHorario' alt='Tabela de Horário escolar' src='data:image/jpeg;base64," + horarios.img_recado + "'>";
                            cadaRecado += "    </figure>";
                            cadaRecado += "    </div>";
                            cadaRecado += "   <div class='espacamento'></div>";
                            }
                        }
                    }
                }


  lit_horarioEspecifico.Text = cadaRecado;

            

      


        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {


            clsInserirHorario horarios = new clsInserirHorario();
            byte[] foto = null;
          
            MySqlCommand cSQL = new MySqlCommand();
           

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

            List<string> Turmas = new List<string>();
            List<string> Siglas = new List<string>();
            Siglas = horarios.Siglas_Turmas();
            Turmas = horarios.Codigos_Turmas();
            for (int i = 0; i < Turmas.Count; i++)
            {
                if (Turmas[i].ToString() == dp_turmas.SelectedIndex.ToString())
                {
                    cSQL = new MySqlCommand("update turma set img_horario =@img where cd_turma="+dp_turmas.SelectedIndex.ToString(), conexao);
                }
            }
             


            
                cSQL.Parameters.Clear();
               



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


            Response.Redirect("recados.aspx");
            

        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("index.aspx");
        }
    }
}