<%@ Page Title="Output Select Page" Language="vb" EnableSessionState="True" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="OutputSelectPage.aspx.vb" Inherits="GBATExcel.WebForm2" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <!DOCTYPE html>
    <link href="/WebGbat/Content/bootstrap.css" rel="stylesheet" type="text/css" media="screen" runat="server" />
    <link href="/WebGbat/Content/Site.css" rel="stylesheet" type="text/css" media="screen" runat="server" />
    <div id="OutputSelectPage" style="width:100%;">
<br />
<br />
<br />
<br />

        <script type="text/javascript">
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
    <div class="row">
        <div class="col-md-12" style="text-align:left">
            <asp:ImageButton runat="server" ImageUrl="Images/Back.png" CssClass="no-border" ToolTip="Go Back" Id="BackImageButton" Height="35px" Width="36px" Style="margin-left: 15px;"/>
            <p style="color:white;margin-left: 19px;font-weight:bold;">Go Back One Page</p>
        </div>
    </div>

<br />
    <div class="row">
        <div class="col-md-12" style="text-align:left; margin-left:25%">
            <strong style="color: white; font-size:medium;">*Add items below from one listbox to another. Then Press Submit at the bottom of the page for Results.</strong>
        </div> 
    </div>

    <p>
      <%--<asp:Button ID="HideShowButton5" data-toggle="collapse" data-target="#row1" runat="server" Text="Button" style="width: 30px;" Font-Bold="True" onclientclick="return false;"/>--%>
        <asp:Button ID="HideShowButton5" runat="server" class="btn btn-info btn-sm"  Text="" style="width: 30px; margin-left:30%;" Font-Bold="True"/>
    </p>
<div class="collapse in row" style="height:250px;text-align:center; margin-top: -10px" id="row1" runat="server">
<%--    <br />--%>
    <asp:Label ID="Label6" runat="server" Text="Excel Inputs" ForeColor="Black" class="row-title"></asp:Label>
    <br />
    
   <div class="col-md-1"></div>
   <div class="col-md-1"></div>
   <div class="col-md-3">
       <asp:ListBox ID="lbxUserUploadedIn" runat="server" style="height: 171px; width: 250px;"></asp:ListBox><br />
       <asp:CheckBox ID="CheckBox1" runat="server" ForeColor="White" Text="INCLUDE NORMALIZED INPUTS" style="width: 232px;" Font-Bold="True" Font-Overline="False" Font-Size="Small" Font-Strikeout="False"/>
   </div>
   <div class="col-md-1"  style="margin-top:17px;">
      <asp:Button ID="AddOneButton5" runat="server" Text="&gt;" style="width:33px;margin-bottom:2px"/><br />
      <asp:Button ID="RemoveOneButton5" runat="server" Text="&lt;" style="width:33px;margin-bottom:20px"/><br />

      <asp:Button ID="AddAllButton3" runat="server" Text="&gt;&gt;" style="width:33px;margin-bottom:2px"/><br />

      <asp:Button ID="RemoveAllButton3" runat="server" Text="&lt;&lt;" style="width:33px;"/><br />
   </div>
   <div class="col-md-3">
       <asp:ListBox ID="lbxOut0" runat="server" style="height: 171px; width: 250px;" SelectionMode="Multiple"></asp:ListBox>
   </div>
   <div class="col-md-1"> </div>
   <div class="col-md-2">
   </div>
     
</div><br />

   


 <p>  
<%--<asp:Button ID="HideShowButton1" runat="server" class="btn btn-info" data-toggle="collapse" data-target="#row2" Text="Button" style="width: 30px;" Font-Bold="True" onclientclick="return false;" />--%>
     <asp:Button ID="HideShowButton1" runat="server" class="btn btn-info btn-sm" Text="" style="width: 30px; margin-left:30%;" Font-Bold="True" />
   </p>


<div style="height:250px;text-align:center;"  class="collapse in row" id="row2" runat="server">
     <asp:Label ID="Label1" runat="server" Text="Excel Inputs" ForeColor="Black" class="row-title"></asp:Label>
    <br />
   <div class="col-md-1"></div>
   <div class="col-md-1"></div>
   <div class="col-md-3">
       <asp:ListBox ID="ListBox1" runat="server" style="height: 171px; width: 250px;" SelectionMode="Multiple"></asp:ListBox>
   </div>
   <div class="col-md-1" style="margin-top:17px;">
      <asp:Button ID="AddOneButton0" runat="server" Text="&gt;" style="width:33px;margin-bottom:2px;"/><br />
      <asp:Button ID="RemoveOneButton0" runat="server" Text="&lt;" style="width:33px;margin-bottom:20px"/><br />

      <asp:Button ID="AddAllButton" runat="server" Text="&gt;&gt;" style="width:33px;margin-bottom:2px"/><br />

      <asp:Button ID="RemoveAllButton0" runat="server" Text="&lt;&lt;" style="width:33px;"/><br />
   </div>
   <div class="col-md-3">
       <asp:ListBox ID="lbxOut1" runat="server" style="height: 171px; width: 250px;" SelectionMode="Multiple"></asp:ListBox>
   </div>
   <div class="col-md-1"> </div>
   <div class="col-md-2"></div><br />
</div><br />
   
  <p>
 <%--<asp:Button ID="HideShowButton2" runat="server" class="btn btn-info" data-toggle="collapse" data-target="#row3" Text="Button" onclientclick="return false;" style="width: 30px;" Font-Bold="True" />--%>
    <asp:Button ID="HideShowButton2" runat="server" class="btn btn-info btn-sm" Text="" style="width: 30px;  margin-left:30%;" Font-Bold="True" />
      </p>
<div class="collapse in row" style="height:250px;text-align:center;" id="row3" runat="server">

    <%-- ISSUE HERE --%>
      <asp:Label ID="Label2" runat="server" Text="Inputs" ForeColor="Black" class="row-title"></asp:Label>
    <%-- ********** --%>
    <br />
   <div class="col-md-1"></div>
   <div class="col-md-1"></div>
   <div class="col-md-3">
       <asp:ListBox ID="ListBox3" runat="server" style="height: 171px; width: 250px;" SelectionMode="Multiple" ></asp:ListBox>
   </div>
   <div class="col-md-1" style="margin-top:17px;">
      <asp:Button ID="AddOneButton2" runat="server" Text="&gt;" style="width:33px;margin-bottom:2px;"/><br />
      <asp:Button ID="RemoveOneButton3" runat="server" Text="&lt;" style="width:33px;margin-bottom:20px"/><br />

      <asp:Button ID="AddAllButton1" runat="server" Text="&gt;&gt;" style="width:33px;margin-bottom:2px"/><br />

      <asp:Button ID="RemoveAllButton" runat="server" Text="&lt;&lt;" style="width:33px;"/><br />
   </div>
   <div class="col-md-3">
       <asp:ListBox ID="lbxOut2" runat="server" style="height: 171px; width: 250px;" SelectionMode="Multiple"></asp:ListBox>
   </div>
   <div class="col-md-1"> </div>
   <div class="col-md-2"></div>
</div><br />


<%--<asp:Button ID="HideShowButton3" runat="server" class="btn btn-info" data-toggle="collapse" data-target="#row4" Text="Button" style="width: 30px;" Font-Bold="True" onclientclick="return false;" />--%>
    <p>
    <asp:Button ID="HideShowButton3" runat="server" class="btn btn-info btn-sm" Text="" style="width: 30px; margin-left:30%;" Font-Bold="True" />
    </p>
<div class="collapse in row" style="height:250px;text-align:center;" id="row4" runat="server">
        <asp:Label ID="Label3" runat="server" Text="Excel Inputs" class="row-title" ForeColor="Black"></asp:Label>
     <br />
   <div class="col-md-1"></div>
   <div class="col-md-1"></div>
   <div class="col-md-3">
       <asp:ListBox ID="ListBox5" runat="server" style="height: 171px; width: 250px;" SelectionMode="Multiple"></asp:ListBox>
   </div>
   <div class="col-md-1"  style="margin-top:17px;">
      <asp:Button ID="AddOneButton4" runat="server" Text="&gt;" style="width:33px;margin-bottom:2px;"/><br />
      <asp:Button ID="RemoveOneButton2" runat="server" Text="&lt;" style="width:33px;margin-bottom:20px"/><br />

      <asp:Button ID="AddAllButton2" runat="server" Text="&gt;&gt;" style="width:33px;margin-bottom:2px"/><br />

      <asp:Button ID="RemoveAllButton1" runat="server" Text="&lt;&lt;" style="width:33px;"/><br />
   </div>
   <div class="col-md-3">
       <asp:ListBox ID="lbxOut3" runat="server" style="height: 171px; width: 250px;" SelectionMode="Multiple"></asp:ListBox>
   </div>
   <div class="col-md-1"> </div>
   <div class="col-md-2"></div><br />
</div><br />

   <p>
<%--<asp:Button ID="HideShowButton4" runat="server" class="btn btn-info" data-toggle="collapse" data-target="#row5" Text="Button" style="width: 30px;" Font-Bold="True" onclientclick="return false;" />--%>
   <asp:Button ID="HideShowButton4" runat="server" class="btn btn-info btn-sm" Text="" style="width: 30px; margin-left:30%;" Font-Bold="True" />
   </p>

<div class="collapse in row" style="height:250px;text-align:center;" id="row5" runat="server">
      <asp:Label ID="Label4" runat="server" Text="Excel Inputs" class="row-title" ForeColor="Black"></asp:Label>
    <br />
   <div class="col-md-1"></div>
   <div class="col-md-1"></div>
   <div class="col-md-3">
       <asp:ListBox ID="ListBox7" runat="server" style="height: 171px; width: 250px;" SelectionMode="Multiple"></asp:ListBox>
   </div>
   <div class="col-md-1"  style="margin-top:17px;">
      <asp:Button ID="AddOneButton3" runat="server" Text="&gt;" style="width:33px;margin-bottom:2px;"/><br />
      <asp:Button ID="RemoveOneButton4" runat="server" Text="&lt;" style="width:33px;margin-bottom:20px"/><br />

      <asp:Button ID="AddAllButton0" runat="server" Text="&gt;&gt;" style="width:33px;margin-bottom:2px"/><br />

      <asp:Button ID="RemoveAllButton2" runat="server" Text="&lt;&lt;" style="width:33px;"/><br />
   </div>
   <div class="col-md-3">
       <asp:ListBox ID="lbxOut4" runat="server" style="height: 171px; width: 250px;" SelectionMode="Multiple"></asp:ListBox>
   </div>
   <div class="col-md-1"> </div>
   <div class="col-md-2"></div><br />
</div>

        <div class="loading" style="text-align:center;">
                   Processing...... Please Wait.<br />
                <br />
                    <img src="Images/Preloader_8.gif" style="height:100px; width:100px;" />
             </div>

    <div class="row">
    <div class="col-md-12" style="text-align:center;">
        <%--<asp:Button ID="SubmitButton" runat="server" style="margin-right: 3cm;" Text="SUBMIT" BackColor="#666666" Font-Bold="True" ForeColor="White" />--%>
         <asp:Button class="btn btn-primary" ID="SubmitButton" runat="server" Text="Submit" Width="111px" Font-Bold="True" Font-Size="Medium" ForeColor="White" style="margin-bottom:30px;" OnClientClick="ShowProgress()" />
    </div>
    </div>
        </div>
</asp:Content>
