<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="webword.index" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta  name="keywords" content="webword，在线文本编辑器，word" />
    <meta name="description" content="word 在线文本编辑器" />
    <title>Word 在线文档编辑器</title>
    <style type="text/css">
        .username{font-size:16px;color:#7d4e4e;}
        .warn{color:red;font-size:12px;}
        .frame{width:100%;height:120px;border:none;}
        .fous{color:white;font-weight:bold;border:1px solid #dedede;background-color:#dedede;          }
        .fc{color:white;font-weight:bold;border:1px solid #dedede;background-color:#dedede;}
        #fnameform,#FileUpload1,#Button6,#logicstate,#op{display:none;}
    </style>  
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="div_head">
           <h2 style="text-align:center;padding:10px;">Word 在线文档编辑器</h2>
             <div id="div_logic" runat="server" style="text-align:center;"></div>
            </div>
            <div style="border:1px solid silver; margin-bottom:3px;margin-top:3px;">
                <span id="myfile" runat="server" class="fc">我的文档</span>
                <span id="resz" runat="server">回收站</span>
                <div style="border:2px solid silver; background-color:white;">
                    <iframe src="filelist.aspx" class="frame" id="iflist"></iframe>
                </div>              
            </div> 
            <asp:Button ID="Button1" runat="server" Text="保存到本地"  OnClick="Button1_Click"/>
            <asp:Button ID="Button2" runat="server" Text="保存到服务器" OnClick="Button2_Click" /> 
             <asp:FileUpload ID="FileUpload1" runat="server" />
            <input id="Button5" type="button" value="上传文件到服务器" />
             <br />
            <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server" ></CKEditor:CKEditorControl>
              <asp:Panel style="position:absolute; top: 40%; left: 40%; border:1px solid silver;background-color:grey; width:200px;" id="fnameform" runat="server">
                <p style="text-align: center;"><span style="padding:5px;">文件名：</span><br /><br /><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="文件名不能为空！" CssClass="warn" ControlToValidate="TextBox1" ValidationGroup="fnamec"></asp:RequiredFieldValidator>
                </p>
                <p style="text-align:center;">
                    <asp:Button ID="Button3" runat="server" Text="保存" ValidationGroup="fnamec" OnClick="Button3_Click"/>
                    <asp:Button ID="Button4" runat="server" Text="取消" OnClick="Button4_Click" />
                </p>
            </asp:Panel> 
            <asp:TextBox ID="logicstate" runat="server"></asp:TextBox>
            <asp:TextBox ID="op" runat="server"></asp:TextBox>
        </div>
        <script src="jquery-3.4.js"></script>
     <script type="text/javascript">
         $(document).ready(function () {
             $("#FileUpload1").attr("accept", ".doc,.docx");
           $("#TextBox1").focus();
           $("#myfile").mouseover(function () {$(this).css("cursor", "pointer");$("#myfile").addClass("fous");});
           $("#myfile").mouseleave(function () {$("#myfile").removeClass("fous");});
           $("#resz").mouseover(function () {$(this).css("cursor", "pointer");$("#resz").addClass("fous");});
           $("#resz").mouseleave(function () {$("#resz").removeClass("fous");});
           $("#myfile").click(function () {$("#resz").removeClass("fc");$("#iflist").attr("src", "filelist.aspx");$("#myfile").addClass("fc");});
           $("#resz").click(function () {$("#myfile").removeClass("fc");$("#iflist").attr("src", "hsz.aspx");$("#resz").addClass("fc");});
           $("#Button5").click(function () {if ($("#logicstate").val() == "true") {$("#FileUpload1").click();}else {alert("请先登录！");}});
           $("#FileUpload1").change(function () {if ($("FileUpload1").val() != "") { document.getElementById("op").value = "upload";$("#fnameform").show(function () { $("#TextBox1").focus(); });}});
       });
   </script>
    </form>
</body>
</html>
