using SqliteHelper;
using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;

namespace webword
{
	public partial class hsz : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Request.QueryString["model"] == null)
			{
				if (Session["uid"] != null)
				{
					Panel panel, subpel, namepel, clpel;
					Label label1;
					Button btn_recov, btn_rdelete;
					Sqlitehelper.SetConnectionString(MapPath("~/webword.db"), "");
					string sql = "select fileinfo_name,fileinfo_id from user inner join fileinfo on user_id=fileinfo_userid where fileinfo_delete=1 and user_name='" + Session["uid"].ToString() + "'";
					DataTable table = Sqlitehelper.ExecuteQuery(sql);
					foreach (DataRow row in table.Rows)
					{
						panel = new Panel();
						panel.CssClass = "fileitem";
						label1 = new Label();
						subpel = new Panel();
						clpel = new Panel();
						clpel.CssClass = "clr";
						subpel.CssClass = "subpel";
						namepel = new Panel();
						namepel.CssClass = "namepel";
						label1.Text = row["fileinfo_name"].ToString();
						namepel.Controls.Add(label1);
						btn_recov = new Button();
						btn_recov.Text = "还原";
						btn_recov.CommandArgument = row["fileinfo_id"].ToString();
						btn_recov.Command += new CommandEventHandler(Btn_recov_Command);
						btn_rdelete = new Button();
						btn_rdelete.Text = "删除";
						btn_rdelete.CommandArgument = row["fileinfo_id"].ToString();
						btn_rdelete.Command += new CommandEventHandler(Btn_rdelete_Command);
						subpel.Controls.Add(btn_recov);
						subpel.Controls.Add(btn_rdelete);
						panel.Controls.Add(namepel);
						panel.Controls.Add(subpel);
						panel.Controls.Add(clpel);
						div_hszitem.Controls.Add(panel);



					}

				}

			}
			else
			{
				if (Session["uid"] != null)
				{
					Sqlitehelper.SetConnectionString(MapPath("~/webword.db"), "");
					DataTable table = Sqlitehelper.ExecuteQuery("select (user_name||'\\'||fileinfo_name||'.doc') as path from user inner join fileinfo on user_id=fileinfo_userid where fileinfo_delete=1");
					foreach (DataRow row in table.Rows)
					{

						string path = MapPath("~/wordsave/") + row["path"].ToString();
						if (File.Exists(path))
						{
							File.Delete(path);

						}
						else
						{
							path = path.Replace(".doc", ".txt");
							File.Delete(path);
						}

					}
					Sqlitehelper.SetConnectionString(MapPath("~/webword.db"), "");
					Sqlitehelper.ExecuteNonQuery("delete from fileinfo where fileinfo_delete=1");


				}


			}

		}

		private void Btn_rdelete_Command(object sender, CommandEventArgs e)
		{
			Sqlitehelper.SetConnectionString(MapPath("~/webword.db"), "");
			DataTable table = Sqlitehelper.ExecuteQuery("select user_name,(user_name||'\\'||fileinfo_name||'.doc') as path from user inner join fileinfo on user_id=fileinfo_userid where fileinfo_id=" + e.CommandArgument);
			string path = MapPath("~/wordsave/") + table.Rows[0]["path"].ToString();
			if (!File.Exists(path))
			{

				path = path.Replace(".doc", ".txt");
			}
			File.Delete(path);
			Sqlitehelper.ExecuteNonQuery("delete from fileinfo where fileinfo_id=" + e.CommandArgument);

			Response.Redirect(Request.RawUrl);
		}

		private void Btn_recov_Command(object sender, CommandEventArgs e)
		{
			Sqlitehelper.SetConnectionString(MapPath("~/webword.db"), "");
			Sqlitehelper.ExecuteNonQuery("update fileinfo set fileinfo_delete=0 where fileinfo_id=" + e.CommandArgument);
			Response.Redirect(Request.RawUrl);
		}
	}
}