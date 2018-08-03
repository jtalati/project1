<%@ Page Title="Results Page" EnableSessionState="True" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Results.aspx.vb" Inherits="GBATExcel.WebForm3" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/WebGbat/Content/bootstrap.css" rel="stylesheet" type="text/css" media="screen" runat="server" />
    <link href="/WebGbat/Content/TabbedGridView.css" rel="stylesheet" type="text/css" media="screen" runat="server" />
    <link href="/WebGbat/Content/Site.css" rel="stylesheet" type="text/css" media="screen" runat="server" />
    <div id="ResultsPage" style="width:100%;">
    <meta http-equiv='X-UA-Compatible' content='IE=edge,chrome=1'>
     

    <br />
    <br />
    <br />
    <br />
    <asp:ImageButton runat="server" ImageUrl="Images/Back.png" CssClass="no-border" ToolTip="Go Back" Id="BackImageButton" Height="35px" Width="36px" Style="margin-left:15px;"/>
    <p style="color:white;margin-left:15px;">Go Back One Page</p>

    <strong style="color:white; font:bold; margin-left:10%; margin-bottom:10px;">Choose Below:</strong><br />

    <asp:Button ID="DownloadExcelButton" runat="server" class="btn btn-primary" Text="Download Excel" Width="129px"  ForeColor="White" Style="margin-left:10%;" />

    <br />

    
    <br />


 
    
    <div id="columnControlButtons" >

        <asp:Button class="btn btn-primary" ID="previousColumns" runat="server" Text="Prev Columns" />
        <asp:Button class="btn btn-primary" ID="nextColumns" runat="server" Text="Next Columns"/>

    </div>

    <div style="overflow:hidden; width: 80%; height:400px; margin-left:10%;" onmouseover="this.style.overflow='scroll'" onmouseout="this.style.overflow='hidden'">
    <link href="..\Content\TabbedGridView.css" rel="stylesheet" type="text/css" />
    <table style="width:80%; text-align:center">
      <tr>
        <td>
          <asp:Button Text="Output" BorderStyle="None" ID="Tab1" CssClass="Initial" runat="server" style="float:left; margin-left:0px; border:solid 1px; border-color:black"
              OnClick="Tab1_Click" />
          <asp:Button Text="Errors" BorderStyle="None" ID="Tab2" CssClass="Initial" runat="server" style="float:left; margin-left:0px; border:solid 1px; border-color:black"
              OnClick="Tab2_Click" />          
           <asp:MultiView ID="MainView" runat="server">               
            <asp:View ID="View1" runat="server">
              <table class="results" style="width: 100%; margin-bottom:0px;">
                <tr>
                  <td>
                        <%--<asp:GridView ID="GridView1" AutoGenerateColumns="true" GridLines="Both" RowStyle-Width="150px" RowStyle-BorderWidth="0" runat="server" CellPadding="4" ForeColor="#333333"  OnPageIndexChanging="GridView1_PageIndexChanging" AllowPaging="True" PageSize="10">--%>
                        <asp:GridView ID="GridView1"  GridLines="Both" RowStyle-Width="150px" RowStyle-BorderWidth="0" runat="server" CellPadding="4" ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Left" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                  </td>
                </tr>
              </table>
            </asp:View>
            <asp:View ID="View2" runat="server">
              <table class="results" style="width: 100%; border-width: 1px; border-color: #666; border-style: solid">
                <tr>
                  <td>
                        <%--<asp:GridView ID="GridView2" AutoGenerateColumns="true" GridLines="Both" RowStyle-BorderWidth="0" runat="server" CellPadding="4" ForeColor="#333333"  OnPageIndexChanging="GridView2_PageIndexChanging" AllowPaging="True" PageSize="10">--%>
                        <asp:GridView ID="GridView2" AutoGenerateColumns="true" GridLines="Both" RowStyle-BorderWidth="0" runat="server" CellPadding="4" ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                  </td>
                </tr>
              </table>
            </asp:View>
                   
          </asp:MultiView>
         
        </td>
      </tr>
    </table>
    </div>
        
     <div class="next-previous-buttons">
        <asp:Button class="btn btn-primary" ID="prevButton" runat="server" Text="Prev Rows" />
        <asp:Button class="btn btn-primary" ID="nextButton" runat="server" Text="Next Rows" />
     </div>
   </div>

      
</asp:Content>
