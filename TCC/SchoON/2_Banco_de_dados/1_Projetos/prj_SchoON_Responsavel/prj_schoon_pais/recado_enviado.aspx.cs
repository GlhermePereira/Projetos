using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prj_schoon_pais.cls;

namespace prj_schoon_pais
{
    public partial class recado_enviado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string emailUsuario = "";

            if (Session["emailUsuario"] != null && Session["emailUsuario"].ToString() != "")
            {
                emailUsuario = Session["emailUsuario"].ToString();
            }
            else
            {
                Response.Redirect("index.aspx");
            }

            clsRecadosEnviados RecadosEnviados = new clsRecadosEnviados();

            string cadaRecado = "";
            string RecadoEsp = "";

            string data = Request["c"].ToString();
          

            List<string> datas = new List<string>();
 
            datas = RecadosEnviados.datas_recados(emailUsuario);


            if (RecadosEnviados.Recado_especifico_enviado_responsaveis(emailUsuario, data))
            {
                Session["emailFuncionario"] = RecadosEnviados.nmEmailRemetente;
                Session["nomeFuncionario"] = RecadosEnviados.nmRemetente;

                RecadoEsp += "     <div class='areaDadosEnviado'>";
                RecadoEsp += "   <div class='paddingAreaDados'>";
             

                RecadoEsp += "     <span class='fl titulo'>" + RecadosEnviados.TituloRecado + "</span></br>";
                RecadoEsp += "    <span class='fr data'>" + RecadosEnviados.dtRecado + "</span><br>";

                RecadoEsp += "   <span class='fl nome'>" + RecadosEnviados.nmRemetente + "</span></br>";
                RecadoEsp += "      <span class='ds' >" + RecadosEnviados.dsRecado + "</span></br>";
                RecadoEsp += "  </div>";
                RecadoEsp += "  </div>";

               















            }

            lit_reacado_unico.Text = RecadoEsp;

        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("index.aspx");
        }
    }
}