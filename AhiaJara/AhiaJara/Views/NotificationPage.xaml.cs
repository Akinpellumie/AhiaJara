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
    public partial class NotificationPage : ContentPage
    {
        public NotificationPage()
        {
            InitializeComponent();
        }

        private void NotSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (ListStack.IsVisible == true)
            {
                ListStack.IsVisible = false;
            }
            else if (ListStack.IsVisible == false)
            {
                ListStack.IsVisible = true;
            }
        }
    }
}