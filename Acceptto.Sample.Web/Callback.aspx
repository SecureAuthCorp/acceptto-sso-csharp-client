<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Callback.aspx.cs" Inherits="Acceptto.Sample.Web.Callback" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Multi Factor Auth Result:
            <asp:Label ID="lblStatus" runat="server" />
        </div>
        <div>
            <hr />
            <a href="Default.aspx">Back to Login Page</a>
        </div>
    </form>
</body>
</html>

