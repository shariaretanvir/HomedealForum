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
    public partial class OnlineForum : System.Web.UI.MasterPage
    {
        SqlConnection con = new SqlConnection("Data Source=AKASH-PC\\SQLEXPRESS;Initial Catalog=Registration;Integrated Security=True");

        SqlCommand cmd;
        public string name;
        string phone;
        public int userId;

        protected void Page_Load(object sender, EventArgs e)
        {

           
            if (!IsPostBack)
            {
                GetData();
                cmd = new SqlCommand("SELECT [SubcategoryId],[SubcategoryName],[CategoryId] FROM [Subcategory]", con);
                con.Open();
                categoryDropDownList.DataSource = cmd.ExecuteReader();
                categoryDropDownList.DataBind();
                
            }
        }

        private void GetData()
        {
            SqlConnection con = new SqlConnection("Data Source=AKASH-PC\\SQLEXPRESS;Initial Catalog=Registration;Integrated Security=True");
            //cmd = new SqlCommand("SELECT top 5 [qId],[userId],[question]FROM [Questions] order by [qId] desc;", con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT top 10 [qId],[userId],[question]FROM [userQuestions] order by [qId] desc;", con);
            
            DataSet ds = new DataSet();
            da.Fill(ds);            
            Repeater1.DataSource = ds;
            Repeater1.DataBind();

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            
            try
            {
                string mail = this.mailBox.Text;
                string pass = this.passwordBox.Text;

                
                if (mail != "" && pass != "")
                {
                    con.Open();
                    string cmd = "SELECT [id],[name],[phone] FROM [userDetails] where [email]='" + mail + "' and [password]='" + pass + "';";
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd, con);
                    da.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        userId = Convert.ToInt32( dr["id"].ToString());                        
                        name = dr["name"].ToString();
                        phone = dr["phone"].ToString();
                        
                    }
                    
                    userInfo.Text = name +" (+88 "+phone+")" ;

                    Session["status"] = 1;
                    Session["userId"] = userId;
                    Session["userName"] = name;
                    Session["userPhone"] = phone;
                    
                }
                else
                {
                    MSGbox("You must provide your email & password");  
                }

                
            }
            catch (Exception ex)
            {
                //MSGbox("problem occured in database");
            }

        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            if (userInfo.Text == "")
            {
                MSGbox("You are not logged in");
            }
            else
            {
                //Session.Remove("User_name");
                Session.RemoveAll();
                userName.Text = null;
            }
        }
       

        protected void postQuestion_Click(object sender, EventArgs e)
        {
            int categoryId =Convert.ToInt32( categoryDropDownList.SelectedValue);
            string que = questionBox.Text;
            
            if (Session["status"] != null)
            {
                string uId = Session["userId"].ToString();
                int id = int.Parse(uId);
                try
                {
                    con.Open();
                    cmd = new SqlCommand("INSERT INTO [userQuestions] ([qCategoryId],[question],[userId]) VALUES ('" + categoryId + "','" + que + "','" + id + "')", con);
                    cmd.ExecuteNonQuery();

                    con.Close();

                    questionBox.Text = string.Empty;

                }
                catch (Exception ex)
                {

                }

                GetData();
            }
            else
            {

                MSGbox("To post an question login first");
            }
        }

        public Label userName
        {
            get
            {
                return this.userInfo;
            }
        }

        public void MSGbox(string msg)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language='javascript'>alert('" + msg + "')</script>");
        }
        
    }
}