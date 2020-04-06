using SqliteHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webword
{
	public partial class index : System.Web.UI.Page
	{
		protected static int moi = 0;
		protected void Page_Load(object sender, EventArgs e)
		{

			CKEditorControl1.config.toolbar = new object[]
						{
				//new object[] { "Source", "-", "Save", "NewPage", "Preview", "-", "Templates" },
				new object[] { "Cut", "Copy", "Paste", "PasteText", "PasteFromWord", "-", "Print", "SpellChecker", "Scayt" },
				new object[] { "Undo", "Redo", "-", "Find", "Replace", "-", "SelectAll", "RemoveFormat" },
				new object[] { "Form", "Checkbox", "Radio", "TextField", "Textarea", "Select", "Button", "ImageButton", "HiddenField" },
				"/",
				new object[] { "Bold", "Italic", "Underline", "Strike", "-", "Subscript", "Superscript" },
				new object[] { "NumberedList", "BulletedList", "-", "Outdent", "Indent", "Blockquote", "CreateDiv" },
				new object[] { "JustifyLeft", "JustifyCenter", "JustifyRight", "JustifyBlock" },
				new object[] { "BidiLtr", "BidiRtl" },
				new object[] { "Link", "Unlink", "Anchor" },
				new object[] { "Image", "Flash", "Table", "HorizontalRule", "Smiley", "SpecialChar", "PageBreak", "Iframe" },
				"/",
				new object[] { "Styles", "Format", "Font", "FontSize" },
				new object[] { "TextColor", "BGColor" },
							//new object[] { "Maximize", "ShowBlocks", "-", "About" }
			};
			if (Session["edittext"].ToString() != "\u8000")
			{
				CKEditorControl1.Text = Session["edittext"].ToString();
				Session["edittext"] = "\u8000";
			}


			if (Session["uid"] == null)
			{
				Button button = new Button();
				button.Text = "登录";
				button.Click += new EventHandler(Button_Click);
				div_logic.Controls.Add(button);
				logicstate.Text = "false";
			}
			else
			{
				Label label = new Label();
				label.Text = "用户：" + Session["uid"].ToString();
				label.CssClass = "username";
				div_logic.Controls.Add(label);
				Button button = new Button();
				button.Text = "退出";
				button.Click += new EventHandler(Button_Click1);
				div_logic.Controls.Add(button);
				logicstate.Text = "true";
			}
			if (!IsPostBack)
			{
				int c = (int)Application["count"];
				c++;
				Application["count"] = c;
				((List<string>)Application["ips"]).Add(GetIP());
			}
		}
		private void Button_Click1(object sender, EventArgs e)
		{
			if (CKEditorControl1.Text != String.Empty)
			{
				Session["edittext"] = CKEditorControl1.Text;

			}

			Session["uid"] = null;
			Response.Redirect(Request.RawUrl);

		}

		private void Button_Click(object sender, EventArgs e)
		{
			if (CKEditorControl1.Text != String.Empty)
			{
				Session["edittext"] = CKEditorControl1.Text;

			}
			Response.Redirect("logic.aspx");
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			if (CKEditorControl1.Text == "")
			{
				Response.Write("<script>alert('文档内容不能为空!')</script>");
				return;
			}
			string text = "<!DOCTYPE html>" + CKEditorControl1.Text;
			try
			{
				Directory.CreateDirectory(MapPath("~/wordsave"));
				string path = MapPath("~/wordsave/") + DateTime.Now.ToOADate() + ".doc";
				File.WriteAllText(path, text);
				FileInfo file = new FileInfo(path);

				Response.Clear();

				Response.Charset = "utf-8";//设置输出的编码

				Response.ContentEncoding = System.Text.Encoding.UTF8;

				// 添加头信息，为"文件下载/另存为"对话框指定默认文件名   

				Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode(file.Name));

				// 添加头信息，指定文件大小，让浏览器能够显示下载进度   

				Response.AddHeader("Content-Length", file.Length.ToString());

				// 指定返回的是一个不能被客户端读取的流，必须被下载   

				Response.ContentType = "application/msword";

				// 把文件流发送到客户端   

				Response.WriteFile(file.FullName);

				Response.End();
			}
			catch
			{

			}
		}

		protected void Button2_Click(object sender, EventArgs e)
		{
			if (CKEditorControl1.Text == "")
			{
				Response.Write("<script>alert('文档内容不能为空!')</script>");
				return;
			}
			else
			{
				Session["edittext"] = CKEditorControl1.Text;

			}
			if (Session["uid"] == null)
			{
				Response.Write("<script>alert('请先登录！');location.href='logic.aspx';</script>");
			}
			else
			{
				string js = "$('#fnameform').show();";
				ScriptManager.RegisterStartupScript(this, GetType(), "", js, true);
			}
		}

		protected void Button3_Click(object sender, EventArgs e)
		{
			Sqlitehelper.SetConnectionString(MapPath("~/webword.db"), "");
			DataTable table = Sqlitehelper.ExecuteQuery("select * from fileinfo");
			int i = table.Rows.Count + 1;
			DataTable table2 = Sqlitehelper.ExecuteQuery("select user_id from user where user_name='" + Session["uid"].ToString() + "'");
			try
			{

				Sqlitehelper.ExecuteNonQuery("insert into fileinfo values(" + i + ",'" + TextBox1.Text + "'," + table2.Rows[0]["user_id"] + " ,1,0)");

			}
			catch
			{
				Response.Write("<script>alert('文件名已经存在!')</script>");
			}

			if (op.Text == "")
			{
				string text = "<!DOCTYPE html>" + CKEditorControl1.Text;
				try
				{
					Directory.CreateDirectory(MapPath("~/wordsave/") + Session["uid"].ToString());
					string path = MapPath("~/wordsave/") + Session["uid"].ToString() + "\\" + TextBox1.Text + ".txt";
					File.WriteAllText(path, text);
				}
				catch
				{

				}

			}
			else
			{

				try
				{
					Directory.CreateDirectory(MapPath("~/wordsave/") + Session["uid"].ToString());
					string path = MapPath("~/wordsave/") + Session["uid"].ToString() + "\\" + TextBox1.Text + ".doc";
					if (FileUpload1.HasFile)
					{
						FileUpload1.SaveAs(path);

					}

				}
				catch
				{

				}
			}
			TextBox1.Text = "";
			op.Text = "";
			Response.Redirect(Request.RawUrl);
		}

		protected void Button4_Click(object sender, EventArgs e)
		{
			TextBox1.Text = "";
			op.Text = "";

		}
		protected static string GetIP()
		{
			string result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
			if (string.IsNullOrEmpty(result))
			{
				result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
			}
			if (string.IsNullOrEmpty(result))
			{
				result = HttpContext.Current.Request.UserHostAddress;
			}
			if (string.IsNullOrEmpty(result))
			{
				return "0.0.0.0";
			}
			return result;
		}


	}
}