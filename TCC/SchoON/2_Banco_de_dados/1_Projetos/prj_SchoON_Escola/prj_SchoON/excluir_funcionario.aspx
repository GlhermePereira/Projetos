<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="excluir_funcionario.aspx.cs" Inherits="prj_SchoON.excluir_funcionari" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Funcionários</title>

    <link rel="sortcut icon" href="img/SchoONminiLogo.png" type="img/png" />
    <link href="https://fonts.googleapis.com/css2?family=Roboto&display=swap" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="css/geral.css">
    <link rel="stylesheet" type="text/css" href="css/funcionarios.css">
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
            
            <div class="areaTitulo"><span class="titulo">Funcionários</span></div>

            <div class="filtragemFuncionarios">
                <div class="paddingFitragemFuncionarios">
                   
                    <div class="fl areaNome">
<asp:TextBox ID="txt_nm_funcionario"  class="caixaNome"   placeholder="Nome Funcionário" runat="server" 
                            AutoPostBack="True" ontextchanged="txt_nm_funcionario_TextChanged"></asp:TextBox>
                      
                    </div>
                       <asp:Button ID="btn_cadastrar_func" class="fr botaoCadastrarFuncionario" 
                        href="importar_funcionarios.aspx" runat="server" Text="Cadastrar Funcionario" 
                        onclick="btn_cadastrar_func_Click"></asp:Button>
                 
        
                </div>
            </div>

            <div class="listaFuncionarios">
                <asp:Literal ID="lt_funcionarios" runat="server"></asp:Literal>
                    

            </div>

        </section>
    </section>
        
        
        </main>
    </form>
</body>
</html>
