using FireBasePush.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FireBasePush.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PormotionPage : ContentPage
    {
        public PormotionPage()
        {
            InitializeComponent();
            BindingContext = new PromotionPageViewModel();
        }
        
        public PormotionPage(string message=null)
        {
            InitializeComponent();
            BindingContext = new PromotionPageViewModel("");
        }
    }
}