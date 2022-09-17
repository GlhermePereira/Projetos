<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="prj_schoon_pais.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Schoon</title>

    <link rel="sortcut icon" href="img/SchoONminiLogo.png" type="img/png" />
    <link href="https://fonts.googleapis.com/css2?family=Roboto&display=swap" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="css/geral.css">
    <link rel="stylesheet" type="text/css" href="css/login.css">
    <link rel="stylesheet" href="css/responsive.css" media="screen and (max-width: 768px)"/>
   
</head>
 <body>
    <form id="form1" runat="server">
  
    <script src="js/menu.js"></script>

    <main class="conteudo">
            <div class="quadradoLogin">

                <figure>
                    <img class="logo" src="img/logoschoon.png" alt="Logotipo do site">
                </figure>

                <div class="paddingQuadradoLogin">
                  <asp:TextBox ID="txt_email" class="caixaLogin" placeholder="Digite seu email" runat="server"></asp:TextBox>
            <asp:TextBox ID="txt_senha" type="password" class="caixaLogin2" placeholder="Digite sua senha" runat="server"></asp:TextBox>
                    

                     <asp:Label ID="lblVerificacao" class="observacao fl" runat="server" Text=""></asp:Label>
         
         
               <asp:Button ID="btn_login" class="fr botaoLogin" runat="server" Text="Entrar" 
                    onclick="btn_login_Click"></asp:Button>
                    
                </div>

            </div>
      </main>


   

    </form>
</body>
</html>
