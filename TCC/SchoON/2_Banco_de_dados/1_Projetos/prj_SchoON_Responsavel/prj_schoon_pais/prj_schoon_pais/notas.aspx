<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="notas.aspx.cs" Inherits="prj_schoon_pais.notas" %>

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
  <asp:GridView ID="gvNotas" runat="server" 
         AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
         BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" 
         GridLines="Horizontal" onload="gvNotas_Load">
                <EmptyDataTemplate>
                    <div style="padding:10px">
                        Data not found!
                    </div>
                </EmptyDataTemplate>
                <Columns>
                    <asp:BoundField HeaderText="Nome Materia" DataField="nm_materia" />
                    <asp:BoundField HeaderText="Primeiro" DataField="primeiro_bi" />
                    <asp:BoundField HeaderText="Segundo Bimestre" DataField="segundo_bi" />
                    <asp:BoundField HeaderText="Terceiro Bimestre" DataField="terceiro_bi" />
                    <asp:BoundField HeaderText="Quarto Bimestre" DataField="quarto_bi" />
                    <asp:BoundField HeaderText="Aulas Totais" DataField="aulas_totais" />
                    <asp:BoundField HeaderText="Frequencia" DataField="freq_materia" />
                   
                </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>
    <asp:Label ID="lbl_faltas" runat="server" Text="Faltas"></asp:Label>
    <asp:Label ID="lbl_frequencia" runat="server" Text="Frequencia Total"></asp:Label>
    
    </form>
</body>
</html>
