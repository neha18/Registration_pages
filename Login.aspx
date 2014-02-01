<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server" Width="100%" BackColor="#EFC11B">
          <table style="width:100%">
              <tr>
                  <td style="padding-top:20px">
                      <asp:Label ID="Label2" runat="server" Text="Login Details :" Font-Size="Large"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td style="padding-top:50px; text-align:right">
                      <asp:Label ID="Label1" runat="server" Text="Email ID:"></asp:Label>
                  </td>
                  <td style="padding-top:50px">
                      <asp:TextBox ID="Txtemailid" runat="server" Height="23px" Width="160px"></asp:TextBox>
                  </td>
              </tr>
             <%-- <tr>
                  <td>
                      <asp:Label ID="Label2" runat="server" Text="Password :"></asp:Label>
                  </td>
                  <td>
                      <asp:TextBox ID="Txtpass" runat="server" Height="23px" Width="160px"></asp:TextBox>
                  </td>
              </tr>--%>
              <tr>
                  <td colspan="2" style="text-align:center">
                      <asp:Button ID="Button1" runat="server" Text="Submit" Width="110px" Height="23px" OnClick="Button1_Click" />
                  </td>
              </tr>
          </table>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
