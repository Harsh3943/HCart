using HCart.Method;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HCart
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHCartShoping" in both code and config file together.
    [ServiceContract]
    public interface IHCartShoping
    {
        [OperationContract]
        void DoWork();

        #region API

        #region Catagory List
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetCategoryList", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        checkCategorylist GetCategoryList();
        #endregion


        #region SubCategory List
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetSubCategoryList", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        checkSubCategorylist GetSubCategoryList();
        #endregion

        #region POST Category
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "AddCategory", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        checkCategoryinsert AddCategory(int CategoryId, string CategoryName, string Detail, string CategoryImage);
        #endregion

        #endregion

        #region Entity Model

        #region Category List
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetCategoryByModel", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        checkCategorylist GetCategoryByModel();
        #endregion

        #region SubCategory List
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetSubCategoryByModel", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        checkSubCategorylist GetSubCategoryByModel();
        #endregion

        #endregion
    }


}
