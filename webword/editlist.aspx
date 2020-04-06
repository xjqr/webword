<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editlist.aspx.cs" Inherits="webword.editlist" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        body, div, h1, h2, h3, h4, h5, h6, span {margin: 0px;padding:0px;}
        .fileitem{border:1px solid silver;padding:5px;margin-bottom:5px;}
        .edititem{border:1px solid silver;padding:5px;margin-bottom:5px;background-color:#dedede;}
        .clr{clear:both;}
        .namepel{float:left;}
        .subpel {float: right;}
        input{margin-right:3px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="div_editlist"  runat="server">
        </div>
        <script src="jquery.js"></script>
    <script type="text/javascript">
        $(document).ready(function () { $("#editinput").focus(); });
        function Check() {
            var newname = document.getElementById("editinput").value;
            if (newname == null) {
                alert("文件名不能为空！");
                return false;
            } return true;
        }
    </script>
    </form>
</body>
</html>
