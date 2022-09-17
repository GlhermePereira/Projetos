<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inserirHorario.aspx.cs" Inherits="prj_SchoON.inserirHorario" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Inserir Horarios</title>

     <link rel="sortcut icon" href="img/SchoONminiLogo.png" type="img/png" />
    <link href="https://fonts.googleapis.com/css2?family=Roboto&display=swap" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="css/geral.css">
    <link rel="stylesheet" type="text/css" href="css/InserirHorario.css">
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
            
            <div class="areaTitulo"><span class="titulo">Inserir Horários</span></div>

            <div class="areaImportar">
                <div class="paddingAreaImportar">
                <asp:DropDownList ID="dp_turmas" class="fl selectAnos" runat="server" 
                        AutoPostBack="True">
        </asp:DropDownList>
                    
                     <asp:FileUpload  ID="fl_upload_imagen" runat="server" />
   
     <asp:Button class="fr botaoInserirHorario" ID="btnEnviar" runat="server" Text="Cadastrar Horário" 
            onclick="btnEnviar_Click" />
                    
                </div>
            </div>

            <div class="areaHorarios">
                <div class="paddingAreaHorarios">
                             
                   <asp:Literal ID="lit_horarioEspecifico" runat="server"></asp:Literal>
             

                </div>
            </div>

        </section>
    </section>
















      

    

    </main>
    </form>
</body>
</html>
