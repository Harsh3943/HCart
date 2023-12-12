using HCart.Method;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCart
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public void Regstration()
        {
            int Result = 0;
            Common objc = new Common();

            Result=objc.UserandLoginADD(txtfullname.Text,txtEmail.Text,txtRPassword.Text);

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Regstration();
        }
    }
}