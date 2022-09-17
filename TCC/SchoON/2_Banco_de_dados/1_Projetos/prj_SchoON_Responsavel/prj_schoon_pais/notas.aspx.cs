using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prj_schoon_pais.cls;
using System.Data;

namespace prj_schoon_pais
{
    public partial class notas : System.Web.UI.Page
    {
        public DataTable dtData = new DataTable(); 
        protected void Page_Load(object sender, EventArgs e)
        {

            string emailUsuario = "";
            string emailRemetente = "";
            clsNotas notas = new clsNotas();
            string codigo_aluno = "";


            if (Session["emailUsuario"] != null && Session["emailUsuario"].ToString() != "")
            {
                emailUsuario = Session["emailUsuario"].ToString();

            }
            List<string> datas = new List<string>();

            codigo_aluno = notas.Codigo_Aluno(emailUsuario).ToString();
            int cd_bimestre = 0;
            datas = notas.datas_notas(codigo_aluno);           

        }

        protected void gvNotas_Load(object sender, EventArgs e)
        {

            string primeiro_bi = "";
            string segundo_bi = "";
            string terceiro_bi = "";
            string quarto_bi = "";
           
            double freq_materia = 0.0;
            List<string> notas_alunos = new List<string>();
            string emailUsuario = "";
            string emailRemetente = "";
            clsNotas notas = new clsNotas();
            string codigo_aluno = "";
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataRow dr;
            gvNotas.DataSource = dt;
          

            dt.Columns.Add("nm_materia");
            dt.Columns.Add("primeiro_bi");
            dt.Columns.Add("segundo_bi");
            dt.Columns.Add("terceiro_bi");
            dt.Columns.Add("quarto_bi");
            dt.Columns.Add("aulas_totais");
            dt.Columns.Add("freq_materia");
      

            ds.Tables.Add(dt);

          

          
          

            
            




            

        
          


            if (Session["emailUsuario"] != null && Session["emailUsuario"].ToString() != "")
            {
                emailUsuario = Session["emailUsuario"].ToString();

            }
            List<string> datas = new List<string>();
            List<string> codigo_materia = new List<string>();

            codigo_aluno = notas.Codigo_Aluno(emailUsuario).ToString();
            

            datas = notas.datas_notas(codigo_aluno);
            codigo_materia = notas.codigos_materias(codigo_aluno);

            dr = dt.NewRow();
        
            for (int i = 0; i < datas.Count; i++)
            {
                if (notas.nota_bimestral(codigo_aluno))

                {
                    dr["nm_materia"] = notas.nm_materia;
                    dr["aulas_totais"] = notas.aulas_totais;
                    dr["freq_materia"] = int.Parse(notas.qtSemanalMateria.ToString()) / int.Parse(notas.aulas_totais.ToString());
                    #region notas bimestres
                    if (notas.cdBimestre <  3)
                    {
                        dr["primeiro_bi"] = notas.cdNotaAtribuida;
                    }
                    else
                    {
                        dr["primeiro_bi"] = "-";
                    }

                    if (notas.cdBimestre >= 3 && notas.cdBimestre <= 6)
                    {
                        dr["segundo_bi"] = notas.cdNotaAtribuida;
                    }
                    else
                    {
                        dr["segundo_bi"] = "-";
                    }

                    if (notas.cdBimestre >= 6 && notas.cdBimestre <= 9)
                    {
                        dr["terceiro_bi"] = notas.cdNotaAtribuida;
                    }
                    else
                    {
                        dr["terceiro_bi"] = "-";
                    }
                    if (notas.cdBimestre >= 9 && notas.cdBimestre <= 12)
                    {
                        dr["quarto_bi"] = notas.cdNotaAtribuida;
                    }
                    else
                    {
                        dr["quarto_bi"] = "-";
                    }
                    #endregion
                   
                }
                dt.Rows.Add(dr);
                gvNotas.DataSource = dt;
                dr = dt.NewRow();
                gvNotas.DataBind();
            }



            

        
        }

       


    }
}