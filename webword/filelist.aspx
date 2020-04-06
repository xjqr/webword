<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="filelist.aspx.cs" Inherits="webword.filelist" %>

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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="div_filelist"  runat="server">
            
        </div>
        <script src="jquery-3.4.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".subpel").hide();
            $(".fileitem").mouseover(function () { $(".subpel", this).show(); });
            $(".fileitem").mouseleave(function () { $(".subpel", this).hide(); });
        });
    </script>
    </form>
</body>
</html>
