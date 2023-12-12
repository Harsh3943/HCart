using HCart.Method;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCart
{
    public partial class Product : System.Web.UI.Page
    {
        Common objc = new Common();
        
        string str = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CategoryBind();
                SubCategoryBind();
                ProductGridView();
            }
        }

        public void CategoryBind()
        {
            SqlDataReader dataReader = null;

            dataReader = objc.BindCategory();

            ddlCategory.DataSource = dataReader;
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CategoryId";
            
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("---Select Category---", "0"));
        }

        public void SubCategoryBind()
        {

            DataTable dt = new DataTable();



            dt = objc.BindSubCategory(Convert.ToInt32(ddlCategory.SelectedValue));
            if (dt != null && dt.Rows.Count > 0)
            {
                ddlSubcategory.DataSource = dt;
                ddlSubcategory.DataTextField = "SubCategoryName";
                ddlSubcategory.DataValueField = "SubCategoryId";

                ddlSubcategory.DataBind();
                ddlSubcategory.Items.Insert(0, new ListItem("---Select SubCategory---", "0"));
            }
            else 
            {
                ddlSubcategory.DataSource = null;
                //ddlSubcategory.DataTextField = "SubCategoryName";
                //ddlSubcategory.DataValueField = "SubCategoryId";

                ddlSubcategory.DataBind();
                ddlSubcategory.Items.Clear();
                ddlSubcategory.Items.Insert(0, new ListItem("---Select SubCategory---", "0"));

            }


        }

        public void ProductGridView()
        {
            DataTable dt = new DataTable();
            dt = objc.GridViewProduct();

            GridProduct.DataSource= dt;
            GridProduct.DataBind();

        }

        public void UploadImage()
        {
            try
            {
                string filename = "", newfile = "";
                string[] validFileTypes = { "jpeg", "png", "jpg", "bmp", "gif" };

                if (!FileUploadImage.HasFile)
                {
                    this.Page.ClientScript.RegisterStartupScript(GetType(), "ShowAlert", "alert('Please select a file.');", true);
                    FileUploadImage.Focus();
                }


                string ext = System.IO.Path.GetExtension(FileUploadImage.PostedFile.FileName).ToLower();
                bool isValidFile = false;
                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (ext == "." + validFileTypes[i])
                    {
                        isValidFile = true;
                        break;
                    }
                }
                if (isValidFile == true)
                {

                    if (FileUploadImage.HasFile)
                    {

                        filename = Server.MapPath(FileUploadImage.FileName);
                        newfile = FileUploadImage.PostedFile.FileName;

                        FileInfo fi = new FileInfo(newfile);

                        // check folder exist or not
                        if (!System.IO.Directory.Exists(@"~\ProductPhoto\"))
                        {
                            try
                            {

                                string Imgname = txtProductName.Text;

                                string path = Server.MapPath(@"~\ProductPhoto");

                                System.IO.Directory.CreateDirectory(path);
                                FileUploadImage.SaveAs(path + @"\" + txtProductName.Text + ext);

                                ImageProfileImage.ImageUrl = @"~\ProductPhoto\" + txtProductName.Text + ext;
                                ImageProfileImage.Visible = true;

                                lblFilePath.Text = Imgname + ext;


                            }
                            catch (Exception ex)
                            {
                                lblFilePath.Text = "Not able to create new directory";
                            }

                        }
                    }
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(GetType(), "ShowAlert", "alert('Please select valid file.');", true);
                }
            }
            catch (Exception ex)
            {

            }

        }
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            AddPanel.Visible= true;
            ListPanel.Visible= false;
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubCategoryBind();
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            int Result = 0;

            Result=objc.AddProduct(Convert.ToInt32(ddlCategory.SelectedItem.Value), Convert.ToInt32(ddlSubcategory.SelectedItem.Value),txtProductTitle.Text,txtProductName.Text,Convert.ToDecimal(txtProductPrice.Text),Convert.ToInt32(txtProductQuantity.Text),txtShortDiscription.Text,txtLongDiscription.Text,lblFilePath.Text);
        }

        protected void BtnUplod_Click(object sender, EventArgs e)
        {
            UploadImage();
        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("Product.aspx");
        }
    }
}