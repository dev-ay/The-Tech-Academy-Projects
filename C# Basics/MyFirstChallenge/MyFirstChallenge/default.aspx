<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="MyFirstChallenge._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Free Insults:<br />
        <br />
        How old are you?&nbsp;
        <asp:TextBox ID="ageTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        How much money do you have in your pocket?&nbsp;
        <asp:TextBox ID="moneyTextBox" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="resultButton" runat="server" OnClick="resultButton_Click" Text="Click for Free Insults" />
        <br />
        <br />
        <asp:Label ID="resultLabel" runat="server"></asp:Label>
    </form>
</body>
</html>
