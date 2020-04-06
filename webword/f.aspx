<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="f.aspx.cs" Inherits="webword.f" %>

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
             <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1" ItemPlaceholderID="itemholder" DataKeyNames="fileinfo_id" InsertItemPosition="LastItem">
                <LayoutTemplate>
                    <table>
                        <tr>
                            <td></td>
                            <td>fileinfo_id</td>
                            <td>fileinfo_name</td>
                            <td>fileinfo_userid</td>
                            <td>fileinfo_enable</td>
                            <td>fileinfo_delete</td>
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
                     <td><%#Eval("fileinfo_id") %></td>
                     <td><%#Eval("fileinfo_name") %></td>     
                    <td><%#Eval("fileinfo_userid") %></td> 
                    <td><asp:CheckBox ID="fileinfo_enable" runat="server" Checked=' <%#Eval("fileinfo_enable") %>' Enabled="false" /></td>
                    <td><asp:CheckBox ID="fileinfo_delete" runat="server" Checked=' <%#Eval("fileinfo_delete") %>' Enabled="false" /></td>
                    </tr>    
                </ItemTemplate>
                 <EditItemTemplate>
                     <tr>
                         <td>
                             <asp:Button ID="btn_save" runat="server" Text="保存" CommandName="update"/></td>
                         <td>
                             <asp:TextBox ID="text_e_id" runat="server" Text='<%#Eval("fileinfo_id")%>' Enabled="false"/>

                         </td>
                         <td>
                             <asp:TextBox ID="text_e_name" runat="server" Text='<%#Bind("fileinfo_name")%>'/>
                         </td>
                         <td>
                             <asp:TextBox ID="Text_e_userid" runat="server" Text='<%#Bind("fileinfo_userid")%>'/>
                         </td>
                         <td>
                             <asp:CheckBox ID="cb_e_enable" runat="server" Checked='<%#Bind("fileinfo_enable")%>' />
                         </td>
                         <td>
                             <asp:CheckBox ID="cb_e_delete" runat="server" Checked='<%#Bind("fileinfo_delete")%>' />
                         </td>
                     </tr>
                 </EditItemTemplate>
                  <InsertItemTemplate>
                      <tr>
                         <td>
                             <asp:Button ID="btn_save" runat="server" Text="添加" CommandName="insert"/></td>
                         <td>
                             <asp:TextBox ID="text_i_id" runat="server" Text='<%#Bind("fileinfo_id")%>'/>

                         </td>
                         <td>
                             <asp:TextBox ID="text_i_name" runat="server" Text='<%#Bind("fileinfo_name")%>'/>
                         </td>
                         <td>
                             <asp:TextBox ID="Text_i_userid" runat="server" Text='<%#Bind("fileinfo_userid")%>'/>
                         </td>
                         <td>
                             <asp:CheckBox ID="cb_i_enable" runat="server" Checked='<%#Bind("fileinfo_enable")%>' />
                         </td>
                         <td>
                             <asp:CheckBox ID="cb_i_delete" runat="server" Checked='<%#Bind("fileinfo_delete")%>' />
                         </td>
                     </tr>
                  </InsertItemTemplate>
            </asp:ListView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString=""
                UpdateCommand="update fileinfo set fileinfo_name=?,fileinfo_userid=?,fileinfo_enable=?,fileinfo_delete=? where fileinfo_id=?"
                 InsertCommand="insert into fileinfo values(?,?,?,?,?)"
                 DeleteCommand="delete from fileinfo where fileinfo_id=?">
                <UpdateParameters>
                    <asp:Parameter Name="fileinfo_name" Type="String" />
                    <asp:Parameter Name="fileinfo_userid" Type="Int32" />
                    <asp:Parameter Name="fileinfo_enable"   DbType="Boolean" />
                    <asp:Parameter Name="fileinfo_delete" DbType="Boolean" />
                    <asp:Parameter Name="fileinfo_id" Type="Int32" />
                </UpdateParameters>
                <InsertParameters>
                    <asp:Parameter Name="fileinfo_id" Type="Int32" />
                    <asp:Parameter Name="fileinfo_name" Type="String" />
                    <asp:Parameter Name="fileinfo_userid" Type="String" />
                    <asp:Parameter Name="fileinfo_enable"  DbType="Boolean" />
                    <asp:Parameter Name="fileinfo_delete"  DbType="Boolean" />
                </InsertParameters>
                <DeleteParameters>
                    <asp:Parameter Name="fileinfo_id" Type="Int32" />
                </DeleteParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
