<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="enviados.aspx.cs" Inherits="prj_SchoON.enviados" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Recados Enviados</title>

    <link rel="sortcut icon" href="img/SchoONminiLogo.png" type="img/png" />
    <link href="https://fonts.googleapis.com/css2?family=Roboto&display=swap" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="css/geral.css">
    <link rel="stylesheet" type="text/css" href="css/recados.css">
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
            
            <div class="areaTitulo"><span class="titulo">Recados Enviados</span></div>

            <div class="filtragemRecados">
                <div class="paddingFitragemRecados">
                <asp:DropDownList ID="dp_tipo_recado" runat="server" AutoPostBack="True" 
                onselectedindexchanged="dp_tipo_recado_SelectedIndexChanged" class="fl selectTiposRecado"></asp:DropDownList>
                 
                    <div class="fl areaNome">
                    <asp:TextBox ID="txt_nome_remetente"  class="caixaNome" placeholder="Digite o nome do responsavel" runat="server" 
                ontextchanged="txt_nome_remetente_TextChanged"></asp:TextBox>
                
            </div>

                <div class="fl areaBotaoBuscar">
                    <asp:Button ID="btn_buscar" class="botaoBuscar" runat="server" Text="Buscar" onclick="btn_buscar_Click"></asp:Button>
               </div>

               <div class="fr areaData">
                    <asp:TextBox class="timePeeker"  ID="txt_data_inicial" type="date" runat="server"></asp:TextBox>
                     <span class="between"> - </span>
                    <asp:TextBox  class="timePeeker" ID="txt_data_final"  type="date" runat="server"></asp:TextBox>
                    <asp:Button ID="btn_filtrar" class="botaoBuscar" runat="server" Text="Filtrar" onclick="btn_filtrar_Click"></asp:Button>
               </div>
                    

                </div>
            </div>


            <div class="listaRecados">
                
                  <asp:Literal ID="litrecados" runat="server"></asp:Literal>

            </div>

        </section>
    </section>
      
      
	</main>
    </form>
</body>
</html>
