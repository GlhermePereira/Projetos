<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recado_recebido.aspx.cs" Inherits="prj_schoon_pais.recado_recebido" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    

</head>
<body>
    <form id="form1" runat="server">
           <header>
         
            <div class=" fl menu">
                <ul>
                    <li><a href="recados.aspx">Recebidos</a></li>
                    <li><a href="enviados.aspx">Enviados</a></li>
                  
                    <li><a href="notas.aspx">notas</a></li>
                
                </ul>
            </div>

            <div class="fr areaSair">
              <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                <div class="fr botaoSair">
                    <a href="#" class="btn">Sair</a>
                </div>
                <div class="cls"></div>
            </div>

            <div class="cls"></div>
  
        </header>

     

       <asp:Literal ID="lit_nome_usuario" runat="server"></asp:Literal>
                    <asp:Literal ID="lit_reacado_unico" runat="server"></asp:Literal>
                       

   
    </form>
</body>
</html>
