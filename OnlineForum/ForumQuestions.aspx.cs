using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace OnlineForum
{
    public partial class MobileForum : System.Web.UI.Page
    {
        int userId,id;
        string userName, userPhone;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = int.Parse((Request.QueryString["id"]));
            
            GetData();           
           
            if (Session["status"] != null)
            {
                ((OnlineForum)Master).userName.Text = Session["userName"].ToString() + " (+88 " + Session["userPhone"] + ")";

                userId = int.Parse(Session["userId"].ToString());
                userName = Session["userName"].ToString();
                userPhone = Session["userPhone"].ToString();
            
            }

        }
        private void GetData()
        {
            SqlConnection con = new SqlConnection("Data Source=AKASH-PC\\SQLEXPRESS;Initial Catalog=Registration;Integrated Security=True");
           
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT top 5 [qId],[userId],[question]FROM [userQuestions] where [qCategoryId]='"+ id +"' order by qId desc;", con);

            DataSet ds = new DataSet();
            da.Fill(ds);
            
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
            //return ds;
                       

        }

        
    }
}