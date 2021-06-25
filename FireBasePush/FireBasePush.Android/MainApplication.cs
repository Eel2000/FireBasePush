using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase;
using Plugin.FirebasePushNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FireBasePush.Droid
{
    [Application]
    public class MainApplication:Application
    {
        public MainApplication(IntPtr intPtr, JniHandleOwnership handler):base(intPtr,handler)
        {

        }

        public override void OnCreate()
        {
            base.OnCreate();
            //FirebaseApp.InitializeApp(Context);

            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
            {
                FirebasePushNotificationManager.DefaultNotificationChannelId = "DefaultFBPushNotificationChannel";
                FirebasePushNotificationManager.DefaultNotificationChannelName = "General";
            }

#if DEBUG
            FirebasePushNotificationManager.Initialize(this, true);
#else
            FirebasePushNotificationManager.Initialize(this, false);
#endif

            CrossFirebasePushNotification.Current.OnNotificationReceived += Current_OnNotificationReceived;
            CrossFirebasePushNotification.Current.OnNotificationOpened += Current_OnNotificationOpened;
        }

        private void Current_OnNotificationOpened(object source, FirebasePushNotificationResponseEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Opened");
        }

        private void Current_OnNotificationReceived(object source, FirebasePushNotificationDataEventArgs e)
        {
            //do somethings here
        }
    }
}