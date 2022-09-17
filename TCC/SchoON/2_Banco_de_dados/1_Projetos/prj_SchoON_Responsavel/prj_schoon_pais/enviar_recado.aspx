<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="enviar_recado.aspx.cs" Inherits="prj_schoon_pais.enviar_recado" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Enviar Recados</title>

    <link rel="sortcut icon" href="img/SchoONminiLogo.png" type="img/png" />
    <link href="https://fonts.googleapis.com/css2?family=Roboto&display=swap" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="css/geral.css">
    <link rel="stylesheet" type="text/css" href="css/enviarRecados.css">
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
                            <span class="titulo"> Enviar Recado</span>
                        </div>

                        <div class="areaSelects">

                        <asp:DropDownList ID="dropDownTipoRecado" class="selectTiposRecado"   runat="server" AutoPostBack="True"></asp:DropDownList>


                             <asp:DropDownList ID="dp_nm_funcionarios" class="selectFuncionarios" runat="server" AutoPostBack="True" onselectedindexchanged="dp_nm_funcionarios_SelectedIndexChanged">
                            </asp:DropDownList>

                          

                            <div>
                                    <asp:TextBox ID="txt_titulo" type="text"  class="caixaTitulo" placeholder="Título do recado" runat="server" AutoPostBack="True"></asp:TextBox><br />
                              
                            </div>
                            

                            <div class="areaDescricao">
                            <asp:TextBox ID="txtDescricaoRecado"  TextMode="MultiLine" Columns="50" Rows="5" class="textArea" runat="server" 
                             placeholder="digte a descrição do recado" AutoPostBack="True"></asp:TextBox>
                             
                            </div>

                            <div class="areaBotao">
                                <div class="fr">
                                <asp:Button class="botaoEnviar" ID="btnEnviar" runat="server" Text="Enviar" 
            onclick="btnEnviar_Click" />
                                   
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
