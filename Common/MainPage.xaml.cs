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
            NavigationPage.SetBackButtonTitle(this, "Back");
        }

        private void ButtonNavigationStack_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FirstNavigationStack());
        }

        private void ButtonModalStack_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new FirstModalStack()));
        }
    }
}
