<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="FLO_web.WebForm1" %>

<!DOCTYPE html>
<script runat="server">

</script>
<meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="theme-color" content="#009578">
    <link rel="stylesheet" href="master.css">
    <link rel="manifest" href="manifest.json" />
    <link rel="apple-touch-icon" href="logo192.png">
    <link rel="stylesheet" href="StyleSheet.css">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>
    <link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin="">
<link href="https://fonts.googleapis.com/css2?family=Poppins&display=swap" rel="stylesheet">

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            
            <asp:Label ID="Label5" runat="server" Text="Select Blockchain" style="padding-left:100px;width:500px;"></asp:Label>
            <asp:DropDownList  ID="DropDownList1"  runat="server">
                <asp:ListItem Value = "1" Selected="True">FLO BLOCKCHAIN</asp:ListItem>
                <asp:ListItem Value = "1">ETH BLOCKCHAIN</asp:ListItem>
            </asp:DropDownList>
            <br/>
            <br/>
            <asp:Label ID="Label4" runat="server" Text="ENTER YOUR DATA IDENTIFIER" style="padding-left:100px;width:500px;"></asp:Label>
            <br/>
            <asp:TextBox ID="enteredIDentifier" runat="server" Style="height:60px; width:500px;padding-left:40px;" wrap="true"  ></asp:TextBox>
            <br/>
            <asp:Label ID="Label1" runat="server" Text="ENTER TEXT TO BE STORED" style="padding-left:100px;width:500px"></asp:Label>
            <br/>
            <asp:TextBox ID="enterbox" runat="server" Style="height:60px; width:500px;padding-left:40px;" wrap="true"  ></asp:TextBox>
            <asp:Button ID="submit" runat="server" Text="SUBMIT" style="color:black" OnClick="submit_Click" />
            <br/>
            <asp:Label ID="lblMessage" runat="server" Text="Data Saved Successfully to FLO" Visible="false" style="padding-left:100px;"></asp:Label>
            <br/>
            <%--<asp:HyperLink ID="linkLabel1" runat="server" Text="See transaction on block explorer" Visible="false">See transaction on block explorer</asp:HyperLink>--%>
            <br/>
            <br/>
            <br/>
            <asp:Label ID="Label3" runat="server" Text="ENTER THE DATA IDENTIFIER" style="padding-left:100px;width:500px"></asp:Label>
            <br/>
            <asp:TextBox ID="identifier" runat="server" Style="height:60px; width:500px;padding-left:40px;" wrap="true" OnTextChanged="identifier_TextChanged"></asp:TextBox>
            <asp:Button ID="search" runat="server" Text="SEARCH" style="color:black" OnClick="search_Click"  />
            <br/>
            <br/>
            <asp:Label ID="Label2" runat="server" Text="FOUND YOUR FLODATA" Visible="false" style="padding-left:100px;width:500px"></asp:Label>
            <br/>
            <asp:TextBox ID="fd" runat="server" Style="height:300px; width:540px;" wrap="true" TextMode="MultiLine" Visible="false"></asp:TextBox>
            <br/>
            <asp:Label ID="lblMessage2" runat="server" Text="Data Does Not Exist" Visible="false" style="padding-left:80px;"></asp:Label>
            <script src="index.js"></script>


            
        </div>
    </form>
</body>
</html>
