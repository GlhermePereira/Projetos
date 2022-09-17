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
            lit_nome_usuario.Text = RecadosEnviados.nome_destinatario(emailUsuario);










            List<string> nome_recado = new List<string>();
            nome_recado = RecadosEnviados.nome_tipo_recado();


            if (!IsPostBack)
            {
                for (int i = 0; i < nome_recado.Count; i++)
                {


                    dp_tipo_recado.Items.Add(nome_recado[i]);

                }
                dp_tipo_recado.Items.Insert(0, new ListItem("-- Tipos Recados --", ""));


            }


            if (datas.Count > 0)
            {

                for (int i = 0; i < datas.Count; i++)
                {
                    if (RecadosEnviados.Recado_especifico_enviado_responsaveis(emailUsuario, datas[i]))
                    {

                        Session["data_recado"] = datas[i];
                        cadaRecado += "  <a href='recado_enviado.aspx?c=" + datas[i] + "'>";
                        cadaRecado += "  <div class='recadoRecebido'>";
                        cadaRecado += "      <div class='paddingRecadoRecebido'>";
                        cadaRecado += "     <span class='tituloRecado'>" + RecadosEnviados.TituloRecado + "</span>";
                        cadaRecado += "        <span class='nomeDestinatario'>" + RecadosEnviados.nmRemetente + "</span>";


                        cadaRecado += "     <span class='descricaoRecado'>" + RecadosEnviados.dsRecado + "</span>";
                        cadaRecado += "       <span class='fr DataRecado'>" + RecadosEnviados.dtRecado + "</span><br>";
                        cadaRecado += "   </div>";
                        cadaRecado += "  </div>";
                        cadaRecado += " </a>";
                        cadaRecado += "<div class='espacamento'></div>";



                    }

                }
            }


            litrecados.Text = cadaRecado;
        }

        protected void dp_tipo_recado_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsRecadosEnviados RecadosEnviados = new clsRecadosEnviados();

            string emailUsuario = "";



            List<string> datas = new List<string>();
            string nome_responsavel = "";
            nome_responsavel = RecadosEnviados.filt_nome_responsavel(txt_nome_remetente.Text);
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

            
            datas = RecadosEnviados.datas_recados(emailUsuario);
            lit_nome_usuario.Text = RecadosEnviados.nome_destinatario(emailUsuario);
            if (datas.Count > 0)
            {
                for (int i = 0; i < datas.Count; i++)
                {
                    if (RecadosEnviados.Recados_enviados_responsaveis(emailUsuario, datas[i]))
                    {
                        if (dp_tipo_recado.SelectedIndex.ToString() == RecadosEnviados.TipoRecado)
                        {

                            cadaRecado += "  <a href='recado_enviado.aspx?c=" + datas[i] + "'>";
                            cadaRecado += "  <div class='recadoRecebido'>";
                            cadaRecado += "      <div class='paddingRecadoRecebido'>";
                            cadaRecado += "     <span class='tituloRecado'>" + RecadosEnviados.TituloRecado + "</span>";
                            cadaRecado += "        <span class='nomeDestinatario'>" + RecadosEnviados.nmRemetente + "</span>";


                            cadaRecado += "     <span class='descricaoRecado'>" + RecadosEnviados.dsRecado + "</span>";
                            cadaRecado += "       <span class='fr DataRecado'>" + RecadosEnviados.dtRecado + "</span><br>";
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

        protected void btn_buscar_Click(object sender, EventArgs e)
        {
            clsRecadosEnviados RecadosEnviados = new clsRecadosEnviados();

            string emailUsuario = "";



            List<string> datas = new List<string>();
            string nome_responsavel = "";
            nome_responsavel = RecadosEnviados.filt_nome_responsavel(txt_nome_remetente.Text);
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

          
            datas = RecadosEnviados.datas_recados(emailUsuario);
            lit_nome_usuario.Text = RecadosEnviados.nome_destinatario(emailUsuario);
            if (datas.Count > 0)
            {
                for (int i = 0; i < datas.Count; i++)
                {
                    if (RecadosEnviados.Recados_enviados_responsaveis(emailUsuario, datas[i]))
                    {
                        if (nome_responsavel == RecadosEnviados.nmRemetente)
                        {
                            cadaRecado += "  <a href='recado_enviado.aspx?c=" + datas[i] + "'>";
                            cadaRecado += "  <div class='recadoRecebido'>";
                            cadaRecado += "      <div class='paddingRecadoRecebido'>";
                            cadaRecado += "     <span class='tituloRecado'>" + RecadosEnviados.TituloRecado + "</span>";
                            cadaRecado += "        <span class='nomeDestinatario'>" + RecadosEnviados.nmRemetente + "</span>";


                            cadaRecado += "     <span class='descricaoRecado'>" + RecadosEnviados.dsRecado + "</span>";
                            cadaRecado += "       <span class='fr DataRecado'>" + RecadosEnviados.dtRecado + "</span><br>";
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

        protected void txt_nome_remetente_TextChanged(object sender, EventArgs e)
        {
            clsRecadosEnviados RecadosEnviados = new clsRecadosEnviados();

            string emailUsuario = "";


            List<string> datas = new List<string>();
            string nome_responsavel = "";
            nome_responsavel = RecadosEnviados.filt_nome_responsavel(txt_nome_remetente.Text);
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

          
            datas = RecadosEnviados.datas_recados(emailUsuario);
            lit_nome_usuario.Text = RecadosEnviados.nome_destinatario(emailUsuario);
            if (datas.Count > 0)
            {
                for (int i = 0; i < datas.Count; i++)
                {
                    if (RecadosEnviados.Recados_enviados_responsaveis(emailUsuario, datas[i]))
                    {
                        if (nome_responsavel == RecadosEnviados.nmRemetente)
                        {
                            cadaRecado += "  <a href='recado_enviado.aspx?c=" + datas[i] + "'>";
                            cadaRecado += "  <div class='recadoRecebido'>";
                            cadaRecado += "      <div class='paddingRecadoRecebido'>";
                            cadaRecado += "     <span class='tituloRecado'>" + RecadosEnviados.TituloRecado + "</span>";
                            cadaRecado += "        <span class='nomeDestinatario'>" + RecadosEnviados.nmRemetente + "</span>";


                            cadaRecado += "     <span class='descricaoRecado'>" + RecadosEnviados.dsRecado + "</span>";
                            cadaRecado += "       <span class='fr DataRecado'>" + RecadosEnviados.dtRecado + "</span><br>";
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
    }
}