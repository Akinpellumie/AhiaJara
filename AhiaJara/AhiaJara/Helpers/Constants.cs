using AhiaJara.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AhiaJara.Helpers
{
    public class Constants
    {
        public static string domainurl
        {
            get
            {
                //return "https://29cebf09-368c-4fb8-ba32-817ee979decc.mock.pstmn.io";
                //return "api-host-sample.herokuapp.com"
                return "https://ahiajara.herokuapp.com";
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
        public static string AllProductsUrl { get { return Constants.domainurl + "/products"; } }
        public static string AddToCart{ get { return Constants.domainurl + "/cart"; } }


        public static Models.UserProfile userprofile { get; set; }
        public static List<ProductModel> ProductsList { get; set; }

        public static int cartCount { get; set; } 
    }
}
