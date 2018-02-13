<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Challenge34._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Postal Calculator<br />
        <br />
        Width:&nbsp;
        <asp:TextBox ID="widthTextBox" runat="server" AutoPostBack="True" OnTextChanged="widthTextBox_TextChanged"></asp:TextBox>
        <br />
        Height:&nbsp;
        <asp:TextBox ID="heightTextBox" runat="server" AutoPostBack="True" OnTextChanged="heightTextBox_TextChanged"></asp:TextBox>
        <br />
        Length:&nbsp;
        <asp:TextBox ID="lengthTextBox" runat="server" AutoPostBack="True" OnTextChanged="lengthTextBox_TextChanged"></asp:TextBox>
        <br />
        <br />
        <asp:RadioButton ID="groundButton" runat="server" AutoPostBack="True" GroupName="postalButtons" OnCheckedChanged="groundButton_CheckedChanged" Text="Ground" />
        <br />
        <asp:RadioButton ID="airButton" runat="server" AutoPostBack="True" GroupName="postalButtons" OnCheckedChanged="airButton_CheckedChanged" Text="Air" />
        <br />
        <asp:RadioButton ID="nextDayButton" runat="server" AutoPostBack="True" GroupName="postalButtons" OnCheckedChanged="nextDayButton_CheckedChanged" Text="Next Day" />
        <br />
        <br />
        <asp:Label ID="resultLabel" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
