<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="importar_notas.aspx.cs" Inherits="prj_SchoON.importar_notas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Importar Notas</title>

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
             
            <div class="areaTitulo"><span class="titulo">Importar Notas</span></div>

            <div class="areaImportar">
                <div class="areaBotoes">
                    <asp:Button ID="btn_Importxlx" class="fr BotaoImportar"  runat="server" Text="Selecionar Notas" OnClick="btn_ImportCSV_Click" />
                 <asp:FileUpload ID="fu_Import_excel"   runat="server" />

                       
                </div>

                <div class="areaGrid">
                 <center> 
                     <asp:GridView ID="gvnota" runat="server" 
         AutoGenerateColumns="False" onpageindexchanging="gvnota_PageIndexChanging" 
                            onrowediting="gvnota_RowEditing" Height="16px" Width="1062px">
                <EmptyDataTemplate>
                    <div style="padding:10px">
                        Data not found!
                    </div>
                </EmptyDataTemplate>
                <Columns>
                    <asp:BoundField HeaderText="Codigo Aluno" DataField="CODIGO_ALUNO" 
                        ItemStyle-ForeColor="Blue" >
<ItemStyle ForeColor="Blue"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Data" DataField="DATA_NOTA" 
                        ItemStyle-ForeColor="Blue" >
<ItemStyle ForeColor="Blue"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Codigo Tipo Nota" DataField="CODIGO_NOTA" 
                        ItemStyle-ForeColor="Blue" >
<ItemStyle ForeColor="Blue"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText=" Codigo Materia " DataField="CODIGO_MATERIA" 
                        ItemStyle-ForeColor="Blue" >
<ItemStyle ForeColor="Blue"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Descrição" DataField="DS_NOTA" 
                        ItemStyle-ForeColor="Blue" HtmlEncode="False" >
<ItemStyle ForeColor="Blue"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Trimestre" DataField="CODIGO_TRIMESTRE_NOTA" 
                        ItemStyle-ForeColor="Blue" HtmlEncode="False" >
<ItemStyle ForeColor="Blue"></ItemStyle>
                    </asp:BoundField>
                     <asp:BoundField HeaderText="Nota Atribuida " DataField="NOTA_ATRIBUIDA" 
                        ItemStyle-ForeColor="Blue" >
<ItemStyle ForeColor="Blue"></ItemStyle>
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
            </center>
                   
            <br />
            <center>
                </div>

                <div class="areaBotaoImportar">
                    <div class="areaPaddingBotaoImportar">
                     <asp:Button class="fr BotaoImportar"  ID="btn_importar" runat="server" Text="Importar" 
         onclick="btn_importar_Click" />
                        
                    </div>
                </div>
            </div>

        </section>
    </section>












        </main>
    </form>
</body>
</html>
