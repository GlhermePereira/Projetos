<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="prj_schoon_pais.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SchoON</title>
   
</head>
<body>
    <form id="form1" runat="server">
   <body>
    <main>
     
            <asp:Label ID="label" runat="server" Text="Email"></asp:Label>
            <asp:Label ID="lblVerificacao" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="txt_email" class="caixaLogin" placeholder="Digite seu email" runat="server"></asp:TextBox>
       <asp:Label ID="Label2" runat="server" Text="Senha"></asp:Label>
                <asp:TextBox ID="txt_senha" type="password" class="caixaLogin" placeholder="Digite sua senha" runat="server"></asp:TextBox>
     
               <asp:Button ID="btn_login" runat="server" Text="Entrar" 
                    onclick="btn_login_Click"></asp:Button>
          
    </main>
</body>
    </form>
</body>
</html>
