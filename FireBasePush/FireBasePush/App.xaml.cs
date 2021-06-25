using FireBasePush.Helpers;
using FireBasePush.ViewModel;
using FireBasePush.Views;
using Plugin.FirebasePushNotification;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FireBasePush
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            CrossFirebasePushNotification.Current.OnTokenRefresh += async (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine("TOKEN => {0}", p.Token);
                await App.Current.MainPage.ShowSuccessAsync("Token refreshed", 5000);
            };

            CrossFirebasePushNotification.Current.OnNotificationOpened += async (s, p) =>
            {
                if (p.Data.ContainsKey("title"))
                {
                    if (p.Data["title"].ToString() == "Message")
                    {
                        //await App.Current.MainPage.Navigation?.PushAsync(new MessagePage());
                        await MainPage.Navigation.PushAsync(new MainPage());
                        await MainPage.Navigation.PushAsync(new MessagePage(""));
                    }
                    else if (p.Data["title"].ToString() == "Promotion")
                    {
                        //await App.Current.MainPage.Navigation?.PushAsync(new PormotionPage());
                        await MainPage.Navigation.PushAsync(new MainPage());
                        await MainPage.Navigation.PushAsync(new PormotionPage(""));
                    }
                }
            };

            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine(p.Data["body"].ToString());
            };
        }

        protected override void OnStart()
        {
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnSleep()
        {
            CrossFirebasePushNotification.Current.OnNotificationOpened += async (s, p) =>
            {
                if (p.Data.ContainsKey("title"))
                {
                    if (p.Data["title"].ToString() == "Message")
                    {
                        //await App.Current.MainPage.Navigation?.PushAsync(new MessagePage());
                        await MainPage.Navigation.PushAsync(new MainPage());
                        await MainPage.Navigation.PushAsync(new MessagePage(""));
                    }
                    else if (p.Data["title"].ToString() == "Promotion")
                    {
                        //await App.Current.MainPage.Navigation?.PushAsync(new PormotionPage());
                        await MainPage.Navigation.PushAsync(new MainPage());
                        await MainPage.Navigation.PushAsync(new PormotionPage(""));
                    }
                }
            };
        }

        protected override void OnResume()
        {
        }
    }
}
