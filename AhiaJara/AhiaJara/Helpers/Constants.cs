using AhiaJara.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AhiaJara.Helpers
{
    public static class Constants
    {
        public static string domainurl
        {
            get
            {
                //return "http://192.168.1.114:4000";
                return "https://ahiajara.herokuapp.com";
            }
        }
        public static string FaqUrl
        {
            get
            {
                return "https://ahiajara.netlify.app/faq";
            }
        }

        //public static string PeercoverUrl
        //{
        //    get
        //    {
        //        return "https://proguardpeercover.herokuapp.com";
        //    }
        //}
        // public static string MyTransactionsUrl { get { return Constants.domainurl + "/transactions/my_transactions/"; } }
        //public static string LoginUrl { get { return Constants.PeercoverUrl + "/user_auth/"; } }

        public static string RegisterUrl { get { return Constants.domainurl + "/member"; } }
        public static string LoginUrl { get { return Constants.domainurl + "/authenticate"; } }
        //public static string LoginUrl { get { return "http://192.168.43.162:5000" + "/authenticate"; } }
        public static string AllProductsUrl { get { return Constants.domainurl + "/products"; } }
        public static string LatestProductsUrl { get { return Constants.domainurl + "/products?limit=5&offset=1"; } }
        public static string AddToCart{ get { return Constants.domainurl + "/cart"; } }
        public static string GetCartCount{ get { return Constants.domainurl + "/cartcount/"; } }
        public static string GetCart{ get { return Constants.domainurl + "/cart/"; } }
        public static string PostQuestionaire{ get { return Constants.domainurl + "/questionniareentry"; } }
        public static string GetAdverts{ get { return Constants.domainurl + "/adverts"; } }
        public static string postSkinIssue{ get { return Constants.domainurl + "/newskinissue"; } }
        public static string getSkinIssue{ get { return Constants.domainurl + "/allskinissue"; } }
        public static string getIncompleteOrder{ get { return Constants.domainurl + "/incompletedorder/"; } }
        public static string getcompletedOrder{ get { return Constants.domainurl + "/completedorder/"; } }
        public static string postcompleteOrder{ get { return Constants.domainurl + "/completeorder/"; } }
        public static string postOrder{ get { return Constants.domainurl + "/order"; } }
        public static string postBespoke{ get { return Constants.domainurl + "/bespokeentry"; } }
        public static string getHairProducts{ get { return Constants.domainurl + "/products/Hair"; } }
        public static string RequestProduct{ get { return Constants.domainurl + "/requestproduct"; } }
        public static string getSkinProducts{ get { return Constants.domainurl + "/products/Skin"; } }
        public static string resetPassword{ get { return Constants.domainurl + "/resetpassword"; } }
        public static string uploadImage{ get { return Constants.domainurl + "/imagemember/"; } }
        public static string changePassword{ get { return Constants.domainurl + "/passwordchange"; } }
        public static string AllNotificationsUrl { get { return Constants.domainurl + "/allnotifications/"; } }
        public static string MyNotificationsUrl { get { return Constants.domainurl + "/notifications/"; } }
        public static string deleteCartItem { get { return Constants.domainurl + "/cart/"; } }
        public static string sendSupportMessage { get { return Constants.domainurl + "/message"; } }
        


        public static Models.UserProfile userprofile { get; set; }
        public static List<ProductModel> ProductsList { get; set; }
        public static List<ProductModel> HairProductsList { get; set; }
        public static List<ProductModel> SkinProductsList { get; set; }
        public static List<ProductModel> LatestProductsList { get; set; }
        public static List<Cart> CartItemList { get; set; }

        public static Models.SkinIssue skinIssue { get; set; }


        public static List<Product> CarouselItemList { get; set; }

        public static ArrayList singleOrder { get; set; }

        public static string ShippingDetails { get; set; }

        public static int cartCount { get; set; }

        public static bool Contains(this string target, string value, StringComparison comparison)
        {
            return target.IndexOf(value, comparison) >= 0;
        }


    }
}
