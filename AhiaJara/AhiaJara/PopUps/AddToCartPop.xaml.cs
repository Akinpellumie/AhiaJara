using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AhiaJara.PopUps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddToCartPop
    {
        public AddToCartPop()
        {
            InitializeComponent();
        }

        public async void ClosePopUp_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);
        }
    }
}