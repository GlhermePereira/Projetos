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
            lit_nome_usuario.Text = RecadosEnviados.nome_destinatario(emailUsuario);

            List<string> datas = new List<string>();
 
            datas = RecadosEnviados.datas_recados(emailUsuario);
            lit_nome_usuario.Text = RecadosEnviados.nome_destinatario(emailUsuario);


            for (int i = 0; i < datas.Count; i++)
            {
                if (RecadosEnviados.Recado_especifico_enviado_responsaveis(emailUsuario, datas[i]))
                {

                    if (data == datas[i].ToString())
                    {

                        RecadoEsp += "     <div class='areaDados'>";
                        RecadoEsp += "   <div class='paddingAreaDados'>";
                        RecadoEsp += "     <span class='tituloRecado'>" + RecadosEnviados.TituloRecado + "</span>";
                        RecadoEsp += "   <span class='nomeTipoRecado'>" + RecadosEnviados.NomeTipoRecado + "</span>";
                        RecadoEsp += "    <span class='fr dataRecado'>" + RecadosEnviados.dtRecado + "</span><br>";

                        RecadoEsp += "     <div class='areaNomeEmail'>";
                        RecadoEsp += "       <img class='fotoProduto' src='data:image/jpeg;base64," + RecadosEnviados.img_recado + "'>"; ;
                        RecadoEsp += "         <span class='nomeRemetente'>" + RecadosEnviados.nmRemetente + "</span><br>";
                        RecadoEsp += "     <span class='emailRemetente'>" + RecadosEnviados.nmEmailRemetente + "</span>";
                        RecadoEsp += "       </div>";

                        RecadoEsp += "  </div>";
                        RecadoEsp += "  </div>";

                        RecadoEsp += "   <div class='fl lateral'>";
                        RecadoEsp += "  </div>";

                        RecadoEsp += "  <div class='areaDescricaoRecado'>";
                        RecadoEsp += "      <span class='descricaoRecado' >" + RecadosEnviados.dsRecado + "</span>";

                        RecadoEsp += "  </div>";
                        RecadoEsp += " <div class='areaBotaoResponder'>";
                        RecadoEsp += "  <a class='fl btn' href='responder_recado_funcionario.aspx?c=" + datas[i] + "'>Responder<a/>";
                        RecadoEsp += "  </div>";
                        Session["emailResponsavel"] = RecadosEnviados.nmEmailRemetente;
                        Session["nomeFuncionario"] = RecadosEnviados.nmRemetente;






                    }



                }

            }

            lit_reacado_unico.Text = RecadoEsp;

        }
    }
}