using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.IO;

using Facebook;

namespace OnlineForum
{
    public partial class QuestionDeatils : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=AKASH-PC\\SQLEXPRESS;Initial Catalog=Registration;Integrated Security=True");

        SqlCommand cmd;
        int userId, qid;
        string que, q, uName, userName, userPhone;

       
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["status"] != null)
            {
                ((OnlineForum)Master).userName.Text = Session["userName"].ToString() + " (+88 " + Session["userPhone"] + ")";

                userId = int.Parse(Session["userId"].ToString());
                userName = Session["userName"].ToString();
                userPhone = Session["userPhone"].ToString();
                commenterName.Text = userName;

            }
            if (!IsPostBack)
            {

                GetData();
                commenterName.Text = userName;
            }


            q = (Request.QueryString["id"]);
            qid = int.Parse(q);

            con.Open();
            string cmd = "select [qId],[qCategoryId],[question],[userId],[name] from [Registration].[dbo].[UserQuestions] inner join [Registration].[dbo].[UserDetails] on [UserQuestions].[userId]=[UserDetails].[id] where [UserQuestions].[qId]= '" + qid + "' ;";

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd, con);
            da.Fill(dt);

            int a = dt.Rows.Count;
            foreach (DataRow dr in dt.Rows)
            {
                //int qId = Convert.ToInt32(dr["qId"].ToString());
                que = dr["question"].ToString();
                uName = dr["name"].ToString();

            }
            question.Text = que;
            usreName.Text = "by " + uName;

            GetData();

           
        }

        private void GetData()
        {
            SqlConnection con = new SqlConnection("Data Source=AKASH-PC\\SQLEXPRESS;Initial Catalog=Registration;Integrated Security=True");

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select comment,UserId,name,commentDate from [Registration].[dbo].[Comments] inner join [Registration].[dbo].[UserDetails] on [Comments].[UserId] =[UserDetails].[id] where [queId]= '" + qid + "' ", con);

            DataSet ds = new DataSet();
            da.Fill(ds);
            commentRepeater.DataSource = ds;
            commentRepeater.DataBind();

        }

        protected void commentButton_Click(object sender, EventArgs e)
        {
            string cmt = commentBox.Text;
            int uId = userId;
            DateTime date = DateTime.Now;

            if (Session["status"] != null)
            {
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=AKASH-PC\\SQLEXPRESS;Initial Catalog=Registration;Integrated Security=True");

                    con.Open();
                    cmd = new SqlCommand("insert into [Registration].[dbo].[Comments] ([comment],[queId],[UserId],[commentDate]) values ('" + cmt + "','" + qid + "','" + uId + "','" + date + "')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    commentBox.Text = string.Empty;

                }
                catch (Exception ex)
                {

                }
                GetData();
            }
            else
            {

                MSGbox("To post a comment login first");
            }
        }

       

        protected void fbShareButton_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string app_id = "654429374658070";
                string app_secret = "66e85a4b5e67a3a309d4e78d00d391ba";
                string scope = "publish_actions,manage_pages";//// publish_stream,manage_pages,publish_actions

                if (Request["code"] == null)/////
                {
                    Response.Redirect(string.Format("https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope={2}",
                        app_id, Request.Url.AbsoluteUri, scope));
                    //MSGbox("You are now logged in to facebook. Share now");
                }
                else
                {
                    Dictionary<string, string> tokens = new Dictionary<string, string>();
                    string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&scope={2}&code={3}&client_secret={4}",
                        app_id, Request.Url.AbsoluteUri, scope, Request["code"].ToString(), app_secret);

                    HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream());

                        string vals = reader.ReadToEnd();
                        foreach (string token in vals.Split('&'))
                        {
                            tokens.Add(token.Substring(0, token.IndexOf("=")),
                                token.Substring(token.IndexOf("=") + 1, token.Length - token.IndexOf("=") - 1));
                        }
                    }


                    string access_token = tokens["access_token"];
                    var client = new FacebookClient(access_token);

                    string postUrl = Request.Url.AbsoluteUri;
                    string[] splitedUrl = postUrl.Split('&');
                    string targetUrl = splitedUrl[0];

                    client.Post("/me/feed", new { message = "Check the HomeDeal Forum: "+ targetUrl });//////
                    
                    MSGbox("Shared on your facebook wall");
                }
            }
            catch (Exception ex)
            {
                MSGbox(ex.ToString());
            }

        }

        public void MSGbox(string msg)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language='javascript'>alert('" + msg + "')</script>");
        }

    }
}