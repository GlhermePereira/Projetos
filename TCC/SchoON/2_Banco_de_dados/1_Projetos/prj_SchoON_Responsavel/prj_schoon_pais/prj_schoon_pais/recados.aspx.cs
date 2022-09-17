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



                        Session["data_recado"] = datas[i];
                        cadaRecado += "  <a href='recado_recebido.aspx?c=" + datas[i] + "'>";
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

            litrecados.Text = cadaRecado;
         

               
        }

        protected void dp_tipo_recado_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsRecadosRecebidos RecadosRecebidos = new clsRecadosRecebidos();

            string emailUsuario = "";


            List<string> datas = new List<string>();
            string nome_responsavel = "";
            nome_responsavel = RecadosRecebidos.filt_nome_responsavel(txt_nome_remetente.Text);
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
                                Session["data_recado"] = datas[i];
                                cadaRecado += "  <a href='recado_recebido.aspx?c=" + datas[i] + "'>";
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

        protected void txt_nome_remetente_TextChanged(object sender, EventArgs e)
        {
            clsRecadosRecebidos RecadosRecebidos = new clsRecadosRecebidos();

            string emailUsuario = "";



            List<string> datas = new List<string>();
            string nome_responsavel = "";
            nome_responsavel = RecadosRecebidos.filt_nome_responsavel(txt_nome_remetente.Text);
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


                        if (nome_responsavel == "")
                        {
                            cadaRecado += "        <span class='nmRemetente'>" + nome_responsavel + " Não Foi encontrado " + "</span>";
                            return;
                        }
                        else
                        {
                            Session["data_recado"] = datas[i];
                            cadaRecado += "  <a href='recado_recebido.aspx?c=" + datas[i] + "'>";
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

        protected void btn_buscar_Click(object sender, EventArgs e)
        {
            clsRecadosRecebidos RecadosRecebidos = new clsRecadosRecebidos();

            string emailUsuario = "";


            List<string> datas = new List<string>();
            string nome_responsavel = "";
            nome_responsavel = RecadosRecebidos.filt_nome_responsavel(txt_nome_remetente.Text);
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
                        if (nome_responsavel == "")
                        {
                            cadaRecado += "        <span class='nmRemetente'>" + nome_responsavel + " Não Foi encontrado " + "</span>";
                            return;
                        }
                        else
                        {
                            Session["data_recado"] = datas[i];
                            cadaRecado += "  <a href='recado_recebido.aspx?c=" + datas[i] + "'>";
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
    }
}