<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="horario.aspx.cs" Inherits="prj_schoon_pais.horario" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Horários</title>

    <link rel="sortcut icon" href="img/SchoONminiLogo.png" type="img/png" />
    <link href="https://fonts.googleapis.com/css2?family=Roboto&display=swap" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="css/geral.css">
    <link rel="stylesheet" type="text/css" href="css/horario.css">
    <link rel="stylesheet" href="css/responsive.css" media="screen and (max-width: 768px)"/>
</head>
<body>
    <form id="form1" runat="server">
   
               <header>
        <div class="container">

            <a href="recados.aspx">
                  <img src="./img/logoschoon.png" alt="SchoON" />
            
                
            </a>
          
          <div class="menu-section">
            <div class="menu-toggle">
              <div class="one"></div>
              <div class="two"></div>
              <div class="three"></div>
            </div>
            <nav>
              <ul>
                <li>
                  <a href="recados.aspx">Recados</a>
                </li>
                <li>
                  <a href="enviar_recado.aspx">Novo Recado</a>
                </li>
                <li>
                    <a href="boletim.aspx">Boletim</a>
                </li>
                <li>
                  <a href="horario.aspx">Horários</a>
                </li>
                <li>
                  <asp:Button ID="btnSair" class="sair" runat="server" Text="Sair" onclick="btnSair_Click" 
                        ></asp:Button>
                </li>
              </ul>
            </nav>
          </div>
        </div>
      </header>
      <script src="js/menu.js"></script>

      
      <main class="conteudo">
            <section class="enviarRecados">
                <div class="areaDados">
                    <div class="paddingAreaDados">

                      <div class="areaTitulo">
                        <span class="titulo"> Horários </span>
                      </div>

                      <div class="areaDadosHorario">
                        
                        <figure class="areaImagemHorario">
                <asp:Literal ID="lit_horarioEspecifico" runat="server"></asp:Literal>
                        </figure>

                        <div class="areaDadosAvancados">
                          <div class="paddingAreaDadosAvancados">

                              <div class="areaDescricaoHorario">
                                  <div class="paddingAreaDescricaoHorario">
                                  <span>Aulas Totais</span>
                                   <asp:Label ID="lblAulasTotais" runat="server" Text=""></asp:Label> </br>
                                            <span>Faltas Totais</span>
        <asp:Label ID="lblFaltasTotais" runat="server" Text=""></asp:Label> </br>
                 <span>Frequência</span>
        <asp:Label ID="lblFrequencia" runat="server" Text=""></asp:Label> 
                                  </div>
                              </div>
    
                              


       
  
       <div class="areaGrafico">
              <span>Faltas Totais</span>
        <asp:Chart ID="chtFaltasTotais"  runat="server">
            <Series>
                <asp:Series Name="Series1" IsValueShownAsLabel="True" 
                 XValueMember="Trimestre" YValueMembers="Faltas">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        </div>                         


                                  </div>
                              
  
                        </div>

                      </div>

                    </div>
                </div>
            </section>
      </main>
















    </form>
</body>
</html>
