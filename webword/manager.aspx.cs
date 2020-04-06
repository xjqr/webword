using System;
using System.Web.UI.WebControls;

namespace webword
{
	public partial class manager : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

			if (Session["uid"] == null || Session["uid"].ToString() != "admin")
			{
				Response.Redirect("error.html");
			}

		}

		protected void BulletedList1_Click(object sender, BulletedListEventArgs e)
		{

			string p = BulletedList1.Items[e.Index].Value;
			switch (p)
			{
				case "user表": frame.Src = "~/u.aspx"; break;
				case "fileinfo表": frame.Src = "~/f.aspx"; break;
				case "统计": frame.Src = "~/t.aspx"; break;
			}

		}
	}
}