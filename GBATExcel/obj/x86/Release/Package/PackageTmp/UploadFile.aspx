<%@ Page Title="Home Page" EnableSessionState="True" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UploadFile.aspx.vb" Inherits="GBATExcel._Default" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/WebGbat/Content/bootstrap.css" rel="stylesheet" type="text/css" media="screen" runat="server" />
    <link href="/WebGbat/Content/Site.css" rel="stylesheet" type="text/css" media="screen" runat="server" />
    <script src="/WebGbat/extern/JavaScript.js"></script>
    <br />
    <br />

    <style>
        #HomePage{
            background: url('Images/EquitableLifeBuilding.jpg') no-repeat center center fixed;
            background-size: cover;
        }
        #opaquetd:hover{
            opacity:0.96;
        }
        #function-box:hover{
            opacity:0.96;
        }
        #auto-style1:hover{
            opacity:0.96;
        }
        .heroText {
            max-width:320px;
            width:100%;
            top:0;
            left:0;
            height:100%;
            background: rgb(26, 93, 161);
            background:rgba(26, 93, 161, 0.85);
            color:white!important;
            padding:16px;
            box-shadow: 2px 0px 5px rgba(0,0,0,0.5);
        }
        .heroText p{
            font-size:15px;
        }
        .auto-style1 {
            width: 103px;
        }
    </style>
        <div id="HomePage" style="height:100%; width:100%;">
            <div class="heroText">
                <h3><br /><br />Welcome To <span style="color:#F54347">WebGBAT</span></h3>
                <br />
                <p class="GoatHeader">
                    
                  WebGBAT allows you to upload an excel 
                   spreadsheet with New York City geographic 
                     location such as an address, intersection, 
                     street segment, street stretch, block and lot 
                    or BIN and select a Function in order to 
                     obtain related geographic information, such 
                    as cross streets, side of street, tax block and 
                    lot (AKA Parcel - ID), five-digit ZIP code, 
                   census tract and block, police precinct, 
                    community district and city council district.
                    Information on the functions can be found in the <a href="userguide.aspx" style="color:#F54347">WebGBAT User Guide.</a>
                    Click on the output field label for its definition in the <a href="glossary.aspx" style="color:#F54347">Glossary.</a>
                </p>
             </div>
       
             <br />
             <br />
            
             <table id="functiontable-box" border="0" style="text-align:center; margin:auto;" visible="true">
                 <tr>
                 <td id="function-box" style="text-align:center; vertical-align:top; margin-right: 0px; background-color: #C0C0C0; border-collapse:separate;">
                <span class="label label-default" style="border-style:none; border-color: black; font-size:110%; color:black;">Step 1: Choose a Function Below: </span> 
                 <br />
                 <br />
                        <%--RadioButtons --%>
                 <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Font-Size="Smaller" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Selected="True" Value="1A" Text="Address<br>(Function 1A)"></asp:ListItem>
                        <asp:ListItem  Value="1B" Text="Address<br>(Function 1B)"></asp:ListItem>
                        <asp:ListItem Value="1E" Text="Address<br>(Function 1E)"></asp:ListItem>
                        <asp:ListItem Value="AP" Text="Address Point<br>(Function AP)"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Intersection<br>(Function 2)"></asp:ListItem>
                        <asp:ListItem Value="3" Text="Street Segment<br>(Function 3)"></asp:ListItem>
                        <asp:ListItem Value="3S" Text="Street Stretch<br>(Function 3S)"></asp:ListItem>
                        <asp:ListItem Value="BL" Text="Block & Lot<br>(Function BL)"></asp:ListItem>
                        <asp:ListItem Value="BN" Text="BIN<br>(Function BN)"></asp:ListItem>
                        <asp:ListItem Value="Name/Code" Text="Street<br>(Name/Code)"></asp:ListItem>
                 </asp:RadioButtonList>
                    <br />
               
                     <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal" style="text-align:left; margin:auto;" Visible="true">
                         <asp:ListItem>Roadbed Specific Information</asp:ListItem>
     
                    </asp:CheckBoxList>

                     <asp:CheckBoxList ID="CheckBoxList2" runat="server" RepeatDirection="Horizontal" style="text-align:right; margin:auto;" Visible="true">
                         <%--<asp:ListItem Selected="True">TPAD</asp:ListItem>--%>
                    </asp:CheckBoxList>

                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal" Visible="false" Font-Size="Smaller" style="text-align:center; margin:auto;">
                        <asp:ListItem Selected="True" Value="1N" Text="Convert Street Name to Street Code<br>(Function 1N)"></asp:ListItem>
                        <asp:ListItem Value="D" Text="Convert Street Code to Street Name<br>(Function D, DG, DN)"></asp:ListItem>
                        <asp:ListItem Value="N" Text="Normalize Input Street Name<br>(Function N)"></asp:ListItem>
                    </asp:RadioButtonList>
                </td> 
                </tr>
             </table>

           <table id="fileupload-box" border="0" style="text-align:center; margin:auto; border-collapse:separate;" visible="true">
             <tr>    
                 <td id="opaquetd" style="text-align:center; vertical-align:top; background-color:#C0C0C0;" >                      
                    <%-- Label Which asks to Upload a Spreadsheet --%>
                    <asp:Label ID="Label1" class="label label-default" runat="server" ForeColor="Black" Text="Step 2: Upload an Excel Spreadsheet:" style="font-size:110%;text-align:center;">
                    </asp:Label>
                    
                    <br />
                    <%-- Browse Button--%>
                    <br />
                    <asp:FileUpload ID="FileUpload1" runat="server" Height="28px"/>
                    <br />
                    <span style="font-size:75%; color:black;">*WebGBAT allows a Maximum of <strong>100,000</strong> Rows to be uploaded for all Functions except Function 3S. Maximum allowable upload size for Function 3s is <strong>1000</strong>.*</span>
                  
                    <%--Hidden Button which Uploads a file to a given path without the need to be clicked --%>
                    <asp:Button ID="Button1" Text="Upload" runat="server" Style="display: none"/>

                  </td>              
             </tr>
            </table>
            <table border="0" visible="true" style="text-align:center; margin:auto;" id="auto-style1">
                <tr>
                    <td style="vertical-align:top; Width:165px;">
                        <%--<asp:DropDownList ID="DropDownList1" runat="server" Visible="False">
                            <asp:ListItem Value="1N">Convert Street Name to Street Code (1N)</asp:ListItem>
                            <asp:ListItem Value="D,DG,DN">Convert Street Code to Street Name (D,DG,DN) </asp:ListItem>
                            <asp:ListItem Value="N*">Normalize Input Street Name (N*) </asp:ListItem>
                            <%--<asp:ListItem Value="BB,BF">Browse Street Name Dictionary (BB,BF) </asp:ListItem>--%>
                        <%--</asp:DropDownList>--%>
                    <br /><span class="label label-default" style="border-style:none; border-color: black; font-size:110%; color:black;">Step 3: Press Below Button to Submit</span><br />
                    <%-- Submit Button which opens the second page on click--%>
                     <br />
                        <div class="loading" style="text-align:center;">
                               Uploading...... Please Wait.<br />
                            <br />
                                <img src="Images/Preloader_8.gif" style="height:100px; width:100px;" />
                        </div>
                    <asp:Button ID="btnUpload" runat="server" Class="btn btn-primary" onclick="btnUpload_Click" style="margin-left: auto;margin-bottom:20px;" Text="NEXT" Width="96px" Height="33px" OnClientClick="ShowProgress()"/>
                    </td>
                 </tr>
            </table>

            <br />
            <br />
            <br />

        </div>

</asp:Content>