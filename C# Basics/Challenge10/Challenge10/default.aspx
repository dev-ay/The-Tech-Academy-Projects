<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Challenge10._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-family: Arial, Helvetica, sans-serif;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1>Simple Calculator</h1>
        <br />
        <span class="auto-style1">First Value:&nbsp; </span>
        <asp:TextBox ID="firstValue" runat="server"></asp:TextBox>
        <br />
        <span class="auto-style1">Second Value:&nbsp; </span>
        <asp:TextBox ID="secondValue" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text=" + " />
&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text=" - " OnClick="Button2_Click" />
&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" Text=" * " OnClick="Button3_Click" />
&nbsp;&nbsp;
        <asp:Button ID="Button4" runat="server" Text=" / " OnClick="Button4_Click" />
        <br />
        <br />
        <asp:Label ID="resultLabel" runat="server" style="font-weight: 700; font-size: large; background-color: #3399FF"></asp:Label>
    
    </div>
    </form>
</body>
</html>
