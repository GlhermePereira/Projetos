<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="responder_recados.aspx.cs" Inherits="prj_SchoON.responder_recados" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Enviar Recado</title>

    <link rel="sortcut icon" href="img/SchoONminiLogo.png" type="img/png" />
    <link href="https://fonts.googleapis.com/css2?family=Roboto&display=swap" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="css/geral.css">
    <link rel="stylesheet" type="text/css" href="css/enviar.css">
    <script src="js/jquery-3.2.0.min.js" type="text/javascript"></script>
    <script src="js/script.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <main>
    <header>

            <div class="fl areaLogo">
            <figure class="logoCabecalho">
  <a href="recados.aspx"><img class="logoMenu" src="img/logoschoon.png" alt="Logotipo do site"></a>
            </figure>
        </div>
          
            <nav class="menu">
              <ul>
                <li><a id="lblQuantidade" href="#">Recados </a>
                    <ul>
                        <li><a  href="recados.aspx">Recebidos </a></li>
                        <li><a href="enviados.aspx">Enviados</a></li>
                    </ul>
                </li>
                <li><a href="#"> Enviar Recado </a>
                  <ul>
                        <li><a  href="enviar_recado_aluno.aspx">Individual </a></li>
                        <li><a href="enviar_recado_turma.aspx">Turma</a></li>
                    </ul>
                </li>
                <li><a href="#"> Importações</a>
                    <ul>
                         <li><a href="importar_notas.aspx">Notas</a></li>
                        <li><a href="importar_materia.aspx">Matérias</a></li>
                        <li><a href="importar_alunos.aspx">Alunos</a></li>
                        <li><a href="importar_pais.aspx">Responsáveis</a></li>
                    </ul>
                </li>
                <li><a href="funcionarios.aspx">Funcionários</a>

                </li>
                <li><a href="inserirHorario.aspx">Horários</a>

                </li>
            </ul>
         

             <div class="fr areaSair">
                <div class="paddingAreaSair">
                     <asp:Button ID="btnSair"  class="botaoSair" runat="server" Text="Sair" onclick="btnSair_Click" 
                        ></asp:Button>
                </div>
            </div>
            
            <div class="fr areaNome">
                <div class="paddingAreaNome"> 
<asp:Literal ID="lit_nome_usuario" runat="server"></asp:Literal>
                </div>
            </div>


  
            </nav>
            
  
        </header>

        <section class="conteudo">
        <section class="paddingConteudo">
            
            <div class="areaTitulo"><span class="titulo">Responder Recado</span></div>

            <div class="areaEnviar">
                <div class="paddingEnviar">

                    <div class="areaCombosBoxResponder">

                  <asp:DropDownList ID="dropDownTipoRecado" class="selectAssuntos"  runat="server" AutoPostBack="True"></asp:DropDownList>
                       
                       <asp:TextBox ID="txt_titulo_recado" placeholder="Título do recado" runat="server" class="caixaTitulo" AutoPostBack="True"></asp:TextBox>
                      

                    </div>

                    <div class="areaNomeResponsavel">
                     <span  class="nomeResponsavel">Nome do Responsável: </span>
                                 <asp:Label  class="nomeResponsavel" ID="lblNomeResponsavel" runat="server" Text=""></asp:Label><br />
                    <span  class="nomeResponsavel"> Nome do aluno: </span>
                            <asp:Label  class="nomeResponsavel" ID="lblNomeALuno" runat="server" Text=""></asp:Label><br />
                               
                        

                    </div>

                    <div class="areaDescricaoResponder">
                    <asp:TextBox ID="txtDescricaoRecado"   class="textArea" TextMode="MultiLine" Columns="50" Rows="5"  runat="server" 
                             placeholder="digte a descrição do recado" AutoPostBack="True"></asp:TextBox>
                        
                    </div>

                    <div class="areaImagem">
                          <asp:FileUpload  class="btn" ID="fl_upload_imagen" runat="server" />
           
                    </div>

                    <div class="areaBotoes">

                        <div class="fl paddingAreaBotoes">
                            <a class="btnDescartar"> Descartar </a>
                        </div>

                        <div class="fr paddingAreaBotoes">
                            <asp:Button class="btnEnviar" ID="btnEnviar" runat="server" Text="Enviar" onclick="btnEnviar_Click" />
                  
                        </div>

                    </div>

                </div>
            </div>

        </section>
    </section>


        </main>
    </form>
</body>
</html>
