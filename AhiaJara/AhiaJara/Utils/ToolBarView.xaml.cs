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
    public partial class ToolBarView : ContentView
    {
        public ToolBarView()
        {
            InitializeComponent();
        }

        void Back(System.Object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}