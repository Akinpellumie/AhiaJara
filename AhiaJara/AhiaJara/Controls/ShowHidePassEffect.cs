using Xamarin.Forms;

namespace AhiaJara.Controls
{
    public class ShowHidePassEffect : RoutingEffect
    {
        public string Entry { get; set; }
        public ShowHidePassEffect() : base("Xamarin.ShowHidePassEffect") { }
    }
}