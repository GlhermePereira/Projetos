<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="boletim.aspx.cs" Inherits="prjNotas.boletim" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html>
<head runat="server">
 <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Boletim</title>

    <link rel="sortcut icon" href="img/SchoONminiLogo.png" type="img/png" />
    <link href="https://fonts.googleapis.com/css2?family=Roboto&display=swap" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="css/geral.css">
    <link rel="stylesheet" type="text/css" href="css/boletim.css">
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
                 <asp:Button ID="btnSair" class="sair" runat="server" Text="Sair" 
                        onclick="btnSair_Click"></asp:Button>
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
                            <span class="titulo"> Boletim </span>
                        </div>

                        <div class="areaNota">

                          <div class="areaBoletim">
                          <asp:GridView ID="dgvBoletim" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Matéria" HeaderText="Matéria" />
                <asp:HyperLinkField DataNavigateUrlFields="Link 1º Trimestre" 
                    DataTextField="1º Trimestre" HeaderText="1º Trimestre" />
                <asp:HyperLinkField DataNavigateUrlFields="Link 2º Trimestre" 
                    DataTextField="2º Trimestre" HeaderText="2º Trimestre" />
                <asp:HyperLinkField DataNavigateUrlFields="Link 3º Trimestre" 
                    DataTextField="3º Trimestre" HeaderText="3º Trimestre" />
                <asp:BoundField DataField="Frequência" HeaderText="Frequência" />
            </Columns>
        </asp:GridView>
                            
                          </div>
                          
                          
                          <div class="areaDadosNota">
                              <div class="paddingAreaDadosNota">

                                  <div class="areaDescricao">
                                      <div class="paddingAreaDescricao">
      
         <asp:GridView ID="dgvInformacaoNota" runat="server">
        </asp:GridView>
                                      </div>
                                  </div>
        
                                  <span>Notas</span>

                                  <div class="areaGrafico">

                           

                                    <asp:Chart ID="chtNotas" runat="server" >
            <Series>
                <asp:Series Name="Series1" IsValueShownAsLabel="True" 
                 XValueMember="Trimestre" YValueMembers="Notas">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
                                  
<span>Faltas</span>
                               <asp:Chart ID="chtFaltas" runat="server">
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

        </br>

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
