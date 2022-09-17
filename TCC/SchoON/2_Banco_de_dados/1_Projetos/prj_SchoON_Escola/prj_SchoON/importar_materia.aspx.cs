using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.OleDb;
using System.Data;
using prj_SchoON.cls;

namespace prj_SchoON
{
    public partial class importar_materia : System.Web.UI.Page
    {
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

        protected void btn_Importxlx_Click(object sender, EventArgs e)
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
                gvMateria.DataSource = dados;
                gvMateria.DataBind();
            }
        }

        protected void btn_importar_Click(object sender, EventArgs e)
        {
        

            clsImportarMaterias EnviarMaterias = new clsImportarMaterias();


            
                for (int i = 0; i < gvMateria.Rows.Count; i++)
                {
                    //erro de caractere especial e
                    EnviarMaterias.enviar_materia(gvMateria.Rows[i].Cells[0].Text,gvMateria.Rows[i].Cells[3].Text,
                        gvMateria.Rows[i].Cells[2].Text, gvMateria.Rows[i].Cells[1].Text, gvMateria.Rows[i].Cells[4].Text);
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