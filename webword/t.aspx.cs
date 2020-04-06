using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;

namespace webword
{
	public partial class t : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["uid"] == null || Session["uid"].ToString() != "admin")
			{
				Response.Redirect("error.html");
			}
			count.Text = (Application["count"].ToString());
			onlinecount.Text = Application["online"].ToString();
			TableCell tableCell;
			TableRow row;
			string[] ips = ((List<string>)Application["ips"]).ToArray<string>();
			foreach (string ip in ips)
			{
				tableCell = new TableCell
				{
					Text = ip
				};

				row = new TableRow();
				row.Cells.Add(tableCell);
				tableCell = new TableCell
				{
					Text = SelectIp(ip)
				};
				row.Cells.Add(tableCell);
				iplist.Rows.Add(row);
			}

		}

		protected string SelectIp(string ip)
		{
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent:Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3314.0 Safari/537.36 SE 2.X MetaSr 1.0");
			byte[] buffer = webClient.DownloadData($"http://freeapi.ipip.net/{ip}");
			string result = Encoding.UTF8.GetString(buffer);
			result = result.Replace("\"", "");
			return result.Substring(1, result.Length - 4);

		}

	}
}