using SqliteHelper;
using System;
using System.Data;

namespace webword
{
	public partial class forgetpassword : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			Sqlitehelper.SetConnectionString(MapPath("~/webword.db"), "");
			DataTable table = Sqlitehelper.ExecuteQuery($"select * from user where user_name='{TextBox1.Text}' and user_check='{TextBox3.Text}' and user_question={DropDownList1.SelectedIndex + 1}");
			if (table.Rows.Count > 0) { Session["resetinfo"] = TextBox1.Text; Response.Redirect("~/resetpassword.aspx"); }
			else
			{
				Response.Write("<script>alert('用户名或问题答案错误')</script>");
			}
		}
	}
}