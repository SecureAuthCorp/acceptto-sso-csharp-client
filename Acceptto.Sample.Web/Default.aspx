<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Acceptto.Sample.Web.Default" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Sample Acceptto Multifactor Authentication</h2>
    </div>
    <hr />
    <div>
        Sign In With Acceptto Multi Factor Authentication: 
    </div>
        <br />
        <table>
            <tr>
                <td>
                    Email Address
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server">
                    </asp:TextBox> ( Use the same email address you signed up with on Acceptto mobile app)
                </td>
            </tr>
            <tr>
                <td>
                    Password
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" TextMode="Password"  runat="server"></asp:TextBox>
                    (Use 123)
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Button ID="btnLogin" Text="Sign In" OnClick="btnLogin_Click" runat="server" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
