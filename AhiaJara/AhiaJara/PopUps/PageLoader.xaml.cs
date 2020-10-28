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
    public partial class PageLoader
    {
        public PageLoader()
        {
            InitializeComponent();
            logEff.FadeTo(Opacity, 50, Easing.BounceIn);
        }
    }
}