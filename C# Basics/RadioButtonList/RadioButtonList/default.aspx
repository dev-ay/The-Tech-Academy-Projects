<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="RadioButtonList._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Your Note Taking Prefrences<br />
        <br />
        <asp:RadioButton ID="pencil" runat="server" GroupName="buttonGroup" OnCheckedChanged="RadioButton1_CheckedChanged" Text="Pencil" />
        <br />
        <asp:RadioButton ID="pen" runat="server" GroupName="buttonGroup" Text="Pen" />
        <br />
        <asp:RadioButton ID="phone" runat="server" GroupName="buttonGroup" Text="Phone" />
        <br />
        <asp:RadioButton ID="tablet" runat="server" GroupName="buttonGroup" OnCheckedChanged="RadioButton4_CheckedChanged" Text="Tablet" />
        <br />
        <br />
        <asp:Button ID="okayButton" runat="server" OnClick="okayButton_Click" Text="OK" />
        <br />
        <br />
        <asp:Image ID="resultImage" runat="server" Height="250px" Width="214px" />
        <br />
        <br />
        <asp:Label ID="resultLabel" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
