using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SQLInjection
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SampleConnectionString"].ConnectionString);
            SqlCommand com = new SqlCommand("Select * from Sample_Table where Name= @Name", conn);
            com.Parameters.Add(new SqlParameter("@Name",TextBox1.Text));
           
            conn.Open();
            GridView1.DataSource = com.ExecuteReader();
            GridView1.DataBind();
            conn.Close();
        }

        //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SampleConnectionString"].ConnectionString);
        //SqlCommand com = new SqlCommand("Select * from Sample_Table where Name= '" + TextBox1.Text + "'", conn);
        //conn.Open();
        //    GridView1.DataSource = com.ExecuteReader();
        //    GridView1.DataBind();
        //    conn.Close();
    }
}