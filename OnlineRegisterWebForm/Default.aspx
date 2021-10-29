<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OnlineRegisterWebForm.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="BtnStudent" runat="server" Text="STUDENTI" OnClick="BtnStudent_Click" />
            <asp:Button ID="BtnTeacher" runat="server" Text="DOCENTI" OnClick="BtnTeacher_Click" />
            <br />
            <asp:Label ID="LblOutput" runat="server" Text="(qui appariranno i dati)"></asp:Label>
        </div>
    </form>
</body>
</html>
