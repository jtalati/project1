<%@ Page Title="Gridview Input Page" Language="vb" EnableSessionState="True" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="GridViewInputPage.aspx.vb" Inherits="GBATExcel.WebForm1" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>
    <link href="/WebGbat/Content/bootstrap.css" rel="stylesheet" type="text/css" media="screen" runat="server" />
    <link href="/WebGbat/Content/Site.css" rel="stylesheet" type="text/css" media="screen" runat="server" />
    <script type="text/javascript">

        function scrollToRow(pixels) {
            $(MainContent_infoContainer)[0].scrollTop = pixels
        }

            function ShowProgress() {
                setTimeout(function () {
        var modal = $('<div />'); 
        modal.addClass("modal");
        $('body').append(modal);
        var loading = $(".loading");
        loading.show();
        var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
        var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
        loading.css({ top: top, left: left });
                }, 200);
    }


        </script>
    <div id="GridViewPage" style="height:100%; width:100%;">
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:ImageButton runat="server" ImageUrl="Images/Back.png" CssClass="no-border" ToolTip="Go Back" Id="BackImageButton" Height="35px" Width="36px" Style="margin-left: 10px;"/>
    <p style="color:white;margin-left: 14px;font-weight:bold; font-size:20px;color:black">Go Back One Page</p> 
    <br />
    <br />
    
    <div id="labeldiv">
        <asp:Label ID="label1" runat="server" style="margin-left:16px; color:black; font-weight: bold; font-size: 16px;"></asp:Label>
    </div>
    <div id="infoContainer" style="overflow:scroll; height: 520px; width: 80%; margin-top: 23px; margin-left: 10%; background-color:rgba(0, 0, 0, 0.80)" runat="server"  MaintainScrollPositionOnPostback="true">
        <style>
            .fixedColWidth > tr > td,
            .fixedColWidth > tbody > tr > td,
            .fixedColWidth > thead > tr > td,
            .fixedColWidth > tfoot > tr > td
            {
                min-width: 150px;
                max-width: 150px;
            }
        </style>
        
<asp:Panel runat="server" Width="4075px" style="margin-top:15px; margin-left:15px;" MaintainScrollPositionOnPostback="true">

        <asp:DropDownList ID="DropDownList0" runat="server" Width="150px" style="padding:0" Visible="False">
        </asp:DropDownList><asp:DropDownList ID="DropDownList1" runat="server" Width="150px"  style="padding:0" Visible="False">
        </asp:DropDownList><asp:DropDownList ID="DropDownList2" runat="server" Width="150px"  style="padding:0" Visible="False">
        </asp:DropDownList><asp:DropDownList ID="DropDownList3" runat="server" Width="150px"  style="padding:0" Visible="False">
        </asp:DropDownList><asp:DropDownList ID="DropDownList4" runat="server" Width="150px" style="padding:0" Visible="False">
        </asp:DropDownList><asp:DropDownList ID="DropDownList5" runat="server" Width="150px" style="padding:0" Visible="False">
        </asp:DropDownList><asp:DropDownList ID="DropDownList6" runat="server" Width="150px" style="padding:0" Visible="False">
        </asp:DropDownList><asp:DropDownList ID="DropDownList7" runat="server" Width="150px" style="padding:0" Visible="False">
        </asp:DropDownList><asp:DropDownList ID="DropDownList8" runat="server" Width="150px" style="padding:0" Visible="False">
        </asp:DropDownList><asp:DropDownList ID="DropDownList9" runat="server" Width="150px" style="padding:0" Visible="False">
        </asp:DropDownList><asp:DropDownList ID="DropDownList10" runat="server" Width="150px" style="padding:0" Visible="False">
        </asp:DropDownList><asp:DropDownList ID="DropDownList11" runat="server" Width="150px" style="padding:0" Visible="False">
        </asp:DropDownList><asp:DropDownList ID="DropDownList12" runat="server" Width="150px" style="padding:0" Visible="False">
        </asp:DropDownList><asp:DropDownList ID="DropDownList13" runat="server" Width="150px" style="padding:0" Visible="False">
        </asp:DropDownList><asp:DropDownList ID="DropDownList14" runat="server" Width="150px" style="padding:0" Visible="False">
        </asp:DropDownList><asp:DropDownList ID="DropDownList15" runat="server" Width="150px" style="padding:0" Visible="False">
        </asp:DropDownList><asp:DropDownList ID="DropDownList16" runat="server" Width="150px" style="padding:0" Visible="False">
        </asp:DropDownList><asp:DropDownList ID="DropDownList17" runat="server" Width="150px" style="padding:0" Visible="False">
        </asp:DropDownList><asp:DropDownList ID="DropDownList18" runat="server" Width="150px" style="padding:0" Visible="False">
        </asp:DropDownList><asp:DropDownList ID="DropDownList19" runat="server" Width="150px" style="padding:0" Visible="False">
        </asp:DropDownList><asp:DropDownList ID="DropDownList20" runat="server" Width="150px" style="padding:0" Visible="False">
        </asp:DropDownList><asp:DropDownList ID="DropDownList21" runat="server" Width="150px" style="padding:0" Visible="False">
        </asp:DropDownList><asp:DropDownList ID="DropDownList22" runat="server" Width="150px" style="padding:0" Visible="False">
        </asp:DropDownList><asp:DropDownList ID="DropDownList23" runat="server" Width="150px" style="padding:0" Visible="False">
        </asp:DropDownList><asp:DropDownList ID="DropDownList24" runat="server" Width="150px" style="padding:0" Visible="False">
        </asp:DropDownList><asp:DropDownList ID="DropDownList25" runat="server" Width="150px" style="padding:0" Visible="False">
        </asp:DropDownList><asp:DropDownList ID="DropDownList26" runat="server" Width="150px" style="padding:0" Visible="False">
        
        </asp:DropDownList>
<asp:GridView ID="GridView1" runat="server" CssClass="fixedColWidth" CellPadding="0" ForeColor="#333333" Height="273px" AutoGenerateEditButton="True"  OnRowEditing="GridView1_RowEditing"         
        OnRowCancelingEdit="GridView1_RowCancelingEdit" 
        OnRowUpdating="GridView1_RowUpdating"
        OnPageIndexChanging="GridView1_PageIndexChanging" AllowPaging="True" PageSize="1250" MaintainScrollPositionOnPostback="true">
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
<br />

</asp:Panel>
        </div> 
    <br />
    <br />

            <div class="loading" style="text-align:center;">
                   Loading...... Please Wait.<br />
                     <br />
                      <img src="Images/Preloader_8.gif" style="height:100px; width:100px;" />
             </div>
        <div>
            <asp:Button ID="InputPageSubmitButton" class="btn btn-primary" runat="server" Text="Next" Width="101px" Font-Bold="True" Font-Size="Medium" ForeColor="White" style="margin-left:45%;margin-bottom:30px;" OnClientClick="ShowProgress()" />
            <asp:Button ID="SkipErrorsButton" class="btn btn-primary" runat="server" Text="Skip Errors" Width="111px" Font-Bold="True" Font-Size="Medium" ForeColor="White" style="margin-bottom:30px;" Visible="False" OnClientClick="ShowProgress()"/>
        </div>
        </div>
</asp:Content>