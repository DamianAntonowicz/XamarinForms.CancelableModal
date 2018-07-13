using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XamarinForms.CancelableModal
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ButtonNavigationStack_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FirstNavigationStack());
//            Navigation.PushAsync(new NavigationPage(new FirstNavigationStack()));
        }

        private void ButtonModalStack_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new FirstModalStack()));
        }
    }
}
