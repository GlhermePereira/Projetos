using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prj_schoon_pais.cls;
using System.IO;

namespace prj_schoon_pais
{
    public partial class enviar_recado_funcionario : System.Web.UI.Page
    {
        string caminho_base = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            ClsResponderRecados EnviarRecado = new ClsResponderRecados();
            List<string> emails = new List<string>();
            List<string> nome_recado = new List<string>();
            nome_recado = EnviarRecado.nome_tipo_recado();




            if (!IsPostBack)
            {
                for (int i = 0; i < nome_recado.Count; i++)
                {


                    dropDownTipoRecado.Items.Add(nome_recado[i]);
                }

                lblEmailFuncionario.Text = Session["emailResponsavel"].ToString();
                        lblNomeFuncionario.Text = Session["nomeFuncionario"].ToString();
            }











        }


       


        protected void btnEnviar_Click(object sender, EventArgs e)
        {
  /*/
            caminho_base = Request.PhysicalApplicationPath + @"\uploads";
            DirectoryInfo diretorio = new DirectoryInfo(caminho_base);
            FileInfo[] lista_arquivos = diretorio.GetFiles();
          

            pnl_fotos.Controls.Clear();





            if (fl_upload_imagen.PostedFile != null)
            {
                string nome_original_arquivo = Path.GetFileName(fl_upload_imagen.PostedFile.FileName);
                string tipo_arquivo = fl_upload_imagen.PostedFile.ContentType;

                int tamanho_arquivo = fl_upload_imagen.PostedFile.ContentLength;

               
                    fl_upload_imagen.PostedFile.SaveAs(Request.PhysicalApplicationPath + @"uploads\" + nome_original_arquivo + ".jpg");

                


            }
            /*/
            /*/
          for (int i = 0; i < lista_arquivos.Length; i++)
          {
              Image img = new Image();
              img.ID = "img_" + (i + 1).ToString();
              img.CssClass = "imagem";
              img.ImageUrl = "~/uploads/" + lista_arquivos[i].Name;
              pnl_fotos.Controls.Add(img);

          }

          Panel fim_float = new Panel();
          fim_float.ID = "limparFloat";
          fim_float.CssClass = "cls";
          pnl_fotos.Controls.Add(fim_float);
/*/






            DateTime localDate = DateTime.Now;
            ClsResponderRecados EnviarRecado = new ClsResponderRecados();
            string emailUsuario = "";

            if (Session["emailUsuario"] != null && Session["emailUsuario"].ToString() != "")
            {
                emailUsuario = Session["emailUsuario"].ToString();
            }
            string cd_tipo_recado = dropDownTipoRecado.SelectedIndex.ToString();


            EnviarRecado.enviar_recado(cd_tipo_recado, emailUsuario, Session["emailFuncionario"].ToString(), localDate.ToString(), 
                txtDescricaoRecado.Text, EnviarRecado.Codigo_Aluno(Session["emailFuncionario"].ToString()), null);
            Response.Redirect("enviados.aspx");
        }
    }
}