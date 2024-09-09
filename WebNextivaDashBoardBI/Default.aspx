<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebNextivaDashBoardBI._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextUser" runat="server" Width="158px"></asp:TextBox><br />
        <asp:TextBox ID="TextPass" runat="server" Width="157px"></asp:TextBox><br />
       <asp:Button ID="btnIngreso" runat="server" Text="Ingreso" 
            onclick="btnIngreso_Click" /><br />
    </div>
    
    </form>
</body>
</html>
