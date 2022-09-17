<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="enviar_recado.aspx.cs" Inherits="prj_schoon_pais.enviar_recado" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <header>
            
 
            <nav class="fl menu">
                <ul>
                    <li><a href="#">Recados</a>
                        <ul>
                            <li><a href="recados.aspx">Recebidos</a></li>
                            <li><a href="enviados.aspx">Enviados</a></li> 
                        </ul>
                    </li>
                   
                    <li><a >Enviar Recados</a>
                        <ul>
                            <li><a href="enviar_recado_aluno.aspx">Individual</a></li>
                            <li><a href="enviar_recado_turma.aspx">Turma</a></li>
                        </ul>
                    </li>
                    
                    <li><a> Importações</a>
                        <ul>
                            <li><a href="importar_notas.aspx">Notas</a></li>
                            <li><a href="importar_alunos.aspx">Alunos</a></li>
                            <li><a href="importar_materia.aspx">Matérias</a></li>
                            <li><a href="importar_pais.aspx">Pais</a></li>
                        </ul>
                    </li>
                    
                </ul>
            </nav>

            <div class="fr areaSair">
              <asp:Literal ID="lit_nome_usuario" runat="server"></asp:Literal>
                <div class="fr botaoSair">
                    <a href="#" class="btn">Sair</a>
                </div>
                <div class="cls"></div>
            </div>

            <div class="cls"></div>
  
        </header>
             <section class="areaConteudo">
            <div class="conteudo">

                <div class="areaTitulo">
                    <span class="spanTitulo">Enviar Recado </span>
                </div>

                <div class="areaEnviar">
              
              
                

                
                    <div class="paddingEnviar">


                  
                     
                            <asp:DropDownList ID="dp_nm_funcionarios" runat="server" 
               
                                AutoPostBack="True" 
                                onselectedindexchanged="dp_nm_funcionarios_SelectedIndexChanged">
                                  
                            </asp:DropDownList>
                             <asp:DropDownList ID="dropDownTipoRecado" class="selectTiposRecado"   runat="server" AutoPostBack="True"></asp:DropDownList>
                     
                        <asp:Label ID="lblVerificacao" runat="server" Text=""></asp:Label>
                        <div class="areaDropDown">   
                        <div class="areaNome">
                       
                              <span class="spanDados"> Titulo: </span><br />
                        <asp:TextBox ID="txt_titulo" runat="server" AutoPostBack="True"></asp:TextBox><br />
                       
                         
                         
              
                        </div>                       
                      
                        </div>
                       

                        <div class="areaTexto">
                           
                           
                             <asp:TextBox ID="txtDescricaoRecado"  TextMode="MultiLine" Columns="50" Rows="5" class="textArea" runat="server" 
                             placeholder="digte a descrição do recado" AutoPostBack="True"></asp:TextBox>
                        </div>

                        <div class="areaImagem">

                            <div class="area">
                            <asp:FileUpload  ID="fl_upload_imagen" runat="server" />
                            </div>
                                
                            </div>
                          

                        </div>

                        <div class="areaBotoes">
                           <asp:Panel ID="pnl_fotos" runat="server"></asp:Panel>
                           <asp:Button class="btn fr" ID="btnEnviar" runat="server" Text="Enviar" 
            onclick="btnEnviar_Click" />
                            <a class="btn fl"> Descartar</a>
                          
                        </div>
                     
    </form>
</body>
</html>
