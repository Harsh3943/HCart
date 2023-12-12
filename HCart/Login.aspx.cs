using HCart.Method;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCart
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoginMaster()
        {
            Common objc = new Common();
            DataTable dt = new DataTable();
            dt = objc.Login(txtusername.Text,txtPaaword.Text);

            if(dt != null && dt.Rows.Count>0) 
            {

                Response.Redirect("Category.aspx");
            
            }
            else

            {
                lblmessage.Text = "Username & Password is Incoreect";

            }




        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            LoginMaster();
        }
    }
}