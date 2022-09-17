using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.OleDb;
using System.Web.Hosting;
using prj_SchoON.cls;



namespace prj_SchoON
{
    public partial class importar_notas : System.Web.UI.Page
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

        

        protected void btn_ImportCSV_Click(object sender, EventArgs e)
        {

            verificador = true;
            string connectionString = "";

            DataSet dados = new DataSet();

         

            if (fu_Import_excel.HasFile)
            {
                string fileName = Path.GetFileName(fu_Import_excel.PostedFile.FileName);
                string fileExtension = Path.GetExtension(fu_Import_excel.PostedFile.FileName);
                string fileLocation = Server.MapPath("~/xmls/" + fileName);

                fu_Import_excel.SaveAs(fileLocation);
                dados.ReadXml(fileLocation);
                gvnota.DataSource = dados;
                gvnota.DataBind();

               




                DateTime localDate = DateTime.Now;
               
                string emailUsuario = "";

                if (Session["emailUsuario"] != null && Session["emailUsuario"].ToString() != "")
                {
                    emailUsuario = Session["emailUsuario"].ToString();
                }



            


            }
        }

        protected void btn_importar_Click(object sender, EventArgs e)
        {

          

            clsImportarNotas EnviarNotas = new clsImportarNotas();


           
                for (int i = 0; i < gvnota.Rows.Count; i++)
                {
                    if (EnviarNotas.VerificarNotas( gvnota.Rows[i].Cells[3].Text, gvnota.Rows[i].Cells[0].Text, gvnota.Rows[i].Cells[1].Text)==true)
                    {
                        EnviarNotas.enviar_notas(gvnota.Rows[i].Cells[0].Text, gvnota.Rows[i].Cells[1].Text, gvnota.Rows[i].Cells[2].Text,
             gvnota.Rows[i].Cells[3].Text, gvnota.Rows[i].Cells[4].Text, gvnota.Rows[i].Cells[5].Text, gvnota.Rows[i].Cells[6].Text);
                        Response.Redirect("recados.aspx");
                    }
                    


                }
         
        
     
          
            
            

        }

        protected void gvnota_RowEditing(object sender, GridViewEditEventArgs e)
        {


            
            BindData();


        }

        private void BindData()
        {
            gvnota.DataSource = Session["TaskTable"];
            gvnota.DataBind();
        }




        protected void gvnota_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvnota.PageIndex = e.NewPageIndex;
            //Bind data to the GridView control.
            BindData();
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("index.aspx");
        }

       
            

            /*/
                                        String strConnection = "ConnectionString";
                    string connectionString ="";
                            if (fu_ImportCSV.HasFile)
                    {
                        string fileName = Path.GetFileName(fu_ImportCSV.PostedFile.FileName);
                        string fileExtension = Path.GetExtension(fu_ImportCSV.PostedFile.FileName);
                        string fileLocation = Server.MapPath("~/notas/" + fileName);
                        fu_ImportCSV.SaveAs(fileLocation);
                        if (fileExtension == ".xls")
                        {
                            connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                                fileLocation + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                        }
                        else if (fileExtension == ".xlsx")
                        {
                            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                        }
                        OleDbConnection con = new OleDbConnection(connectionString);
                        OleDbCommand cmd = new OleDbCommand();
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Connection = con;
                        OleDbDataAdapter dAdapter = new OleDbDataAdapter(cmd);
                        DataTable dtExcelRecords = new DataTable();
                        con.Open();
                        DataTable dtExcelSheetName = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        string getExcelSheetName = dtExcelSheetName.Rows[0]["Table_Name"].ToString();
                        cmd.CommandText = "SELECT * FROM [" + getExcelSheetName + "]";
                        dAdapter.SelectCommand = cmd;
                        dAdapter.Fill(dtExcelRecords);
                        gvnota.DataSource = dtExcelRecords;
                        gvnota.DataBind();


                    }
             * /*/
           
            


           

        }

       
    }
