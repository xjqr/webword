<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resetpassword.aspx.cs" Inherits="webword.resetpassword" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>重置密码</title>
    <style type="text/css">.warn{color:red;font-size:13px;}</style>
</head>
<body>
    <form id="form1" runat="server">
        <div><div id="div_head">
           <h2 style="text-align:center;padding:10px;">Word 在线文档编辑器</h2></div>
            <div id="div_logic" style="width:50%;height:400px; margin:100px auto;border:1px solid silver;">
                <h3 style="text-align:center;padding:10px;border-bottom:1px solid silver;">忘记密码</h3>
                <p style="text-align:center; margin-top:70px;">
                    <span>新的密码：</span><asp:TextBox ID="TextBox1" runat="server"  TextMode="Password"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="新密码不能为空" ControlToValidate="TextBox1" CssClass="warn"></asp:RequiredFieldValidator></p>
                <p style="text-align:center;">
                 <span>确定密码：</span><asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox><br />
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="两次密码不一致" ControlToCompare="TextBox1" ControlToValidate="TextBox3" CssClass="warn"></asp:CompareValidator><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="确定密码不能为空" ControlToValidate="TextBox3" CssClass="warn"></asp:RequiredFieldValidator>
                </p>
                <p style="text-align:center;">
                    <asp:Button ID="Button1" runat="server" Text="重置密码" Height="21px" OnClick="Button1_Click"/></p>
            </div>
        </div>
    </form>
</body>
</html>
