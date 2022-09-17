<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="responder_recado_funcionario.aspx.cs" Inherits="prj_schoon_pais.enviar_recado_funcionario" %>

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
   <asp:DropDownList ID="dropDownTipoRecado" runat="server" AutoPostBack="True" 
          >
        <asp:ListItem>Tipos de Recado</asp:ListItem>
        </asp:DropDownList><br />



        <span>Nome Funcionario: </span>
        <asp:Label ID="lblNomeFuncionario" runat="server" Text="Nome"></asp:Label><br />
        <span>Email Responsavel: </span>
        <asp:Label ID="lblEmailFuncionario" runat="server" Text="Nome"></asp:Label><br />

        <asp:TextBox ID="txtDescricaoRecado" runat="server" placeholder="digte a descrição do recado"></asp:TextBox><br /><br />
        <asp:Panel ID="pnl_fotos" runat="server">
        </asp:Panel>
        <asp:FileUpload ID="fl_upload_imagen" runat="server" />
        <br />
        
        <asp:Button ID="btnExcluirImagem" runat="server" Text="X" /><br /><br />

        <asp:Button ID="btnDescartar" runat="server" Text="Descartar" />
        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" 
            onclick="btnEnviar_Click" />

    </form>
</body>
</html>
