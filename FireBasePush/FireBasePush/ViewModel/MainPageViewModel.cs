using FireBasePush.Helpers;
using FireBasePush.Views;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FireBasePush.ViewModel
{
    public class MainPageViewModel:BaseViewModel
    {

        public ICommand GoToMessageCommand { get; set; }
        public ICommand GoToPromotionCommand { get; set; }
        public ICommand GoToAboutCommand { get; set; }

        public MainPageViewModel()
        {
            Title = "Home";

            GoToAboutCommand = new Command(async () =>
            {
                await App.Current.MainPage.ShowWarningAsync("Consult our site...");
            });

            GoToMessageCommand = new Command(async () =>
            {
                await App.Current.MainPage.Navigation?.PushAsync(new MessagePage());
            });

            GoToPromotionCommand = new Command(async () =>
            {
                await App.Current.MainPage.Navigation?.PushAsync(new PormotionPage());
            });
        }
    }
}
