using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prj_SchoON.cls;


namespace prj_SchoON
{
    public partial class recados : System.Web.UI.Page
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

            clsRecadosRecebidos RecadosRecebidos = new clsRecadosRecebidos();
            List<string> emails = new List<string>();
            List<string> datas = new List<string>();

            string cadaRecado = "";
            string RecadoEsp = "";
          
            datas = RecadosRecebidos.datas_recados(emailUsuario);
            string data_recado_recebido = Session["data_recado"].ToString();
            lit_nome_usuario.Text = RecadosRecebidos.nome_destinatario(emailUsuario);
            string data = Request["c"].ToString();
            lit_nome_usuario.Text = RecadosRecebidos.nome_destinatario(emailUsuario);




            if (RecadosRecebidos.Recado_especifico_Recebido(emailUsuario, data))
                {

                   

                            RecadoEsp += "   <div class='areaDados'>";
                   RecadoEsp += "   <div class='paddingAreaDados'>";
                       RecadoEsp += "   <span class='tituloRecado'>" + RecadosRecebidos.TituloRecado + "</span>";
                        RecadoEsp += "  <span class='nomeTipoRecado'>"+RecadosRecebidos.NomeTipoRecado+"</span>";
                     RecadoEsp += "     <span class='fr dataRecado'>" + RecadosRecebidos.dtRecado + "</span><br>";

                       RecadoEsp += "   <div class='areaNomeEmail'>";
                       RecadoEsp += "    <span class='nomeRemetente'>" + RecadosRecebidos.nmRemetente + "</span><br>";
                         RecadoEsp += "     <span id='txt_email_remetente' class='emailRemetente'>" + RecadosRecebidos.nmEmailRemetente + "</span>";
                       RecadoEsp += "   </div>";
                        
                    RecadoEsp += "  </div>";
                 RecadoEsp += " </div>";

                RecadoEsp += "  <div class='fl lateral'>";

                    RecadoEsp += "  <div class='areaBotao'>";
                    RecadoEsp += "  <a class='botao' href='responder_recados.aspx?c=" + data_recado_recebido + "'>Responder<a/>";
                 RecadoEsp += "     </div>";

               RecadoEsp += "   </div>";

               RecadoEsp += "   <div class='areaDescricaoRecado'>";
                  RecadoEsp += "    <span class='descricaoRecado' >"+RecadosRecebidos.dsRecado+"</span>";
              RecadoEsp += "    </div>";


                        Session["emailResponsavel"] = RecadosRecebidos.nmEmailRemetente;



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