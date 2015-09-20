using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

namespace OnlineForum
{
    public partial class UserRegister : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=AKASH-PC\\SQLEXPRESS;Initial Catalog=Registration;Integrated Security=True");

        SqlCommand cmd;
        int userId;
        string userName, userPhone;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["status"] != null)
            {
                ((OnlineForum)Master).userName.Text = Session["userName"].ToString() + " (+88 " + Session["userPhone"] + ")";

                userId = int.Parse(Session["userId"].ToString());
                userName = Session["userName"].ToString();
                userPhone = Session["userPhone"].ToString();


            }
        }

        protected void registerButton_Click(object sender, EventArgs e)
        {
            if (Session["status"] == null)  //login checking
            {
                string name = userNameTextBox.Text;
                string email = mailTextBox.Text;
                string phone = phoneTextBox.Text;
                string password = passwordTextBox.Text;

                int i = 0;

                con.Open();
                string query = "select [email] from [Registration].[dbo].[UserDetails];";

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(dt);

                int a = dt.Rows.Count;
                foreach (DataRow dr in dt.Rows) //email cheking
                {
                    if (email == dr["email"].ToString())
                    {
                        i = 1;
                        break;
                    }


                }

                if (i == 0) //email ok then
                {

                    cmd = new SqlCommand("insert into [Registration].[dbo].[UserDetails] ([name],[email],[phone],[password]) values ('" + name + "','" + email + "','" + phone + "','" + password + "')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    string link="http://localhost:25384/ForumHomePage.aspx#login";

                    MailMessage msg = new MailMessage();
                    msg.From = new MailAddress("jobayershoaib@gmail.com");
                    msg.To.Add(email);
                    msg.Subject = "HomeDeal Registration";
                    msg.Body = "Hi " + name + " your registration to HomeDeal.com has been completed. Your Email address is " + email + " Phone number is " + phone + " and Password is " + password +  ". For confirmation go to :"+ link +" Thank you " + name + " for dealing with HomeDeal.";
                    msg.IsBodyHtml = true;

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    System.Net.NetworkCredential netCredential = new System.Net.NetworkCredential();
                    netCredential.UserName = "jobayershoaib@gmail.com";
                    netCredential.Password = "110104098";
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = netCredential;
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Send(msg);


                    MSGbox("Registration completed. An email has been send to " + email);
                    userNameTextBox.Text="";                
                    mailTextBox.Text="";
                    phoneTextBox.Text="";
                    passwordTextBox.Text="";



                }
                else
                {
                    MSGbox("Email address already exists");
                }
            }
            else
            {
                MSGbox("To register a user logout first");
            }
        }
        public void MSGbox(string msg)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language='javascript'>alert('" + msg + "')</script>");
        }
    }
}