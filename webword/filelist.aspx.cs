using Spire.Doc;
using SqliteHelper;
using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;

namespace webword
{
	public partial class filelist : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["uid"] != null)
			{
				Panel panel, subpel, namepel, clpel;
				Label label1;
				Button btn_open, btn_edit, btn_delete, btn_download;
				Sqlitehelper.SetConnectionString(MapPath("~/webword.db"), "");
				string sql = "select fileinfo_name,fileinfo_id from user inner join fileinfo on user_id=fileinfo_userid where fileinfo_delete=0 and user_name='" + Session["uid"].ToString() + "'";
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
					btn_open = new Button();
					btn_open.Text = "打开";
					btn_open.Command += new CommandEventHandler(Btn_open_Command);
					btn_open.CommandArgument = row["fileinfo_id"].ToString();
					btn_edit = new Button();
					btn_edit.Text = "重命名";
					btn_edit.Command += new CommandEventHandler(Btn_edit_Command);
					btn_edit.CommandArgument = row["fileinfo_id"].ToString();
					btn_delete = new Button();
					btn_delete.Text = "删除";
					btn_delete.Command += new CommandEventHandler(Btn_delete_Command);
					btn_delete.CommandArgument = row["fileinfo_id"].ToString();
					btn_download = new Button();
					btn_download.Text = "下载";
					btn_download.Command += new CommandEventHandler(Btn_download_Command); ;
					btn_download.CommandArgument = row["fileinfo_id"].ToString();
					subpel.Controls.Add(btn_open);
					subpel.Controls.Add(btn_edit);
					subpel.Controls.Add(btn_delete);
					subpel.Controls.Add(btn_download);
					panel.Controls.Add(namepel);
					panel.Controls.Add(subpel);
					panel.Controls.Add(clpel);
					div_filelist.Controls.Add(panel);
				}
			}
		}

		private void Btn_download_Command(object sender, CommandEventArgs e)
		{
			Sqlitehelper.SetConnectionString(MapPath("~/webword.db"), "");

			DataTable table = Sqlitehelper.ExecuteQuery("select (user_name||'\\'||fileinfo_name||'.txt') as path from user inner join fileinfo on user_id=fileinfo_userid where fileinfo_id=" + e.CommandArgument);

			string path = MapPath("~/wordsave/") + table.Rows[0]["path"].ToString();
			if (!File.Exists(path))
			{
				path = path.Replace(".txt", ".doc");

			}
			FileInfo file = new FileInfo(path);


			Response.Clear();

			Response.Charset = "utf-8";//设置输出的编码

			Response.ContentEncoding = System.Text.Encoding.UTF8;

			// 添加头信息，为"文件下载/另存为"对话框指定默认文件名   

			Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode(Path.GetFileNameWithoutExtension(file.Name) + ".doc"));

			// 添加头信息，指定文件大小，让浏览器能够显示下载进度   

			Response.AddHeader("Content-Length", file.Length.ToString());

			// 指定返回的是一个不能被客户端读取的流，必须被下载   

			Response.ContentType = "application/msword";

			// 把文件流发送到客户端   

			Response.WriteFile(file.FullName);
			Response.End();

		}

		private void Btn_delete_Command(object sender, CommandEventArgs e)
		{
			Sqlitehelper.SetConnectionString(MapPath("~/webword.db"), "");
			Sqlitehelper.ExecuteNonQuery("update fileinfo set fileinfo_delete=1 where fileinfo_id=" + e.CommandArgument);
			Response.Redirect(Request.RawUrl);
		}

		private void Btn_edit_Command(object sender, CommandEventArgs e)
		{
			Response.Redirect("~/editlist.aspx?eid=" + e.CommandArgument);
		}

		private void Btn_open_Command(object sender, CommandEventArgs e)
		{

			Sqlitehelper.SetConnectionString(MapPath("~/webword.db"), "");
			DataTable table = Sqlitehelper.ExecuteQuery("select (user_name||'\\'||fileinfo_name||'.doc') as path from user inner join fileinfo on user_id=fileinfo_userid where fileinfo_id=" + e.CommandArgument);
			string path = MapPath("~/wordsave/") + table.Rows[0]["path"].ToString();
			//string wctext = GetWordContent(path);
			string wctext;
			if (File.Exists(path))
			{
				wctext = File.ReadAllText(path);
				if (wctext.StartsWith("<!DOCTYPE html>"))
				{

					wctext = File.ReadAllText(path);

					wctext = wctext.Substring(15);
				}
				else
				{
					Document doc = new Document();
					//加载Word文档
					doc.LoadFromFile(path);
					//使用GetText方法获取文档中的所有文本
					wctext = doc.GetText();
					wctext = wctext.Replace("\r", "<Br/>");
					wctext = wctext.Replace("\n", "<Br/>");

				}

			}
			else
			{

				path = path.Replace(".doc", ".txt");
				wctext = File.ReadAllText(path);
				char[] prc = "<!DOCTYPE html>".ToCharArray();

				wctext = wctext.Substring(15);
			}

			Session["edittext"] = wctext;
			Response.Write("<script>parent.location.reload();</script>");
		}
		/// <summary>
		/// 读取 word文档 返回内容
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		//public static string GetWordContent(string path)
		//{
		//	try
		//	{
		//		Word.Application app = new Microsoft.Office.Interop.Word.Application();
		//		Type wordType = app.GetType();
		//		Word.Document doc = null;
		//		object unknow = Type.Missing;
		//		app.Visible = false;
		//		object file = path;
		//		doc = app.Documents.Open(ref file,
		//			ref unknow, ref unknow, ref unknow, ref unknow,
		//			ref unknow, ref unknow, ref unknow, ref unknow,
		//			ref unknow, ref unknow, ref unknow, ref unknow,
		//			ref unknow, ref unknow, ref unknow);
		//		int count = doc.Paragraphs.Count;
		//		StringBuilder sb = new StringBuilder();
		//		for (int i = 1; i <= count; i++)
		//		{

		//			sb.Append(doc.Paragraphs[i].Range.Text.Trim());
		//		}

		//		doc.Close(ref unknow, ref unknow, ref unknow);
		//		wordType.InvokeMember("Quit", System.Reflection.BindingFlags.InvokeMethod, null, app, null);
		//		doc = null;
		//		app = null;
		//		//垃圾回收
		//		GC.Collect();
		//		GC.WaitForPendingFinalizers();
		//		string temp = sb.ToString();
		//		//if (temp.Length > 200)
		//		//    return temp.Substring(0, 200);
		//		//else
		//		return temp;
		//	}
		//	catch
		//	{
		//		return "";
		//	}

		//}


	}
}