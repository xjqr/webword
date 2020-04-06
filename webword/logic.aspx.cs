using SqliteHelper;
using System;
using System.Data;

namespace webword
{
	public partial class logic : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		[Obsolete]
		protected void Button1_Click(object sender, EventArgs e)
		{
			Sqlitehelper.SetConnectionString(MapPath("~/webword.db"), "");
			string password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(TextBox2.Text, "MD5");
			DataTable table = Sqlitehelper.ExecuteQuery("select * from user where user_name='" + TextBox1.Text + "' and user_password='" + password + "'");
			if (table.Rows.Count == 0)
			{
				TextBox1.Text = "";
				TextBox2.Text = "";
				Response.Write("<script>alert('用户名或密码错误')</script>");
			}
			else
			{
				Session["uid"] = TextBox1.Text;
				if (TextBox1.Text == "admin")
				{
					Response.Redirect("manager.aspx");
				}
				else
				{
					Response.Redirect("index.aspx");

				}
				;
			}
		}

		protected void Button2_Click(object sender, EventArgs e)
		{
			Response.Redirect("register.aspx");
		}
	}
}