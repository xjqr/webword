using System;
using System.Collections.Generic;

namespace webword
{
	public class Global : System.Web.HttpApplication
	{

		protected void Application_Start(object sender, EventArgs e)
		{
			Application["count"] = 0;
			Application["ips"] = new List<string>();
			Application["online"] = 0;
		}

		protected void Session_Start(object sender, EventArgs e)
		{
			Session["edittext"] = "\u8000";
			int o = (int)Application["online"];
			o++;
			Application["online"] = o;




		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{

		}

		protected void Application_Error(object sender, EventArgs e)
		{

		}

		protected void Session_End(object sender, EventArgs e)
		{
			int o = (int)Application["online"];
			o--;
			Application["online"] = o;

		}

		protected void Application_End(object sender, EventArgs e)
		{

		}

	}
}