using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views.Options;
using Xamarin.Forms;

namespace FireBasePush.Helpers
{
    public static class CustomToast
    {

        public static async Task ShowSuccessAsync(this Page page,string message, int duration = 3000)
        {
            var toastOptions = new MessageOptions
            {
                Foreground = Color.White,
                Font = Font.OfSize("GroteskMedium", 16),
                Message = message
            };

            var options = new ToastOptions
            {
                MessageOptions = toastOptions,
                Duration = TimeSpan.FromMilliseconds(duration),
                BackgroundColor = Color.Green,
                IsRtl = false
            };

            await page.DisplayToastAsync(options);
        }

        public static async Task ShowWarningAsync(this Page page, string message, int duration = 3000)
        {
            var toastOptions = new MessageOptions
            {
                Foreground = Color.White,
                Font = Font.OfSize("GroteskMedium", 16),
                Message = message
            };

            var options = new ToastOptions
            {
                MessageOptions = toastOptions,
                Duration = TimeSpan.FromMilliseconds(duration),
                BackgroundColor = Color.DarkOrange,
                IsRtl = false
            };

            await page.DisplayToastAsync(options);
        }

        public static async Task ShowCriticalAsync(this Page page, string message, int duration = 3000)
        {
            var toastOptions = new MessageOptions
            {
                Foreground = Color.White,
                Font = Font.OfSize("GroteskMedium", 16),
                Message = message
            };

            var options = new ToastOptions
            {
                MessageOptions = toastOptions,
                Duration = TimeSpan.FromMilliseconds(duration),
                BackgroundColor = Color.Red,
                IsRtl = false
            };

            await page.DisplayToastAsync(options);
        }
    }
}
