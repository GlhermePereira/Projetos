<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="prj_SchoON.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>SchoON</title>

    <link rel="sortcut icon" href="img/SchoONminiLogo.png" type="img/png" />
    <link href="https://fonts.googleapis.com/css2?family=Roboto&display=swap" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="css/geral.css">
    
    <link rel="stylesheet" type="text/css" href="css/login.css">
  
    
</head>

<body>
    <form id="form1" runat="server" method="post">
    <main>
        <div class="areaLogin">
            <figure>
                    <img class="logo" src="img/logoschoon.png" alt="Logotipo do site">
            </figure>

            <div class="interiorAreaLogin">
                  <asp:TextBox ID="txt_email" runat="server" placeholder="Digite seu Email" class="caixaLogin"></asp:TextBox>                
                  <asp:TextBox ID="txt_senha" runat="server" placeholder="Digite sua senha"  type="password" class="caixaLogin"></asp:TextBox>
                   <asp:Label class="fl validation" ID="lblVerificacao" runat="server" Text=""></asp:Label>
                <asp:Button ID="btn_login" runat="server" class="fr botaoLogin" Text="Entrar" 
                    onclick="btn_login_Click"></asp:Button>

      
              
            </div>
        </div>
    </main>
    
    </form>

    
</body>
</html>
