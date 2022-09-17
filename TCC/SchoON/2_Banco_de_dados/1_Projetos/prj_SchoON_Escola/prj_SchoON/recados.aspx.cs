using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prj_SchoON.cls;

namespace prj_SchoON
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string emailUsuario = "";

            clsRecadosRecebidos RecadosRecebidos = new clsRecadosRecebidos();
   
            List<string> datas = new List<string>();

            string cadaRecado = "";
            string TipoUsuario = "";
            
            if (Session["emailUsuario"] != null && Session["emailUsuario"].ToString() != "")
            {
                 emailUsuario = Session["emailUsuario"].ToString();
       
            }
           


            List<string> nome_recado = new List<string>();
            nome_recado = RecadosRecebidos.nome_tipo_recado();


            if (!IsPostBack)
            {
                for (int f = 0; f < nome_recado.Count; f++)
                {


                    dp_tipo_recado.Items.Add(nome_recado[f]);

                }
                dp_tipo_recado.Items.Insert(0, new ListItem("-- Tipos Recados --", ""));

                
            }





            datas = RecadosRecebidos.datas_recados(emailUsuario);
            lit_nome_usuario.Text = RecadosRecebidos.nome_destinatario(emailUsuario);
            if (datas.Count > 0)
            {
                for (int i = 0; i < datas.Count; i++)
                {
                    if (RecadosRecebidos.DadosBaseRecado(emailUsuario, datas[i]))
                    {
                        if (RecadosRecebidos.recado_lido_funcionario=="1")

                        {

                            Session["data_recado"] = datas[i];
                            cadaRecado += "  <a   href='recado_especifico.aspx?c=" + datas[i] + "'>";
                            cadaRecado += "  <div class='recadoRecebido lido'>";
                            cadaRecado += "      <div class='paddingRecadoRecebido'>";
                            cadaRecado += "     <span class='tituloRecado'>"+ RecadosRecebidos.TituloRecado + "</span>";
                            cadaRecado += "        <span class='nomeRemetente'>" + RecadosRecebidos.nmRemetente + "</span>";


                            cadaRecado += "     <span class='descricaoRecado'>" + RecadosRecebidos.dsRecado + "</span>";
                            cadaRecado += "       <span class='fr DataRecado'>" + RecadosRecebidos.dtRecado + "</span><br>";
                            cadaRecado += "   </div>";
                            cadaRecado += "  </div>";
                            cadaRecado += " </a>";
                            cadaRecado += "<div class='espacamento'></div>";
                            
                        }
                        else
                        {
                                  Session["data_recado"] = datas[i];
                        cadaRecado+="  <a   href='recado_especifico.aspx?c=" + datas[i] + "'>";
                      cadaRecado+="  <div class='recadoRecebido'>";
                      cadaRecado+="      <div class='paddingRecadoRecebido'>";
                      cadaRecado += "     <span class='tituloRecado'>" + RecadosRecebidos.TituloRecado + "</span>";
                        cadaRecado+="        <span class='nomeRemetente'>" + RecadosRecebidos.nmRemetente+ "</span>";
                      
                     
                         cadaRecado += "     <span class='descricaoRecado'>" + RecadosRecebidos.dsRecado + "</span>";
                         cadaRecado += "       <span class='fr DataRecado'>" + RecadosRecebidos.dtRecado + "</span><br>";
                         cadaRecado+="   </div>";
                      cadaRecado+="  </div>";
                   cadaRecado+=" </a>";
                    cadaRecado+="<div class='espacamento'></div>";
                        }


                      

                        
           
                    }





                }
               
            }

            litrecados.Text = cadaRecado;

         

               

            }

        protected void txt_nome_remetente_TextChanged(object sender, EventArgs e)
        {
            clsRecadosRecebidos RecadosRecebidos = new clsRecadosRecebidos();

            string emailUsuario = "";

         
            
            List<string> datas = new List<string>();
            string nome_responsavel="";
            nome_responsavel=RecadosRecebidos.filt_nome_responsavel(txt_nome_remetente.Text);
            string cadaRecado = "";
            string TipoUsuario = "";

            if (Session["emailUsuario"] != null && Session["emailUsuario"].ToString() != "")
            {
                emailUsuario = Session["emailUsuario"].ToString();

            }
            else
            {
                Response.Redirect("index.aspx");
            }

          
            datas = RecadosRecebidos.datas_recados(emailUsuario);
            lit_nome_usuario.Text = RecadosRecebidos.nome_destinatario(emailUsuario);
            if (datas.Count > 0)
            {
                for (int i = 0; i < datas.Count; i++)
                {
                    if (RecadosRecebidos.DadosBaseRecado(emailUsuario, datas[i]))
                    {


                        if (nome_responsavel==RecadosRecebidos.nmRemetente)

                        {

                            if (RecadosRecebidos.recado_lido_funcionario == "1")
                            {

                                Session["data_recado"] = datas[i];
                                cadaRecado += "  <a   href='recado_especifico.aspx?c=" + datas[i] + "'>";
                                cadaRecado += "  <div class='recadoRecebido lido'>";
                                cadaRecado += "      <div class='paddingRecadoRecebido'>";
                                cadaRecado += "     <span class='tituloRecado'>" + RecadosRecebidos.TituloRecado + "</span>";
                                cadaRecado += "        <span class='nomeRemetente'>" + RecadosRecebidos.nmRemetente + "</span>";


                                cadaRecado += "     <span class='descricaoRecado'>" + RecadosRecebidos.dsRecado + "</span>";
                                cadaRecado += "       <span class='fr DataRecado'>" + RecadosRecebidos.dtRecado + "</span><br>";
                                cadaRecado += "   </div>";
                                cadaRecado += "  </div>";
                                cadaRecado += " </a>";
                                cadaRecado += "<div class='espacamento'></div>";

                            }
                            else
                            {
                                Session["data_recado"] = datas[i];
                                cadaRecado += "  <a   href='recado_especifico.aspx?c=" + datas[i] + "'>";
                                cadaRecado += "  <div class='recadoRecebido'>";
                                cadaRecado += "      <div class='paddingRecadoRecebido'>";
                                cadaRecado += "     <span class='tituloRecado'>" + RecadosRecebidos.TituloRecado + "</span>";
                                cadaRecado += "        <span class='nomeRemetente'>" + RecadosRecebidos.nmRemetente + "</span>";


                                cadaRecado += "     <span class='descricaoRecado'>" + RecadosRecebidos.dsRecado + "</span>";
                                cadaRecado += "       <span class='fr DataRecado'>" + RecadosRecebidos.dtRecado + "</span><br>";
                                cadaRecado += "   </div>";
                                cadaRecado += "  </div>";
                                cadaRecado += " </a>";
                                cadaRecado += "<div class='espacamento'></div>";
                            }

                            
                        }
                      

                         
             

                        



                    }





                }

            }

            litrecados.Text = cadaRecado;


        }

        protected void dp_tipo_recado_SelectedIndexChanged(object sender, EventArgs e)
        {
             clsRecadosRecebidos RecadosRecebidos = new clsRecadosRecebidos();

            string emailUsuario = "";


            List<string> datas = new List<string>();
            string nome_responsavel="";
            nome_responsavel=RecadosRecebidos.filt_nome_responsavel(txt_nome_remetente.Text);
            string cadaRecado = "";
            string TipoUsuario = "";

            if (Session["emailUsuario"] != null && Session["emailUsuario"].ToString() != "")
            {
                emailUsuario = Session["emailUsuario"].ToString();

            }
            else
            {
                Response.Redirect("index.aspx");
            }

            datas = RecadosRecebidos.datas_recados(emailUsuario);
            lit_nome_usuario.Text = RecadosRecebidos.nome_destinatario(emailUsuario);
            if (datas.Count > 0)
            {
                for (int i = 0; i < datas.Count; i++)
                {
                    if (RecadosRecebidos.DadosBaseRecado(emailUsuario, datas[i]))
                    {
                        if (dp_tipo_recado.SelectedIndex.ToString() == RecadosRecebidos.TipoRecado)
                        {
                            if (RecadosRecebidos.recado_lido_funcionario == "1")
                            {

                                Session["data_recado"] = datas[i];
                                cadaRecado += "  <a   href='recado_especifico.aspx?c=" + datas[i] + "'>";
                                cadaRecado += "  <div class='recadoRecebido lido'>";
                                cadaRecado += "      <div class='paddingRecadoRecebido'>";
                                cadaRecado += "     <span class='tituloRecado'>" + RecadosRecebidos.TituloRecado + "</span>";
                                cadaRecado += "        <span class='nomeRemetente'>" + RecadosRecebidos.nmRemetente + "</span>";


                                cadaRecado += "     <span class='descricaoRecado'>" + RecadosRecebidos.dsRecado + "</span>";
                                cadaRecado += "       <span class='fr DataRecado'>" + RecadosRecebidos.dtRecado + "</span><br>";
                                cadaRecado += "   </div>";
                                cadaRecado += "  </div>";
                                cadaRecado += " </a>";
                                cadaRecado += "<div class='espacamento'></div>";

                            }
                            else
                            {
                                Session["data_recado"] = datas[i];
                                cadaRecado += "  <a   href='recado_especifico.aspx?c=" + datas[i] + "'>";
                                cadaRecado += "  <div class='recadoRecebido'>";
                                cadaRecado += "      <div class='paddingRecadoRecebido'>";
                                cadaRecado += "     <span class='tituloRecado'>" + RecadosRecebidos.TituloRecado + "</span>";
                                cadaRecado += "        <span class='nomeRemetente'>" + RecadosRecebidos.nmRemetente + "</span>";


                                cadaRecado += "     <span class='descricaoRecado'>" + RecadosRecebidos.dsRecado + "</span>";
                                cadaRecado += "       <span class='fr DataRecado'>" + RecadosRecebidos.dtRecado + "</span><br>";
                                cadaRecado += "   </div>";
                                cadaRecado += "  </div>";
                                cadaRecado += " </a>";
                                cadaRecado += "<div class='espacamento'></div>";
                            }
                        }
                        





                    }
                }
            }

            litrecados.Text = cadaRecado;
        }

        protected void btn_buscar_Click(object sender, EventArgs e)
        {

            #region verificações

            if (dp_tipo_recado.SelectedIndex == 0)
            {
                dp_tipo_recado.Focus();
            }

            if (txt_nome_remetente.Text == "")
            {
                Response.Write("Digite o nome do responsavel.");
                txt_nome_remetente.Focus();
             
            }

            try
            {
                string x = txt_nome_remetente.Text;
            }

            catch
            {
                Console.Write("Digite o nome do responsavel. Sem numeros.");
                txt_nome_remetente.Focus();
                
            }

            #endregion



            clsRecadosRecebidos RecadosRecebidos = new clsRecadosRecebidos();

            string emailUsuario = "";


            List<string> datas = new List<string>();
            string nome_responsavel="";
            nome_responsavel=RecadosRecebidos.filt_nome_responsavel(txt_nome_remetente.Text);
            string cadaRecado = "";
            string TipoUsuario = "";

            if (Session["emailUsuario"] != null && Session["emailUsuario"].ToString() != "")
            {
                emailUsuario = Session["emailUsuario"].ToString();

            }
            else
            {
                Response.Redirect("index.aspx");
            }


            datas = RecadosRecebidos.datas_recados(emailUsuario);
            lit_nome_usuario.Text = RecadosRecebidos.nome_destinatario(emailUsuario);
            if (datas.Count > 0)
            {
                for (int i = 0; i < datas.Count; i++)
                {
                    if (RecadosRecebidos.DadosBaseRecado(emailUsuario, datas[i]))
                    {
                        if (nome_responsavel == RecadosRecebidos.nmRemetente)
                        {
                            if (RecadosRecebidos.recado_lido_funcionario == "1")
                            {

                                Session["data_recado"] = datas[i];
                                cadaRecado += "  <a   href='recado_especifico.aspx?c=" + datas[i] + "'>";
                                cadaRecado += "  <div class='recadoRecebido lido'>";
                                cadaRecado += "      <div class='paddingRecadoRecebido'>";
                                cadaRecado += "     <span class='tituloRecado'>" + RecadosRecebidos.TituloRecado + "</span>";
                                cadaRecado += "        <span class='nomeRemetente'>" + RecadosRecebidos.nmRemetente + "</span>";


                                cadaRecado += "     <span class='descricaoRecado'>" + RecadosRecebidos.dsRecado + "</span>";
                                cadaRecado += "       <span class='fr DataRecado'>" + RecadosRecebidos.dtRecado + "</span><br>";
                                cadaRecado += "   </div>";
                                cadaRecado += "  </div>";
                                cadaRecado += " </a>";
                                cadaRecado += "<div class='espacamento'></div>";

                            }
                            else
                            {
                                Session["data_recado"] = datas[i];
                                cadaRecado += "  <a   href='recado_especifico.aspx?c=" + datas[i] + "'>";
                                cadaRecado += "  <div class='recadoRecebido'>";
                                cadaRecado += "      <div class='paddingRecadoRecebido'>";
                                cadaRecado += "     <span class='tituloRecado'>" + RecadosRecebidos.TituloRecado + "</span>";
                                cadaRecado += "        <span class='nomeRemetente'>" + RecadosRecebidos.nmRemetente + "</span>";


                                cadaRecado += "     <span class='descricaoRecado'>" + RecadosRecebidos.dsRecado + "</span>";
                                cadaRecado += "       <span class='fr DataRecado'>" + RecadosRecebidos.dtRecado + "</span><br>";
                                cadaRecado += "   </div>";
                                cadaRecado += "  </div>";
                                cadaRecado += " </a>";
                                cadaRecado += "<div class='espacamento'></div>";
                            }
                           
                        }
                      

                        



                    }





                }

            }

            litrecados.Text = cadaRecado;
        }

        protected void btn_filtrar_Click(object sender, EventArgs e)
        {
            string emailUsuario = "";

            clsRecadosRecebidos RecadosRecebidos = new clsRecadosRecebidos();

            List<string> datas = new List<string>();

            string cadaRecado = "";
            string TipoUsuario = "";
            string dataInicial = "";
            string dataFinal = "";


            DateTime date_time = DateTime.Parse(txt_data_inicial.Text);

     
            dataInicial = date_time.ToString("yyyy-MM-dd");
            date_time = DateTime.Parse(txt_data_final.Text);
           
            dataFinal = date_time.ToString("yyyy-MM-dd");





            if (Session["emailUsuario"] != null && Session["emailUsuario"].ToString() != "")
            {
                emailUsuario = Session["emailUsuario"].ToString();

            }




            datas = RecadosRecebidos.datas_recados(emailUsuario);
            lit_nome_usuario.Text = RecadosRecebidos.nome_destinatario(emailUsuario);
            if (datas.Count > 0)
            {
                for (int i = 0; i < datas.Count; i++)
                {
                    if (RecadosRecebidos.filt_recados_recebidos(emailUsuario,txt_data_inicial.Text,txt_data_final.Text))
                    {
                        if (RecadosRecebidos.recado_lido_funcionario == "1")
                        {

                            Session["data_recado"] = datas[i];
                            cadaRecado += "  <a   href='recado_especifico.aspx?c=" + datas[i] + "'>";
                            cadaRecado += "  <div class='recadoRecebido lido'>";
                            cadaRecado += "      <div class='paddingRecadoRecebido'>";
                            cadaRecado += "     <span class='tituloRecado'>" + RecadosRecebidos.TituloRecado + "</span>";
                            cadaRecado += "        <span class='nomeRemetente'>" + RecadosRecebidos.nmRemetente + "</span>";


                            cadaRecado += "     <span class='descricaoRecado'>" + RecadosRecebidos.dsRecado + "</span>";
                            cadaRecado += "       <span class='fr DataRecado'>" + RecadosRecebidos.dtRecado + "</span><br>";
                            cadaRecado += "   </div>";
                            cadaRecado += "  </div>";
                            cadaRecado += " </a>";
                            cadaRecado += "<div class='espacamento'></div>";

                        }
                        else
                        {
                            Session["data_recado"] = datas[i];
                            cadaRecado += "  <a   href='recado_especifico.aspx?c=" + datas[i] + "'>";
                            cadaRecado += "  <div class='recadoRecebido'>";
                            cadaRecado += "      <div class='paddingRecadoRecebido'>";
                            cadaRecado += "     <span class='tituloRecado'>" + RecadosRecebidos.TituloRecado + "</span>";
                            cadaRecado += "        <span class='nomeRemetente'>" + RecadosRecebidos.nmRemetente + "</span>";


                            cadaRecado += "     <span class='descricaoRecado'>" + RecadosRecebidos.dsRecado + "</span>";
                            cadaRecado += "       <span class='fr DataRecado'>" + RecadosRecebidos.dtRecado + "</span><br>";
                            cadaRecado += "   </div>";
                            cadaRecado += "  </div>";
                            cadaRecado += " </a>";
                            cadaRecado += "<div class='espacamento'></div>";
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