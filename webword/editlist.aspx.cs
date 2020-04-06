using SqliteHelper;
using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webword
{
	public partial class editlist : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			int i = int.Parse(Request.QueryString["eid"]);
			if (Session["uid"] != null)
			{
				Panel panel, subpel, namepel, clpel;
				Label label1;
				Button btn_save, btn_cancel;
				Sqlitehelper.SetConnectionString(MapPath("~/webword.db"), "");
				string sql = "select fileinfo_name,fileinfo_id from user inner join fileinfo on user_id=fileinfo_userid where fileinfo_delete=0 and user_name='" + Session["uid"].ToString() + "'";
				DataTable table = Sqlitehelper.ExecuteQuery(sql);
				for (int j = 0; j < table.Rows.Count; j++)
				{
					panel = new Panel();
					label1 = new Label();
					subpel = new Panel();
					clpel = new Panel();
					clpel.CssClass = "clr";
					subpel.CssClass = "subpel";
					namepel = new Panel();
					namepel.CssClass = "namepel";
					label1.Text = table.Rows[j]["fileinfo_name"].ToString();

					if (j == (i - 1))
					{
						btn_save = new Button();
						btn_save.Text = "保存";
						btn_save.CommandArgument = i.ToString();
						btn_save.Command += new CommandEventHandler(Btn_save_Command);
						btn_save.OnClientClick = "return Check";
						btn_cancel = new Button();
						btn_cancel.Text = "取消";
						btn_cancel.Command += new CommandEventHandler(Btn_cancel_Command);
						subpel.Controls.Add(btn_save);
						subpel.Controls.Add(btn_cancel);
						panel.CssClass = "edititem";
						TextBox textBox = new TextBox();
						textBox.ID = "editinput";
						textBox.Text = table.Rows[j]["fileinfo_name"].ToString();
						;
						namepel.Controls.Add(textBox);
					}
					else
					{
						namepel.Controls.Add(label1);

						panel.CssClass = "fileitem";
					}

					panel.Controls.Add(namepel);
					panel.Controls.Add(subpel);
					panel.Controls.Add(clpel);
					div_editlist.Controls.Add(panel);

				}

			}

		}


		private void Btn_cancel_Command(object sender, CommandEventArgs e)
		{
			Response.Redirect("filelist.aspx");
		}

		private void Btn_save_Command(object sender, CommandEventArgs e)
		{
			TextBox box = (TextBox)Page.FindControl("editinput");
			Sqlitehelper.SetConnectionString(MapPath("~/webword.db"), "");
			DataTable table = Sqlitehelper.ExecuteQuery("select user_name,(user_name||'\\'||fileinfo_name||'.doc') as path from user inner join fileinfo on user_id=fileinfo_userid where fileinfo_id=" + e.CommandArgument);

			string opath = MapPath("~/wordsave/") + table.Rows[0]["path"].ToString();

			if (File.Exists(opath))
			{
				string npath0 = MapPath("~/wordsave/") + table.Rows[0]["user_name"].ToString() + "\\" + box.Text + ".doc";
				File.Move(opath, npath0);
			}
			else
			{
				string npath = MapPath("~/wordsave/") + table.Rows[0]["user_name"].ToString() + "\\" + box.Text + ".txt";
				opath = opath.Replace(".doc", ".txt");
				File.Move(opath, npath);
			}



			Sqlitehelper.ExecuteNonQuery("update fileinfo set fileinfo_name='" + box.Text + "' where fileinfo_id=" + e.CommandArgument);
			Response.Redirect("filelist.aspx");

		}
	}
}