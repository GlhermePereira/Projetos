using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prj_SchoON.cls;

namespace prj_SchoON
{
    public partial class enviado_especifico : System.Web.UI.Page
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
            List<string> emails = new List<string>();
            List<string> datas = new List<string>();
            string data_recado = "";
            data_recado = Session["data_recado"].ToString();
            
            /*/emails = RecadosEnviados.emails_recebidos_funcionario(emailUsuario);
            datas = RecadosEnviados.datas_recados(emailUsuario);
             * /*/
            lit_nome_usuario.Text = RecadosEnviados.nome_destinatario(emailUsuario);




            if (RecadosEnviados.Recado_especifico_enviado(emailUsuario, data))
                {


              



                   RecadoEsp += "     <div class='areaDados'>";
                   RecadoEsp += "   <div class='paddingAreaDados'>";
                     RecadoEsp += "     <span class='tituloRecado'>"+RecadosEnviados.TituloRecado+ "</span>";
                       RecadoEsp += "   <span class='nomeTipoRecado'>"+RecadosEnviados.NomeTipoRecado+"</span>";
                      RecadoEsp += "    <span class='fr dataRecado'>" + RecadosEnviados.dtRecado +"</span><br>";

                  
                RecadoEsp += "     <div class='areaNomeEmail'>";
                 
                     RecadoEsp += "         <span class='nomeRemetente'>"+RecadosEnviados.nmRemetente+"</span><br>";
                         RecadoEsp += "     <span class='emailRemetente'>"+RecadosEnviados.nmEmailRemetente+"</span>";
                   RecadoEsp += "       </div>";
                        
                    RecadoEsp += "  </div>";
                RecadoEsp += "  </div>";
       
               RecadoEsp += "   <div class='fl lateral'>";            
                    RecadoEsp += "       </div>";

                
                 RecadoEsp += "   <div class='areaDescricaoRecado'>";
                 RecadoEsp += "     <span class='descricaoRecado' >" + RecadosEnviados.dsRecado + "</span>";   
                 RecadoEsp += "   </div>";

                
                 


                     if (RecadosEnviados.img_recado== null || RecadosEnviados.img_recado=="")
                     {
                            
                     }
                     else
                     {
                         RecadoEsp += "   <div class='areaImagem'>";
                             RecadoEsp += "       <img class='imagemRecado' src='data:image/jpeg;base64," + RecadosEnviados.img_recado + "'>";
                             RecadoEsp += "  </div>";
                     }  
             

             


               
                  
                  


                 



                    



                

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