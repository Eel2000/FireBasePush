using FireBasePush.Helpers;
using FireBasePush.Views;
using MvvmHelpers;
using Plugin.FirebasePushNotification;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FireBasePush.ViewModel
{
    public class MainPageViewModel:BaseViewModel
    {

        private ObservableCollection<string> _subsriptions;

        public ObservableCollection<string> Subsriptions
        {
            get => _subsriptions;
            set => SetProperty(ref _subsriptions, value);
        }

        public ICommand GoToMessageCommand { get; set; }
        public ICommand GoToPromotionCommand { get; set; }
        public ICommand GoToAboutCommand { get; set; }
        public ICommand SubcribeToStudentCommand { get; set; }
        public ICommand SubcribeToParentCommand { get; set; }
        public ICommand UnSubcribeCommand { get; set; }
        public ICommand DisplaySubscriptionsCommand { get; set; }

        public MainPageViewModel()
        {
            Title = "Home";
            Subsriptions = new ObservableCollection<string>();

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

            SubcribeToParentCommand = new Command(() =>
            {
                CrossFirebasePushNotification.Current.Subscribe("Parent");
            });

            SubcribeToStudentCommand = new Command(() =>
            {
                CrossFirebasePushNotification.Current.Subscribe("Student");
            });

            UnSubcribeCommand = new Command(() =>
            {
                CrossFirebasePushNotification.Current.UnsubscribeAll();
                Subsriptions = new ObservableCollection<string>();
            });

            DisplaySubscriptionsCommand = new Command(() =>
            {
                
                var subscriptions = CrossFirebasePushNotification.Current.SubscribedTopics;
                foreach (var item in subscriptions)
                {
                    Subsriptions.Add(item);
                }
            });
        }
    }
}
