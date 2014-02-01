<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Regis1.aspx.cs" Inherits="Regis1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="ASPTokenInputLib" Namespace="ASPTokenInputLib" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.5.1-vsdoc.js" type="text/javascript"></script>

    <script src="Scripts/jquery-1.5.1.min.js" type="text/javascript"></script>

    <script src="Scripts/jquery.tokeninput.js" type="text/javascript"></script>

    <script src="Scripts/json2.js" type="text/javascript"></script>

    <link href="globals/token-input-facebook.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function validInfo() {

            if (document.getElementById('TxtFirstname').value == "First name") {

                alert("Please Enter Your First Name"); return false;
            }
            if (document.getElementById('Txtlastname').value == "Last name") {

                alert("Please Enter Your Last Name"); return false;
            }
            if (document.getElementById('txtPwd').value == "Password") {
                alert("Please Enter Password"); return false;
              }
            if (document.getElementById('txtRePwd').value == "Re-type Password") {
                  alert("Please Enter Re-Type Password"); return false;
              }
            if (document.getElementById('TxtUniversity').value == "University") {
                alert("Please Enter University Name"); return false;
            }
            if (document.getElementById('TxtCourse').value == "Course") {
                alert("Please Enter Course Name"); return false;
            }
            if (document.getElementById('TxtYear').value == "Year") {
                alert("Please Enter Year"); return false;
            }
            if (document.getElementById('TxtLocation').value == "Location") {
                alert("Please Enter Location"); return false;
            }
            //if (document.getElementById('TxtSuaveid').value == "S(u)ave ID") {
            //    alert("Please Enter Suave Id"); return false;
            //}
           
            return true;
        }

    </script>
    <script type="text/javascript">
        function myFunction() {

            var pass1 = document.getElementById("txtPwd").value;
            var pass2 = document.getElementById("txtRePwd").value;
            var ok = true;
            if (pass1 != pass2) {
                alert("Passwords Do not match");
              
                    setTimeout(function () {
                        document.getElementById("txtRePwd").focus();
                    }, 0);
                  
                document.getElementById("pass1").style.borderColor = "#E34234";
                document.getElementById("pass2").style.borderColor = "#E34234";
                ok = false;
            }
            else {
              
            }
            return ok;
        }
    </script>
    <script type="text/javascript">
        function CheckPassword(password) {

            var strength = new Array();
            strength[0] = "Blank";
            strength[1] = "Very Weak";
            strength[2] = "Weak";
            strength[3] = "Medium";
            strength[4] = "Strong";
            strength[5] = "Very Strong";
            var score = 1;
            if (password.length < 1)
                return strength[0];
            if (password.length < 4)
                return strength[1];
            if (password.length >= 8)
                score++;
            if (password.length >= 10)
                score++;
            if (password.match(/\d+/))
                score++;
            if (password.match(/[a-z]/) &&
            password.match(/[A-Z]/))
                score++;
            if (password.match(/.[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]/))
                score++;
            return strength[score];

        }

        function PasswordChanged(field) {

            var span = document.getElementById("txtPwd");
           
            document.getElementById("<% =Hiddpass.ClientID %>").value = field.value;
            span.innerHTML = CheckPassword(field.value);
            
        }

        function ButtonClicked(field) {

            var strength = document.getElementById("txtPwd").innerHTML;
           
            if (strength.indexOf("Strong") < 0)
            {

                document.getElementById("LblPass").textContent = strength;
                return false;
            }
            else {
                document.getElementById("LblPass").textContent = "";
            }
        }
    </script>
    
    <script type="text/javascript">
        function ValidateEmail(x) {
           
            var EmailExp = /^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9]*[a-zA-Z0-9]\.[\w\.-][ac]\.[\w\.-][uk]$/;
            if (x.value.match(EmailExp)) {
                document.getElementById("Lblemail").textContent = "";
                return true;
            }
            else {
                document.getElementById("Lblemail").textContent = "Invalid Email ID";
                // x.value = "";
                // x.focus();
                return false;
            }
           
        }
        function Lblvalue() {
           if (document.getElementById('Lblemail').textContent == "" && document.getElementById('TxtEmailid').textContent != "University email ending with .ac.uk") {
                
                return true;
            }
            else {
               
                return false;
            }
        }
    </script>
    <script type="text/javascript">
        function WaterMark(objtxt, event) {
            var defaultpwdText = "Password";
            // Condition to check textbox length and event type
            if (objtxt.id == "txtPwd") {
               var abc= document.getElementById("<%= txtPwd.ClientID %>").value;
                if (abc.length < 6) {
                    alert("Password should contain atleast 6 characters");
                setTimeout(function () {
                    document.getElementById("txtPwd").focus();
                }, 0);
                }
                if (objtxt.value.length == 0 & event.type == "blur") {
                    if (objtxt.id == "txtPwd") {
                        document.getElementById("<%= txtTempPwd.ClientID %>").style.display = "block";
                        objtxt.style.display = "none";

                    }
                   }
            } 
            
          // Condition to check textbox value and event type
          if ((objtxt.value == defaultpwdText) & event.type == "focus") {
             
              if (objtxt.id == "txtTempPwd") {

                  objtxt.style.display = "none";
                  document.getElementById("<%= txtPwd.ClientID %>").style.display = "";
                 document.getElementById("<%= txtPwd.ClientID %>").focus();

              }
             
          }
           
      }
      function WaterMarkre(objtxt, event) {
          var defaultpwdText = "Re-type Password";
          // Condition to check textbox length and event type
          if (objtxt.id == "txtRePwd") {
              if (objtxt.value.length == 0 & event.type == "blur") {

                  if (objtxt.id == "txtRePwd") {
                      document.getElementById("<%= txtTempRePwd.ClientID %>").style.display = "block";
                          objtxt.style.display = "none";
                  }
                
              }
             
              }
              // Condition to check textbox value and event type
              if ((objtxt.value == defaultpwdText) & event.type == "focus") {

                  if (objtxt.id == "txtTempRePwd") {
                      objtxt.style.display = "none";
                      document.getElementById("<%= txtRePwd.ClientID %>").style.display = "";
                  document.getElementById("<%= txtRePwd.ClientID %>").focus();
              }
              }
         
      }


    </script>
    
    <style type="text/css">
        .Corners {
            border: 1px solid #DDDDDD;
            padding: 5px;
            background: #ffffff;
            -moz-border-radius: 8px;
            border-radius: 8px;
            -webkit-border-radius: 8px;
            text-align: center;
        }


        .Button {
            background-color: black;
            font: bold;
            color: white;
            border: 1px solid;
            border-radius: 10px;
        }

        .Watermark {
            text-align: center;
            border: 1px solid #DDDDDD;
            height: 15px;
            width: 200px;
            padding: 5px;
            background: #ffffff;
            -moz-border-radius: 8px;
            border-radius: 8px;
            -webkit-border-radius: 8px;
        }

        .div {
            border: 1px solid #DDDDDD;
            padding: 5px;
            background: #ffffff;
            -moz-border-radius: 8px;
            border-radius: 8px;
            -webkit-border-radius: 8px;
        }
       
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
        <div>
            <asp:Panel ID="Panel1" runat="server" Width="100%" Height="300px" BackColor="#efc11b">
                <table style="width: 100%">

                    <tr>
                        <td style="padding-left: 300px; padding-top: 85px; width:375px">
                            <asp:TextBox ID="TxtEmailid" runat="server" Height="35px" Width="250px" CssClass="Corners" onblur="ValidateEmail(this)"></asp:TextBox>
                            <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkEmail" runat="server" TargetControlID="TxtEmailid"
                                WatermarkText="University email ending with .ac.uk" WatermarkCssClass="Watermark">
                            </asp:TextBoxWatermarkExtender>

                            <asp:Label ID="Lblemail" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </td>
                        <td style="padding-top:85px">
                            <asp:Button ID="BtnGetcode" runat="server" Text="Get Code" Width="80px" Height="40px" 
                         OnClientClick="return Lblvalue()"  CssClass="Button" OnClick="BtnGetcode_Click" />
                        </td>
                    </tr>

                    <tr>
                        <td style="padding-left: 335px; padding-top: 35px" colspan="2">
                            <asp:TextBox ID="TxtEmailcode" runat="server" Height="35px" Width="180px" CssClass="Corners"></asp:TextBox>
                            <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkCode" runat="server" TargetControlID="TxtEmailcode"
                                WatermarkText="Insert code from your email" WatermarkCssClass="Watermark">
                            </asp:TextBoxWatermarkExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 400px; padding-top: 15px" colspan="2">
                            <asp:Button ID="BtnNext" runat="server" Text="Next" Width="70px" Height="40px" OnClick="BtnNext_Click" CssClass="Button" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server" Width="100%" Height="500px" BackColor="#efc11b" style="display:none">
                <table style="width: 100%; text-align: center">
                    <tr>
                        <td style="padding-top: 70px; padding-left:70px">
                            <asp:TextBox ID="TxtFirstname" runat="server" Height="45px" Width="150px" CssClass="Corners" AutoPostBack="true" OnTextChanged="TxtFirstname_TextChanged" MaxLength="15"></asp:TextBox>
                            <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkFullname" runat="server" TargetControlID="TxtFirstname"
                                WatermarkText="First name" WatermarkCssClass="Watermark">
                            </asp:TextBoxWatermarkExtender>
                        </td>
                        <td style="padding-top: 70px">
                            <asp:TextBox ID="Txtlastname" runat="server" Height="45px" Width="150px" CssClass="Corners" MaxLength="15"></asp:TextBox>
                            <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkLastname" runat="server" TargetControlID="Txtlastname"
                                WatermarkText="Last name" WatermarkCssClass="Watermark">
                            </asp:TextBoxWatermarkExtender>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="4" style="padding-top:10px; text-align:center">
                            <asp:HiddenField ID="Hiddpass" runat="server" />
                            <asp:TextBox ID="txtTempPwd" Text="Password" runat="server" onfocus="WaterMark(this, event);" Width="200px" Height="45px" CssClass="Corners" />
                            <asp:TextBox ID="txtPwd" TextMode="Password" Text="Password" runat="server" Width="200px" Height="45px" CssClass="Corners" Style="display: none" onblur="WaterMark(this, event);" onchange="PasswordChanged(this); return ButtonClicked()" />
                           <asp:Label ID="LblPass" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </td>
                      
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align:center">
                            <asp:Label ID="Label1" runat="server" Text="(Atleast 6 characters)" ForeColor="Red" Font-Size="Small"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align:center">

                            <asp:TextBox ID="txtTempRePwd" Text="Re-type Password" runat="server" onfocus="WaterMarkre(this, event);" Width="200px" Height="45px" CssClass="Corners" />
                            <asp:TextBox ID="txtRePwd" TextMode="Password" Text="Re-type Password" runat="server" Width="200px" Height="45px" CssClass="Corners" Style="display: none" onblur="WaterMarkre(this, event);" />
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top:10px;padding-left:70px">
                            <asp:TextBox ID="TxtUniversity" runat="server" Height="45px" Width="200px" Enabled="false" CssClass="Corners" Text="Kings College"></asp:TextBox>

                        </td>
                        <td style="padding-top:10px">
                            <asp:TextBox ID="TxtCourse" runat="server" Height="45px" Width="160px" CssClass="Corners"></asp:TextBox>
                            <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkCourse" runat="server" TargetControlID="TxtCourse"
                                WatermarkText="Course" WatermarkCssClass="Watermark">
                            </asp:TextBoxWatermarkExtender>
                        </td>
                        <td style="padding-top:10px">
                            <asp:DropDownList ID="DdlYear" runat="server" Height="45px" Width="140px" CssClass="Corners">
                                <asp:ListItem>-Select-</asp:ListItem>
                                <asp:ListItem>2002</asp:ListItem>
                                <asp:ListItem>2003</asp:ListItem>
                                <asp:ListItem>2004</asp:ListItem>
                                <asp:ListItem>2005</asp:ListItem>
                                <asp:ListItem>2006</asp:ListItem>
                                <asp:ListItem>2007</asp:ListItem>
                                <asp:ListItem>2008</asp:ListItem>
                                <asp:ListItem>2009</asp:ListItem>
                                <asp:ListItem>2010</asp:ListItem>
                                <asp:ListItem>2011</asp:ListItem>
                                <asp:ListItem>2012</asp:ListItem>
                                <asp:ListItem>2013</asp:ListItem>
                                <asp:ListItem>2014</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="padding-top:10px">
                            <asp:TextBox ID="TxtLocation" runat="server" Height="45px" Width="160px" Enabled="false" CssClass="Corners" Text="London"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="padding-top:10px">
                             <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                            <asp:TextBox ID="TxtSuaveid" runat="server" Height="45px" Width="200px" CssClass="Corners"></asp:TextBox>
                            <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkSuave" runat="server" TargetControlID="TxtSuaveid"
                                WatermarkText="S(u)ave ID" WatermarkCssClass="Watermark">
                            </asp:TextBoxWatermarkExtender>
                           
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Button ID="BtnNext2" runat="server" Text="Next" OnClientClick="return validInfo()" Width="70px" Height="45px" OnClick="BtnNext2_Click"
                                CssClass="Button" />

                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="Panel3" runat="server" Width="100%" BackColor="#efc11b" Style="display: none" Height="450px">
                <table style="width: 100%">
                    <tr>
                        <td style="padding-top: 50px; padding-left: 70px; width:65%">
                            <div style="background-color: white" class="div">

                                <table style="width: 100%; padding-left: 20px">
                                    <tr>
                                        <td>

                                            <asp:TextBox ID="LblFLName" runat="server" Font-Bold="True" Font-Size="X-Large" BorderStyle="None" MaxLength="31"></asp:TextBox>
                                           <%-- <asp:TextBox ID="LblLastname" runat="server" Font-Bold="True" Font-Size="X-Large" BorderStyle="None" Width="150px"></asp:TextBox>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LblSuaveid" runat="server" Text="" Font-Bold="True"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LblEmailId" runat="server" Text="" Font-Bold="True"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TxtAbout" runat="server" BorderStyle="None" Font-Bold="True" Width="260px" MaxLength="200" TextMode="MultiLine" CssClass="textboxmultiline"></asp:TextBox>
                                            <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkAbout" runat="server" TargetControlID="TxtAbout" WatermarkText="Write a bit about yourself..."></asp:TextBoxWatermarkExtender>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="padding-top: 25px">
                                            <asp:Label ID="LblUni" runat="server" Text="" Font-Bold="True"></asp:Label>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>

                                            <asp:TextBox ID="LblCourse" runat="server" Font-Bold="True" BorderStyle="None"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>

                                            <asp:TextBox ID="LblYear" runat="server" Font-Bold="True" BorderStyle="None" Width="60px"></asp:TextBox>,
            
                                          <asp:Label ID="LblCity" runat="server" Text="" Font-Bold="True"></asp:Label></td>
                                    </tr>
                                </table>


                            </div>
                        </td>
                        <td style="padding-top: 50px; padding-right: 60px; width:35%">
                            <div style="background-color: white" class="div">
                                <table style="width:100%; text-align:center">
                                    <tr>
                                        <td>
                               <img src="" runat="server" id="ProfileImg" height="170" width="170"/>
                                          
                                <asp:FileUpload ID="FileUpload1" runat="server" BackColor="Black" ForeColor="White" CssClass="Corners"/>
                                                
                                            </td>
                                        </tr>
                                    <tr>
                                        <td>
            <asp:Button ID="BtnProfileimg" runat="server" Text="Upload Image" Width="110px" OnClick="BtnProfileimg_Click" BackColor="Black" ForeColor="White" CssClass="Corners" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>


                <table style="width: 70%; text-align: center">
                    <tr>
                        <td style="text-align:right">
                            <asp:Label ID="Label3" runat="server" Text="Follow People :" Font-Bold="true"></asp:Label>
                        </td>
                        <td style="text-align:left">
                            <cc1:ASPTokenInput ID="tiTest2" Width="200px" Height="45px" runat="server" OnListChanged="tiTest2_ListChanged" RequestHandlerPath="~/ItemList.aspx?type=FollowPpl"
                                PostbackOnItemAdded="True" PostbackOnItemRemoved="True" Theme="facebook" PreventDuplicates="true" />
                            <asp:ListBox ID="lbList2" runat="server" Style="display: none" />
                    
                        </td>

                        <td>
                            <asp:TextBox ID="TxtCreateproj" runat="server" Height="45px" Width="200px" CssClass="Corners"></asp:TextBox>
                            <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkCreate" runat="server" TargetControlID="TxtCreateproj"
                                WatermarkText="Create a project" WatermarkCssClass="Watermark">
                            </asp:TextBoxWatermarkExtender>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align:center">
                            <asp:Button ID="Btndone" runat="server" Text="Done" Width="70px" Height="45px" CssClass="Button" OnClick="Btndone_Click" />
                        </td>
                    </tr>
                </table>

            </asp:Panel>
        </div>
    </form>
</body>
</html>
