using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.IO;
using System.Data;
using prj_SchoON.cls;

namespace prj_SchoON
{
    public partial class importar_alunos : System.Web.UI.Page
    {
        string caminho_base = "";
        bool verificador = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["emailUsuario"] != null && Session["emailUsuario"].ToString() != "")
            {
                 lit_nome_usuario.Text = Session["nomeUsuario"].ToString();
            }
            else
            {
                Response.Redirect("index.aspx");
            }
        }

        protected void btn_Import_Click(object sender, EventArgs e)
        {
            DataSet dados = new DataSet();
            string connectionString = "";
            if (fu_Import_excel.HasFile)
            {
                string fileName = Path.GetFileName(fu_Import_excel.PostedFile.FileName);
                string fileExtension = Path.GetExtension(fu_Import_excel.PostedFile.FileName);
                string fileLocation = Server.MapPath("~/xmls/" + fileName);

                fu_Import_excel.SaveAs(fileLocation);
                dados.ReadXml(fileLocation);
                gvAlunos.DataSource = dados;
                gvAlunos.DataBind();
            }
        }

        protected void btn_importar_Click(object sender, EventArgs e)
        {
           
            
            clsImportarAlunos ImportarAlunos = new clsImportarAlunos();


              
                    for (int i = 0; i < gvAlunos.Rows.Count; i++)
                    {
                        if (ImportarAlunos.verificar_alunos(gvAlunos.Rows[i].Cells[3].Text,gvAlunos.Rows[i].Cells[0].Text,gvAlunos.Rows[i].Cells[1].Text)==true)
                        {
                             ImportarAlunos.inserir_alunos(gvAlunos.Rows[i].Cells[3].Text, gvAlunos.Rows[i].Cells[2].Text, gvAlunos.Rows[i].Cells[4].Text);
                             ImportarAlunos.inserir_lista_aluno(gvAlunos.Rows[i].Cells[3].Text, gvAlunos.Rows[i].Cells[0].Text, gvAlunos.Rows[i].Cells[1].Text);
                             
                        }
                        

                       
                       
                       
                    }



                    Response.Redirect("importar_alunos.aspx");
                   
               
        }

        protected void fu_Import_excel_Load(object sender, EventArgs e)
        {
          
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("index.aspx");
        }

       
        }

        
    }
