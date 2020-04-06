using SqliteHelper;
using System;

namespace webword
{
	public partial class resetpassword : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["resetinfo"] == null)
			{
				Response.Redirect("~/error.html");
			}


		}

		[Obsolete]
		protected void Button1_Click(object sender, EventArgs e)
		{
			Sqlitehelper.SetConnectionString(MapPath("~/webword.db"), "");
			string password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(TextBox3.Text, "MD5");
			Sqlitehelper.ExecuteNonQuery($"update user set user_password='{password}' where user_name='{Session["resetinfo"].ToString()}'");
			Session["resetinfo"] = null;
			Response.Redirect("~/logic.aspx");
		}
	}
}