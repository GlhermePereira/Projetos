using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prj_schoon_pais.cls;

namespace prj_schoon_pais
{
    public partial class recados_recebidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

            clsRecadosRecebidos RecadosRecebidos = new clsRecadosRecebidos();

            List<string> datas = new List<string>();

            string cadaRecado = "";
            string TipoUsuario = "";
            string emailUsuario = "";
            if (Session["emailUsuario"] != null && Session["emailUsuario"].ToString() != "")
            {
                emailUsuario = Session["emailUsuario"].ToString();

            }



            List<string> nome_recado = new List<string>();
            nome_recado = RecadosRecebidos.nome_tipo_recado();


           





            datas = RecadosRecebidos.datas_recados(emailUsuario);
     
            if (datas.Count > 0)
            {
                for (int i = 0; i < datas.Count; i++)
                {
                    if (RecadosRecebidos.DadosBaseRecado(emailUsuario, datas[i]))
                    {
                            Session["data_recado"] = datas[i];

                            if (RecadosRecebidos.recado_lido_responsavel == "1")
                        {
                            cadaRecado += "  <a href='recado_recebido.aspx?c=" + datas[i] + "'>";

                         
                            cadaRecado += "  <div class='recadoRecebido lido'>";
                            cadaRecado += "  <div class='paddingRecado'>";

                            cadaRecado += "     <span class='fl'>" + RecadosRecebidos.TituloRecado + "</span>";
                            cadaRecado += "        <span class='fl'>" + "  - -  " + "</span>";

                            cadaRecado += "        <span class='fl'>" + RecadosRecebidos.nmRemetente + "</span>";

                            cadaRecado += "       <span class='fr'>" + RecadosRecebidos.dtRecado + "</span><br>";
                            cadaRecado += "     <span>" + RecadosRecebidos.dsRecado + "</span>";

                            cadaRecado += "   </div>";
                            cadaRecado += "  </div>";
                            cadaRecado += "<div class='espacamento'></div>";
                            cadaRecado += " </a>";
                            
                        }
                        else
                        {

                        cadaRecado += "  <a href='recado_recebido.aspx?c=" + datas[i] + "'>";
                        
                        cadaRecado += "  <div class='recadoRecebido'>";
                        cadaRecado += "  <div class='paddingRecado'>";
               
                        cadaRecado += "     <span class='fl'>" + RecadosRecebidos.TituloRecado + "</span>";
                        cadaRecado += "        <span class='fl'>" +"  - -  " + "</span>";

                        cadaRecado += "        <span class='fl'>" + RecadosRecebidos.nmRemetente + "</span>";

                           cadaRecado += "       <span class='fr'>" + RecadosRecebidos.dtRecado + "</span><br>";
                        cadaRecado += "     <span>" + RecadosRecebidos.dsRecado + "</span>";
                       
                        cadaRecado += "   </div>";
                        cadaRecado += "  </div>";
                   cadaRecado += "<div class='espacamento'></div>";
                        cadaRecado += " </a>";
             
                        }

                        



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