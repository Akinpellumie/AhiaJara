using AhiaJara.ViewModels;
using Sharpnado.Presentation.Forms.CustomViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AhiaJara.Utils
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PendingOrderView : ContentView
    {
        //ProductViewModel ProductViewModel;
        public PendingOrderView()
        {
            //ProductViewModel = new ProductViewModel(Navigation);
            InitializeComponent();
            //this.BindingContext = ProductViewModel;
        }

        public bool Animate { get; set; }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
        }
    }
}