using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineForum
{
    public partial class ForumHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["status"] != null)
            {
                ((OnlineForum)Master).userName.Text = Session["userName"].ToString() + " (+88 " + Session["userPhone"] + ")";
            }
        }
    }
}