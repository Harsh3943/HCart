using HCart.Data;
using HCart.Method;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Xml.Linq;

namespace HCart
{
    public partial class Category : System.Web.UI.Page
    {
        internal object categoryid;
        internal readonly object isActive;
        HCartEntities1 db;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //GridViewCBind();
                BindGridC();
            }
        }

        public void GridViewCBind()
        {
            Common objc = new Common();
            DataTable dt = new DataTable();

            dt = objc.GridViewC();

            GridCategory.DataSource = dt;
            GridCategory.DataBind();

        }

        public void BindGridC()
        {
            db = new HCartEntities1();

            var res = (from C in db.Categories
                       orderby C.CategoryId ascending
                       where C.IsActive == true
                       select C).ToList();

            GridCategory.DataSource= res;
            GridCategory.DataBind();
        }

        public void AddCategorybymodel(int Categoryid)
        {

            




        }
        private long CategoryId
        {
            get
            {
                if (ViewState["CategoryId"] != null)
                {
                    return (long)ViewState["CategoryId"];
                }
                return 0;

            }
            set
            {
                ViewState["CategoryId"] = value;
            }
        }
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            AddPanel.Visible = true;
            ListPanel.Visible = false;
        }

        protected void GridCategory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Common objc = new Common();
            int CategoryID = 0;
            CategoryID = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "CategoryDelete")
            {
                int IsResult = 0;

                IsResult = objc.DeleteCategory(CategoryID);
                GridViewCBind();


            }
            if (e.CommandName == "CategoryEdit")
            {
                CategoryId = CategoryID;
                AddPanel.Visible = true;
                ListPanel.Visible = false;
                DataTable dt = objc.GetSelectCategory(CategoryID.ToString());
                
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtCName.Text = dt.Rows[0]["CategoryName"].ToString();
                    txtDetail.Text = dt.Rows[0]["Detail"].ToString();

                }

            }
            
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

                                string Imgname = txtCName.Text;

                                string path = Server.MapPath(@"~\ProductPhoto");

                                System.IO.Directory.CreateDirectory(path);
                                FileUploadImage.SaveAs(path + @"\" + txtCName.Text + ext);

                                ImageProfileImage.ImageUrl = @"~\ProductPhoto\" + txtCName.Text + ext;
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

        protected void btnserch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtserch.Text))
             {
            Common objc = new Common();

                DataTable dt = new DataTable(); 
                 dt=   objc.SearchCategoryByName(txtserch.Text);

                // Bind the search results to the GridView
                GridCategory.DataSource = dt;
                GridCategory.DataBind();
            }
            else
            {
                //If search keyword is empty, bind all employees
                GridViewCBind();
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            Common objc = new Common();
            int Result = 0;
            
            Result=objc.InsertCatagory(Convert.ToInt32(CategoryId),txtCName.Text,txtDetail.Text,lblFilePath.Text);
        }

        protected void BtnUplod_Click(object sender, EventArgs e)
        {
            UploadImage();
        }
    }
}