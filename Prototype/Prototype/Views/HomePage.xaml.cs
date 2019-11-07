using Prototype.ViewModels;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototype.Views
{
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            Title = "Home Page";
            (BindingContext as HomePageViewModel).Navigation = Navigation;
        }
    }
}