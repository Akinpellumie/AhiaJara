using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AhiaJara.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PayStackPage : ContentPage
    {
        public PayStackPage()
        {
            InitializeComponent();

            JArray jarray = new JArray();
            dynamic customFieldsArray = new JArray();

            dynamic displayname = new JObject();
            displayname.display_name = "Mobile Number";
            displayname.variable_name = "mobile_number";
            displayname.@value = "+23480000000";

            customFieldsArray.Add(displayname);
            dynamic jobtitlefield = new JObject();
            jobtitlefield.display_name = "Job Title";
            jobtitlefield.variable_name = "job_title";
            jobtitlefield.@value = "Software Developer";

            customFieldsArray.Add(jobtitlefield);



            dynamic custom = new JObject();
            custom.custom_fields = customFieldsArray;

            dynamic product = new JObject();
            product.key = "pk_live_472e7785d2a12c332ef662d659c6007772e5a54b";
            product.email = "ahiajara007@gmail.com";
            product.amount = 490000m;
            //product.subaccount = "ACCT_zpve61wnc0fbs6b";
            product.bearer = "account";
            product.@ref = Guid.NewGuid();
            product.metadata = custom;

            hybridWebView.Data = product.ToString();


            hybridWebView.RegisterCloseAction(() => DisplayAlert("WebView Closed", "Close button clicked", "ok"));
            hybridWebView.RegisterCallBackAction(data => DisplayAlert("Alert", "Hello " + data, "OK"));

        }

        private void HybridWebView_PaymentClosed(object sender, string e)
        {
            DisplayAlert("WebView Closed", "Close button clicked event", "ok");
        }



        private void hybridWebView_PaymentSuccessful(object sender, string e)
        {
            DisplayAlert("Alert", "Payment Reference: " + e, "OK");
        }
    }
}