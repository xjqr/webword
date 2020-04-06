using System;

namespace webword
{
	public partial class f : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["uid"] == null || Session["uid"].ToString() != "admin")
			{
				Response.Redirect("error.html");
			}
			SqlDataSource1.ConnectionString = $"Data Source={MapPath("~/webword.db")};Version=3;";
			SqlDataSource1.ProviderName = "System.Data.SQLite";
			SqlDataSource1.SelectCommand = "select * from fileinfo";
		}
	}
}