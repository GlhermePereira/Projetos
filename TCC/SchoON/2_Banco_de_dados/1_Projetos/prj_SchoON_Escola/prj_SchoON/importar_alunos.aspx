<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="importar_alunos.aspx.cs" Inherits="prj_SchoON.importar_alunos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Importar Alunos</title>

    <link rel="sortcut icon" href="img/SchoONminiLogo.png" type="img/png" />
    <link href="https://fonts.googleapis.com/css2?family=Roboto&display=swap" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="css/geral.css">
    <link rel="stylesheet" type="text/css" href="css/importar.css">
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
           
                
               
                  
                     <div class="areaTitulo"><span class="titulo">Importar Alunos</span></div>
                     <div class="areaImportar">

                     <div class="areaBotoes">
                       <asp:Button ID="btn_Importxlx" class="fr BotaoImportar" runat="server" Text="Selecionar Alunos" 
        onclick="btn_Import_Click" />

                      <asp:FileUpload  ID="fu_Import_excel" runat="server"   
                             onload="fu_Import_excel_Load" />
                      

                </div>

                 <div class="areaGrid">
                 <center> 
                     <asp:GridView ID="gvAlunos" runat="server" 
         AutoGenerateColumns="False" Width="1107px">
                <EmptyDataTemplate>
                    <div style="padding:10px">
                        Data not found!
                    </div>
                </EmptyDataTemplate>
                <Columns>
                    <asp:BoundField HeaderText="Turma" DataField="cd_sg_turma" HtmlEncode="False" />
                    <asp:BoundField HeaderText="Ano " DataField="aa_turma" />
                    <asp:BoundField HeaderText="Nome Aluno" DataField="nm_aluno" HtmlEncode="False" />
                    <asp:BoundField HeaderText="Codigo Aluno " DataField="cd_aluno" HtmlEncode="False"/>
                    <asp:BoundField HeaderText="Email Responsavel" DataField="nm_email_responsavel" HtmlEncode="False" />
                    
                </Columns>
            </asp:GridView>
            </center>
           
                </div>


                <div class="areaBotaoImportar">
                    <div class="areaPaddingBotaoImportar">
                               
           
                    <asp:Button class="fr BotaoImportar" ID="btn_importar" runat="server" Text="Importar" 
         onclick="btn_importar_Click" />
         <asp:Label ID="lblVerificacao" runat="server" Text=""></asp:Label>
            
                 <asp:Label ID="lbl_ErrorMsg" runat="server" Visible="false"></asp:Label>
                    </div>
                    </div>
        </div>
                   
                 
        </section>
                
        </section>
    </main>
    </form>  
  
</body>
</html>
