using FireBasePush.Helpers;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FireBasePush.ViewModel
{
    public class MessagePageViewModel:BaseViewModel
    {
        public MessagePageViewModel()
        {
            Title = "Messages";
        }

        public MessagePageViewModel(string message = null)
        {
            Title = "Messages";
            Event();
        }

        private async void Event()
        {
            await App.Current.MainPage.ShowWarningAsync("New Message received...");
        }
    }
}
