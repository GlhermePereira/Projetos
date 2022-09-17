 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="enviar_recado_turma.aspx.cs" Inherits="prj_SchoON.enviar_recado_turma" %>

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
                  <asp:Button ID="btnSair"  class="botaoSair" runat="server" Text="Sair" 
                        onclick="btnSair_Click"></asp:Button>
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
            
            <div class="areaTitulo"><span class="titulo">Enviar Recados</span></div>

            <div class="areaEnviar">
                <div class="paddingEnviar">


                    <div class="areaDadosAluno">
                     <asp:DropDownList ID="dp_turmas" class="selectTurmasTurma" runat="server" 
                            AutoPostBack="True">
        </asp:DropDownList>
                        

                    </div>

                    <div class="areaCombosBox">

                    
                        <asp:DropDownList ID="tipos_recados_turma" class="selectAssuntos" runat="server" 
                            >
        </asp:DropDownList>
                        
                          <asp:TextBox ID="txt_titulo_recado_turma" class="caixaTitulo" runat="server" AutoPostBack="True"></asp:TextBox>

                        

                    </div>

                    <div class="areaDescricaoTurm">
                        <asp:TextBox ID="txt_descricao_recado_turma"  class="textArea"  TextMode="MultiLine" Columns="50" Rows="5"  runat="server" 
            placeholder="digte a descrição do recado" ></asp:TextBox>
                    </div>

                    <div class="areaImagem">
                        <asp:FileUpload ID="fl_upload_imagen_turma" runat="server" />
                    </div>

                    <div class="areaBotoes">

                        <div class="fl paddingAreaBotoes">
                            <asp:Button class="btnDescartar" ID="Button1" runat="server" Text="Descartar" />
                        </div>

                        <div class="fr paddingAreaBotoes">
                            <asp:Button class="btnEnviar" ID="btn_enviar_recado_turma" runat="server" Text="Enviar" onclick="btnEnviarRecadoTurma_Click" />
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
