<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recados.aspx.cs" Inherits="prj_schoon_pais.recados_recebidos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
</head>
<body>
    <form id="form1" runat="server">
              <main>
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
           <section class="conteudo">
        <section class="paddingConteudo">
            
            <div class="areaTitulo"><span class="titulo">Recados Enviados</span></div>

            <div class="filtragemRecados">
                <div class="paddingFitragemRecados">
                <asp:DropDownList ID="dp_tipo_recado" runat="server" AutoPostBack="True" 
                onselectedindexchanged="dp_tipo_recado_SelectedIndexChanged" class="fl selectTiposRecado"></asp:DropDownList>
                 
                    <div class="fl areaNome">
                    <span>Nome Responsavel:</span></div>
                    <asp:TextBox ID="txt_nome_remetente"  class="caixaNome" 
                        placeholder="Digite o nome do responsavel" runat="server" 
                ontextchanged="txt_nome_remetente_TextChanged" AutoPostBack="True"></asp:TextBox>
                <asp:Button ID="btn_buscar" runat="server" Text="Buscar" onclick="btn_buscar_Click"></asp:Button>
            </div>

             
                    <div class="fr areaData">
                        <input class="timePeeker" id="date" type="date">
                        <span class="between"> - </span>
                        <input class="timePeeker" id="date" type="date">
                    </div>

                </div>
            </div>


            <div class="listaRecados">
                
                  <asp:Literal ID="litrecados" runat="server"></asp:Literal>

            </div>

        </section>
    </section>
      
      
	</main>


    </form>
</body>
</html>
