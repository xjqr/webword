<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="u.aspx.cs" Inherits="webword.u" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">table{border:1px solid silver;border-collapse:collapse;padding:10px;}td{border:1px solid silver;padding:10px;}</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
              <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1" ItemPlaceholderID="itemholder" DataKeyNames="user_id" InsertItemPosition="LastItem">
                <LayoutTemplate>
                    <table>
                        <tr>
                            <td></td>
                            <td>user_id</td>
                            <td>user_name</td>
                            <td>user_password</td>
                            <td>user_enable</td>
                            <td>user_check</td>
                            <td>user_question</td>
                        </tr>
                    <div id="itemholder" runat="server"></div>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Button ID="btn_edit" runat="server" Text="编辑" CommandName="edit"/><br />
                            <asp:Button ID="btn_delete" runat="server" Text="删除" CommandName="delete" />
                        </td>
                     <td><%#Eval("user_id") %></td>
                     <td><%#Eval("user_name") %></td>     
                    <td><%#Eval("user_password") %></td> 
                    <td><asp:CheckBox ID="user_enable" runat="server" Checked=' <%#Eval("user_enable") %>' Enabled="false" /></td>
                        <td><%#Eval("user_check") %></td>
                         <td><%#Eval("user_question") %></td>
                    </tr>    
                </ItemTemplate>
                 <EditItemTemplate>
                     <tr>
                         <td>
                             <asp:Button ID="btn_save" runat="server" Text="保存" CommandName="update"/></td>
                         <td>
                             <asp:TextBox ID="text_e_id" runat="server" Text='<%#Eval("user_id")%>' Enabled="false"/>

                         </td>
                         <td>
                             <asp:TextBox ID="text_e_name" runat="server" Text='<%#Bind("user_name")%>'/>
                         </td>
                         <td>
                             <asp:TextBox ID="Text_e_password" runat="server" Text='<%#Bind("user_password")%>'/>
                         </td>
                         <td>
                             <asp:CheckBox ID="cb_e_enable" runat="server" Checked='<%#Bind("user_enable")%>' />
                         </td>
                         <td>
                             <asp:TextBox ID="text_e_check" runat="server" Text='<%#Bind("user_check")%>'/>
                         </td>
                         <td>
                             <asp:TextBox ID="text_e_question" runat="server" Text='<%#Bind("user_question")%>'/>
                         </td>
                     </tr>
                 </EditItemTemplate>
                  <InsertItemTemplate>
                      <tr>
                           <td>
                             <asp:Button ID="btn_save" runat="server" Text="添加" CommandName="insert"/></td>
                         <td>
                             <asp:TextBox ID="text_i_id" runat="server" Text='<%#Bind("user_id")%>'/>

                         </td>
                         <td>
                             <asp:TextBox ID="text_i_name" runat="server" Text='<%#Bind("user_name")%>'/>
                         </td>
                         <td>
                             <asp:TextBox ID="Text_i_password" runat="server" Text='<%#Bind("user_password")%>'/>
                         </td>
                         <td>
                             <asp:CheckBox ID="cb_i_enable" runat="server" Checked='<%#Bind("user_enable")%>' />
                         </td>
                           <td>
                             <asp:TextBox ID="text_i_check" runat="server" Text='<%#Bind("user_check")%>'/>
                         </td>
                          <td>
                             <asp:TextBox ID="text_i_question" runat="server" Text='<%#Bind("user_question")%>'/>
                         </td>
                      </tr>
                  </InsertItemTemplate>
            </asp:ListView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString=""
                UpdateCommand="update user set user_name=?,user_password=?,user_enable=?,user_check=?,user_question=? where user_id=?"
                 InsertCommand="insert into user values(?,?,?,?,?,?)"
                 DeleteCommand="delete from user where user_id=?">
                <UpdateParameters>
                    <asp:Parameter Name="user_name" Type="String" />
                    <asp:Parameter Name="user_password" Type="String" />
                    <asp:Parameter Name="user_enable"   DbType="Boolean" />
                    <asp:Parameter Name="user_check" Type="String" />
                    <asp:Parameter Name="user_question" Type="Int32" />
                    <asp:Parameter Name="user_id" Type="Int32" />
                </UpdateParameters>
                <InsertParameters>
                    <asp:Parameter Name="user_id" Type="Int32" />
                    <asp:Parameter Name="user_name" Type="String" />
                    <asp:Parameter Name="user_password" Type="String" />
                    <asp:Parameter Name="user_enable"  DbType="Boolean" />
                    <asp:Parameter Name="user_check" Type="String" />
                    <asp:Parameter Name="user_question" Type="Int32" />
                </InsertParameters>
                <DeleteParameters>
                    <asp:Parameter Name="user_id" Type="Int32" />
                </DeleteParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
