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
    public partial class ViewProductUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblProductId.Text = Request.QueryString["ProductID"];
            BindProduct();
        }
        public void BindProduct()
        {

            Common objc = new Common();
            DataTable dt = new DataTable();

            dt = objc.GetProduct(Convert.ToInt32(lblProductId.Text));

            if (dt != null && dt.Rows.Count > 0)
            {
                ImageView.ImageUrl = "~/ProductPhoto/" + dt.Rows[0]["ProductImage"].ToString();

                lblTitle.Text = dt.Rows[0]["ProductName"].ToString();
                lblShortDesc.Text = dt.Rows[0]["ShortDiscription"].ToString();
                lblLongDesc.Text = dt.Rows[0]["LongDiscription"].ToString();
                lblViewPrice.Text = dt.Rows[0]["ProductPrice"].ToString();
                lblViewQty.Text = dt.Rows[0]["ProductQuantity"].ToString();

            }

        }

        protected void btnGoBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductList.aspx");

        }
    }

}