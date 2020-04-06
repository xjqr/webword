<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="logic.aspx.cs" Inherits="webword.logic" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>登录</title>
    <style type="text/css">.warn{color:red;font-size:13px;}</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <div id="div_head">
           <h2 style="text-align:center;padding:10px;">Word 在线文档编辑器</h2>
            </div>
            <div id="div_logic" style="width:50%;height:400px; margin:100px auto;border:1px solid silver;">
                <h3 style="text-align:center;padding:10px;border-bottom:1px solid silver;">登录</h3>
                <p style="text-align:center; margin-top:90px;">
                    <span>用户名：</span><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="用户名不能为空" ControlToValidate="TextBox1" ValidationGroup="logic" CssClass="warn"></asp:RequiredFieldValidator>
                </p>
                  <p style="text-align:center;">
                    <span>密  码：</span><asp:TextBox ID="TextBox2" runat="server"  TextMode="Password"></asp:TextBox><br />
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="密码不能为空" ControlToValidate="TextBox2" ValidationGroup="logic" CssClass="warn"></asp:RequiredFieldValidator>
                </p>
                <p style="text-align:center">
                    <a href="forgetpassword.aspx" style="color:#808080; font-size:13px;">忘记密码</a>
                </p>
                <p style="text-align:center;">
                    <asp:Button ID="Button1" runat="server" Text="登录" Height="21px" OnClick="Button1_Click" ValidationGroup="logic"/>&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" Text="注册" Height="20px" OnClick="Button2_Click" />
                </p>
            </div>
        </div>
    </form>
</body>
</html>
