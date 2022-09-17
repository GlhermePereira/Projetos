using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prj_schoon_pais.cls;

namespace prj_schoon_pais
{
    public partial class recado_recebido : System.Web.UI.Page
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
       
            string data = Request["c"].ToString();
       



        

                if (RecadosRecebidos.Recado_especifico_Recebido(emailUsuario,data))
                {

                    Session["emailFuncionario"] = RecadosRecebidos.nmEmailRemetente;
                    Session["nomeFuncionario"] = RecadosRecebidos.nmRemetente;

     
                    
                      







                    RecadoEsp += "     <div class='areaDados'>";
                    RecadoEsp += "   <div class='paddingAreaDados'>";
                    RecadoEsp += "     <span class='fl titulo'>" + RecadosRecebidos.TituloRecado + "</span></br>";
                    RecadoEsp += "         <span class='fl nome'>" + RecadosRecebidos.nmRemetente + "</span></br>";

                    RecadoEsp += "    <span class='fr data'>" + RecadosRecebidos.dtRecado + "</span></br>";

                    RecadoEsp += "      <span class='ds' >" + RecadosRecebidos.dsRecado + "</span></br>";


                    RecadoEsp += "  </div>";
                    RecadoEsp += "  </div>";

                    if (RecadosRecebidos.img_recado == null || RecadosRecebidos.img_recado == "")
                    {

                    }
                    else
                    {

                         RecadoEsp += "     <div class='areaImagem'>";
                              RecadoEsp += "      <div class='paddingAreaImagem'>";
                        RecadoEsp += "       <img class='fotoProduto' src='data:image/jpeg;base64," + RecadosRecebidos.img_recado + "'>"; 

                            
                             RecadoEsp += "       </div>";
                              RecadoEsp += "  </div>";


                    }
           
                    RecadoEsp += "  <div class='areaResponder'>";
                    RecadoEsp += "  <a class='botaoResponder' href='responder_recado_funcionario.aspx?c=" + data + "'>Responder<a/>";
                    RecadoEsp += "       </div>";

                    
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
