<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manager.aspx.cs" Inherits="webword.manager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <style type="text/css">
        body,div,ul{padding:0px;margin:0px;}
        h2{text-align:center;padding:10px 0px 20px 0px;border-bottom:1px solid silver;}
        .div_left{border:1px solid silver;padding:10px;float:left;height:400px;background-color:#f8f5f5;width:14%;}
        .div_right{padding:10px;float:left;width:70%;}
        ul{list-style-type:none;margin:auto auto;}
        li{margin:10px 0px 10px 0px;}
        li a{padding:10px; font-size:32px;text-decoration:none;display:block;border:1px solid silver;color:#808080}
        li a:hover{background-color:#dedede; color:white;}
        #frame{height:400px;margin:0px;border:none;width:100%}
     </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="div_head">
                <h2>webword 在线文档编辑器管理平台</h2>
            </div>
            <div class="div_left">
                <h5 style="text-align:center;">菜单</h5>
                <asp:BulletedList ID="BulletedList1" runat="server" DisplayMode="LinkButton" OnClick="BulletedList1_Click">
                    <asp:ListItem>user表</asp:ListItem>
                    <asp:ListItem>fileinfo表</asp:ListItem>
                    <asp:ListItem>统计</asp:ListItem>
                </asp:BulletedList>
            </div>   
            <div class="div_right">
                <iframe id="frame" runat="server" ></iframe>
            </div>
           <div style="clear:both;"></div>
        </div>
    </form>
</body>   
</html>
