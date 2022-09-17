using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prj_schoon_pais.cls;

namespace prj_schoon_pais
{
    public partial class enviados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string emailUsuario = "";
            string TipoUsuario = "";

            if (Session["emailUsuario"] != null && Session["emailUsuario"].ToString() != "")
            {
                emailUsuario = Session["emailUsuario"].ToString();

            }
            else
            {
                Response.Redirect("index.aspx");
            }

            clsRecadosEnviados RecadosEnviados = new clsRecadosEnviados();

            List<string> datas = new List<string>();

            string cadaRecado = "";
            RecadosEnviados.tipo_usuario = TipoUsuario;


            // emails = RecadosEnviados.emails_recebidos_funcionario(emailUsuario);
            datas = RecadosEnviados.datas_recados(emailUsuario);
        









            List<string> nome_recado = new List<string>();
            nome_recado = RecadosEnviados.nome_tipo_recado();



            if (datas.Count > 0)
            {

                for (int i = 0; i < datas.Count; i++)
                {
                    if (RecadosEnviados.Recados_enviados_responsaveis(emailUsuario, datas[i]))
                    {

                        Session["data_recado"] = datas[i];
                        cadaRecado += "  <a href='recado_enviado.aspx?c=" + datas[i] + "'>";
                        cadaRecado += "  <div class='recadoRecebido'>";
                        cadaRecado += "      <div class='paddingRecado'>";
                        cadaRecado += "     <span class='fl'>" + RecadosEnviados.TituloRecado + "</span>";
                        cadaRecado += "     <span class='fl'>  - -  </span>";

                        cadaRecado += "        <span class='fl'>" + RecadosEnviados.nmRemetente + "</span>";


           
                        cadaRecado += "       <span class='fr'>" + RecadosEnviados.dtRecado + "</span><br>";
                        cadaRecado += "     <span>" + RecadosEnviados.dsRecado + "</span>";
                        cadaRecado += "   </div>";
                        cadaRecado += "  </div>";
                        cadaRecado += "<div class='espacamento'></div>";

                        cadaRecado += " </a>";



                    }

                }
            }


            litrecados.Text = cadaRecado;
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("index.aspx");
        }

       

    }
}