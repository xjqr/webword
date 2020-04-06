<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="t.aspx.cs" Inherits="webword.t" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">table{border:1px solid silver;border-collapse:collapse;}td{border:1px  solid silver;padding:10px;}</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>访问量:<asp:Label ID="count" runat="server"></asp:Label></p>
            <p>在线人数:<asp:Label ID="onlinecount" runat="server"></asp:Label></p>
            <asp:Table ID="iplist" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>访问IP记录</asp:TableHeaderCell>
                    <asp:TableHeaderCell>所在地</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
