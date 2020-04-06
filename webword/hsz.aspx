<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hsz.aspx.cs" Inherits="webword.hsz" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        body, div, h1, h2, h3, h4, h5, h6, span {margin: 0px;padding:0px;}
        .fileitem{border:1px solid silver;padding:5px;margin-bottom:5px;}
        .fileitem:hover{background-color:#dedede;font-weight:bold;color:white;}
        .clr{clear:both;}
        .namepel{float:left;}
        .subpel{float:right;}
        input{margin-right:3px;}
        a{display:block;padding:5px;font-size:20px;text-align:center;text-decoration:none;color:black;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="div_head" class="fileitem">
                <a href="hsz.aspx?model=0">清空</a>
            </div>
            <div id="div_hszitem"  runat="server"></div>
        </div>
    </form>
</body>
</html>
