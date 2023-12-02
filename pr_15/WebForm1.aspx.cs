using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace pr_15
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vyas\source\repos\pr_15\pr_15\App_Data\Database1.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from [dbo].[user] where user='"+TextBox1.Text+"' and pass='"+TextBox2.Text+"';", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable user = new DataTable();
            sda.Fill(user);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (user.Rows.Count > 0)
            {
                Session["id"] = TextBox1.Text;
                Response.Redirect("Redirectform.aspx");
                Session.RemoveAll();
            }
            else
            {
                Label1.Text = "You're username and word is incorrect";
                Label1.ForeColor = System.Drawing.Color.Red;

            }
        }
    }
}