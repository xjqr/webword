<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgetpassword.aspx.cs" Inherits="webword.forgetpassword" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>忘记密码</title>
    <style type="text/css">.warn{color:red;font-size:13px;}</style>
</head>
<body>
    <form id="form1" runat="server">
        <div><div id="div_head">
           <h2 style="text-align:center;padding:10px;">Word 在线文档编辑器</h2></div>
            <div id="div_logic" style="width:50%;height:400px; margin:100px auto;border:1px solid silver;">
                <h3 style="text-align:center;padding:10px;border-bottom:1px solid silver;">找回密码</h3>
                <p style="text-align:center; margin-top:70px;">
                    <span>用户名：</span><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="用户名不能为空" ControlToValidate="TextBox1" CssClass="warn"></asp:RequiredFieldValidator></p>
                   <p style="text-align:center;">
                       <span>验证问题：</span><asp:DropDownList ID="DropDownList1" runat="server">
                           <asp:ListItem>您母亲的名字</asp:ListItem>
                           <asp:ListItem>您父亲的名字</asp:ListItem>
                           <asp:ListItem>您童年好友的名字</asp:ListItem>
                       </asp:DropDownList><br />  
                   </p>
                <p style="text-align:center;">
                 <span>问题答案：</span><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="问题答案不能为空" ControlToValidate="TextBox3" CssClass="warn"></asp:RequiredFieldValidator>
                </p>
                <p style="text-align:center;">
                    <asp:Button ID="Button1" runat="server" Text="找回密码" Height="21px" OnClick="Button1_Click"/></p>
            </div>
        </div>
    </form>
</body>
</html>