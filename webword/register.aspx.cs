using SqliteHelper;
using System;
using System.Data;
namespace webword
{
	public partial class register : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		[Obsolete]
		protected void Button1_Click(object sender, EventArgs e)
		{
			Sqlitehelper.SetConnectionString(MapPath("~/webword.db"), "");
			DataTable table = Sqlitehelper.ExecuteQuery("select * from user where user_name='" + TextBox1.Text + "'");
			if (table.Rows.Count > 0)
			{
				TextBox1.Focus();
				Response.Write("<script>alert('用户名已经存在!')</script>");
			}
			else
			{
				DataTable table1 = Sqlitehelper.ExecuteQuery("select * from user");
				int i = table1.Rows.Count + 1;
				string password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(TextBox2.Text, "MD5");
				Sqlitehelper.ExecuteNonQuery("insert into user values(" + i + ",'" + TextBox1.Text + "','" + password + "',1,'" + TextBox3.Text + "'," + (DropDownList1.SelectedIndex + 1).ToString() + ")");
				Response.Write("<script>alert('注册成功！');location.href='logic.aspx';</script>");
			}
		}
	}
}