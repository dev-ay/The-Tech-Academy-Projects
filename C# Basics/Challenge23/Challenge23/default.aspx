<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Challenge23._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 149px;
            height: 180px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <img alt="Epic Spies Logo" class="auto-style1" src="epic-spies-logo.jpg" /><br />
        <h2>Asset Performance Tracker</h2>
        Asset Name:&nbsp;
        <asp:TextBox ID="nameBox" runat="server"></asp:TextBox>
        <br />
        Elections Rigged:&nbsp;
        <asp:TextBox ID="electionsBox" runat="server"></asp:TextBox>
        <br />
        Acts of Subterfuge Performed:&nbsp;
        <asp:TextBox ID="actsBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="addButton" runat="server" OnClick="addButton_Click" Text="Add Asset" />
        <br />
        <br />
        <asp:Label ID="resultLabel" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
