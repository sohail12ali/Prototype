using Prototype.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Prototype.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public ICommand NavigateCommand { get; set; }

        public HomePageViewModel()
        {
            NavigateCommand = new Command(async () => await Navigation.PushAsync(new ItemsPage()));
        }
    }
}