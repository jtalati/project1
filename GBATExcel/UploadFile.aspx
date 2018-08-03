<%@ Page Title="Home Page" EnableSessionState="True" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UploadFile.aspx.vb" Inherits="GBATExcel._Default" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="extern/JavaScript.js"></script>

<div id="HomePage">
            <div class="container-fluid b-section-bg bottom-5-border">
               <div class="banner text-center">
        <h3>Welcome To WebGBAT</h3>
        <p>
            WebGBAT allows you to upload an Excel spreadsheet with New York City geographic location such as an address, intersection, street segment, street stretch, block and lot or BIN and select a function in order to obtain related geographic information, such as cross streets, side of street, tax block and lot, five-digit ZIP code, census tract and block, police precinct, community district and city council district.
            Information on the functions can be found in the <a href="https://nycplanning.github.io/webGBATdocs/userguide/">WebGBAT User Guide</a>. Click on the output field label for its definition in the <a href="https://nycplanning.github.io/webGBATdocs/">Glossary</a>.
        </p>
    </div>
            </div>
   <div class="container-fluid">
     <div class="content" style="padding: 89px 0;">
        <div>
            <div class="row py-2" style="margin-top: -17px;">
                <div class="col-md-2 mb">
                    <div class="navigation-indicator">
                        <span>Step 1: </span> Choose a function
                    </div>
                </div>
                <div class="col-md-10">      
                 <asp:RadioButtonList CssClass="list-inline list-group select-items" ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Font-Size="Smaller" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Selected="True" Value="1A" Text="Address<br>(Function 1A)"></asp:ListItem>
                        <asp:ListItem Value="1B" Text="Address<br>(Function 1B)"></asp:ListItem>
                        <asp:ListItem Value="1E" Text="Address<br>(Function 1E)"></asp:ListItem>
                        <asp:ListItem Value="AP" Text="Address Point<br>(Function AP)"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Intersection<br>(Function 2)"></asp:ListItem>
                        <asp:ListItem Value="3" Text="Street Segment<br>(Function 3)"></asp:ListItem>
                        <asp:ListItem Value="3S" Text="Street Stretch<br>(Function 3S)"></asp:ListItem>
                        <asp:ListItem Value="BL" Text="Block & Lot<br>(Function BL)"></asp:ListItem>
                        <asp:ListItem Value="BN" Text="BIN<br>(Function BN)"></asp:ListItem>
                        <asp:ListItem Value="Name/Code" Text="Street<br>(Name/Code)"></asp:ListItem>
                 </asp:RadioButtonList>
                    <div class="check-box">
                        
                     <asp:CheckBoxList CssClass="test-CSS" ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal" Visible="true">
                         <asp:ListItem>Roadbed Specific Information</asp:ListItem>
                     </asp:CheckBoxList>

                     <asp:CheckBoxList ID="CheckBoxList2" runat="server" RepeatDirection="Horizontal" Visible="true">
                         <%--<asp:ListItem Selected="True">TPAD</asp:ListItem>--%>
                    </asp:CheckBoxList>
                        
                    </div>
                    
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" CssClass="select-items" RepeatDirection="Horizontal" Visible="false" Font-Size="Smaller" style="text-align:center;">
                        <asp:ListItem Selected="True" Value="1N" Text="Convert Street Name to Street Code<br>(Function 1N)"></asp:ListItem>
                        <asp:ListItem Value="D" Text="Convert Street Code to Street Name<br>(Function D, DG, DN)"></asp:ListItem>
                        <asp:ListItem Value="N" Text="Normalize Input Street Name<br>(Function N)"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="row py-2">
                <div class="col-md-2 mb">
                    <div class="navigation-indicator">
                        <span>Step 2: </span> Upload a Spreadsheet
                    </div>
                </div>
                <div class="col-md-10">
                    <%--<asp:FileUpload ID="FileUpload1" class="form-control upload-field" runat="server" Height="28px"/>--%>
                    <asp:FileUpload ID="FileUpload1" name="file-upload" runat="server" class="form-control upload-field" type="file" placeholder="Upload an Excel Spreadsheet" />
                    <%--<asp:Button ID="Button1" Text="Upload" runat="server" class="form-control upload-field" placeholder="Upload an Excel Spreadsheet"
                           name="file-upload" />--%>
                    <small class="text-mute">WebGBAT allows a Maximum of 100,000 rows to be uploaded for all funcations
                        except function 3S. Maximum allowable upload size for Funcation 3s is 1000.
                    </small>
                </div>
            </div>al 
            <div class="row py-2">
                <div class="col-md-2 mb">
                    <div class="navigation-indicator">
                        <span>Step 3: </span> Press Next Button
                    </div>
                </div>
                <br />
                        <div class="loading" style="text-align:center;">
                               Uploading...... Please Wait.<br />
                            <br />
                                <img src="Images/Preloader_8.gif" style="height:100px; width:100px;" />
                        </div>
                <div class="col-md-10" style="    margin-top: -15px;">
                    <asp:Button ID="btnUpload" runat="server" Class="btn btn-primary btn-lg" onclick="btnUpload_Click" Text="NEXT" OnClientClick="ShowProgress()"/>
                </div>
            </div>
        </div>
      </div>
   </div>

</div>
</asp:Content>