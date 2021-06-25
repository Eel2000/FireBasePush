using FireBasePush.Helpers;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FireBasePush.ViewModel
{
    class PromotionPageViewModel : BaseViewModel
    {
        public PromotionPageViewModel()
        {
            Title = "Promotions";
        }

        public PromotionPageViewModel(string message)
        {
            Title = "Promotions";
            Event();
        }

        private async void Event()
        {
            await App.Current.MainPage.ShowWarningAsync("New Promotion is Out...");
        }
    }
}
